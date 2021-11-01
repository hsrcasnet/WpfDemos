using System.Windows.Input;

namespace WpfAutofac.Services
{
    public class LoadingIndicatorsService : ILoadingIndicatorService
    {
        public LoadingIndicatorsService()
        {
        }

        public void ShowLoadingIndicator()
        {
            Mouse.OverrideCursor = Cursors.Wait;
        }

        public void HideLoadingIndicator()
        {
            Mouse.OverrideCursor = null;
        }
    }
}