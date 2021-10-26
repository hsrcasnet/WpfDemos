using System;
using System.Windows;

namespace DelegateCommandWith.ViewModels
{
    public class DialogService : IDialogService
    {
        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }
    }
}