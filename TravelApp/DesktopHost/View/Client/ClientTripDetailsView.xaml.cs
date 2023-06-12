using Microsoft.Maps.MapControl.WPF;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
using TravelApp.Core.Model;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Component.Agent;

namespace TravelApp.DesktopHost.View
{
    /// <summary>
    /// Interaction logic for ClientTripDetailsView.xaml
    /// </summary>
    public partial class ClientTripDetailsView : UserControl
    {
        public ClientTripDetailsView()
        {
            InitializeComponent();
            myMap.Center = new Location(45.23898647559673, 19.842916112490993);
            myMap.ZoomLevel = 11;
        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ClientTripDetailsViewModel viewModel = (ClientTripDetailsViewModel)DataContext;
            if (viewModel != null)
                Task.Run(() =>
                {
                    foreach (Attraction a in viewModel.Trip.Attractions)
                    {
                        HandleMarkerRequest(a.Address, "none", a.Name);
                    }
                    foreach (TouristFacility tf in viewModel.Trip.FacilityList)
                    {
                        if (tf.Type.Equals(PlaceType.RESTAURANT))
                            HandleMarkerRequest(tf.Address, "r", tf.Name);
                        else HandleMarkerRequest(tf.Address, "ac", tf.Name);
                    }
                });
        }

        private void PlaceDot(Location location, string type, string name)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                //pin == atrakcija
                Pushpin dot = new Pushpin
                {
                    Location = location
                };
                dot.Background = new SolidColorBrush(Colors.Yellow);
                //zvijezda == restoran
                if (type == "r")
                {
                    dot.Background = new SolidColorBrush(Colors.White);
                    dot.Content = new Path
                    {
                        Data = Geometry.Parse("M 10,10 L 20,30 40,35 20,40 10,60 0,40 10,10 Z"),
                        Fill = new SolidColorBrush(Colors.Red),
                        Stroke = new SolidColorBrush(Colors.Black),
                        StrokeThickness = 1
                    };
                }
                //krug = smjestaj
                else if (type == "ac")
                {
                    dot.Background = new SolidColorBrush(Colors.White);
                    dot.Content = new Rectangle
                    {
                        Width = 20,
                        Height = 20,
                        Fill = new SolidColorBrush(Colors.Blue),
                        Stroke = new SolidColorBrush(Colors.Black),
                        StrokeThickness = 1
                    };
                }
                ToolTip tt = new ToolTip();
                tt.Content = "Name = " + name;
                dot.ToolTip = tt;
                Point p0 = myMap.LocationToViewportPoint(location);
                Location loc = myMap.ViewportPointToLocation(p0);
                MapLayer.SetPosition(dot, loc);
                myMap.Children.Add(dot);
            });
        }

        private void HandleMarkerRequest(string address, string type, string name)
        {
            (double latitude, double longitude) = MapService.GetCoordinates(address);
            PlaceDot(new Location(latitude, longitude), type, name);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;
            double windowHeight = e.NewSize.Height;

            if (DataContext is ClientTripDetailsViewModel viewModel)
            {
                viewModel.ScrollViewHeight = windowHeight - 50;
                if (windowWidth <= 1100)
                {
                    viewModel.FieldsWidth = 270;
                    viewModel.DescriptionWidth = 370;
                    viewModel.TextFontSize = 30;

                }
                else if (windowWidth <= 1300)
                {
                    viewModel.FieldsWidth = 350;
                    viewModel.DescriptionWidth = 450;
                    viewModel.TextFontSize = 35;
                }
                else if (windowWidth <= 1400)
                {
                    viewModel.FieldsWidth = 400;
                    viewModel.DescriptionWidth = 500;
                    viewModel.TextFontSize = 46;
                }
                else
                {
                    viewModel.FieldsWidth = 500;
                    viewModel.DescriptionWidth = 600;
                    viewModel.TextFontSize = 50;
                }

                if (windowWidth <= 930) { viewModel.TableWidth = 600;}
                else if (windowWidth <= 990) { viewModel.TableWidth = 650; }
                else if (windowWidth <= 1200) { viewModel.TableWidth = 700; }
                else if (windowWidth <= 1400) { viewModel.TableWidth = 900; }
                else { viewModel.TableWidth = 1075; }
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            ClientTripDetailsViewModel viewModel = (ClientTripDetailsViewModel)DataContext;
            Button button = sender as Button;
            viewModel.Trips.Execute(this);

        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            string url = e.Uri.AbsoluteUri;
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };

            Process.Start(psi);
            e.Handled = true;
        }

        private void HorizontalScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            // Pass the mouse wheel event to the parent vertical scroll viewer
            VerticalScrollViewer.RaiseEvent(new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
            {
                RoutedEvent = UIElement.MouseWheelEvent,
                Source = VerticalScrollViewer
            });
            e.Handled = true; // Prevent the smaller scroll viewer from handling the event
        }
    }
}
