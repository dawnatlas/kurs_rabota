﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Helper
{
    class FindBank
    {
        public int id;
        public FindBank(int id)
        {
            this.id = id;
        }
        public bool BankPredicate(Bank bank)
        {
            return bank.Id == id;
        }
    }
}
