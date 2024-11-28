using AMRConnector;
using System;
using System.Windows.Forms;

namespace Hotel_Management_System
{
    public partial class FormLogin : Form
    {
        private DbConnector db;

        public FormLogin()
        {
            InitializeComponent();
            db = new DbConnector();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void pictureBoxMinimzed_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxMinimzed, "Minimize");
        }

        private void pictureBoxMinimzed_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxClose_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxClose, "Close");
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxHide_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxHide, "Hide");
        }

        private void pictureBoxShow_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxShow, "Show");
        }

        private void pictureBoxShow_Click(object sender, EventArgs e)
        {
            pictureBoxShow.Hide();
            textBoxPassword.UseSystemPasswordChar = false;
            pictureBoxHide.Show();
        }

        private void pictureBoxHide_Click(object sender, EventArgs e)
        {
            pictureBoxHide.Hide();
            textBoxPassword.UseSystemPasswordChar = true;
            pictureBoxShow.Show();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            bool check = db.IsValidNamePass(textBoxUsername.Text.Trim(), textBoxPassword.Text.Trim());

            if (!check)
            {
                MessageBox.Show("Invalid Username Or Password", "Username Or Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBoxUsername.Text.Trim() == string.Empty || textBoxPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please fill out all field", "Required field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            textBoxUsername.Clear();
            textBoxPassword.Clear();

            FormDashboard fd = new FormDashboard();
            fd.Username = textBoxUsername.Text;
            fd.Show();
        }
    }
}