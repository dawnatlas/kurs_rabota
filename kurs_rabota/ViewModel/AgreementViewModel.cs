using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel
{
    class AgreementViewModel
    {
        public ObservableCollection<Agreement> ListAgreement { get; set; } = new ObservableCollection<Agreement>();

        public AgreementViewModel()
        {
            this.ListAgreement.Add(
                new Agreement
                {
                    Id = 1,
                    Number = "А-005015",
                    DataOpen = new DateTime(2018, 03, 20),
                    DataClouse = new DateTime(2022, 03, 20),
                    Note = "Срок годности карты-4 года"

                });

            this.ListAgreement.Add(
    new Agreement
    {
        Id = 2,
        Number = "Ф-005024",
        DataOpen = new DateTime(2016, 10, 07),
        DataClouse = new DateTime(2026, 10, 07),
        Note = "Срок годности карты-10 лет"

    });
this.ListAgreement.Add(
new Agreement
            {
                Id = 3,
                Number = "К-003118",
                DataOpen = new DateTime(2020, 07, 09),
                DataClouse = new DateTime(2022, 07, 09),
                Note = "Срок годности карты-2 года"

            });
        }
        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListAgreement)
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
