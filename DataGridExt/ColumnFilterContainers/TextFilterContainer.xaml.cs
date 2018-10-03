using FilterFactory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
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
    public partial class TextFilterContainer : BaseFilterContainer
    {
        public TextFilterContainer()
        {
            InitializeComponent();
            Loaded += TextFilterContainer_Loaded;
     
        }

        private void TextFilterContainer_Loaded(object sender, RoutedEventArgs e)
        {
           // Filter = new TextFilter(ColumnOwner.DataGridExt.ModelView.ItemType, ColumnOwner.Property());
        }

        public override void OnAttachToDataGrid(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            //if (DataGridOwner != null)
            //    DataGridOwner.Loaded += DataGridOwner_Loaded;
                
        }

        private void DataGridOwner_Loaded(object sender, RoutedEventArgs e)
        {
            if (Filter == null)
                Filter = new TextFilter(ColumnOwner.DataGridExt.ModelView.ItemType, ColumnOwner.Property());
        }

        public override void OnAttachToDataGridColumn(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            if (Filter == null)
                Filter = new TextFilter(ColumnOwner.DataGridExt.ModelView.ItemType, ColumnOwner.Property());
        }

    }
    
}
