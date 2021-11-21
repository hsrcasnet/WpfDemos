using System.Collections.Generic;
using BankApp.Models;

namespace BankApp.Services
{

    public interface IDialogService<T> where T : IEntity
    {
        T Edit(T entity);

        T Selected(IList<T> entities);
    }
}
