using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabMagicControl.Modelos
{
    public class Configuracion
    {
        public string PRIVATE_TOKEN { get; set; }
        public string API_URL { get; set; }
        public string USERNAME { get; set; }
        public string TEMA { get; set; }
        public string HORA_RECORDATORIO_SPEND { get; set; }
        public string PANEL { get; set; } = "Proyectos";
    }
}
