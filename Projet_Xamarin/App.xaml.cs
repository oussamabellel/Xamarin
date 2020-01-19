﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Projet_Xamarin.Views;
using Projet_Xamarin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using Xamarin.Essentials;

namespace Projet_Xamarin
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
            //MainPage = new NavigationPage(new Page1());
        }
        
        protected override void OnStart()
        {
            // Handle when your app starts
        }

       

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
