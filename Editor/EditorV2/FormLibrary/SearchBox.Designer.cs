namespace FormLibrary
{
    partial class SearchBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchBox));
            this.textBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.searchButton)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Location = new System.Drawing.Point(0, 3);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(230, 13);
            this.textBox.TabIndex = 0;
            this.textBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClickHendler);
            this.textBox.TextChanged += new System.EventHandler(this.TextChangedHandler);
            this.textBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownHendler);
            this.textBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpHendler);
            // 
            // searchButton
            // 
            this.searchButton.Image = ((System.Drawing.Image)(resources.GetObject("searchButton.Image")));
            this.searchButton.Location = new System.Drawing.Point(230, 0);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(15, 15);
            this.searchButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.searchButton.TabIndex = 1;
            this.searchButton.TabStop = false;
            this.searchButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClickHendler);
            this.searchButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownHendler);
            this.searchButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpHendler);
            // 
            // SearchBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.textBox);
            this.Name = "SearchBox";
            this.Size = new System.Drawing.Size(250, 20);
            this.SizeChanged += new System.EventHandler(this.SizeChangedHandler);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClickHendler);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownHendler);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpHendler);
            ((System.ComponentModel.ISupportInitialize)(this.searchButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.PictureBox searchButton;
    }
}
