using System.Windows;

namespace PrismSampleApp.Services
{
    public class MessageService : IMessageService
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