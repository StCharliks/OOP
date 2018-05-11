using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstFigures;

namespace OstaPaint.Geometry
{
    class Swastika: Shape, iPlagin
    {
        private int[] coords = new int[8];

        public override void draw(Graphics canvas)
        {
            base.draw(canvas);
        }
    }
}
