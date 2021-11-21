using System.Collections.Generic;
using BankApp.Infrastructure;
using BankApp.Models;

namespace BankApp.Services
{
    public interface IRepository<T> where T : IEntity
    {
        event RepositoryEventHandler RepositoryEvent;

        void Add(T item);

        bool Remove(T item);

        void Update(int id, T item);

        T Get(int id);

        IList<T> GetAll();

        void SetAll(IList<T> items);
    }
}
