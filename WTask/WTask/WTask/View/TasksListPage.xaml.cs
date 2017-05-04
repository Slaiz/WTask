using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTask.ViewModel;
using Xamarin.Forms;

namespace WTask.View
{
    public partial class TasksListPage : ContentPage
    {
        public TasksListPage()
        {
            InitializeComponent();
            BindingContext = new TasksListPageViewModel() { Navigation = this.Navigation};
        }
    }
}
