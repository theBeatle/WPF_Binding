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

namespace Binding_06_DataContext
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string myKey  = "thirdPerson";
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            this.Resources.Add(myKey, new Person { FirstName = "1", LastName = "2" });
            MessageBox.Show(this.Resources.Count.ToString());
        }

    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
