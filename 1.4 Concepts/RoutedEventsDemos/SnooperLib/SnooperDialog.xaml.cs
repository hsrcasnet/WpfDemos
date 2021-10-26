using System;
using System.Windows;

namespace SnooperLib
{
    public partial class SnooperDialog : Window
    {
        public SnooperDialog()
        {
            InitializeComponent();

            this.Closed += new EventHandler(SnooperDialog_Closed);
        }

        void SnooperDialog_Closed(object sender, EventArgs e)
        {
            var root = base.DataContext as VisualElement[];
            if (root != null)
                VisualElement.ClearSelectionState(root[0]);
        }

        public UIElement TargetElement
        {
            get { return _targetElement; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                _targetElement = value;

                base.DataContext = new VisualElement[]
                {
                    new VisualElement(_targetElement)
                };
            }
        }

        void HandleRefreshButtonClick(object sender, RoutedEventArgs e)
        {
            base.DataContext = null;
            this.TargetElement = this.TargetElement;
        }

        UIElement _targetElement;
    }
}