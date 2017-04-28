using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PropertyChanged;
using WTask.Model;
using Xamarin.Forms;

namespace WTask
{
    [ImplementPropertyChanged]
    public partial class App : Application
    {
        private const string DATABASE_NAME = "WTask2.db";
        private static TaskModelRepository _database;
        public static TaskModelRepository Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new TaskModelRepository(DATABASE_NAME);
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new WTask.View.TasksListView());
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
