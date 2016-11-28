using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebateRI.Entities;
using DebateRI.Sessions;

using Xamarin.Forms;

namespace DebateRI.Sessions
{
    public partial class SessionDetailPage : ContentPage
    {

        ListView listView;
        List<Session> session;
        public SessionDetailPage()
        {
            GoBack.Clicked += BackClicked;
            InitializeComponent();

            var timelbl = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };
            timelbl.SetBinding(Label.TextProperty, "Time");

            var desciptionlbl = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };
            desciptionlbl.SetBinding(Label.TextProperty, "Description");
        }

        async void BackClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}
