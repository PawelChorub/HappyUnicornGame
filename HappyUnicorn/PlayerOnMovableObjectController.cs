using Ninject;
using System.Windows.Forms;

namespace HappyUnicorn
{
    public class PlayerOnMovableObjectController
    {
        private IKernel kernel = new StandardKernel(new DI_Container());

        private CheckClass checkClass;
        private LeftDirectionController leftDirectionController;
        private RightDirectionController rightDirectionController;

        public PlayerOnMovableObjectController()
        {
            leftDirectionController = kernel.Get<LeftDirectionController>();
            rightDirectionController = kernel.Get<RightDirectionController>();
            checkClass = kernel.Get<CheckClass>();
        }
        public void ControlPlayerPositionOnMovableObject(PictureBox movableObject, PictureBox player, int speed, Direction.Way direction)
        {
            if (checkClass.IsPlayerOnMovableObject(player, movableObject))
            {
                //srodek
                if ((movableObject.Left <= player.Left) && (movableObject.Right >= player.Right))
                {
                    if (direction == Direction.Way.Left)
                    {
                        leftDirectionController.MoveRowLeft(player, speed);

                    }
                    if (direction == Direction.Way.Right)
                    {
                        rightDirectionController.MoveRowRight(player, speed);
                    }
                }
                //lewy
                if ((movableObject.Left > player.Left) && (movableObject.Right > player.Right))
                {   // speed bo jest skok obiektu ruchomego o speed
                    player.Left = movableObject.Left - speed;
                }
                //prawy
                if ((movableObject.Left < player.Left) && (movableObject.Right < player.Right))
                {
                    player.Left = movableObject.Right - player.Width;
                }
            }
        }
    }
}
