using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StormBoard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create Object
            var n = new Note("New Item");

            // Assign and apply the resource template
            n.Template = this.Resources["NoteTemplate"] as ControlTemplate;
            n.ApplyTemplate();

            // Add the object to the canvas
            workArea.Children.Add(n);

            // Set the location (Default of 0x0)
            Canvas.SetLeft(n, 0);
            Canvas.SetTop(n, 0);

            // Set Panel Index
            Panel.SetZIndex(n, 1);

            // Manually update the layout of the new item
            n.UpdateLayout();

            e.Handled = true;
        }

        private void TabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = new TabItem();
            

            // Create a reference to the "new tab" tab
            var newItemTab = tabControl.Items.GetItemAt(tabControl.Items.Count - 1);
            // Remove the "new tab" tab
            tabControl.Items.RemoveAt(tabControl.Items.Count - 1);

            // Add the new tab in the list
            tabControl.Items.Add(item);

            // Add the "new tab" tab back in
            tabControl.Items.Add(newItemTab);
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var control = sender as TabControl;
            var selectedTab = control.SelectedItem as TabItem;

            if (selectedTab != null && selectedTab.Header.Equals("+"))
            {
                // Create a reference to the "new tab" tab
                var newItemTab = control.Items.GetItemAt(tabControl.Items.Count - 1);
                // Remove the "new tab" tab
                control.Items.RemoveAt(control.Items.Count - 1);

                // Add the new tab to the list
                var item = new TabItem();
                item.Header = "My New Tab";
                
                control.Items.Add(item);

                // Add the "new tab" tab back in
                control.Items.Add(newItemTab);
                control.SelectedItem = item;
            }
        }

        private Border CreateTabItemContent()
        {
            // Create the border
            var b = new Border();
            b.BorderBrush = new SolidColorBrush(Colors.Black);
            b.BorderThickness = new Thickness(2);
            b.Background = new SolidColorBrush(Colors.White);

            // Create the canvas that goes in the border
            var c = new Canvas();
            
        }
    }
}
