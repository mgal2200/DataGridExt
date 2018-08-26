using FilterFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
using DataGridExt.Models;

namespace Controlls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DataGridNumberColumn: DataGridTextColumn,IFilterColunm
    {
        public string FieldName => ((Binding )Binding).Path .Path ;
        NumberFilterContainer NumberFilterContainer { get; set; }
        public IFilter RangeFilter { get; set; }

        public DataGridExt.Controlls.DataGridExt DataGridExt => (DataGridExt.Controlls.DataGridExt)DataGridOwner;

        public DataGridNumberColumn()
        {
            InitializeComponent();
        }
        
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            //if (RangeFilter == null)
            //{
            //    var type = DataGridExt.ModelView.ItemType;
            //    var prop = Property();
            //    RangeFilter = new RangeFilter(type, prop);
            //    RangeFilter.FilterChanged += (s, e) => DataGridExt.ModelView.RefreshView();
            //    NumberFilterContainer.DataContext = RangeFilter;
            //}
            return base.GenerateElement(cell, dataItem);
        }

        public IRangeFilter GetFilterObject()
        {
            return null; ;
        }

        public System.Linq.Expressions.Expression GetFilterExpression(ParameterExpression param)
        {
            return RangeFilter.GetFilterExpression(param);
        }

        

        public PropertyInfo Property()
        {
            return DataGridExt.ModelView.ItemType.GetProperty(FieldName);
        }
        private void NumberFilterContainer_Loaded(object sender, RoutedEventArgs e)
        {
            NumberFilterContainer = (NumberFilterContainer)sender;
        }
    }
}
