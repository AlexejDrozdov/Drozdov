using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;
using Builds;

namespace OOP3
{
    public partial class Form1 : Form
    {
        public List<Build> BuildingsList;
        private List<Type> typesList;
        private List<Type> allTypes;
        bool treeExist;
        private TreeNode curretnNode;
        public Form1()
        {

            InitializeComponent();
            BuildingsList = new List<Build>();
            getTypes();
        }
        private void getTypes()
        {
            
            var directory = new DirectoryInfo("ClassDll");
            allTypes = directory.GetFiles("*.dll").
                Select(x => Assembly.LoadFile(x.FullName).GetTypes().
                    Where(y => y.IsSubclassOf(typeof(Build))))
                    .Aggregate(new List<Type>(), (acc, x) => { acc.AddRange(x); return acc; });
            typesList = directory.GetFiles("*.dll").
              Select(x => Assembly.LoadFile(x.FullName).GetTypes())
                  .Aggregate(new List<Type>(), (acc, x) => { acc.AddRange(x); return acc; });
            typesList.Add(typeof(Addres));
            foreach (var type in allTypes)
            {
                var menuItem = new ToolStripButton
                {
                    Name = type.Name,
                    Text = type.Name,
                    Tag = type,
                };

                menuItem.Click += BuildingItem_Click;
                buildingsToolStripMenuItem.DropDownItems.Add(menuItem);
            }
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


        private void BuildingItem_Click(object sender, EventArgs e)
        {
            Build Item = (Build)Activator.CreateInstance((Type)((ToolStripItem)sender).Tag);
            
            Item.initialization();
            BuildingsList.Add(Item);
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
                textBoxInfo.Text = nodeTag.Value.ToString();
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
                Type[] types = allTypes.ToArray();
                var xmlSerializer = new XmlSerializer(typeof(List<Build>), types);
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

        private void xmlDeserializationButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XML-files (*.xml)|*.xml";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                Type[] types = allTypes.ToArray();
                BuildingsList.Clear();
                var xmlSerializer = new XmlSerializer(typeof(List<Build>), types);
                using (var fileStream = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    BuildingsList = (List<Build>)xmlSerializer.Deserialize(fileStream);
                }
            }
            ShowTree();
        }

        private void serializationButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Serialized file (*.txt)|*.txt";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                Type[] types = allTypes.ToArray();
                Serialization serialization = new Serialization();
                using (FileStream fileStream = new FileStream(filename, FileMode.Create))
                {
                    StreamWriter strWr = new StreamWriter((Stream)fileStream);
                    strWr.AutoFlush = true;
                    serialization.Serialize(BuildingsList, strWr);
                }
            }
        }

        private void desirializationButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Serialized files (*.txt)|*.txt";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                Type[] types = allTypes.ToArray();
                BuildingsList.Clear();
                Deserialization deserialization = new Deserialization();
                using (var fileStream = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    StreamReader reader = new StreamReader((Stream) fileStream);
                    BuildingsList = (List<Build>) deserialization.Deserialize(typesList, reader);
                }
            }
            ShowTree();
        }

    }
}




