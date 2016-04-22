using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Game
    {
        private Wall wall = new Wall();
        private Brick currentBrick;
        private int currentX;
        private int currentY;
        private int score;
        public void changeState()
        {
            currentBrick.changeDirection();
        }

        private bool downable()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (currentBrick.CurrentShape[i][j] == 1)
                    {
                        if (i + currentY + 1 >= 20)
                        {
                            return false;
                        }
                        if (j + currentX >= 14)
                        {
                            currentX = 13 - j;
                        }
                        if (wall.Bg[i + currentY + 1, j + currentX] == 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private bool lefeable()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (currentBrick.CurrentShape[i][j] == 1)
                    {
                        if (j + currentX - 1 < 0)
                        {
                            return false;
                        }
                        if (wall.Bg[i + currentY, j + currentX - 1] == 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private bool rightable()
        {
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if(currentBrick.CurrentShape[i][j] == 1)
                    {
                        if (j + currentX + 1 > 14)
                        {
                            return false;
                        }
                        if(wall.Bg[i+currentY, j + currentX + 1] == 1)
                        {
                            return false;
                        }
                    }

                }
            }
            return true;
        }
    }
}
