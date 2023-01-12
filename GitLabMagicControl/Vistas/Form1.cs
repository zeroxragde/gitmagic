using GitLabMagicControl.Clases;
using GitLabMagicControl.Controladores;
using GitLabMagicControl.Modelos;
using GitLabMagicControl.Modelos.GItlab;
using GitLabMagicControl.Vistas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GitLabMagicControl
{
    public partial class Form1 : IForms
    {
        private Point panel_activo_position = new Point(3, 54);
        private Dictionary<int,string> listas = new Dictionary<int, string>();
        public Form1()
        {
            InitializeComponent();
            ChangeTemaControls();

            if (int.Parse(General.configuracion.PANEL) > 1)
            {
                btnPrevList.Enabled = true;
                btnNextList.Enabled = false;
            }
            else
            {
                btnPrevList.Enabled = false;
                btnNextList.Enabled = true;
            }
          
            Size = new Size(216, 650);
            int x = 1;
            foreach (Control c in Controls)
            {
                if (c is Panel)
                {
                    listas.Add(x, c.Tag.ToString());
                    x++;
                }
            }
            activarList(int.Parse(General.configuracion.PANEL));

        }
        private void activarList(int tagname) {
            string tagid = listas[tagname];
            foreach (Control c in Controls) {
                if (c is Panel) {
                    if (tagid == c.Tag.ToString())
                    {
                        c.Location = panel_activo_position;
                        c.Visible = true;
                        lblTitulo.Text = c.Tag.ToString();
                    }
                    else {
                        c.Location = panel_activo_position;
                        c.Visible = false;
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
          
            int taks_s = Screen.PrimaryScreen.Bounds.Bottom - Screen.PrimaryScreen.WorkingArea.Bottom;
            int y = (Screen.PrimaryScreen.Bounds.Bottom - taks_s)-(Size.Height);
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Right-Size.Width, y);
            General.getAllProjects();
            General.getAllIssues();
            General.getAllMergeOpen();
            ReloadGrids();
            lvlProjects.Columns[0].Width = lvlProjects.Width - 4 - SystemInformation.VerticalScrollBarWidth;

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            else {
                WindowState = FormWindowState.Normal;
            }
            
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            VistaConfiguracion config_view = new VistaConfiguracion();
            config_view.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
          
        private void ReloadGrids()
        {
            lvlProjects.Items.Clear();
            foreach (Projects proyecto in General.all_proyectos)
            {
                ListViewItem itm = new ListViewItem(proyecto.name);
                itm.ImageIndex = 0;
                itm.StateImageIndex = 0;
                if (!lvlProjects.Items.Contains(itm))
                {
                    lvlProjects.Items.Add(itm);
                }
            }

            lvIssues.Items.Clear();
            foreach (Issue issue in General.all_issues)
            {
                ListViewItem itm = new ListViewItem(issue.title);
                itm.ImageIndex = 0;
                itm.StateImageIndex = 0;
                if (!lvIssues.Items.Contains(itm))
                {
                    lvIssues.Items.Add(itm);
                }
            }

            lvMergeRequest.Items.Clear();
            foreach (Merges merge in General.all_merges_open)
            {
                ListViewItem itm = new ListViewItem(merge.title);
                itm.ImageIndex = 0;
                itm.StateImageIndex = 0;
                if (!lvMergeRequest.Items.Contains(itm))
                {
                    lvMergeRequest.Items.Add(itm);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string hourMinute = DateTime.Now.ToString("hh:mm:ss tt");
            if (hourMinute == General.configuracion.HORA_RECORDATORIO_SPEND) {
                SpendControl s = new SpendControl();
                s.ShowDialog();
            }
        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnNextList_Click(object sender, EventArgs e)
        {
            General.configuracion.PANEL = (int.Parse(General.configuracion.PANEL) + 1).ToString();

            if (int.Parse(General.configuracion.PANEL) == listas.Count) {
                btnNextList.Enabled = false;
                btnPrevList.Enabled = true;
            }
            
            activarList(int.Parse(General.configuracion.PANEL));
            General.saveConfig();
        }

        private void btnPrevList_Click(object sender, EventArgs e)
        {
            General.configuracion.PANEL = (int.Parse(General.configuracion.PANEL) - 1).ToString();
            if (int.Parse(General.configuracion.PANEL) == 1) {
                btnPrevList.Enabled = false;
                btnNextList.Enabled = true;
            }
           
            activarList(int.Parse(General.configuracion.PANEL));
            General.saveConfig();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            ReporteMensual repo = new ReporteMensual();
            repo.ShowDialog();
        }

        private void btnIssues_Click(object sender, EventArgs e)
        {
            VerIssues v = new VerIssues();
            v.ShowDialog();
        }

        private void btnTiempoSpend_Click(object sender, EventArgs e)
        {
            SpendControl s = new SpendControl();
            s.ShowDialog();
        }
    }
}
