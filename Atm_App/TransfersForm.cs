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
    public partial class TransfersForm : Form
    {
        public TransfersForm(MainApplicationForm mainForm)
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            decimal transferAmount;
            if (decimal.TryParse(txtAmount.Text, out transferAmount))
            {
                // Check if deposit amount is greater than zero
                if (transferAmount <= 0)
                {
                    MessageBox.Show("Please enter a positive transfer amount.");
                }
                else
                {
                    this.mainForm.loggedInAccount.Withdraw(transferAmount);
                    AccountRetriever retriever = new AccountRetriever();
                    Account destinationAccount = retriever.GetAccount(cboAccount.Text);
                    destinationAccount.Deposit(transferAmount);
                    MessageBox.Show("Success");
                    this.mainForm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid deposit amount.");
            }
        }

        private void TransfersForm_Load(object sender, EventArgs e)
        {
            //Populate the cboField with the field account numbers 12345678, 23958291, 47428592, 39852758, 99651735,
            //75753412, 69542874, 26574738, 11995378, 57933221
            cboAccount.Items.Add("12345678");
            cboAccount.Items.Add("23958291");
            cboAccount.Items.Add("47428592");
            cboAccount.Items.Add("39852758");
            cboAccount.Items.Add("99651735");
            cboAccount.Items.Add("75753412");
            cboAccount.Items.Add("69542874");
            cboAccount.Items.Add("26574738");
            cboAccount.Items.Add("11995378");
            cboAccount.Items.Add("57933221");

            //Populate cboName with the names corresponding to the accounts Kaya, Elaine
            //Sean, John, Sandra, Thomas, Christopher, Jakub, Stephen, Elvira

            cboName.Items.Add("Kaya");
            cboName.Items.Add("Elaine");
            cboName.Items.Add("Sean");
            cboName.Items.Add("John");
            cboName.Items.Add("Sandra");
            cboName.Items.Add("Thomas");
            cboName.Items.Add("Christopher");
            cboName.Items.Add("Jakub");
            cboName.Items.Add("Stephen");
            cboName.Items.Add("Elvira");

        }
    }
    
}
