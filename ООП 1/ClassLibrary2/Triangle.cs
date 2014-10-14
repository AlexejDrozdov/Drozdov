using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Triangle
{
    public class Triangle : Shape.Shape
    {
        public Triangle(Point[] poly)
        {
            Points = new Point[]{new Point( poly[0].X, poly[1].Y),
                                 new Point( poly[1].X - (poly[1].X - poly[0].X) / 2, poly[0].Y),
                                 new Point( poly[1].X, poly[1].Y),
                                 /*new Point((poly[1].X - poly[0].X)/4, poly[1].Y),
                                 new Point(poly[0].X,(poly[1].Y - poly[0].Y)/2)*/};


        }

        public override void Draw(Graphics e)
        {

            e.DrawPolygon(new Pen(Color), Points);
        }

    }
}
