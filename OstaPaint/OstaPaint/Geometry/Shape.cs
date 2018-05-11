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
    abstract class Shape
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

        /*private Pen _pen;
        public Pen pen
        {
            get
            {
                return _pen;
            }
            set
            {
                _pen = value;
            }
        }*/

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
}
