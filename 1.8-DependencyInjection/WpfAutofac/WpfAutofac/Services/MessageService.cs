using System.Windows;

namespace WpfAutofac.Services
{
    public sealed class MessageService : IMessageService
    {
        public MessageService()
        {
        }

        void IMessageService.Show(string message)
        {
            MessageBox.Show(message);
        }
    }
}