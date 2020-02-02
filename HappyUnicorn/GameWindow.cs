using Ninject;
using System;
using System.Windows.Forms;

namespace HappyUnicorn
{
    public partial class GameWindow : Form
    {
        private IKernel kernel = new StandardKernel(new DI_Container());
        private PlayerCollisionGfx collisionGfx;
        private PlayerFallGfx playerFallGfx;
        private PlayerWinGfx playerWinGfx;
        private PlayerMoveDirectionSet playerMoveDirectionSet;
        private LeftDirectionController leftDirectionController;
        private RightDirectionController rightDirectionController;
        private MainSceneAreaController mainSceneAreaController;
        private PlayerMoveController playerMoveController;
        private PlayerSideController playerSideController;
        private PlayerOnMovableObjectController playerOnMovableObjectController;
        private PlayerBackground playerBackground;
        private GameController gameController;
        private GameSetup gameSetup;
        private CheckClass checkClass;

        public GameWindow()
        {
            InitializeComponent();
            playerMoveController = kernel.Get<PlayerMoveController>();

            mainSceneAreaController = kernel.Get<MainSceneAreaController>();
            mainSceneAreaController.Initialize(playerMoveController);

            collisionGfx = kernel.Get<PlayerCollisionGfx>();
            collisionGfx.Initialize(collisionGraphicsPictureBox);

            playerFallGfx = kernel.Get<PlayerFallGfx>();
            playerFallGfx.Initialize(PlayerFallPictureBox);

            playerWinGfx = kernel.Get<PlayerWinGfx>();
            playerWinGfx.Initialize(WinnerPictureBox);

            playerMoveDirectionSet = kernel.Get<PlayerMoveDirectionSet>();
            playerMoveDirectionSet.Initialize(player);

            leftDirectionController = kernel.Get<LeftDirectionController>();
            leftDirectionController.Initialize(scene);

            rightDirectionController = kernel.Get<RightDirectionController>();
            rightDirectionController.Initialize(scene);

            playerSideController = kernel.Get<PlayerSideController>();
            playerOnMovableObjectController = kernel.Get<PlayerOnMovableObjectController>();
            playerBackground = kernel.Get<PlayerBackground>();
            gameController = kernel.Get<GameController>();
            gameSetup = kernel.Get<GameSetup>();
            checkClass = kernel.Get<CheckClass>();

            gameSetup.SetPlayerToStart(player, scene);
            SetMovableObjectsToStart();

            MovableObjectCollectionInitializer();
            FinishBoxCollectionInitializer();

            EventRegister();
        }

        private PictureBox[,] movableObjectCollection;
        private void MovableObjectCollectionInitializer()
        {
            const int rowsNumber = 9;
            const int movableObjectsMaxNumberPerRow = 4;

            movableObjectCollection = new PictureBox[rowsNumber, movableObjectsMaxNumberPerRow]
            {
                {movableObjectRow0No1, movableObjectRow0No2, movableObjectRow0No3, null},
                {movableObjectRow1No1, movableObjectRow1No2, movableObjectRow1No3, movableObjectRow1No4},
                {movableObjectRow2No1, movableObjectRow2No2, movableObjectRow2No3, movableObjectRow2No4},
                {movableObjectRow3No1, movableObjectRow3No2, movableObjectRow3No3 , null},
                {movableObjectRow4No1, movableObjectRow4No2, movableObjectRow4No3, null },
                {movableObjectRow5No1, movableObjectRow5No2, movableObjectRow5No3, null },
                {movableObjectRow6No1, null, null, null},
                {movableObject7No1, movableObject7No2, movableObject7No3, movableObject7No4},
                {movableObject8No1, movableObject8No2, null, null },
            };
        }

        private PictureBox[] finishBoxCollection;
        private void FinishBoxCollectionInitializer()
        {
            finishBoxCollection = new PictureBox[5]
            {
                finishBox1, finishBox2, finishBox3, finishBox4, finishBox5
            };
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
            checkClass.PlayerIsOutOfScene += playerFallGfx.ViewFallGraphic;
            checkClass.PlayerIsOutOfScene += GameOver;

            checkClass.PlayerIsNotCollisionWithMovableObject += collisionGfx.HideCollisionGraphic;

            gameController.GameIsStarted += playerFallGfx.HideFallGraphic;
            gameController.GameIsStarted += playerWinGfx.HideWinGraphic;
        }

        private void GameStart()
        {
            gameController.GameStart();
            SetMovableObjectsToStart();
            gameSetup.SetPlayerToStart(player, scene);
            SetTimerEnabled(true);
        }
        private void GameOver(object sender, EventArgs e)
        {
            SetTimerEnabled(false);
        }

