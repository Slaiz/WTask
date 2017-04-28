using WTask.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WTask.View
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskView : ContentPage
    {
        public TaskView(TaskViewModel taskViewModel)
        {
            InitializeComponent();
            taskViewModel.Navigation = this.Navigation;
            BindingContext = taskViewModel;
        }
    }
}
