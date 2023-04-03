using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atm_App
{
    public class Account
    {

        public Account() 
        { 
        }
        public Account(string guid, string accountNumber, string accountPin, string balance, string accountHolderGuid) 
        {

            this.guid = guid;
            this.accountNumber = accountNumber;
            this.accountPin = accountPin;
            this.balance = balance;
            this.accountHolderGuid = accountHolderGuid;
            
        }

        static string AccountNumber;
        public string accountNumber
        {
            get
            {
                return AccountNumber;
            }
            set
            {
                AccountNumber = value;
            }
        }

        static string Guid;

        public string guid
        {
            get
            {
                return Guid;
            }
            set
            {
                Guid = value;
            }
        }

        static string AccountPin;

        public string accountPin
        {
            get
            {
                return AccountPin;
            }
            set
            {
                AccountPin = value;
            }
        }

        static string Balance;

        public string balance
        {
            get
            {
                return Balance;
            }
            set
            {
                Balance = value;
            }
        }

        static string FirstName;

        public string firstName
        {
            get
            {
                return FirstName;
            }
            set
            {
                FirstName = value;
            }
        }

        static string LastName;

        public string lastName
        {
            get
            {
                return LastName;
            }
            set
            {
                LastName = value;
            }
        }

        static string DateOfBirth;

        public string dateOfBirth
        {
            get
            {
                return DateOfBirth;
            }
            set
            {
                DateOfBirth = value;
            }
        }

        static string EmailAddress;

        public string emailAddress
        {
            get
            {
                return EmailAddress;
            }
            set
            {
                EmailAddress = value;
            }
        }

        static string PhoneNumber;

        public string phoneNumber
        {
            get
            {
                return PhoneNumber;
            }
            set
            {
                PhoneNumber = value;
            }
        }

        static string Address;

        public string address
        {
            get
            {
                return Address;
            }
            set
            {
                Address = value;
            }
        }

        static string City;

        public string city
        {
            get
            {
                return City;
            }
            set
            {
                City = value;
            }
        }

        static string County;

        public string county
        {
            get
            {
                return County;
            }
            set
            {
                County = value;
            }
        }

        static string Postcode;

        public string postcode
        {
            get
            {
                return Postcode;
            }
            set
            {
                Postcode = value;
            }
        }

        static string AccountHolderGuid;
        
        public string accountHolderGuid
        {
            get
            {
                return AccountHolderGuid;
            }
            set
            {
                AccountHolderGuid = value;
            }
        }

        public void Withdraw(decimal amount)
        {
            // Update the user's balance in the database
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=Bank Data.db"))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "UPDATE BankAccount SET Balance = Balance + @withdrawAmount WHERE Guid = @Guid";
                    command.Parameters.AddWithValue("@withdrawAmount", amount);
                    command.Parameters.AddWithValue("@Guid", this.guid);
                    int rowsUpdated = command.ExecuteNonQuery();

                    if (rowsUpdated == 1)
                    {
                        // Update the logged in user's balance and display success message
                        decimal.TryParse(this.balance, out decimal balanceDecimal); 
                        this.balance = (balanceDecimal -= amount).ToString();
                        connection.Close();
                    }
                    else
                    {
                        connection.Close();
                        throw new Exception();
                    }
                }
            }
        }

        public void Deposit(decimal amount)
        {
            // Update the user's balance in the database
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=Bank Data.db"))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "UPDATE BankAccount SET Balance = Balance + @depositAmount WHERE Guid = @Guid";
                    command.Parameters.AddWithValue("@depositAmount", amount);
                    //command.Parameters.AddWithValue("@Guid", Account.guid);
                    command.Parameters.AddWithValue("@Guid", this.guid);
                    int rowsUpdated = command.ExecuteNonQuery();

                    if (rowsUpdated == 1)
                    {
                        // Update the logged in user's balance and display success message
                        decimal.TryParse(this.balance, out decimal balanceDecimal);
                        this.balance = (balanceDecimal += amount).ToString();
                        connection.Close();
                    }
                    else
                    {
                        connection.Close();
                        throw new Exception();
                    }
                }
            }
        }
    }

    public class AccountRetriever
    {
        public AccountRetriever()
        {

        }
        public Account GetAccountWithPin(string accountNumber, string pin)
        {
            string query = "SELECT * FROM BankAccount WHERE AccountNumber = @AccountNumber AND AccountPin = @AccountPin";
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=Bank Data.db");
            conn.Open();

            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);
            cmd.Parameters.AddWithValue("@AccountPin", pin);


            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Account account = new Account();
                account.guid = reader.GetValue(1).ToString();
                account.accountNumber = reader.GetValue(2).ToString();
                account.accountPin = reader.GetValue(3).ToString();
                account.balance = reader.GetValue(4).ToString();
                account.accountHolderGuid = reader.GetValue(5).ToString();

                reader.Close();

                return account;
            }
            else
            {
                MessageBox.Show("Invalid Account. Please try again");
                throw new Exception();
            }
        }

        public Account GetAccount(string accountNumber)
        {

            string query = "SELECT * FROM BankAccount WHERE AccountNumber = @AccountNumber";
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=Bank Data.db");
            conn.Open();

            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);


            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string readGuid = reader.GetValue(1).ToString();
                string readAccountNumber = reader.GetValue(2).ToString();
                string readAccountPin = reader.GetValue(3).ToString();
                string readBalance = reader.GetValue(4).ToString();
                string readAccountHolderGuid = reader.GetValue(5).ToString();
                reader.Close();
                return new Account(guid: readGuid, accountNumber: readAccountNumber, accountPin: readAccountPin, balance: readBalance , accountHolderGuid: readAccountHolderGuid);
            }
            else
            {
                MessageBox.Show("Invalid Account. Please try again");
                throw new Exception();
            }
        }
    }
}
