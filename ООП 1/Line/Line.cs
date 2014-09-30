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
        public Line(Point[] points)
        {
            Points = points;
        }
        public override void Draw(Graphics e)
        {
            e.DrawLine(new Pen(Color), Points[0].X, Points[0].Y, Points[1].X, Points[1].Y);
        }
    }
}