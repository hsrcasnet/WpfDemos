using System;
using System.Windows;
using System.Windows.Controls;

namespace BankApp.UserControls
{
    public partial class PassportUserControl : UserControl
    {
        public PassportUserControl()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty TitleUCProperty =
           DependencyProperty.Register(nameof(TitleUC),
                                       typeof(string),
                                       typeof(PassportUserControl),
                                       new PropertyMetadata(default(string)));

        public string TitleUC
        {
            get => (string)this.GetValue(TitleUCProperty);
            set => this.SetValue(TitleUCProperty, value);
        }

        public static readonly DependencyProperty NumberUCProperty =
           DependencyProperty.Register(nameof(NumberUC),
                                       typeof(long?),
                                       typeof(PassportUserControl),
                                       new PropertyMetadata(default(long?)));

        public long? NumberUC
        {
            get => (long?)this.GetValue(NumberUCProperty);
            set => this.SetValue(NumberUCProperty, value);
        }

        public static readonly DependencyProperty SeriesUCProperty =
           DependencyProperty.Register(nameof(SeriesUC),
                                       typeof(long?),
                                       typeof(PassportUserControl),
                                       new PropertyMetadata(default(long?)));

        public long? SeriesUC
        {
            get => (long?)this.GetValue(SeriesUCProperty);
            set => this.SetValue(SeriesUCProperty, value);
        }

        public static readonly DependencyProperty DivisionCodeLeftUCProperty =
           DependencyProperty.Register(nameof(DivisionCodeLeftUC),
                                       typeof(int?),
                                       typeof(PassportUserControl),
                                       new PropertyMetadata(default(int?)));

        public int? DivisionCodeLeftUC
        {
            get => (int?)this.GetValue(DivisionCodeLeftUCProperty);
            set => this.SetValue(DivisionCodeLeftUCProperty, value);
        }

        public static readonly DependencyProperty DivisionCodeRightUCProperty =
           DependencyProperty.Register(nameof(DivisionCodeRightUC),
                                       typeof(int?),
                                       typeof(PassportUserControl),
                                       new PropertyMetadata(default(int?)));

        public int? DivisionCodeRightUC
        {
            get => (int?)this.GetValue(DivisionCodeRightUCProperty);
            set => this.SetValue(DivisionCodeRightUCProperty, value);
        }

        public static readonly DependencyProperty DateOfIssueUCProperty =
           DependencyProperty.Register(nameof(DateOfIssueUC),
                                       typeof(DateTime?),
                                       typeof(PassportUserControl),
                                       new PropertyMetadata(default(DateTime?)));

        public DateTime? DateOfIssueUC
        {
            get => (DateTime?)this.GetValue(DateOfIssueUCProperty);
            set => this.SetValue(DateOfIssueUCProperty, value);
        }

        public static readonly DependencyProperty PlaceOfIssueUCProperty =
           DependencyProperty.Register(nameof(PlaceOfIssueUC),
                                       typeof(string),
                                       typeof(PassportUserControl),
                                       new PropertyMetadata(default(string)));

        public string PlaceOfIssueUC
        {
            get => (string)this.GetValue(PlaceOfIssueUCProperty);
            set => this.SetValue(PlaceOfIssueUCProperty, value);
        }

    }
}
