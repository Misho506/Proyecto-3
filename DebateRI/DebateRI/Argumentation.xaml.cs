using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DebateRI
{
    public partial class Argumentation : ContentPage
    {
        int minutesCounter = 0;
        int trigger = 0;
        bool stop = false;
        public Argumentation()
        {
            InitializeComponent();
            sw.Stop();
                
        }

        public static Stopwatch sw = new Stopwatch();
        async void QuestionPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuestionStage());
        }
        void StopClicked(object sender, EventArgs e)
        {
            stop = true;
            sw.Stop();
        }
        void RestarClicked(object sender, EventArgs e)
        {
            stop = false;
            sw.Restart();
        }

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
            int elapsedSec = 0;
            int elapsedMin = 0;
            if (trigger == 0)
            {
                trigger++;
            }
            if (trigger <= 1)
            {
                sw.Restart();
                Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
                {
                    if (stop == true)
                    {
                        sw.Stop();
                    }
                    else
                    {
                        sw.Start();
                         elapsedSec = (int)sw.ElapsedMilliseconds / 1000 % 60;
                         elapsedMin = (int)sw.ElapsedMilliseconds / 1000 / 60;
                        timeLabel.Text = "Tiempo: \n" + elapsedMin + "m " + elapsedSec + "s";
                    }
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
    }
}
