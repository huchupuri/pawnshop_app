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

        private TreeView treeView;
        private DataGridView dataGridView;
        private Button Load;
        private Button button2;
        private SplitContainer splitContainer;
        private Panel buttonPanel;
        private Label tableTitle;

        private void InitializeComponent()
        {
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
            splitContainer.TabIndex = 0;
            // 
            // treeView
            // 
            treeView.Dock = DockStyle.Fill;
            treeView.Font = new Font("Segoe UI", 10F);
            treeView.ItemHeight = 25;
            treeView.Location = new Point(0, 0);
            treeView.Name = "treeView";
            treeView.ShowLines = false;
            treeView.Size = new Size(215, 653);
            treeView.TabIndex = 0;
            treeView.AfterSelect += TreeView_AfterSelect;
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(Load);
            buttonPanel.Controls.Add(button2);
            buttonPanel.Dock = DockStyle.Top;
            buttonPanel.Location = new Point(0, 40);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(763, 60);
            buttonPanel.TabIndex = 1;
            // 
            // Load
            // 
            Load.FlatStyle = FlatStyle.Flat;
            Load.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Load.Location = new Point(24, 15);
            Load.Name = "Load";
            Load.Size = new Size(120, 30);
            Load.TabIndex = 0;
            Load.Text = "Добавить из XML";
            Load.UseVisualStyleBackColor = true;
            Load.Click += Load_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkRed;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(160, 15);
            button2.Name = "button2";
            button2.Size = new Size(157, 30);
            button2.TabIndex = 1;
            button2.Text = "Добавить из JSON";
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
            tableTitle.Size = new Size(763, 40);
            tableTitle.TabIndex = 0;
            tableTitle.Text = "Данные";
            tableTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BackgroundColor = SystemColors.Window;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.ColumnHeadersHeight = 30;
            dataGridView.GridColor = SystemColors.ControlDark;
            dataGridView.Location = new Point(0, 106);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(763, 547);
            dataGridView.TabIndex = 2;
            // 
            // MainForm
            // 
            ClientSize = new Size(982, 653);
            Controls.Add(splitContainer);
            Font = new Font("Segoe UI", 9F);
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
    }
}