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
using TravelApp.DesktopHost.ViewModel;

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
