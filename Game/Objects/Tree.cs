﻿using System;
using System.Drawing;

namespace Game.Objects
{
    public class Tree : IEntity
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
        public int Damage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Tree(Point position)
        {
            posX = position.X;
            posY = position.Y;
            sizeX = 192;
            sizeY = 256;
            this.position = new RectangleF(position, new Size(sizeX, sizeY));
            collisionBox = new RectangleF(position.X + 48, position.Y + 174, 96, 56);
            delta = 10;
        }

        public void Update() { }

        public bool IsMoving() { return false; }

        public void PlayAnimation(Graphics g)
        {
            DrawObject(Textures.objectsSheet, position, new Rectangle(new Point(0, 80), new Size(46, 64)), g);
        }
        private void DrawObject(Image image, RectangleF rect, Rectangle rectSrc, Graphics g)
        {
            g.DrawImage(image, rect, rectSrc, GraphicsUnit.Pixel);
        }

        public void SetRunAnimation() { }

        public void SetAnimationAfterAttack() { }

        public void SetAnimation(int currentAnimation) { }

        public void StopEntity() { }

        public void Attack() { }
        public void SetBounds() { }
    }
}
