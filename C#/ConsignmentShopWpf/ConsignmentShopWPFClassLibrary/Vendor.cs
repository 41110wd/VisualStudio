using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopWPFClassLibrary
{
    public class Vendor
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Commission { get; set; } = 0.3;
        public decimal Money { get; set; } = 0;

        public override string ToString()
        {
            return string.Format("{0} {1} - € {2}", FirstName, LastName, Money);
        }
    }
}
