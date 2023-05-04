using Game.Objects;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Timers;
using static Game.MVC;

namespace Game.Models
{
    public class Player : IEntity
    {
        public ProgressBar healthPoint { get; set; }
        public bool isAlive { get { return healthPoint.currentValue > 0; } set { healthPoint.currentValue = 1; } }
        public bool isImmunity { get; set; }

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

        public RectangleF collisionBox => new RectangleF(posX - 18, posY + 136, 36, 28);

        public RectangleF currentAttack;
        public RectangleF attackUp => new RectangleF(posX - 38, posY + 90, 76, 20);
        public RectangleF attackDown => new RectangleF(posX - 38, posY + 172, 76, 20);
        public RectangleF attackRight => new RectangleF(posX + 36, posY + 128, 24, 44);
        public RectangleF attackLeft => new RectangleF(posX - 60, posY + 128, 24, 44);

        public RectangleF position => new RectangleF(posX - flip * sizeX / 2, posY, flip * sizeX, sizeY);
        public Rectangle spriteSrc => new Rectangle(spriteSize * currentFrame, spriteSize * currentAnimation, spriteSize, spriteSize);

        private static Point _minPos, _maxPos;

        int currentTime = 0;
        int preiod = 5;

        private Timer immunityTimer = new Timer(500);

        public Player(int posX, int posY, ICreature model)
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
            healthPoint = new HealthBar(100, new Point(WindowWidth - 70, WindowHeight - 220));
            immunityTimer.Elapsed += ImmunityTimer_Elapsed;
        }

        private void ImmunityTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            isImmunity = false;
            immunityTimer.Stop();
        }

        public void Update()
        {
            if (isImmunity && !immunityTimer.Enabled)
            {
                immunityTimer.Start();
            }

            var flag1 = true;
            var flag2 = true;

            if (player.isAlive && !player.isAttack)
            {
                foreach (var e in mapController.currentLevel.entities.Where(x =>
                {
                    var type = x.GetType();
                    return type == typeof(Tree) || type == typeof(Bush) || type == typeof(Rock);
                }))
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

                if (flag1) posX = Clamp(posX += dirX, _minPos.X, _maxPos.X);
                if (flag2) posY = Clamp(posY += dirY, _minPos.Y, _maxPos.Y);

                SetRunAnimation();
            }
        }

        public static void SetBounds()
        {
            _minPos = new Point(MapController.cellSize + 20, -MapController.cellSize);
            _maxPos = new Point(mapController.GetWidth() - 192 / 2, mapController.GetHeight() - 240);
        }

        public static float Clamp(float value, float min, float max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }

        public bool IsMoving() => isMovingDown || isMovingUp || isMovingLeft || isMovingRight;

        public void PlayAnimation(Graphics g)
        {
            g.DrawImage(Textures.playerSheet, position, spriteSrc, GraphicsUnit.Pixel);
            healthPoint.Update();
            g.DrawString($"{posX},{posY}", new Font("Times New Roman", 12.0f), Brushes.AliceBlue, new PointF(posX, posY));


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
            foreach (var entity in Model.entities.Where(x => x.GetType() != typeof(Player)))
            {

                if (currentAttack.IntersectsWith(entity.collisionBox))
                {
                    entity.healthPoint.currentValue -= 10;
                }
            }
        }
    }
}
