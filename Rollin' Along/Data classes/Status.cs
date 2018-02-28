using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rollin__Along.Data_classes
{
    public partial class Status
    {
        public string Ime { get; set; }
        public int ID { get; set; }
        public override string ToString()
        {
            return ID + " - " + Ime;
        }
    }
}
