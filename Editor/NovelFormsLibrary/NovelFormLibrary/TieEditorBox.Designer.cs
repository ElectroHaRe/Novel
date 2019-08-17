namespace NovelFormLibrary
{
    partial class TieEditorBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TieEditorBox));
            this.TieTextBox = new System.Windows.Forms.TextBox();
            this.RemoveButton = new System.Windows.Forms.Label();
            this.ArrowButton = new System.Windows.Forms.PictureBox();
            this.CenterButton = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ArrowButton)).BeginInit();
            this.SuspendLayout();
            // 
            // TieTextBox
            // 
            this.TieTextBox.Location = new System.Drawing.Point(38, 2);
            this.TieTextBox.Multiline = true;
            this.TieTextBox.Name = "TieTextBox";
            this.TieTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TieTextBox.Size = new System.Drawing.Size(174, 40);
            this.TieTextBox.TabIndex = 0;
            this.TieTextBox.TextChanged += new System.EventHandler(this.TieTextBox_TextChanged);
            // 
            // RemoveButton
            // 
            this.RemoveButton.AutoSize = true;
            this.RemoveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveButton.Location = new System.Drawing.Point(4, 0);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(28, 39);
            this.RemoveButton.TabIndex = 2;
            this.RemoveButton.Text = "-";
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // ArrowButton
            // 
            this.ArrowButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ArrowButton.BackgroundImage")));
            this.ArrowButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ArrowButton.Location = new System.Drawing.Point(221, 11);
            this.ArrowButton.Name = "ArrowButton";
            this.ArrowButton.Size = new System.Drawing.Size(25, 23);
            this.ArrowButton.TabIndex = 3;
            this.ArrowButton.TabStop = false;
            // 
            // CenterButton
            // 
            this.CenterButton.AutoSize = true;
            this.CenterButton.BackColor = System.Drawing.Color.Transparent;
            this.CenterButton.ForeColor = System.Drawing.Color.Transparent;
            this.CenterButton.Location = new System.Drawing.Point(204, 17);
            this.CenterButton.Name = "CenterButton";
            this.CenterButton.Size = new System.Drawing.Size(0, 13);
            this.CenterButton.TabIndex = 4;
            // 
            // TieEditorBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.CenterButton);
            this.Controls.Add(this.ArrowButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.TieTextBox);
            this.Name = "TieEditorBox";
            this.Size = new System.Drawing.Size(250, 45);
            ((System.ComponentModel.ISupportInitialize)(this.ArrowButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TieTextBox;
        private System.Windows.Forms.Label RemoveButton;
        private System.Windows.Forms.PictureBox ArrowButton;
        private System.Windows.Forms.Label CenterButton;
    }
}
