using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Helper
{
    class FindAccount
    {
        public int id;
        public FindAccount(int id)
        {
            this.id = id;
        }
        public bool AccountPredicate(Account account)
        {
            return account.Id == id;
        }
    }
}
