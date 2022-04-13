using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Helper
{
    class FindAgreement
    {
        public int id;
        public FindAgreement(int id)
        {
            this.id = id;
        }
        public bool AgreementPredicate(Agreement agr)
        {
            return agr.Id == id;
        }
    }
}
