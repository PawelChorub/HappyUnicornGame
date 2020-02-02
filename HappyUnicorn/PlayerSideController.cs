using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyUnicorn
{
    public class PlayerSideController
    {
        private IKernel kernel = new StandardKernel(new DI_Container());

        private bool PlayerStayRight;
        private bool PlayerStayLeft;

        private PlayerBackground playerBackground;

        public PlayerSideController()
        {
            playerBackground = kernel.Get<PlayerBackground>();
        }
        public void RightSide()
        {
            PlayerStayLeft = false;
            PlayerStayRight = true;
        }
        public void LeftSide()
        {
            PlayerStayLeft = true;
            PlayerStayRight = false;
        }
        public void SetPlayerStaySideImage(PictureBox player)
        {
            if (PlayerStayLeft)
            {
                player.BackgroundImage = playerBackground.ChoosePlayerBackgroundColor(player, Direction.Way.Left);
            }
            else
            {
                player.BackgroundImage = playerBackground.ChoosePlayerBackgroundColor(player, Direction.Way.Right);
            }
        }

    }
}
