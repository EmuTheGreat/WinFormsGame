using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static Game.MVC;

namespace Game
{
    public class ProgressBar
    {
        public Point position;
        public float maxValue;
        public float currentValue;
        public Rectangle part;
        public Point srcPos;

        public ProgressBar(float max, Point pos)
        {
            maxValue = max;
            currentValue = max;
            position = pos;
        }

        public virtual void Update()
        {
            
        }

        public virtual void Draw(Graphics g)
        {
            
        }
    }
}
