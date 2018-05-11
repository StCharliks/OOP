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
    class Square: Shape
    {
        [DataMember]
        private Point leftCorner;
        public Point LeftCorner
        {
            get
            {
                return leftCorner;
            }
            set
            {
                leftCorner = value;
            }
        }
        [DataMember]
        private Point rigthCorner;
        public Point RigthCorner
        {
            get
            {
                return rigthCorner;
            }
            set
            {
                rigthCorner = value;
            }
        }

        public override void draw(Graphics canvas)
        {
            canvas.DrawRectangle(new Pen(color, Width), leftCorner.X, leftCorner.Y, Math.Abs(rigthCorner.X - leftCorner.X), Math.Abs(rigthCorner.Y - leftCorner.Y));
        }

        public override void tempDraw(object sender, PaintEventArgs e)
        {
            Last = CornerCorrection(First, Last);
            leftCorner = getHighLeftCorner(First, Last);
            rigthCorner = getBottomRightCorner(First, Last);
            e.Graphics.DrawRectangle(new Pen(color, Width), leftCorner.X, leftCorner.Y, Math.Abs(rigthCorner.X - leftCorner.X), Math.Abs(rigthCorner.Y - leftCorner.Y));
        }

        private Point CornerCorrection(Point left, Point rigth)
        {
            int distance = (int)Math.Round(Math.Sqrt(Math.Pow(left.X - rigth.X, 2) + Math.Pow(left.Y - rigth.Y, 2)));
            int offset = (int)Math.Round(distance / Math.Sqrt(2));

            int offsetX = (left.X < rigth.X) ? offset : -offset;
            int offsetY = (left.Y < rigth.Y) ? offset : -offset;

            return new Point(left.X + offsetX, left.Y + offsetY);
        }

        private int returnOffset(Point left, Point rigth)
        {
            int distance = (int)Math.Round(Math.Sqrt(Math.Pow(left.X - rigth.X, 2) + Math.Pow(left.Y - rigth.Y, 2)));
            return (int)Math.Round(Math.Sqrt(distance));
        }
    }
}
