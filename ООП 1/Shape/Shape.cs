using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Shape
{
    public abstract class Shape
    {
        private Color color;
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        private Point[] points;
        public Point[] Points
        {
            get { return points; }
            set { points = value; }
        }
        public abstract void Draw(Graphics e);
    }
}
