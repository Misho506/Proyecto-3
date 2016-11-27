using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebateRI.Entities;

using Xamarin.Forms;

namespace DebateRI.Sessions
{
    public partial class SessionPage : ContentPage
    {
        ListView listView;
        List<Session> session;
        public SessionPage()
        {
            SetupData();
            listView.ItemsSource = session;
            listView.ItemSelected += OnItemSelected;
            InitializeComponent();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                var detailPage = new DetailSessionPage();
                detailPage.BindingContext = e.SelectedItem as Session;
                listView.SelectedItem = null;
                await Navigation.PushModalAsync(detailPage);
            }
        }
        public void SetupData()
        {
            session = new List<Session>();
            session.Add(new Session(1, "Posición inicial.", 5, "Debatientes dan sus posiciones"));
            session.Add(new Session(2, "Primeras argumentaciones.", 5, "Se realizan lar primeras argumentaciones del debate"));
            session.Add(new Session(3, "Preguntas.", 5, "Se realiza las preguntas"));
            session.Add(new Session(4, "Nuevas argumentaciones.", 5, "Se realizan nuevas argumentaciones"));
            session.Add(new Session(5, "Conclusión.", 5, "Se realiza la conclusion del debate"));
        }
    }
}
