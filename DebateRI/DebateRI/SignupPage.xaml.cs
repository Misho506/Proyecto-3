using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DebateRI
{
    public partial class SignupPage : ContentPage
    {
        HttpClient httpClient;
        public SignupPage()
        {
            InitializeComponent();
        }

        async void OnSignup(object sender, EventArgs e)
        {
            httpClient = new HttpClient();
            try
            {
                string resourceAddress = "http://45.55.128.241:8080/DebateRI/v1/users";

                //Role hardcoded cambiar!!!!!!!!!!!!
                Role r = new Role { name = "role 1", roleId = 2, isAdmin = true };
                User userToBeChecked = new User { name = nameText.Text, lastName = lastNameText.Text, email = emailText.Text, passwordHash = passwordText.Text, role = r };
                //Role hardcoded cambiar!!!!!!!!!!!!

                string postBody = JsonConvert.SerializeObject(userToBeChecked);

                HttpResponseMessage wcfResponse = await httpClient.PostAsync(resourceAddress, new StringContent(postBody, Encoding.UTF8, "application/json"));
                string responseBody = await wcfResponse.Content.ReadAsStringAsync();
                JSONResponse jr = JsonConvert.DeserializeObject<JSONResponse>(responseBody);

                if (jr.error)
                    await DisplayAlert("Error", jr.description, "ok");
                else
                {
                    App.currentUser = userToBeChecked;
                    App.Current.MainPage = new NavigationPage(new Home());
                    await Navigation.PopToRootAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "ok");
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
    }
}
