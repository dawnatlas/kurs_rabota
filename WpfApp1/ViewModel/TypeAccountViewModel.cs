using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel
{
    class TypeAccountViewModel
    {
        public ObservableCollection<TypeAccount> ListTypeAccount { get; set; } = new ObservableCollection<TypeAccount>();

        public TypeAccountViewModel()
        {
            this.ListTypeAccount.Add(
                new TypeAccount
                {
                    Id = 1,
                    TypeAccount_ = "брокерский"

                });

            this.ListTypeAccount.Add(
            new TypeAccount
            {
                Id = 2,
                TypeAccount_ = "дилерский"

            });

            this.ListTypeAccount.Add(
            new TypeAccount
            {
              Id = 3,
              TypeAccount_ = "управления"
            });

        }
        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListTypeAccount)
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
