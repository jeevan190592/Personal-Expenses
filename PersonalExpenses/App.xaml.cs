using PersonalExpenses.classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace PersonalExpenses
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    { 
        public static ObservableCollection<Expense> _expenses;
        public static ObservableCollection<TotalAmount> _DatesTotalAmount;
        public static ObservableCollection<string> _uniqueDates;
        Random rnd = new Random(Guid.NewGuid().GetHashCode());
        public static List<string> _categories = new List<string> { "food","clothes","car" };
        public App()
        {

        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //get the data from storage 
         _expenses= MyStorage.ReadXML<ObservableCollection<Expense>>("Expenses.xml");
            
             if(_expenses==null)
            {
                _expenses = new ObservableCollection<Expense>(); 
               
               // _expenses = Generateexpenses(20);
            }
            ObservableCollection<string> uniqueDates = new ObservableCollection<string>();
            foreach (Expense ex in _expenses)
            {
                if(uniqueDates.IndexOf(ex.Datetime) < 0)
                {
                    uniqueDates.Add(ex.Datetime);
                }
            }

            ObservableCollection<TotalAmount> amountList = new ObservableCollection<TotalAmount>(); ;

            for (int i = 0; i < uniqueDates.Count(); i++)
            {
                //MessageBox.Show("i = " + i);
                double toAm = 0.0;
                for(int j = 0; j < _expenses.Count(); j++)
                {
                    //MessageBox.Show(j + " Vakue " + _expenses[j].Datetime.ToString());
                    //MessageBox.Show(i + " Value " + uniqueDates[i]);
                    if (uniqueDates[i] == _expenses[j].Datetime.ToString())
                    {
                        toAm += _expenses[j].Amount;
                    }
                }
                amountList.Add(new TotalAmount { CurrentDate = uniqueDates[i], Amount = toAm });
            }
            _uniqueDates = uniqueDates;
            _DatesTotalAmount = amountList;
        }

        //private ObservableCollection<Expense> Generateexpenses(int count)
        //{
        //    List<string> title = new List<string> { "In h&m", "In kauland", "in garage" };
        //    List<string> amount = new List<string> { "20", "30", "40" };

          
        //    var lst = new ObservableCollection<Expense>();
        //    for (int i = 1; i < count; i++)
        //    {
        //        int Tno = rnd.Next(title.Count);
        //        int Ano = rnd.Next(amount.Count);
        //        var cat = Tno > 1 ? "food" : "clothes";

        //        lst.Add(new Expense { Title = title[Tno], Category=cat});
        //    }
        //    return lst;
        //}

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            MyStorage.WriteXml<ObservableCollection<Expense>>(_expenses, "Expenses.xml");
        }
    }

}
