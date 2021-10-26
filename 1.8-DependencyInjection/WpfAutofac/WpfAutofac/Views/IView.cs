using System;

namespace WpfAutofac
{
    public interface IView
    {
        object DataContext { get; set; }

        event EventHandler Closed;

        void Show();
    }
}