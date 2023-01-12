using GitLabMagicControl.Controladores;
using GitLabMagicControl.Modelos;
using GitLabMagicControl.Modelos.GItlab;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tiny.RestClient;

namespace GitLabMagicControl.Clases
{
    public class APIGitlab
    {
        private Headers headers;
        JsonSerializerSettings settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        public APIGitlab() {

        }
        public Task<List<Projects>> obtenerProyectos(string pagenumer = "1") {
            List<Projects> p = new List<Projects>();
            string res = RunApi("projects?page=" + pagenumer + "&per_page=1000&order_by=id&sort=asc&membership=true");
            List<Projects> myDeserializedClass = JsonConvert.DeserializeObject<List<Projects>>(res);
            return Task.FromResult(myDeserializedClass);
        }
        public User obtenerUsuario(string user)
        {
            List<Projects> p = new List<Projects>();
            string res = RunApi("users?username=" + user);
            List<User> myDeserializedClass = JsonConvert.DeserializeObject<List<User>>(res);
            return myDeserializedClass[0];
        }
        public List<Notas> obtenerNotasFromMerge(int projectid,int mergeid)
        {
            List<Notas> p = new List<Notas>();
            string res = RunApi("projects/"+projectid+"/merge_requests/"+mergeid+"/notes");
            List<Notas> myDeserializedClass = JsonConvert.DeserializeObject<List<Notas>>(res);
            return myDeserializedClass;
        }
        public List<Notas> obtenerNotasFromIssue(int projectid, int issueid)
        {
            List<Notas> p = new List<Notas>();
            string res = RunApi("projects/" + projectid + "/issues/" + issueid + "/notes");
            List<Notas> myDeserializedClass = JsonConvert.DeserializeObject<List<Notas>>(res);
            return myDeserializedClass;
        }
        public List<Merges> obtenerMergesAbiertos(int userid)
        {
            string res = RunApi("merge_requests?scope=all&state=opened&per_page=1000&author_id=" + userid);
            List<Merges> myDeserializedClass = JsonConvert.DeserializeObject<List<Merges>>(res,settings);
            return myDeserializedClass;
        }
        public List<Merges> obtenerMergesAprovadosPor(int userid) {
            List<Merges> p = new List<Merges>();
            string res = RunApi("merge_requests?scope=all&per_page=1000&approved_by_ids[]=" + userid);
            List<Merges> myDeserializedClass = JsonConvert.DeserializeObject<List<Merges>>(res);
            return myDeserializedClass;
        }
        public List<Issue> obtenerIssues (string userid)
        {
            List<Issue> p = new List<Issue>();
            string res = RunApi("issues?assignee_id="+userid+ "&state=opened&scope=all&per_page=1000");
            List<Issue> myDeserializedClass = JsonConvert.DeserializeObject<List<Issue>>(res);
            return myDeserializedClass;
        }
        public List<Issue> obtenerIssuesCerrados(string userid)
        {
            List<Issue> p = new List<Issue>();
            string res = RunApi("issues?assignee_id=" + userid + "&scope=all&state=closed&per_page=1000");
            List<Issue> myDeserializedClass = JsonConvert.DeserializeObject<List<Issue>>(res);
            return myDeserializedClass;
        }
        public add_spend_time agregarSpend(int idProyecto,int idIssue, string duracion, string creado_en, string comentario = "") {
            string res = RunApiPOST("projects/"+ idProyecto + "/issues/"+ idIssue + "/add_spent_time?duration="+duracion+ "&summary="+comentario+ "&created_at="+creado_en);
            add_spend_time myDeserializedClass = JsonConvert.DeserializeObject<add_spend_time>(res);
            return myDeserializedClass;
        }


        private string RunApiPOST(string comando) {
            var client = new TinyRestClient(new HttpClient(), General.configuracion.API_URL);
            string res = client.PostRequest(comando).
                          AddHeader("PRIVATE-TOKEN", General.configuracion.PRIVATE_TOKEN).
                          FillResponseHeaders(out Headers h).
                          ExecuteAsStringAsync().Result;
            headers = h;
            Console.WriteLine(res);
            return res;
        }
        private string RunApi(string comando)
        {

            var client = new TinyRestClient(new HttpClient(), General.configuracion.API_URL);
            string res = client.GetRequest(comando).
                          AddHeader("PRIVATE-TOKEN", General.configuracion.PRIVATE_TOKEN).
                          FillResponseHeaders(out Headers h).
                          ExecuteAsStringAsync().Result;
            headers = h;
            
            return res;
       
        }
        public string getHeaderResponse(string h) {
            foreach (var cabezera in headers) {
                foreach (var item in cabezera.Value)
                {
                    if (cabezera.Key == h) {
                        return item;
                    }
                }
            }
            return "";
        }




    }
}
