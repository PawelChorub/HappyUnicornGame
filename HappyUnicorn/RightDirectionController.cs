using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyUnicorn
{
    public class RightDirectionController
    {
        private PictureBox scene;

        public void Initialize(PictureBox _scene)
        {
            scene = _scene;
        }

        public void CircuitRight(PictureBox movableObject)
        {
            if (movableObject.Left + 2 >= scene.Location.X + scene.Width)
            {
                movableObject.Left = scene.Location.X;
            }
        }
        public void MoveRowRight(PictureBox movableObject, int speed)
        {
            movableObject.Left += speed;
        }

    }
}
