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
    /// Логика взаимодействия для WindowBank.xaml
    /// </summary>
    public partial class WindowBank : Window
    {
        BankViewModel vmBank = new BankViewModel();
        public WindowBank()
        {
            InitializeComponent();
            lvBank.ItemsSource = vmBank.ListBank;

        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewBank wnBank = new WindowNewBank
            {
                Title = "Новый банк",
                Owner = this
            };
            int maxIdBank = vmBank.MaxId() + 1;
            Bank bank = new Bank
            {
                Id = maxIdBank
            };
            wnBank.DataContext = bank;
            if (wnBank.ShowDialog() == true)
            {
                vmBank.ListBank.Add(bank);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewBank wnBank = new WindowNewBank
            {
                Title = "Редактирование банка",
                Owner = this
            };
            Bank bank = lvBank.SelectedItem as Bank;
            if (bank != null)
            {
                Bank tempBang = bank.ShallowCopy();
                wnBank.DataContext = tempBang;
                if (wnBank.ShowDialog() == true)
                {
                    // сохранение данных
                    bank.Account = tempBang.Account;
                    bank.Bik = tempBang.Bik;
                    bank.City = tempBang.City;
                    bank.CorAccount = tempBang.CorAccount;
                    bank.Inn = tempBang.Inn;
                    bank.NameFull = tempBang.NameFull;
                    bank.NameShort = tempBang.NameShort;
                    lvBank.ItemsSource = null;
                    lvBank.ItemsSource = vmBank.ListBank;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать банк для редактирования",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Bank bank = (Bank)lvBank.SelectedItem;
            if (bank != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по банку: " +

                bank.NameShort, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmBank.ListBank.Remove(bank);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать банк для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
