using System;
using System.Windows;
using System.Windows.Controls;

namespace CustomAttachedProperties3.UserControls
{
    public partial class AddressUserControl : UserControl
    {
        public AddressUserControl()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(AddressUserControl),
            new PropertyMetadata(default(string)));

        public string Title
        {
            get => (string)this.GetValue(TitleProperty);
            set => this.SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty StreetProperty = DependencyProperty.Register(
            nameof(Street),
            typeof(string),
            typeof(AddressUserControl),
            new PropertyMetadata(
                defaultValue: default(string),
                propertyChangedCallback: OnStreetPropertyChanged));

        // Demo: Property changed event handler can be subscribed:
        private static void OnStreetPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine($"OnStreetPropertyChanged: OldValue={e.OldValue}, NewValue={e.NewValue}");
        }

        public string Street
        {
            get => (string)this.GetValue(StreetProperty);
            set => this.SetValue(StreetProperty, value);
        }

        public static readonly DependencyProperty ZipCodeProperty = DependencyProperty.Register(
            nameof(ZipCode),
            typeof(string),
            typeof(AddressUserControl),
            new PropertyMetadata(defaultValue: default(string)));

        public string ZipCode
        {
            get => (string)this.GetValue(ZipCodeProperty);
            set => this.SetValue(ZipCodeProperty, value);
        }

        public static readonly DependencyProperty PlaceProperty = DependencyProperty.Register(
            nameof(Place),
            typeof(string),
            typeof(AddressUserControl),
            new PropertyMetadata(defaultValue: default(string)));

        public string Place
        {
            get => (string)this.GetValue(PlaceProperty);
            set => this.SetValue(PlaceProperty, value);
        }
    }
}
