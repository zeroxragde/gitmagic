using GitLabMagicControl.Controladores;
using GitLabMagicControl.Modelos;
using GitLabMagicControl.Modelos.GItlab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace GitLabMagicControl.Vistas
{
    public partial class VerIssues : Form
    {
        private List<Merges> merges = new List<Merges>();
        private List<List<Notas>> Merge_Notas = new List<List<Notas>>();
        private List<string> cols = new List<string>();
        private List<ReporteMensualData> data = new List<ReporteMensualData>();
        //subtracted 
        private string regex_horas = "(?<=added ).*?(?= of time)";
        private string regex_subhora = "(?<=subtracted ).*?(?= of time)";
        private Regex filter_subhoras;
        private Regex filter_horas;
        private string regex_fecha = "(?<=at ).*";
        private Regex filter_fecha;
        private string patter = @"(\d+(?=h|m|d))";
        private Thread th1;
        public VerIssues()
        {
            InitializeComponent();
            filter_horas = new Regex(regex_horas);
            filter_fecha = new Regex(regex_fecha);
            filter_subhoras = new Regex(regex_subhora);

        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            dtInicial.CustomFormat = "yyyy-MM-01";
            dtFinal.CustomFormat = "yyyy-MM-dd";
            DateTime fechaActual = DateTime.Now;
            int diasARestar = fechaActual.Day - 1;
            dtInicial.Value = fechaActual.AddDays(-diasARestar);
            th1 = new Thread(new ThreadStart(initReporte));
            th1.Start();
        }


        private void initReporte()
        {
            getHorasFromIssuesClose();
            getHorasFromIssues();
            try
            {
                Invoke(new MethodInvoker(() => {


                    dgData.DataSource = new BindingSource
                    {
                        DataSource = data
                    };

                    foreach (DataGridViewColumn c in dgData.Columns)
                    {
                        c.Visible = true;
                        c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        c.ReadOnly = true;
                    }
                    //btnVer.Enabled = true;
                }));
            }
            catch
            {

            }


        }

        public void getHorasFromIssues()
        {

            DateTime oDate_init = dtInicial.Value;
            DateTime oDate_final = dtFinal.Value;
            var issues_w = General.all_issues.Where(o => o.created_at.Ticks >= oDate_init.Ticks && o.created_at.Ticks <= oDate_final.Ticks);

            foreach (Issue issue in issues_w)
            {
                List<Notas> notas = new List<Notas>();
                notas = General.api.obtenerNotasFromIssue(issue.project_id, issue.iid);
                ReporteMensualData tmp = new ReporteMensualData()
                {
                    Tipo = "ISSUE",
                    Nombre = issue.title,
                    Fecha = issue.created_at.ToString(),
                    TiempoInvertido= (issue.time_stats.total_time_spent* 0.000277778).ToString(),
                    WebUrl = issue.web_url
                };
            }
        }
        public void getHorasFromIssuesClose()
        {

            DateTime oDate_init = dtInicial.Value;
            DateTime oDate_final = dtFinal.Value;

            List<Issue> issues = General.api.obtenerIssuesCerrados(General.usuario.id.ToString());
            var issues_w = issues.Where(o => o.created_at.Ticks >= oDate_init.Ticks && o.created_at.Ticks <= oDate_final.Ticks);

            foreach (Issue issue in issues_w)
            {
                ReporteMensualData tmp = new ReporteMensualData()
                {
                    Tipo = "ISSUE",
                    Nombre = issue.title,
                    Fecha = issue.created_at.ToString(),
                    TiempoInvertido = (issue.time_stats.total_time_spent * 0.000277778).ToString(),
                    WebUrl=issue.web_url
                };
                data.Add(tmp);
            }
        }
   
        private void VerIssues_Load(object sender, EventArgs e)
        {
            dtInicial.CustomFormat = "yyyy-MM-01";
            dtFinal.CustomFormat = "yyyy-MM-dd";

            th1 = new Thread(new ThreadStart(initReporte));
            th1.Start();
        }
    }
}
