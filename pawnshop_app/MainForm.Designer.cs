using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace pawnshop_app
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private TreeView treeView;
        private DataGridView dataGridView;
        private Button Load;
        private Button button2;
        private SplitContainer splitContainer;
        private Panel buttonPanel;
        private ImageList imageList;

        // Цветовая схема
        private Color primaryColor = Color.FromArgb(52, 73, 94);     // Темно-синий
        private Color accentColor = Color.FromArgb(26, 188, 156);    // Бирюзовый
        private Color lightColor = Color.FromArgb(236, 240, 241);    // Светло-серый
        private Color darkColor = Color.FromArgb(44, 62, 80);        // Очень темно-синий
        private Color textColor = Color.FromArgb(236, 240, 241);     // Светлый текст
        private void ButtonPanel_Paint(object sender, PaintEventArgs e)
        {
            // Создаем градиентный фон для панели кнопок
            using (LinearGradientBrush brush = new LinearGradientBrush(
                buttonPanel.ClientRectangle,
                Color.FromArgb(240, 242, 245),
                Color.FromArgb(225, 228, 232),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, buttonPanel.ClientRectangle);
            }

            // Добавляем линию-разделитель внизу панели
            using (Pen pen = new Pen(Color.FromArgb(189, 195, 199)))
            {
                e.Graphics.DrawLine(pen, 0, buttonPanel.Height - 1, buttonPanel.Width, buttonPanel.Height - 1);
            }
        }
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            imageList = new ImageList(components);
            splitContainer = new SplitContainer();
            treeView = new TreeView();
            buttonPanel = new Panel();
            Load = new Button();
            button2 = new Button();
            tableTitle = new Label();
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageSize = new Size(16, 16);
            imageList.TransparentColor = Color.Transparent;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(treeView);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(buttonPanel);
            splitContainer.Panel2.Controls.Add(tableTitle);
            splitContainer.Panel2.Controls.Add(dataGridView);
            splitContainer.Size = new Size(982, 653);
            splitContainer.SplitterDistance = 215;
            splitContainer.SplitterIncrement = 10;
            splitContainer.SplitterWidth = 5;
            splitContainer.TabIndex = 0;
            // 
            // treeView
            // 
            treeView.BorderStyle = BorderStyle.None;
            treeView.Dock = DockStyle.Fill;
            treeView.Font = new Font("Segoe UI", 10F);
            treeView.Indent = 20;
            treeView.ItemHeight = 25;
            treeView.Location = new Point(0, 0);
            treeView.Name = "treeView";
            treeView.ShowLines = false;
            treeView.Size = new Size(215, 653);
            treeView.TabIndex = 1;
            treeView.AfterSelect += TreeView_AfterSelect;
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(Load);
            buttonPanel.Controls.Add(button2);
            buttonPanel.Dock = DockStyle.Top;
            buttonPanel.Location = new Point(0, 40);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(762, 60);
            buttonPanel.TabIndex = 0;
            buttonPanel.Paint += ButtonPanel_Paint;
            // 
            // Load
            // 
            Load.Cursor = Cursors.Hand;
            Load.FlatAppearance.BorderSize = 0;
            Load.FlatStyle = FlatStyle.Flat;
            Load.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Load.ForeColor = Color.White;
            Load.Location = new Point(24, 15);
            Load.Name = "Load";
            Load.Size = new Size(120, 30);
            Load.TabIndex = 0;
            Load.Text = "Добавить";
            Load.Click += Load_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(231, 76, 60);
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(160, 15);
            button2.Name = "button2";
            button2.Size = new Size(120, 30);
            button2.TabIndex = 1;
            button2.Text = "Удалить";
            button2.UseVisualStyleBackColor = false;
            button2.Click += Button2_Click;
            // 
            // tableTitle
            // 
            tableTitle.Dock = DockStyle.Top;
            tableTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            tableTitle.Location = new Point(0, 0);
            tableTitle.Name = "tableTitle";
            tableTitle.Padding = new Padding(10, 0, 0, 0);
            tableTitle.Size = new Size(762, 40);
            tableTitle.TabIndex = 1;
            tableTitle.Text = "Данные";
            tableTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(245, 246, 250);
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = Color.FromArgb(189, 195, 199);
            dataGridView.Location = new Point(0, 106);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 30;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(761, 547);
            dataGridView.TabIndex = 2;
            // 
            // MainForm
            // 
            ClientSize = new Size(982, 653);
            Controls.Add(splitContainer);
            Font = new Font("Segoe UI", 9F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Управление данными";
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label tableTitle;
    }
}