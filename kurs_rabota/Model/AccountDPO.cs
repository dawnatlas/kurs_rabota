using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;

namespace WpfApp1.Model
{
    class AccountDPO
    {
        public int Id { get; set; }
        public string a_Type { get; set; }
        public string a_Bank { get; set; }
        public string a_Agreement { get; set; }
        public string Account_ { get; set; }

        public AccountDPO() { }
        public AccountDPO(int id, string a_Type, string a_Bank,
            string a_Agreement, string Account_)
        {
            this.Id = id;
            this.a_Type = a_Type;
            this.a_Bank = a_Bank;
            this.a_Agreement = a_Agreement;
            this.Account_ = Account_;
        }
        public AccountDPO CopyFromAccount(Account account)
        {
            AccountDPO acDPO = new AccountDPO();
            TypeAccountViewModel vmTypeAccount = new TypeAccountViewModel();
            BankViewModel vmBank = new BankViewModel();
            AgreementViewModel vmAgreement = new AgreementViewModel();
            string bank = string.Empty;
            string TA = string.Empty;
            string agr = string.Empty;
            foreach (var t in vmTypeAccount.ListTypeAccount)
            {
                if (t.Id == account.Id)
                {
                    TA = t.TypeAccount_;
                    break;
                }
            }
            foreach (var b in vmBank.ListBank)
            {
                if (b.Id == account.Id)
                {
                    bank = b.NameShort;
                    break;
                }
            }
            foreach (var a in vmAgreement.ListAgreement)
            {
                if (a.Id == account.Id)
                {
                    agr = a.Number;
                    break;
                }
            }
            if (TA != string.Empty && bank != string.Empty && agr != string.Empty)
            {
                acDPO.Id = account.Id;
                acDPO.a_Type = TA;
                acDPO.a_Bank = bank;
                acDPO.a_Agreement = agr;
                acDPO.Account_ = account.Account_;
            }
            return acDPO;
        }
        public AccountDPO ShallowCopy()
        {
            return (AccountDPO)this.MemberwiseClone();
        }
    }
}
