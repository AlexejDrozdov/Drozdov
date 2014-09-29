using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OOP_1
{
    public partial class OOP : Form
    {
        Graphics graph;
        Shape.Shape shape;
        Point[] points;
        
        private List<Shape.Shape> List;

        int i;
        Random rand = new Random();
        public OOP()
        {
            
            InitializeComponent();
            graph = pictureBox1.CreateGraphics();
            List = new List<Shape.Shape>();
        }

        private void Line_Click(object sender, EventArgs e)
        {
            points = new Point[2];
            for (i = 0; i <2; i++)
            {
                points[i].X = rand.Next(0 , 500); 
                points[i].Y = rand.Next(0 , 500); 
            }
            shape = new Line.Line(points);
            shape.Draw(graph);
            List.Add(shape);
        }

        private void EllipseStrip_Click(object sender, EventArgs e)
        {
            int a, b;
            Point point = new Point();
            point.X = rand.Next(50, 200);
            point.Y= rand.Next(50, 200);
            a = rand.Next(10, 200);
            b = rand.Next(10, 200);
            shape = new Ellipse.Ellipse(point, a, b);
            shape.Draw(graph);
            List.Add(shape);
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            points = new Point[2];
            for (i = 0; i < 2; i++)
            {
                points[i].X = rand.Next(0, 200);
                points[i].Y = rand.Next(0, 300);
            }
            shape = new Rectangle.Rectangle(points);
            shape.Draw(graph);
            List.Add(shape);
        }

        private void ClearPicture_Click(object sender, EventArgs e)
        {
            graph.Clear(Color.White);
        }

        private void PolygonStrip_Click(object sender, EventArgs e)
        {
            points = new Point[5];
            for (i = 0 ; i < 5; i++)
            {
                points[i].X = rand.Next(0, 400);
                points[i].Y = rand.Next(0, 500);
            }
            shape = new Polygon.Polygon(points);
            shape.Color = Color.Blue;
            shape.Draw(graph);
            List.Add(shape);
        }
        
    }
}
