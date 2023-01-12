using GitLabMagicControl.Modelos.GItlab;
using System.Windows.Forms;

namespace GitLabMagicControl.Vistas
{
    public partial class TiempoInvertidoRespuesta : Form
    {
        private add_spend_time respuesta;
        public TiempoInvertidoRespuesta(add_spend_time e)
        {
            InitializeComponent();
            respuesta = e;
        }

        private void TiempoInvertidoRespuesta_Load(object sender, System.EventArgs e)
        {
            try {
                label1.Text = label1.Text.Replace("{TE}",respuesta.time_estimate.ToString());
            } catch { label1.Text=label1.Text.Replace("{TE}", ""); }

            try {
                label2.Text = label2.Text.Replace("{TTG}", respuesta.total_time_spent.ToString());
            } catch { label2.Text= label2.Text.Replace("{TTG}", ""); }

            try {
                if (respuesta.human_time_estimate != null)
                {
                    label3.Text = label3.Text.Replace("{THE}", respuesta.human_time_estimate.ToString());
                }
                else {
                    label3.Text = label3.Text.Replace("{THE}", "");
                }
               
            } catch { label3.Text = label3.Text.Replace("{THE}", ""); }

            try {
                label4.Text = label4.Text.Replace("{THT}", respuesta.human_total_time_spent.ToString());
            } catch { label4.Text = label4.Text.Replace("{THT}", ""); }

        }
    }
}
