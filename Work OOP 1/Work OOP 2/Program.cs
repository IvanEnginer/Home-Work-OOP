using System;

namespace Work_OOP_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player playerOne = new Player(5, 5, '@');
            RenderPlayer drawPlayer = new RenderPlayer();

            drawPlayer.Draw(playerOne.XPosition, playerOne.YPosition, playerOne.Sign);
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
        public void Draw(int xPosition, int yPostion, char sign)
        {
            Console.SetCursorPosition(xPosition, yPostion);
            Console.Write(sign);
        }
    }
}
