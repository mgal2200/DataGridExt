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
    public class BaseFilter : IFilter
    {
        public BaseFilter(Type type, PropertyInfo propertyInfo)
        {
            ItemType = type;
            prop = propertyInfo;
        }


        public Type PropType => prop.PropertyType;
        public Type ItemType { get; set; }

        PropertyInfo prop;

        public event FilterChangedEventHandler FilterChanged;

        public IFilter GetFilterObject()
        {
            return (IFilter)this;
        }

        public Expression MemberAccessExpression(ParameterExpression param)
        {
            return Expression.MakeMemberAccess(param, prop);
        }

        virtual   public Expression BaseExpression(ParameterExpression param)
        {
            if (PropType.IsNullable())
            {
                var mtdxpr = MethodExpression("GetValueOrDefault", MemberAccessExpression(param), null, Type.EmptyTypes);
                return mtdxpr;
            }
            return MemberAccessExpression(param);
        }

        public Expression MethodExpression(string methodName, Expression member, Expression parameters, Type[] types)
        {

            MethodInfo mtd = PropType.GetMethod(methodName, types);
            return Expression.Call(member, mtd);
        }

        virtual public IQueryable ApplyFilter(IQueryable queryable)
        {
            throw new NotImplementedException();
        }

        virtual public Expression GetFilterExpression(ParameterExpression param)
        {
            throw new NotImplementedException();
        }
        public void RaiseFilterChanged(EventArgs e)
        {
            FilterChanged?.Invoke(this, e);
        }
    }
}
