﻿namespace Game.Models
{
    public class Player : ICreature
    {
        public int size => 192;

        public int speed => 4;

        int ICreature.idleFrames => 6;

        int ICreature.runFrames => 6;

        int ICreature.attackFrames => 4;

        int ICreature.deathFrames => 4;
    }
}
