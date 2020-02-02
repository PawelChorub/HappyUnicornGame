using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyUnicorn
{
    public class MainSceneAreaController
    {
        IKernel kernel = new StandardKernel(new DI_Container());
        private PlayerMoveController playerMoveController;

        public void Initialize(PlayerMoveController playerMoveController)
        {
            this.playerMoveController = playerMoveController;
        }

        public event EventHandler SceneLeftEdgeReached;
        public event EventHandler SceneLeftEdgeNotReached;

        public event EventHandler SceneRightEdgeReached;
        public event EventHandler SceneRightEdgeNotReached;

        public event EventHandler SceneTopEdgeReached;
        public event EventHandler SceneTopEdgeNotReached;

        public event EventHandler SceneBottomEdgeReached;
        public event EventHandler SceneBottomEdgeNotReached;

        protected virtual void OnSceneLeftEdgeReached(EventArgs e)
        {
            SceneLeftEdgeReached?.Invoke(this, e);
        }
        protected virtual void OnSceneLeftEdgeNotReached(EventArgs e)
        {
            SceneLeftEdgeNotReached?.Invoke(this, e);
        }

        protected virtual void OnSceneRightEdgeReached(EventArgs e)
        {
            SceneRightEdgeReached?.Invoke(this, e);
        }
        protected virtual void OnSceneRightEdgeNotReached(EventArgs e)
        {
            SceneRightEdgeNotReached?.Invoke(this, e);
        }

        protected virtual void OnSceneTopEdgeReached(EventArgs e)
        {
            SceneTopEdgeReached?.Invoke(this, e);
        }
        protected virtual void OnSceneTopEdgeNotReached(EventArgs e)
        {
            SceneTopEdgeNotReached?.Invoke(this, e);
        }

        protected virtual void OnSceneBottomEdgeReached(EventArgs e)
        {
            SceneBottomEdgeReached?.Invoke(this, e);
        }
        protected virtual void OnSceneBottomEdgeNotReached(EventArgs e)
        {
            SceneBottomEdgeNotReached?.Invoke(this, e);
        }

        public void WatchPlayerMoveOnMainSceneArea(PictureBox player, PictureBox scene)
        {
            if (player.Left <= scene.Left + (player.Width - 1))
            {
                OnSceneLeftEdgeReached(EventArgs.Empty);
            }
            else
            {
                OnSceneLeftEdgeNotReached(EventArgs.Empty);
            }

            if (player.Right >= scene.Right - (player.Width - 1))
            {
                OnSceneRightEdgeReached(EventArgs.Empty);
            }
            else
            {
                OnSceneRightEdgeNotReached(EventArgs.Empty);
            }
            //
            if (player.Top <= scene.Top + 10)
            {
                OnSceneTopEdgeReached(EventArgs.Empty);
            }
            else
            {
                OnSceneTopEdgeNotReached(EventArgs.Empty);
            }
            //
            if (player.Bottom >= scene.Bottom - 10)
            {
                OnSceneBottomEdgeReached(EventArgs.Empty);
            }
            else
            {
                OnSceneBottomEdgeNotReached(EventArgs.Empty);
            }
        }

    }
}
