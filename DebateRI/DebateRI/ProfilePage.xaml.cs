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
            nameLabel.Text = "Bienvenido " + App.currentUser.name;
        }

    }
}
