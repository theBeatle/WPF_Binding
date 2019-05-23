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

namespace Binding_08_toCollection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // List<string> list = new List<string>();
        ObservableCollection<string> list = new ObservableCollection<string>();
        ObservableCollection<string> list2 = null; // = new ObservableCollection<string>();
        ObservableCollection<string> list3 = null;

        public MainWindow()
        {
            InitializeComponent();

            //variant 1
            List<string> myList = new List<string>() { "myFirst", "mySecond" };
            
            list2 = new ObservableCollection<string>(myList);
            

            //variant 2
            string[] arr = { "First", "Second", "Third", "Fourth" };
            foreach (string item in arr)
            {
                list.Add(item);
            }

            //variant 3
            list3 = new ObservableCollection<string>(arr);
            listBox1.ItemsSource = list;


        
            

        }

        private void Button_Click(object sender, RoutedEventArgs e) =>
            // INotifyCollectionChanged  - > ObservableCollection<T>
            list.Add(DateTime.Now.ToLongDateString());

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (list.Count != 0)
            {
                list.RemoveAt(list.Count - 1);
            }
        }

    }
}
