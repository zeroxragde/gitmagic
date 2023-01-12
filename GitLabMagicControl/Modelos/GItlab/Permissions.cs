using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabMagicControl.Modelos.GItlab
{
    public class Permissions
    {
        public ProjectAccess project_access { get; set; }
        public GroupAccess group_access { get; set; }
    }
}
