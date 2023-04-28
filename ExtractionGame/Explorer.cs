using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractionGame
{
    public class Explorer : Robot
    {
        public Explorer(): base() 
        {
        
        }
        public override void Draw(Graphics handler)
        {
            int size = 10;
            handler.FillEllipse(Brushes.Yellow, absLocation.X - size, absLocation.Y - size, 2 * size + 1, 2 * size + 1);
            handler.FillEllipse(Brushes.Black, absLocation.X - size, absLocation.Y - 2 * size, size / 2, size / 2);
            handler.DrawEllipse(Pens.White, absLocation.X - size, absLocation.Y - size, 2 * size + 1, 2 * size + 1);
        }
    }
}
