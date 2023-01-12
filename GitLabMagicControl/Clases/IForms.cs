using GitLabMagicControl.Controladores;
using System.Drawing;
using System.Windows.Forms;

namespace GitLabMagicControl.Clases
{
    public class IForms : Form
    {

        public IForms(){
           
   
        }
        public void ChangeTemaControls() {
            if (General.configuracion == null)
            {
                General.ChangeBG(this, Color.White);
            }
            else
            {
                if (General.configuracion.TEMA == "1" || General.configuracion.TEMA == null || General.configuracion.TEMA == "")
                {
                    General.ChangeBG(this, Color.White);
                    this.ForeColor = Color.Black;
                    foreach (Control control in this.Controls)
                    {
                        if (control.Controls.Count > 0) {
                            foreach (Control ctr in control.Controls) {
                                ctr.BackColor = Color.White;
                                ctr.ForeColor = Color.Black;
                            }
                        }
                        control.BackColor = Color.White;
                        control.ForeColor = Color.Black;
                    }
                }
                else
                {
                    General.ChangeBG(this, Color.Black);
                    this.ForeColor = Color.White;
                    foreach (Control control in this.Controls)
                    {
                        if (control is Panel && control.Controls.Count>0)
                        {
                            foreach (Control ctr in control.Controls)
                            {

                                ctr.BackColor = Color.Black;
                                ctr.ForeColor = Color.White;
                            }
                        }
                        control.BackColor = Color.Black;
                        control.ForeColor = Color.White;
                    }
                }
            }
  
        }



    }
}
