
namespace GitLabMagicControl.Vistas
{
    partial class SpendControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpendControl));
            this.lblDescripcion = new System.Windows.Forms.WebBrowser();
            this.cbMinutos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbHoras = new System.Windows.Forms.ComboBox();
            this.cbIssues = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(16, 66);
            this.lblDescripcion.MinimumSize = new System.Drawing.Size(20, 20);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(543, 396);
            this.lblDescripcion.TabIndex = 15;
            // 
            // cbMinutos
            // 
            this.cbMinutos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMinutos.FormattingEnabled = true;
            this.cbMinutos.Location = new System.Drawing.Point(102, 505);
            this.cbMinutos.Name = "cbMinutos";
            this.cbMinutos.Size = new System.Drawing.Size(62, 27);
            this.cbMinutos.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 508);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Minutos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 471);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Horas";
            // 
            // cbHoras
            // 
            this.cbHoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHoras.FormattingEnabled = true;
            this.cbHoras.Location = new System.Drawing.Point(102, 468);
            this.cbHoras.Name = "cbHoras";
            this.cbHoras.Size = new System.Drawing.Size(63, 27);
            this.cbHoras.TabIndex = 7;
            // 
            // cbIssues
            // 
            this.cbIssues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIssues.FormattingEnabled = true;
            this.cbIssues.Location = new System.Drawing.Point(13, 33);
            this.cbIssues.Name = "cbIssues";
            this.cbIssues.Size = new System.Drawing.Size(546, 27);
            this.cbIssues.TabIndex = 6;
            this.cbIssues.SelectedIndexChanged += new System.EventHandler(this.cbIssues_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Seleccionar Issue";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(362, 475);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 57);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(469, 475);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(90, 57);
            this.btnRemove.TabIndex = 16;
            this.btnRemove.Text = "Quitar";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtSummary
            // 
            this.txtSummary.Location = new System.Drawing.Point(28, 576);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(531, 115);
            this.txtSummary.TabIndex = 17;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(102, 543);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(98, 27);
            this.dtpFecha.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 543);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Fecha";
            // 
            // SpendControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 703);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.cbMinutos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbHoras);
            this.Controls.Add(this.cbIssues);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdd);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpendControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpendControl";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SpendControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbIssues;
        private System.Windows.Forms.ComboBox cbHoras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMinutos;
        private System.Windows.Forms.WebBrowser lblDescripcion;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label4;
    }
}