﻿#pragma checksum "C:\Users\Kieran\Desktop\Student Guide 2012-2013\studentguideapp\bullyingPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3829286BC8EE63D7ED9FD672F5207830"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace studentguideapp {
    
    
    public partial class bullyingPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox inputIncident;
        
        internal System.Windows.Controls.TextBox inputWhere;
        
        internal System.Windows.Controls.TextBox inputPerson;
        
        internal System.Windows.Controls.CheckBox checkBoxDetails;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/studentguideapp;component/bullyingPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.inputIncident = ((System.Windows.Controls.TextBox)(this.FindName("inputIncident")));
            this.inputWhere = ((System.Windows.Controls.TextBox)(this.FindName("inputWhere")));
            this.inputPerson = ((System.Windows.Controls.TextBox)(this.FindName("inputPerson")));
            this.checkBoxDetails = ((System.Windows.Controls.CheckBox)(this.FindName("checkBoxDetails")));
        }
    }
}

