using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class datamodal
    {
        public class customer
        {
            public string firstname { get; set; }
            public string lastname { get; set; }
            public int age { get; set; }
        }
        public partial class employee
        {
            public string firstname { get; set; }
            public int age { get; set; }
        }

        public partial class employee
        {
            public static explicit operator employee(customer obj)
            {
                return JsonConvert.DeserializeObject<employee>(JsonConvert.SerializeObject(obj));
            }
        }

    }
}
