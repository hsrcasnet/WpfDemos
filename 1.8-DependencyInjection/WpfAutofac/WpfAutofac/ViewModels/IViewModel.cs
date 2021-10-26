using System;
using System.ComponentModel;

namespace WpfAutofac.ViewModels
{
    public interface IViewModel : INotifyPropertyChanged
    {
        string ViewTitle { get; }
    }
}