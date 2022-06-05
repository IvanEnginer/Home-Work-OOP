using System;

namespace Work_OOP_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player playerOne = new Player(5, 5, '@');
            RenderPlayer drawPlayer = new RenderPlayer();

            drawPlayer.DrawPlayer(playerOne.XPosition, playerOne.YPosition, playerOne.Sign);
        }
    }

    class Player
    {
        public int XPosition { get;private set; }
        public int YPosition { get;private set; }
        public char Sign { get; private set; }

        public Player(int xPosition = 0, int yPosition = 0, char sign = '|')
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Sign = sign;
        }
    }

    class RenderPlayer
    {
        public void DrawPlayer(int xPositionPlayer, int yPostionPlayer, char signPlayer)
        {
            Console.SetCursorPosition(xPositionPlayer, yPostionPlayer);
            Console.Write(signPlayer);
        }
    }
}
