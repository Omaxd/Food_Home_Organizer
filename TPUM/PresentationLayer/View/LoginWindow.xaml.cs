using PresentationLayer.Interfaces;
using PresentationLayer.StaticResources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PresentationLayer.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, ISecurePassword
    {
        public bool isOpen = true;
        public LoginWindow()
        {
            InitializeComponent();
        }

        public string Login
        {
            get
            {
                return tbLogin.Text;
            }
        }

        public System.Security.SecureString Password
        {
            get
            {
                return pbPassword.SecurePassword;
            }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (ApplicationInfo.User != null)
                Close();
        }
    }
}
