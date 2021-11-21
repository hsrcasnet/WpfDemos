using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BankApp.Enums;
using BankApp.Infrastructure;
using BankApp.Models;

namespace BankApp.Services
{
    public abstract class RepositoryInMemory<T> : IRepository<T> where T : IEntity
    {
        private readonly IList<T> items = new ObservableCollection<T>();
        private int lastId;

        public event RepositoryEventHandler RepositoryEvent;

        protected RepositoryInMemory()
        {
        }

        protected RepositoryInMemory(IList<T> items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public void Add(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (this.items.Contains(item))
            {
                return;
            }

            item.Id = ++this.lastId;
            this.items.Add(item);
            RepositoryEvent?.Invoke(item, RepositoryArgs.Add);
        }

        public T Get(int id) => this.GetAll().FirstOrDefault(item => item.Id == id);

        public IList<T> GetAll() => this.items;

        public void SetAll(IList<T> items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            this.items.Clear();
            this.lastId = 0;

            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public bool Remove(T item)
        {
            var result = this.items.Remove(item);

            if (result)
            {
                RepositoryEvent?.Invoke(item, RepositoryArgs.Delete);
            }

            return result;
        }

        public void Update(int id, T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), id, "id must be a positive integer");
            }

            if (this.items.Contains(item))
            {
                return;
            }

            var existing = ((IRepository<T>)this).Get(id);
            if (existing is null)
            {
                throw new InvalidOperationException("Item does not exist");
            }

            this.Update(item, existing);
            RepositoryEvent?.Invoke(item, RepositoryArgs.Update);
        }

        protected abstract void Update(T source, T destination);
    }
}
