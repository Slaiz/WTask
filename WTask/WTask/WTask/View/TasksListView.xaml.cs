using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTask.ViewModel;
using Xamarin.Forms;

namespace WTask.View
{
    public partial class TasksListView : ContentPage
    {
        public TasksListView()
        {
            InitializeComponent();
            BindingContext = new TasksListViewModel() { Navigation = this.Navigation};
        }
    }
}
