using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyUnicorn
{
    public class EventManager
    {
        MainSceneAreaController mainSceneAreaController;
        public EventManager()
        {
            mainSceneAreaController = new MainSceneAreaController(ref playerMoveController);

        }
        public void EventRegister()
        {
            mainSceneAreaController.SceneLeftEdgeReached += playerMoveController.MoveLeftLockOn;
            mainSceneAreaController.SceneLeftEdgeNotReached += playerMoveController.MoveLeftLockOff;

            mainSceneAreaController.SceneRightEdgeReached += playerMoveController.MoveRightLockOn;
            mainSceneAreaController.SceneRightEdgeNotReached += playerMoveController.MoveRightLockOff;

            mainSceneAreaController.SceneTopEdgeReached += playerMoveController.MoveUpLockOn;
            mainSceneAreaController.SceneTopEdgeNotReached += playerMoveController.MoveUpLockOff;

            mainSceneAreaController.SceneBottomEdgeReached += playerMoveController.MoveDownLockOn;
            mainSceneAreaController.SceneBottomEdgeNotReached += playerMoveController.MoveDownLockOff;

            checkClass.PlayerIsWin += playerWinGfx.ViewWinGraphic;
            checkClass.PlayerIsWin += playerFallGfx.HideFallGraphic;
            checkClass.PlayerIsWin += playerMoveController.PlayerMoveLockOn;
            checkClass.PlayerIsWin += GameOver;

            checkClass.PlayerIsCollisionWithMovableObject += collisionGfx.ViewCollisionGraphic;
            checkClass.PlayerIsCollisionWithMovableObject += playerMoveController.PlayerMoveLockOn;
            checkClass.PlayerIsCollisionWithMovableObject += GameOver;

            checkClass.PlayerIsFallOffMovableObject += playerFallGfx.ViewFallGraphic;
            checkClass.PlayerIsFallOffMovableObject += playerMoveController.PlayerMoveLockOn;
            checkClass.PlayerIsFallOffMovableObject += GameOver;

            checkClass.PlayerIsOutOfScene += playerMoveController.PlayerMoveLockOn;
            checkClass.PlayerIsOutOfScene += GameOver;
            checkClass.PlayerIsOutOfScene += playerFallGfx.ViewFallGraphic;

            checkClass.PlayerIsNotCollisionWithMovableObject += collisionGfx.HideCollisionGraphic;

            gameController.GameIsStarted += playerFallGfx.HideFallGraphic;
            gameController.GameIsStarted += playerWinGfx.HideWinGraphic;
        }
    }
}
