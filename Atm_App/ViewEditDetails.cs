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
    public partial class ViewEditDetails : Form
    {
        public ViewEditDetails(MainApplicationForm mainForm)
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

        private void AccountHolderDetails_Load()
        {
            string query = "SELECT * FROM AccountHolder WHERE Guid = @AccountHolderGuid";
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=Bank Data.db");
            conn.Open();

            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@AccountHolderGuid", this.mainForm.loggedInAccount.accountHolderGuid);


            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                AccountHolder.guid = reader.GetValue(1).ToString();
                AccountHolder.firstName = reader.GetValue(2).ToString();
                AccountHolder.lastName = reader.GetValue(3).ToString();
                AccountHolder.dateOfBirth = reader.GetValue(4).ToString();
                AccountHolder.emailAddress = reader.GetValue(5).ToString();
                AccountHolder.phoneNumber = reader.GetValue(6).ToString();
                AccountHolder.address = reader.GetValue(7).ToString();
                AccountHolder.city = reader.GetValue(8).ToString();
                AccountHolder.county = reader.GetValue(9).ToString();
                AccountHolder.postcode = reader.GetValue(10).ToString();



                reader.Close();

            }
        }

        private void ViewEditDetails_Load(object sender, EventArgs e)
        {
            this.mainForm.ResetInactivityTimer();

            AccountHolderDetails_Load();
            txtFirstName.Text = AccountHolder.firstName;
            txtLastName.Text = AccountHolder.lastName;
            txtDOB.Text = AccountHolder.dateOfBirth;
            txtEmailAddress.Text = AccountHolder.emailAddress;
            txtPhoneNumber.Text = AccountHolder.phoneNumber;
            txtAddress.Text = AccountHolder.address;
            txtCity.Text = AccountHolder.city;
            txtCounty.Text = AccountHolder.county;
            txtPostCode.Text = AccountHolder.postcode;
            

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.mainForm.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //Save Details/Update Button
        private void btnSaveDetails_Click(object sender, EventArgs e)
        {
            this.mainForm.ResetInactivityTimer();
            try
            {

                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string dateOfBirth = txtDOB.Text;
                string emailAddress = txtEmailAddress.Text;
                string phoneNumber = txtPhoneNumber.Text;
                string address = txtAddress.Text;
                string city = txtCity.Text;
                string county = txtCounty.Text;
                string postcode = txtPostCode.Text;




                string query = "UPDATE AccountHolder SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, EmailAddress = @EmailAddress, PhoneNumber = @PhoneNumber, Address = @Address, City = @City, County = @County, Postcode = @Postcode WHERE Guid = @AccountHolderGuid";
                SQLiteConnection conn = new SQLiteConnection(@"Data Source=Bank Data.db");
                conn.Open();

                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@AccountHolderGuid", this.mainForm.loggedInAccount.accountHolderGuid);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                cmd.Parameters.AddWithValue("@EmailAddress", emailAddress);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@County", county);
                cmd.Parameters.AddWithValue("@Postcode", postcode);


                //SQLiteDataReader reader = cmd.ExecuteReader();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    MessageBox.Show("Details saved successfully");
                }
                    
            }
            catch (Exception)
            {

                MessageBox.Show("Failed to save details");
            }
        }
    }
}
