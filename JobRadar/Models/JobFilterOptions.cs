using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRadar.Models
{
    public class JobFilterOptions
    {
        public List<string> Keywords { get; set; } = new();

        public List<string> Locations { get; set; } = new();

        public bool RemoteOnly { get; set; }
    }
}
