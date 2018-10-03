using Controlls;
using FilterFactory;
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
using WpfApp1.Models;

namespace Controlls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NumberFilterContainer : BaseFilterContainer
    {
        public NumberFilterModelView  numberFilterModelView { get; set; }
        public NumberFilterContainer()
        {
            InitializeComponent();
        }
        public override void OnAttachToDataGrid(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            if (DataGridOwner != null)
                DataGridOwner.Loaded += DataGridOwner_Loaded;

        }

        private void DataGridOwner_Loaded(object sender, RoutedEventArgs e)
        {
            if (Filter == null)
                Filter = new RangeFilter(ColumnOwner.DataGridExt.ModelView.ItemType, ColumnOwner.Property());
        }
        public override void OnAttachToDataGridColumn(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
           if (Filter == null)
                Filter = new RangeFilter(ColumnOwner.DataGridExt.ModelView.ItemType, ColumnOwner.Property());
        }
    }
    public class NumberFilterModelView
    {
        NumberFilterContainer numFilterContner;
        //public string From
        //{
        //    get { return RangeFilter.From; }
        //    set
        //    {
        //        RangeFilter.From = value;
        //    }
        //}
        //public string To
        //{
        //    get { return RangeFilter.To; }
        //    set
        //    {
        //        RangeFilter.To = value;
        //    }
        //}

        public NumberFilterModelView(NumberFilterContainer numberFilterContainer)
        {
            this.numFilterContner = numberFilterContainer;


        }

       

       
    }
}
