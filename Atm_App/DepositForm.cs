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
    public partial class DepositForm : Form
    {
        public DepositForm(MainApplicationForm mainForm)
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

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            this.mainForm.ResetInactivityTimer();

            // Parse the deposit amount from the textbox
            decimal depositAmount;
            if (decimal.TryParse(txtDeposit.Text, out depositAmount))
            {
                // Check if deposit amount is greater than zero
                if (depositAmount <= 0)
                {
                    MessageBox.Show("Please enter a positive deposit amount.");
                }
                else
                {

                    try
                    {
                        this.mainForm.loggedInAccount.Deposit(depositAmount);
                        txtCurrentBalance.Text = this.mainForm.loggedInAccount.balance;
                        MessageBox.Show($"Deposit of {depositAmount:C} was successful.");
                    }
                    catch
                    {
                        // Display error message if update failed
                        MessageBox.Show("Failed to deposit amount. Please try again.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid deposit amount.");
            }
        }

        private void DepositForm_Load(object sender, EventArgs e)
        {
            this.mainForm.ResetInactivityTimer();
            txtCurrentBalance.Text = this.mainForm.loggedInAccount.balance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.mainForm.Show();
        }
    }
}
