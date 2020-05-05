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

namespace TaxiProgramm.pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void ClientAuthorization_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ClientPage.ClientAuthorization());
        }

        private void WorkerAuthorization_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.WorkerPage.WorkerAuthorization());
        }
    }
}
