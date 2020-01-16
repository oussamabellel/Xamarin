using Projet_Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Projet_Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class favoris : ContentPage
    {
        List<Message> Favoris { get; set; }
        public favoris()
        {
            InitializeComponent();
            RefreshFavoris();
        }

        public void RefreshFavoris()
        {
            Favoris = JsonConvert.DeserializeObject<List<Message>>(Preferences.Get("favoris", null));
            myListView.ItemsSource = Favoris;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RefreshFavoris();
        }


    }
}