        private void SetTimerEnabled(bool shift)
        {
            timerRow1.Enabled = shift;
            timerRow2.Enabled = shift;
            timerRow3.Enabled = shift;
            timerRow4.Enabled = shift;
            timerRow5to9.Enabled = shift;
            timerMovableObjectCircuit.Enabled = shift;
            timerCheckPlayerIsOnMovable.Enabled = shift;
            timerCheckPlayerWin.Enabled = shift;
            timerGameControl.Enabled = shift;
        }

        private void SetMovableObjectsToStart()
        {
            movableObjectRow0No1.Left = 200;
            movableObjectRow0No2.Left = movableObjectRow0No1.Right - 200;
            movableObjectRow0No3.Left = movableObjectRow0No2.Right - 200;

            movableObjectRow1No1.Left = 100;
            movableObjectRow1No2.Left = movableObjectRow1No1.Right + 60;
            movableObjectRow1No3.Left = movableObjectRow1No2.Right + 200;
            movableObjectRow1No4.Left = movableObjectRow1No3.Right + 60;

            movableObjectRow2No1.Left = 50;
            movableObjectRow2No2.Left = movableObjectRow2No1.Right + 140;
            movableObjectRow2No3.Left = movableObjectRow2No2.Right + 140;
            movableObjectRow2No4.Left = movableObjectRow2No3.Right + 140;

            movableObjectRow3No1.Left = 100;
            movableObjectRow3No2.Left = movableObjectRow3No1.Right + 200;
            movableObjectRow3No3.Left = movableObjectRow3No2.Right + 200;

            movableObjectRow4No1.Left = 80;
            movableObjectRow4No2.Left = movableObjectRow4No1.Right + 130;
            movableObjectRow4No3.Left = movableObjectRow4No2.Right + 130;

            movableObjectRow5No1.Left = 60;
            movableObjectRow5No2.Left = movableObjectRow5No1.Right + 130;
            movableObjectRow5No3.Left = movableObjectRow5No2.Right + 130;

            movableObjectRow6No1.Left = 200;

            movableObject7No1.Left = 100;
            movableObject7No2.Left = movableObject7No1.Right + 51;
            movableObject7No3.Left = movableObject7No2.Right + 200;
            movableObject7No4.Left = movableObject7No3.Right + 51;

            movableObject8No1.Left = 30;
            movableObject8No2.Left = movableObject8No1.Right + 150;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            GameKeyControl(e);
        }

        private void GameKeyControl(KeyEventArgs e)
        {
            var keyPressed = e.KeyCode;

            switch (keyPressed)
            {
                case Keys.Left:
                    MovePlayerLeft();
                    break;
                case Keys.Right:
                    MovePlayerRight();
                    break;
                case Keys.Up:
                    MovePlayerUp();
                    break;
                case Keys.Down:
                    MovePlayerDown();
                    break;
                case Keys.S:
                    GameStart();
                    break;
                case Keys.A:
                    gameSetup.GameSpeedIncrease();
                    break;
                case Keys.Z:
                    gameSetup.GameSpeedDecrease();
                    break;
            }
        }

        private void MovePlayerDown()
        {
            if (playerMoveController.CanMoveDown)
            {
                playerMoveDirectionSet.MoveVertical(gameSetup.JumpVertical);
            }
        }

        private void MovePlayerUp()
        {
            if (playerMoveController.CanMoveUp)
            {
                playerMoveDirectionSet.MoveVertical(-gameSetup.JumpVertical);
            }
        }

        private void MovePlayerRight()
        {
            if (playerMoveController.CanMoveRight)
            {
                playerSideController.RightSide();
                playerMoveDirectionSet.MoveHorizontal(gameSetup.JumpHorizontal);
            }
        }

        private void MovePlayerLeft()
        {
            if (playerMoveController.CanMoveLeft)
            {
                playerSideController.LeftSide();
                playerMoveDirectionSet.MoveHorizontal(-gameSetup.JumpHorizontal);
            }
        }

