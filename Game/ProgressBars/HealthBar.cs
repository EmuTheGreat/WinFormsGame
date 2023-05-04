using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static Game.MVC;

namespace Game
{
    public class HealthBar : ProgressBar
    {
        public HealthBar(Image bg, Image fg, float max, Point pos) : base(bg, fg, max, pos)
        {
            background = bg;
            foreground = fg;
            maxValue = max;
            currentValue = max;
            position = pos;
            part = new Rectangle(16, 2, 10, 80);
        }

        public override void Draw(Graphics g)
        {
            var gr = g;
            gr.ResetTransform();
            gr.DrawImage(Textures.healthBar, new Rectangle(WindowWidth - 70, WindowHeight - 220, 20, 160), new Rectangle(42, 2, 10, 80), GraphicsUnit.Pixel);
            gr.DrawImage(Textures.healthBar, new Rectangle(position, new Size(20, 160)), part, GraphicsUnit.Pixel);
            gr.DrawImage(Textures.healthBar, new Rectangle(WindowWidth - 78, WindowHeight - 240, 36, 32), new Rectangle(64, 3, 18, 16), GraphicsUnit.Pixel);
        }

        public override void Update()
        {
            part.Y = (int)(currentValue / maxValue * foreground.Height) - 82;
            position.Y = WindowHeight - 220 + part.Y * 2;
        }
    }
}
