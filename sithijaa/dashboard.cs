using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sithijaa
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbmgal_Click(object sender, EventArgs e)
        {
            manageathletes manageathletes = new manageathletes();
            manageathletes.Show();
            this.Hide();
        }

        private void pbtgpn_Click(object sender, EventArgs e)
        {

        }

        private void pbcmpn_Click(object sender, EventArgs e)
        {
            manageCompetitions manageCompetitions = new manageCompetitions();
            manageCompetitions.Show();
            this.Hide();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();   

        }
    }
}
