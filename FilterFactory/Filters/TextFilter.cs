using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FilterFactory
{
    public class TextFilter :BaseFilter  
    {
        public TextFilter(Type type, PropertyInfo propertyInfo) : base(type, propertyInfo) 
        {
            FilterText = "";
        }
        private string filterText;

        public string FilterText
        {
            get { return filterText; }
            set
            {
                filterText = value;
                RaiseFilterChanged(null);
            }
        }

        override public Expression GetFilterExpression(ParameterExpression param)
        {
            var member = BaseExpression (param);
            if (string.IsNullOrEmpty(filterText))
                return Expression.Constant(true);
            Expression valExpr = Expression.Constant(FilterText,typeof(string));
            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var isNullMtd = typeof(string).GetMethod("IsNullOrEmpty");
            var isNullMtdExpr = Expression.Call( isNullMtd, member);
            var notExpr = Expression.Not(isNullMtdExpr);
            var containsMethodExpr = Expression.Call(member, method, valExpr);
            var andExpr = Expression.AndAlso(notExpr, containsMethodExpr); 
            return andExpr;
        }
        public override Expression BaseExpression(ParameterExpression param)
        {
            if (PropType == typeof( string))
            {
                return MemberAccessExpression(param);
            }
            return ToStringExpression(param);
        }
        Expression ToStringExpression(ParameterExpression param)
        {
           return this.MethodExpression("ToString", MemberAccessExpression(param),null, Type.EmptyTypes);
        }

    }
}
