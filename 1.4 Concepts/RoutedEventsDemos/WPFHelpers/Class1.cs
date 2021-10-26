using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFHelpers
{
    public static class VisualLogicalTree
    {


        public static void DisplayLogicalTree(object obj)
        {
            Window w = new Window();
            w.Title = "Logical Tree";
            TreeView tv = new TreeView();
            w.Content = tv;

            WalkLogicalTree(obj, tv);

            w.Show();
        }

        static void WalkLogicalTree(object obj, ItemsControl item)
        {
            TreeViewItem tvi = new TreeViewItem();
            tvi.Header = obj.GetType().Name;
            tvi.IsExpanded = true;
            item.Items.Add(tvi);

            if ((obj as DependencyObject) != null)
                foreach (object o in LogicalTreeHelper.GetChildren((obj as DependencyObject)))
                    WalkLogicalTree(o, tvi);
        }

        public static void DisplayVisualTree(object obj)
        {
            Window w = new Window();
            w.Title = "Visual Tree";
            TreeView tv = new TreeView();
            w.Content = tv;

            WalkVisualTree(obj, tv);

            w.Show();
        }

        static void WalkVisualTree(object obj, ItemsControl item)
        {
            TreeViewItem tvi = new TreeViewItem();
            tvi.Header = obj.GetType().Name;
            tvi.IsExpanded = true;
            item.Items.Add(tvi);

            DependencyObject dobj = obj as DependencyObject;
            if (dobj != null)
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dobj); i++)
                    WalkVisualTree(VisualTreeHelper.GetChild(dobj, i), tvi); //System.Windows.Media
        }
    }
}

