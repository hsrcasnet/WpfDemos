using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfDependencyApp.ViewModels
{
    // DEMO: Use CommunityToolkit.Mvvm instead of our own viewmodel base class
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}