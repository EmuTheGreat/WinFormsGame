using Game.interfaces;
using static Game.MVC;
using System.Drawing;
using Game.Levels;
using System.Collections.Generic;
using Game.Objects;
using Game.Models;
using System.Collections;

namespace Game
{
    public class MapController
    {
        public LevelNode currentLevel;
        public const int cellSize = 64;
        public const int spriteSize = 16;

        public LinckedLevels levels;

        public MapController()
        {
            levels = GenerateLevels();
            currentLevel = levels.Head;
        }

        public void ChangeCurrentLevel(bool direction)
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
            currentLevel.Level.Entities.ForEach(e => e.SetBounds());
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
                        case 35:
                            DrawSprite(Textures.grassSprite, rect, 0, 0, g);
                            DrawSprite(Textures.plainsSheet, rect, 48, 96, g);
                            break;
                        case 36:
                            DrawSprite(Textures.grassSprite, rect, 0, 0, g);
                            DrawSprite(Textures.plainsSheet, rect, 48, 64, g);
                            break;
                    }
                }
            }
            //g.DrawRectangle(new Pen(Color.Black), currentLevel.Level.exit);
            //g.DrawRectangle(new Pen(Color.Black), currentLevel.Level.enter);
        }

        private void DrawSprite(Image image, Rectangle rect, int srcX, int srcY, Graphics g)
        {
            g.DrawImage(image, rect, srcX, srcY, spriteSize, spriteSize, GraphicsUnit.Pixel);
        }

        public int GetWidth() => cellSize * currentLevel.Level.mapWidth + 15;
        public int GetHeight() => cellSize * currentLevel.Level.mapHeight + 14;

        private LinckedLevels GenerateLevels()
        {
            LinckedLevels levels = new LinckedLevels();
            var patterns = new LevelPatterns();
            levels.Add(new LevelStart());

            foreach(var p in patterns.patterns)
            {
                levels.Add(new Level1 { Entities = p });
            }
            
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

    public class LinckedLevels : IEnumerable<LevelNode>
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<LevelNode> IEnumerable<LevelNode>.GetEnumerator()
        {
            LevelNode current = Head;
            while (current != null)
            {
                yield return current;
                current = current.NextLevel;
            }
        }
    }

    class LevelPatterns
    {
        static SlimeModel slimeModel = new SlimeModel();
        public List<List<IEntity>> patterns = new List<List<IEntity>>
        {
            pattern1,
            pattern2
        };

        public static List<IEntity> pattern1 = new List<IEntity>
        {
            new Rock(new Point(64, 256)),
            new Rock(new Point(128, 256)),
            new Rock(new Point(192, 256)),
            new Rock(new Point(256, 256)),
            new Rock(new Point(320, 256)),
            new Rock(new Point(320, 210)),
            new Rock(new Point(320, 110)),
            new Rock(new Point(320, 64)),
            new Slime(128, 32, slimeModel),

            new Rock(new Point(64, 384)),
            new Rock(new Point(128, 384)),
            new Rock(new Point(192, 384)),
            new Rock(new Point(256, 384)),
            new Rock(new Point(320, 384)),
            new Rock(new Point(320, 430)),
            new Rock(new Point(320, 558)),
            new Rock(new Point(320, 606)),
            new Slime(128, 532, slimeModel),

            new Rock(new Point(576, 384)),
            new Rock(new Point(640, 384)),
            new Rock(new Point(704, 384)),
            new Rock(new Point(768, 384)),
            new Rock(new Point(832, 384)),
            new Rock(new Point(576, 430)),
            new Rock(new Point(576, 558)),
            new Rock(new Point(576, 606)),
            new Slime(800, 532, slimeModel),

            new Rock(new Point(576, 256)),
            new Rock(new Point(640, 256)),
            new Rock(new Point(704, 256)),
            new Rock(new Point(768, 256)),
            new Rock(new Point(832, 256)),
            new Rock(new Point(576, 210)),
            new Rock(new Point(576, 110)),
            new Rock(new Point(576, 64)),
            new Slime(800, 32, slimeModel),

        };
        public static List<IEntity> pattern2 = new List<IEntity>
        {
            new Rock(new Point(200, 360)),
            new Rock(new Point(720, 440)),
            new Rock(new Point(300, 32)),
            new Tree(new Point(600, 0)),
            new Slime(800, 532, slimeModel),
            new Slime(200, 453, slimeModel),
            new Slime(500, 300, slimeModel),
            new Rock(new Point(832, 256)),
            new Rock(new Point(832, 304)),
            new Rock(new Point(832, 352)),
            new Rock(new Point(832, 400))
        };
    }
}
