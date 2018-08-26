using FilterFactory.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilterFactory
{
    public class DateRangeFilter : RangeFilter
    {
        public DateRangeFilter(Type type, PropertyInfo propertyInfo) : base(type, propertyInfo)
        {
            DateRanges = new List<KeyValuePair<DateRanges?, string>>() {
                new KeyValuePair<DateRanges?, string>(Models.DateRanges.Past, Models.DateRanges.Past.ToString()),
                new KeyValuePair<DateRanges?, string>(null,"")
            };
            CultureInfo = FilterOptions.CultureInfo ?? Thread.CurrentThread.CurrentCulture;
        }
        public CultureInfo  CultureInfo { get;  }
        public DateTime? FromDate {
            get
            {
                if (string.IsNullOrEmpty(From))
                    return null;
                return DateTime.Parse(From, CultureInfo);
            }
            set {

                From  = value == null ? null : value.Value.ToString(CultureInfo);
            }
        }
        public DateTime? ToDate
        {
            get
            {
                if (string.IsNullOrEmpty(To))
                    return null;
                return DateTime.Parse(To, CultureInfo);
            }
            set
            {

                To = value == null ? null : value.Value.ToString(CultureInfo);
            }
        }

        private DateRanges? seletedRange;

        public DateRanges? SelectedRange
        {
            get => seletedRange;
            set
            {
                seletedRange = value;
                if (seletedRange == null)
                {
                    SetTo(null);
                }
                else
                {
                    SetTo(DateTime.Now.ToString()); 
                }

            }
        }
        public List<KeyValuePair<DateRanges?, string>> DateRanges { get; set; }
    }
}
