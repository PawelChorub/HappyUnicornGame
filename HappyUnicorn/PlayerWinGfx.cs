using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyUnicorn
{
    public class PlayerWinGfx
    {
        private PictureBox winnerGraphic;

        public void Initialize(PictureBox _winnerGraphic)
        {
            winnerGraphic = _winnerGraphic;
        }
        public void ViewWinGraphic(object sender, EventArgs e)
        {
            winnerGraphic.Visible = true;
        }
        public void HideWinGraphic(object sender, EventArgs e)
        {
            winnerGraphic.Visible = false;
        }
    }
}
