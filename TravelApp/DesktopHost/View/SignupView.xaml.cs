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

namespace TravelApp.DesktopHost.View
{
    /// <summary>
    /// Interaction logic for SignupView.xaml
    /// </summary>
    public partial class SignupView : UserControl
    {
        public SignupView()
        {
            InitializeComponent();
        }

        private void TextBox_NameLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            SignupViewModel viewModel = (SignupViewModel)DataContext;
            if (viewModel == null)  return;
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

        private void TextBox_SurnameLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            SignupViewModel viewModel = (SignupViewModel)DataContext;
            if (viewModel == null) return;
            if (!viewModel.ValidationViewModel.IsSurnameValid(textBox.Text))
            {
                textBox.BorderBrush = Brushes.Red;
            }
            else
            {
                textBox.BorderBrush = Brushes.Gray;
            }
            viewModel.Surname = textBox.Text;
        }

        private void TextBox_EmailLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            SignupViewModel viewModel = (SignupViewModel)DataContext;
            if (viewModel == null) return;
            if (!viewModel.ValidationViewModel.IsEmailValid(textBox.Text))
            {
                textBox.BorderBrush = Brushes.Red;
            }
            else
            {
                textBox.BorderBrush = Brushes.Gray;
            }
            viewModel.Email = textBox.Text;
        }

        private void TextBox_PasswordLostFocus(object sender, RoutedEventArgs e)
        {
            BindablePasswordBox textBox = (BindablePasswordBox)sender;
            SignupViewModel viewModel = (SignupViewModel)DataContext;
            if (viewModel == null) return;
            if (!viewModel.ValidationViewModel.IsPasswordValid(textBox.Password, viewModel.PasswordAgain))
            {
                textBox.BorderBrush = Brushes.Red;
            }
            else
            {
                textBox.BorderBrush = Brushes.Gray;
            }
        }

        private void TextBox_PasswordAgainLostFocus(object sender, RoutedEventArgs e)
        {
            BindablePasswordBox textBox = (BindablePasswordBox)sender;
            SignupViewModel viewModel = (SignupViewModel)DataContext;
            if (viewModel == null) return;
            if (!viewModel.ValidationViewModel.IsPasswordAgainValid(textBox.Password, viewModel.Password))
            {
                textBox.BorderBrush = Brushes.Red;
            }
            else
            {
                textBox.BorderBrush = Brushes.Gray;
            }
        }

        private void TextBox_PreviewTextInputEmail(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Check if the new text length exceeds the maximum character count
            if (textBox.Text.Length + e.Text.Length > 60)
            {
                e.Handled = true; // Prevent the input from being added to the TextBox
            }
        }

        private void TextBox_PreviewTextInputName(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Check if the new text length exceeds the maximum character count
            if (textBox.Text.Length + e.Text.Length > 60)
            {
                e.Handled = true; // Prevent the input from being added to the TextBox
            }
        }

        private void TextBox_PreviewTextInputSurname(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Check if the new text length exceeds the maximum character count
            if (textBox.Text.Length + e.Text.Length > 60)
            {
                e.Handled = true; // Prevent the input from being added to the TextBox
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;
            double windowHeigth = e.NewSize.Height;

            // Adjust the font size based on the window width
            SignupViewModel viewModel = (SignupViewModel)DataContext;
            if (windowWidth <= 1200 || windowHeigth <= 700)
            {
                viewModel.TextFontSize = 40;
                viewModel.Width = 300;
                viewModel.LoginFontSize = 14;
            }
            else
            {
                viewModel.TextFontSize = 60;
                viewModel.Width = 439;
                viewModel.LoginFontSize = 18;
            }
        }
    }
}
