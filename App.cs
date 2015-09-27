using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ExamPrep
{
    public class App : Application
    {
        public QuestionTemplate TemplateName { get; set; }

        public App()
        {
            // The root page of your application
            CreateNewTemplate();
            MainPage = new NavigationPage(new MainPage());
            //{
            //    BarBackgroundColor = Color.FromHex("#3199FF")
            //};


        }

        private void CreateNewTemplate() //This is here because a new home page will be introduced - The selected template will be saved to application class
        {
            var curTemplate = new QuestionTemplate
            {
                CompanyName = "OIS",
                CurrentTemplate = new QuestionTemplateDetail
                {
                    FileName = "QuestionData.xml",
                    Version = "1",
                    YearReleased = new DateTime(2015,03,25),
                    Id = 1
                },
            };

            this.TemplateName = curTemplate;
            if (!Application.Current.Properties.ContainsKey("QuestionTemplate"))
            {
                Application.Current.Properties["QuestionTemplate"] = TemplateName;
            }
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
