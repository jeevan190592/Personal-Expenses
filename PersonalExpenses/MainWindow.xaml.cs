using PersonalExpenses.classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using System.Diagnostics;
using System.Windows.Interop;

namespace PersonalExpenses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string language;
        bool firstTime = true;

        public MainWindow()
        {
            language = Properties.Settings.Default.language;

            CultureInfo.CurrentCulture = new CultureInfo(language);
            CultureInfo.CurrentUICulture = new CultureInfo(language);

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Properties.Resources.FlowDirection.Contains("ToLeft"))
                FlowDirection = FlowDirection.RightToLeft;
            else
                FlowDirection = FlowDirection.LeftToRight;

            //Lst_expenses.ItemsSource = App._expenses;
            Lst_dates.ItemsSource = App._DatesTotalAmount;
            Lst_totalexpenses.ItemsSource = App._expenses;
            cbx_category.ItemsSource = App._categories;
            

            //calender.SelectedDateFormat = "dd/MM/yyyy";

            displayDate.Text = "";

            var lst = new List<string> { "de Deutsch", "en_English", "ar_عربى" };

            CoBx_language.ItemsSource = lst;

            var itm = (from l in lst where l.Contains(language) select l).FirstOrDefault();
            CoBx_language.SelectedItem = itm;
            selectedTotalAmount.Text = "";
        }

        public Expense exp;
        private void Btn_Add_Expenses(object sender, RoutedEventArgs e)
        {

          //  MessageBox.Show(" successfully Added " + expTitle.Text + "of" + expAmount.Text ) ;
            //MessageBox.Show("VAlue: " + expAmount.Text);
            if (expTitle.Text != "" & expAmount.Text != "" & cbx_category.Text != "" & calender.Text != "")
            {
                exp = new Expense();
                //validation is not true then dont add
                exp.Title = expTitle.Text;
                exp.Amount = int.Parse(expAmount.Text);
                exp.Category = cbx_category.SelectedValue.ToString();
                exp.Datetime = calender.SelectedDate.ToString().Split(' ')[0];
                Lst_expenses.SelectedItem = exp;
            
                App._expenses.Add(exp);
               
                Lst_expenses.ScrollIntoView(exp);

                uniqueDatesUpdate(App._expenses);
                selectedTotalAmount.Text = "";
                MessageBox.Show(" successfully Added " + expTitle.Text + "of" + expAmount.Text);
            }
            else
            {
                MessageBox.Show("Please Provide correct Details and then ADD");
            }
        }

        private void uniqueDatesUpdate(ObservableCollection<Expense> expenses)
        {
            ObservableCollection<string> uniqueDates = new ObservableCollection<string>();
            foreach (Expense ex in App._expenses)
            {
                if (uniqueDates.IndexOf(ex.Datetime) < 0)
                {
                    uniqueDates.Add(ex.Datetime);
                }
            }

            ObservableCollection<TotalAmount> amountList = new ObservableCollection<TotalAmount>(); ;

            for (int i = 0; i < uniqueDates.Count(); i++)
            {
                //MessageBox.Show("i = " + i);
                double toAm = 0.0;
                for (int j = 0; j < App._expenses.Count(); j++)
                {
                    //MessageBox.Show(j + " Vakue " + App._expenses[j].Datetime.ToString());
                    //MessageBox.Show(i + " Value " + uniqueDates[i]);
                    if (uniqueDates[i] == App._expenses[j].Datetime.ToString())
                    {
                        toAm += App._expenses[j].Amount;
                    }
                }
                amountList.Add(new TotalAmount { CurrentDate = uniqueDates[i], Amount = toAm });
            }
            //App._uniqueDates = uniqueDates;
            App._DatesTotalAmount = amountList;

            Lst_dates.ItemsSource = App._DatesTotalAmount;
        }

        private void Btn_Delete_Expenses(object sender, RoutedEventArgs e)
        {
            var itm = Lst_expenses.SelectedItem;

            if(itm==null)
            {
                MessageBox.Show("please select the item to be deleted", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
                return;
            }
            var toDelete = itm as Expense;

             var res = MessageBox.Show($" Are you sure to delete {toDelete.Title} {toDelete.Amount}€?", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            if (res == MessageBoxResult.OK)
            {
                App._expenses.Remove(toDelete);
                Lst_dates.SelectedItem = null;
                uniqueDatesUpdate(App._expenses);
                selectedTotalAmount.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void calender_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
        //    var picker = sender as DatePicker;
        //    DateTime? date = picker.SelectedDate;
        //    var date1 = date.Value.Date.ToShortDateString();
        //    //Expense new_expense = new Expense();
        //    //new_expense.Datetime = date1;
        //    //new_expense.Title = "new title";
        //    //new_expense.Category = "new category";
        //    //new_expense.Amount = 56;
        //    //App._expenses.Add(new_expense);
        //    Lst_dates.Items.Add(date1);


        }

        private void Lst_dates_Selected(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(Lst_dates.SelectedItem.ToString());

            //Lst_expenses.ItemsSource = null;

            //var dateAndTime = DateTime;
            //var date = dateAndTime.Date;
            TotalAmount ta = null;
            if (Lst_dates.SelectedItem != null)
            {
                ta = (TotalAmount)Lst_dates.SelectedItem;
                selectedTotalAmount.Text = ta.Amount.ToString();
                displayDate.Text = ta.CurrentDate.ToString();
            }

            ObservableCollection<Expense> selectedDateExpenses = new ObservableCollection<Expense>();
            foreach (Expense exp in App._expenses)
            {
                if (Lst_dates.SelectedItem == null || exp.Datetime == ta.CurrentDate.ToString())
                {
                    selectedDateExpenses.Add(exp);
                }
            }
            Lst_expenses.ItemsSource = selectedDateExpenses;

        }

        private void CoBx_language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(firstTime)
            {
                firstTime = false;
                return;
            }
            
            language = CoBx_language.SelectedItem.ToString().Substring(0, 2);

            Properties.Settings.Default.language = language;
            Properties.Settings.Default.Save();

            Process.Start(Application.ResourceAssembly.Location);
            App.Current.Shutdown();
        }

        private void Tbx_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = (sender as TextBox).Text;
            var lst = from s in App._DatesTotalAmount where s.CurrentDate.Contains(filter) select s;
            Lst_dates.ItemsSource = lst;
        }

        private void expenseDateFilter(object sender, RoutedEventArgs e)
        {
            
            if (toDateFilter.Text != "" && fromDateFilter.Text != "")
            {
                int val = DateTime.Compare(toDateFilter.SelectedDate.Value, fromDateFilter.SelectedDate.Value);
                if (val >= 0)
                {
                    
                    Lst_totalexpenses.ItemsSource = null;
                    ObservableCollection<Expense> filteredExpenses = new ObservableCollection<Expense>();

                    foreach (Expense ex in App._expenses)
                    {
                        var dateString = ex.Datetime.ToString().Split('/').ToList();
                        DateTime dg = DateTime.Parse(ex.Datetime, System.Globalization.CultureInfo.InvariantCulture);
                        int a = DateTime.Compare(dg, fromDateFilter.SelectedDate.Value);
                        int b = DateTime.Compare(dg, toDateFilter.SelectedDate.Value);
                        if (a >= 0 && b <= 0)
                        {
                            filteredExpenses.Add(ex);
                            Lst_totalexpenses.ItemsSource = filteredExpenses;
                        }
                    }                    
                }
                else
                {
                    MessageBox.Show("Provide Proper Dates");
                }
            }
            else
            {
                MessageBox.Show("Provide Dates");
            }
        }

        private void prepareChartForDate(object sender, SelectionChangedEventArgs e)
        {
            DateTime startDate = chartStartDate.SelectedDate.Value;
            DateTime endDate = startDate.AddDays(30);
            MessageBox.Show("Range of Dates: " + startDate + " - " + endDate);
        }
    }
}
