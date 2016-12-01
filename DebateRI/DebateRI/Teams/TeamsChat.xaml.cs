using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebateRI.Entities;

using Xamarin.Forms;

namespace DebateRI.Teams
{
    public partial class TeamsChat : ContentPage
    {
        List<Message> chat = new List<Message>();
        public TeamsChat()
        {
            InitializeComponent();
        }
        void sendMessageClicked(object sender, EventArgs e)
        { var newMessage = new Message(); 
            newMessage.description = message.Text;
            message.Placeholder = "Escriba su  mensaje";
            chat.Add(newMessage);
            messagesList.ItemsSource = chat;

           
        }
    }
}
