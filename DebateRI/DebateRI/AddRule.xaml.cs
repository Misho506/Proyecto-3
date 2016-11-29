using DebateRI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DebateRI
{
    public partial class AddRule : ContentPage
    {        
        public AddRule()
        {
            InitializeComponent();
            newRule.Placeholder = "'Reglamento'";
            CreateRule.Clicked += CreateRuleClicked;
        }
        void CreateRuleClicked(object sender, EventArgs args)
        {
            confirmedRule.Text = "";
            confirmedRule.Text = newRule.Text;
            //App.currentRule.description = "";
            //App.currentRule.description = confirmedRule.Text;

        }
    }
}
