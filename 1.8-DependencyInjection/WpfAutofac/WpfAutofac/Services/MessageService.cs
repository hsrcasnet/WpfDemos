using System.Windows;

namespace WpfAutofac.Services
{
    public sealed class MessageService : IMessageService
    {
        public MessageService()
        {
        }

        public void Show(string message)
        {
            MessageBox.Show(message);
        }
    }
}