using System;
using System.Collections.Generic;
using System.Windows;
using BankApp.Enums;

namespace BankApp.Views
{
    public partial class AddBankCustomersWindow : Window
    {
        public AddBankCustomersWindow()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty PhoneNumberProperty =
            DependencyProperty.Register(
                nameof(PhoneNumber),
                typeof(string),
                typeof(AddBankCustomersWindow),
                new PropertyMetadata(default(string)));

        public string PhoneNumber
        {
            get => (string)this.GetValue(PhoneNumberProperty);
            set => this.SetValue(PhoneNumberProperty, value);
        }

        public static readonly DependencyProperty EmailProperty =
            DependencyProperty.Register(
                nameof(Email),
                typeof(string),
                typeof(AddBankCustomersWindow),
                new PropertyMetadata(default(string)));

        public string Email
        {
            get => (string)this.GetValue(EmailProperty);
            set => this.SetValue(EmailProperty, value);
        }

        public static readonly DependencyProperty ReliabilityProperty =
            DependencyProperty.Register(
                nameof(Reliability),
                typeof(Reliability),
                typeof(AddBankCustomersWindow),
                new PropertyMetadata(default(Reliability)));

        public Reliability Reliability
        {
            get => (Reliability)this.GetValue(ReliabilityProperty);
            set => this.SetValue(ReliabilityProperty, value);
        }

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register(
                nameof(Description),
                typeof(string),
                typeof(AddBankCustomersWindow),
                new PropertyMetadata(default(string)));

        public string Description
        {
            get => (string)this.GetValue(DescriptionProperty);
            set => this.SetValue(DescriptionProperty, value);
        }

        public static readonly DependencyProperty NameBankCustomerProperty =
            DependencyProperty.Register(
                nameof(NameBankCustomer),
                typeof(string),
                typeof(AddBankCustomersWindow),
                new PropertyMetadata(default(string)));

        public string NameBankCustomer
        {
            get => (string)this.GetValue(NameBankCustomerProperty);
            set => this.SetValue(NameBankCustomerProperty, value);
        }

        public static readonly DependencyProperty SurnameBankCustomerProperty =
            DependencyProperty.Register(
                nameof(SurnameBankCustomer),
                typeof(string),
                typeof(AddBankCustomersWindow),
                new PropertyMetadata(default(string)));

        public string SurnameBankCustomer
        {
            get => (string)this.GetValue(SurnameBankCustomerProperty);
            set => this.SetValue(SurnameBankCustomerProperty, value);
        }

        public static readonly DependencyProperty GenderBankCustomerProperty =
            DependencyProperty.Register(
                nameof(GenderBankCustomer),
                typeof(Gender),
                typeof(AddBankCustomersWindow),
                new PropertyMetadata(default(Gender)));

        public Gender GenderBankCustomer
        {
            get => (Gender)this.GetValue(GenderBankCustomerProperty);
            set => this.SetValue(GenderBankCustomerProperty, value);
        }

        public static readonly DependencyProperty BirthdayBankCustomerProperty =
            DependencyProperty.Register(
                nameof(BirthdayBankCustomer),
                typeof(DateTime?),
                typeof(AddBankCustomersWindow),
                new PropertyMetadata(default(DateTime?)));

        public DateTime? BirthdayBankCustomer
        {
            get => (DateTime?)this.GetValue(BirthdayBankCustomerProperty);
            set => this.SetValue(BirthdayBankCustomerProperty, value);
        }

        public static readonly DependencyProperty PlaceOfBirthBankCustomerProperty =
            DependencyProperty.Register(
                nameof(PlaceOfBirthBankCustomer),
                typeof(string),
                typeof(AddBankCustomersWindow),
                new PropertyMetadata(default(string)));

        public string PlaceOfBirthBankCustomer
        {
            get => (string)this.GetValue(PlaceOfBirthBankCustomerProperty);
            set => this.SetValue(PlaceOfBirthBankCustomerProperty, value);
        }

        public static readonly DependencyProperty NumberPassportProperty =
           DependencyProperty.Register(nameof(NumberPassport),
                                       typeof(long?),
                                       typeof(AddBankCustomersWindow),
                                       new PropertyMetadata(default(long?)));

        public long? NumberPassport
        {
            get => (long?)this.GetValue(NumberPassportProperty);
            set => this.SetValue(NumberPassportProperty, value);
        }

        public static readonly DependencyProperty SeriesPassportProperty =
           DependencyProperty.Register(nameof(SeriesPassport),
                                       typeof(long?),
                                       typeof(AddBankCustomersWindow),
                                       new PropertyMetadata(default(long?)));

        public long? SeriesPassport
        {
            get => (long?)this.GetValue(SeriesPassportProperty);
            set => this.SetValue(SeriesPassportProperty, value);
        }

