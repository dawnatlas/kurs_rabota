using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel
{
    class BankViewModel
    {
        public ObservableCollection<Bank> ListBank { get; set; } = new ObservableCollection<Bank>();

        public BankViewModel()
        {
            this.ListBank.Add(
                new Bank
                {
                    Id = 1,
                    NameFull = "Публичное акционерное общество «Сбербанк России»",
                    NameShort = "ПАО Сбербанк",
                    Inn = "7707083893",
                    Bik = "044525225",
                    CorAccount = "30101810400000000225",
                    Account = "30301810800006003800",
                    City = "Москва"
                });
            this.ListBank.Add(
    new Bank
    {
        Id = 2,
        NameFull = "Акционерное общество «Тинькофф Банк»",
        NameShort = "АО «Тинькофф Банк»",
        Inn = "7710140679",
        Bik = "044525974",
        CorAccount = "30101810145250000974",
        Account = "30232810100000000004",
        City = "Москва"
    });
this.ListBank.Add(
new Bank
            {
                Id = 3,
                NameFull = "Публичное акционерное общество коммерческий банк «Центр-инвест»",
                NameShort = "ПАО КБ «Центр-инвест»",
                Inn = "6163011391",
                Bik = "046015762",
                CorAccount = "30101810100000000762",
                Account = "30109156100000000269",
                City = "Ростов-на-Дону"
            });
        }
        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListBank)
            {
                if (max < r.Id)
                {
                    max = r.Id;
                };
            }
            return max;
        }
    }
}
