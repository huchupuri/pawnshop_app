using pawnshop_app.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace pawnshop_app
{
    public partial class MainForm : Form
    {
        private TreeNode PawnshopNode = new TreeNode("Ломбарды");
        private TreeNode ItemNode = new TreeNode("Товар");
        private TreeNode LendersNode = new TreeNode("Заемщики");

        // Пути к файлам
        private string xmlFilePath = "information\\examplesXML.xml";
        private string jsonFilePath = "information\\examplesJSON.json";
        private List<Pawnshop> pawnshops = new List<Pawnshop>();
        private List<Item> items = new List<Item>();
        private List<Lender> lenders = new List<Lender>();

        public MainForm()
        {
            InitializeComponent();
            LoadTreeViewData();
        }

        private void LoadTreeViewData()
        {
            treeView.Nodes.Clear();
            treeView.Nodes.Add(PawnshopNode);
            treeView.Nodes.Add(ItemNode);
            treeView.Nodes.Add(LendersNode);
            treeView.ExpandAll();
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null) 
            {
                switch (e.Node.Text.ToLower())
                {
                    case "ломбарды":
                        CreateData("ломбарды");
                        break;
                    case "товар":
                        CreateData("товар");
                        break;
                    case "заемщики":
                        CreateData("заемщики");
                        break;
                }
            }
            else
            {
                ShowDetailForm(e.Node);
            }
        }

        private void ShowDetailForm(TreeNode node)
        {
            object selectedObject = null;
            string objectType = "";

            if (node.Parent == PawnshopNode)
            {
                selectedObject = pawnshops.FirstOrDefault(p => p.Name == node.Text);
                objectType = "pawnshop";
            }
            else if (node.Parent == ItemNode)
            {
                selectedObject = items.FirstOrDefault(i => i.Type == node.Text);
                objectType = "item";
            }
            else if (node.Parent == LendersNode)
            {
                
                selectedObject = lenders.FirstOrDefault(l => l.Name == node.Text);
                objectType = "lender";
            }
            else
            {
                if (pawnshops.FirstOrDefault(p => p.Name == node.Text) != null)
                {
                    selectedObject = pawnshops.FirstOrDefault(p => p.Name == node.Text);
                    objectType = "pawnshop";
                }
                else if (items.FirstOrDefault(i => i.Type == node.Text) != null)
                {
                    selectedObject = items.FirstOrDefault(i => i.Type == node.Text);
                    objectType = "item";
                }
                else if (lenders.FirstOrDefault(l => l.Name == node.Text) != null)
                {
                    selectedObject = lenders.FirstOrDefault(l => l.Name == node.Text);
                    objectType = "lender";
                }

            }

            if (selectedObject != null)
            {
                using (var detailForm = new DetailForm(selectedObject, objectType))
                {
                    detailForm.ShowDialog();
                }
            }
        }
        private void Load_Click(object sender, EventArgs e)
        {
            var data = LoadDataFromXml();
            AddNodesToTreeView(data);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var data = LoadDataFromJson();
            AddNodesToTreeView(data);
        }

        private Root LoadDataFromXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Root));

            using (StreamReader reader = new StreamReader(xmlFilePath))
            {
                return (Root)serializer.Deserialize(reader);
            }
        }
        private Root LoadDataFromJson()
        {
            string json = File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<Root>(json);
        }

        private void AddNodesToTreeView(Root root)
        {

            foreach (var pawnshop in root.Pawnshops)
            {
                pawnshops.Add(pawnshop);
                var node = new TreeNode(pawnshop.Name);
                PawnshopNode.Nodes.Add(node);

                foreach (var item in pawnshop.Items)
                {
                    items.Add(item);
                    node.Nodes.Add(new TreeNode(item.Description));
                }
                foreach (Lender lender in pawnshop.Lenders)
                {
                    lenders.Add(lender);
                    node.Nodes.Add(new TreeNode(lender.Name));
                }
            }

            foreach (var item in root.Items)
            {
                items.Add(item);
                var node = new TreeNode(item.Type);
                ItemNode.Nodes.Add(node);
                foreach (var pawnshop in item.Pawnshops)
                {
                    pawnshops.Add(pawnshop);
                    node.Nodes.Add(new TreeNode(pawnshop.Name));
                }
                foreach (Lender lender in item.Lenders)
                {
                    lenders.Add(lender);
                    node.Nodes.Add(new TreeNode(lender.Name));
                }
            }

            foreach (var lender in root.Lenders)
            {
                lenders.Add(lender);
                var node = new TreeNode($"{lender.Name}");
                LendersNode.Nodes.Add(node);
                foreach (var pawnshop in lender.Pawnshops)
                {
                    pawnshops.Add(pawnshop);
                    node.Nodes.Add(new TreeNode(pawnshop.Name));
                }
                foreach (var item in lender.Items)
                {
                    items.Add(item);
                    node.Nodes.Add(new TreeNode(item.Type));
                }
            }

            treeView.ExpandAll();
        }


        private void CreateData(string dataType)
        {
            DataTable dataTable = new DataTable();

            switch (dataType.ToLower())
            {
                case "ломбарды":
                    dataTable.Columns.Add("ID", typeof(int));
                    dataTable.Columns.Add("Название", typeof(string));
                    dataTable.Columns.Add("Адрес", typeof(string));
                    dataTable.Columns.Add("Рейтинг", typeof(double));
                    dataTable.Columns.Add("Год основания", typeof(int));

                    foreach (var p in pawnshops)
                    {
                        dataTable.Rows.Add(p.Id, p.Name, p.Location, p.Rating, p.EstablishedYear);
                    }
                    break;

                case "товар":
                    dataTable.Columns.Add("ID", typeof(int));
                    dataTable.Columns.Add("Тип", typeof(string));
                    dataTable.Columns.Add("Описание", typeof(string));
                    dataTable.Columns.Add("Стоимость", typeof(decimal));
                    dataTable.Columns.Add("Состояние", typeof(string));

                    foreach (var i in items)
                    {
                        dataTable.Rows.Add(i.Id, i.Type, i.Description, i.EstimatedValue, i.Condition);
                    }
                    break;

                case "заемщики":
                    dataTable.Columns.Add("ID", typeof(int));
                    dataTable.Columns.Add("Имя", typeof(string));
                    dataTable.Columns.Add("Контакты", typeof(string));
                    dataTable.Columns.Add("Сумма займа", typeof(decimal));
                    dataTable.Columns.Add("Статус", typeof(string));

                    foreach (var l in lenders)
                    {
                        dataTable.Rows.Add(l.Id, l.Name, l.ContactInfo, l.LoanAmount, l.LoanStatus);
                    }
                    break;

                default:
                    MessageBox.Show("Неизвестный тип данных.");
                    return;
            }

            dataGridView.DataSource = dataTable;
        }
    }
}