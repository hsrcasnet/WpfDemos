using System.Windows.Input;

namespace CustomCommandDemo
{
    public static class DataCommands
    {
        public static RoutedUICommand Requery = new RoutedUICommand(
            text: "Do Requery",
            name: "Requery",
            ownerType: typeof(DataCommands),
            inputGestures: new InputGestureCollection
            {
                new KeyGesture(
                    key: Key.R,
                    modifiers: ModifierKeys.Control,
                    displayString: "Ctrl+R")
            });
    }
}