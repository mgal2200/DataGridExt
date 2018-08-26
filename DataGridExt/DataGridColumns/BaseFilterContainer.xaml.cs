using FilterFactory;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Controlls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BaseFilterContainer: UserControl  
    {
         public BaseFilterContainer()
         {
             InitializeComponent(); 
             //Loaded += BaseFilterContainer_Loaded;
         }

        //private void BaseFilterContainer_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var bind = new Binding();
        //    bind.RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataGridExt), 1);
        //    //SetBinding(DataGridOwnerProperty, bind);
        //}

        //public static readonly DependencyProperty DataGridOwnerProperty = DependencyProperty.Register("DataGridOwner", typeof(DataGridExt), typeof(BaseFilterContainer), new UIPropertyMetadata(new PropertyChangedCallback((DependencyObject s, DependencyPropertyChangedEventArgs e) => {
        //    var me = s as BaseFilterContainer;
        //    me.OnAttachToDataGrid(s, e);
        //})));

        //public DataGridExt DataGridOwner
        //{
        //    get => (DataGridExt)GetValue(DataGridOwnerProperty);
        //    set { SetValue(DataGridOwnerProperty, value); }
        //}
        public IFilter filter { get; set; }

        public virtual void OnAttachToDataGrid(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
