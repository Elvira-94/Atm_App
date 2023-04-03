using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Entity;
using System.Runtime.Remoting;

namespace Atm_App
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtAccountNumber.Text.Trim() == "" && txtPin.Text.Trim() == "")
            {
                MessageBox.Show("Empty fields", "Error");
            }
            else 
            {

                try
                {
                    AccountRetriever retriever = new AccountRetriever();
                    Account loggedInAccount = new AccountRetriever().GetAccountWithPin(txtAccountNumber.Text, txtPin.Text);
                    MainApplicationForm mainForm = new MainApplicationForm(loggedInAccount);
                    mainForm.Show();
                    this.Hide();
                }
                catch
                {
                    MessageBox.Show("Invalid login credentials. Please try again");
                }
            }
            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
