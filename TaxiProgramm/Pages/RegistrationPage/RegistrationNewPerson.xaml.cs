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
using System.IO;
using Microsoft.Win32;

namespace TaxiProgramm.Pages.RegistrationPage
{
    /// <summary>
    /// Логика взаимодействия для RegistrationNewPerson.xaml
    /// </summary>
    public partial class RegistrationNewPerson : Page
    {
        public RegistrationNewPerson()
        {
            InitializeComponent();
        }
        TaxiProgEntities entities = new TaxiProgEntities();
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FirstName.Text == "" && SecondName.Text == "" && LastName.Text == "" && Gender.Text == "" && Phone.Text == "" && Email.Text == "" && Password.Text == "")
                {
                    MessageBox.Show("", "");
                }
                bool TrueEmail = false;

                for (int i = 0; i < Email.Text.Length; i++)
                {
                    if (Email.Text[i] == '@')
                    {
                        TrueEmail = true;
                    }
                }
                if (TrueEmail == false)
                {
                    MessageBox.Show("Вы ввели некорректный Email", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                int Symbol1 = 0;
                int Symbol2 = 0;
                int Symbol3 = 0;
                int Symbol4 = 0;
                int Number = 0;
                for (int i = 0; i < Password.Text.Length; i++)
                {
                   

                    if (Password.Text[i] == '!')
                    {
                        Symbol1++;
                    }
                    if (Password.Text[i] == '@')
                    {
                        Symbol2++;
                    }
                    if (Password.Text[i] == '?')
                    {
                        Symbol3++;
                    }
                    if (Password.Text[i] == '%')
                    {
                        Symbol4++;
                    }
                    if (Password.Text[i] >= 0 && Password.Text[i] <= 9)
                    {
                        Number++;
                    }
                }
                if (Symbol1 < 1 && Symbol2 < 1 && Symbol3 < 1 && Symbol4 < 1 && Number < 1 && Password.Text.Length < 8)
                {
                    MessageBox.Show("", "");
                    return;
                }
                    



                if (ClientChek.IsChecked == true)
                {
                    Client NewClient = new Client
                    { 
                    
                    
                    };
                    entities.Clients.Add(NewClient);
                    entities.SaveChanges();
                }
                if (WorkerCheck.IsChecked == true)
                {
                    TaxiDriver NewDriver = new TaxiDriver
                    {


                    };
                    entities.TaxiDrivers.Add(NewDriver);
                    entities.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            
        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pages.StartPage());
        }

        byte[] imageData = null; //начало конвертации
        private void DownloadPhoto_Click(object sender, RoutedEventArgs e)
        {
            //диалоговое окно для открытия файлов
            string iFile = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (dialog.ShowDialog() == true )
            {
                iFile = dialog.FileName;
            }
            //конвертация изображения для бд
            FileInfo fInfo = new FileInfo(iFile);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            imageData = br.ReadBytes((int)numBytes);
            //для отображения изображения
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(iFile);
            image.EndInit();
            Photo.Source = image;
        }
    }
}
