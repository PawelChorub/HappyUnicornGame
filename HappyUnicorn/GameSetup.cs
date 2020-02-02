using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyUnicorn
{
    public class GameSetup
    {
        public int GameSpeed { get; set; } = 3;
        public int MaxGameSpeed { get; } = 10;
        public int MinGameSpeed { get; } = 1;
        public int JumpHorizontal { get; } = 20;
        public int JumpVertical { get; } = 50;

        public void GameSpeedDecrease()
        {
            if (GameSpeed > MinGameSpeed && GameSpeed <= MaxGameSpeed)
            {
                GameSpeed--;
            }
        }

        public void GameSpeedIncrease()
        {
            if (GameSpeed >= MinGameSpeed && GameSpeed < MaxGameSpeed)
            {
                GameSpeed++;
            }
        }

        public void SetPlayerToStart(PictureBox player, PictureBox scene)
        {
            player.Top = scene.Height - player.Height;
            player.Left = scene.Left + (7 * player.Width);
        }
    }
}
