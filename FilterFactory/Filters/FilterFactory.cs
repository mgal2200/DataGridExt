using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FilterFactory
{
    public class FilterDactory
    {
        Type type;
        public FilterDactory(Type type)
        {
            this.type = type;
            FilterCollection = new List<IFilter>();
        }
        public List<IFilter> FilterCollection { get; set; }
       public event FilterChangedEventHandler FilterChanged;

        public void AddFilter(IFilter filter) {
            FilterCollection.Add(filter);
            filter.FilterChanged += filterChanged;
        }

        void filterChanged(IFilter filter,EventArgs e)
        {
            FilterChanged?.Invoke(null, null);
        }

        public Expression GetFilterExpression(ParameterExpression param)
        {
            Expression ret = Expression.Constant(true); ;
            foreach (IFilter filter in FilterCollection)
            {
                ret = Expression.AndAlso(ret, filter.GetFilterExpression(param));
            }
            return ret;
        }
    }
}
