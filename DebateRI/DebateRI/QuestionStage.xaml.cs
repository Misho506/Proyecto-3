using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DebateRI.Mains;
using DebateRI.Entities;

using Xamarin.Forms;

namespace DebateRI
{
    public partial class QuestionStage : ContentPage
    {
        HttpClient httpClient;
        List<string> questions = new List<string>();
        public QuestionStage()
        {
            InitializeComponent();
        }
        async void SendQuestionCliked(object sender, EventArgs e)
        {
            int messageIdc = 50;
            messageIdc ++;
            httpClient = new HttpClient();
            try {
                string resourceAddress = "http://45.55.128.241:8080/DebateRItest/v1/messages";
                
            Mensaje mensaje = new Mensaje { description = entQuestion.Text};
            //Role hardcoded cambiar!!!!!!!!!!!!

            string postBody = JsonConvert.SerializeObject(mensaje);

            HttpResponseMessage wcfResponse = await httpClient.PostAsync(resourceAddress, new StringContent(postBody, Encoding.UTF8, "application/json"));
            string responseBody = await wcfResponse.Content.ReadAsStringAsync();
            JSONResponse jr = JsonConvert.DeserializeObject<JSONResponse>(responseBody);

                if (jr.error) { }

                else
                {
                   
          

                    //App.currentUser = userToBeChecked;
                    //App.Current.MainPage = new NavigationPage(new MainAdmin());
                    //await Navigation.PopToRootAsync();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (httpClient != null)
                {
                    httpClient.Dispose();
                    httpClient = null;
                }
            }
            questions.Add(entQuestion.Text);
            entQuestion.Placeholder = "Digite su pregunta";
            listView.ItemsSource = questions;

        }
    }
}



   