using System;

namespace Work_OOP_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player playerOne = new Player(10, 1);

            Draw drawPlayer = new Draw(playerOne.GetXPosition(), playerOne.GetYPosition());

            drawPlayer.DrawPlayerPosition();
        }

    class Player
        {
            private int _xPosition;
            private int _yPosition;

            public Player(int xPosition, int yPosition)
            {
                _xPosition = xPosition;
                _yPosition = yPosition;
            }

            public void SetXYPosition(int xPosition,int yPosition)
            {
                xPosition = _xPosition;
                yPosition = _yPosition;
            }

            public int GetXPosition()
            {
                return _xPosition;
            }

            public int GetYPosition()
            {
                return _yPosition;
            }
        }

    class Draw
        {
            private int _xPosition;
            private int _yPosition;

            public Draw(int xPosition, int yPosition)
            {
                _xPosition = xPosition;
                _yPosition = yPosition;
            }

            public void DrawPlayerPosition(int xPosition = 0, int yPosition = 0)
            {
                xPosition = _xPosition;
                yPosition = _yPosition;

                Console.SetCursorPosition(xPosition, yPosition);
                Console.Write("@");
            }
        }
    }
}
