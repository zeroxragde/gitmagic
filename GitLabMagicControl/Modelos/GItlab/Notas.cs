using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabMagicControl.Modelos.GItlab
{
    public class Notas
    {
        public int id { get; set; }
        public object type { get; set; }
        public string body { get; set; }
        public object attachment { get; set; }
        public Author author { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public bool system { get; set; }
        public int noteable_id { get; set; }
        public string noteable_type { get; set; }
        public bool resolvable { get; set; }
        public bool confidential { get; set; }
        public int noteable_iid { get; set; }
        public CommandsChanges commands_changes { get; set; }
    }
}
