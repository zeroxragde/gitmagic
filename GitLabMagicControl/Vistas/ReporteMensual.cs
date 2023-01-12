using GitLabMagicControl.Controladores;
using GitLabMagicControl.Modelos;
using GitLabMagicControl.Modelos.GItlab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace GitLabMagicControl.Vistas
{
    public partial class ReporteMensual : Form
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

        public ReporteMensual()
        {
            InitializeComponent();
            filter_horas = new Regex(regex_horas);
            filter_fecha = new Regex(regex_fecha);
            filter_subhoras = new Regex(regex_subhora);
            dgvReporte.Size = panel1.Size;
            dgvReporte.Location = new Point(0,0);
            General.getAllIssues();

        }

        private void ReporteMensual_Load(object sender, EventArgs e)
        {
            dtInicial.CustomFormat = "yyyy-MM-dd";
            dtFinal.CustomFormat = "yyyy-MM-dd";

            DateTime fechaActual = DateTime.Now;
            int diasARestar = fechaActual.Day - 1;
            dtInicial.Value = fechaActual.AddDays(-diasARestar);
            th1 = new Thread(new ThreadStart(initReporte));
            th1.Start();
            btnVer.Enabled = false;
        }
        public void getHorasFromIssues()
        {

            DateTime oDate_init = dtInicial.Value;
            DateTime oDate_final = dtFinal.Value;

            foreach (Issue issue in General.all_issues)
            {
                List<Notas> notas = new List<Notas>();
                notas = General.api.obtenerNotasFromIssue(issue.project_id, issue.iid);
                var inotas = notas.Where(o => o.author.id == General.usuario.id);
                foreach (Notas nota in inotas)
                {
                    var match = filter_fecha.Match(nota.body.ToString());
                    var match_horas = filter_horas.Match(nota.body.ToString());
                    var match_horas_sub = filter_subhoras.Match(nota.body.ToString());

                    string fecha = "";
                    if (match.Success)
                    {
                        if (match_horas.Success)
                        {
                            fecha = match.Value;
                        }
                        else {
                            fecha = nota.created_at.ToString("yyyy-MM-dd");
                        }
                    }
                    else
                    {
                        continue;
                    }
                    DateTime fecha_rev = Convert.ToDateTime(fecha);
                    if (fecha_rev.Ticks > oDate_init.Ticks && fecha_rev.Ticks < oDate_final.Ticks)
                    {
                                ReporteMensualData tmp = new ReporteMensualData()
                                {
                                    Tipo = "ISSUE",
                                    Nombre = issue.title,
                                    Fecha = fecha,
                                    Horas = "0",
                                    Minutos = "0"
                                };
                        string[] datos = null;
                        if (match_horas.Success)
                        {
                            datos = match_horas.Value.Split(' ');
                        }
                        else {
                            datos = match_horas_sub.Value.Split(' ');
                        }
                                
                               
                                Regex filter_hora_min = new Regex(patter);

                                foreach (string d in datos)
                                {
                                    var match_horas_filtrado = filter_hora_min.Match(d);
                                    if (match_horas_filtrado.Success)
                                    {
                                       if (d.IndexOf("d") > -1){
                                            int val = int.Parse(match_horas_filtrado.Value) * 8;
                                            string valor = val.ToString();
                                            if (nota.body.IndexOf("subtracted") > -1)
                                            {
                                                valor = "-" + valor;
                                            }
                                            tmp.Horas = valor;
                                        }
                                        if (d.IndexOf("h") > -1)
                                        {
                                            string valor = match_horas_filtrado.Value;
                                            if (nota.body.IndexOf("subtracted") > -1) {
                                               valor = "-" + match_horas_filtrado.Value;
                                            }
                                            tmp.Horas = valor;
                                        }
                                        if (d.IndexOf("m") > -1)
                                        {
                                            string valor = match_horas_filtrado.Value;
                                            if (nota.body.IndexOf("subtracted") > -1)
                                            {
                                                valor = "-" + match_horas_filtrado.Value;
                                            }
                                            tmp.Minutos = valor;
                                        }
                                        tmp.WebUrl = issue.web_url;
                                        tmp.TiempoInvertido = (int.Parse(tmp.Horas) + (int.Parse(tmp.Minutos) * 0.0166667)).ToString();
                                       
                                    }
                                }
                                data.Add(tmp);
                        }
                        
                    
                }
            }
        }
        public void getHorasFromIssuesClose() {

            DateTime oDate_init = dtInicial.Value;
            DateTime  oDate_final = dtFinal.Value;

            List<Issue> issues = General.api.obtenerIssuesCerrados(General.usuario.id.ToString());
            foreach (Issue issue in issues) {
                List<Notas> notas = new List<Notas>();
                notas = General.api.obtenerNotasFromIssue(issue.project_id, issue.iid);
                if (issue.iid == 394) {
                    Console.WriteLine("holi");
                }
                var inotas = notas.Where(o => o.author.id == General.usuario.id);
                foreach (Notas nota in inotas)
                {
                   
                    var match_horas = filter_horas.Match(nota.body.ToString());
                    var match = filter_fecha.Match(nota.body.ToString());
                    var match_horas_sub = filter_subhoras.Match(nota.body.ToString());

                        string fecha = "";
                        if (match.Success)
                        {
                            fecha = match.Value;
                        }
                        else
                        {
                            fecha = nota.created_at.ToString("yyyy-MM-dd");
                        }
                        DateTime fecha_rev = Convert.ToDateTime(fecha);
                        if (fecha_rev.Ticks > oDate_init.Ticks && fecha_rev.Ticks < oDate_final.Ticks)
                            {

                            ReporteMensualData tmp = new ReporteMensualData()
                                {
                                    Tipo = "ISSUE CLOSE",
                                    Nombre = issue.title,
                                    Fecha = fecha,
                                    Horas = "0",
                                    Minutos = "0"
                                };

                        string[] datos = null;
                        if (match_horas.Success)
                        {
                            datos = match_horas.Value.Split(' ');
                        }
                        else
                        {
                            datos = match_horas_sub.Value.Split(' ');
                        }
                       
                                Regex filter_hora_min = new Regex(patter);
                                int c = 0;

                                foreach (string d in datos) {
                                    var match_horas_filtrado = filter_hora_min.Match(d);
                                    if (match_horas_filtrado.Success) {

                                         if (d.IndexOf("d") > -1)
                                            {
                                                int val = int.Parse(match_horas_filtrado.Value) * 8;
                                                string valor = val.ToString();
                                                if (nota.body.IndexOf("subtracted") > -1)
                                                {
                                                    valor = "-" + valor;
                                                }
                                                tmp.Horas = valor;
                                            }

                                        if (d.IndexOf("h") > -1) {
                                            string valor = match_horas_filtrado.Value;
                                            if (nota.body.IndexOf("subtracted") > -1)
                                            {
                                                valor = "-" + match_horas_filtrado.Value;
                                            }
                                            tmp.Horas = valor;
                                        }
                                        if (d.IndexOf("m") > -1)
                                        {
                                            string valor = match_horas_filtrado.Value;
                                            if (nota.body.IndexOf("subtracted") > -1)
                                            {
                                                valor = "-" + match_horas_filtrado.Value;
                                            }
                                            tmp.Minutos = valor;
                                        }
                                        tmp.WebUrl = issue.web_url;
                                        tmp.TiempoInvertido = (int.Parse(tmp.Horas) + (int.Parse(tmp.Minutos) * 0.0166667)).ToString();
                                        c++;
                                        if (datos.Length == c) {
                                            data.Add(tmp);
                                        }
                                    }
                                }
                            }
                        
                    
                }
            }
        }
        public void getHorasFromReviews() {
            merges = General.api.obtenerMergesAprovadosPor(General.usuario.id);

            DateTime oDate_init = dtInicial.Value;
            DateTime oDate_final = dtFinal.Value;
            foreach (Merges merge in merges)
            {
                List<Notas> notas = new List<Notas>();
                notas = General.api.obtenerNotasFromMerge(merge.project_id, merge.iid);
                var inotas = notas.Where(o => o.author.id == General.usuario.id);
                foreach (Notas nota in inotas)
                {
                    var match_horas = filter_horas.Match(nota.body.ToString());
                    var match = filter_fecha.Match(nota.body.ToString());
                    var match_horas_sub = filter_subhoras.Match(nota.body.ToString());

                    if (match_horas.Success)
                    {
                        string fecha = "";
                        if (match.Success)
                        {
                            fecha = match.Value;
                        }
                        else
                        {
                            fecha = nota.created_at.ToString("yyyy-MM-dd");
                        }
                        DateTime fecha_rev = Convert.ToDateTime(fecha); 
                        if (fecha_rev.Ticks > oDate_init.Ticks && fecha_rev.Ticks < oDate_final.Ticks)
                        {
                            ReporteMensualData tmp = new ReporteMensualData()
                            {
                                Tipo = "REVIEW",
                                Nombre = merge.title,
                                Fecha = fecha,
                                Horas = "0",
                                Minutos = "0"
                            };
                            string[] datos = null;
                            if (match_horas.Success)
                            {
                                datos = match_horas.Value.Split(' ');
                            }
                            else
                            {
                                datos = match_horas_sub.Value.Split(' ');
                            }
                           
                            Regex filter_hora_min = new Regex(patter);

                            foreach (string d in datos)
                            {
                                var match_horas_filtrado = filter_hora_min.Match(d);
                                if (match_horas_filtrado.Success)
                                {

                                    if (d.IndexOf("d") > -1)
                                    {
                                        int val = int.Parse(match_horas_filtrado.Value) * 8;
                                        string valor = val.ToString();
                                        if (nota.body.IndexOf("subtracted") > -1)
                                        {
                                            valor = "-" + valor;
                                        }
                                        tmp.Horas = valor;
                                    }
                                    if (d.IndexOf("h") > -1)
                                    {
                                        string valor = match_horas_filtrado.Value;
                                        if (nota.body.IndexOf("subtracted") > -1)
                                        {
                                            valor = "-" + match_horas_filtrado.Value;
                                        }
                                        tmp.Horas = valor;
                                    }
                                    if (d.IndexOf("m") > -1)
                                    {
                                        string valor = match_horas_filtrado.Value;
                                        if (nota.body.IndexOf("subtracted") > -1)
                                        {
                                            valor = "-" + match_horas_filtrado.Value;
                                        }
                                        tmp.Minutos = valor;
                                    }
                                    tmp.TiempoInvertido = (int.Parse(tmp.Horas) + (int.Parse(tmp.Minutos) * 0.0166667)).ToString();
                                    data.Add(tmp);
                                }
                            }
                        }
                    }
                }
            }
        }

    

        private void initReporte() {
            getHorasFromIssuesClose();
            getHorasFromIssues();
            getHorasFromReviews();
            try { 
                 Invoke(new MethodInvoker(() => {
                     float total_tiempo = 0;
                     float total_horas  = 0;
                     foreach (ReporteMensualData item in data) {
                         total_tiempo += float.Parse(item.TiempoInvertido);
                         total_horas += float.Parse(item.Horas);
                     }
                     data.Add(new ReporteMensualData() { 
                         TiempoInvertido = total_tiempo.ToString(),
                         Horas = total_horas.ToString()
                     });;


                     dgvReporte.DataSource = new BindingSource
                    {
                        DataSource = data
                    };
                    foreach (DataGridViewColumn c in dgvReporte.Columns)
                    {
                        c.Visible = true;
                        c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        c.ReadOnly = true;
                         if (c.HeaderText == "TiempoInvertido") {
                             c.HeaderText = "Tiempo Invertido (Horas)";
                         }
                    }


                     btnVer.Enabled = true;
                 }));           
            } catch { 
            
            }


        }

        private void ReporteMensual_SizeChanged(object sender, EventArgs e)
        {
            dgvReporte.Size = panel1.Size;
        }

  

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteMensual));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dvTotales = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtInicial = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFinal = new System.Windows.Forms.DateTimePicker();
            this.btnVer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvTotales)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dvTotales, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.425703F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1067, 613);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dvTotales
            // 
            this.dvTotales.AllowUserToAddRows = false;
            this.dvTotales.AllowUserToDeleteRows = false;
            this.dvTotales.AllowUserToOrderColumns = true;
            this.dvTotales.AllowUserToResizeColumns = false;
            this.dvTotales.AllowUserToResizeRows = false;
            this.dvTotales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvTotales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvTotales.Location = new System.Drawing.Point(4, 569);
            this.dvTotales.Margin = new System.Windows.Forms.Padding(4);
            this.dvTotales.MultiSelect = false;
            this.dvTotales.Name = "dvTotales";
            this.dvTotales.ReadOnly = true;
            this.dvTotales.RowHeadersWidth = 51;
            this.dvTotales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvTotales.Size = new System.Drawing.Size(1059, 40);
            this.dvTotales.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.dtInicial);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.dtFinal);
            this.flowLayoutPanel1.Controls.Add(this.btnVer);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 12);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(13, 12, 13, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1041, 62);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Inicial:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtInicial
            // 
            this.dtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInicial.Location = new System.Drawing.Point(171, 19);
            this.dtInicial.Margin = new System.Windows.Forms.Padding(4);
            this.dtInicial.Name = "dtInicial";
            this.dtInicial.Size = new System.Drawing.Size(129, 22);
            this.dtInicial.TabIndex = 0;
            this.dtInicial.Value = new System.DateTime(2022, 12, 1, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(308, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha Final:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtFinal
            // 
            this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFinal.Location = new System.Drawing.Point(443, 19);
            this.dtFinal.Margin = new System.Windows.Forms.Padding(4);
            this.dtFinal.Name = "dtFinal";
            this.dtFinal.Size = new System.Drawing.Size(129, 22);
            this.dtFinal.TabIndex = 1;
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(580, 19);
            this.btnVer.Margin = new System.Windows.Forms.Padding(4);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(64, 25);
            this.btnVer.TabIndex = 4;
            this.btnVer.Text = "Ver";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvReporte);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 84);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1059, 477);
            this.panel1.TabIndex = 3;
            // 
            // dgvReporte
            // 
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            this.dgvReporte.AllowUserToOrderColumns = true;
            this.dgvReporte.AllowUserToResizeColumns = false;
            this.dgvReporte.AllowUserToResizeRows = false;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(46, 40);
            this.dgvReporte.Margin = new System.Windows.Forms.Padding(4);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.RowHeadersWidth = 51;
            this.dgvReporte.Size = new System.Drawing.Size(280, 158);
            this.dgvReporte.TabIndex = 1;
            this.dgvReporte.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReporte_CellClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Black;
            this.imageList1.Images.SetKeyName(0, "frame_0_delay-0.08s.gif");
            this.imageList1.Images.SetKeyName(1, "frame_1_delay-0.08s.gif");
            this.imageList1.Images.SetKeyName(2, "frame_2_delay-0.08s.gif");
            this.imageList1.Images.SetKeyName(3, "frame_3_delay-0.08s.gif");
            this.imageList1.Images.SetKeyName(4, "frame_4_delay-0.08s.gif");
            this.imageList1.Images.SetKeyName(5, "frame_5_delay-0.08s.gif");
            this.imageList1.Images.SetKeyName(6, "frame_6_delay-0.08s.gif");
            this.imageList1.Images.SetKeyName(7, "frame_7_delay-0.08s.gif");
            // 
            // ReporteMensual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 613);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReporteMensual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Mensual";
            this.Load += new System.EventHandler(this.ReporteMensual_Load);
            this.SizeChanged += new System.EventHandler(this.ReporteMensual_SizeChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvTotales)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);

        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            dgvReporte.Rows.Clear();
            th1 = new Thread(new ThreadStart(initReporte));
            th1.Start();
        }

        private void dgvReporte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string cellValue = dgvReporte.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                Clipboard.SetText(cellValue);
            }
        }
    }
}
