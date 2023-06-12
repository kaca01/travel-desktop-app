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
using static TravelApp.Core.Model.BingMapsApiResponse.ResourceSet.Resource;

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
            mapError.Visibility = Visibility.Collapsed;
        }

        private void PlaceDot(Location location, string text)
        {
            Pushpin dot = new Pushpin
            {
                Location = location
            };
            ToolTip tt = new ToolTip();
            tt.Content = "Address = " + text;
            dot.ToolTip = tt;
            Point p0 = myMap.LocationToViewportPoint(location);
            Location loc = myMap.ViewportPointToLocation(p0);
            MapLayer.SetPosition(dot, loc);
            dot.MouseLeftButtonDown += Marker_MouseDown;
            dot.MouseLeftButtonUp += Marker_MouseUp;
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

            HandleMarkerRequest(textBox, viewModel);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            NewAttractionViewModel viewModel = (NewAttractionViewModel)DataContext;

            if (e.Key == Key.Enter)
            {
                HandleMarkerRequest(textBox, viewModel);
            }
        }

        private void HandleMarkerRequest(TextBox textBox, NewAttractionViewModel viewModel)
        {
            myMap.Children.Clear();  //obrisi prethodni marker bilo da se desila greska bilo da je nov korektan unos
            if (viewModel == null) return;
            if (!viewModel.ValidationViewModel.IsAddressValid(textBox.Text))
            {
                textBox.BorderBrush = Brushes.Red;
            }
            else
            {
                textBox.BorderBrush = Brushes.Gray;
                (double latitude, double longitude) = MapService.GetCoordinates(textBox.Text);
                this.PlaceDot(new Location(latitude, longitude), textBox.Text);
                if (myMap.Children.Count == 0)
                    mapError.Visibility = Visibility.Visible;
                else mapError.Visibility = Visibility.Collapsed;
            }
            viewModel.Address = textBox.Text;
        }

        Vector _mouseToMarker;
        private bool isDragging = false;
        private Pushpin selectedMarker { get; set; }

        void Marker_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            selectedMarker = sender as Pushpin;
            isDragging = true;
            _mouseToMarker = Point.Subtract(
              myMap.LocationToViewportPoint(selectedMarker.Location),
              e.GetPosition(myMap));
        }

        async void Marker_MouseUp(object sender, MouseButtonEventArgs e)
        {
            selectedMarker = sender as Pushpin;
            string address = await MapService.ReverseGeocodeAsync(selectedMarker.Location);
            await Task.Delay(350);
            NewAttractionViewModel viewModel = (NewAttractionViewModel)DataContext;
            if (address != null)
            {
                viewModel.Address = address;
                viewModel.ValidationViewModel.IsAddressValid(address);
                selectedMarker.ToolTip = "Address: " + address;
            }
            else
            {
                viewModel.Address = "";
                viewModel.ValidationViewModel.IsAddressValid("");
                mapError.Visibility = Visibility.Visible;
                mapError.Content = "Cannot find corresponding address";
            }
            //todo find new address ftom latitude and longitude
            e.Handled = true;
            selectedMarker = null;
            isDragging = false;
            selectedMarker = null;
        }

        private void Marker_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (isDragging && selectedMarker != null)
                {
                    selectedMarker.Location = myMap.ViewportPointToLocation(
                      Point.Add(e.GetPosition(myMap), _mouseToMarker));
                    e.Handled = true;
                }
            }
        }
    }
}
