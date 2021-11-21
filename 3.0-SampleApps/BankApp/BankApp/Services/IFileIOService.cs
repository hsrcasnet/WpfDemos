namespace BankApp.Services
{
    public interface IFileIOService<T>
    {
        void SaveAsJSON(string pathFile, T data);

        T OpenAsJSON(string pathFile);
    }
}
