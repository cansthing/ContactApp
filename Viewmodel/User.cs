using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsWSIO.Viewmodel
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }

        public User()
        {
            string firstname = FirstName;
            string lastname = LastName;
            string email = Email;
            string phone = Phone;
            string mobile = Mobile;
        }
    }
}
