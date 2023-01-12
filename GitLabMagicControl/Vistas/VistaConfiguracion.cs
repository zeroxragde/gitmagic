using GitLabMagicControl.Clases;
using GitLabMagicControl.Controladores;
using System;

using System.Windows.Forms;

namespace GitLabMagicControl.Vistas
{
    public partial class VistaConfiguracion : IForms
    {
        public VistaConfiguracion()
        {
            InitializeComponent();
            ChangeTemaControls();
            txtToken.Text = General.configuracion.PRIVATE_TOKEN;
            txtUser.Text = General.configuracion.USERNAME;
            txtUrl.Text = General.configuracion.API_URL;
            dateTimePicker1.Text= General.configuracion.HORA_RECORDATORIO_SPEND;
            if (General.configuracion.TEMA=="1")
            {
                rb1.Checked = true;
            }
            if (General.configuracion.TEMA == "2")
            {
                rb2.Checked = true;
            }
    
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;
        }

        private void btnShowHideToken_Click(object sender, EventArgs e)
        {
    
            if (btnShowHideToken.ImageIndex == 1) {
                btnShowHideToken.ImageIndex = 0;
                btnShowHideToken.ImageList = imageList1;
                txtToken.PasswordChar = '\0';
            }
            else
            {
                btnShowHideToken.ImageIndex = 1;
                txtToken.PasswordChar = '*';
            }
        }

        private void VistaConfiguracion_Load(object sender, EventArgs e)
        {
            btnShowHideToken.ImageIndex = 1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            General.configuracion.API_URL = txtUrl.Text;
            General.configuracion.PRIVATE_TOKEN = txtToken.Text;
            General.configuracion.USERNAME = txtUser.Text;
            General.configuracion.HORA_RECORDATORIO_SPEND = dateTimePicker1.Text;
           
            if (txtUser.Text == "") {
                MessageBox.Show("Se necesita ingresar un usuario...","GitLabMagicControl",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            General.usuario = General.api.obtenerUsuario(txtUser.Text);
            if (General.usuario.name == "") {
                MessageBox.Show("Se necesita ingresar un usuario valido al que pertenezca el token...", "GitLabMagicControl", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (rb1.Checked) {
                General.configuracion.TEMA = "1";
            }
            if (rb2.Checked) {
                General.configuracion.TEMA = "2";
            }
            if (General.saveConfig()) {
                MessageBox.Show(this,"Se guardo la configuracion","GitLabMagicControl",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }
    }
}
