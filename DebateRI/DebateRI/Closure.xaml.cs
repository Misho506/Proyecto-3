using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebateRI.Mains;

using Xamarin.Forms;

namespace DebateRI 
{
    public partial class Closure : ContentPage
    {
        public Closure()
        {
            InitializeComponent();
            entryClosure.Placeholder = "Ingrese su conclusión porfavor";
        }
        void SendClosure(object sender, EventArgs e)
        {
            ClosureLBL.Text = entryClosure.Text;
            entryClosure.Placeholder = "Ingrese su nueva conclusión";
        }
        async void CloseDebateClicked(object sender, EventArgs e)
        {
            // 1 = admin
            if (App.currentUser.role.roleId == 2)
            {
                App.Current.MainPage = new NavigationPage(new MainAdmin());
                await Navigation.PopToRootAsync();
            }
            // 2 = Debatiente
            else if (App.currentUser.role.roleId == 1)
            {
                App.Current.MainPage = new NavigationPage(new MainAdmin());
                await Navigation.PopToRootAsync();
            }
            // 3 = Asessor
            else if (App.currentUser.role.roleId == 3)
            {
                App.Current.MainPage = new NavigationPage(new MainAdmin());
                await Navigation.PopToRootAsync();
            }
            //4 = Observador
            else if (App.currentUser.role.roleId == 4)
            {
                App.Current.MainPage = new NavigationPage(new MainObserver());
                await Navigation.PopToRootAsync();
            }
            //5 = Público
            else if (App.currentUser.role.roleId == 5)
            {
                App.Current.MainPage = new NavigationPage(new MainPublic());
                await Navigation.PopToRootAsync();
            }
        }

    }
}
