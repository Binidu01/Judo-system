using System;
using System.Windows.Forms;

namespace sithijaa
{
    public partial class loading : Form
    {
        public loading()
        {
            InitializeComponent();
        }

        private void loading_Load(object sender, EventArgs e)
        {
            // Set ProgressBar style
            progbar.Minimum = 0;
            progbar.Maximum = 100;
            progbar.Value = 0;
            progbar.Step = 2;

            // Configure Timer
            timer.Interval = 50; // 50 ms → smooth loading
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (progbar.Value < progbar.Maximum)
            {
                progbar.PerformStep();
                lblStatus.Text = $"Loading... {progbar.Value}%";
            }
            else
            {
                timer.Stop();
                this.Hide();

                // Open Login Form after loading finishes
                LoginForm login = new LoginForm();
                login.Show();
            }
        }
    }
}
