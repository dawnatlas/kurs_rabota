using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Bank
    {
        public int Id { get; set; }
        public string NameFull { get; set; }
        public string NameShort { get; set; }
        public string Inn { get; set; }
        public string Bik { get; set; }
        public string CorAccount { get; set; }
        public string Account { get; set; }
        public string City { get; set; }
        public Bank() { }
        public Bank(int id, string NameFull, string NameShort,
            string Inn, string Bik, string CorAccount, string Account, string City)
        {
            this.Id = id;
            this.NameFull = NameFull;
            this.NameShort = NameShort;
            this.Inn = Inn;
            this.Bik = Bik;
            this.CorAccount = CorAccount;
            this.Account = Account;
            this.City = City;
        }
        public Bank ShallowCopy()
        {
            return (Bank)this.MemberwiseClone();
        }
    }
}
