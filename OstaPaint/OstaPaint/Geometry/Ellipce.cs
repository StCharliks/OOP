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
    class Ellipce: Shape
    {
        [DataMember]
        private Point leftCorner;
        [DataMember]
        private Point rigthCorner;

        private Point getLeftCorner() { return new Point(); }
        public Ellipce()
        { }

        public override void draw(Graphics canvas)
        {
            //leftCorner = getHighLeftCorner(First, Last);
            //rigthCorner = getBottomRightCorner(First, Last);
            canvas.DrawEllipse(new Pen(color, Width), leftCorner.X, leftCorner.Y, Math.Abs(rigthCorner.X - leftCorner.X), Math.Abs(rigthCorner.Y - leftCorner.Y));
        }

        public override void tempDraw(object sender, PaintEventArgs e)
        {
            leftCorner = getHighLeftCorner(First, Last);
            rigthCorner = getBottomRightCorner(First, Last);
            e.Graphics.DrawEllipse(new Pen(color, Width), leftCorner.X, leftCorner.Y, Math.Abs(rigthCorner.X - leftCorner.X), Math.Abs(rigthCorner.Y - leftCorner.Y));
        }
    }
}
