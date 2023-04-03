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
    public partial class ChangePinForm : Form
    {
        public ChangePinForm(MainApplicationForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        static MainApplicationForm MainForm;

        public MainApplicationForm mainForm
        {
            get { 
                return MainForm; 
            }
            set { 
                MainForm = value; 
            }
        }

        private void ChangePinForm_Load(object sender, EventArgs e)
        {
            this.mainForm.ResetInactivityTimer();
            lblAccountName.Text = this.mainForm.loggedInAccount.accountNumber;
        }

        //return true if user enters valid number
        private bool validateTextBox()
        {
            double value;

            if(Double.TryParse(txtNewPin.Text, out value))
            {

                if (txtNewPin.Text.Length <= 4)
                {
                    return true;
                }
                
            }
            return false;
        }

        //display error message if user does not enter valid number into the text box
        private void errorMessage()
        {
            MessageBox.Show("Invalid entry. Please enter a valid amount");
        }


        private void btnChangePin_Click(object sender, EventArgs e)
        {
            this.mainForm.ResetInactivityTimer();
            string newPin = txtNewPin.Text;
            string confirmPin = txtConfirmPin.Text;
            
            if (newPin != confirmPin)
            {
                MessageBox.Show("New pin and confirm pin do not match. Please try again.");
            }
            else if (txtNewPin.Text.Trim() == "" && txtConfirmPin.Text.Trim() == "")
            {
                    MessageBox.Show("Empty fields", "Error");
            }
            else if (!validateTextBox())
            {
                MessageBox.Show("Please enter valid digits");
                return;
            }
            else
            {
                string query = "UPDATE BankAccount SET AccountPin = @newPin WHERE AccountNumber = @AccountNumber";
                SQLiteConnection conn = new SQLiteConnection(@"Data Source=Bank Data.db");
                conn.Open();

                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@newPin", txtNewPin.Text);
                cmd.Parameters.AddWithValue("@AccountNumber", lblAccountName.Text);

                int rowsAffected = cmd.ExecuteNonQuery();
                
                if (rowsAffected == 1)
                {
                    MessageBox.Show("Pin changed successfully!");
                    this.Close();
                    this.mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Pin change failed. Please try again.");
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.mainForm.Show();
            this.Hide();
        }
    }
}
