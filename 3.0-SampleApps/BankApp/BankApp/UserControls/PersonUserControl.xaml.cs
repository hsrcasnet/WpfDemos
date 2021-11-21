using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BankApp.Enums;

namespace BankApp.UserControls
{
    public partial class PersonUserControl : UserControl
    {
        public PersonUserControl()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty TitleUCProperty =
            DependencyProperty.Register(
                nameof(TitleUC),
                typeof(string),
                typeof(PersonUserControl),
                new PropertyMetadata(default(string)));

        public string TitleUC
        {
            get => (string)this.GetValue(TitleUCProperty);
            set => this.SetValue(TitleUCProperty, value);
        }

        public static readonly DependencyProperty NameUCProperty =
            DependencyProperty.Register(
                nameof(NameUC),
                typeof(string),
                typeof(PersonUserControl),
                new PropertyMetadata(default(string)));

        public string NameUC
        {
            get => (string)this.GetValue(NameUCProperty);
            set => this.SetValue(NameUCProperty, value);
        }

        public static readonly DependencyProperty SurnameUCProperty =
            DependencyProperty.Register(
                nameof(SurnameUC),
                typeof(string),
                typeof(PersonUserControl),
                new PropertyMetadata(default(string)));

        public string SurnameUC
        {
            get => (string)this.GetValue(SurnameUCProperty);
            set => this.SetValue(SurnameUCProperty, value);
        }

        public static readonly DependencyProperty PatronymicUCProperty =
            DependencyProperty.Register(
                nameof(PatronymicUC),
                typeof(string),
                typeof(PersonUserControl),
                new PropertyMetadata(default(string)));

        public string PatronymicUC
        {
            get => (string)this.GetValue(PatronymicUCProperty);
            set => this.SetValue(PatronymicUCProperty, value);
        }

        public static readonly DependencyProperty PlaceOfBirthUCProperty =
            DependencyProperty.Register(
                nameof(PlaceOfBirthUC),
                typeof(string),
                typeof(PersonUserControl),
                new PropertyMetadata(default(string)));

        public string PlaceOfBirthUC
        {
            get => (string)this.GetValue(PlaceOfBirthUCProperty);
            set => this.SetValue(PlaceOfBirthUCProperty, value);
        }

        [Obsolete("Move to viewmodel")]
        public List<string> GenderListUC { get; set; } = new List<string> { "Male", "Female" };

        public static readonly DependencyProperty GenderUCProperty =
            DependencyProperty.Register(
                nameof(GenderUC),
                typeof(Gender),
                typeof(PersonUserControl),
                new PropertyMetadata(default(Gender)));

        public Gender GenderUC
        {
            get => (Gender)this.GetValue(GenderUCProperty);
            set => this.SetValue(GenderUCProperty, value);
        }

        public static readonly DependencyProperty DateOfBirthrUCProperty =
            DependencyProperty.Register(
                nameof(DateOfBirthrUC),
                typeof(DateTime?),
                typeof(PersonUserControl),
                new PropertyMetadata(default(DateTime?)));

        public DateTime? DateOfBirthrUC
        {
            get => (DateTime?)this.GetValue(DateOfBirthrUCProperty);
            set => this.SetValue(DateOfBirthrUCProperty, value);
        }
    }
}
