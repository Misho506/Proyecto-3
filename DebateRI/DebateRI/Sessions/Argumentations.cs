using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DebateRI.Sessions
{
    class Argumentations : ContentPage
    {

        Label Sec = new Label()
        {
            HorizontalOptions = LayoutOptions.Center,
        };
        Label HourAndMin = new Label()
        {
            HorizontalOptions = LayoutOptions.Center,
        };
        int count = 0;
        int hour = 00;
        int min = 00;
        int sec = 00;
        public Argumentations()
        {
            HourAndMin.Text = hour + ":0" + min;
            HourAndMin.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            Sec.Text = " " + sec;
            Sec.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            var lessMinButton = new Button { Text = "Quitar 1 minuto", VerticalOptions = LayoutOptions.Center, BackgroundColor = Color.Red };
            lessMinButton.Clicked += lessMinButtonClick;
            var AddMinButton = new Button { Text = "Agregar 1 minuto", VerticalOptions = LayoutOptions.Center, BackgroundColor = Color.Green };
            AddMinButton.Clicked += AddMinButtonClick;
            var StartButton = new Button { Text = "Empezar", VerticalOptions = LayoutOptions.Center, BackgroundColor = Color.FromHex("#F0F8FF") };
            StartButton.Clicked += StartButtonClick;


            var btnNext = new Button
            {
                Text = "Siguiente etapa",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand
            };

            //btnNext.Clicked += async (sender, args) =>
            //{
                //await Navigation.PushModalAsync(new QuestionStage());
            //};

            var btnBack = new Button
            {
                Text = "Volver",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            btnBack.Clicked += async (sender, args) =>
            {
                await Navigation.PopModalAsync();
            };





            Padding = new Thickness(0, 50, 0, 0);
            Content = new StackLayout
            {
                Children = {
                    new StackLayout {
                        Orientation = StackOrientation.Vertical,
                        Children = {

                            new StackLayout{
                                             Spacing = 0,
                                             Orientation = StackOrientation.Vertical,
                Children = {
                new Label
                {
                 Text = "Argumentaciones",
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 30,
            TextColor = Color.Green
                }
                }
            },


                            new StackLayout
            {
                Spacing = 0,
                Orientation = StackOrientation.Horizontal,
                Children =
            {
            HourAndMin, Sec
                            },
                        },
                    StartButton,
                    AddMinButton,
                    lessMinButton,
                    new StackLayout
            {
                Spacing = 10,
                Orientation = StackOrientation.Horizontal,
                Children =
            {     btnBack,
                            btnNext,

                    }
                        }
                            }
                                } }
            };

        }

        void lessMinButtonClick(object sender, EventArgs args)
        {
            if (hour != 0 || min != 0 || sec != 0)
            {
                if (hour > 0 && min == 0)
                {
                    hour--;
                    min = 59;
                    count--;
                    HourAndMin.Text = hour + ":" + min;
                }
                else if (min <= 59)
                {
                    if (min < 9)
                    {
                        min--;
                        HourAndMin.Text = hour + ":0" + min;
                    }
                    else
                    {
                        min--;
                        count--;
                        HourAndMin.Text = hour + ":" + min;
                    }
                }
            }
        }
        void AddMinButtonClick(object sender, EventArgs args)
        {
            count++;
            if (min == 59)
            {
                hour++;
                min = 00;
                count = 0;
                HourAndMin.Text = hour + ":" + min;
            }
            else if (min < 9)
            {
                min++;
                HourAndMin.Text = hour + ":0" + min;
            }
            else
            {
                min++;
                HourAndMin.Text = hour + ":" + min;
            }
        }
        void StartButtonClick(object sender, EventArgs args)
        {
            while (hour > 0 || min > 0 || sec > 0)
            {
                if (hour >= 0)
                {
                    if (min >= 0)
                    {
                        if (sec > 0)
                        {
                            sec--;
                            //Thread.Sleep(1000);
                            if (sec <= 9)
                            {
                                Sec.Text = ":0" + sec;
                            }
                            else
                            {
                                Sec.Text = ":" + sec;
                            }
                        }
                        else
                        {
                            //Thread.Sleep(1000);
                            sec = 59;
                            min--;
                            if (min <= 9)
                            {
                                Sec.Text = ":" + sec;
                                HourAndMin.Text = hour + ":0" + min;
                            }
                            else
                            {
                                HourAndMin.Text = hour + ":" + min;
                                Sec.Text = ":" + sec;
                            }
                        }
                    }
                    else
                    {
                        //Thread.Sleep(1000);
                        if (hour <= 24)
                        {
                            HourAndMin.Text = "0" + hour + ":" + min;
                        }
                        else
                        {
                            HourAndMin.Text = hour + ":" + min;
                        }
                        min = 59;
                        hour--;
                    }
                }
            }
        }
    }

}
