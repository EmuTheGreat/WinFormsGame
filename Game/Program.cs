using System;
using System.Drawing;
using System.Windows.Forms;
using Game.Models;
using System.IO;

namespace Game
{
    public class MVC
    {
        public static Entity slime;
        public static Entity player;
        public static MapController map;

        public class Model
        {
            public static Image playerSheet;
            public static Image grassSprite;
            public static Image plainsSheet;
            public static Image slimeSheet;

            public Model()
            {
                #region Textures
                playerSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                    "Content\\characters\\playerEnlarged++.png"));
                grassSprite = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                    "Content\\tilesets\\grassEnlarged.png"));
                plainsSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                    "Content\\tilesets\\plainsEnlarged.png"));
                slimeSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                    "Content\\characters\\slimeEnlarged.png"));
                #endregion

                slime = new Entity(800, 800, new Slime(), slimeSheet);
                player = new Entity(512, 256, new Player(), playerSheet);

                map = new MapController(grassSprite, plainsSheet);
            }
        }

        public class Controller
        {
            public static void KeyPress(object sender, KeyEventArgs e)
            {
                if (player.isAlive)
                {
                    switch (e.KeyCode)
                    {
                        #region Move
                        case Keys.W:
                            player.dirY = -player.speed;
                            player.isMovingUp = true;
                            break;
                        case Keys.S:
                            player.dirY = player.speed;
                            player.isMovingDown = true;
                            break;
                        case Keys.A:
                            player.dirX = -player.speed;
                            player.isMovingLeft = true;
                            player.flip = -1;
                            break;
                        case Keys.D:
                            player.dirX = player.speed;
                            player.isMovingRight = true;
                            player.flip = 1;
                            break;
                        case Keys.J:
                            player.isAlive = false;
                            break;
                        #endregion

                        #region Attack
                        case Keys.Up:
                            if (!player.isAttack)
                            {
                                player.isAttack = true;
                                player.SetAnimation(8);
                            }
                            break;
                        case Keys.Down:
                            if (!player.isAttack)
                            {
                                player.isAttack = true;
                                player.SetAnimation(6);
                            }
                            break;
                        case Keys.Left:
                            if (!player.isAttack)
                            {
                                player.isAttack = true;
                                player.flip = -1;
                                player.SetAnimation(7);
                            }
                            break;
                        case Keys.Right:
                            if (!player.isAttack)
                            {
                                player.isAttack = true;
                                player.flip = 1;
                                player.SetAnimation(7);
                            }
                            break;
                            #endregion
                    }
                }
                if (e.KeyCode == Keys.K)
                {
                    player.isAlive = true;
                    player.deathAnimationFlag = false;
                    player.SetAnimation(1);
                }
            }

            public static void KeyUp(object sender, KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        player.dirY = player.isMovingDown ? player.dirY : 0;
                        player.isMovingUp = false;
                        if (player.isAlive && !player.IsMoving()) player.SetAnimation(2);
                        break;
                    case Keys.S:
                        player.dirY = player.isMovingUp ? player.dirY : 0;
                        player.isMovingDown = false;
                        if (player.isAlive && !player.IsMoving()) player.SetAnimation(0);
                        break;
                    case Keys.A:
                        player.dirX = player.isMovingRight ? player.dirX : 0;
                        player.isMovingLeft = false;
                        if (player.isAlive && !player.IsMoving()) player.SetAnimation(1);
                        break;
                    case Keys.D:
                        player.dirX = player.isMovingLeft ? player.dirX : 0;
                        player.isMovingRight = false;
                        if (player.isAlive && !player.IsMoving()) player.SetAnimation(1);
                        break;
                }
            }
        }

        public class View
        {
            public static void Paint(object sender, PaintEventArgs e)
            {
                Graphics g = e.Graphics;

                int cameraX = player.posX - 1024 / 2;
                int cameraY = player.posY - 768 / 2;

                cameraX = Math.Max(0, Math.Min(map.GetWidth() - 1024, cameraX));
                cameraY = Math.Max(0, Math.Min(map.GetHeight() - 768 + 25, cameraY));

                g.TranslateTransform(-cameraX, -cameraY);

                map.DrawMap(g);
                player.PlayAnimation(g);
                slime.PlayAnimation(g);
            }
        }
    }

    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new MVC.Model();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1() { Size = new Size(1024, 768) });
        }
    }
}
