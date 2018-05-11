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
    class Line : Shape
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
}
