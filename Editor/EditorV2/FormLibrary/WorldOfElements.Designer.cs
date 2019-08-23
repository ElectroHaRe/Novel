namespace FormLibrary
{
    partial class WorldOfElements
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.backgroundMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elementMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeElementMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.backgroundMenu.SuspendLayout();
            this.elementMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundMenu
            // 
            this.backgroundMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createMenuItem});
            this.backgroundMenu.Name = "backgroundMenu";
            this.backgroundMenu.Size = new System.Drawing.Size(109, 26);
            // 
            // createMenuItem
            // 
            this.createMenuItem.Name = "createMenuItem";
            this.createMenuItem.Size = new System.Drawing.Size(108, 22);
            this.createMenuItem.Text = "Create";
            this.createMenuItem.Click += new System.EventHandler(this.createMenuItem_Click);
            // 
            // elementMenu
            // 
            this.elementMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeImageMenuItem,
            this.removeElementMenuItem});
            this.elementMenu.Name = "elementMenu";
            this.elementMenu.Size = new System.Drawing.Size(164, 48);
            // 
            // changeImageMenuItem
            // 
            this.changeImageMenuItem.Name = "changeImageMenuItem";
            this.changeImageMenuItem.Size = new System.Drawing.Size(163, 22);
            this.changeImageMenuItem.Text = "Change Image";
            this.changeImageMenuItem.Click += new System.EventHandler(this.changeImageMenuItem_Click);
            // 
            // removeElementMenuItem
            // 
            this.removeElementMenuItem.Name = "removeElementMenuItem";
            this.removeElementMenuItem.Size = new System.Drawing.Size(163, 22);
            this.removeElementMenuItem.Text = "Remove Element";
            this.removeElementMenuItem.Click += new System.EventHandler(this.removeElementMenuItem_Click);
            // 
            // openImageDialog
            // 
            this.openImageDialog.FileName = "New Image";
            // 
            // WorldOfElements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Name = "WorldOfElements";
            this.Size = new System.Drawing.Size(600, 450);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.WorldOfElements_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Background_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.World_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.World_MouseUp);
            this.backgroundMenu.ResumeLayout(false);
            this.elementMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip backgroundMenu;
        private System.Windows.Forms.ToolStripMenuItem createMenuItem;
        private System.Windows.Forms.ContextMenuStrip elementMenu;
        private System.Windows.Forms.ToolStripMenuItem changeImageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeElementMenuItem;
        private System.Windows.Forms.OpenFileDialog openImageDialog;
    }
}
