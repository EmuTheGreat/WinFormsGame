using Game.interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Levels
{
    public class Level1 : ILevel
    {
        private const int height = 11;
        private const int width = 15;
        public int mapWidth => width;
        public int mapHeight => height;

        public List<IEntity> entities => new List<IEntity>();

        public Rectangle enter => new Rectangle();
        public Rectangle exit => new Rectangle();

        public int[,] map => new int[height, width]
        {
            {5,8,8,8,8,8,8,8,8,8,8,8,8,8,6},
            {9,0,0,0,0,0,0,0,0,0,0,0,0,0,11},
            {9,0,0,0,0,0,0,0,0,0,0,0,0,0,11},
            {9,0,0,0,0,0,0,0,0,0,0,0,0,0,11},
            {9,0,0,0,0,0,0,0,0,0,0,0,0,0,11},
            {9,0,0,0,0,0,0,0,0,0,0,0,0,0,11},
            {9,0,0,0,0,0,0,0,0,0,0,0,0,0,11},
            {9,0,0,0,0,0,0,0,0,0,0,0,0,0,11},
            {9,0,0,0,0,0,0,0,0,0,0,0,0,0,11},
            {9,0,0,0,0,0,0,0,0,0,0,0,0,0,11},
            {4,10,10,10,10,10,10,10,10,10,10,10,10,10,7},
        };

        public Point enterPosition => new Point (100, 300);

        public Point exitPosition => throw new NotImplementedException();
    }
}
