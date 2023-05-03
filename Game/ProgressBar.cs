using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ProgressBar
    {
        public readonly Image background;
        public readonly Image foreground;
        public readonly RectangleF position;
        public readonly float maxValue;
        public  float currentValue;
        public RectangleF part;

        public ProgressBar(Image bg, Image fg, float max, PointF pos)
        {
            background = bg;
            foreground = fg;
            maxValue = max;
            currentValue = max;
            position = new RectangleF(pos, new Size(background.Width * 2, background.Height * 2));
            part = new RectangleF(0, 0, foreground.Width, foreground.Height);
        }

        public virtual void Update()
        {
            part.Y = (int)(currentValue / maxValue * foreground.Height) - part.Height;
        }

        public virtual void Draw(Graphics g)
        {
            var gr = g;
            gr.ResetTransform();
            gr.DrawImage(background, position);
            gr.DrawImage(foreground, position, part, GraphicsUnit.Pixel);
        }
    }
}
