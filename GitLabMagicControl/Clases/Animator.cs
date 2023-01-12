using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitLabMagicControl.Clases
{
    public partial class Animator : UserControl
    {
        bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
        ImageList _frames;
        [Browsable(true), Description("Selecciona el imagenlist que contenga las imagenes de la animacion")]
        [Category("Personalizar")]
        // [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]//SIn esto no se guarda en modo build

        public ImageList Frames
        {
            get
            {
                return _frames;
            }
            set
            {
                _frames = value;
           
            }
        }
        private int frame_actual = 0;
        public Animator()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!designMode)
            {
                if (_frames.Images.Count > 0)
                {
                    pbFrame.Image = _frames.Images[frame_actual];
                    frame_actual++;
                    if (frame_actual == _frames.Images.Count)
                    {
                        frame_actual = 0;
                    }
                }
            }
            else {
                pbFrame.Image = _frames.Images[0];
            }

        }
    }
}
