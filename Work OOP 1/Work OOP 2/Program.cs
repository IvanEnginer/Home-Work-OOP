using System;

namespace Work_OOP_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player playerOne = new Player(1, 1);

            playerOne.Draw();
        }

    class Player
        {
            public int XPosition;
            public int YPosition;

            public Player(int xPosition, int yPosition)
            {
                XPosition = xPosition;
                YPosition = yPosition;
            }

            //public Player()
            //{
            //    XPosition = 10;
            //    YPosition = 10;
            //}

            public void Draw(int xPosition = 0, int yPosition = 0)
            {
                xPosition = XPosition;
                yPosition = YPosition;

                Console.SetCursorPosition(xPosition, yPosition);
                Console.Write("@");
            }
        }

    class Draw
        {

        }
    }
}
