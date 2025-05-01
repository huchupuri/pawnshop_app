using pawnshop_app.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

            this.Load += DetailForm_Load;
        }

        private void DetailForm_Load(object sender, EventArgs e)
        {
            PopulateFields();
        }
        private void PopulateFields()
        {
            flowLayoutPanel.Controls.Clear();

            switch (_itemType.ToLower())
            {
                case "pawnshop":
                    AddPawnshopFields((Pawnshop)_selectedItem);
                    break;
                case "item":
                    AddItemFields((Item)_selectedItem);
                    break;
                case "lender":
                    AddLenderFields((Lender)_selectedItem);
                    break;
            }
        }

        private void AddPawnshopFields(Pawnshop pawnshop)
        {
            AddField("ID", pawnshop.Id.ToString());
            AddField("Название", pawnshop.Name);
            AddField("Адрес", pawnshop.Location);
            AddField("Рейтинг", pawnshop.Rating.ToString());
            AddField("Год основания", pawnshop.EstablishedYear.ToString());

            // Добавляем информацию о товарах в этом ломбарде
            if (pawnshop.Items != null && pawnshop.Items.Count > 0)
            {
                AddSeparator("Товары в ломбарде");

                DataGridView itemsGrid = new DataGridView
                {
                    Width = flowLayoutPanel.Width - 20,
                    Height = 150,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    ReadOnly = true,
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    RowHeadersVisible = false,
                    BackgroundColor = Color.White,
                    BorderStyle = BorderStyle.None,
                    CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                    GridColor = Color.FromArgb(230, 230, 230),
                    Margin = new Padding(10, 5, 10, 10)
                };

                itemsGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
                itemsGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                itemsGrid.ColumnHeadersHeight = 40;
                itemsGrid.EnableHeadersVisualStyles = false;

                itemsGrid.Columns.Add("Id", "ID");
                itemsGrid.Columns.Add("Type", "Тип");
                itemsGrid.Columns.Add("Description", "Описание");
                itemsGrid.Columns.Add("Value", "Стоимость");
                itemsGrid.Columns.Add("Condition", "Состояние");

                foreach (var item in pawnshop.Items)
                {
                    itemsGrid.Rows.Add(
                        item.Id,
                        item.Type,
                        item.Description,
                        item.EstimatedValue,
                        item.Condition
                    );
                }

                flowLayoutPanel.Controls.Add(itemsGrid);
            }
        }

        private void AddItemFields(Item item)
        {
            AddField("ID", item.Id.ToString());
            AddField("Тип", item.Type);
            AddField("Описание", item.Description);
            AddField("Оценочная стоимость", item.EstimatedValue.ToString());
            AddField("Состояние", item.Condition);
        }

        private void AddLenderFields(Lender lender)
        {
            AddField("ID", lender.Id.ToString());
            AddField("Имя", lender.Name);
            AddField("Контактная информация", lender.ContactInfo);
            AddField("Сумма займа", lender.LoanAmount.ToString());
            AddField("Статус займа", lender.LoanStatus);
        }

        private void AddField(string labelText, string value)
        {
            // Создаем панель для поля
            Panel fieldPanel = new Panel
            {
                Width = flowLayoutPanel.Width - 20,
                Height = 60,
                Margin = new Padding(10, 5, 10, 5)
            };

            // Добавляем метку
            Label label = new Label
            {
                Text = labelText,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Location = new Point(0, 0),
                AutoSize = true
            };

            // Добавляем значение
            Label valueLabel = new Label
            {
                Text = value,
                Width = fieldPanel.Width - 10,
                Location = new Point(0, 25),
                Font = new Font("Segoe UI", 10F),
                AutoEllipsis = true
            };

            fieldPanel.Controls.Add(label);
            fieldPanel.Controls.Add(valueLabel);
            flowLayoutPanel.Controls.Add(fieldPanel);
        }

        private void AddSeparator(string title)
        {
            Label separator = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Width = flowLayoutPanel.Width - 20,
                Height = 30,
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(10, 15, 10, 5),
                BorderStyle = BorderStyle.None
            };

            flowLayoutPanel.Controls.Add(separator);
        }
    }
}