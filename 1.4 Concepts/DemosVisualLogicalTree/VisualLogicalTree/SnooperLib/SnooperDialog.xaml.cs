using System;
using System.Windows;

namespace SnooperLib
{
    public partial class SnooperDialog : Window
    {
        public SnooperDialog()
        {
            this.InitializeComponent();

            this.Closed += new EventHandler(this.SnooperDialog_Closed);
        }

        void SnooperDialog_Closed(object sender, EventArgs e)
        {
            var root = this.DataContext as VisualElement[];
            if (root != null)
            {
                VisualElement.ClearSelectionState(root[0]);
            }
        }

        public UIElement TargetElement
        {
            get { return this._targetElement; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                this._targetElement = value;

                this.DataContext = new VisualElement[]
                {
                    new VisualElement(this._targetElement)
                };
            }
        }

        void HandleRefreshButtonClick(object sender, RoutedEventArgs e)
        {
            this.DataContext = null;
            this.TargetElement = this.TargetElement;
        }

        UIElement _targetElement;
    }
}