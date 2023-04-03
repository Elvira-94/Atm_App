using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atm_App
{
    public partial class MainApplicationForm : Form
    {
        public MainApplicationForm(Account loggedInAccount)
        {
            InitializeComponent();
            this.loggedInAccount = loggedInAccount;
        }

        static Account LoggedInAccount;

        public Account loggedInAccount
        {
            get
            {
                return LoggedInAccount; 
            }

            set {
                LoggedInAccount = value; 
            }
        }

        //View Balance Button
        private void btnViewBalance_Click(object sender, EventArgs e)
        {
            ResetInactivityTimer();
            ViewBalanceForm balanceForm = new ViewBalanceForm(this);
            balanceForm.Show();
            this.Hide();
        }

       //Load Main Page
        private void MainApplicationForm_Load(object sender, EventArgs e)
        {
            lblAccountName.Text = this.loggedInAccount.accountNumber;
            StartInactivityTimer();
           
        }

        //Change Pin Button
        private void btnChangePin_Click(object sender, EventArgs e)
        {
            ResetInactivityTimer();
            ChangePinForm pinForm = new ChangePinForm(this);
            pinForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        //View/Edit Details Button
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            ResetInactivityTimer();
            ViewEditDetails viewEditDetails = new ViewEditDetails(this);
            viewEditDetails.Show();
            this.Hide();    
        }

        //Deposit Button
        private void btnDeposit_Click(object sender, EventArgs e)
        {
            ResetInactivityTimer();
            DepositForm depositForm = new DepositForm(this);
            depositForm.Show();
            this.Hide();
        }

        //Withdraw Button
        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            ResetInactivityTimer();
            WithdrawForm withdrawForm = new WithdrawForm(this);
            withdrawForm.Show();
            this.Hide();
        }

        public const int MAX_INACTIVE_TIME = 5; //In minutes
        public int inactiveTime = 0;
        public void StartInactivityTimer()
        {
            //Create a new timer with an interval of 1 minute
            Timer timer = new Timer();
            timer.Interval = 60000; //1 minute
            timer.Tick += new EventHandler(InactivityTimer_Tick);
            timer.Start();
            
        }

        public void InactivityTimer_Tick(object sender, EventArgs e)
        {
            //Increment the inactive time counter
            inactiveTime++;

            if(inactiveTime >= MAX_INACTIVE_TIME)
            {
                //Automatically log out the user after MAX_INACTIVE_TIME minutes of activity
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
                MessageBox.Show("You have been automatically logged out due to inactivity.");
               
            }
            else
            {
                //Ask the user if they need more time before automatically logged out
                DialogResult result = MessageBox.Show($"You have been inactive for {inactiveTime} minutes(s). Do you need more time?", "Inactivity Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    //Automatically log out the user if they do not need more time
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Hide();
                    MessageBox.Show("You have been automatically logged out due to inactivity");
                }
            }
            ;

        }

        public void ResetInactivityTimer()
        {
            //reset the inactive timer
            inactiveTime = 0;
        }

        //Transfers Button
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            TransfersForm transfersForm = new TransfersForm(this);
            transfersForm.Show();
            this.Hide();
        }
    }
}
