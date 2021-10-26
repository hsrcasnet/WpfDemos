using System.Windows;
using System.Windows.Controls;

namespace BindToList
{
    class PersonTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null || !(item is Person))
            {
                return null;
            }

            var pers = item as Person;
            if (pers.Age >= 65)
            {
                return (container as FrameworkElement).FindResource("retiredTemplate") as DataTemplate;
            }
            else
            {
                if (pers.Age <= 18)
                {
                    return (container as FrameworkElement).FindResource("childrenTemplate") as DataTemplate;
                }
                else
                {
                    return (container as FrameworkElement).FindResource("adultTemplate") as DataTemplate;
                }
            }
        }
    }
}