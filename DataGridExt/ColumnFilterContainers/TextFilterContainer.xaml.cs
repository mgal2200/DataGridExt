using FilterFactory;
using System.Windows;

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
            //Loaded += TextFilterContainer_Loaded;
     
        }
        public override IFilter GetFilterObj()
        {
            return new TextFilter(ColumnOwner.DataGridExt.ModelView.ItemType, ColumnOwner.Property());
        }
        //private void TextFilterContainer_Loaded(object sender, RoutedEventArgs e)
        //{
        //   // Filter = new TextFilter(ColumnOwner.DataGridExt.ModelView.ItemType, ColumnOwner.Property());
        //}

        //public override void OnAttachToDataGrid(DependencyObject s, DependencyPropertyChangedEventArgs e)
        //{
        //    if (DataGridOwner != null)
        //        DataGridOwner.Loaded += DataGridOwner_Loaded;

        //}

        //private void DataGridOwner_Loaded(object sender, RoutedEventArgs e)
        //{
        //    if (Filter == null)
        //        Filter = new TextFilter(ColumnOwner.DataGridExt.ModelView.ItemType, ColumnOwner.Property());
        //}

        //public override void OnAttachToDataGridColumn(DependencyObject s, DependencyPropertyChangedEventArgs e)
        //{
        //   // ColumnOwner.DataGridExt.item
        //    if (Filter == null && ColumnOwner.DataGridExt.IsLoaded )
        //        Filter = new TextFilter(ColumnOwner.DataGridExt.ModelView.ItemType, ColumnOwner.Property());
        //}

    }
    
}
