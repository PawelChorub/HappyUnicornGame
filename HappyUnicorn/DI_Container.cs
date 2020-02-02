using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyUnicorn
{
    //builder.RegisterAssemblyTypes(Assembly.Load(nameof(Ninject_IoC)))
    //    .Where(t => t.Namespace.Contains("NazwaFolderu"))
    //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
    public class DI_Container : NinjectModule
    {
        public override void Load()
        {
            Bind<CheckClass>().ToSelf();
            Bind<GameController>().ToSelf();
            Bind<GameSetup>().ToSelf();
            Bind<LeftDirectionController>().ToSelf();
            Bind<RightDirectionController>().ToSelf();
            Bind<MainSceneAreaController>().ToSelf();
            Bind<PlayerBackground>().ToSelf();
            Bind<PlayerCollisionGfx>().ToSelf();
            Bind<PlayerFallGfx>().ToSelf();
            Bind<PlayerMoveController>().ToSelf();
            Bind<PlayerMoveDirectionSet>().ToSelf();
            Bind<PlayerOnMovableObjectController>().ToSelf();
            Bind<PlayerSideController>().ToSelf();
            Bind<PlayerWinGfx>().ToSelf();
        }
    }
}
