using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace sithijaa
{
    public partial class manageathletes : Form
    {
        private string connStr = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=KickBlastJudo;Integrated Security=True;TrustServerCertificate=True";

        // Store selected athlete ID
        private int selectedAthleteID = -1;

        public manageathletes()
        {
            InitializeComponent();
            dgvAthletes.CellClick += dgvAthletes_CellClick;
        }

        private void manageathletes_Load(object sender, EventArgs e)
        {
            LoadAthletes();
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadAthletes()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    string query = "SELECT * FROM Athletes";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAthletes.DataSource = dt;

                    // Clear selection
                    dgvAthletes.ClearSelection();
                    selectedAthleteID = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading athletes: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string plan = cbTrainingPlan.SelectedItem?.ToString() ?? "";
                int hours = Convert.ToInt32(txtPrivateHours.Text);
                int comps = Convert.ToInt32(txtCompetitions.Text);

                // Rule 1: Private hours must be less than 20
                if (hours >= 20)
                {
                    MessageBox.Show("Private coaching hours must be less than 20 per month.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Rule 2: Beginners cannot have competitions
                if (plan == "Beginner" && comps > 0)
                {
                    MessageBox.Show("Beginners are not allowed to enter competitions.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    string query = @"INSERT INTO Athletes 
(Name, TrainingPlan, CurrentWeight, CompetitionCategory, Competitions, PrivateHours)
VALUES (@name, @plan, @weight, @category, @comps, @hours)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@plan", plan);
                    cmd.Parameters.AddWithValue("@weight", Convert.ToDecimal(txtWeight.Text));
                    cmd.Parameters.AddWithValue("@category", cbCategory.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@comps", comps);
                    cmd.Parameters.AddWithValue("@hours", hours);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Athlete added successfully!");
                LoadAthletes();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding athlete: " + ex.Message);
            }
        }


        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal baseFee = 0;
                string plan = cbTrainingPlan.SelectedItem?.ToString() ?? "";

                switch (plan)
                {
                    case "Beginner":
                        baseFee = 100;
                        break;
                    case "Intermediate":
                        baseFee = 150;
                        break;
                    case "Elite":
                        baseFee = 200;
                        break;
                }

                int comps = Convert.ToInt32(txtCompetitions.Text);
                int hours = Convert.ToInt32(txtPrivateHours.Text);
                decimal total = baseFee + comps * 50 + hours * 20;

                MessageBox.Show($"Total cost for {txtName.Text}: {total:C2}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating cost: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedAthleteID == -1)
            {
                MessageBox.Show("Select an athlete to delete.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    string query = "DELETE FROM Athletes WHERE AthleteID=@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", selectedAthleteID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Athlete deleted successfully!");
                LoadAthletes();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting athlete: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtWeight.Clear();
            txtCompetitions.Clear();
            txtPrivateHours.Clear();
            cbTrainingPlan.SelectedIndex = -1;
            cbCategory.SelectedIndex = -1;

            // Reset selection
            dgvAthletes.ClearSelection();
            selectedAthleteID = -1;
        }

        private void dgvAthletes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvAthletes.Rows[e.RowIndex];

            // Store ID for delete/update
            selectedAthleteID = Convert.ToInt32(row.Cells["AthleteID"].Value);

            txtName.Text = row.Cells["Name"].Value.ToString();
            cbTrainingPlan.SelectedItem = row.Cells["TrainingPlan"].Value.ToString();
            txtWeight.Text = row.Cells["CurrentWeight"].Value.ToString();
            cbCategory.SelectedItem = row.Cells["CompetitionCategory"].Value.ToString();
            txtCompetitions.Text = row.Cells["Competitions"].Value.ToString();
            txtPrivateHours.Text = row.Cells["PrivateHours"].Value.ToString();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void pbback_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
