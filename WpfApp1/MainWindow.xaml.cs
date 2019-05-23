using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MyData myData = new MyData()
        {
            MyProperty = "Test string for binding to instance from c#"
        };
        public MainWindow()
        {
            InitializeComponent();

            this.Resources.Add("myFirsInstance", myData);

            //this.DataContext = myData;
            newName.DataContext = myData;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new MyData() { MyProperty = $"Changed context binding {DateTime.Now}" };
            newName.DataContext = new MyData() { MyProperty = $"Changed context binding {DateTime.Now}" };
        }
    }
    public class MyData
    {
        public string MyProperty { get; set; }
        private string MyProperty1 { get; set; }
    }
}
