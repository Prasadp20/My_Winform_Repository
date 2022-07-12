using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleWinForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUserId.Text == "admin" && txtPassword.Text == "123")
            {
                MessageBox.Show("Sucess");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void btnReaset_Click(object sender, EventArgs e)
        {
            txtUserId.Clear();
            txtPassword.Clear();
        }
    }
}
