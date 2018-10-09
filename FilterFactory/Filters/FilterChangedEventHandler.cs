using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FilterFactory
{
    public delegate void FilterChangedEventHandler(IFilter filter , EventArgs e);
    public delegate void ItemSourceChangedEventHandler(IEnumerable oldValue, IEnumerable newValue);

}
