using Newtonsoft.Json;
using Projet_Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projet_Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            getMessages(myListView);
 
        }

        private static async Task<List<Message>> getMessages(ListView listView)
        {
            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync("https://hmin309-embedded-systems.herokuapp.com/message-exchange/messages/");
                List<Message> liste = JsonConvert.DeserializeObject<List<Message>>(content);

                foreach (Message message in liste)
                {
                    Debug.WriteLine(message.student_message);
                }
                listView.ItemsSource = liste;

                return liste;
            }
        }
    }
}