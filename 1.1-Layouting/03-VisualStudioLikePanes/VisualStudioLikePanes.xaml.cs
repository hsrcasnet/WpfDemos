using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

public partial class MainWindow : Window
{
    // Dummy columns for layers 0 and 1:
    readonly ColumnDefinition column1CloneForLayer0;
    readonly ColumnDefinition column2CloneForLayer0;
    readonly ColumnDefinition column2CloneForLayer1;

    public MainWindow()
    {
        this.InitializeComponent();

        // Initialize the dummy columns used when docking:
        this.column1CloneForLayer0 = new ColumnDefinition();
        this.column1CloneForLayer0.SharedSizeGroup = "column1";
        this.column2CloneForLayer0 = new ColumnDefinition();
        this.column2CloneForLayer0.SharedSizeGroup = "column2";
        this.column2CloneForLayer1 = new ColumnDefinition();
        this.column2CloneForLayer1.SharedSizeGroup = "column2";
    }

    // Toggle between docked and undocked states (Pane 1)
    public void pane1Pin_Click(object sender, RoutedEventArgs e)
    {
        if (this.pane1Button.Visibility == Visibility.Collapsed)
        {
            this.UndockPane(1);
        }
        else
        {
            this.DockPane(1);
        }
    }

    // Toggle between docked and undocked states (Pane 2)
    public void pane2Pin_Click(object sender, RoutedEventArgs e)
    {
        if (this.pane2Button.Visibility == Visibility.Collapsed)
        {
            this.UndockPane(2);
        }
        else
        {
            this.DockPane(2);
        }
    }

    // Show Pane 1 when hovering over its button
    public void pane1Button_MouseEnter(object sender, RoutedEventArgs e)
    {
        this.layer1.Visibility = Visibility.Visible;

        // Adjust Z order to ensure the pane is on top:
        this.parentGrid.Children.Remove(this.layer1);
        this.parentGrid.Children.Add(this.layer1);

        // Ensure the other pane is hidden if it is undocked
        if (this.pane2Button.Visibility == Visibility.Visible)
        {
            this.layer2.Visibility = Visibility.Collapsed;
        }
    }

    // Show Pane 2 when hovering over its button
    public void pane2Button_MouseEnter(object sender, RoutedEventArgs e)
    {
        this.layer2.Visibility = Visibility.Visible;

        // Adjust Z order to ensure the pane is on top:
        this.parentGrid.Children.Remove(this.layer2);
        this.parentGrid.Children.Add(this.layer2);

        // Ensure the other pane is hidden if it is undocked
        if (this.pane1Button.Visibility == Visibility.Visible)
        {
            this.layer1.Visibility = Visibility.Collapsed;
        }
    }

    // Hide any undocked panes when the mouse enters Layer 0
    public void layer0_MouseEnter(object sender, RoutedEventArgs e)
    {
        if (this.pane1Button.Visibility == Visibility.Visible)
        {
            this.layer1.Visibility = Visibility.Collapsed;
        }

        if (this.pane2Button.Visibility == Visibility.Visible)
        {
            this.layer2.Visibility = Visibility.Collapsed;
        }
    }

    // Hide the other pane if undocked when the mouse enters Pane 1
    public void pane1_MouseEnter(object sender, RoutedEventArgs e)
    {
        // Ensure the other pane is hidden if it is undocked
        if (this.pane2Button.Visibility == Visibility.Visible)
        {
            this.layer2.Visibility = Visibility.Collapsed;
        }
    }

    // Hide the other pane if undocked when the mouse enters Pane 2
    public void pane2_MouseEnter(object sender, RoutedEventArgs e)
    {
        // Ensure the other pane is hidden if it is undocked
        if (this.pane1Button.Visibility == Visibility.Visible)
        {
            this.layer1.Visibility = Visibility.Collapsed;
        }
    }

    // Docks a pane, which hides the corresponding pane button
    public void DockPane(int paneNumber)
    {
        if (paneNumber == 1)
        {
            this.pane1Button.Visibility = Visibility.Collapsed;
            this.pane1PinImage.Source = new BitmapImage(new Uri("pin.gif", UriKind.Relative));

            // Add the cloned column to layer 0:
            this.layer0.ColumnDefinitions.Add(this.column1CloneForLayer0);
            // Add the cloned column to layer 1, but only if pane 2 is docked:
            if (this.pane2Button.Visibility == Visibility.Collapsed)
            {
                this.layer1.ColumnDefinitions.Add(this.column2CloneForLayer1);
            }
        }
        else if (paneNumber == 2)
        {
            this.pane2Button.Visibility = Visibility.Collapsed;
            this.pane2PinImage.Source = new BitmapImage(new Uri("pin.gif", UriKind.Relative));

            // Add the cloned column to layer 0:
            this.layer0.ColumnDefinitions.Add(this.column2CloneForLayer0);
            // Add the cloned column to layer 1, but only if pane 1 is docked:
            if (this.pane1Button.Visibility == Visibility.Collapsed)
            {
                this.layer1.ColumnDefinitions.Add(this.column2CloneForLayer1);
            }
        }
    }

    // Undocks a pane, which reveals the corresponding pane button
    public void UndockPane(int paneNumber)
    {
        if (paneNumber == 1)
        {
            this.layer1.Visibility = Visibility.Collapsed;
            this.pane1Button.Visibility = Visibility.Visible;
            this.pane1PinImage.Source = new BitmapImage(new Uri("pinHorizontal.gif", UriKind.Relative));

            // Remove the cloned columns from layers 0 and 1:
            this.layer0.ColumnDefinitions.Remove(this.column1CloneForLayer0);
            // This won't always be present, but Remove silently ignores bad columns:
            this.layer1.ColumnDefinitions.Remove(this.column2CloneForLayer1);
        }
        else if (paneNumber == 2)
        {
            this.layer2.Visibility = Visibility.Collapsed;
            this.pane2Button.Visibility = Visibility.Visible;
            this.pane2PinImage.Source = new BitmapImage(new Uri("pinHorizontal.gif", UriKind.Relative));

            // Remove the cloned columns from layers 0 and 1:
            this.layer0.ColumnDefinitions.Remove(this.column2CloneForLayer0);
            // This won't always be present, but Remove silently ignores bad columns:
            this.layer1.ColumnDefinitions.Remove(this.column2CloneForLayer1);
        }
    }
}