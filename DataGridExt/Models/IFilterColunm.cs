using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataGridExt.Controlls;

namespace DataGridExt.Models
{
   public interface IFilterColunm 
    {
        Expression GetFilterExpression(ParameterExpression param);
        Controlls.DataGridExt  DataGridExt { get; }
        PropertyInfo Property();
        string FieldName { get; }
    }
}
