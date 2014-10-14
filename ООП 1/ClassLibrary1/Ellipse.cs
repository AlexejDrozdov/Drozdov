using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ellipse
{
    public class Ellipse : Shape.Shape
    {
        Point point;
        Size ellsize;
        public Ellipse(Point[] points)
        {
            point = new Point(points[0].X + (points[1].X - points[0].X) / 2, 
                points[0].Y + (points[1].Y - points[0].Y) / 2);
            ellsize.Width = points[1].X - points[0].X;
            ellsize.Height = points[1].Y - points[0].Y;
        }
        public override void Draw(Graphics e)
        {
            e.DrawEllipse(new Pen(Color), point.X, point.Y, ellsize.Width, ellsize.Height);
        }
    }
}
