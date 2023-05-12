using System.Drawing;


namespace Game
{
    public interface IEntity
    {
        int Damage { get; set; }
        ProgressBar healthPoint { get; set; }
        bool isAlive { get; set; }

        float posX { get; set; }
        float posY { get; set; }

        float dirX { get; set; }
        float dirY { get; set; }
        int speed { get; set; }

        bool isMovingLeft { get; }
        bool isMovingRight { get; }
        bool isMovingUp { get; }
        bool isMovingDown { get; }
        bool isAttack { get; }
        bool deathAnimationFlag { get; }

        int currentFrame { get; set; }
        int currentAnimation { get; set; }
        int currentLimit { get; set; }
        int idleFrames { get; set; }
        int runFrames { get; set; }
        int attackFrames { get; set; }
        int deathFrames { get; set; }

        int spriteSize { get; set; }
        int sizeX { get; set; }
        int sizeY { get; set; }
        int flip { get; set; }
        int delta { get; set; }

        RectangleF position { get; }
        RectangleF collisionBox { get; }

        void Update();

        bool IsMoving();

        void PlayAnimation(Graphics g);

        void SetRunAnimation();

        void SetAnimation(int currentAnimation);

        void StopEntity();

        void Attack();
        void SetBounds();
    }
}
