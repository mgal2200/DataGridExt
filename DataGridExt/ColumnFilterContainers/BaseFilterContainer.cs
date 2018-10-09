using DataGridExt.Controlls;
using DataGridExt.Models;
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
namespace Controlls
{
    public  abstract  class BaseFilterContainer :StackPanel
    {
        public BaseFilterContainer( )
        {
            Loaded += BaseFilterContainer_Loaded;
            var bind = new Binding();
            bind.RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataGridExt.Controlls.DataGridExt), 1);
            SetBinding(DataGridOwnerProperty, bind);
        }
        private void BaseFilterContainer_Loaded(object sender, RoutedEventArgs e)
        {
            
            
        }

        public static readonly DependencyProperty DataGridOwnerProperty = DependencyProperty.Register("DataGridOwner", typeof(DataGridExt.Controlls.DataGridExt), typeof(BaseFilterContainer), new UIPropertyMetadata(new PropertyChangedCallback((DependencyObject s, DependencyPropertyChangedEventArgs e) =>
        {
            var me = s as BaseFilterContainer;
            if (e.NewValue != null)
            {
                me.OnAttachToDataGrid(s, e);
            }
        })));

        public DataGridExt.Controlls.DataGridExt DataGridOwner
        {
            get => (DataGridExt.Controlls.DataGridExt)GetValue(DataGridOwnerProperty);
            set { SetValue(DataGridOwnerProperty, value); }
        }

        public static readonly DependencyProperty DataGridColumnProperty = DependencyProperty.Register("ColumnOwner", typeof(IFilterColunm), typeof(BaseFilterContainer), new UIPropertyMetadata(new PropertyChangedCallback((DependencyObject s, DependencyPropertyChangedEventArgs e) =>
        {
            var me = s as BaseFilterContainer;
            if (me.DataGridOwner == null) { 
                me.DataGridOwner = me.ColumnOwner.DataGridExt;
                me.DataGridOwner.Loaded -= me.DataGridOwner_Loaded;
                me.DataGridOwner.Loaded +=me. DataGridOwner_Loaded;

            }
            me.OnAttachToDataGridColumn(s, e);
        })));

        private   void DataGridOwner_Loaded(object sender, RoutedEventArgs e)
        {
            SetFilterObj();
        }

        public IFilterColunm ColumnOwner
        {
            get => (IFilterColunm)GetValue(DataGridColumnProperty );
            set { SetValue(DataGridColumnProperty , value); }
        }

        IFilter filter;
        public IFilter Filter
        {
            get { return filter; }
            set
            {
                filter = value;
                DataGridOwner.ModelView.FilterDactory.AddFilter(Filter);
                DataContext = Filter;
            }

        }

        public abstract IFilter GetFilterObj(); 

        public virtual void OnAttachToDataGrid(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            if (DataGridOwner != null)
                DataGridOwner.ItemSourceChanged += DataGridOwner_ItemSourceChanged; ;
        }

        private void DataGridOwner_ItemSourceChanged(System.Collections.IEnumerable oldValue, System.Collections.IEnumerable newValue)
        {
            SetFilterObj();
        }

        public virtual void OnAttachToDataGridColumn(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            SetFilterObj();
        }

      public   void SetFilterObj()
        {
            if (Filter == null && DataGridOwner.ModelView.ItemType != null)
                Filter = GetFilterObj();
        }
    }
}
