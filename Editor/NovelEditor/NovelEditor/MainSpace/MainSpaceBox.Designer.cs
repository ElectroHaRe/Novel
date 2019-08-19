namespace NovelEditor.MainSpace
{
    partial class MainSpaceBox
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
            this.backgroundContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeImageContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPictureDialog = new System.Windows.Forms.OpenFileDialog();
            this.backgroundContextMenu.SuspendLayout();
            this.nodeImageContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundContextMenu
            // 
            this.backgroundContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNodeToolStripMenuItem});
            this.backgroundContextMenu.Name = "backgroundContextMenu";
            this.backgroundContextMenu.Size = new System.Drawing.Size(141, 26);
            this.backgroundContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.backgroundContextMenu_ItemClicked);
            // 
            // createNodeToolStripMenuItem
            // 
            this.createNodeToolStripMenuItem.Name = "createNodeToolStripMenuItem";
            this.createNodeToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.createNodeToolStripMenuItem.Text = "Create Node";
            // 
            // nodeImageContextMenu
            // 
            this.nodeImageContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeImageToolStripMenuItem});
            this.nodeImageContextMenu.Name = "nodeImageContextMenu";
            this.nodeImageContextMenu.Size = new System.Drawing.Size(152, 26);
            this.nodeImageContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.nodeImageContextMenu_ItemClicked);
            // 
            // changeImageToolStripMenuItem
            // 
            this.changeImageToolStripMenuItem.Name = "changeImageToolStripMenuItem";
            this.changeImageToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.changeImageToolStripMenuItem.Text = "Change Image";
            // 
            // openPictureDialog
            // 
            this.openPictureDialog.FileName = "Node Image";
            // 
            // MainSpaceBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Name = "MainSpaceBox";
            this.Size = new System.Drawing.Size(356, 292);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainSpaceBox_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainSpaceBox_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainSpaceBox_MouseUp);
            this.backgroundContextMenu.ResumeLayout(false);
            this.nodeImageContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip backgroundContextMenu;
        private System.Windows.Forms.ToolStripMenuItem createNodeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip nodeImageContextMenu;
        private System.Windows.Forms.ToolStripMenuItem changeImageToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openPictureDialog;
    }
}
