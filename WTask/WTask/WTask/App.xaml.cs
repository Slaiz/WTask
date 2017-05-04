using Prism.Unity;
using PropertyChanged;
using WTask.Model;
using WTask.View;
using Xamarin.Forms;

namespace WTask
{
    [ImplementPropertyChanged]
    public partial class App:PrismApplication
    {
        private const string DATABASE_NAME = "WTask9.db";
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

            MainPage = new WTask.View.MasterPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnInitialized()
        {
            throw new System.NotImplementedException();
        }

        protected override void RegisterTypes()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
