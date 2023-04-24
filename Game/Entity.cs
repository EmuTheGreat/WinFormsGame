using Game.Models;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;

namespace Game
{
    public class Entity
    {
        public int healthPoint;
        public bool isAlive;

        public int posX;
        public int posY;

        public int dirX;
        public int dirY;
        public int speed;

        public bool isMovingLeft = false;
        public bool isMovingRight = false;
        public bool isMovingUp = false;
        public bool isMovingDown = false;
        public bool isAttack = false;
        public bool deathAnimationFlag = false;

        public int currentFrame;
        public int currentAnimation;
        public int currentLimit;
        public int idleFrames;
        public int runFrames;
        public int attackFrames;
        public int deathFrames;

        public int spriteSize;
        public int size;
        public int flip;

        public Image spriteSheet;
        int currentTime = 0;
        int preiod = 5;

        public Entity(int posX, int posY, ICreature model, Image spriteSheet)
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
            new Rectangle(new Point(posX - flip * (size + 4) / 2, posY), new Size(flip * size, size)),
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
    }
}
