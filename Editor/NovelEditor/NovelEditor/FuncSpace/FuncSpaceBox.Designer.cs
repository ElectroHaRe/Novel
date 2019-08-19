namespace NovelEditor
{
    partial class FuncSpaceBox
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
            this.functionalZones = new System.Windows.Forms.SplitContainer();
            this.searchBox = new NovelFormLibrary.SearchBox();
            this.map = new NovelFormLibrary.Map();
            this.tieNodesState = new NovelEditor.TieNodesState();
            this.editorTieStateBox = new NovelEditor.EditorTieStateBox();
            this.defaultTieStateBox = new NovelEditor.DefaultStateBox();
            ((System.ComponentModel.ISupportInitialize)(this.functionalZones)).BeginInit();
            this.functionalZones.Panel1.SuspendLayout();
            this.functionalZones.Panel2.SuspendLayout();
            this.functionalZones.SuspendLayout();
            this.SuspendLayout();
            // 
            // functionalZones
            // 
            this.functionalZones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.functionalZones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.functionalZones.Location = new System.Drawing.Point(0, 0);
            this.functionalZones.Name = "functionalZones";
            this.functionalZones.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // functionalZones.Panel1
            // 
            this.functionalZones.Panel1.AutoScroll = true;
            this.functionalZones.Panel1.Controls.Add(this.tieNodesState);
            this.functionalZones.Panel1.Controls.Add(this.editorTieStateBox);
            this.functionalZones.Panel1.Controls.Add(this.defaultTieStateBox);
            // 
            // functionalZones.Panel2
            // 
            this.functionalZones.Panel2.Controls.Add(this.searchBox);
            this.functionalZones.Panel2.Controls.Add(this.map);
            this.functionalZones.Size = new System.Drawing.Size(190, 450);
            this.functionalZones.SplitterDistance = 260;
            this.functionalZones.TabIndex = 0;
            // 
            // searchBox
            // 
            this.searchBox.BackColor = System.Drawing.Color.White;
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.searchBox.Location = new System.Drawing.Point(17, 5);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(150, 20);
            this.searchBox.TabIndex = 0;
            // 
            // map
            // 
            this.map.BackColor = System.Drawing.Color.White;
            this.map.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.map.Location = new System.Drawing.Point(17, 30);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(150, 150);
            this.map.TabIndex = 0;
            this.map.WindowPosition = new System.Drawing.Point(0, 0);
            this.map.WindowSize = new System.Drawing.Size(0, 0);
            this.map.WorldSize = new System.Drawing.Size(1, 1);
            // 
            // tieNodesState
            // 
            this.tieNodesState.Active = false;
            this.tieNodesState.Location = new System.Drawing.Point(17, 3);
            this.tieNodesState.Name = "tieNodesState";
            this.tieNodesState.Size = new System.Drawing.Size(150, 220);
            this.tieNodesState.TabIndex = 2;
            this.tieNodesState.TieText = "";
            // 
            // editorTieStateBox
            // 
            this.editorTieStateBox.Active = false;
            this.editorTieStateBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editorTieStateBox.Location = new System.Drawing.Point(17, 5);
            this.editorTieStateBox.Name = "editorTieStateBox";
            this.editorTieStateBox.Size = new System.Drawing.Size(150, 250);
            this.editorTieStateBox.TabIndex = 1;
            // 
            // defaultTieStateBox
            // 
            this.defaultTieStateBox.Active = true;
            this.defaultTieStateBox.Location = new System.Drawing.Point(17, 3);
            this.defaultTieStateBox.Name = "defaultTieStateBox";
            this.defaultTieStateBox.Size = new System.Drawing.Size(150, 168);
            this.defaultTieStateBox.TabIndex = 0;
            // 
            // FuncSpaceBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.functionalZones);
            this.Name = "FuncSpaceBox";
            this.Size = new System.Drawing.Size(190, 450);
            this.SizeChanged += new System.EventHandler(this.FuncSpaceBox_SizeChanged);
            this.functionalZones.Panel1.ResumeLayout(false);
            this.functionalZones.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.functionalZones)).EndInit();
            this.functionalZones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer functionalZones;
        private NovelFormLibrary.SearchBox searchBox;
        private NovelFormLibrary.Map map;
        private DefaultStateBox defaultTieStateBox;
        private EditorTieStateBox editorTieStateBox;
        private TieNodesState tieNodesState;
    }
}
