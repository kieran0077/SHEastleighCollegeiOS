using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Phone.UserData;
using System.IO;
using System.Windows.Resources;
using System.IO.IsolatedStorage;
using System.Windows.Navigation;


namespace studentguideapp
{
    public class Controller
    {

        public ObservableCollection<StudentGuideModel> allData = new ObservableCollection<StudentGuideModel>();
        public IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        public Dictionary<string,string> theImages = new Dictionary<string,string>();

        private bool dictionarySetup=false;
        private void setupDictionary()
        {
            if (dictionarySetup == true) { return; }
            theImages.Add("Information", "/Light/info.png");
            theImages.Add("Contacts", "/Light/phonemail.png");
            theImages.Add("Facilities", "/Light/bell.png");
            theImages.Add("Food", "/Light/foodImage.png");
            theImages.Add("Listening", "/Light/peopleblue.png");
            dictionarySetup = true;
        }

        public bool loadedData = false;

        public bool checkStorage()
        {
            if (!settings.Contains("name"))
            {
                MessageBox.Show("This is your first time opening the Application, we require some information from you to begin.");
                return false;
            }
            else
            {
                return true;
            }
        }

        public void saveSettings(string name, string tutor,string courseCode)
        {
            if (name!=null && tutor!=null && courseCode!=null)
            {
                if (settings.Contains("name"))
                {
                    settings["name"] = name;
                }
                else
                {
                    settings.Add("name", name);
                }
                if (settings.Contains("tutor"))
                {
                    settings["tutor"] = tutor;
                }
                else
                {
                    settings.Add("tutor", tutor);
                }
                if (settings.Contains("course"))
                {
                    settings["course"] = courseCode;
                }
                else
                {
                    settings.Add("course", courseCode);
                }
                settings.Save();
            }
        }

        public void DialNumber(string phoneNumber)
        {
            PhoneCallTask callingTask = new PhoneCallTask();
            callingTask.PhoneNumber = phoneNumber;
            callingTask.Show();
        }
        public void saveNumber(string phoneNumber)
        {
            SavePhoneNumberTask savingTask = new SavePhoneNumberTask();
            savingTask.PhoneNumber = phoneNumber;
            savingTask.Show();
            savingTask.Completed += new EventHandler<TaskEventArgs>(savingTask_Completed);
        }
        void savingTask_Completed(object sender, TaskEventArgs e)
        {
            switch (e.TaskResult)
            {
                case TaskResult.OK:
                    MessageBox.Show("Phone number successfully saved");
                    break;
                case TaskResult.Cancel:
                    MessageBox.Show("Saving canceled");
                    break;
                case TaskResult.None:
                    MessageBox.Show("Unable to save phone number");
                    break;
            }
        }
        public void sendEmail(string email)
        {
            EmailComposeTask theEmailTask = new EmailComposeTask();
            theEmailTask.To = email;
            theEmailTask.Show();
        }
        public void AddAppointmentMethod(DateTime startTime, DateTime endTime, string appointmentName)
        {
            Appointments appts = new Appointments();
            appts.SearchAsync(startTime, endTime, appointmentName);
        }

        public EventHandler<AppointmentsSearchEventArgs> Appointments_SearchCompleted { get; set; }

        private string getImage(string category)
        {
            string finalResult = "";
            theImages.TryGetValue(category, out finalResult);
            return finalResult;
        }

        public void getData()
        {
            setupDictionary();
            if (loadedData == true) { return; }
            List<StudentGuideModel> moveItems = new List<StudentGuideModel>();
            StreamResourceInfo xml = Application.GetResourceStream(new Uri("Data/Data.xml", UriKind.Relative));
            var doc = XDocument.Load(xml.Stream);
            var feed = doc.Descendants("item").Select(c => new StudentGuideModel()
            {
                Title = c.Element("Title").Value,
                Description = c.Element("Description").Value,
                Phone = c.Element("Phone").Value,
                Email = c.Element("Email").Value,
                Address = c.Element("Address").Value,
                Category = c.Element("Category").Value,
                Image = getImage(c.Element("Image").Value),
                SmallInfo = c.Element("SmallInfo").Value,
            }
            );
            moveItems = feed.ToList();
            foreach (var item in moveItems)
            {
                allData.Add(item);
            }
            loadedData = true;
        }
        public ObservableCollection<StudentGuideModel> splitCategories(string catName)
        {
            ObservableCollection<StudentGuideModel> catItems = new ObservableCollection<StudentGuideModel>();
            foreach (var item in allData)
            {
                if (item.Category == catName)
                {
                    catItems.Add(item);
                }
            }
            return catItems;
        }

