﻿using System.Collections.ObjectModel;
using System.Windows;

namespace BindToList2
{
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Person> persons;

        public MainWindow()
        {
            this.InitializeComponent();
            this.persons = new ObservableCollection<Person>(PeopleFactory.GetPeople());
            this.DataContext = this.persons;
        }

        private void OnDeletePerson(object sender, RoutedEventArgs e)
        {
            var selectedPerson = this.listBox.SelectedItem as Person;
            if (this.persons.Contains(selectedPerson))
            {
                this.persons.Remove(selectedPerson);
            }
        }

        private void OnAddPerson(object sender, RoutedEventArgs e)
        {
            this.persons.Add(new Person
            {
                LastName = "",
                FirstName = ""
            });
            this.listBox.SelectedIndex = this.persons.Count - 1;
        }
    }
}