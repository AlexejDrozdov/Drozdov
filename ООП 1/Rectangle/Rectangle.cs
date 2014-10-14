using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Rectangle
{
    public class Rectangle : Shape.Shape
    {
        public Rectangle(Point[] points)
        {
            Points = points;
        }
        public override void Draw(Graphics e)
        {
            e.DrawRectangle(new Pen(Color), Points[0].X, Points[0].Y, Points[1].X, Points[1].Y);
        }
    }
}
