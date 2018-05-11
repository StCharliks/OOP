using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstFigures;

namespace OstaPaint.Controls
{
    abstract class ShapeFactory
    {
        public abstract Shape Create();
    }

    class CircleFactory : ShapeFactory
    {
        public override Shape Create()
        {
            return new Circle();
        }
    }
    //================================================================================
    class RectangleFactory : ShapeFactory
    {
        public override Shape Create()
        {
            return new Rectangle();
        }
    }
    //================================================================================
    class EllipseFactory : ShapeFactory
    {
        public override Shape Create()
        {
            return new Ellipce();
        }
    }
    //================================================================================
    class TriangleFactory : ShapeFactory
    {
        public override Shape Create()
        {
            return new Trianle();
        }
    }
    //================================================================================
    class SquareFactory: ShapeFactory
    {
        public override Shape Create()
        {
            return new Square();
        }
    }
    //================================================================================
    class LineFactory : ShapeFactory
    {
        public override Shape Create()
        {
            return new Line();
        }
    }
    //================================================================================
}
