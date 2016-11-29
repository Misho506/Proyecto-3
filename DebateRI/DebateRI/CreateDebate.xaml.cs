using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebateRI.Entities;
using DebateRI.Teams;

using Xamarin.Forms;

namespace DebateRI
{
    public partial class CreateDebate : ContentPage
    {
        List<Session> session;
        public CreateDebate()
        {
            InitializeComponent();
            SetupData();

        }
        public void SetupData()
        {
            session = new List<Session>();
            session.Add(new Session(1, "Posición inicial.", 5, "descripción"));
            session.Add(new Session(2, "Primeras argumentaciones.", 5, "descripción"));
            session.Add(new Session(3, "Preguntas.", 5, "descripción"));
            session.Add(new Session(4, "Nuevas argumentaciones.", 5, "descripción"));
            session.Add(new Session(5, "Conclusión.", 5, "descripción"));
            debateSessions.ItemsSource = session;
        }
        async void CreateTeamsClicked(object sender, EventArgs args)
        {
            debateName.Text = null;
            debateName.Placeholder = "'Nombre del debate'";
            await Navigation.PushAsync(new AddTeamDebaters());
        }
    }
}
