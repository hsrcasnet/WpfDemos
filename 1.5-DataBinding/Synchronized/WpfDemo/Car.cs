using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfDemo
{
    public class Car : INotifyPropertyChanged 
    {
        private string _marke;
        private string _modell;
        private double _preis;
        
        public event PropertyChangedEventHandler PropertyChanged;

        public Car(string marke, string modell, double preis)
        {
            _marke = marke;
            _modell = modell;
            _preis = preis;
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Marke
        {
            get { return _marke; }
            set
            {
                _marke = value;
                OnPropertyChanged("Marke");
            }
        }

        public string Modell
        {
            get { return _modell; }
            set
            {
                _modell = value;
                OnPropertyChanged("Modell");
            }
        }

        public double Preis
        {
            get { return _preis; }
            set
            {
                _preis = value;
                OnPropertyChanged("Preis");
            }
        }
    }
}
