using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyUnicorn
{
    public class PlayerMoveController
    {
        public bool CanMoveRight { get; set; } = true;
        public bool CanMoveLeft { get; set; } = true;
        public bool CanMoveUp { get; set; } = true;
        public bool CanMoveDown { get; set; } = true;

        public void PlayerMoveLockOn(object sender, EventArgs e)
        {
            CanMoveDown = false;
            CanMoveUp = false;
            CanMoveRight = false;
            CanMoveLeft = false;
        }

        public void MoveLeftLockOn(object sender, EventArgs e)
        {
            CanMoveLeft = false;
        }
        public void MoveLeftLockOff(object sender, EventArgs e)
        {
            CanMoveLeft = true;
        }

        public void MoveRightLockOn(object sender, EventArgs e)
        {
            CanMoveRight = false;
        }
        public void MoveRightLockOff(object sender, EventArgs e)
        {
            CanMoveRight = true;
        }

        public void MoveUpLockOn(object sender, EventArgs e)
        {
            CanMoveUp = false;
        }
        public void MoveUpLockOff(object sender, EventArgs e)
        {
            CanMoveUp = true;
        }

        public void MoveDownLockOn(object sender, EventArgs e)
        {
            CanMoveDown = false;
        }
        public void MoveDownLockOff(object sender, EventArgs e)
        {
            CanMoveDown = true;
        }

    }
}
