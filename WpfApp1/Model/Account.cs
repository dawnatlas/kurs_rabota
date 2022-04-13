using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;

namespace WpfApp1.Model
{
    class Account
    {
        public int Id { get; set; }
        public int TypeID { get; set; }
        public int BankID { get; set; }
        public int AgreementID { get; set; }
        public string Account_ { get; set; }

        public Account() { }
        public Account(int id, int TypeID, int BankID,
            int AgreementID, string Account_)
        {
            this.Id = id;
            this.TypeID = TypeID;
            this.BankID = BankID;
            this.AgreementID = AgreementID;
            this.Account_ = Account_;
        }

        public Account CopyFromAccountDPO(AccountDPO a)
        {
           TypeAccountViewModel vmTypeAccount = new TypeAccountViewModel();
           BankViewModel vmBank = new BankViewModel();
           AgreementViewModel vmAgreement = new AgreementViewModel();
            int TypeAccountId = 0;
            int BankId = 0;
            int AgreementId = 0;
            foreach (var t in vmTypeAccount.ListTypeAccount)
            {
                if (t.TypeAccount_ == a.a_Type)
                {
                    TypeAccountId = t.Id;
                    break;
                }
            }
            foreach (var b in vmBank.ListBank)
            {
                if (b.NameShort == a.a_Bank)
                {
                    BankId = b.Id;
                    break;
                }
            }
            foreach (var a_agr in vmAgreement.ListAgreement)
            {
                if (a_agr.Number == a.a_Agreement)
                {
                    AgreementId = a_agr.Id;
                    break;
                }
            }
            if (TypeAccountId != 0 && BankId != 0 && AgreementId != 0)
            {
                this.Id = a.Id;
                this.TypeID = TypeAccountId;
                this.BankID = BankID;
                this.AgreementID = AgreementID;
                this.Account_ = Account_;
            }
            return this;
        }
    }
}