        public void sendLateText()
        {
            if (!settings.Contains("lateMessages"))
            {
                settings.Add("lateMessages", 0);
            }
            MessageBoxResult popup = MessageBox.Show("You have sent in a total of " + settings["lateMessages"].ToString() + " late messages. Do you wish to continue?","Notice!", MessageBoxButton.OKCancel);
            if (popup == MessageBoxResult.OK)
            {
                SmsComposeTask smsComposeText = new SmsComposeTask();
                smsComposeText.To = "07624810342";
                smsComposeText.Body = "Hello, my name is " + settings["name"].ToString() + " (" + settings["course"] + "), unfortunately I will be late." + Environment.NewLine + "Please could you tell my tutor " + settings["tutor"].ToString() + ", that I shall be late. Thank you.";
                smsComposeText.Show();
                int curMessages = int.Parse(settings["lateMessages"].ToString());
                settings["lateMessages"] = curMessages + 1;
            }
        }

        public void sendImIll()
        {
            if (!settings.Contains("illMessages"))
            {
                settings.Add("illMessages", 0);
            }
            MessageBoxResult popup = MessageBox.Show("You have been ill a total of " + settings["illMessages"].ToString() + " times. Do you wish to continue?", "Notice!", MessageBoxButton.OKCancel);
            if (popup == MessageBoxResult.OK)
            {
                SmsComposeTask smsComposeText = new SmsComposeTask();
                smsComposeText.To = "07624810342";
                smsComposeText.Body = "Hello, my name is " + settings["name"].ToString() + " (" + settings["course"] + "), unfortunately I am ill." + Environment.NewLine + "Please could you tell my tutor " + settings["tutor"].ToString() + ", that I will not be attending lessons today. Thank you.";
                smsComposeText.Show();
                int curMessages = int.Parse(settings["illMessages"].ToString());
                settings["illMessages"] = curMessages + 1;
            }
        }
        public void addAppointment(DateTime start, DateTime finish, string appointment)
        {
            Appointments aAppointment = new Appointments();
            aAppointment.SearchCompleted += new EventHandler<AppointmentsSearchEventArgs>(GetAppointments);
            aAppointment.SearchAsync(start, finish, appointment);
            MessageBox.Show("Your appointments have been susessfully added to your calender!", "Sucsess!", MessageBoxButton.OK);
        }
        void GetAppointments(object sender, AppointmentsSearchEventArgs e)
        { }

        public void sendBullyingEmail(string inputdescription, string whenandWhere, string who, bool detials)
        {
            EmailComposeTask theEmailTask = new EmailComposeTask();
            string contactDetails = "";
                if (detials == false)
	            {
		            contactDetails = "I am to afraid to to give away my contact details";    
	            }
                else if (detials == true)
	            {
		          contactDetails = "My name is :" + App.getControl.settings["name"].ToString() + "and my tutor is: " + App.getControl.settings["tutor"].ToString(); 
	            }
            theEmailTask.To = "speakup@eastleigh.ac.uk";
            theEmailTask.Subject = "Help im being bullied";
            theEmailTask.Body = "Hello, I am being bullied by " + who + " they were " + inputdescription + " this all happened" + whenandWhere + " " + contactDetails; 
            theEmailTask.Show();       
        }

        public void sendBullyingText(string inputdescription, string whenandWhere, string who, bool detials)
        {
            SmsComposeTask smsComposeText = new SmsComposeTask();
            string contactDetails = "";
            if (detials == false)
            {
                contactDetails = "I am to afraid to to give away my contact details";
            }
            else if (detials == true)
            {
                contactDetails = "My name is :" + App.getControl.settings["name"].ToString() + "and my tutor is: " + App.getControl.settings["tutor"].ToString();
            }
            smsComposeText.To = "07624808747";
            smsComposeText.Body = "Hello, I am being bullied by " + who + " they were " + inputdescription + " this all happened" + whenandWhere + " " + contactDetails; 
            smsComposeText.Show();
        
        }



    }
}
