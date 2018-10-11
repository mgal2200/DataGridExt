using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FilterFactory
{
    public class RangeFilter :BaseFilter  
    {
        public RangeFilter(Type type, PropertyInfo propertyInfo):base(type,propertyInfo  )
        {
            From = null;
            To = null; 
        }


        string from;
        public string From
        {
            get
            {
                return from;
            }
            set
            {
                from = value;
                RaiseFilterChanged( null);
            }
        }
        string to;
        public string To
        {
            get
            {
                return to;
            }
            set
            {
                to = value;
                RaiseFilterChanged( null);

            }
        }

        public void SetFrom(string val)
        {
            from = val;
            RaiseFilterChanged(null);
        }
        public void SetTo(string val)
        {
            to = val;
            RaiseFilterChanged(null);
        }
      
     override    public Expression GetFilterExpression(ParameterExpression param)
        {
            var member = base.BaseExpression(param);
            Expression fromExpr = Expression.Constant(true);
            Expression toExpr = Expression.Constant(true);
            if (!string.IsNullOrEmpty(from))
            {
                    var fromval =Helpers. Helpers.ChangeType(From, PropType);
                fromExpr = Expression.GreaterThanOrEqual(member, Expression.Constant(fromval));
            }
            if (!string.IsNullOrEmpty(  to ))
            {
                var toval = Helpers.Helpers.ChangeType(To, PropType);
                toExpr = Expression.LessThan(member, Expression.Constant(toval));
            }
            //Expression.Constant(fromval )
            return Expression.AndAlso(toExpr, fromExpr);
        }

        public IQueryable ApplyFilter(IQueryable queryable)
        {
            throw new NotImplementedException();
        }

        public IFilter GetFilterObject()
        {
            return (IFilter)this;
        }
    }
}
