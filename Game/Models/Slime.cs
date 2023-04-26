using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models
{
    public class Slime : IEntity
    {
        public int healthPoint { get; set; }
        public bool isAlive { get; set; }

        public int posX { get; set; }
        public int posY { get; set; }

        public int dirX { get; set; }
        public int dirY { get; set; }
        public int speed { get; set; }

        public bool isMovingLeft { get; set; }
        public bool isMovingRight { get; set; }
        public bool isMovingUp { get; set; }
        public bool isMovingDown { get; set; }
        public bool isAttack { get; set; }
        public bool deathAnimationFlag { get; set; }

        public int currentFrame { get; set; }
        public int currentAnimation { get; set; }
        public int currentLimit { get; set; }
        public int idleFrames { get; set; }
        public int runFrames { get; set; }
        public int attackFrames { get; set; }
        public int deathFrames { get; set; }

        public int spriteSize { get; set; }
        public int size { get; set; }
        public int flip { get; set; }
        public int delta { get; set; }

        public Image spriteSheet { get; set; }
        int currentTime = 0;
        int preiod = 8;

        public Slime(int posX, int posY, ICreature model, Image spriteSheet)
        {
            this.posX = posX;
            this.posY = posY;
            this.spriteSheet = spriteSheet;
            idleFrames = model.idleFrames;
            runFrames = model.runFrames;
            attackFrames = model.attackFrames;
            deathFrames = model.deathFrames;
            size = model.size;
            spriteSize = model.spriteSize;
            speed = model.speed;
            currentLimit = idleFrames;
            currentAnimation = 0;
            currentFrame = 0;
            flip = 1;
            isAlive = true;
            delta = model.delta;
        }

        public virtual void Move()
        {
            posX += dirX;
            posY += dirY;
        }

        public bool IsMoving() => isMovingDown || isMovingUp || isMovingLeft || isMovingRight;

        public void PlayAnimation(Graphics g)
        {
            g.DrawImage(spriteSheet,
            new Rectangle(new Point(posX - flip * (size) / 2, posY), new Size(flip * size, size)),
            spriteSize * currentFrame, spriteSize * currentAnimation, spriteSize, spriteSize, GraphicsUnit.Pixel);

            if (++currentTime > preiod)
            {
                currentTime = 0;
                currentFrame = ++currentFrame % currentLimit;
            }

            if (!isAlive)
            {
                if (!deathAnimationFlag) SetAnimation(9);
                deathAnimationFlag = true;
                if (currentFrame == 3) --currentFrame;
            }

            if (isAttack)
            {
                StopEntity();
                if (currentFrame == 3)
                {
                    isAttack = false;
                    SetAnimationAfterAttack();
                }
            }
        }

        public void SetRunAnimation()
        {
            if (isMovingRight || isMovingLeft) currentAnimation = 4;
            if (isMovingUp) currentAnimation = 5;
            else if (isMovingDown) currentAnimation = 3;
            currentLimit = runFrames;
        }

        public void SetAnimationAfterAttack()
        {
            switch (currentAnimation)
            {
                case 8:
                    SetAnimation(2);
                    break;
                case 6:
                    SetAnimation(0);
                    break;
                case 7:
                    SetAnimation(1);
                    break;
            }
        }

        public void SetAnimation(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 0:
                case 1:
                case 2:
                    currentLimit = runFrames; break;
                case 6:
                case 7:
                case 8:
                    currentFrame = 0;
                    currentLimit = attackFrames; break;
                case 9:
                    currentFrame = 0;
                    currentLimit = deathFrames; break;
            }
        }

        public void StopEntity()
        {
            dirX = 0;
            dirY = 0;
            isMovingUp = false;
            isMovingDown = false;
            isMovingLeft = false;
            isMovingRight = false;
        }

        public void Attack()
        {
            throw new NotImplementedException();
        }
    }
}

