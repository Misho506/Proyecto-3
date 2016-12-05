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
            nameLabel.Text = "Bienvenido: \n" + App.currentUser.name;
            //ruleLabel.Text = "Reglemento: \n" + App.currentRule.description;
        }
        async void AddRuleClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AddRule());
        }
        async void ShowSessionClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new InitialPosition());
        }

    }
}