        public static readonly DependencyProperty DivisionCodeLeftPassportProperty =
           DependencyProperty.Register(nameof(DivisionCodeLeftPassport),
                                       typeof(int?),
                                       typeof(AddBankCustomersWindow),
                                       new PropertyMetadata(default(int?)));

        public int? DivisionCodeLeftPassport
        {
            get => (int?)this.GetValue(DivisionCodeLeftPassportProperty);
            set => this.SetValue(DivisionCodeLeftPassportProperty, value);
        }

        public static readonly DependencyProperty DivisionCodeRightPassportProperty =
           DependencyProperty.Register(nameof(DivisionCodeRightPassport),
                                       typeof(int?),
                                       typeof(AddBankCustomersWindow),
                                       new PropertyMetadata(default(int?)));

        public int? DivisionCodeRightPassport
        {
            get => (int?)this.GetValue(DivisionCodeRightPassportProperty);
            set => this.SetValue(DivisionCodeRightPassportProperty, value);
        }

        public static readonly DependencyProperty DateOfIssuePassportProperty =
           DependencyProperty.Register(nameof(DateOfIssuePassport),
                                       typeof(DateTime?),
                                       typeof(AddBankCustomersWindow),
                                       new PropertyMetadata(default(DateTime?)));

        public DateTime? DateOfIssuePassport
        {
            get => (DateTime?)this.GetValue(DateOfIssuePassportProperty);
            set => this.SetValue(DateOfIssuePassportProperty, value);
        }

        public static readonly DependencyProperty PlaceOfIssuePassportProperty =
           DependencyProperty.Register(nameof(PlaceOfIssuePassport),
                                       typeof(string),
                                       typeof(AddBankCustomersWindow),
                                       new PropertyMetadata(default(string)));

        public string PlaceOfIssuePassport
        {
            get => (string)this.GetValue(PlaceOfIssuePassportProperty);
            set => this.SetValue(PlaceOfIssuePassportProperty, value);
        }

        public static readonly DependencyProperty RegionPlaceOfResidenceProperty =
            DependencyProperty.Register(nameof(RegionPlaceOfResidence),
                                        typeof(string),
                                        typeof(AddBankCustomersWindow),
                                        new PropertyMetadata(default(string)));

        public string RegionPlaceOfResidence
        {
            get => (string)this.GetValue(RegionPlaceOfResidenceProperty);
            set => this.SetValue(RegionPlaceOfResidenceProperty, value);
        }

        public static readonly DependencyProperty CityPlaceOfResidenceProperty =
            DependencyProperty.Register(nameof(CityPlaceOfResidence),
                                        typeof(string),
                                        typeof(AddBankCustomersWindow),
                                        new PropertyMetadata(default(string)));

        public string CityPlaceOfResidence
        {
            get => (string)this.GetValue(CityPlaceOfResidenceProperty);
            set => this.SetValue(CityPlaceOfResidenceProperty, value);
        }

        public static readonly DependencyProperty DistrictPlaceOfResidenceProperty =
            DependencyProperty.Register(nameof(DistrictPlaceOfResidence),
                                        typeof(string),
                                        typeof(AddBankCustomersWindow),
                                        new PropertyMetadata(default(string)));

        public string DistrictPlaceOfResidence
        {
            get => (string)this.GetValue(DistrictPlaceOfResidenceProperty);
            set => this.SetValue(DistrictPlaceOfResidenceProperty, value);
        }

        public static readonly DependencyProperty StreetPlaceOfResidenceProperty =
            DependencyProperty.Register(nameof(StreetPlaceOfResidence),
                                        typeof(string),
                                        typeof(AddBankCustomersWindow),
                                        new PropertyMetadata(default(string)));

        public string StreetPlaceOfResidence
        {
            get => (string)this.GetValue(StreetPlaceOfResidenceProperty);
            set => this.SetValue(StreetPlaceOfResidenceProperty, value);
        }

        public static readonly DependencyProperty HouseNumberPlaceOfResidenceProperty =
            DependencyProperty.Register(nameof(HouseNumberPlaceOfResidence),
                                        typeof(int?),
                                        typeof(AddBankCustomersWindow),
                                        new PropertyMetadata(default(int?)));

        public int? HouseNumberPlaceOfResidence
        {
            get => (int?)this.GetValue(HouseNumberPlaceOfResidenceProperty);
            set => this.SetValue(HouseNumberPlaceOfResidenceProperty, value);
        }

        public static readonly DependencyProperty HousingPlaceOfResidenceProperty =
            DependencyProperty.Register(nameof(HousingPlaceOfResidence),
                                        typeof(string),
                                        typeof(AddBankCustomersWindow),
                                        new PropertyMetadata(default(string)));

        public string HousingPlaceOfResidence
        {
            get => (string)this.GetValue(HousingPlaceOfResidenceProperty);
            set => this.SetValue(HousingPlaceOfResidenceProperty, value);
        }

