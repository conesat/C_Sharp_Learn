using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nncqweekly.myclass.model
{
    [Serializable]
    public class Work
    {
        public String content { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public String id { get; set; }
    }
}
