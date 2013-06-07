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
    public partial class bullyingPage : PhoneApplicationPage
    {
        public bullyingPage()
        {
            InitializeComponent();
            if (checkBoxDetails.IsChecked == true)
            {
                
            }
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            bool isDetailsChecked = true;
            if (checkBoxDetails.IsChecked == true)
            {
                isDetailsChecked = true;
            }
            else if (true)
	        {
		        isDetailsChecked = false;
	        }
            App.getControl.sendBullyingEmail(inputIncident.Text, inputWhere.Text, inputPerson.Text, isDetailsChecked); 
        }

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            bool isDetailsChecked = true;
            if (checkBoxDetails.IsChecked == true)
            {
                isDetailsChecked = true;
            }
            else if (true)
            {
                isDetailsChecked = false;
            }
            App.getControl.sendBullyingText(inputIncident.Text, inputWhere.Text, inputPerson.Text, isDetailsChecked);
        }

        private void inputIncident_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                inputWhere.Focus();
            }
        }

        private void inputWhere_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                inputPerson.Focus();
            }
        }
    }
}