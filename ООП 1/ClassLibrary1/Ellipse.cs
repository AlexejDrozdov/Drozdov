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
        public Ellipse(Point centre, int a, int b)
        {
            point = centre;
            ellsize.Width = a * 2;
            ellsize.Height = b * 2;
        }
        public override void Draw(Graphics e)
        {
            e.DrawEllipse(new Pen(Color), point.X, point.Y, ellsize.Width, ellsize.Height);
        }
    }
}
