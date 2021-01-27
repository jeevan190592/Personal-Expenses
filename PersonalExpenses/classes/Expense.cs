using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PersonalExpenses.classes
{
    public class Expense
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public int Amount { get; set; }
        public string Datetime { get; set; }

        [XmlIgnoreAttribute]
        public string expe { get { return $" {Title} {Amount}"; } }
    }
}
