using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atm_App
{
    public partial class WithdrawForm : Form
    {
        public WithdrawForm(MainApplicationForm mainForm)
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
            decimal withdrawAmount;
            if (decimal.TryParse(txtWithdraw.Text, out withdrawAmount))
            {
                // Check if deposit amount is greater than zero
                if (withdrawAmount <= 0)
                {
                    MessageBox.Show("Please enter a positive withdraw amount.");
                }
                else
                {
                    

                    decimal.TryParse(this.mainForm.loggedInAccount.balance, out decimal balance);

                    if (balance - withdrawAmount < 0)
                    {
                        MessageBox.Show("Amount not allowed to go under €0.00.");
                    }
                    else
                    {

                        try
                        {
                            this.mainForm.loggedInAccount.Withdraw(withdrawAmount);
                            txtCurrentBalance.Text = this.mainForm.loggedInAccount.balance;
                            MessageBox.Show($"Withdraw of {withdrawAmount:C} was successful.");
                        }
                        catch
                        {
                            // Display error message if update failed
                            MessageBox.Show("Failed to withdraw amount. Please try again.");
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Please enter a valid deposit amount.");
            }
        }

        private void btnMainPage_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.mainForm.Show();
        }

        private void WithdrawForm_Load(object sender, EventArgs e)
        {
            this.mainForm.ResetInactivityTimer();
            txtCurrentBalance.Text = this.mainForm.loggedInAccount.balance;
        }
    }
}

