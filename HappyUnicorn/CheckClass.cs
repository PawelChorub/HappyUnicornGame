using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyUnicorn
{
    public class CheckClass
    {
        public event EventHandler PlayerIsWin;

        protected virtual void OnPlayerIsWin(EventArgs e)
        {
            PlayerIsWin?.Invoke(this, e);
        }

        public bool IsPlayerWin(PictureBox player, PictureBox [] finishBox)
        {
            bool output = false;

            foreach (var item in finishBox)
            {
                if ((player.Left > item.Left) && (player.Top < item.Bottom) && (player.Right < item.Right))
                {
                    output = true;
                    OnPlayerIsWin(EventArgs.Empty);
                }
            }
            return output;
        }
        //=======================================================================================
        public bool IsPlayerOnMovableObject(PictureBox player, PictureBox movableObject)
        {
            if (player.Bounds.IntersectsWith(movableObject.Bounds))
            {
                if ((player.Left >= movableObject.Left) && (player.Right <= movableObject.Right) &&
                    (player.Top == movableObject.Top) && (player.Bottom == movableObject.Bottom))
                {
                    return true;
                }
                else if ((player.Left < movableObject.Left) && (player.Right > movableObject.Left) &&
                        (player.Top == movableObject.Top) && (player.Bottom == movableObject.Bottom))
                     {
                        return true;
                     }
                else if ((player.Left < movableObject.Right) && (player.Right > movableObject.Right) &&
                        (player.Top == movableObject.Top) && (player.Bottom == movableObject.Bottom))
                     {
                        return true;
                     }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private readonly int FirstRoundEndPoint = 350;
        private readonly int SecondRoundStartPoint = 311;
        public void GameRoundControl(PictureBox[,] movableObjectCollection, PictureBox player)
        {
            if (player.Top >= FirstRoundEndPoint)
            {
                CheckIfPlayerIsCollisionWithMovableObject(movableObjectCollection, player);
            }

            if (player.Bottom <= SecondRoundStartPoint)
            {
                CheckIfPlayerIsFallOffMovableObject(movableObjectCollection, player);
            }
        }

        public bool CheckIfPlayerIsIntersectMovableObject(PictureBox player, PictureBox movableObject)
        {
            if (player.Bounds.IntersectsWith(movableObject.Bounds))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //=======================================================================================
        public event EventHandler PlayerIsOutOfScene;

        protected virtual void OnPlayerIsOutOfScene(EventArgs e)
        {
            PlayerIsOutOfScene?.Invoke(this, e);
        }

        public bool CheckIfPlayerIsOutOfScene(PictureBox player, PictureBox scene)
        {
            if ((player.Left < scene.Left) || (player.Right > scene.Right))
            {
                OnPlayerIsOutOfScene(EventArgs.Empty);
                return true;
            }
            else return false;
        }
        //=======================================================================================

        public event EventHandler PlayerIsFallOffMovableObject;
        public event EventHandler PlayerIsNotFallOffMovableObject;

        public virtual void OnPlayerIsFallOffMovableObject(EventArgs e)
        {
            PlayerIsFallOffMovableObject?.Invoke(this, e);
        }
        public virtual void OnPlayerIsNotFallOffMovableObject(EventArgs e)
        {
            PlayerIsNotFallOffMovableObject?.Invoke(this, e);
        }

        public bool CheckIfPlayerIsFallOffMovableObject(PictureBox[,] movableObject, PictureBox player)
        {
            bool output = true;
            foreach (var item in movableObject)
            {
                if (item != null)
                {
                    if (IsPlayerOnMovableObject(player, item))
                    {
                        output = false;
                        OnPlayerIsNotFallOffMovableObject(EventArgs.Empty);
                    }
                }
            }
            if (output == true)
            {
                OnPlayerIsFallOffMovableObject(EventArgs.Empty);

            }
            return output;
        }
        //=======================================================================================

        public event EventHandler PlayerIsCollisionWithMovableObject;
        public event EventHandler PlayerIsNotCollisionWithMovableObject;

        protected virtual void OnPlayerIsCollisionWithMovableObject(EventArgs e)
        {
            PlayerIsCollisionWithMovableObject?.Invoke(this, e);
        }
        protected virtual void OnPlayerIsNotCollisionWithMovableObject(EventArgs e)
        {
            PlayerIsNotCollisionWithMovableObject?.Invoke(this, e);
        }

        public bool CheckIfPlayerIsCollisionWithMovableObject(PictureBox[,] movableObject, PictureBox player)
        {
            bool output = false;
            foreach (var item in movableObject)
            {
                if (item != null)
                {
                    if (CheckIfPlayerIsIntersectMovableObject(player, item))
                    {
                        output = true;
                        OnPlayerIsCollisionWithMovableObject(EventArgs.Empty);
                    }
                }
            }
            if (output == false)
            {
                OnPlayerIsNotCollisionWithMovableObject(EventArgs.Empty);
            }
            return output;
        }
        //=======================================================================================
    }
}
