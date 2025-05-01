namespace pawnshop_app
{
    partial class DetailForm
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

        private void InitializeComponent()
        {
            flowLayoutPanel = new FlowLayoutPanel();
            panelButtons = new Panel();

            SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(0, 0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Padding = new Padding(10);
            flowLayoutPanel.Size = new Size(550, 400);
            flowLayoutPanel.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.FromArgb(245, 246, 250);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 400);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(550, 60);
            panelButtons.TabIndex = 2;
            // 
            // DetailForm
            // 

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(550, 460);
            Controls.Add(flowLayoutPanel);
            Controls.Add(panelButtons);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DetailForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Детали";
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnClose;
    }
}