        public static readonly DependencyProperty ApartmentNumberPlaceOfResidenceProperty =
            DependencyProperty.Register(nameof(ApartmentNumberPlaceOfResidence),
                                        typeof(int?),
                                        typeof(AddBankCustomersWindow),
                                        new PropertyMetadata(default(int?)));

        public int? ApartmentNumberPlaceOfResidence
        {
            get => (int?)this.GetValue(ApartmentNumberPlaceOfResidenceProperty);
            set => this.SetValue(ApartmentNumberPlaceOfResidenceProperty, value);
        }

        public static readonly DependencyProperty RegistrationDatePlaceOfResidenceProperty =
            DependencyProperty.Register(nameof(RegistrationDatePlaceOfResidence),
                                        typeof(DateTime?),
                                        typeof(AddBankCustomersWindow),
                                        new PropertyMetadata(default(DateTime?)));

        public DateTime? RegistrationDatePlaceOfResidence
        {
            get => (DateTime?)this.GetValue(RegistrationDatePlaceOfResidenceProperty);
            set => this.SetValue(RegistrationDatePlaceOfResidenceProperty, value);
        }

        public static readonly DependencyProperty RegionRegistrationProperty =
            DependencyProperty.Register(nameof(RegionRegistration),
                                        typeof(string),
                                        typeof(AddBankCustomersWindow),
                                        new PropertyMetadata(default(string)));

        public string RegionRegistration
        {
            get => (string)this.GetValue(RegionRegistrationProperty);
            set => this.SetValue(RegionRegistrationProperty, value);
        }

        public static readonly DependencyProperty CityRegistrationProperty =
            DependencyProperty.Register(nameof(CityRegistration),
                                        typeof(string),
                                        typeof(AddBankCustomersWindow),
                                        new PropertyMetadata(default(string)));

        public string CityRegistration
        {
            get => (string)this.GetValue(CityRegistrationProperty);
            set => this.SetValue(CityRegistrationProperty, value);
        }

        public static readonly DependencyProperty DistrictRegistrationProperty =
            DependencyProperty.Register(nameof(DistrictRegistration),
                                        typeof(string),
                                        typeof(AddBankCustomersWindow),
                                        new PropertyMetadata(default(string)));

        public string DistrictRegistration
        {
            get => (string)this.GetValue(DistrictRegistrationProperty);
            set => this.SetValue(DistrictRegistrationProperty, value);
        }

        public static readonly DependencyProperty StreetRegistrationProperty =
            DependencyProperty.Register(nameof(StreetRegistration),
                                        typeof(string),
                                        typeof(AddBankCustomersWindow),
                                        new PropertyMetadata(default(string)));

        public string StreetRegistration
        {
            get => (string)this.GetValue(StreetRegistrationProperty);
            set => this.SetValue(StreetRegistrationProperty, value);
        }

        public static readonly DependencyProperty HouseNumberRegistrationProperty =
            DependencyProperty.Register(nameof(HouseNumberRegistration),
                                        typeof(int?),
                                        typeof(AddBankCustomersWindow),
                                        new PropertyMetadata(default(int?)));

        public int? HouseNumberRegistration
        {
            get => (int?)this.GetValue(HouseNumberRegistrationProperty);
            set => this.SetValue(HouseNumberRegistrationProperty, value);
        }

        public static readonly DependencyProperty HousingRegistrationProperty =
            DependencyProperty.Register(nameof(HousingRegistration),
                                        typeof(string),
                                        typeof(AddBankCustomersWindow),
                                        new PropertyMetadata(default(string)));

        public string HousingRegistration
        {
            get => (string)this.GetValue(HousingRegistrationProperty);
            set => this.SetValue(HousingRegistrationProperty, value);
        }

        public static readonly DependencyProperty ApartmentNumberRegistrationProperty =
            DependencyProperty.Register(nameof(ApartmentNumberRegistration),
                                        typeof(int?),
                                        typeof(AddBankCustomersWindow),
                                        new PropertyMetadata(default(int?)));

        public int? ApartmentNumberRegistration
        {
            get => (int?)this.GetValue(ApartmentNumberRegistrationProperty);
            set => this.SetValue(ApartmentNumberRegistrationProperty, value);
        }

        public static readonly DependencyProperty RegistrationDateRegistrationProperty =
            DependencyProperty.Register(
                nameof(RegistrationDateRegistration),
                typeof(DateTime?),
                typeof(AddBankCustomersWindow),
                new PropertyMetadata(default(DateTime?)));

        public DateTime? RegistrationDateRegistration
        {
            get => (DateTime?)this.GetValue(RegistrationDateRegistrationProperty);
            set => this.SetValue(RegistrationDateRegistrationProperty, value);
        }
        
        [Obsolete("Move to viewmodel")]
        public List<string> ReliabilityList { get; set; } = new List<string> { "Low",
                                                                               "Medium",
                                                                               "High" };

    }
}
