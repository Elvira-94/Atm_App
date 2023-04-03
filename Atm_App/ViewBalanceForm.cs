using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atm_App
{
    public partial class ViewBalanceForm : Form
    {
        public ViewBalanceForm(MainApplicationForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        static MainApplicationForm MainForm;

        public MainApplicationForm mainForm
        {
            get
            {
                return MainForm;
            }
            set
            {
                MainForm = value;
            }
        }

        private void ViewBalanceForm_Load(object sender, EventArgs e)
        {
            this.mainForm.ResetInactivityTimer();

            lblAccountName.Text = this.mainForm.loggedInAccount.accountNumber; //passing parameter AccountName from Main Page

            string query = "SELECT Balance FROM BankAccount WHERE AccountNumber = @AccountNumber";
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=Bank Data.db");
            conn.Open();

            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@AccountNumber", lblAccountName.Text);
            

            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                
                decimal balance = reader.GetDecimal(0);
                lblBalance.Text = $"Your current balance is: {balance:C}"; //display the current balance to the user
                reader.Close();
            }
            else
            {
                MessageBox.Show("Unable to retrieve balance");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void btnMainPage_Click(object sender, EventArgs e)
        {
            //MainApplicationForm loginForm = new MainApplicationForm();
            this.mainForm.ResetInactivityTimer();
            this.mainForm.Show();
            this.Hide();
        }
    }
}
