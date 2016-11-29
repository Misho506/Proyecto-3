using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DebateRI 
{
    public partial class Conclution : ContentPage
    {
        public Conclution()
        {
            InitializeComponent();
            entryConclution.Placeholder = "Ingrese su conclusión porfavor";
        }
        void SendConclution(object sender, EventArgs e)
        {
            ConclutionLBL.Text = entryConclution.Text;
            entryConclution.Placeholder = "Ingrese su nueva conclusión";
        }

    }
}
