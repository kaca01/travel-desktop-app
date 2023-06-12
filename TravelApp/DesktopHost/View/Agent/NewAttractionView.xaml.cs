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
                textBox.BorderBrush = Brushes.Gray;
            }
            viewModel.Description = textBox.Text;
        }

        private void TextBox_AddressLostFocus(object sender, RoutedEventArgs e)
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
                textBox.BorderBrush = Brushes.Gray;
            }
            viewModel.Address = textBox.Text;
        }

        private void TextBox_PreviewTextInputAddress(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Check if the new text length exceeds the maximum character count
            if (textBox.Text.Length + e.Text.Length > 35)
            {
                e.Handled = true; // Prevent the input from being added to the TextBox
            }
        }

    }
}
