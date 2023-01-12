namespace GitLabMagicControl
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnConfig = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnOcultar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnNextList = new System.Windows.Forms.Button();
            this.btnPrevList = new System.Windows.Forms.Button();
            this.pProyectos = new System.Windows.Forms.Panel();
            this.lvlProjects = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pIssues = new System.Windows.Forms.Panel();
            this.lvIssues = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnReporte = new System.Windows.Forms.Button();
            this.pMerge = new System.Windows.Forms.Panel();
            this.lvMergeRequest = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnTiempoSpend = new System.Windows.Forms.Button();
            this.pProyectos.SuspendLayout();
            this.pIssues.SuspendLayout();
            this.pMerge.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfig
            // 
            this.btnConfig.ForeColor = System.Drawing.Color.Black;
            this.btnConfig.Location = new System.Drawing.Point(12, 518);
            this.btnConfig.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(256, 64);
            this.btnConfig.TabIndex = 0;
            this.btnConfig.Text = "Configuracion";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "GitLabMagicControl";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "LOGOGIT.png");
            // 
            // btnClose
            // 
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(12, 590);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 64);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "a_r.png");
            this.imageList2.Images.SetKeyName(1, "a_l.png");
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(67, 17);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(155, 28);
            this.lblTitulo.TabIndex = 7;
            this.lblTitulo.Text = "Proyectos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOcultar
            // 
            this.btnOcultar.ForeColor = System.Drawing.Color.Black;
            this.btnOcultar.Location = new System.Drawing.Point(148, 590);
            this.btnOcultar.Margin = new System.Windows.Forms.Padding(4);
            this.btnOcultar.Name = "btnOcultar";
            this.btnOcultar.Size = new System.Drawing.Size(124, 64);
            this.btnOcultar.TabIndex = 12;
            this.btnOcultar.Text = "Ocultar";
            this.btnOcultar.UseVisualStyleBackColor = true;
            this.btnOcultar.Click += new System.EventHandler(this.btnOcultar_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnNextList
            // 
            this.btnNextList.ForeColor = System.Drawing.Color.Black;
            this.btnNextList.ImageIndex = 0;
            this.btnNextList.ImageList = this.imageList2;
            this.btnNextList.Location = new System.Drawing.Point(229, 11);
            this.btnNextList.Margin = new System.Windows.Forms.Padding(4);
            this.btnNextList.Name = "btnNextList";
            this.btnNextList.Size = new System.Drawing.Size(43, 38);
            this.btnNextList.TabIndex = 6;
            this.btnNextList.UseVisualStyleBackColor = true;
            this.btnNextList.Click += new System.EventHandler(this.btnNextList_Click);
            // 
            // btnPrevList
            // 
            this.btnPrevList.ForeColor = System.Drawing.Color.Black;
            this.btnPrevList.ImageIndex = 1;
            this.btnPrevList.ImageList = this.imageList2;
            this.btnPrevList.Location = new System.Drawing.Point(16, 11);
            this.btnPrevList.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrevList.Name = "btnPrevList";
            this.btnPrevList.Size = new System.Drawing.Size(43, 38);
            this.btnPrevList.TabIndex = 5;
            this.btnPrevList.UseVisualStyleBackColor = true;
            this.btnPrevList.Click += new System.EventHandler(this.btnPrevList_Click);
            // 
            // pProyectos
            // 
            this.pProyectos.Controls.Add(this.lvlProjects);
            this.pProyectos.Location = new System.Drawing.Point(288, 57);
            this.pProyectos.Margin = new System.Windows.Forms.Padding(4);
            this.pProyectos.Name = "pProyectos";
            this.pProyectos.Size = new System.Drawing.Size(281, 452);
            this.pProyectos.TabIndex = 13;
            this.pProyectos.Tag = "Proyectos";
            this.pProyectos.Visible = false;
            // 
            // lvlProjects
            // 
            this.lvlProjects.BackColor = System.Drawing.Color.White;
            this.lvlProjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvlProjects.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvlProjects.ForeColor = System.Drawing.Color.Black;
            this.lvlProjects.FullRowSelect = true;
            this.lvlProjects.GridLines = true;
            this.lvlProjects.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvlProjects.HideSelection = false;
            this.lvlProjects.Location = new System.Drawing.Point(13, 20);
            this.lvlProjects.Margin = new System.Windows.Forms.Padding(4);
            this.lvlProjects.MultiSelect = false;
            this.lvlProjects.Name = "lvlProjects";
            this.lvlProjects.Size = new System.Drawing.Size(255, 408);
            this.lvlProjects.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvlProjects.TabIndex = 12;
            this.lvlProjects.UseCompatibleStateImageBehavior = false;
            this.lvlProjects.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 180;
            // 
            // pIssues
            // 
            this.pIssues.Controls.Add(this.lvIssues);
            this.pIssues.Location = new System.Drawing.Point(577, 57);
            this.pIssues.Margin = new System.Windows.Forms.Padding(4);
            this.pIssues.Name = "pIssues";
            this.pIssues.Size = new System.Drawing.Size(281, 452);
            this.pIssues.TabIndex = 14;
            this.pIssues.Tag = "Issues";
            this.pIssues.Visible = false;
            // 
            // lvIssues
            // 
            this.lvIssues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvIssues.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvIssues.FullRowSelect = true;
            this.lvIssues.GridLines = true;
            this.lvIssues.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvIssues.HideSelection = false;
            this.lvIssues.Location = new System.Drawing.Point(13, 20);
            this.lvIssues.Margin = new System.Windows.Forms.Padding(4);
            this.lvIssues.MultiSelect = false;
            this.lvIssues.Name = "lvIssues";
            this.lvIssues.Size = new System.Drawing.Size(255, 408);
            this.lvIssues.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvIssues.TabIndex = 12;
            this.lvIssues.UseCompatibleStateImageBehavior = false;
            this.lvIssues.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 180;
            // 
            // btnReporte
            // 
            this.btnReporte.ForeColor = System.Drawing.Color.Black;
            this.btnReporte.Location = new System.Drawing.Point(12, 662);
            this.btnReporte.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(256, 64);
            this.btnReporte.TabIndex = 15;
            this.btnReporte.Text = "Reporte Mensual";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // pMerge
            // 
            this.pMerge.Controls.Add(this.lvMergeRequest);
            this.pMerge.Location = new System.Drawing.Point(867, 57);
            this.pMerge.Margin = new System.Windows.Forms.Padding(4);
            this.pMerge.Name = "pMerge";
            this.pMerge.Size = new System.Drawing.Size(281, 452);
            this.pMerge.TabIndex = 15;
            this.pMerge.Tag = "Merges Req.";
            this.pMerge.Visible = false;
            // 
            // lvMergeRequest
            // 
            this.lvMergeRequest.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.lvMergeRequest.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMergeRequest.FullRowSelect = true;
            this.lvMergeRequest.GridLines = true;
            this.lvMergeRequest.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvMergeRequest.HideSelection = false;
            this.lvMergeRequest.Location = new System.Drawing.Point(13, 20);
            this.lvMergeRequest.Margin = new System.Windows.Forms.Padding(4);
            this.lvMergeRequest.MultiSelect = false;
            this.lvMergeRequest.Name = "lvMergeRequest";
            this.lvMergeRequest.Size = new System.Drawing.Size(255, 408);
            this.lvMergeRequest.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvMergeRequest.TabIndex = 12;
            this.lvMergeRequest.UseCompatibleStateImageBehavior = false;
            this.lvMergeRequest.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 180;
            // 
            // btnTiempoSpend
            // 
            this.btnTiempoSpend.ForeColor = System.Drawing.Color.Black;
            this.btnTiempoSpend.Location = new System.Drawing.Point(12, 734);
            this.btnTiempoSpend.Margin = new System.Windows.Forms.Padding(4);
            this.btnTiempoSpend.Name = "btnTiempoSpend";
            this.btnTiempoSpend.Size = new System.Drawing.Size(256, 64);
            this.btnTiempoSpend.TabIndex = 17;
            this.btnTiempoSpend.Text = "Declarar Tiempo";
            this.btnTiempoSpend.UseVisualStyleBackColor = true;
            this.btnTiempoSpend.Click += new System.EventHandler(this.btnTiempoSpend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 814);
            this.Controls.Add(this.btnTiempoSpend);
            this.Controls.Add(this.pMerge);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.pIssues);
            this.Controls.Add(this.pProyectos);
            this.Controls.Add(this.btnOcultar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnNextList);
            this.Controls.Add(this.btnPrevList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pProyectos.ResumeLayout(false);
            this.pIssues.ResumeLayout(false);
            this.pMerge.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnPrevList;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btnNextList;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnOcultar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pProyectos;
        private System.Windows.Forms.ListView lvlProjects;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel pIssues;
        private System.Windows.Forms.ListView lvIssues;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Panel pMerge;
        private System.Windows.Forms.ListView lvMergeRequest;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnTiempoSpend;
    }
    #endregion
}