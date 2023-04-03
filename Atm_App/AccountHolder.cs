using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atm_App
{
    internal class AccountHolder
    {
        static string Guid;
        public static string guid
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

        static string FirstName;
        public static string firstName
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
        public static string lastName
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
        public static string dateOfBirth
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
        public static string emailAddress
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
        public static string phoneNumber
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
        public static string address
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
        public static string city
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
        public static string county
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
        public static string postcode
        {
            get
            {
                return Postcode;
            }
            set
            {
                Postcode= value;
            }
        }
    }
}
