using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Polygon
{
    public class Polygon: Shape.Shape
    {
        public Polygon(Point[] poly)
        {
            Points = poly;
        }

        public override void Draw(Graphics e)
        {
            
            e.DrawPolygon(new Pen(Color), Points);
        }
        
    }
}
