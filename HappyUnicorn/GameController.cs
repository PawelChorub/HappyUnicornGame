using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyUnicorn
{
    public class GameController
    {
        IKernel kernel = new StandardKernel(new DI_Container());
        readonly CheckClass checkClass;

        public GameController()
        {
            checkClass = kernel.Get<CheckClass>();
        }

        public event EventHandler GameIsStarted;

        protected virtual void OnGameIsStarted(EventArgs e)
        {
            GameIsStarted?.Invoke(this, e);
        }

        public void GameStart()
        {
            OnGameIsStarted(EventArgs.Empty);
        }

        public event EventHandler GameIsOver;

        protected virtual void OnGameIsOver(EventArgs e)
        {
            GameIsOver?.Invoke(this, e);
        }

        public void GameOver()
        {
            OnGameIsOver(EventArgs.Empty);
        }
    }
}
