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
                if (_children == null)
                {
                    _children = new List<VisualElement>();
                    int cnt = VisualTreeHelper.GetChildrenCount(Element);
                    for (int i = 0; i < cnt; ++i)
                    {
                        var child = VisualTreeHelper.GetChild(Element, i);
                        var elem = new VisualElement(child as UIElement);
                        _children.Add(elem);
                    }
                }
                return _children;
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;

                var layer = AdornerLayer.GetAdornerLayer(Element);
                if (layer == null)
                    return;

                if (_adorner != null)
                    layer.Remove(_adorner);

                if (_isSelected)
                {
                    _adorner = new SelectionAdorner(Element);
                    layer.Add(_adorner);
                }
            }
        }

        internal static void ClearSelectionState(VisualElement elem)
        {
            elem.IsSelected = false;
            foreach (VisualElement child in elem.Children)
                ClearSelectionState(child);
        }

        List<VisualElement> _children;
        bool _isSelected;
        SelectionAdorner _adorner;
    }    
}