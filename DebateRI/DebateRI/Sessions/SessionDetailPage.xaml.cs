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
            GoBack.Clicked += GoBackButtonClicked;
            InitializeComponent();
        }
        async void GoBackButtonClicked(object sender, EventArgs args)
        {
            if (listView.SelectedItem != null)
            {
                var detailPage = new SessionDetailPage();
                detailPage.BindingContext = e.SelectedItem as Session;
                listView.SelectedItem = null;
                await Navigation.PushModalAsync(detailPage);
            }
        }
    }
}
