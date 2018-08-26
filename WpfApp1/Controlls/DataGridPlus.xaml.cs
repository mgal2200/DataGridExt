using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Automation.Peers;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Data;
using WpfApp1.Models;
using FilterFactory;
using System.ComponentModel;

namespace Controlls
{
    public partial class DataGridPlus : DataGrid
    {
        public DataGridPlus()
        {
            DataContext = ModelView = new DataGridModelView(this);
            Loaded += DataGridPlus_Loaded;
        }

        private void DataGridPlus_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        public DataGridModelView ModelView { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new FieldChooser(new FieldChooserModelView(ModelView.ItemType)).ShowDialog();
        }
    }
    public class DataGridModelView
    {
        public FilterDactory FilterDactory { get; set; }
        public DataGridModelView(DataGridPlus dataGridPlus)
        {
            DataGrid = dataGridPlus;
            FilterDactory = new FilterDactory(ItemType);
            FilterDactory.FilterChanged += (s, e) => RefreshView();

        }
        public DataGridPlus DataGrid { get; set; }
        private Type itemType;

        public Type ItemType
        {
            get
            {
                if (itemType == null && DataGrid.ItemsSource != null)
                {
                    ItemType = DataGrid.ItemsSource.Cast<object>().FirstOrDefault()?.GetType();
                }
                return itemType;
            }
            set { itemType = value; }
        }


        public void RefreshView()
        {
            try
            {
                var param = System.Linq.Expressions.Expression.Parameter(ItemType);
                var expr = FilterDactory.GetFilterExpression(param);

                var lmbda = System.Linq.Expressions.Expression.Lambda(expr, param);
                var predicat = lmbda.Compile();

                CollectionViewSource.GetDefaultView(DataGrid.ItemsSource).Filter = (x) =>
                {
                    bool ret = (bool)predicat.DynamicInvoke(x);
                    return ret;

                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
