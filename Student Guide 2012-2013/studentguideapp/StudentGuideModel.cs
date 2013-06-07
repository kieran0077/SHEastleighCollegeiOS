using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
namespace studentguideapp
{
    public class StudentGuideModel : INotifyPropertyChanged
    {
        private string _description;
        private string _title;
        private string _email;
        private string _phone;
        private string _address;
        private string _image;
        private string _category;
        private string _smallInfo;

        public StudentGuideModel()
        {

        }

        public string Description
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged("Description"); }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; NotifyPropertyChanged("Title"); }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; NotifyPropertyChanged("Email"); }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; NotifyPropertyChanged("Phone"); }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; NotifyPropertyChanged("Address"); }
        }

        public string Image
        {
            get { return _image; }
            set { _image = value; NotifyPropertyChanged("Image"); }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; NotifyPropertyChanged("Category"); }
        }

        public string SmallInfo
        {
            get { return _smallInfo; }
            set { _smallInfo = value; NotifyPropertyChanged("SmallInfo"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
