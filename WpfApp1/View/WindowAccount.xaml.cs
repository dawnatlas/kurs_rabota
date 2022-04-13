using System.Windows;
using WpfApp1.Helper;
using WpfApp1.ViewModel;
using WpfApp1.Model;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using WpfApp1.View;
using System.Linq;
using WpfApp1.Helper;
namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для WindowAccount.xaml
    /// </summary>
    public partial class WindowAccount : Window
    {
        private AccountViewModel vmAccount = MainWindow.vmAccount;
        private TypeAccountViewModel vmType;
        private BankViewModel vmBank;
        private AgreementViewModel vmAgreement;
        private ObservableCollection<AccountDPO> accountDPO;
        private List<TypeAccount> types;
        private List<Bank> banks;
        private List<Agreement> agreements;
        public WindowAccount()
        {
            InitializeComponent();
            vmAccount = new AccountViewModel();
            vmType = new TypeAccountViewModel();
            vmBank = new BankViewModel();
            vmAgreement = new AgreementViewModel();
            types = vmType.ListTypeAccount.ToList();
            banks = vmBank.ListBank.ToList();
            agreements = vmAgreement.ListAgreement.ToList();
            // Формирование данных для отображения сотрудников с должностями
            // на базе коллекции класса ListPerson<Person> 
            accountDPO = new ObservableCollection<AccountDPO>();
            foreach (var ac in vmAccount.ListAccount)
            {
                AccountDPO a = new AccountDPO();
                a = a.CopyFromAccount(ac);
                accountDPO.Add(a);
            }
            lvAccount.ItemsSource = accountDPO;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewAccount wnAccount = new WindowNewAccount
            {
                Title = "Новый счет",
                Owner = this
            };
            // формирование кода нового собрудника
            int maxIdAccount = vmAccount.MaxId() + 1;
            AccountDPO ac = new AccountDPO
            {
                Id = maxIdAccount,
            };
            wnAccount.DataContext = ac;
            wnAccount.TbTypeID.ItemsSource = types;
            wnAccount.TbBankID.ItemsSource = banks;
            wnAccount.TbAgreementID.ItemsSource = agreements;
            if (wnAccount.ShowDialog() == true)
            {
                TypeAccount t = (TypeAccount)wnAccount.TbTypeID.SelectedValue;
                ac.a_Type = t.TypeAccount_;
                Bank b = (Bank)wnAccount.TbBankID.SelectedValue;
                ac.a_Bank = b.NameShort;
                Agreement ag = (Agreement)wnAccount.TbAgreementID.SelectedValue;
                ac.a_Agreement = ag.Number;
                accountDPO.Add(ac);
                // добавление нового сотрудника в коллекцию ListPerson<Person> 
                Account a = new Account();
                a = a.CopyFromAccountDPO(ac);
                vmAccount.ListAccount.Add(a);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewAccount wnAccount = new WindowNewAccount
            {
                Title = "Редактирование данных",
                Owner = this
            };
            AccountDPO acDPO = (AccountDPO)lvAccount.SelectedValue;
            AccountDPO tempacDPO; // временный класс для редактирования
            if (acDPO != null)
            {
                tempacDPO = acDPO.ShallowCopy();
                wnAccount.DataContext = tempacDPO;
                wnAccount.TbTypeID.ItemsSource = types;
                wnAccount.TbTypeID.Text = tempacDPO.a_Type;
                wnAccount.TbBankID.ItemsSource = banks;
                wnAccount.TbBankID.Text = tempacDPO.a_Bank;
                wnAccount.TbAgreementID.ItemsSource = agreements;
                wnAccount.TbAgreementID.Text = tempacDPO.a_Agreement;
                if (wnAccount.ShowDialog() == true)
                {
                    // перенос данных из временного класса в класс отображения данных
                    TypeAccount t = (TypeAccount)wnAccount.TbTypeID.SelectedValue;
                    acDPO.a_Type = t.TypeAccount_;
                    Bank b = (Bank)wnAccount.TbBankID.SelectedValue;
                    acDPO.a_Bank = b.NameShort;
                    Agreement ag = (Agreement)wnAccount.TbAgreementID.SelectedValue;
                    acDPO.a_Agreement = ag.Number;
                    lvAccount.ItemsSource = null;
                    lvAccount.ItemsSource = accountDPO;

                    // перенос данных из класса отображения данных в класс Person
                    FindAccount finder = new FindAccount(acDPO.Id);
                    List<Account> listAccount = vmAccount.ListAccount.ToList();
                    Account a = listAccount.Find(new Predicate<Account>(finder.AccountPredicate)); 
                    a = a.CopyFromAccountDPO(acDPO);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать счет для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            AccountDPO account = (AccountDPO)lvAccount.SelectedItem;
            if (account != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по счету: \n" + account.Id ,

                "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    // удаление данных в списке отображения данных
                    accountDPO.Remove(account);
                    // удаление данных в списке классов ListPerson<Person>
                    Account ac = new Account();
                    ac = ac.CopyFromAccountDPO(account);
                    vmAccount.ListAccount.Remove(ac);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать данные по счету для удаления",

                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
