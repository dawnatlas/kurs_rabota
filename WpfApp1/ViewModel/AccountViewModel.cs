using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel
{
    class AccountViewModel
    {
        public ObservableCollection<Account> ListAccount { get; set; } = new ObservableCollection<Account>();

        public AccountViewModel()
        {
            this.ListAccount.Add(
                new Account
                {
                    Id = 1,
                    TypeID = 2,
                    BankID = 2,
                    AgreementID = 2,
                    Account_ = "253017558032693058706"

                });
            this.ListAccount.Add(
    new Account
    {
        Id = 2,
        TypeID = 1,
        BankID = 3,
        AgreementID = 1,
        Account_ = "032801450390665831795"

    });
this.ListAccount.Add(
new Account
            {
                Id = 3,
                TypeID = 2,
                BankID = 1,
                AgreementID = 3,
                Account_ = "779563396555098600533"

            });
        }
        public int MaxId()
        {
            int max = 0;
            foreach (var a in this.ListAccount)
            {
                if (max < a.Id)
                {
                    max = a.Id;
                };
            }
            return max;
        }
    }
}
