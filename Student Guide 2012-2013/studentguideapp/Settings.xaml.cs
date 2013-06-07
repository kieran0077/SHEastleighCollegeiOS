using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;

namespace studentguideapp
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void FirstNameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            FirstNameBox.Text = "";
        }

        private void TutorBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TutorBox.Text = "";
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (App.getControl.settings.Contains("name"))
            {
                FirstNameBox.Text = App.getControl.settings["name"].ToString();
            }
            if (App.getControl.settings.Contains("tutor"))
            {
                TutorBox.Text = App.getControl.settings["tutor"].ToString();
            }
            if (App.getControl.settings.Contains("course"))
            {
                CourseCodeBox.Text = App.getControl.settings["course"].ToString();
            }
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    if (FirstNameBox.Text != "" && TutorBox.Text != "")
        //    {
        //        App.getControl.saveSettings(FirstNameBox.Text, TutorBox.Text);
        //        NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        //    }
        //    else
        //    {
        //        MessageBox.Show("All fields are required to be filled out.");
        //    }
        //}

        private void FirstNameBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TutorBox.Focus();
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            if (FirstNameBox.Text != "" && TutorBox.Text != "" && CourseCodeBox.Text!="")
            {
                App.getControl.saveSettings(FirstNameBox.Text, TutorBox.Text,CourseCodeBox.Text);
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show("All fields are required to be filled out.");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (App.getControl.settings.Contains("name"))
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show("All fields are required to be filled out. You cannot cancel");
            }
        }

        private void TutorBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CourseCodeBox.Focus();
            }
        }

        private void CourseCodeBox_GotFocus(object sender, RoutedEventArgs e)
        {
            CourseCodeBox.Text = "";
        }
    }
}