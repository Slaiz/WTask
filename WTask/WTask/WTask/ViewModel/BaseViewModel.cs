using System.ComponentModel;
using System.Runtime.CompilerServices;
using PropertyChanged;
using WTask.Annotations;
using Xamarin.Forms;

namespace WTask.ViewModel
{
    [ImplementPropertyChanged]
    public class BaseViewModel:INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}