using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebateRI.Entities;

using Xamarin.Forms;

namespace DebateRI.Teams
{
    public partial class AddObserversTeam : ContentPage
    {
        List<User> team1 = new List<User>();
        List<User> team2 = new List<User>();
        bool changeTeam = false;
        Uri email;
        string body;

        private readonly List<User> User = new List<User>
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
                User.Remove(newUser);


                if (changeTeam == false)
                {

                    team1.Add(new User(newUser.userId, newUser.name, newUser.lastName, newUser.email, newUser.passwordHash, newUser.joinDate));
                    SelectedTeam1ListView.ItemsSource = team1;

                }
                else if (changeTeam == true)
                {

                    team2.Add(new User(newUser.userId, newUser.name, newUser.lastName, newUser.email, newUser.passwordHash, newUser.joinDate));
                    SelectedTeam2ListView.ItemsSource = team2;

                }
                //debatersNumber = "You have to add '" + counter + "' debaters";
                //Team1ListView.ItemsSource = User;
                //SearchBarTeam1.Text = null;
                ContactsListView.ItemsSource = User;
                ContactsListView.SelectedItem = null;

            }
        }
        public AddObserversTeam()
        {
            InitializeComponent();
            TeamAdvisors.Text = "Tienes que agregar Observadores";
            ContactsListView.ItemsSource = User;
            ContactsListView.ItemSelected += OnItemSelected;
            SelectedTeam1ListView.ItemSelected += SendEmailForSelectedContact;
            SelectedTeam2ListView.ItemSelected += SendEmailForSelectedContact;
        }
        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            string keyword = SearchBarAdvisors.Text;
            IEnumerable<User> searchResult = User.Where(CompletName => CompletName.ToString().Contains(keyword));
            ContactsListView.ItemsSource = searchResult;
            //SearchBarTeam1.Text = null;
        }
        void ChangeTeamButtonClicked(object sender, EventArgs args)
        {
            changeTeam = true;
        }
    }
}
