using GitLabMagicControl.Clases;
using GitLabMagicControl.Modelos;
using GitLabMagicControl.Modelos.GItlab;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitLabMagicControl.Controladores
{
    public static class General
    {
        public static string AppPath = Application.StartupPath;
        public static List<Projects> all_proyectos = new List<Projects>();
        public static List<Issue> all_issues = new List<Issue>();
        public static List<Merges> all_merges_open = new List<Merges>();
        public static Configuracion configuracion = new Configuracion();
        public static User usuario = new User();
        public static APIGitlab api = new APIGitlab();

        public static void getAllMergeOpen() {
            List<Merges> mmerges = api.obtenerMergesAbiertos(usuario.id);
            all_merges_open.Clear();
            foreach (Merges m in mmerges)
            {
                all_merges_open.Add(m);
            }
        }

        public static void getAllIssues() {
           List<Issue> iisues = api.obtenerIssues(usuario.id.ToString());
            all_issues.Clear();
            foreach (Issue issue in iisues) {
                all_issues.Add(issue);
            }
        }
        public static void getAllProjects() {
            List<Projects> proyectos = api.obtenerProyectos().Result;
            int total_proyectos_pages = int.Parse(api.getHeaderResponse("X-Total-Pages"));
            for (int x=1; x < total_proyectos_pages; x++) {
                List<Projects> tmp = api.obtenerProyectos(x.ToString()).Result;
                foreach (Projects p in tmp) {
                    all_proyectos.Add(p);
                }
            }
        }
        public static void ChangeBG(Form f,Color c) {
            f.BackColor = c;
        }
        public static bool saveConfig() {

            string config_string = JsonConvert.SerializeObject(configuracion, Formatting.Indented);
            try {
                // serialize JSON to a string and then write string to a file
                File.WriteAllText(AppPath + @"\configuracion.json", config_string);
                return true;
            } catch {
                return false;
            }
  
        }
        
    }
}
