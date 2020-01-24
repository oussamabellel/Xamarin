using Newtonsoft.Json;
using Projet_Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;


namespace Projet_Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {

        List<Message> Favoris { get; set; }
        List<Message> Messages { get; set; }
        Dictionary<int, string> Pairs { get; set; }

        List<string> Colors = new List<string>() {"LightGray","Red", "Blue", "Green", "Yellow", "Violet", "Orange"};
        public Page1()
        {
            InitializeComponent();
            Favoris = new List<Message>();
            Messages = new List<Message>();
            Pairs = new Dictionary<int, string>();
            Refresh();
            _ = AutoRefresh();
            RefreshFavoris();
            myListView.RefreshCommand = new Command(() => {
                //Do your stuff.
                Refresh();
                myListView.IsRefreshing = false;
            });
        }

        public void RefreshFavoris()
        {
            if (Preferences.ContainsKey("favoris"))
            {
                Favoris = JsonConvert.DeserializeObject<List<Message>>(Preferences.Get("favoris", null));
                favorisListView.ItemsSource = Favoris;
                favorisListView.HeightRequest = (Favoris.Count * 100)/2;
                favorisListView.IsVisible = true;

            }else
            {
                Debug.WriteLine("Empty");
                favorisListView.IsVisible = false;
            }

            if(Favoris.Count == 0)
            {
                favorisListView.IsVisible = false;

            }
        }

        public async Task AutoRefresh()
        {
            while (true)
            {
                await Task.Delay(30000);
                Refresh();
            }

        }

        private async Task<List<Message>> GetMessages()
        {
            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync("https://hmin309-embedded-systems.herokuapp.com/message-exchange/messages/");
                List<Message> liste = JsonConvert.DeserializeObject<List<Message>>(content);
                return liste;
               
            }

        }

        public async Task<List<Message>> GetUserMessages(int id)
        {
            List<Message> UserMessages = new List<Message>();
            List<Message> liste = await GetMessages();
            foreach (Message message in liste)
            {
                if (message.student_id == id)
                {
                    UserMessages.Add(message);
                }
            }
            return UserMessages;
        }

        private async void myListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var message = (Message)myListView.SelectedItem;
            List<Message> liste = await GetUserMessages(message.student_id);
            await Navigation.PushAsync(new MessageContent(message, liste));

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Refresh();
            
        }

        public bool verifyIfExist(Message msg)
        {
            bool b = false;
            foreach (Message m in Favoris)
            {
                if (m.id == msg.id)
                {
                    Debug.WriteLine("Exist");
                    b = true;
                }
            }
            return b;
        }

        private async void Button_Clicked_1Async(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Message msg = (Message)button.CommandParameter;
            if (! verifyIfExist(msg))
            {
                Favoris.Add(msg);
                string json = JsonConvert.SerializeObject(Favoris);
                Preferences.Set("favoris", json);
                RefreshFavoris();
            }
        }

        //Delete From Favoris
        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Message msg = (Message)button.CommandParameter;
            Favoris.Remove(msg);
            string json = JsonConvert.SerializeObject(Favoris);
            Preferences.Set("favoris", json);
            RefreshFavoris();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Message msg = (Message)button.CommandParameter;
            int student_id = msg.student_id;
            if (Pairs.ContainsKey(student_id))
            {
                return;
            }
            Pairs.Add(student_id, Colors.ElementAt(0));
            Colors.RemoveAt(0);
            string json = JsonConvert.SerializeObject(Pairs);
            Preferences.Set("Colors", json);
            Refresh();

        }

        private async void Refresh()
        {
            Dictionary<int, string> Colors = new Dictionary<int, string>();

            if (Preferences.ContainsKey("Colors"))
            {
                Colors = JsonConvert.DeserializeObject<Dictionary<int,string>>(Preferences.Get("Colors", null));
            }
            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync("https://hmin309-embedded-systems.herokuapp.com/message-exchange/messages/");
                List<Message> liste = JsonConvert.DeserializeObject<List<Message>>(content);
                foreach (Message m in liste)
                {
                    foreach (var item in Colors)
                    {
                        if (m.student_id == item.Key)
                        {
                            m.color = item.Value;
                        }
                    }
                }
                myListView.ItemsSource = liste;
            }
        }

        private async void favorisListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var message = (Message) favorisListView.SelectedItem;
            List<Message> liste = await GetUserMessages(message.student_id);
            await Navigation.PushAsync(new MessageContent(message, liste));
        }
    }
}