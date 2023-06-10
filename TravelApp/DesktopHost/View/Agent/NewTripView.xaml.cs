using System;
using System.Collections.Generic;
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
using TravelApp.DesktopHost.ViewModel.Component.Agent;

namespace TravelApp.DesktopHost.View.Agent
{
    /// <summary>
    /// Interaction logic for NewTripView.xaml
    /// </summary>
    public partial class NewTripView : UserControl
    {
        public NewTripView()
        {
            InitializeComponent();
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

        private void TextBox_PreviewTextInputPrice(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Check if the new text length exceeds the maximum character count
            if (textBox.Text.Length + e.Text.Length > 9)
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

        private void TextBox_PreviewDateTextInput(object sender, TextCompositionEventArgs e)
        {
            DatePicker textBox = (DatePicker)sender;

            // Check if the new text length exceeds the maximum character count
            if (textBox.Text.Length + e.Text.Length > 10)
            {
                e.Handled = true; // Prevent the input from being added to the TextBox
            }
        }

        private void TextBox_NameLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            NewTripViewModel viewModel = (NewTripViewModel)DataContext;
            if (viewModel == null) return;
            if (!viewModel.ValidationViewModel.IsNameValid(textBox.Text))
            {
                textBox.BorderBrush = Brushes.Red;
            }
            else
            {
                textBox.BorderBrush = Brushes.Gray;
            }
            viewModel.Name = textBox.Text;
        }

        private void TextBox_StartLocationLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            NewTripViewModel viewModel = (NewTripViewModel)DataContext;
            if (viewModel == null) return;
            if (!viewModel.ValidationViewModel.IsSurnameValid(textBox.Text))
            {
                textBox.BorderBrush = Brushes.Red;
            }
            else
            {
                textBox.BorderBrush = Brushes.Gray;
            }
            viewModel.StartLocation = textBox.Text;
        }

        private void TextBox_EndLocationLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            NewTripViewModel viewModel = (NewTripViewModel)DataContext;
            if (viewModel == null) return;
            if (!viewModel.ValidationViewModel.IsAddressValid(textBox.Text))
            {
                textBox.BorderBrush = Brushes.Red;
            }
            else
            {
                textBox.BorderBrush = Brushes.Gray;
            }
            viewModel.EndLocation = textBox.Text;
        }

        private void TextBox_PriceLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            NewTripViewModel viewModel = (NewTripViewModel)DataContext;
            if (viewModel == null) return;
            if (!viewModel.ValidationViewModel.IsPriceValid(textBox.Text))
            {
                textBox.BorderBrush = Brushes.Red;
            }
            else
            {
                textBox.BorderBrush = Brushes.Gray;
            }
            viewModel.Price = textBox.Text;
        }

        private void TextBox_DescriptionLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            NewTripViewModel viewModel = (NewTripViewModel)DataContext;
            if (viewModel == null) return;
            if (!viewModel.ValidationViewModel.IsDescriptionValid(textBox.Text))
            {
                textBox.BorderBrush = Brushes.Red;
            }
            else
            {
                textBox.BorderBrush = Brushes.Gray;
            }
            viewModel.Description = textBox.Text;
        }

        private void TextBox_StartDateLostFocus(object sender, RoutedEventArgs e)
        {
            DatePicker textBox = (DatePicker)sender;
            NewTripViewModel viewModel = (NewTripViewModel)DataContext;
            if (viewModel == null) return;
            if (!viewModel.ValidationViewModel.IsStartDateValid(textBox.Text))
            {
                textBox.BorderBrush = Brushes.Red;
            }
            else
            {
                textBox.BorderBrush = Brushes.Gray;
            }
            viewModel.StartDate = textBox.Text;
        }

        private void TextBox_EndDateLostFocus(object sender, RoutedEventArgs e)
        {
            DatePicker textBox = (DatePicker)sender;
            NewTripViewModel viewModel = (NewTripViewModel)DataContext;
            if (viewModel == null) return;
            if (!viewModel.ValidationViewModel.IsEndDateValid(textBox.Text))
            {
                textBox.BorderBrush = Brushes.Red;
            }
            else
            {
                textBox.BorderBrush = Brushes.Gray;
            }
            viewModel.EndDate = textBox.Text;
        }

        private void Attractions_GotFocus(object sender, RoutedEventArgs e)
        {
            NewTripViewModel viewModel = (NewTripViewModel)DataContext;
            if (viewModel == null) return;
            viewModel.Attractions.IsDropDownOpen = true;
        }

        private void Accomodations_GotFocus(object sender, RoutedEventArgs e)
        {
            NewTripViewModel viewModel = (NewTripViewModel)DataContext;
            if (viewModel == null) return;
            viewModel.Accomodations.IsDropDownOpen = true;
        }

        private void Restaurants_GotFocus(object sender, RoutedEventArgs e)
        {
            NewTripViewModel viewModel = (NewTripViewModel)DataContext;
            if (viewModel == null) return;
            viewModel.Restaurants.IsDropDownOpen = true;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;
            double windowHeigth = e.NewSize.Height;

            // Adjust the font size based on the window width
            NewTripViewModel viewModel = (NewTripViewModel)DataContext;
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
    }
}
