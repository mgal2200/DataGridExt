using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FilterFactory
{
    public class FieldData  
    {
        public FieldData(PropertyInfo propertyInfo)
        {
            Name = propertyInfo.Name;
            PropertyInfo = propertyInfo;
        }
        public PropertyInfo PropertyInfo  { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public bool  IsSelected { get; set; }

    }
}
