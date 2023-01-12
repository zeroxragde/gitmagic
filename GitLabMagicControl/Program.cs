using GitLabMagicControl.Clases;
using GitLabMagicControl.Controladores;
using GitLabMagicControl.Modelos;
using GitLabMagicControl.Vistas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitLabMagicControl
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (File.Exists(General.AppPath + @"\configuracion.json"))
            {

                string json = File.ReadAllText(General.AppPath + "\\configuracion.json");
                General.configuracion = JsonConvert.DeserializeObject<Configuracion>(json);
                if (General.configuracion.USERNAME != "")
                {
                    General.usuario = General.api.obtenerUsuario(General.configuracion.USERNAME);
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new VistaConfiguracion());
            }

        }
    }
}
