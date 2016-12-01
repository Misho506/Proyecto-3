using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DebateRI
{
    public partial class ProfilePage : ContentPage
    {
        //HttpClient httpClient;
        public ProfilePage()
        {
            InitializeComponent();
            NameLBL.Text = "Bienvenido: \n" + App.currentUser.name;
            //if (App.currentRule.description != null)
            //{
            //    RuleLBL.Text = "Reglemento: \n" + App.currentRule.description;
            //}
        }
        async void ChatClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Teams.TeamsChat());
        }
        async void CheckSessionClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new InitialPosition());
        }
        async void DressCodeClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AddRule());
        }

    }
}
