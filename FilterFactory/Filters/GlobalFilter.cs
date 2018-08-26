using FilterFactory;
using FilterFactory.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FilterFactory
{
    public class GlobalFilter  :IFilter  
    {
        
        public GlobalFilter(Type type, IEnumerable<string > propertyNames)  
        {
            filters = new List<TextFilter>();
            FilterTerm = "";
           var props =  type.GetProperties().Where(x => propertyNames.Contains(x.Name));
            foreach (var prop in props)
            {
                var fltr = new TextFilter(type, prop);
                filters.Add(fltr);
            }
        }
        List<TextFilter> filters;

        void NotifyFilterChanged(IFilter filter, EventArgs e)
        {
            FilterChanged?.Invoke(this, e);
        }
        
        private string filterTerm;

        public event FilterChangedEventHandler FilterChanged;

        public string FilterTerm
        {
            get { return filterTerm; }
            set
            {
                filterTerm = value;
                FilterChanged?.Invoke(this, null);
            }
        }

         public Expression GetFilterExpression(ParameterExpression param)
        {
            Expression finaltXpr = Expression.Constant(false );

            foreach (var filter in filters)
            {
                if (FilterTerm.IsNullOrEmpty())
                {
                    return Expression.Constant(true);
                }
                filter.FilterText = FilterTerm;
                finaltXpr = Expression.OrElse (finaltXpr, filter.GetFilterExpression(param)); 
            }
            return finaltXpr;
        }

        public IQueryable ApplyFilter(IQueryable queryable)
        {
            throw new NotImplementedException();
        }

        public IFilter GetFilterObject()
        {
          return    this;
        }
    }
}
