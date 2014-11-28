using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;
using Builds;
using Factories;
using HighRise;
using Hospital;
using Militia;
using Movie;
using MuseumBuild;
using PrivateHouse;
using Shop;

namespace OOP3
{
    public partial class Form1 : Form
    {
        const string FileName = @"..\..\Buildings.bin";
        private Build building;
        public List<Build> BuildingsList;
        bool treeExist;
        private TreeNode curretnNode;
        public Form1()
        {
            InitializeComponent();
            BuildingsList = new List<Build>();
        }

        private void ShowTree()
        {

            if (treeExist)
            {
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add(TreeBuilder.GetTree(BuildingsList));
            }
            else
            {
                treeView1.Nodes.Add(TreeBuilder.GetTree(BuildingsList));
                treeExist = true;
            }
        }


        private void HospitalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hospital = new Infirmary
            {
                CountOFCustomer = 2000,
                CountOfOperatingRoom = 100,
                Telephone = 103,
                address = { Street = "Gikalo", NumberOfHouse = 1 }
            };
            BuildingsList.Add(hospital);
            ShowTree();
        }

        private void MuseumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var museum = new Museum
            {
                CountOFCustomer = 1000,
                CountOfExhibit = 250,
                CountOfHall = 10,
                address = { NumberOfHouse = 2, Street = "Gikalo" }
            };
            BuildingsList.Add(museum);
            ShowTree();
        }

        private void CinemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cinema = new Cinema
            {
                CountOFCustomer = 5000,
                CountOfHall = 10,
                CountOfSeance = 10,
                address = { NumberOfHouse = 3, Street = "Gikalo" }
            };
            BuildingsList.Add(cinema);
            ShowTree();
        }

        private void StoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var store = new Store
            {
                CountOFCustomer = 750,
                TypeOfProduct = "Shoes",
                address = { NumberOfHouse = 4, Street = "Gikalo" }
            };
            BuildingsList.Add(store);
            ShowTree();
        }

        private void MilitiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var militia = new BuildOfMilitia
            {
                CountOFCustomer = 100,
                Telephone = 102,
                VolumeMonkeyHouse = 100,
                address = { NumberOfHouse = 5, Street = "Gikalo" }
            };
            BuildingsList.Add(militia);
            ShowTree();
        }

        private void FactoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var factory = new Factory { Aray = 10000, Pollution = 50, address = { NumberOfHouse = 6, Street = "Gikalo" } };
            BuildingsList.Add(factory);
            ShowTree();
        }

        private void MultistroyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var house = new Multistory
            {
                CountInhabitant = 1000,
                CountOfFlat = 100,
                CountOfFlower = 16,
                CountOfPorch = 2,
                address = { NumberOfHouse = 7, Street = "Gikalo" }
            };
            BuildingsList.Add(house);
            ShowTree();
        }

        private void PrivateHouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var privateHome = new Home
            {
                CountInhabitant = 6,
                Area = 300,
                address = { NumberOfHouse = 9, Street = "Gikalo" }
            };
            BuildingsList.Add(privateHome);
            ShowTree();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNodeTag nodeTag = e.Node.Tag as TreeNodeTag;
            if (nodeTag.NodeType.IsSubclassOf(typeof(Builds.Build)))
            {
                BuildingsList.Remove((Build)nodeTag.Value);
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add(TreeBuilder.GetTree(BuildingsList));
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNodeTag nodeTag = e.Node.Tag as TreeNodeTag;
            if (nodeTag != null)
            {
                curretnNode = e.Node;
            }
        }

        private void buttonChangeInfo_Click(object sender, EventArgs e)
        {
            if ((curretnNode != null) && (textBoxInfo.Text != ""))
            {
                TreeNodeTag nodeTag = (TreeNodeTag)curretnNode.Tag;
                TreeNodeTag parentTag = (TreeNodeTag)curretnNode.Parent.Tag;
                curretnNode.Name = nodeTag.PropertiesInfo.Name + " = ";
                if (nodeTag.Value is int)
                {
                    curretnNode.Name += textBoxInfo.Text;
                    nodeTag.PropertiesInfo.SetValue(parentTag.Value, int.Parse(textBoxInfo.Text));
                    nodeTag.Value = textBoxInfo.Text;
                }
                else if (nodeTag.Value is String)
                {
                    curretnNode.Name += textBoxInfo.Text;
                    nodeTag.PropertiesInfo.SetValue(parentTag.Value, textBoxInfo.Text);
                    nodeTag.Value = textBoxInfo.Text;
                }
            }
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(TreeBuilder.GetTree(BuildingsList));
        }

        private void buttonBinary_Click(object sender, EventArgs e)
        {

            saveFileDialog1.Filter = "Binary files (*.bin)|*.bin";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string filename = saveFileDialog1.FileName;
                Stream TestFileStream = File.Create(filename);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(TestFileStream, BuildingsList);
                TestFileStream.Close();
            }
        }

        private void buttonXML_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "XML-files (*.xml)|*.xml";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string filename = saveFileDialog1.FileName;
                
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Build>));
                using (FileStream fileStream = new FileStream(filename, FileMode.Create))
                {
                    xmlSerializer.Serialize(fileStream, BuildingsList);
                }
            }
        }

        private void buttonDeserialize_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Binary files (*.bin)|*.bin";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                if (File.Exists(filename))
                {
                    Stream TestFileStream = File.OpenRead(filename);
                    BinaryFormatter deserializer = new BinaryFormatter();
                    BuildingsList = (List<Build>)deserializer.Deserialize(TestFileStream);
                    TestFileStream.Close();
                    treeView1.Nodes.Clear();
                    treeView1.Nodes.Add(TreeBuilder.GetTree(BuildingsList));
                }
            }
        }

    }
}




