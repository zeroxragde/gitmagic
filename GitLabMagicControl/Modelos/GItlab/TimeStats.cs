using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabMagicControl.Modelos.GItlab
{
    public class TimeStats
    {
        public int time_estimate { get; set; }
        public int total_time_spent { get; set; }
        public object human_time_estimate { get; set; }
        public string human_total_time_spent { get; set; }
    }
}
