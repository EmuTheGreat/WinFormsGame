using Game.interfaces;
using Game.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Game.Levels
{
    public class Level1 : ILevel
    {
        private const int height = 11;
        private const int width = 15;
        public int mapWidth => width;
        public int mapHeight => height;
        private List<IEntity> entities = new List<IEntity>();
        public List<IEntity> Entities { get { return entities; } set { entities = value; } }


        public Rectangle enter => new Rectangle(0, height * MapController.cellSize / 2 - MapController.cellSize + 32, 
            MapController.cellSize, 2 * MapController.cellSize - 64);
        public Rectangle exit => new Rectangle(width * MapController.cellSize - 64, 
            height * MapController.cellSize / 2 - MapController.cellSize + 32, MapController.cellSize, 2 * MapController.cellSize - 64);

        public int[,] map => new int[height, width]
        {
            {5,8,8,8,8,8,8,8,8,8,8,8,8,8,6},
            {9,0,0,0,0,0,0,0,0,0,0,0,0,0,11},
            {9,0,0,0,0,0,0,0,0,0,0,0,0,0,11},
            {9,0,0,0,0,0,0,0,0,0,0,0,0,0,11},
            {35,0,0,0,0,0,0,0,0,0,0,0,0,0,33},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {36,0,0,0,0,0,0,0,0,0,0,0,0,0,34},
            {9,0,0,0,0,0,0,0,0,0,0,0,0,0,11},
            {9,0,0,0,0,0,0,0,0,0,0,0,0,0,11},
            {9,0,0,0,0,0,0,0,0,0,0,0,0,0,11},
            {4,10,10,10,10,10,10,10,10,10,10,10,10,10,7},
        };

        public Point enterPosition => new Point(100, 200);

        public Point exitPosition => new Point(870, 200);
    }
}
