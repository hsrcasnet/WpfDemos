using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace WpfDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            CarList cl = new CarList();
            this.DataContext = cl.List;

            ICollectionView view = CollectionViewSource.GetDefaultView(cl.List);
            view.SortDescriptions.Add(new SortDescription("Marke", ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription("Modell", ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription("Preis", ListSortDirection.Ascending));

            view.CurrentChanged += new EventHandler(this.view_CurrentChanged);
        }

        void view_CurrentChanged(object sender, EventArgs e)
        {
            this.lMarke.ScrollIntoView(((ICollectionView)sender).CurrentItem);
            this.lModell.ScrollIntoView(((ICollectionView)sender).CurrentItem);
            this.lPreis.ScrollIntoView(((ICollectionView)sender).CurrentItem);
        }
    }
}