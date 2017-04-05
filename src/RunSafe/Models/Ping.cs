using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunSafe.Models
{
    public class Ping
    {
        public int Ping_ID { get; set; }
        public DateTime datetime_logged { get; set; }
        public DateTime datetime_stored { get; set; }
        public Double latitude { get; set; }
        public Double longtitude { get; set; }
        public int? battery { get; set; }
        public int? signal { get; set; }
    }
}
