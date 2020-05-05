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


namespace TaxiProgramm.Pages.ClientPage
{
    /// <summary>
    /// Логика взаимодействия для ClientAuthorization.xaml
    /// </summary>
    public partial class ClientAuthorization : Page
    {
        public ClientAuthorization()
        {
            InitializeComponent();
        }
        int FalsAuthorization = 0;
        //int TrueLogin = 0;
        TaxiProgEntities entities = new TaxiProgEntities();
        private void authorization_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LogiinText.Text == "" && PasswordText.Text == "")
                {
                    MessageBox.Show("Вы ввели логин или пароль не правильно", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Warning);
                    FalsAuthorization++;
                    return;
                }

                var user = entities.Clients.AsNoTracking().FirstOrDefault(c => c.PhoneNumber == LogiinText.Text.Trim() && c.Password == PasswordText.Text.Trim());

                if (user == null)
                {
                    MessageBox.Show("Вы ввели логин или пароль не правильно", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else
                {
                    NavigationService.Navigate(new pages.StartPage());
                }

                if (FalsAuthorization == 3)
                {

                }
                if (FalsAuthorization == 4)
                {

                }
                if (FalsAuthorization == 5)
                {
                    MessageBox.Show("Вы ввели логин или пароль не правильно слишком много раз","Ошибка авторизации",MessageBoxButton.OK,MessageBoxImage.Warning);
                    Application.Current.Shutdown();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                FalsAuthorization++;
            }
        }

        private void registartion_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.RegistrationPage.RegistrationNewPerson());
        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pages.StartPage());
        }
    }
}
