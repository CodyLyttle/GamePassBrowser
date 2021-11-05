using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GamePassBrowser.Core.MVVM.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        
        protected bool TryUpdateAndNotify<T>(ref T propertyValue, T newValue, [CallerMemberName] string callerMethod = "")
        {
            if (propertyValue.Equals(newValue))
                return false;

            propertyValue = newValue;
            OnPropertyChanged(callerMethod);
            return true;
        }
    }
}