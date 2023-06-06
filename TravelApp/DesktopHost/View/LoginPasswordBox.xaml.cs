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
    /// Interaction logic for LoginPasswordBox.xaml
    /// </summary>
    public partial class LoginPasswordBox : UserControl
    {
        private bool _isPasswordChanging;

        private void TextBox_PreviewTextInputPassword(object sender, TextCompositionEventArgs e)
        {
            PasswordBox textBox = (PasswordBox)sender;

            // Check if the new text length exceeds the maximum character count
            if (textBox.Password.Length + e.Text.Length > 40)
            {
                e.Handled = true; // Prevent the input from being added to the TextBox
            }
        }

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(LoginPasswordBox),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    PasswordPropertyChanged, null, false, UpdateSourceTrigger.PropertyChanged));


        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public LoginPasswordBox()
        {
            InitializeComponent();
        }

        private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LoginPasswordBox passwordBox)
            {
                passwordBox.UpdatePassword();
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _isPasswordChanging = true;
            Password = passwordBox.Password;
            _isPasswordChanging = false;
        }

        private void UpdatePassword()
        {
            if (!_isPasswordChanging)
            {
                passwordBox.Password = Password;
            }
        }
    }
}
