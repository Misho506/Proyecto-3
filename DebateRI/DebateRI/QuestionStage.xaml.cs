using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DebateRI
{
    public partial class QuestionStage : ContentPage
    {
        List<string> questions = new List<string>();
        public QuestionStage()
        {
            InitializeComponent();
        }
        void SendQuestionCliked(object sender, EventArgs e)
        {
            questions.Add(Question.Text);
            Question.Placeholder = "Digite su pregunta";
            listView.ItemsSource = questions;
        }

    }
}
