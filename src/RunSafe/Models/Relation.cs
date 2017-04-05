using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunSafe.Models
{
    public class Relation
    {
        public int Relation_ID { get; set; }
        public int PersonID { get; set; }
        public int observerID { get; set; }
        public bool priority { get; set; }
    }
}
