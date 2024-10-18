using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace silo_connect
{
    public partial class Form2 : Form
    {
        public string Username { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;

        public Form2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent; // Center this form
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Username = txtUsername.Text;
            Password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Initialization logic (if needed)
        }
    }
}
