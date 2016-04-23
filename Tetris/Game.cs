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
        public Brick currentBrick;
        public Brick nextBrick;
        public BrickFactory bf;
        private int currentX;
        private int currentY;
        private int score;
        private System.Windows.Forms.Timer timer;
        private Form1 form;

        private Random random;

        public Game(System.Windows.Forms.Timer t, Form1 f)
        {
            this.timer = t;
            random = new Random();
            bf = new BrickFactory();
            form = f;
            currentBrick = new Brick();
            nextBrick = new Brick();
        }

        internal Wall Wall
        {
            get
            {
                return wall;
            }

            set
            {
                wall = value;
            }
        }

        public int CurrentX
        {
            get
            {
                return currentX;
            }

            set
            {
                currentX = value;
            }
        }

        public int CurrentY
        {
            get
            {
                return currentY;
            }

            set
            {
                currentY = value;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }

     

        public void changeState()
        {
            currentBrick.changeDirection();
        }

        public bool downable()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (currentBrick.CurrentShape[i][j] == 1)
                    {
                        if (i + CurrentY + 1 >= 20)
                        {
                            return false;
                        }
                        if (j + CurrentX >= 14)
                        {
                            CurrentX = 13 - j;
                        }
                        if (Wall.Bg[i + CurrentY + 1, j + CurrentX] == 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public bool lefeable()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (currentBrick.CurrentShape[i][j] == 1)
                    {
                        if (j + CurrentX - 1 < 0)
                        {
                            return false;
                        }
                        if (Wall.Bg[i + CurrentY, j + CurrentX - 1] == 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public bool rightable()
        {
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if(currentBrick.CurrentShape[i][j] == 1)
                    {
                        if (j + CurrentX + 1 >= 14)
                        {
                            return false;
                        }
                        if(Wall.Bg[i+CurrentY, j + CurrentX + 1] == 1)
                        {
                            return false;
                        }
                    }

                }
            }
            return true;
        }

        public void downBricks()
        {
            if (downable())
            {
                CurrentY++;
            }
            else
            {
                if(CurrentY == 0)
                {
                    timer.Stop();
                    form.message("你输了");
                    return;
                }
                for (int y = 0; y < 4; y++)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        if (currentBrick.CurrentShape[y][x] == 1)
                        {
                            wall.Bg[CurrentY + y, CurrentX + x] = currentBrick.CurrentShape[y][x];
                        }
                    }
                }
                checkScore();
                beginDrop();
            }
            form.Draw();
            
        }

        private void checkScore()
        {
            for (int y = 19; y > -1; y--)
            {
                bool isFull = true;
                for (int x = 13; x > -1; x--)
                {
                    if (wall.Bg[y, x] == 0)
                    {
                        isFull = false;
                        break;
                    }
                }
                if (isFull)
                {
                    Score = Score + 100;
                    for (int yy = y; yy > 0; yy--)
                    {
                        for (int xx = 0; xx < 14; xx++)
                        {
                            int temp = wall.Bg[yy - 1, xx];
                            wall.Bg[yy, xx] = temp;
                        }
                    }
                    y++;
                    form.updateScore();
                }

            }
        }

 

        public void beginDrop()
        {
            currentBrick = new Brick(nextBrick.Shapes, nextBrick.State);

            int i = random.Next(0, 4);
            int j = random.Next(0, 4);
            nextBrick = bf.getBricks(i, j);
            CurrentX = 6;
            currentY = 0;
            timer.Start();

        }
    }
}
