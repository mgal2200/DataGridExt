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
        public MainWindow()
        {
            InitializeComponent();
           Loaded += MainWindow_Loaded;
            //FilterFactory.FilterOptions.CultureInfo = new System.Globalization.CultureInfo() 
        }



        private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            abc.ItemsSource = GetPersons();
            abcd.ItemsSource = GetPersons();

        }

        List<Person> GetPersons()
        {
            return Enumerable.Range(1, 10).Select(x => new Person {
                ID = x,
                DateTime = DateTime.Now.AddDays(x)
                

            }).ToList();
        }
    }
   
    public class Person
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public DateTime? DateTime  { get; set; }
        //public List<int> MyProperty { get; set; }

    }
}
