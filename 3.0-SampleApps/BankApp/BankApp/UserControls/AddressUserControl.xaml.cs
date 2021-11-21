using System;
using System.Windows;
using System.Windows.Controls;

namespace BankApp.UserControls
{
    public partial class AddressUserControl : UserControl
    {
        public AddressUserControl()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty TitleUCProperty =
           DependencyProperty.Register(nameof(TitleUC),
                                       typeof(string),
                                       typeof(AddressUserControl),
                                       new PropertyMetadata(default(string)));

        public string TitleUC
        {
            get => (string)this.GetValue(TitleUCProperty);
            set => this.SetValue(TitleUCProperty, value);
        }

        public static readonly DependencyProperty RegionUCProperty =
            DependencyProperty.Register(nameof(RegionUC),
                                        typeof(string),
                                        typeof(AddressUserControl),
                                        new PropertyMetadata(default(string)));

        public string RegionUC
        {
            get => (string)this.GetValue(RegionUCProperty);
            set => this.SetValue(RegionUCProperty, value);
        }

        public static readonly DependencyProperty CityUCProperty =
            DependencyProperty.Register(nameof(CityUC),
                                        typeof(string),
                                        typeof(AddressUserControl),
                                        new PropertyMetadata(default(string)));

        public string CityUC
        {
            get => (string)this.GetValue(CityUCProperty);
            set => this.SetValue(CityUCProperty, value);
        }

        public static readonly DependencyProperty DistrictUCProperty =
            DependencyProperty.Register(nameof(DistrictUC),
                                        typeof(string),
                                        typeof(AddressUserControl),
                                        new PropertyMetadata(default(string)));

        public string DistrictUC
        {
            get => (string)this.GetValue(DistrictUCProperty);
            set => this.SetValue(DistrictUCProperty, value);
        }

        public static readonly DependencyProperty StreetUCProperty =
            DependencyProperty.Register(nameof(StreetUC),
                                        typeof(string),
                                        typeof(AddressUserControl),
                                        new PropertyMetadata(default(string)));

        public string StreetUC
        {
            get => (string)this.GetValue(StreetUCProperty);
            set => this.SetValue(StreetUCProperty, value);
        }

        public static readonly DependencyProperty HouseNumberUCProperty =
            DependencyProperty.Register(nameof(HouseNumberUC),
                                        typeof(int?),
                                        typeof(AddressUserControl),
                                        new PropertyMetadata(default(int?)));

        public int? HouseNumberUC
        {
            get => (int?)this.GetValue(HouseNumberUCProperty);
            set => this.SetValue(HouseNumberUCProperty, value);
        }

        public static readonly DependencyProperty HousingUCProperty =
            DependencyProperty.Register(nameof(HousingUC),
                                        typeof(string),
                                        typeof(AddressUserControl),
                                        new PropertyMetadata(default(string)));

        public string HousingUC
        {
            get => (string)this.GetValue(HousingUCProperty);
            set => this.SetValue(HousingUCProperty, value);
        }

        public static readonly DependencyProperty ApartmentNumberUCProperty =
            DependencyProperty.Register(nameof(ApartmentNumberUC),
                                        typeof(int?),
                                        typeof(AddressUserControl),
                                        new PropertyMetadata(default(int?)));

        public int? ApartmentNumberUC
        {
            get => (int?)this.GetValue(ApartmentNumberUCProperty);
            set => this.SetValue(ApartmentNumberUCProperty, value);
        }

        public static readonly DependencyProperty RegistrationDateUCProperty =
            DependencyProperty.Register(nameof(RegistrationDateUC),
                                        typeof(DateTime?),
                                        typeof(AddressUserControl),
                                        new PropertyMetadata(default(DateTime?)));

        public DateTime? RegistrationDateUC
        {
            get => (DateTime?)this.GetValue(RegistrationDateUCProperty);
            set => this.SetValue(RegistrationDateUCProperty, value);
        }
    }
}
