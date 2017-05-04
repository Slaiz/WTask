using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WTask.ViewModel;
using Xamarin.Forms;

namespace WTask.View
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();

            BindingContext = new MasterPageViewModel() { Navigation = this.Navigation };

            Detail = new NavigationPage(new TasksListPage());

            IsPresented = false;
        }
    }
}
