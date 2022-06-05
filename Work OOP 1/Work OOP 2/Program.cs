using System;

namespace Work_OOP_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player playerOne = new Player(5, 5);
            Draw drawPlayer = new Draw();

            drawPlayer.DrawPlayerPosition(playerOne.XPosition, playerOne.YPosition);
        }

        class Player
        {
            public int XPosition { get; set; }
            public int YPosition { get; set; }

            public Player(int xPosition = 0, int yPosition = 0)
            {
                XPosition = xPosition;
                YPosition = yPosition;
            }
        }

        class Draw
        {
            public void DrawPlayerPosition(int xPosition, int ypostion, char sign = '@')
            {
                Console.SetCursorPosition(xPosition, ypostion);
                Console.Write(sign);
            }
        }
    }
}
