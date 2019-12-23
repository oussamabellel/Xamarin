using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Projet_Xamarin.Services;
using Projet_Xamarin.Views;
using Projet_Xamarin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Projet_Xamarin
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new Page1();
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
