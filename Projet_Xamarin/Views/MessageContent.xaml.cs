using Projet_Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projet_Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageContent : ContentPage
    {
        public Message message { get; set; }
        public List<Message> liste { get; set; }
        public MessageContent(Message message, List<Message> liste)
        {
            
            InitializeComponent();
            this.message = message;
            this.liste = liste;

            BindingContext = this;

        }
    }
}