using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace OstaPaint.Geometry
{
    [DataContract]
    class Trianle: Shape
    {
        [DataMember]
        private Point[] points = new Point[3];

        public override void draw(Graphics canvas)
        {
            canvas.DrawPolygon(new Pen(color, Width), points);
        }

        public override void tempDraw(object sender, PaintEventArgs e)
        {
            points = getPoints(First, Last);

            e.Graphics.DrawPolygon(new Pen(color, Width), points);
        }

        private int getSideLength(Point first, Point last)
        {
            return Math.Abs(first.Y - last.Y);
        }

        private int getOffsetY(Point first, Point last, int sideLength)
        {
            return (first.Y < last.Y) ? sideLength : -sideLength;
        }

        private Point[] getPoints(Point first, Point last)
        {
            int sideLength = getSideLength(first, last);
            last = new Point(first.X, first.Y + getOffsetY(first, last, sideLength));

            Point[] coords = new Point[3];

            int offsetX = (int)Math.Round(sideLength / Math.Sqrt(5));
            coords[0] = first;
            coords[1] = new Point(last.X + offsetX, last.Y);
            coords[2] = new Point(last.X - offsetX, last.Y);

            return coords;
        }
    }
}
