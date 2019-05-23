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

namespace Binding_01_slider_incode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            SetBinding();
        }

        private void SetBinding()
        {
            Binding binding = new Binding()
            {
                ElementName = "Slider1",
                Path = new PropertyPath("Value"),
                Mode = BindingMode.OneWay
            };

            Binding binding2 = new Binding()
            {
                ElementName = "myColor",
                Path = new PropertyPath("Text"),
                Mode = BindingMode.TwoWay,

            };

            TextBlock1.SetBinding(TextBlock.FontSizeProperty, binding);
            TextBlock1.SetBinding(TextBlock.ForegroundProperty, binding2);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBlock1.FontSize = 100;
        }
    }
}
