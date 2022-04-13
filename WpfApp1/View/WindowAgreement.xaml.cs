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
using System.Windows.Shapes;
using WpfApp1.ViewModel;
using WpfApp1.Model;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для WindowAgreement.xaml
    /// </summary>
    public partial class WindowAgreement : Window
    {
        AgreementViewModel vmAgreement = new AgreementViewModel();
        public WindowAgreement()
        {
            InitializeComponent();

            lvAgreement.ItemsSource = vmAgreement.ListAgreement;


        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewAgreement wnAgreement = new WindowNewAgreement
            {
                Title = "Новый договор",
                Owner = this
            };
            int maxIdAgreement = vmAgreement.MaxId()+ 1;
            Agreement agreement = new Agreement
            {
                Id = maxIdAgreement
            };
            wnAgreement.DataContext = agreement;
            if (wnAgreement.ShowDialog() == true)
            {
                vmAgreement.ListAgreement.Add(agreement);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewAgreement wnAgreement = new WindowNewAgreement
            {
                Title = "Редактирование договора",
                Owner = this
            };
            Agreement agreement = lvAgreement.SelectedItem as Agreement;
            if (agreement != null)
            {
                Agreement tempAgreement = agreement.ShallowCopy();
                wnAgreement.DataContext = tempAgreement;
                if (wnAgreement.ShowDialog() == true)
                {
                    // сохранение данных
                    agreement.Number = tempAgreement.Number;
                    agreement.DataOpen = tempAgreement.DataOpen;
                    agreement.DataClouse = tempAgreement.DataClouse;
                    agreement.Note = tempAgreement.Note;
                    lvAgreement.ItemsSource = null;
                    lvAgreement.ItemsSource = vmAgreement.ListAgreement;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать договор для редактирования",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Agreement agreement = (Agreement)lvAgreement.SelectedItem;
            if (agreement != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по договору: " +

                agreement.Number, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmAgreement.ListAgreement.Remove(agreement);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать договор для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
