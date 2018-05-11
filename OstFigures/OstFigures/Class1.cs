using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace OstFigures
{
    public interface iPlagin
    {
        void draw(Graphics canvas);
        void tempDraw(object sender, PaintEventArgs e);
        void drawInstance(Graphics canvas);
    }

    [DataContract]
    public abstract class Shape: iPlagin
    {
        [DataMember]
        private Color _color;
        public Color color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        [DataMember]
        private int width;
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        [DataMember]
        private Point first;
        public Point First
        {
            get
            {
                return first;
            }
            set
            {
                first = value;
            }
        }
        [DataMember]
        private Point last;
        public Point Last
        {
            get
            {
                return last;
            }
            set
            {
                last = value;
            }
        }

        public virtual void draw(Graphics canvas) { }
        public virtual void tempDraw(object sender, PaintEventArgs e) { }
        public virtual void drawInstance(Graphics canvas) { }

        //методы для повышения эффективности и удобства рисования
        protected Point getHighLeftCorner(Point p1, Point p2)
        {
            Point pHigthLeft = new Point((p1.X < p2.X) ? p1.X : p2.X, (p1.Y < p2.Y) ? p1.Y : p2.Y);
            return pHigthLeft;
        }

        protected Point getBottomRightCorner(Point p1, Point p2)
        {
            Point pBotomRight = new Point((p1.X > p2.X) ? p1.X : p2.X, (p1.Y > p2.Y) ? p1.Y : p2.Y);
            return pBotomRight;
        }
    }

    [DataContract]
    public class Trianle : Shape, iPlagin
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

    [DataContract]
    public class Ellipce : Shape, iPlagin
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
            canvas.DrawEllipse(new Pen(color, Width), leftCorner.X, leftCorner.Y, Math.Abs(rigthCorner.X - leftCorner.X), Math.Abs(rigthCorner.Y - leftCorner.Y));
        }

        public override void tempDraw(object sender, PaintEventArgs e)
        {
            leftCorner = getHighLeftCorner(First, Last);
            rigthCorner = getBottomRightCorner(First, Last);
            e.Graphics.DrawEllipse(new Pen(color, Width), leftCorner.X, leftCorner.Y, Math.Abs(rigthCorner.X - leftCorner.X), Math.Abs(rigthCorner.Y - leftCorner.Y));
        }
    }

    [DataContract]
    public class Line : Shape, iPlagin
    {
        public Line() { }
        public Line(Point start, Point finish)
        {
            First = start;
            Last = finish;
        }

        public override void draw(Graphics canvas)
        {
            canvas.DrawLine(new Pen(color, Width), First, Last);
        }

        public override void tempDraw(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(color, Width), First, Last);
        }
    }

    [DataContract]
    public class Square : Shape, iPlagin
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

    [DataContract]
    public class Rectangle : Square, iPlagin
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

    [DataContract]
    public class Circle : Shape, iPlagin
    {
        public override void draw(Graphics canvas)
        {

        }
    }

    public class Swastika: Shape, iPlagin
    {

    }
}
