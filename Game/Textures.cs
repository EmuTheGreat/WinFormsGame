﻿using System.Drawing;
using System.IO;

namespace Game
{
    public static class Textures
    {
        public static Image playerSheet;
        public static Image grassSprite;
        public static Image plainsSheet;
        public static Image slimeSheet;
        public static Image objectsSheet;
        public static Image decorSheet;
        public static Image healthBar;
        public static Image level1;

        public static void LoadContent()
        {
            playerSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                    "Content\\characters\\player.png"));
            grassSprite = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                "Content\\tilesets\\grass.png"));
            plainsSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                "Content\\tilesets\\plains.png"));
            slimeSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                "Content\\characters\\slime.png"));
            decorSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                "Content\\tilesets\\decor_16x16.png"));
            objectsSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                "Content\\objects\\objects.png"));
            healthBar = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                "Content\\characters\\Heart.png"));
            level1 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                "Content\\Levels\\LevelStart.png"));
        }
    }
}
