namespace BankApp.Services
{
    public interface IFileDialogService<T>
    {
        void SaveFileDialog(T data);

        T OpenFileDialog();
    }
}
