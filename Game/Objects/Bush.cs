using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    public class Bush : IEntity
    {
        public ProgressBar healthPoint { get; set; }
        public bool isAlive { get; set; }

        public float posX { get; set; }
        public float posY { get; set; }

        public float dirX { get; set; }
        public float dirY { get; set; }
        public int speed { get; set; }

        public bool isMovingLeft { get; }
        public bool isMovingRight { get; }
        public bool isMovingUp { get; }
        public bool isMovingDown { get; }
        public bool isAttack { get; }
        public bool deathAnimationFlag { get; }

        public int currentFrame { get; set; }
        public int currentAnimation { get; set; }
        public int currentLimit { get; set; }
        public int idleFrames { get; set; }
        public int runFrames { get; set; }
        public int attackFrames { get; set; }
        public int deathFrames { get; set; }

        public int spriteSize { get; set; }
        public int sizeX { get; set; }
        public int sizeY { get; set; }
        public int flip { get; set; }
        public int delta { get; set; }
        public RectangleF collisionBox { get; }
        public RectangleF position { get; set; }

        public Bush(Point position)
        {
            posX = position.X;
            posY = position.Y;
            sizeX = 128;
            sizeY = 128;
            this.position = new RectangleF(position, new Size(sizeX, sizeY));
            collisionBox = new RectangleF(position.X + 5, position.Y + 64, 114, 50);
            delta = 10;
        }

        public void Update() { }

        public bool IsMoving() { return false; }

        public void PlayAnimation(Graphics g)
        {
            DrawObject(Textures.objectsSheet, position, new Rectangle(new Point(96, 112), new Size(32, 32)), g);
        }
        private void DrawObject(Image image, RectangleF rect, Rectangle rectSrc, Graphics g)
        {
            g.DrawImage(image, rect, rectSrc, GraphicsUnit.Pixel);
            //g.DrawRectangles(new Pen(Color.Beige), new RectangleF[] { collisionBox });
        }

        public void SetRunAnimation() { }

        public void SetAnimationAfterAttack() { }

        public void SetAnimation(int currentAnimation) { }

        public void StopEntity() { }

        public void Attack() { }
    }
}
