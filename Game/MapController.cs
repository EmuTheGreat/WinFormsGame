using Game.interfaces;
using static Game.MVC;
using System.Drawing;
using Game.Levels;

namespace Game
{
    public class MapController
    {
        public LevelNode currentLevel;
        public const int cellSize = 64;
        public const int spriteSize = 16;

        public LinckedLevels levels;

        public MapController(ILevel level)
        {
            levels = new LinckedLevels();
            levels.Add(level);
            levels.Add(new Level1());
            currentLevel = levels.Head;
        }

        public void ChangeCurrentLevel(bool direction, Graphics g)
        {
            if (direction)
            {
                currentLevel = currentLevel.NextLevel;
                player.posX = currentLevel.Level.enterPosition.X;
                player.posY = currentLevel.Level.enterPosition.Y;
            }
            else 
            { 
                currentLevel = currentLevel.PreviousLevel;
                player.posX = currentLevel.Level.exitPosition.X;
                player.posY = currentLevel.Level.exitPosition.Y;
            }
            currentLevel.Level.entities.ForEach(e => e.SetBounds());
            player.SetBounds();
        }

        public void DrawMap(Graphics g)
        {
            for (int i = 0; i < currentLevel.Level.mapWidth; i++)
            {
                for (int j = 0; j < currentLevel.Level.mapHeight; j++)
                {
                    var rect = new Rectangle(new Point(i * cellSize, j * cellSize), new Size(66, 66));
                    var e = currentLevel.Level.map[j, i];
                    switch (e)
                    {
                        case 0:
                            DrawSprite(Textures.grassSprite, rect, 0, 0, g);
                            break;
                        case 1:
                        case 2:
                        case 3:
                            DrawSprite(Textures.plainsSheet, rect, 16 * e, 0, g);
                            break;
                        case 4:
                            DrawSprite(Textures.grassSprite, rect, 0, 0, g);
                            DrawSprite(Textures.plainsSheet, rect, 64, 80, g);
                            break;
                        case 5:
                            DrawSprite(Textures.grassSprite, rect, 0, 0, g);
                            DrawSprite(Textures.plainsSheet, rect, 64, 64, g);
                            break;
                        case 6:
                            DrawSprite(Textures.grassSprite, rect, 0, 0, g);
                            DrawSprite(Textures.plainsSheet, rect, 80, 64, g);
                            break;
                        case 7:
                            DrawSprite(Textures.grassSprite, rect, 0, 0, g);
                            DrawSprite(Textures.plainsSheet, rect, 80, 80, g);
                            break;
                        case 8:
                            DrawSprite(Textures.grassSprite, rect, 0, 0, g);
                            DrawSprite(Textures.plainsSheet, rect, 32, 96, g);
                            break;
                        case 9:
                            DrawSprite(Textures.grassSprite, rect, 0, 0, g);
                            DrawSprite(Textures.plainsSheet, rect, 48, 80, g);
                            break;
                        case 10:
                            DrawSprite(Textures.grassSprite, rect, 0, 0, g);
                            DrawSprite(Textures.plainsSheet, rect, 32, 64, g);
                            break;
                        case 11:
                            DrawSprite(Textures.grassSprite, rect, 0, 0, g);
                            DrawSprite(Textures.plainsSheet, rect, 16, 80, g);
                            break;
                        case 12:
                            DrawSprite(Textures.plainsSheet, rect, 0, 48, g);
                            break;
                        case 13:
                            DrawSprite(Textures.plainsSheet, rect, 16, 16, g);
                            break;
                        case 14:
                            DrawSprite(Textures.plainsSheet, rect, 32, 16, g);
                            break;
                        case 15:
                            DrawSprite(Textures.plainsSheet, rect, 48, 16, g);
                            break;
                        case 16:
                            DrawSprite(Textures.plainsSheet, rect, 16, 32, g);
                            break;
                        case 17:
                            DrawSprite(Textures.plainsSheet, rect, 32, 32, g);
                            break;
                        case 18:
                            DrawSprite(Textures.plainsSheet, rect, 48, 32, g);
                            break;
                        case 19:
                            DrawSprite(Textures.plainsSheet, rect, 64, 0, g);
                            break;
                        case 20:
                            DrawSprite(Textures.plainsSheet, rect, 80, 0, g);
                            break;
                        case 21:
                            DrawSprite(Textures.plainsSheet, rect, 64, 16, g);
                            break;
                        case 22:
                            DrawSprite(Textures.plainsSheet, rect, 80, 16, g);
                            break;
                        case 23:
                            DrawSprite(Textures.plainsSheet, rect, 64, 32, g);
                            break;
                        case 24:
                            DrawSprite(Textures.plainsSheet, rect, 80, 32, g);
                            break;
                        case 25:
                            DrawSprite(Textures.decorSheet, rect, 0, 0, g);
                            break;
                        case 26:
                            DrawSprite(Textures.decorSheet, rect, 16, 0, g);
                            break;
                        case 27:
                            DrawSprite(Textures.decorSheet, rect, 32, 0, g);
                            break;
                        case 28:
                            DrawSprite(Textures.decorSheet, rect, 48, 0, g);
                            break;
                        case 29:
                            DrawSprite(Textures.plainsSheet, rect, 32, 16, g);
                            DrawSprite(Textures.decorSheet, rect, 0, 64, g);
                            break;
                        case 30:
                            DrawSprite(Textures.plainsSheet, rect, 32, 16, g);
                            DrawSprite(Textures.decorSheet, rect, 16, 64, g);
                            break;
                        case 31:
                            DrawSprite(Textures.plainsSheet, rect, 32, 16, g);
                            DrawSprite(Textures.decorSheet, rect, 32, 64, g);
                            break;
                        case 32:
                            DrawSprite(Textures.plainsSheet, rect, 32, 16, g);
                            DrawSprite(Textures.decorSheet, rect, 48, 64, g);
                            break;
                        case 33:
                            DrawSprite(Textures.grassSprite, rect, 0, 0, g);
                            DrawSprite(Textures.plainsSheet, rect, 16, 96, g);
                            break;
                        case 34:
                            DrawSprite(Textures.grassSprite, rect, 0, 0, g);
                            DrawSprite(Textures.plainsSheet, rect, 16, 64, g);
                            break;
                    }
                }
            }
            g.DrawRectangle(new Pen(Color.Black), currentLevel.Level.exit);
        }

        private void DrawSprite(Image image, Rectangle rect, int srcX, int srcY, Graphics g)
        {
            g.DrawImage(image, rect, srcX, srcY, spriteSize, spriteSize, GraphicsUnit.Pixel);
        }

        public int GetWidth() => cellSize * currentLevel.Level.mapWidth + 15;
        public int GetHeight() => cellSize * currentLevel.Level.mapHeight + 14;

        private LinckedLevels GenerateLevels(LinckedLevels levels)
        {
            return levels;
        }
    }

    public class LevelNode
    {
        public ILevel Level { get; set; }
        public LevelNode PreviousLevel { get; set; }
        public LevelNode NextLevel { get; set; }

        public LevelNode(ILevel level)
        {
            Level = level;
        }
    }

    public class LinckedLevels
    {
        public LevelNode Head { get; set; }
        public LevelNode Tail { get; set; }

        public void Add(ILevel level)
        {
            LevelNode node = new LevelNode(level);

            if (Head == null)
                Head = node;
            else
            {
                Tail.NextLevel = node;
                node.PreviousLevel = Tail;
            }
            Tail = node;
        }
    }
}
