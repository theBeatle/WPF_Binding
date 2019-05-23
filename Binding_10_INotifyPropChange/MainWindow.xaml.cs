using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Binding_10_INotifyPropChange
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PropChange myTestClass = new PropChange() { Currency = "Dollar", Quantity = 100500 };
        SalaryBalance salary = new SalaryBalance();
        ObservableCollection<Worker> workers = new ObservableCollection<Worker>();
        private int currentWorker = -1;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = salary;
            workers.Add(new Worker { Currency = "qwew", Quantity = 454 });
            workers.Add(new Worker { Currency = ";kl;lk;l", Quantity = 7896 });
            workers.Add(new Worker { Currency = ";'l;'l;'", Quantity = 4235 });

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ///myTestClass.StringProperty = textSource.Text;

           // salary.PropertyChanged += Salary_PropertyChanged;
            salary.Quantity += 200;
            salary.Currency = "USD";

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DataContext = myTestClass;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (currentWorker == -1)
            {
                this.DataContext = workers.FirstOrDefault();
                currentWorker = 0;
            }
            else if (currentWorker == 0)
            {
                this.DataContext = workers.LastOrDefault();
                currentWorker = workers.Count - 1;
            }
            else
            {
                this.DataContext = workers[currentWorker-- - 1];
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (currentWorker == -1 || currentWorker == workers.Count - 1)
            {
                this.DataContext = workers.FirstOrDefault();
                currentWorker = 0;
            }
            else
            {
                this.DataContext = workers[++currentWorker];
            }

        }
    }

    public class PropChange : INotifyPropertyChanged
    {
        private string stringProperty = String.Empty;
        private int myAge;

        public int Quantity
        {
            get { return myAge; }
            set
            {
                if (value != this.myAge)
                {
                    this.myAge =  value;
                    NotifyPropertyChanged("Quantity");
                }
            }
        }
        public string Currency
        {
            get => this.stringProperty;
            set
            {
                if (value != this.stringProperty)
                {
                    this.stringProperty = value;
                    NotifyPropertyChanged("Currency");
                }
            }
        }
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class SalaryBalance : INotifyPropertyChanged
    {
        private int quantity = 6666;
        private string currency = "hello";
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value != quantity)
                {
                    quantity = value;
                    OnPropertyChanged("Quantity");
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName]string v = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public string Currency
        {
            get { return currency;  }
            set
            {
                if (value != this.currency)
                {
                    currency = value;
                    OnPropertyChanged("Currency");
                }
            }
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class Worker
    {
        public int Quantity { get; set; }
        public string Currency { get; set; }
    }


}
