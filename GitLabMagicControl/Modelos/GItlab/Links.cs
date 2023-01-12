using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabMagicControl.Modelos.GItlab
{
    public class Links
    {
        public string self { get; set; }
        public string issues { get; set; }
        public string merge_requests { get; set; }
        public string repo_branches { get; set; }
        public string labels { get; set; }
        public string events { get; set; }
        public string members { get; set; }
    }
}
