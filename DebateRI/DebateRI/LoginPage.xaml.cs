using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DebateRI
{
    public partial class LoginPage : ContentPage
    {
        HttpClient httpClient;
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnLogin(object sender, EventArgs e)
        {
            httpClient = new HttpClient();
            try
            {
                //La URL de el web service
                string resourceAddress = "http://45.55.128.241:8080/DebateRI/v1/users/login";
                string resourceAddressEmail = "http://45.55.128.241:8080/DebateRI/v1/users/email/" + emailText.Text;
                //El usuario a ser checkeado
                User userToBeChecked = new User { email = emailText.Text, passwordHash = passwordText.Text };
                //El objeto User convertido a JSON guardado en un string
                string postBody = JsonConvert.SerializeObject(userToBeChecked);
                //El response que va a ser igual a hacer el request POST
                HttpResponseMessage wcfResponse = await httpClient.PostAsync(resourceAddress, new StringContent(postBody, Encoding.UTF8, "application/json"));
                //El response en formato JSON guardado en un string
                string responseBody = await wcfResponse.Content.ReadAsStringAsync();
                //El string del response convertido a un objeto de C#
                //Ya en este punto se tiene el objeto desde el Web Service
                JSONResponse jr = JsonConvert.DeserializeObject<JSONResponse>(responseBody);
                
                if (jr.error)
                    await DisplayAlert("Error", jr.description, "ok");
                else
                {
                    App.currentUser = userToBeChecked;
                    wcfResponse = await httpClient.GetAsync(resourceAddressEmail);
                    responseBody = await wcfResponse.Content.ReadAsStringAsync();
                    User returnedUser = JsonConvert.DeserializeObject<User>(responseBody);
                    App.currentUser = returnedUser;
                    App.Current.MainPage = new NavigationPage(new Home());
                    await Navigation.PopToRootAsync();
                }
            }
            finally
            {
                if (httpClient != null)
                {
                    httpClient.Dispose();
                    httpClient = null;
                }
            }
        }

        async void OnSignup(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }
    }
}
