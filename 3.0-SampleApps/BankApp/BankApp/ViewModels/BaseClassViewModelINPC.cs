using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Markup;

namespace BankApp.ViewModels
{
    public abstract class BaseClassViewModelINPC : MarkupExtension, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public void OnPropertyChanged(IEnumerable<string> propList)
        {
            foreach (var prp in propList.Where(name => !string.IsNullOrWhiteSpace(name)))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prp));
            }
        }

        public void OnPropertyChanged(IEnumerable<PropertyInfo> propList)
        {
            foreach (var prp in propList)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prp.Name));
            }
        }

        public void OnAllPropertyChanged() => this.OnPropertyChanged(this.GetType().GetProperties());

        public bool Set<T>(ref T field, T value, [CallerMemberName] string property = null)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            this.OnPropertyChanged(property);

            return true;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
