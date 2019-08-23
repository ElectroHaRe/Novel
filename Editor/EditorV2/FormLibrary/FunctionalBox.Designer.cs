namespace FormLibrary
{
    partial class FunctionalBox
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
            this.zoneBox = new System.Windows.Forms.SplitContainer();
            this.plusButton = new System.Windows.Forms.Label();
            this.noSelectLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tieButton = new System.Windows.Forms.Button();
            this.newTieText = new System.Windows.Forms.TextBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.toElement = new FormLibrary.Element();
            this.fromElement = new FormLibrary.Element();
            this.map = new FormLibrary.Map();
            this.searchBox = new FormLibrary.SearchBox();
            ((System.ComponentModel.ISupportInitialize)(this.zoneBox)).BeginInit();
            this.zoneBox.Panel1.SuspendLayout();
            this.zoneBox.Panel2.SuspendLayout();
            this.zoneBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // zoneBox
            // 
            this.zoneBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zoneBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zoneBox.Location = new System.Drawing.Point(0, 0);
            this.zoneBox.Name = "zoneBox";
            this.zoneBox.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // zoneBox.Panel1
            // 
            this.zoneBox.Panel1.AutoScroll = true;
            this.zoneBox.Panel1.Controls.Add(this.plusButton);
            this.zoneBox.Panel1.Controls.Add(this.noSelectLabel);
            this.zoneBox.Panel1.Controls.Add(this.cancelButton);
            this.zoneBox.Panel1.Controls.Add(this.tieButton);
            this.zoneBox.Panel1.Controls.Add(this.toElement);
            this.zoneBox.Panel1.Controls.Add(this.newTieText);
            this.zoneBox.Panel1.Controls.Add(this.fromElement);
            this.zoneBox.Panel1.Controls.Add(this.exitButton);
            this.zoneBox.Panel1.Controls.Add(this.loadButton);
            this.zoneBox.Panel1.Controls.Add(this.saveButton);
            // 
            // zoneBox.Panel2
            // 
            this.zoneBox.Panel2.Controls.Add(this.map);
            this.zoneBox.Panel2.Controls.Add(this.searchBox);
            this.zoneBox.Size = new System.Drawing.Size(180, 450);
            this.zoneBox.SplitterDistance = 250;
            this.zoneBox.TabIndex = 0;
            // 
            // plusButton
            // 
            this.plusButton.AutoSize = true;
            this.plusButton.BackColor = System.Drawing.Color.Transparent;
            this.plusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plusButton.Location = new System.Drawing.Point(69, 87);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(37, 39);
            this.plusButton.TabIndex = 9;
            this.plusButton.Text = "+";
            this.plusButton.Click += new System.EventHandler(this.plusButton_Click);
            // 
            // noSelectLabel
            // 
            this.noSelectLabel.AutoEllipsis = true;
            this.noSelectLabel.Location = new System.Drawing.Point(28, 173);
            this.noSelectLabel.Name = "noSelectLabel";
            this.noSelectLabel.Size = new System.Drawing.Size(122, 14);
            this.noSelectLabel.TabIndex = 8;
            this.noSelectLabel.Text = "Select Destination Node";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(115, 217);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(50, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tieButton
            // 
            this.tieButton.Location = new System.Drawing.Point(15, 217);
            this.tieButton.Name = "tieButton";
            this.tieButton.Size = new System.Drawing.Size(50, 23);
            this.tieButton.TabIndex = 6;
            this.tieButton.Text = "Tie";
            this.tieButton.UseVisualStyleBackColor = true;
            this.tieButton.Click += new System.EventHandler(this.tieButton_Click);
            // 
            // newTieText
            // 
            this.newTieText.Location = new System.Drawing.Point(15, 80);
            this.newTieText.Multiline = true;
            this.newTieText.Name = "newTieText";
            this.newTieText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.newTieText.Size = new System.Drawing.Size(150, 60);
            this.newTieText.TabIndex = 4;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(15, 61);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(150, 23);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(15, 33);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(150, 23);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(16, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(150, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // toElement
            // 
            this.toElement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toElement.Image = null;
            this.toElement.Location = new System.Drawing.Point(15, 150);
            this.toElement.Name = "toElement";
            this.toElement.ReadOnly = true;
            this.toElement.Size = new System.Drawing.Size(150, 60);
            this.toElement.TabIndex = 5;
            // 
            // fromElement
            // 
            this.fromElement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fromElement.Image = null;
            this.fromElement.Location = new System.Drawing.Point(15, 10);
            this.fromElement.Name = "fromElement";
            this.fromElement.ReadOnly = true;
            this.fromElement.Size = new System.Drawing.Size(150, 60);
            this.fromElement.TabIndex = 3;
            // 
            // map
            // 
            this.map.BackColor = System.Drawing.SystemColors.Window;
            this.map.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.map.Location = new System.Drawing.Point(15, 30);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(150, 160);
            this.map.TabIndex = 2;
            // 
            // searchBox
            // 
            this.searchBox.BackColor = System.Drawing.SystemColors.Window;
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.searchBox.Location = new System.Drawing.Point(16, 5);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(150, 20);
            this.searchBox.TabIndex = 1;
            // 
            // FunctionalBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.zoneBox);
            this.DoubleBuffered = true;
            this.Name = "FunctionalBox";
            this.Size = new System.Drawing.Size(180, 450);
            this.SizeChanged += new System.EventHandler(this.FunctionalBox_SizeChanged);
            this.zoneBox.Panel1.ResumeLayout(false);
            this.zoneBox.Panel1.PerformLayout();
            this.zoneBox.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.zoneBox)).EndInit();
            this.zoneBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer zoneBox;
        private SearchBox searchBox;
        private Map map;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button loadButton;
        private Element fromElement;
        private System.Windows.Forms.TextBox newTieText;
        private Element toElement;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button tieButton;
        private System.Windows.Forms.Label noSelectLabel;
        private System.Windows.Forms.Label plusButton;
    }
}
