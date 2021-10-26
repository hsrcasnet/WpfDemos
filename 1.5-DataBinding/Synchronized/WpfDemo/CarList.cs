using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfDemo
{
    public class CarList
    {
        private ObservableCollection<Car> _list;

        public ObservableCollection<Car> List
        {
            get { return _list; }
        }

        public CarList()
        {
            _list = new ObservableCollection<Car>();
            Car c = new Car("BMW", "M3", 100000);
            _list.Add(c);
            c = new Car("BMW", "M5", 150000);
            _list.Add(c);
            c = new Car("BMW", "M5 Kombi", 160000);
            _list.Add(c);
            c = new Car("BMW", "535", 80000);
            _list.Add(c);
            c = new Car("BMW", "335i", 70000);
            _list.Add(c); 
            c = new Car("BMW", "320i", 60000);
            _list.Add(c);
            c = new Car("VW", "Golf R32", 55000);
            _list.Add(c);
            c = new Car("VW", "Passat R36", 65000);
            _list.Add(c);

        }
    }
}
