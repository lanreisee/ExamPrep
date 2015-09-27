using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ExamPrep
{
    public partial class StudyPlanPage : ContentPage
    {
       
       

        public QuestionTemplate CurrentTemplate { get; set; }  
        public StudyPlanPage()
        {
            InitializeComponent();
            
            NavigationPage.SetBackButtonTitle(this, "Study Plans");
            
            if (AppCache.ItemPressedCount > 0)
                RefreshList();
            ++AppCache.ItemPressedCount;
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSet = e.Item as StudyPlan;
            if (itemSet == null) return;
            if (AppCache.QuestionCache != null && Application.Current.Properties.ContainsKey("QuestionTemplate"))
            {
                object currentTemplate = null;
                if (Application.Current.Properties.TryGetValue("QuestionTemplate", out currentTemplate))
                {
                    var currTemplate = currentTemplate as QuestionTemplate;
                    List<Question> retList = null;
                    if (currTemplate != null && AppCache.QuestionCache != null && AppCache.QuestionCache.ContainsKey(currTemplate.UniqueGuid))
                    {
                        CurrentTemplate = currTemplate;
                        if (AppCache.QuestionCache.TryGetValue(currTemplate.UniqueGuid, out retList))
                        {
                            if (retList != null)
                            {
                                RefreshList(); //Saw some random error and adding this line to fix it
                                await Navigation.PushAsync(new QuestionListPage(retList, itemSet.Category, AppEnums.QuestionListFilter.StudyPlan));
                                
                                return;
                            }
                        }
                    }
                }
            }
           
            var list = await AppCache.GetData(null, null);
            if (list != null && list.Count > 0)
                RefreshList(); //Saw some random error and adding this line to fix it
            await Navigation.PushAsync(new QuestionListPage(list, itemSet.Category, AppEnums.QuestionListFilter.StudyPlan));
            
        }

        private void RefreshList()
        {
            if (AppCache.QuestionCache != null && Application.Current.Properties.ContainsKey("QuestionTemplate"))
            {
                object currentTemplate = null;
                if (Application.Current.Properties.TryGetValue("QuestionTemplate", out currentTemplate))
                {
                    var currTemplate = currentTemplate as QuestionTemplate;
                    List<Question> retList = null;
                    if (currTemplate != null && AppCache.QuestionCache != null &&
                        AppCache.QuestionCache.ContainsKey(currTemplate.UniqueGuid))
                    {
                        CurrentTemplate = currTemplate;
                        if (AppCache.QuestionCache.TryGetValue(currTemplate.UniqueGuid, out retList))
                        {
                            if (retList != null)
                            {
                               
                                    foreach (var item in retList)
                                    {
                                        item.Refresh();
                                    }
                                

                            }
                        }
                    }
                }

            }
        }

        private void SaveInCache(List<Question> list)
        {
            if (CurrentTemplate == null)
            {
                object currentTemplate = null;

                if (Application.Current.Properties.TryGetValue("QuestionTemplate", out currentTemplate))
                {
                    var currTemplate = currentTemplate as QuestionTemplate;
                    if (currentTemplate != null)
                    {
                        CurrentTemplate = currTemplate;
                    }
                    else
                    {
                        //throw application wide exception
                    }
                }
            }
            if (CurrentTemplate != null && !AppCache.QuestionCache.ContainsKey(CurrentTemplate.UniqueGuid))
            {
                AppCache.QuestionCache.Add(CurrentTemplate.UniqueGuid, list);
            }
            else
            {
               //throw application wide exception
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }
    }
}
