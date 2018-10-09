using FilterFactory;
using System.Linq;
using System.Windows;

namespace Controlls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DataGridGlobalFilter : BaseFilterContainer
    {

        public DataGridGlobalFilter()
        {
            InitializeComponent();
        }

        public override void OnAttachToDataGrid(DependencyObject s,  DependencyPropertyChangedEventArgs e)
        {
            base.OnAttachToDataGrid(s,e);
            var me = s as BaseFilterContainer;
            me.SetFilterObj();
            //Filter = new GlobalFilter(DataGridOwner.ModelView.ItemType,  DataGridOwner.ModelView.ItemType.GetProperties().Select(x => x.Name));
        
        }
        public override IFilter GetFilterObj()
        {
            return new GlobalFilter(DataGridOwner.ModelView.ItemType, DataGridOwner.ModelView.ItemType.GetProperties().Select(x => x.Name));

        }

    }
}
