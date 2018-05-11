using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace OstaPaint.Geometry
{
    [DataContract]
    class Rectangle: Square
    {
        public override void draw(Graphics canvas)
        {
            canvas.DrawRectangle(new Pen(color, Width), LeftCorner.X, LeftCorner.Y, Math.Abs(RigthCorner.X - LeftCorner.X), Math.Abs(RigthCorner.Y - LeftCorner.Y));
        }

        public override void tempDraw(object sender, PaintEventArgs e)
        {
            LeftCorner = getHighLeftCorner(First, Last);
            RigthCorner = getBottomRightCorner(First, Last);
            e.Graphics.DrawRectangle(new Pen(color, Width), LeftCorner.X, LeftCorner.Y, Math.Abs(RigthCorner.X - LeftCorner.X), Math.Abs(RigthCorner.Y - LeftCorner.Y));
        }
    }
}
