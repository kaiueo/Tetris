using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Brick
    {
        private int[][][] shapes;
        private int[][] currentShape;
        private int state;
        public int[][][] Shapes
        {
            get
            {
                return shapes;
            }

            set
            {
                shapes = value;
            }
        }

        public int State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }

        public int [][] CurrentShape
        {
            get
            {
                return currentShape;
            }

            set
            {
                currentShape = value;
            }
        }

        public void changeDirection()
        {
            if (State < 3)
            {
                State++;
            }
            else
            {
                State = 0;
            }
            CurrentShape = Shapes[State];
        }
        public Brick(int [][][] shapes, int s)
        {
            this.Shapes = shapes;
            this.State = s;
            this.CurrentShape = Shapes[State];
        }
    }
}
