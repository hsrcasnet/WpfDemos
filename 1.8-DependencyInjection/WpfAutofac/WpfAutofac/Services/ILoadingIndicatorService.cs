namespace WpfAutofac.Services
{
    public interface ILoadingIndicatorService : IService
    {
        void ShowLoadingIndicator();

        void HideLoadingIndicator();
    }
}
