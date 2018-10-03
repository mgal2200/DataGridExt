using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterFactoryTest
{
    public  class DataList
    {
       public static  List<Person> GetData()
        {
            return Enumerable.Range(1, 10).Select(x => new Person { ID = x, Name = Path.GetRandomFileName().Replace(".",""), DateTime = DateTime.Now.AddDays(x) }).ToList();
        }
    }
    public class Person
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public DateTime? DateTime { get; set; }

    }
}