        private void TimerRow1_Tick(object sender, EventArgs e)
        {
            rightDirectionController.MoveRowRight( movableObjectRow0No1, gameSetup.GameSpeed);
            rightDirectionController.MoveRowRight( movableObjectRow0No2, gameSetup.GameSpeed);
            rightDirectionController.MoveRowRight( movableObjectRow0No3, gameSetup.GameSpeed);
        }
        private void TimerRow2_Tick(object sender, EventArgs e)
        {
            leftDirectionController.MoveRowLeft(movableObjectRow1No1, gameSetup.GameSpeed);
            leftDirectionController.MoveRowLeft(movableObjectRow1No2, gameSetup.GameSpeed);
            leftDirectionController.MoveRowLeft(movableObjectRow1No3, gameSetup.GameSpeed);
            leftDirectionController.MoveRowLeft(movableObjectRow1No4, gameSetup.GameSpeed);
        }
        private void TimerRow3_Tick(object sender, EventArgs e)
        {
            leftDirectionController.MoveRowLeft(movableObjectRow2No1, gameSetup.GameSpeed);
            leftDirectionController.MoveRowLeft(movableObjectRow2No2, gameSetup.GameSpeed);
            leftDirectionController.MoveRowLeft(movableObjectRow2No3, gameSetup.GameSpeed);
            leftDirectionController.MoveRowLeft(movableObjectRow2No4, gameSetup.GameSpeed);
        }
        private void TimerRow4_Tick(object sender, EventArgs e)
        {
            rightDirectionController.MoveRowRight(movableObjectRow3No1, gameSetup.GameSpeed);
            rightDirectionController.MoveRowRight(movableObjectRow3No2, gameSetup.GameSpeed);
            rightDirectionController.MoveRowRight(movableObjectRow3No3, gameSetup.GameSpeed);
        }

        private void TimerRow5to9_Tick(object sender, EventArgs e)
        {
            leftDirectionController.MoveRowLeft(movableObjectRow4No1, gameSetup.GameSpeed);
            leftDirectionController.MoveRowLeft(movableObjectRow4No2, gameSetup.GameSpeed);
            leftDirectionController.MoveRowLeft(movableObjectRow4No3, gameSetup.GameSpeed);

            rightDirectionController.MoveRowRight(movableObjectRow5No1, gameSetup.GameSpeed);
            rightDirectionController.MoveRowRight(movableObjectRow5No2, gameSetup.GameSpeed);
            rightDirectionController.MoveRowRight(movableObjectRow5No3, gameSetup.GameSpeed);

            leftDirectionController.MoveRowLeft(movableObjectRow6No1, gameSetup.GameSpeed);

            leftDirectionController.MoveRowLeft(movableObject7No1, gameSetup.GameSpeed);
            leftDirectionController.MoveRowLeft(movableObject7No2, gameSetup.GameSpeed);
            leftDirectionController.MoveRowLeft(movableObject7No3, gameSetup.GameSpeed);
            leftDirectionController.MoveRowLeft(movableObject7No4, gameSetup.GameSpeed);

            rightDirectionController.MoveRowRight(movableObject8No1, gameSetup.GameSpeed);
            rightDirectionController.MoveRowRight(movableObject8No2, gameSetup.GameSpeed);
        }

        private void TimerMovableObjectCircuit_Tick(object sender, EventArgs e)
        {
            GameSpeedDisplayLabel.Text = "Prędkość gry :" + gameSetup.GameSpeed.ToString();
            MovableObjectCircuit(movableObjectCollection);
        }

        private void MovableObjectCircuit(PictureBox[,] movableObjectCollection)
        {
            PictureBox movableObject;
            foreach (var item in movableObjectCollection)
            {
                movableObject = item;
                if (movableObject != null)
                {
                    rightDirectionController.CircuitRight(movableObject);
                    leftDirectionController.CircuitLeft(movableObject);
                }
            }
        }

        private void TimerCheckPlayerWin_Tick(object sender, EventArgs e)
        {
            checkClass.IsPlayerWin(player, finishBoxCollection);
        }

        private void TimerGameControl_Tick(object sender, EventArgs e)
        {
            mainSceneAreaController.WatchPlayerMoveOnMainSceneArea(player, scene);
            playerSideController.SetPlayerStaySideImage(player);
            checkClass.CheckIfPlayerIsOutOfScene(player, scene);
            checkClass.GameRoundControl(movableObjectCollection, player);
        }

        private void TimerCheckPlayerIsOnMovable_Tick(object sender, EventArgs e)
        {
            ControlPlayerOnMovableObject(movableObjectCollection);
        }

        private void ControlPlayerOnMovableObject(PictureBox[,] movableObjectCollection)
        {
            PictureBox movableObject;
            foreach (var item in movableObjectCollection)
            {
                movableObject = item;
                if (movableObject != null)
                    playerOnMovableObjectController.ControlPlayerPositionOnMovableObject(movableObject, player, gameSetup.GameSpeed, Direction.GetRowDirection(movableObject, movableObjectCollection));
            }
        }

        private void ExitLabel_Click(object sender, EventArgs e) => Close();
        private void ExitLabel_MouseEnter(object sender, EventArgs e) => exitLabel.BorderStyle = BorderStyle.FixedSingle;
        private void ExitLabel_MouseLeave(object sender, EventArgs e) => exitLabel.BorderStyle = BorderStyle.None;
    }
}
