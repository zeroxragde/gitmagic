using System;
using System.Drawing;
using System.Windows.Forms;

namespace GitLabMagicControl.Clases
{
    public class iButton:Button
    {
        private Color btnColor;
        private bool localChange = false;
        public iButton()
        {
            EnabledChanged += IButton_EnabledChanged;
            BackColorChanged += IButton_BackColorChanged;
            btnColor = BackColor;
            if (!Enabled)
            {
                BackColor = Color.Gray;
            }
        }

        private void IButton_BackColorChanged(object sender, EventArgs e)
        {
            if (!localChange)
            {
                btnColor = BackColor;
            }
            localChange = false;
        }

        private void IButton_EnabledChanged(object sender, EventArgs e)
        {
            localChange = true;
            if (Enabled)
            {
                BackColor = btnColor;
            }
            else
            {
                BackColor = Color.Gray;
            }

        }
    }
}
