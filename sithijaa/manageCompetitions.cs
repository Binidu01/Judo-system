using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace sithijaa
{
    public partial class manageCompetitions : Form
    {
        private string connStr = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=KickBlastJudo;Integrated Security=True;TrustServerCertificate=True";

        public manageCompetitions()
        {
            InitializeComponent();
        }

        private void manageCompetitions_Load(object sender, EventArgs e)
        {
            txtfee.Text = "50"; // fixed fee
            dtpCompetitionDate.Value = GetNextSecondSaturday(DateTime.Now); // set default date
            LoadAthleteIDs();
            LoadCompetitions();
        }

        // Load all Athlete IDs into ComboBox
        private void LoadAthleteIDs()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    string query = "SELECT AthleteID, Name FROM Athletes ORDER BY AthleteID";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbid.DataSource = dt;
                    cbid.DisplayMember = "AthleteID"; // shown in ComboBox
                    cbid.ValueMember = "AthleteID";   // actual value
                }

                cbid.SelectedIndexChanged += cbid_SelectedIndexChanged;

                // Automatically select first user with ID = 1
                for (int i = 0; i < cbid.Items.Count; i++)
                {
                    DataRowView drv = cbid.Items[i] as DataRowView;
                    if (drv != null && Convert.ToInt32(drv["AthleteID"]) == 1)
                    {
                        cbid.SelectedIndex = i;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Athlete IDs: " + ex.Message);
            }
        }

        // Update Name textbox when ID changes
        private void cbid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbid.SelectedItem == null) return;

            DataRowView drv = cbid.SelectedItem as DataRowView;
            if (drv != null)
            {
                txtAthleteName.Text = drv["Name"].ToString();
            }
        }

        // Register athlete for competition
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (cbid.SelectedItem == null)
            {
                MessageBox.Show("Please select an athlete ID.");
                return;
            }

            try
            {
                int athleteID = Convert.ToInt32(cbid.SelectedValue);
                decimal fee = Convert.ToDecimal(txtfee.Text);
                DateTime competitionDate = dtpCompetitionDate.Value;

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    string query = @"INSERT INTO Competitions (AthleteID, CompetitionDate, Fee)
                                     VALUES (@athleteID, @date, @fee)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@athleteID", athleteID);
                    cmd.Parameters.AddWithValue("@date", competitionDate);
                    cmd.Parameters.AddWithValue("@fee", fee);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Athlete registered successfully!");
                LoadCompetitions();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error registering athlete: " + ex.Message);
            }
        }

        // Clear selection
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (cbid.Items.Count > 0)
                cbid.SelectedIndex = 0;
            txtAthleteName.Clear();
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Load all registered competitions into DataGridView
        private void LoadCompetitions()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    string query = @"SELECT c.CompetitionID, c.AthleteID, a.Name, c.CompetitionDate, c.Fee
                                     FROM Competitions c
                                     INNER JOIN Athletes a ON c.AthleteID = a.AthleteID
                                     ORDER BY c.CompetitionDate";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCompetitions.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading competitions: " + ex.Message);
            }
        }

        // Helper: get next 2nd Saturday of given month
        private DateTime GetNextSecondSaturday(DateTime fromDate)
        {
            DateTime firstDay = new DateTime(fromDate.Year, fromDate.Month, 1);
            int dayOffset = ((int)DayOfWeek.Saturday - (int)firstDay.DayOfWeek + 7) % 7;
            DateTime firstSaturday = firstDay.AddDays(dayOffset);
            DateTime secondSaturday = firstSaturday.AddDays(7);
            return secondSaturday;
        }

        private void pbback_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
