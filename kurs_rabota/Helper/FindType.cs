using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Helper
{

         class FindType
        {
            public int id;
            public FindType(int id)
            {
                this.id = id;
            }
            public bool TypePredicate(TypeAccount type)
            {
                return type.Id == id;
            }
        }
    }

