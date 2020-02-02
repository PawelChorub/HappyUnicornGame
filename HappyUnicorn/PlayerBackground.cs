using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyUnicorn
{
    public class PlayerBackground
    {
        public Image ChoosePlayerBackgroundColor(PictureBox player, Direction.Way way)
        {
            if (way == Direction.Way.Left)
            {
                if (player.Top >= 560)
                {
                    return Image.FromFile(@"C:\Users\Paweł.000\source\repos\HappyUnicornGame\HappyUnicorn\img\unicornClipart\UnicornStayLeftGreen.png");
                }
                else if (player.Top >= 350 && player.Top < 560)
                {
                    return Image.FromFile(@"C:\Users\Paweł.000\source\repos\HappyUnicornGame\HappyUnicorn\img\unicornClipart\UnicornStayLeftGrey.png");
                }
                else if (player.Top >= 310 && player.Top < 350)
                {
                    return Image.FromFile(@"C:\Users\Paweł.000\source\repos\HappyUnicornGame\HappyUnicorn\img\unicornClipart\UnicornStayLeftGreen.png");
                }
                else if (player.Top >= 50 && player.Top < 310)
                {
                    return Image.FromFile(@"C:\Users\Paweł.000\source\repos\HappyUnicornGame\HappyUnicorn\img\unicornClipart\UnicornStayLeftLightBlue.png");
                }
                else
                {
                    return Image.FromFile(@"C:\Users\Paweł.000\source\repos\HappyUnicornGame\HappyUnicorn\img\unicornClipart\UnicornStayLeftPink.png");
                }
            }
            else if (way == Direction.Way.Right)
            {
                if (player.Top >= 560)
                {
                    return Image.FromFile(@"C:\Users\Paweł.000\source\repos\HappyUnicornGame\HappyUnicorn\img\unicornClipart\UnicornStayRightGreen.png");
                }
                else if (player.Top >= 350 && player.Top < 560)
                {
                    return Image.FromFile(@"C:\Users\Paweł.000\source\repos\HappyUnicornGame\HappyUnicorn\img\unicornClipart\UnicornStayRightGrey.png");
                }
                else if (player.Top >= 310 && player.Top < 350)
                {
                    return Image.FromFile(@"C:\Users\Paweł.000\source\repos\HappyUnicornGame\HappyUnicorn\img\unicornClipart\UnicornStayRightGreen.png");
                }
                else if (player.Top >= 50 && player.Top < 310)
                {
                    return Image.FromFile(@"C:\Users\Paweł.000\source\repos\HappyUnicornGame\HappyUnicorn\img\unicornClipart\UnicornStayRightLightBlue.png");
                }
                else
                {
                   return Image.FromFile(@"C:\Users\Paweł.000\source\repos\HappyUnicornGame\HappyUnicorn\img\unicornClipart\UnicornStayRightPink.png");
                }
            }
            else return null;
        }

    }
}
