using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace studentguideapp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();

            }
            App.getControl.getData();
            contactPanel.ItemsSource = App.getControl.splitCategories("Contacts");
            faciliiesList.ItemsSource = App.getControl.splitCategories("Facilities");

        }


        private void contactPanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox _list = (ListBox)sender;
            StudentGuideModel _item = (StudentGuideModel)contactPanel.SelectedItem;
            if (_item != null)
            {
                NavigationService.Navigate(new Uri("/infopage.xaml?title=" + _item.Title, UriKind.RelativeOrAbsolute));
            }
        }

        private void faciliiesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox _list = (ListBox)sender;
            StudentGuideModel _item = (StudentGuideModel)faciliiesList.SelectedItem;
            if (_item != null)
            {
                NavigationService.Navigate(new Uri("/infopage.xaml?title=" + _item.Title, UriKind.RelativeOrAbsolute));
            }
        }

        private void Late_Click(object sender, RoutedEventArgs e)
        {
            if (App.getControl.settings.Contains("name"))
            {
                App.getControl.sendLateText();
            }
            else
            {
                NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        private void Ill_Click(object sender, RoutedEventArgs e)
        {
            if (App.getControl.settings.Contains("name"))
            {
                App.getControl.sendImIll();
            }
            else
            {
                NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            //Shove security phone number here
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/bullyingPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Security_Click(object sender, RoutedEventArgs e)
        {
            App.getControl.DialNumber("02380911049");
        }

        private void HelpMe_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/bullyingInfoPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}