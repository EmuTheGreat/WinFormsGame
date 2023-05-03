using System;
using static Game.MVC;
using System.Drawing;
using System.Linq;
using Game.Objects;
using System.Numerics;

namespace Game.Models
{
    public class Slime : IEntity
    {
        public ProgressBar healthPoint { get; set; }
        public bool isAlive { get; set; }

        public float posX { get; set; }
        public float posY { get; set; }

        public float dirX { get; set; }
        public float dirY { get; set; }
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
        public int sizeX { get; set; }
        public int sizeY { get; set; }
        public int flip { get; set; }
        public int delta { get; set; }

        private static Point _minPos, _maxPos;
        public RectangleF collisionBox => new RectangleF(posX - 26, posY + 52, 48, 36);
        public RectangleF position => new RectangleF(posX, posY, sizeX, sizeY);
        public RectangleF spriteSrc => new RectangleF(spriteSize * currentFrame, spriteSize * currentAnimation, spriteSize, spriteSize);

        private int currentTime = 0;
        private int period = 8;
        private int attackTime = 20;
        private int attackPeriod = 100;

        public Slime(int posX, int posY, ICreature model)
        {
            this.posX = posX;
            this.posY = posY;
            idleFrames = model.idleFrames;
            runFrames = model.runFrames;
            attackFrames = model.attackFrames;
            deathFrames = model.deathFrames;
            sizeX = model.size;
            sizeY = model.size;
            spriteSize = model.spriteSize;
            speed = model.speed;
            delta = model.delta;
            currentLimit = idleFrames;
            flip = 1;
            isAlive = true;
        }

        private void Move()
        {
            Vector2 direction = Vector2.Normalize(new Vector2(player.collisionBox.Right / 2 - collisionBox.Right / 2,
                player.collisionBox.Bottom / 2 - collisionBox.Bottom / 2));
            Vector2 velocity = direction * speed;
            dirX = velocity.X;
            dirY = velocity.Y;
        }

        public double GetDistance(RectangleF rS, RectangleF rP)
        {
            return Math.Sqrt(Math.Pow((rS.Right / 2) - (rP.Right / 2), 2)
               + Math.Pow(rS.Bottom / 2 - (rP.Bottom / 2), 2));
        }

        public void Update()
        {
            var flag1 = true;
            var flag2 = true;

            if (++attackTime > attackPeriod && !isAttack && GetDistance(collisionBox, player.collisionBox) < 130)
            {
                SetAnimation(2);
                Move();
                flip = player.collisionBox.Right / 2 > collisionBox.Right / 2 ? 1 : -1;
                isAttack = true;
                attackTime = 0;
            }

            foreach (var e in mapController.currentLevel.entities.Where(x =>
            {
                var type = x.GetType();
                return type == typeof(Tree);
            }))
            #region
            {
                if (new RectangleF(collisionBox.X + dirX, collisionBox.Y, collisionBox.Width, collisionBox.Height).IntersectsWith(e.collisionBox))
                {
                    flag1 = false;
                }
                if (new RectangleF(collisionBox.X, collisionBox.Y + dirY, collisionBox.Width, collisionBox.Height).IntersectsWith(e.collisionBox))
                {
                    flag2 = false;
                }
            }
            #endregion

            if (flag1) posX = Player.Clamp(posX += dirX, _minPos.X, _maxPos.X);
            if (flag2) posY = Player.Clamp(posY += dirY, _minPos.Y, _maxPos.Y);

            Attack();
        }

        public bool IsMoving() => isMovingDown || isMovingUp || isMovingLeft || isMovingRight;

        public void PlayAnimation(Graphics g)
        {
            g.DrawImage(Textures.slimeSheet,
            new RectangleF(new PointF(posX - flip * (sizeX) / 2, posY), new Size(flip * sizeX, sizeX)),
            spriteSrc, GraphicsUnit.Pixel);

            if (++currentTime > period)
            {
                currentTime = 0;
                currentFrame = ++currentFrame % currentLimit;
            }

            if (!isAlive)
            {
                if (!deathAnimationFlag) SetAnimation(4);
                deathAnimationFlag = true;
                if (currentFrame == 5) --currentFrame;
            }

            if (isAttack)
            {
                if (currentFrame == attackFrames - 1)
                {
                    isAttack = false;
                    StopEntity();
                    SetAnimation(0);
                }
            }
        }

        public void SetRunAnimation()
        {
            if (IsMoving()) currentAnimation = 1;
            currentLimit = runFrames;
        }

        public static void SetBounds()
        {
            _minPos = new Point(MapController.cellSize + 22, -MapController.cellSize + 64);
            _maxPos = new Point(mapController.GetWidth() - 128 / 2 - 32, mapController.GetHeight() - 160);
        }

        public void SetAnimation(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 0:
                    currentFrame = 0;
                    this.currentAnimation = currentAnimation;
                    currentLimit = idleFrames;
                    break;
                case 4:
                    currentFrame = 0;
                    this.currentAnimation = currentAnimation;
                    currentLimit = deathFrames;
                    break;
                case 2:
                    currentFrame = 0;
                    this.currentAnimation = currentAnimation;
                    currentLimit = attackFrames;
                    break;
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
            if (!player.isImmunity && player.collisionBox.IntersectsWith(collisionBox))
            {
                player.isImmunity = true;
                player.healthPoint.currentValue -= 10;
            }
        }
    }
}

