using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabMagicControl.Modelos.GItlab
{
    public class add_spend_time
    {
        public int time_estimate { get; set; }
        public int total_time_spent { get; set; }
        public string human_time_estimate { get; set; }
        public string human_total_time_spent { get; set; }
    }
}
