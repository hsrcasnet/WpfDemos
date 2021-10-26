namespace WpfAutofac.Services
{
    public interface IMessageService : IService
    {
        void Show(string message);
    }
}