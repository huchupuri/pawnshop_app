using pawnshop_app.Classes;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace pawnshop_app
{
    public partial class DetailForm : Form
    {
        private object _selectedItem;
        private string _itemType;

        public DetailForm(object selectedItem, string itemType)
        {
            InitializeComponent();
            _selectedItem = selectedItem;
            _itemType = itemType;
            this.Load += PopulateDataGridView;
        }


        private void PopulateDataGridView(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            switch (_itemType.ToLower())
            {
                case "pawnshop":
                    Pawnshop pawnshop = (Pawnshop)_selectedItem;
                    dataTable.Columns.Add("Свойство", typeof(string));
                    dataTable.Columns.Add("Значение", typeof(string));

                    dataTable.Rows.Add("ID", pawnshop.Id);
                    dataTable.Rows.Add("Название", pawnshop.Name);
                    dataTable.Rows.Add("Адрес", pawnshop.Location);
                    dataTable.Rows.Add("Рейтинг", pawnshop.Rating);
                    dataTable.Rows.Add("Год основания", pawnshop.EstablishedYear);

                    if (pawnshop.Items != null && pawnshop.Items.Count > 0)
                    {
                        dataTable.Rows.Add("ТОВАРЫ В ЛОМБАРДЕ", "");

                        foreach (var Item in pawnshop.Items)
                        {
                            dataTable.Rows.Add($"Товар ID {Item.Id}", Item.Description);
                            dataTable.Rows.Add("Тип", Item.Type);
                            dataTable.Rows.Add("Стоимость", Item.EstimatedValue);
                            dataTable.Rows.Add("Состояние", Item.Condition);
                        }
                    }
                    break;

                case "item":
                    Item item = (Item)_selectedItem;

                    dataTable.Columns.Add("Свойство", typeof(string));
                    dataTable.Columns.Add("Значение", typeof(string));

                    dataTable.Rows.Add("ID", item.Id);
                    dataTable.Rows.Add("Тип", item.Type);
                    dataTable.Rows.Add("Описание", item.Description);
                    dataTable.Rows.Add("Оценочная стоимость", item.EstimatedValue);
                    dataTable.Rows.Add("Состояние", item.Condition);
                    break;

                case "lender":
                    Lender lender = (Lender)_selectedItem;

                    dataTable.Columns.Add("Свойство", typeof(string));
                    dataTable.Columns.Add("Значение", typeof(string));

                    dataTable.Rows.Add("ID", lender.Id);
                    dataTable.Rows.Add("Имя", lender.Name);
                    dataTable.Rows.Add("Контактная информация", lender.ContactInfo);
                    dataTable.Rows.Add("Сумма займа", lender.LoanAmount);
                    dataTable.Rows.Add("Статус займа", lender.LoanStatus);
                    break;
            }

            dataGridView1.DataSource = dataTable;

            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns[0].Width = 200;
            }
        }
    }
}