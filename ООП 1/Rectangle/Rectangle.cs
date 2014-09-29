using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Rectangle
{
    public class Rectangle: Shape.Shape
    {
        Point begin, end;
        public Rectangle(Point[] points)
        {
            begin = points[0];
            end = points[1];
        }
        public override void Draw(Graphics e)
        {
            e.DrawRectangle(Pens.Orange,begin.X, begin.Y,end.X,end.Y);
        }
    }
}
