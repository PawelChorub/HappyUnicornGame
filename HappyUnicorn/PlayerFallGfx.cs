using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyUnicorn
{
    public class PlayerFallGfx
    {
        private PictureBox fallGraphic;

        public void Initialize(PictureBox _fallGraphic)
        {
            fallGraphic = _fallGraphic;
        }

        public void ViewFallGraphic(object sender, EventArgs e)
        {
            fallGraphic.Visible = true;
        }
        public void HideFallGraphic(object sender, EventArgs e)
        {
            fallGraphic.Visible = false;
        }
    }
}
