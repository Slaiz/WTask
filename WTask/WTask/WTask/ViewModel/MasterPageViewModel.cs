using System.Windows.Input;
using WTask.View;
using Xamarin.Forms;

namespace WTask.ViewModel
{
    public class MasterPageViewModel:BaseViewModel
    {
        public ICommand NavigateToMyTaskCommand { get; set; }
        public ICommand NavigateToAddTaskCommand { get; set; }

        public MasterPageViewModel()
        {
            NavigateToMyTaskCommand = new Command(arg => NavigateToMyTask());
            NavigateToAddTaskCommand = new Command(arg => NavigateToAddTask());
        }

        private void NavigateToAddTask()
        {
            //_masterPage.Detail = new NavigationPage(new TaskPage(new TaskPageViewModel(null)));
        }

        private void NavigateToMyTask()
        {
            //_masterPage.Detail = new NavigationPage(new TasksListPage());
        }
    }
}