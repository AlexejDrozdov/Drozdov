using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hospital;
using Movie;

namespace OOP3
{
    public partial class Form1 : Form
    {
        private Builds.Build Building;
        public List<Builds.Build> BuildingsList;
        bool TreeExist = false;
        public Form1()
        {
            InitializeComponent();
            BuildingsList = new List<Builds.Build>();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            /*foreach (var build in BuildingsList)
            {
                treeView1.Nodes.Add(build.ToString());
            }*/
            if (TreeExist)
            {
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add(TreeBuilder.GetTree(BuildingsList));
            }
            else
            {
                treeView1.Nodes.Add(TreeBuilder.GetTree(BuildingsList));
                TreeExist = true;
            }
 

        }

        private void HospitalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hospital = new Hospital.Infirmary();
            hospital.CountOFCustomer = 2000;
            hospital.CountOfOperatingRoom = 100;
            hospital.Telephone = 103;
            hospital.SetAddres("Gikalo", 0);
        }

        private void MuseumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var museum = new MuseumBuild.Museum();
            museum.CountOFCustomer = 1000;
            museum.CountOfExhibit = 250;
            museum.CountOfHall = 10;
            museum.SetAddres("Gikalo", 0);
            BuildingsList.Add(museum);
        }

        private void CinemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cinema = new Movie.Cinema();
            cinema.CountOFCustomer = 5000;
            cinema.CountOfHall = 10;
            cinema.CountOfSeance = 10;
            cinema.SetAddres("Gikalo", 0);
            BuildingsList.Add(cinema);
        }

        private void StoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var store = new Shop.Store();
            store.CountOFCustomer = 750;
            store.TypeOfProduct = "Shoes";
            store.SetAddres("Gikalo", 2);
            BuildingsList.Add(store);

        }

        private void MilitiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var militia = new Militia.BuildOfMilitia();
            militia.CountOFCustomer = 100;
            militia.Telephone = 102;
            militia.VolumeMonkeyHouse = 100;
            militia.SetAddres("Gikalo", 1);
            BuildingsList.Add(militia);

        }

        private void FactoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var factory = new Factories.Factory();
            factory.Aray = 10000;
            factory.Pollution = 50;
            factory.SetAddres("Gikalo", 5);
            BuildingsList.Add(factory);
        }

        private void MultistroyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var house = new HighRise.Multistory();
            house.CountInhabitant = 1000;
            house.CountOfFlat = 100;
            house.CountOfFlower = 16;
            house.CountOfPorch = 2;
            house.SetAddres("Gikalo", 45);
            BuildingsList.Add(house);
        }

        private void PrivateHouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var privateHome = new PrivateHouse.Home();
            privateHome.CountInhabitant = 6;
            privateHome.SetAddres("Gikalo", 45);
            privateHome.SetArea(100);
            BuildingsList.Add(privateHome);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }
    }
}




