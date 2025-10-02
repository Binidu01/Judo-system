using System;
using System.Windows.Forms;

namespace sithijaa
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void cbshpd_CheckedChanged(object sender, EventArgs e)
        {
            // If this is a "Show Password" checkbox, we can toggle the password visibility
            if (cbshpd.Checked)
            {
                txtpd.UseSystemPasswordChar = false;
            }
            else
            {
                txtpd.UseSystemPasswordChar = true;
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtun.Text.Trim();
            string password = txtpd.Text.Trim();

            if (username == "admin" && password == "admin")
            {
                MessageBox.Show("✅ Login successful!", "Welcome",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Hide login form and open Dashboard
                this.Hide();
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("❌ Invalid username or password.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtpd.UseSystemPasswordChar = true;
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
