using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.ViewModel.Component.Agent;

namespace TravelApp.DesktopHost.View.Agent
{
    /// <summary>
    /// Interaction logic for NewAttractionView.xaml
    /// </summary>
    public partial class NewAttractionView : UserControl
    {
        public NewAttractionView()
        {
            InitializeComponent();
            myMap.Center = new Location(45.23898647559673, 19.842916112490993); 
            myMap.ZoomLevel = 14;
        }

        private void PlaceDot(Location location)
        {
            Ellipse dot = new Ellipse();
            dot.Fill = new SolidColorBrush(Colors.Red);
            double radius = 12.0;
            dot.Width = radius * 2;
            dot.Height = radius * 2;
            ToolTip tt = new ToolTip();
            tt.Content = "Address = " + location;
            dot.ToolTip = tt;
            Point p0 = myMap.LocationToViewportPoint(location);
            Point p1 = new Point(p0.X - radius, p0.Y - radius);
            Location loc = myMap.ViewportPointToLocation(p1);
            MapLayer.SetPosition(dot, loc);
            myMap.Children.Add(dot);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;
            double windowHeigth = e.NewSize.Height;

            // Adjust the font size based on the window width
            NewAttractionViewModel viewModel = (NewAttractionViewModel)DataContext;
            if (windowWidth <= 1200 || windowHeigth <= 700)
            {
                viewModel.TextFontSize = 40;
                viewModel.Width = 300;
            }
            else
            {
                viewModel.TextFontSize = 60;
                viewModel.Width = 439;
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Check if the new text length exceeds the maximum character count
            if (textBox.Text.Length + e.Text.Length > 50)
            {
                e.Handled = true; // Prevent the input from being added to the TextBox
            }
        }

        private void TextBox_PreviewTextInputDescription(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Check if the new text length exceeds the maximum character count
            if (textBox.Text.Length + e.Text.Length > 450)
            {
                e.Handled = true; // Prevent the input from being added to the TextBox
            }
        }

        private void TextBox_NameLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            NewAttractionViewModel viewModel = (NewAttractionViewModel)DataContext;
            if (viewModel == null) return;
            if (!viewModel.ValidationViewModel.IsNameValid(textBox.Text))
            {
                textBox.BorderBrush = Brushes.Red;
            }
            else
            {
                if (e.RoutedEvent == TextBox.TextChangedEvent)
                    textBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4889E6"));
                else
                    textBox.BorderBrush = Brushes.Gray;
            }
            viewModel.Name = textBox.Text;
        }

        private void TextBox_DescriptionLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            NewAttractionViewModel viewModel = (NewAttractionViewModel)DataContext;
            if (viewModel == null) return;
            if (!viewModel.ValidationViewModel.IsDescriptionValid(textBox.Text))
            {
                textBox.BorderBrush = Brushes.Red;
            }
            else
            {
                if (e.RoutedEvent == TextBox.TextChangedEvent)
                    textBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4889E6"));
                else
                    textBox.BorderBrush = Brushes.Gray;
            }
            viewModel.Description = textBox.Text;
        }

        private void TextBox_AddressTextChanged(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            NewAttractionViewModel viewModel = (NewAttractionViewModel)DataContext;
            if (viewModel == null) return;
            if (!viewModel.ValidationViewModel.IsAddressValid(textBox.Text))
            {
                textBox.BorderBrush = Brushes.Red;
            }
            else
            {
                if (e.RoutedEvent == TextBox.TextChangedEvent)
                    textBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4889E6"));
                else
                    textBox.BorderBrush = Brushes.Gray;
            }
            viewModel.Address = textBox.Text;
        }

        private void TextBox_AddressLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            NewAttractionViewModel viewModel = (NewAttractionViewModel)DataContext;
            myMap.Children.Clear();  //obrisi prethodni marker bilo da se desila greska bilo da je nov korektan unos
            if (viewModel == null) return;
            if (!viewModel.ValidationViewModel.IsAddressValid(textBox.Text))
            {
                textBox.BorderBrush = Brushes.Red;
                //ispisi gresku ispod
            }
            else
            {
                textBox.BorderBrush = Brushes.Gray;
                (double latitude, double longitude) = MapService.GetCoordinates(textBox.Text, "AuLWjg9zk0YyNOzdddizNFywS-R5879R6PnSVyiT_7T3X3SOnJe8TKz0PvlBO0c3");
                this.PlaceDot(new Location(latitude, longitude));
            }
            viewModel.Address = textBox.Text;
        }

    }
}
