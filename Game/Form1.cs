﻿using static Game.MVC;
using System;
using System.Windows.Forms;
using System.Linq;
using Game.Models;
using Game.Objects;

namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            timer1.Interval = 5;
            timer1.Tick += new EventHandler(Update);
            KeyDown += new KeyEventHandler(Controller.KeyPress);
            KeyUp += new KeyEventHandler(Controller.KeyUp);

            timer1.Start();
        }

        public void Update(object sendler, EventArgs e)
        {
            if (player.isAlive)
            {
                foreach (var entity in Model.entities.Where(x => x.isAlive && x.GetType() != typeof(Tree)))
                {
                    entity.Update();
                }
            }
            Invalidate();
        }
    }
}
