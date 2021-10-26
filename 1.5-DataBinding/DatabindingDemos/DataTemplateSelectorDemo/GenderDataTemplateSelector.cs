using System.Windows;
using System.Windows.Controls;

namespace DataTemplateSelectorDemo
{
    public class GenderDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MaleTemplate { get; set; }

        public DataTemplate FemaleTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate selectedTemplate = null;

            if (item is Person person)
            {
                switch (person.Gender)
                {
                    case Gender.Female:
                        selectedTemplate = this.FemaleTemplate;
                        break;
                    case Gender.Male:
                        selectedTemplate = this.MaleTemplate;
                        break;
                }
            }

            return selectedTemplate;
        }
    }
}