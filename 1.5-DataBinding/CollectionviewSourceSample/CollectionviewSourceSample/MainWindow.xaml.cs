﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CollectionviewSourceSample
{
    public partial class MainWindow : Window
    {
        private Model DataModel { get; set; }

        public MainWindow()
        {
            this.InitializeComponent();

            this.DataModel = new Model();

            this.Source = CollectionViewSource.GetDefaultView(this.DataModel.Items);
            this.grdMain.DataContext = this.DataModel;
            this.lvItems.DataContext = this.Source;
        }

        ICollectionView Source { get; set; }

        public IEnumerable<string> DeveloperList
        {
            get { return this.DataModel.AvailableDevelopment; }
        }

        private void ListView_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader currentHeader = e.OriginalSource as GridViewColumnHeader;
            if (currentHeader != null && currentHeader.Role != GridViewColumnHeaderRole.Padding)
            {
                using (this.Source.DeferRefresh())
                {
                    Func<SortDescription, bool> lamda = item => item.PropertyName.Equals(currentHeader.Column.Header.ToString());
                    if (this.Source.SortDescriptions.Count(lamda) > 0)
                    {
                        SortDescription currentSortDescription = this.Source.SortDescriptions.First(lamda);
                        ListSortDirection sortDescription = currentSortDescription.Direction == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;

                        currentHeader.Column.HeaderTemplate = currentSortDescription.Direction == ListSortDirection.Ascending ? this.Resources["HeaderTemplateArrowDown"] as DataTemplate : this.Resources["HeaderTemplateArrowUp"] as DataTemplate;

                        this.Source.SortDescriptions.Remove(currentSortDescription);
                        this.Source.SortDescriptions.Insert(0, new SortDescription(currentHeader.Column.Header.ToString(), sortDescription));
                    }
                    else
                    {
                        this.Source.SortDescriptions.Add(new SortDescription(currentHeader.Column.Header.ToString(), ListSortDirection.Ascending));
                    }
                }
            }
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            this.Source.Filter = item =>
            {
                ViewItem vitem = item as ViewItem;
                if (vitem == null)
                {
                    return false;
                }

                PropertyInfo info = item.GetType().GetProperty(this.cmbProperty.Text);
                if (info == null)
                {
                    return false;
                }

                return info.GetValue(vitem, null).ToString().Contains(this.txtFilter.Text);
            };
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.Source.Filter = item => true;
        }

        private void btnGroup_Click(object sender, RoutedEventArgs e)
        {
            this.Source.GroupDescriptions.Clear();

            var propertyInfo = typeof(ViewItem).GetProperty(this.cmbGroups.Text);
            if (propertyInfo != null)
            {
                this.Source.GroupDescriptions.Add(new PropertyGroupDescription(propertyInfo.Name));
            }
        }

        private void btnClearGr_Click(object sender, RoutedEventArgs e)
        {
            this.Source.GroupDescriptions.Clear();
        }

        private void btnNavigation_Click(object sender, RoutedEventArgs e)
        {
            var currentButton = sender as Button;

            switch (currentButton?.Tag.ToString())
            {
                case "0":
                    this.Source.MoveCurrentToFirst();
                    break;
                case "1":
                    this.Source.MoveCurrentToPrevious();
                    break;
                case "2":
                    this.Source.MoveCurrentToNext();
                    break;
                case "3":
                    this.Source.MoveCurrentToLast();
                    break;
            }
        }

        private void btnEvaluate_Click(object sender, RoutedEventArgs e)
        {
            ViewItem item = this.lvItems.SelectedItem as ViewItem;

            string msg = string.Format("Hello {0}, Developer in {1} with Salary {2}", item.Name, item.Developer, item.Salary);
            MessageBox.Show(msg);
        }
    }
}