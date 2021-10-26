using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace SnooperLib
{
    public class VisualElement
    {
        public VisualElement(UIElement uiElement)
        {
            this.Element = uiElement;
            this.TypeName = uiElement.GetType().Name;
        }

        public UIElement Element { get; private set; }
        public string TypeName { get; private set; }

        public List<VisualElement> Children
        {
            get
            {
                if (this._children == null)
                {
                    this._children = new List<VisualElement>();
                    int cnt = VisualTreeHelper.GetChildrenCount(this.Element);
                    for (int i = 0; i < cnt; ++i)
                    {
                        var child = VisualTreeHelper.GetChild(this.Element, i);
                        var elem = new VisualElement(child as UIElement);
                        this._children.Add(elem);
                    }
                }

                return this._children;
            }
        }

        public bool IsSelected
        {
            get { return this._isSelected; }
            set
            {
                this._isSelected = value;

                var layer = AdornerLayer.GetAdornerLayer(this.Element);
                if (layer == null)
                {
                    return;
                }

                if (this._adorner != null)
                {
                    layer.Remove(this._adorner);
                }

                if (this._isSelected)
                {
                    this._adorner = new SelectionAdorner(this.Element);
                    layer.Add(this._adorner);
                }
            }
        }

        internal static void ClearSelectionState(VisualElement elem)
        {
            elem.IsSelected = false;
            foreach (VisualElement child in elem.Children)
            {
                ClearSelectionState(child);
            }
        }

        List<VisualElement> _children;
        bool _isSelected;
        SelectionAdorner _adorner;
    }
}