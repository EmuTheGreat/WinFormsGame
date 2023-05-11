using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.interfaces
{
    public interface ILevel
    {
        Point enterPosition { get; }
        Point exitPosition { get; }
        Rectangle enter { get; }
        Rectangle exit { get; }
        int[,] map { get; }
        int mapWidth { get; }
        int mapHeight { get; }
        List<IEntity> Entities { get; set; }
    }
}
