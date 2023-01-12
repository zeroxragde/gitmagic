using GitLabMagicControl.Clases;
using GitLabMagicControl.Controladores;
using GitLabMagicControl.Modelos.GItlab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Markdig;
using HtmlAgilityPack;

namespace GitLabMagicControl.Vistas
{
    public partial class SpendControl : IForms
    {
        private Dictionary<int, string> data = new Dictionary<int, string>();
        public SpendControl()
        {
            InitializeComponent();
            ChangeTemaControls();
            lblDescripcion.BackColor = Color.FromArgb(64, 0, 0);
            lblDescripcion.ForeColor = Color.White;
            Text = General.usuario.name+" - SpendTime";
            int horas_max = 12;
            int min_max = 59;
            Dictionary<int, int> horas = new Dictionary<int, int>();
            for (int x=0; x <= horas_max; x++) {
                horas.Add(x,x);
            }
            cbHoras.DataSource = new BindingSource(horas, null);
            cbHoras.DisplayMember = "Value";
            cbHoras.ValueMember = "Key";


            Dictionary<int, int> minutos = new Dictionary<int, int>();
            for (int x = 0; x <= min_max; x++)
            {
                minutos.Add(x, x);
            }
            cbMinutos.DataSource = new BindingSource(minutos, null);
            cbMinutos.DisplayMember = "Value";
            cbMinutos.ValueMember = "Key";
        }

        private void SpendControl_Load(object sender, EventArgs e)
        {
            data.Add(0, "Seleccionar");
            foreach (Issue p in General.all_issues) {
                data.Add(p.id,p.title);
            }
            cbIssues.DataSource = new BindingSource(data, null);
            cbIssues.DisplayMember = "Value";
            cbIssues.ValueMember = "Key";
            lblDescripcion.IsWebBrowserContextMenuEnabled = false;
            lblDescripcion.AllowWebBrowserDrop = false;
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "yyyy-MM-dd";
            dtpFecha.Value = DateTime.Now.Date;
        }

        private void cbIssues_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Issue p in General.all_issues)
            {
                if (cbIssues.SelectedValue.ToString()==p.id.ToString()) {
          
                    File.WriteAllText(General.AppPath + @"\tmp.txt", p.description);
                    int posextract = p.web_url.IndexOf('-');

                    string url_img = p.web_url.Substring(0,posextract);
                    // Configure the pipeline with all advanced extensions active
                    var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
                    var result = Markdown.ToHtml(p.description, pipeline);
                    result.Replace(@"\n", "<br>");

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    string estructura = "<html><head></head><body><div id='titulo'></div>"+result+"</body></html>";
                    doc.LoadHtml(estructura);

                    HtmlNode body = doc.DocumentNode.SelectSingleNode("//body//div[contains(@id, 'titulo')]");
                    HtmlNode div = doc.CreateElement("h1");
                             div.InnerHtml = p.title;
                             div.Attributes.Add("style","font-family:arial;");
                    body.AppendChild(div);

                    HtmlNodeCollection imgs = doc.DocumentNode.SelectNodes("//img");
                    if (imgs != null) {
                        foreach (HtmlNode el in imgs)
                        {
                            string src = el.Attributes["src"].Value;
                            el.SetAttributeValue("src", url_img + "/" + src);
                            el.SetAttributeValue("width", "128px");
                            el.SetAttributeValue("height", "128px");
                            el.WriteTo();
                        }
                    }

                    string newHtml = doc.DocumentNode.WriteTo();
                    lblDescripcion.DocumentText = newHtml;

                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((cbHoras.SelectedValue.ToString() == "0" && cbMinutos.SelectedValue.ToString() == "0") || cbIssues.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Debes ingresar las horas o minutos que trabajaste y seleccionar un ISSUE", "GitLabMagicControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                foreach (Issue p in General.all_issues)
                {
                    if (cbIssues.SelectedValue.ToString() == p.id.ToString())
                    {
                        string horas = cbHoras.SelectedValue.ToString();
                        if (horas != "0") {
                            horas = horas + "h";
                        }
                        else {
                            horas = "";
                        }
                        
                        string minutos = cbMinutos.SelectedValue.ToString();
                        if (minutos != "0")
                        {
                            minutos = minutos + "m";
                        }
                        else {
                            minutos = "";
                        }
                        string duracion =horas+minutos;
                        DateTime date = DateTime.Now;
                        string iso8601Date = dtpFecha.Value.ToString("yyyy-MM-ddT12:00:00Z");
                     
                        try
                        {
                           add_spend_time Res = General.api.agregarSpend(p.project_id, p.iid, duracion, txtSummary.Text, iso8601Date);
                           TiempoInvertidoRespuesta win_res = new TiempoInvertidoRespuesta(Res);
                           win_res.ShowDialog();
                        }
                        catch {
                            MessageBox.Show("Error al agregar el tiempo", "GitLabMagicControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                       
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if ((cbHoras.SelectedValue.ToString() == "0" && cbMinutos.SelectedValue.ToString() == "0") || cbIssues.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Debes ingresar las horas o minutos que trabajaste y seleccionar un ISSUE", "GitLabMagicControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                foreach (Issue p in General.all_issues)
                {
                    if (cbIssues.SelectedValue.ToString() == p.id.ToString())
                    {
                        string horas = cbHoras.SelectedValue.ToString();
                        if (horas != "0")
                        {
                            horas = "-"+horas + "h";
                        }
                        else
                        {
                            horas = "";
                        }

                        string minutos = cbMinutos.SelectedValue.ToString();
                        if (minutos != "0")
                        {
                            minutos ="-" + minutos + "m";
                        }
                        else
                        {
                            minutos = "";
                        }
                        string duracion = horas + minutos;
                        try
                        {
                            add_spend_time Res = General.api.agregarSpend(p.project_id, p.iid, duracion, txtSummary.Text);
                            TiempoInvertidoRespuesta win_res = new TiempoInvertidoRespuesta(Res);
                            win_res.ShowDialog();
                        }
                        catch
                        {
                            MessageBox.Show("Error al agregar el tiempo", "GitLabMagicControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                }
            }
        }
    }
}
