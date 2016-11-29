using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DebateRI
{
    public partial class NewArgumentation : ContentPage
    {
        int minutesCounter = 0;
        int trigger = 0;
        public NewArgumentation()
        {
            InitializeComponent();
            sw.Stop();

        }

        public static Stopwatch sw = new Stopwatch();

        void LessMinClicked(object sender, EventArgs args)
        {

            if (minutesCounter >= 1 & trigger <= 0)
            {
                minutesCounter--;
            }
            minutes.Text = minutesCounter.ToString();
        }
        void AddMinClicked(object sender, EventArgs args)
        {
            if (minutesCounter < 60 & trigger <= 0)
            {
                minutesCounter++;
            }
            minutes.Text = minutesCounter.ToString();
        }
        void StarClicked(object sender, EventArgs args)
        {
            if (trigger == 0)
            {
                trigger++;
            }
            if (trigger <= 1)
            {
                sw.Restart();
                Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
                {

                    sw.Start();
                    int elapsedSec = (int)sw.ElapsedMilliseconds / 1000 % 60;
                    int elapsedMin = (int)sw.ElapsedMilliseconds / 1000 / 60;
                    timeLabel.Text = "Tiempo: \n" + elapsedMin + "m " + elapsedSec + "s";

                    if (elapsedMin == minutesCounter)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                });
            }
        }
        async void OnPassClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Closure());
        }
    }
}
