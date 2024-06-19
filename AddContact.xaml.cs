using ContactsWSIO.Viewmodel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ContactsWSIO
{
    /// <summary>
    /// Interaktionslogik für AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        public const string FILE_EXT = ".txt";


        public AddContact()
        {
            InitializeComponent();

            //tb_firstname.Text = "Vorname";
            //tb_lastname.Text = "Nachname";
            //tb_email.Text = "Email";
            //tb_phone.Text = "Phone";
            //tb_mobile.Text = "Mobil";
        }

        private void Btn_esc_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Btn_saveContact_Click(object sender, RoutedEventArgs e)
        {
            string firstname = tb_firstname.Text;
            string lastname = tb_lastname.Text;
            string email = tb_email.Text;
            string phone = tb_phone.Text;
            string mobile = tb_mobile.Text;

            CreateUser(firstname, lastname, email, phone, mobile);
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            tb_firstname.Text = "";
            tb_lastname.Text = "";
            tb_email.Text = "";
            tb_phone.Text = "";
            tb_mobile.Text = "";
        }

        public void CreateUser(string firstname, string lastname, string email, string phone, string mobile)
        {
            string firstPartOfUrl = @"C:\Users\Löwen\Desktop\Contacts\";
            //string firstPartOfUrl = Environment.SpecialFolder.Desktop.ToString() + @"\Contacts\";

            string nameOfNewContact = firstname + " " + lastname;

            string fullURL = firstPartOfUrl + nameOfNewContact;

            CreateContactFolder(firstPartOfUrl);

            if (!Directory.Exists(firstPartOfUrl + nameOfNewContact))
            {
                Directory.CreateDirectory(fullURL);
            }
            //User user = new User(fullURL, firstname, lastname, email, phone, mobile);

            try
            {
                CreateContactFiles.CreateFiles(fullURL, firstname, lastname, email, phone, mobile);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void CreateContactFolder(string URL)
        {
            if (!Directory.Exists(URL))
                Directory.CreateDirectory(URL);
        }

        //public void CreateFile_FirstName(string UrlForNewContact, string firstname)
        //{
        //    string createFileDirectory = UrlForNewContact + @"\";

        //    if (!Directory.Exists(createFileDirectory))
        //        Directory.CreateDirectory(createFileDirectory);

        //    using (FileStream fileStream = File.Create(createFileDirectory + "Firstname" + FILE_EXT))
        //    {
        //        byte[] contentConvertedToByte = Encoding.ASCII.GetBytes(firstname);
        //        fileStream.Write(contentConvertedToByte, 0, contentConvertedToByte.Length);
        //    }
        //}

        //public void CreateFile_LastName(string UrlForNewContact, string lastname)
        //{
        //    string createFileDirectory = UrlForNewContact + @"\";

        //    if (!Directory.Exists(createFileDirectory))
        //        Directory.CreateDirectory(createFileDirectory);

        //    using (FileStream fileStream = File.Create(createFileDirectory + "Lastname" + FILE_EXT))
        //    {
        //        byte[] contentConvertedToByte = Encoding.ASCII.GetBytes(lastname);
        //        fileStream.Write(contentConvertedToByte, 0, contentConvertedToByte.Length);
        //    }
        //}

        //public void CreateFile_Email(string UrlForNewContact, string email)
        //{
        //    string createFileDirectory = UrlForNewContact + @"\";

        //    if (!Directory.Exists(createFileDirectory))
        //        Directory.CreateDirectory(createFileDirectory);

        //    using (FileStream fileStream = File.Create(createFileDirectory + "Email" + FILE_EXT))
        //    {
        //        byte[] contentConvertedToByte = Encoding.ASCII.GetBytes(email);
        //        fileStream.Write(contentConvertedToByte, 0, contentConvertedToByte.Length);
        //    }
        //}

        //public void CreateFile_Phone(string UrlForNewContact, string phone)
        //{
        //    string createFileDirectory = UrlForNewContact + @"\";

        //    if (!Directory.Exists(createFileDirectory))
        //        Directory.CreateDirectory(createFileDirectory);

        //    using (FileStream fileStream = File.Create(createFileDirectory + "Phone" + FILE_EXT))
        //    {
        //        byte[] contentConvertedToByte = Encoding.ASCII.GetBytes(phone);
        //        fileStream.Write(contentConvertedToByte, 0, contentConvertedToByte.Length);
        //    }
        //}

        //public void CreateFile_Mobile(string UrlForNewContact, string mobile)
        //{
        //    string createFileDirectory = UrlForNewContact + @"\";

        //    if (!Directory.Exists(createFileDirectory))
        //        Directory.CreateDirectory(createFileDirectory);

        //    using (FileStream fileStream = File.Create(createFileDirectory + "Mobil" + FILE_EXT))
        //    {
        //        byte[] contentConvertedToByte = Encoding.ASCII.GetBytes(mobile);
        //        fileStream.Write(contentConvertedToByte, 0, contentConvertedToByte.Length);
        //    }
        //}

        //public void CreateFiles(string fullURL, string firstname, string lastname, string email, string phone, string mobile)
        //{
        //    CreateFile_FirstName(fullURL, firstname);
        //    CreateFile_LastName(fullURL, lastname);
        //    CreateFile_Email(fullURL, email);
        //    CreateFile_Phone(fullURL, phone);
        //    CreateFile_Mobile(fullURL, mobile);
        //}
    }
}
