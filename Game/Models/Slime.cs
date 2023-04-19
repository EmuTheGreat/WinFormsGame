namespace Game.Models
{
    public class Slime : ICreature
    {
        public int size => 128;

        public int speed => 2;

        int ICreature.idleFrames => 4;

        int ICreature.runFrames => 6;

        int ICreature.attackFrames => 7;

        int ICreature.deathFrames => 5;
    }
}
