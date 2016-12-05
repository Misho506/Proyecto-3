using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DebateRI
{
    public partial class InitialPosition : ContentPage
    {
        public InitialPosition()
        {
            InitializeComponent();
            entryPosition.Placeholder = "'Posición inicial'";
        }
        void SendInitialPosition(object sender, EventArgs e)
        {
            
            positionLBL.Text = entryPosition.Text;
            entryPosition.Text = "";
            entryPosition.Placeholder = "'Posición inicial'";
        }
        async void ArgumentationPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Argumentation());
        }
    }
}
