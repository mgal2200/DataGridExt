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
using DataGridExt.Models;
using System.Reflection;
using FilterFactory.Helpers;
using Controlls;
using System.Collections;

namespace DataGridExt.Controlls
{
    public partial class DataGridExt : DataGrid
    {
        public DataGridExt()
        {
            InitializeComponent();
            DataContext = ModelView = new DataGridModelView(this);
            Loaded += DataGridPlus_Loaded;
        }

        private void DataGridPlus_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            var fldchoose = new FieldChooser(new FieldChooserModelView(ModelView.ItemType));
            ModelView.RefreshColumns(fldchoose.FieldChooserModelView.AllFields );
        }
        public DataGridModelView ModelView { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fldchoose = new FieldChooser(new FieldChooserModelView(ModelView.ItemType));
            fldchoose.ShowDialog();
            ModelView.RefreshColumns(fldchoose.FieldChooserModelView.AllFields);

        }
    }
    public class DataGridModelView
    {
        public FilterDactory FilterDactory { get; set; }
        public DataGridModelView(DataGridExt dataGridExt)
        {
            DataGrid = dataGridExt;
            DataGrid.AutoGenerateColumns = false;
            FilterDactory = new FilterDactory(ItemType);
            FilterDactory.FilterChanged += (s, e) => RefreshView();

        }
        public DataGridExt DataGrid { get; set; }
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


        public void RefreshColumns(IEnumerable<FieldData>  fieldsData)
        {
            var fields = fieldsData;
            var colmns = DataGrid.Columns.OfType<IFilterColunm>().ToDictionary(x => x.FieldName);

            var selectedFields = fieldsData.Where(x => x.IsSelected).OrderBy(x=> x.Position ).ToList();
            if (selectedFields.Count == 0)
            {
                selectedFields = fieldsData.ToList();
            }
            foreach (var fldData in selectedFields)
            {
                IFilterColunm   colmn = null;
                colmns.TryGetValue(fldData.Name,out colmn);
                DataGridColumn column = (DataGridColumn)colmn;
                if (column == null)
                {
                    column = GenerateColumn(fldData.PropertyInfo);
                    
                    DataGrid.Columns.Add(column);
                }
                column.DisplayIndex = selectedFields.IndexOf(fldData);
            }

            foreach (var fldData in fieldsData.Where(x => !x.IsSelected))
            {
                if (colmns.ContainsKey(fldData.Name))
                {
                    DataGrid.Columns.Remove((DataGridColumn)colmns[fldData.Name]);
                }
            }
        }

        Type ResolveColumnByType(PropertyInfo propertyInfo)
        {
            var type = propertyInfo.PropertyType.UnderlyingIfNull();


            if (type.IsNumericType())
                return typeof(DataGridNumberColumn);
            if (type == typeof(DateTime))
                return typeof(DataGridDateColumn);

            return typeof(DataGridTextFilterColumn);
        }


        DataGridColumn GenerateColumn(PropertyInfo propertyInfo  )
        {
            var type = ResolveColumnByType(propertyInfo);
            var col = (DataGridBoundColumn )Activator.CreateInstance(type);
            col.Binding = new Binding(propertyInfo.Name);
            col.Header = propertyInfo.Name;
            return col;
        }
    }
}
