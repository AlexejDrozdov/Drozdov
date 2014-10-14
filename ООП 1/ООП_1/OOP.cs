using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;


namespace OOP_1
{
    public partial class OOP : Form
    {
        Graphics graph;
        Shape.Shape shape;
        Point[] points;

        private List<Shape.Shape> List;

        private List<Type> shapeTypes;

        int i;
        Random rand = new Random();
        public OOP()
        {
            InitializeComponent();

            AddMenu();
            graph = pictureBox1.CreateGraphics();
            List = new List<Shape.Shape>();
        }

        private void AddMenu()
        {
            var directory = new DirectoryInfo("Shapes");
            shapeTypes = directory.GetFiles("*.dll").
                Select(x => Assembly.LoadFile(x.FullName).GetTypes().
                    FirstOrDefault(y => y.IsSubclassOf(typeof(Shape.Shape))))
                    .Where(x => x != null).ToList();
            foreach (var type in shapeTypes)
            {
                var menuItem = new ToolStripButton
                {
                    Name = type.Name,
                    Text = type.Name,
                    Tag = type,
                };

                menuItem.Click += ShapeItemClick;
                фигурыToolStripMenuItem.DropDownItems.Add(menuItem);
            }
        }


        private void ShapeItemClick(object sender, EventArgs e)
        {
            points = new Point[2];

            if (textBox1.Text == "")
            {
                points[0].X = rand.Next(10, pictureBox1.Width);
                points[0].Y = rand.Next(10, pictureBox1.Height);
                points[1].X = rand.Next(points[0].X, pictureBox1.Width);
                points[1].Y = rand.Next(points[0].Y, pictureBox1.Height);
            }
            else
            {
                points[0].X = Convert.ToInt32(textBox1.Text);
                points[0].Y = Convert.ToInt32(textBox2.Text);

                points[1].X = Convert.ToInt32(textBox3.Text);
                points[1].Y = Convert.ToInt32(textBox4.Text);
            }
            
            
            shape = (Shape.Shape)Activator.CreateInstance((Type)((ToolStripButton)sender).Tag, points);
            shape.Color = Color.Black;
            shape.Draw(graph);
            List.Add(shape);
        }

        
        private void ClearPicture_Click(object sender, EventArgs e)
        {
            graph.Clear(Color.White);
            List.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
