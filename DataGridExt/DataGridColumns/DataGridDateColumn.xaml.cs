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
using DataGridExt.Models;
using Controlls;

namespace Controlls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DataGridDateColumn: DataGridTextColumn,IFilterColunm
    {
        CultureInfo cultureInfo;
        public CultureInfo  CultureInfo  {
            get
            {
                return cultureInfo;
            }
            set
            {
                cultureInfo = value;
                Thread.CurrentThread.CurrentCulture = value ;
                Thread.CurrentThread.CurrentUICulture = value ;
            }
        }
        public string FieldName => ((Binding)Binding).Path.Path;
        //DateFilterContainer DateFilterContainer { get; set; }
        public RangeFilter RangeFilter { get; set; }

        public DataGridExt.Controlls. DataGridExt DataGridExt => (DataGridExt.Controlls.DataGridExt)DataGridOwner;

        public DataGridDateColumn()
        {
            InitializeComponent();
            CultureInfo = FilterOptions.CultureInfo ?? Thread.CurrentThread.CurrentCulture;
        }

        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            //if (RangeFilter == null)
            //{
            //    var type = DataGridExt .ModelView.ItemType;
            //    var prop = Property();
            //    RangeFilter = new RangeFilter(type, prop);
            //    //RangeFilter.FilterChanged += (s, e) => DataGridExt.ModelView.RefreshView();
            //   // DateFilterContainer.DataContext = RangeFilter;
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
         
    }
}
