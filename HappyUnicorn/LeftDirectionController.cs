using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyUnicorn
{
    public class LeftDirectionController
    {
        private PictureBox scene;

        public void Initialize(PictureBox _scene)
        {
            scene = _scene;
        }
        public void CircuitLeft(PictureBox movableObject)
        {
            if (movableObject.Left + movableObject.Width <= scene.Location.X + 1)
            {
                movableObject.Left = scene.Width - movableObject.Width + 12;
            }
        }
        public void MoveRowLeft(PictureBox movableObject, int speed)
        {
            movableObject.Left -= speed;
        }

    }
}
