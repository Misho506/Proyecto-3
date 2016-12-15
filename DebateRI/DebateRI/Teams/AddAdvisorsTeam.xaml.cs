using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebateRI.Entities;

using Xamarin.Forms;

namespace DebateRI.Teams
{
    public partial class AddAdvisorsTeam : ContentPage
    {
        List<User> team1 = new List<User>();
        List<User> team2 = new List<User>();
        int counter = 6;
        Uri email;
        string body;

        private readonly List<User> contacts = new List<User>
        {
            new User(1, "Mauricio", "Lopez", "maurisho01@gmail.com", "1", DateTime.Today),
            new User(2, "Gerald", "Lopez", "geraldcydonia@gmail.com", "2", DateTime.Today),
            new User(3, "Axel", "Wing", "Awing@hotmail.es", "3", DateTime.Today),
            new User(4, "Maria", "Cornejo", "mary03081@gmail.com", "4", DateTime.Today),
            new User(5, "Farid", "Moreno", "far31af@gmail.com", "5", DateTime.Today),
            new User(6, "Daniel", "Hume", "dhume2112@gmail.com", "6", DateTime.Today),

        };
        void SendEmailForSelectedContact(object sender, SelectedItemChangedEventArgs e)
        {
            var mailToContact = new User();
            mailToContact = e.SelectedItem as User;
            if (SelectedTeam1ListView.SelectedItem != null)
            {

                body = "Saludos, " + mailToContact.name + " has sido invitado al debate...." + "\r\n" + "Como parte del Grupo 1";
                SelectedTeam1ListView.SelectedItem = null;
                email = new Uri("mailto:" + mailToContact.email + "?subject=Invitacion de Debate&body=" + body);
                Device.OpenUri(email);

            }
            else if (SelectedTeam2ListView.SelectedItem != null)
            {

                body = "Saludos, " + mailToContact.name + " has sido invitado al debate...." + "\r\n" + "Como parte del Grupo 2";
                SelectedTeam2ListView.SelectedItem = null;
                email = new Uri("mailto:" + mailToContact.email + "?subject=Invitacion de Debate&body=" + body);
                Device.OpenUri(email);

            }

        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (ContactsListView.SelectedItem != null)
            {
                var newUser = new User();
                newUser = e.SelectedItem as User;
                contacts.Remove(newUser);
                ContactsListView.ItemsSource = contacts;
                if (counter > 3)
                {
                    team1.Add(new User(newUser.userId, newUser.name, newUser.lastName, newUser.email, newUser.passwordHash, newUser.joinDate));
                    SelectedTeam1ListView.ItemsSource = team1;
                }
                else if (counter <= 3)
                {
                    team2.Add(new User(newUser.userId, newUser.name, newUser.lastName, newUser.email, newUser.passwordHash, newUser.joinDate));
                    SelectedTeam2ListView.ItemsSource = team2;
                }
                counter--;
                TeamAdvisors.Text = "Tienes que agregar '" + counter + "' Asesores";
                //debatersNumber = "You have to add '" + counter + "' debaters";
                //Team1ListView.ItemsSource = contacts;
                //SearchBarTeam1.Text = null;
                ContactsListView.SelectedItem = null;

            }
        }
        public AddAdvisorsTeam()
        {
            InitializeComponent();
            TeamAdvisors.Text = "Tienes que agregar '" + counter + "' Asesores";
            ContactsListView.ItemsSource = contacts;
            ContactsListView.ItemSelected += OnItemSelected;
            SelectedTeam1ListView.ItemSelected += SendEmailForSelectedContact;
            SelectedTeam2ListView.ItemSelected += SendEmailForSelectedContact;
            Team1.Text = App.currentNameTeam1;
            Team2.Text = App.currentNameTeam2;
        }
        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            string keyword = SearchBarAdvisors.Text;
            IEnumerable<User> searchResult = contacts.Where(CompletName => CompletName.ToString().Contains(keyword));
            ContactsListView.ItemsSource = searchResult;
            //SearchBarTeam1.Text = null;
        }
        async void AddObserversClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddObserversTeam());
        }
    }
}
