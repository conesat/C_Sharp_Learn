using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nncqweekly.myclass.model
{
    [Serializable]
    public class WorkList
    {
        public WorkList(){
            finsh = new List<Work>();
            todo = new List<Work>();
        }
        public List<Work> finsh { get;set; }
        public List<Work> todo { get; set; }
    }
}
