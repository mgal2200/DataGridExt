using FilterFactory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DataGridExt.Controlls
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class FieldChooser : Window  
    {
        public FieldChooserModelView FieldChooserModelView  { get; set; }
        public FieldChooser(FieldChooserModelView fieldChooserModelView)
        {
            InitializeComponent();
            FieldChooserModelView = fieldChooserModelView;
            DataContext = FieldChooserModelView;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ListBox   sndr = (ListBox  )sender;
            if (e.ClickCount > 1)
            {
                FieldData field = (FieldData)sndr.SelectedItem ;
                FieldChooserModelView.MoveFields(new[] { field });
            }
        }

        //private void ItemsControl_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    ListBox parent = (ListBox)sender;
             
        //  parent.

        //    if (data != null)
        //    {
        //        DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
        //    }
        //}

        //private void TextBlock_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        TextBlock txblck = sender as TextBlock;
        //        DragDrop.DoDragDrop(txblck, txblck.DataContext, DragDropEffects.Move);
        //    }
        //}

        //private void ItemsControl_PreviewDrop(object sender, DragEventArgs e)
        //{
        //    var a = 1;
        //}

      

        //private void TextBlock_DragEnter(object sender, DragEventArgs e)
        //{
        //    var a = 1;
        //}

        //private void TextBlock_DragOver(object sender, DragEventArgs e)
        //{
        //    var a = 1;
        //}
    }

    public class FieldChooserModelView
    {
        public FieldChooserModelView(Type type )
        {
            Type = type;
            AvailableFields = new ObservableCollection<FieldData> ( type.GetProperties().Select(x => new FieldData(x)));
            SelectedFields = new ObservableCollection<FieldData>();
        }
        public Type  Type  { get; set; }
        public ObservableCollection<FieldData> SelectedFields { get; set; }
        public ObservableCollection<FieldData> AvailableFields { get; set; }

        public  void MoveFields(FieldData[] fieldsData)
        {
            foreach (var field in fieldsData )
            {
                if (field.IsSelected)
                {
                    field.IsSelected = false;
                    AvailableFields.Add(field);
                    SelectedFields.Remove(field);
                }
                else
                {
                    field.IsSelected = true ;
                    AvailableFields.Remove (field);
                    SelectedFields.Add(field);
                }
            }        
        }

        public IEnumerable<FieldData> AllFields => SelectedFields.Union(AvailableFields);
    }
}
