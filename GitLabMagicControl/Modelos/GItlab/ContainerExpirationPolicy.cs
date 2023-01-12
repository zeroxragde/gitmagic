using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabMagicControl.Modelos.GItlab
{
    public class ContainerExpirationPolicy
    {
        public string cadence { get; set; }
        public bool enabled { get; set; }
        public int keep_n { get; set; }
        public string older_than { get; set; }
        public string name_regex { get; set; }
        public object name_regex_keep { get; set; }
        public DateTime next_run_at { get; set; }
    }
}
