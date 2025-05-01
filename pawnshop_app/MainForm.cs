using pawnshop_app.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace pawnshop_app
{
    public partial class MainForm : Form
    {
        TreeNode PawnshopNode = new TreeNode("Ломбарды");
        TreeNode ItemNode = new TreeNode("Товар");
        TreeNode LendersNode = new TreeNode("Заемщики");
        private string xmlFilePath = "C:\\Users\\squae\\source\\repos\\pawnshop_app\\pawnshop_app\\information\\examplesXML.xml";
        public MainForm()
        {
            InitializeComponent();
            LoadTreeViewData();

        }
        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Проверяем, является ли выбранный узел родительским
            if (e.Node.Parent == null) // Только корневые узлы
            {
                string selectedNodeText = e.Node.Text.ToLower();

                switch (selectedNodeText)
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
                // Если узел не родительский, показываем форму с деталями
                ShowDetailForm(e.Node);
            }
        }

        private void ShowDetailForm(TreeNode node)
        {
            // Определяем тип объекта и находим соответствующий объект
            string nodeText = node.Text;
            object selectedObject = null;
            string objectType = "";

            if (node.Parent == PawnshopNode)
            {
                // Это ломбард
                selectedObject = pawnshops.FirstOrDefault(p => p.Name == nodeText);
                objectType = "pawnshop";
            }
            else if (node.Parent == ItemNode)
            {
                // Это товар - извлекаем тип и описание из текста узла
                string[] parts = nodeText.Split(new string[] { ": " }, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    string type = parts[0];
                    string description = parts[1];
                    selectedObject = items.FirstOrDefault(i => i.Type == type && i.Description == description);
                    objectType = "item";
                }
            }
            else if (node.Parent == LendersNode)
            {
                // Это заемщик - извлекаем имя из текста узла
                string name = nodeText.Split(new string[] { " (" }, StringSplitOptions.None)[0];
                selectedObject = lenders.FirstOrDefault(l => l.Name == name);
                objectType = "lender";
            }

            // Если объект найден, показываем форму с деталями
            if (selectedObject != null)
            {
                using (DetailForm detailForm = new DetailForm(selectedObject, objectType))
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
        private void LoadTreeViewData()
        {
            treeView.Nodes.Add(ItemNode);
            treeView.Nodes.Add(PawnshopNode);
            treeView.Nodes.Add(LendersNode);

            // Разворачиваем все узлы
            treeView.ExpandAll();
        }
        List<Pawnshop> pawnshops = new List<Pawnshop>();
        List<Lender> lenders = new List<Lender>();
        List<Item> items = new List<Item>();
        private void AddNodesToTreeView(Root data)
        {
            // Очищаем существующие узлы и списки
            PawnshopNode.Nodes.Clear();
            ItemNode.Nodes.Clear();
            LendersNode.Nodes.Clear();
            pawnshops.Clear();
            lenders.Clear();
            items.Clear();
            MessageBox.Show($"{data.Items.Count}");
            // Ломбарды
            foreach (var pawnshop in data.Pawnshops)
            {
                pawnshops.Add(pawnshop);
                var NewNode = new TreeNode($"{pawnshop.Name}");
                PawnshopNode.Nodes.Add(NewNode);
                if (pawnshop.Items != null)
                {
                    foreach (var lend in pawnshop.Items)
                    {
                        NewNode.Nodes.Add(new TreeNode($"{lend.Description}"));
                    }
                }
            }

            // Товары
            foreach (var item in data.Items)
            {
                items.Add(item);
                ItemNode.Nodes.Add(new TreeNode($"{item.Type}: {item.Description}"));
            }

            // Заемщики
            foreach (var lender in data.Lenders)
            {
                lenders.Add(lender);
                LendersNode.Nodes.Add(new TreeNode($"{lender.Name} ({lender.ContactInfo})"));
            }

            // Разворачиваем все узлы
            treeView.ExpandAll();
            treeView.Refresh(); // Обновляем TreeView
        }
        private void AddNodesToTreeView(RootJson data)
        {
            // Очищаем существующие узлы и списки
            PawnshopNode.Nodes.Clear();
            ItemNode.Nodes.Clear();
            LendersNode.Nodes.Clear();
            pawnshops.Clear();
            lenders.Clear();
            items.Clear();
            MessageBox.Show($"{data.Items.Count}");
            // Ломбарды
            foreach (var pawnshop in data.Pawnshops)
            {
                pawnshops.Add(pawnshop);
                var NewNode = new TreeNode($"{pawnshop.Name}");
                PawnshopNode.Nodes.Add(NewNode);
                if (pawnshop.Items != null)
                {
                    foreach (var lend in pawnshop.Items)
                    {
                        NewNode.Nodes.Add(new TreeNode($"{lend.Description}"));
                    }
                }
            }

            // Товары
            foreach (var item in data.Items)
            {
                items.Add(item);
                ItemNode.Nodes.Add(new TreeNode($"{item.Type}: {item.Description}"));
            }

            // Заемщики
            foreach (var lender in data.Lenders)
            {
                lenders.Add(lender);
                LendersNode.Nodes.Add(new TreeNode($"{lender.Name} ({lender.ContactInfo})"));
            }

            // Разворачиваем все узлы
            treeView.ExpandAll();
            treeView.Refresh(); // Обновляем TreeView
        }

        private RootJson LoadDataFromJson()
        {
            string jsonFilePath = "C:\\Users\\squae\\source\\repos\\pawnshop_app\\pawnshop_app\\information\\examplesJSON.json";


            string json = File.ReadAllText(jsonFilePath);


            try
            {
                return JsonSerializer.Deserialize<RootJson>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка десериализации JSON: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private Root LoadDataFromXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Root));

            using (StreamReader reader = new StreamReader(xmlFilePath))
            {
                return (Root)serializer.Deserialize(reader);
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            var data = LoadDataFromJson();
            if (data != null)
            {
                AddNodesToTreeView(data);
            }
        }


        [XmlRoot("root")]
        public class Root
        {
            [XmlArray("pawnshops")]
            [XmlArrayItem("pawnshop")]
            public List<Pawnshop> Pawnshops { get; set; }
            [XmlArray("items")]
            [XmlArrayItem("item")]
            public List<Item> Items { get; set; }
            [XmlArray("lenders")]
            [XmlArrayItem("lender")]
            public List<Lender> Lenders { get; set; }
        }
        public class RootJson
        {
            [JsonPropertyName("pawnshops")]
            public List<Pawnshop> Pawnshops { get; set; }

            [JsonPropertyName("items")]
            public List<Item> Items { get; set; }

            [JsonPropertyName("lenders")]
            public List<Lender> Lenders { get; set; } 
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
                    MessageBox.Show("Неизвестный тип данных");
                    return;
            }

            dataGridView.DataSource = dataTable;
        }
    }
}