using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Line
{
    public class Line: Shape.Shape
    {
        Point begin,end;
        public Line(Point[] points)
        {
            begin = points[0];
            end = points[1];
        }
        public override void Draw(Graphics e)
        {
            e.DrawLine(Pens.Green, begin.X, begin.Y, end.X, end.Y);
        }
    }
}