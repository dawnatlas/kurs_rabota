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
    /// Логика взаимодействия для WindowTypeAccount.xaml
    /// </summary>
    public partial class WindowTypeAccount : Window
    {
        TypeAccountViewModel vmTypeAccount = new TypeAccountViewModel();
        public WindowTypeAccount()
        {
            InitializeComponent();
            lvTypeAccount.ItemsSource = vmTypeAccount.ListTypeAccount;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewTypeAccount wnTypeAccount = new WindowNewTypeAccount
            {
                Title = "Новый договор",
                Owner = this
            };
            int maxIdTypeAccount = vmTypeAccount.MaxId() + 1;
            TypeAccount typeAccount = new TypeAccount
            {
                Id = maxIdTypeAccount
            };
            wnTypeAccount.DataContext = typeAccount;
            if (wnTypeAccount.ShowDialog() == true)
            {
                vmTypeAccount.ListTypeAccount.Add(typeAccount);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewTypeAccount wnTypeAccount = new WindowNewTypeAccount
            {
                Title = "Редактирование договора",
                Owner = this
            };
            TypeAccount typeAccount = lvTypeAccount.SelectedItem as TypeAccount;
            if (typeAccount != null)
            {
                TypeAccount tempAgreement = typeAccount.ShallowCopy();
                wnTypeAccount.DataContext = tempAgreement;
                if (wnTypeAccount.ShowDialog() == true)
                {
                    // сохранение данных
                    typeAccount.TypeAccount_ = tempAgreement.TypeAccount_;

                    lvTypeAccount.ItemsSource = null;
                    lvTypeAccount.ItemsSource = vmTypeAccount.ListTypeAccount;
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
            TypeAccount typeAccount = (TypeAccount)lvTypeAccount.SelectedItem;
            if (typeAccount != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по договору: " +

                typeAccount.TypeAccount_, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmTypeAccount.ListTypeAccount.Remove(typeAccount);
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
