using WTask.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WTask.View
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskPage : ContentPage
    {
        public TaskPage(TaskPageViewModel taskPageViewModel)
        {
            InitializeComponent();
            taskPageViewModel.Navigation = this.Navigation;
            BindingContext = taskPageViewModel;
        }
    }
}
