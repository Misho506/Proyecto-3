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
        }
        async void OnPass(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Argumentations());
        }
    }
}
