using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Agreement
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime DataOpen { get; set; }
        public DateTime DataClouse { get; set; }
        public string Note { get; set; }
      
        public Agreement() { }
        public Agreement(int id, string Number, DateTime DataOpen,
            DateTime DataClouse, string Note)
        {
            this.Id = id;
            this.Number = Number;
            this.DataOpen = DataOpen;
            this.DataClouse = DataClouse;
            this.Note = Note;
        }
        public Agreement ShallowCopy()
        {
            return (Agreement)this.MemberwiseClone();
        }
    }
}
