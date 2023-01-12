using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabMagicControl.Modelos
{
    public class ReporteMensualData
    {
        public string Tipo { get; set; }
        public string Fecha { get; set; }
        public string Nombre { get; set; }
        public string Horas { get; set; }
        public string Minutos { get; set; }
        public string TiempoInvertido { get; set; } = "0";
        public string WebUrl { get; set; } = "";
    }
}
