using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyUnicorn
{
    public static class Direction
    {
        public enum Way { Left, Right }

        public static Way GetRowDirection(PictureBox movableObject, PictureBox[,] movableObjectCollection)
        {
            if ((movableObject.Top == movableObjectCollection[4, 0].Top) ||
                (movableObject.Top == movableObjectCollection[6, 0].Top) ||
                (movableObject.Top == movableObjectCollection[7, 0].Top))
            {
                return Way.Left;
            }
            else return Way.Right;
        }
    }
}
