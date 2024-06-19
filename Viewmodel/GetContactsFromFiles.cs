using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Security.Cryptography.X509Certificates;
using System.Collections.ObjectModel;
using System.Windows.Navigation;

namespace ContactsWSIO.Viewmodel
{
    internal class GetContactsFromFiles
    {
        public const string DIR_Contacts = @"C:\Users\Löwen\Desktop\Contacts\";

        static string[] contacts = Directory.GetDirectories(DIR_Contacts);

        static public List<User> usersList = new List<User>();

        public static ObservableCollection<User> UsersCollection = new ObservableCollection<User>();

        public static void GetAllContactsFromFiles()
        {
            string firstname = "";
            string lastname = "";
            string email = "";
            string phone = "";
            string mobile = "";

            foreach (string contact in contacts)
            {
                

                string[] files = Directory.GetFiles(contact);

                foreach (string file in files)
                {
                    string pathToFile = Path.GetFileNameWithoutExtension(file);

                    string fullpath = DIR_Contacts + file + pathToFile;

                    string content = File.ReadAllText(file);

                    if (file.Contains("Firstname"))
                    {
                        firstname = content;
                    }
                    else if (file.Contains("Lastname"))
                    {
                        lastname = content;
                    }
                    else if (file.Contains("Email"))
                    {
                        email = content;
                    }
                    else if (file.Contains("Phone"))
                    {
                        phone = content;
                    }
                    else if (file.Contains("Mobil"))
                    {
                        mobile = content;
                    }
                }

                usersList.Add(new User()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email,
                    Phone = phone,
                    Mobile = mobile
                });

                UsersCollection.Add(new User()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email,
                    Phone = phone,
                    Mobile = mobile
                });

            }
        }
    }
}
