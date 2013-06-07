using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace studentguideapp
{
    public partial class infopage : PhoneApplicationPage
    {
        public infopage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (NavigationContext.QueryString.Keys.Count > 0)
            {
                if (NavigationContext.QueryString["title"] != null)
                {
                    string title=NavigationContext.QueryString["title"].ToLower();
                    foreach (var item in App.getControl.allData)
                    {
                        if (item.Title.ToLower() == title)
                        {
                            tittleName.Text = item.Title;
                            //contactInfo.Text = item.Phone;
                            //emailInfo.Text = item.Email;
                            infoBox.Text = item.Description;
                        }
                    }
                }
            }
        }

        //private void emailInfo_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        //{
        //    if (emailInfo.Text != "")
        //    {
        //        App.getControl.sendEmail(emailInfo.Text);
        //    }
        //}

        //private void contactInfo_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        //{
        //    if (contactInfo.Text != "")
        //    {
        //        App.getControl.DialNumber(contactInfo.Text);
        //    }
        //}

        private void callAppBarButon_Click(object sender, EventArgs e)
        {
            foreach (var item in App.getControl.allData)
            {
                if (item.Title == tittleName.Text)
                {
                    if (item.Phone == "")
                    {
                        MessageBox.Show("No phone number to call.");
                        return;
                    }
                    else
                    {
                        App.getControl.DialNumber(item.Phone);
                        return;
                    }
                }
            }
        }

        private void emailAppbarButton_Click(object sender, EventArgs e)
        {
            foreach (var item in App.getControl.allData)
            {
                if (item.Title == tittleName.Text)
                {
                    if (item.Email == "")
                    {
                        MessageBox.Show("No email to email.");
                        return;
                    }
                    else
                    {
                        App.getControl.sendEmail(item.Email);
                        return;
                    }
                }
            }
        }
    }
}
