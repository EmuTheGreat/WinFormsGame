using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class MapController
    {
        public const int mapHeight = 20;
        public const int mapWidth = 20;
        public static int cellSize = 64;
        public static int[,] map = new int[mapHeight, mapWidth];
        public static Image spriteSheet;
        public static Image spriteGrass;
        public static Image plainsSheet;

        public MapController(params Image[] sprites)
        {
            spriteGrass = sprites[0];
            plainsSheet = sprites[1];
            CreateMap();
        }

        public static void CreateMap()
        {
            map = new int[,]
            {
                {5, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 6},
                {9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11},
                {9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11},
                {9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11},
                {9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11},
                {9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11},
                {9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11},
                {9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11},
                {9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11},
                {9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11},
                {9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11},
                {9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11},
                {9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11},
                {9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11},
                {9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11},
                {9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11},
                {9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11},
                {9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11},
                {9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11},
                {4, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 7}
            };
        }

        public void DrawMap(Graphics g)
        {
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    var rect = new Rectangle(new Point(i * cellSize, j * cellSize), new Size(cellSize, cellSize));
                    var e = map[j, i];
                    switch (e)
                    {
                        case 0:
                            g.DrawImage(spriteGrass, rect, 0, 0, 64, 64, GraphicsUnit.Pixel);
                            break;
                        case 1:
                        case 2:
                        case 3:
                            g.DrawImage(plainsSheet, rect, 64 * e, 0, 64, 64, GraphicsUnit.Pixel);
                            break;
                        case 4:
                            g.DrawImage(spriteGrass, rect, 0, 0, 64, 64, GraphicsUnit.Pixel);
                            g.DrawImage(plainsSheet, rect, 256, 320, 64, 64, GraphicsUnit.Pixel);
                            break;
                        case 5:
                            g.DrawImage(spriteGrass, rect, 0, 0, 64, 64, GraphicsUnit.Pixel);
                            g.DrawImage(plainsSheet, rect, 256, 256, 64, 64, GraphicsUnit.Pixel);
                            break;
                        case 6:
                            g.DrawImage(spriteGrass, rect, 0, 0, 64, 64, GraphicsUnit.Pixel);
                            g.DrawImage(plainsSheet, rect, 320, 256, 64, 64, GraphicsUnit.Pixel);
                            break;
                        case 7:
                            g.DrawImage(spriteGrass, rect, 0, 0, 64, 64, GraphicsUnit.Pixel);
                            g.DrawImage(plainsSheet, rect, 320, 320, 64, 64, GraphicsUnit.Pixel);
                            break;
                        case 8:
                            g.DrawImage(spriteGrass, rect, 0, 0, 64, 64, GraphicsUnit.Pixel);
                            g.DrawImage(plainsSheet, rect, 128, 384, 64, 64, GraphicsUnit.Pixel);
                            break;
                        case 9:
                            g.DrawImage(spriteGrass, rect, 0, 0, 64, 64, GraphicsUnit.Pixel);
                            g.DrawImage(plainsSheet, rect, 196, 320, 60, 64, GraphicsUnit.Pixel);
                            break;
                        case 10:
                            g.DrawImage(spriteGrass, rect, 0, 0, 64, 64, GraphicsUnit.Pixel);
                            g.DrawImage(plainsSheet, rect, 128, 256, 60, 64, GraphicsUnit.Pixel);
                            break;
                        case 11:
                            g.DrawImage(spriteGrass, rect, 0, 0, 64, 64, GraphicsUnit.Pixel);
                            g.DrawImage(plainsSheet, rect, 64, 320, 60, 64, GraphicsUnit.Pixel);
                            break;
                    }
                }
            }
        }

        public int GetWidth()
        {
            return cellSize * mapWidth + 15;
        }
        public int GetHeight()
        {
            return cellSize * mapHeight + 14;
        }
    }
}
