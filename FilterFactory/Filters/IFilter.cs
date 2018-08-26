

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilterFactory
{
   public interface IFilter 
    {
         IQueryable ApplyFilter(IQueryable queryable);
         IFilter  GetFilterObject();
        Expression GetFilterExpression(ParameterExpression param);
          event FilterChangedEventHandler FilterChanged;


    }
}
