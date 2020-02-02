using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyUnicorn
{
    public class PlayerMoveDirectionSet
    {
        private PictureBox player;
        
        public void Initialize(PictureBox _player)
        {
            player = _player;
        }
        public void MoveVertical(int step)
        {
            player.Top += step;
        }
        public void MoveHorizontal(int step)
        {
            player.Left += step;
        }
    }
}
