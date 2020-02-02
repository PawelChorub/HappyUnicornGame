using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyUnicorn
{
    public class PlayerCollisionGfx
    {
        private PictureBox collisionGraphic;

        public void Initialize(PictureBox _collisionGraphic)
        {
            collisionGraphic = _collisionGraphic;
        }

        public void ViewCollisionGraphic(object sender, EventArgs e)
        {
            collisionGraphic.Visible = true;
        }
        public void HideCollisionGraphic(object sender, EventArgs e)
        {
            collisionGraphic.Visible = false;
        }
    }
}
