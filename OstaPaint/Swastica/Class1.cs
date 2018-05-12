using System;
using OstFigures;
using System.Runtime.Serialization;
using System.Drawing;
using System.Windows.Forms;

namespace Swastica
{
    [DataContract]
    public class Swaston:Square
    {
        [DataMember]
        public String name = "Свастика";
        [DataMember]
        protected Point[] pointH = new Point[4];
        [DataMember]
        protected Point[] pointV = new Point[4];
        

        public override void draw(Graphics canvas)
        {
            canvas.DrawLines(new Pen(color, Width), pointH);
            canvas.DrawLines(new Pen(color, Width), pointV);
        }

        public override void tempDraw(object sender, PaintEventArgs e)
        {
            Last = CornerCorrection(First, Last);
            LeftCorner = getHighLeftCorner(First, Last);
            RigthCorner = getBottomRightCorner(First, Last);
            pointH = calculateH();
            pointV = calculateV();
            e.Graphics.DrawLines(new Pen(color, Width), pointH);
            e.Graphics.DrawLines(new Pen(color, Width), pointV);
        }

        protected Point[] calculateH()
        {
            Point[] Coord = new Point[4];
            Coord[0] = LeftCorner;
            Coord[3] = RigthCorner;
            int offsetX = (RigthCorner.X - LeftCorner.X)/2;
            offsetX = (int)Math.Round((decimal)offsetX);
            Coord[1] = new Point(LeftCorner.X + offsetX, LeftCorner.Y);
            Coord[2] = new Point(LeftCorner.X + offsetX, RigthCorner.Y);

            return Coord;
        }

        protected Point[] calculateV()
        {
            Point[] Coord = new Point[4];
            Coord[0] = new Point(RigthCorner.X, LeftCorner.Y);
            Coord[3] = new Point(LeftCorner.X, RigthCorner.Y);
            int offsetY = (LeftCorner.Y - RigthCorner.Y)/2;
            offsetY = (int)Math.Round((decimal)offsetY);
            Coord[1] = new Point(RigthCorner.X, LeftCorner.Y - offsetY);
            Coord[2] = new Point(LeftCorner.X, LeftCorner.Y - offsetY);

            return Coord;
        }
    }

    public class Wheel:Swaston
    {
        public override void draw(Graphics canvas)
        {
            canvas.DrawEllipse(new Pen(color, Width), LeftCorner.X, LeftCorner.Y, Math.Abs(RigthCorner.X - LeftCorner.X), Math.Abs(RigthCorner.Y - LeftCorner.Y));
            canvas.DrawLines(new Pen(color, Width), pointH);
            canvas.DrawLines(new Pen(color, Width), pointV);
        }

        public override void tempDraw(object sender, PaintEventArgs e)
        {
            Last = CornerCorrection(First, Last);
            LeftCorner = getHighLeftCorner(First, Last);
            RigthCorner = getBottomRightCorner(First, Last);
            pointH = calculateH();
            pointV = calculateV();
            e.Graphics.DrawLines(new Pen(color, Width), pointH);
            e.Graphics.DrawLines(new Pen(color, Width), pointV);
            e.Graphics.DrawEllipse(new Pen(color, Width), LeftCorner.X, LeftCorner.Y, Math.Abs(RigthCorner.X - LeftCorner.X), Math.Abs(RigthCorner.Y - LeftCorner.Y));

        }
    }
}
