using DataGridExt.Controlls;
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
using DataGridExt .Models;

namespace Controlls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DataGridTextFilterColumn : DataGridTextColumn, IFilterColunm
    {

        public string FieldName => ((Binding)Binding).Path.Path;
        TextFilterContainer TextFilterContainer { get; set; }
        public TextFilter TextFilter { get; set; }

        public DataGridExt.Controlls.DataGridExt DataGridExt => (DataGridExt.Controlls.DataGridExt)DataGridOwner;

        public DataGridTextFilterColumn()
        {
            InitializeComponent();
        }

        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            //if (TextFilter == null)
            //{
            //    var type = DataGridExt.ModelView.ItemType;
            //    var prop = Property();
            //    TextFilter = new TextFilter(type, prop);
            //    TextFilter.FilterChanged += (s, e) => DataGridExt.ModelView.RefreshView();
            //    TextFilterContainer.DataContext = TextFilter;
            //}
            return base.GenerateElement(cell, dataItem);
        }

        public IRangeFilter GetFilterObject()
        {
            return null; ;
        }

        public System.Linq.Expressions.Expression GetFilterExpression(ParameterExpression param)
        {
            return TextFilter.GetFilterExpression(param);
        }


        public PropertyInfo Property()
        {
            return DataGridExt.ModelView.ItemType.GetProperty(FieldName);
        }



        private void TextFilterContainer_Loaded(object sender, RoutedEventArgs e)
        {
            TextFilterContainer = (TextFilterContainer)sender;
        }
    }
}
