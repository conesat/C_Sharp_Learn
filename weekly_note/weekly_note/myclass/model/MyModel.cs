using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nncqweekly.myclass.model
{
    [Serializable]
    public class MyModel
    {
        public String title { get; set; }
        public String id { get; set; }
        public Boolean used { get; set; }
        public String timeType { get; set; }
    }
}
