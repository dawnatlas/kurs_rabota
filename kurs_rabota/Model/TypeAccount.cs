using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class TypeAccount
    {
        public int Id { get; set; }
        public string TypeAccount_ { get; set; }


        public TypeAccount() { }
        public TypeAccount(int id, string TypeAccount_)
        {
            this.Id = id;
            this.TypeAccount_ = TypeAccount_;

        }
        public TypeAccount ShallowCopy()
        {
            return (TypeAccount)this.MemberwiseClone();
        }
    }
}
