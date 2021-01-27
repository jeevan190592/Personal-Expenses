using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PersonalExpenses.classes
{
    public class TotalAmount
    {
        [XmlIgnoreAttribute]
        public string CurrentDate { get; set; }
        [XmlIgnoreAttribute]
        public double Amount { get; set; }
    }
}
