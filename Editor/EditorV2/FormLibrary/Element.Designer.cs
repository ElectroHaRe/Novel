namespace FormLibrary
{
    partial class Element
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.NullImageLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(-1, 80);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(251, 80);
            this.textBox.TabIndex = 0;
            this.textBox.Click += new System.EventHandler(this.ElementClickHendler);
            this.textBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ElementMouseClickHendler);
            this.textBox.TextChanged += new System.EventHandler(this.TextChangedHendler);
            // 
            // NullImageLabel
            // 
            this.NullImageLabel.AutoEllipsis = true;
            this.NullImageLabel.Location = new System.Drawing.Point(75, 34);
            this.NullImageLabel.Name = "NullImageLabel";
            this.NullImageLabel.Size = new System.Drawing.Size(100, 14);
            this.NullImageLabel.TabIndex = 2;
            this.NullImageLabel.Text = "Image not selected";
            this.NullImageLabel.Click += new System.EventHandler(this.ElementClickHendler);
            this.NullImageLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ElementMouseClickHendler);
            this.NullImageLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ElementMouseDownHendler);
            this.NullImageLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ElementMouseUpHendler);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(250, 80);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.ElementClickHendler);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ElementMouseClickHendler);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ElementMouseDownHendler);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ElementMouseUpHendler);
            // 
            // Element
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.NullImageLabel);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.textBox);
            this.DoubleBuffered = true;
            this.Name = "Element";
            this.Size = new System.Drawing.Size(250, 160);
            this.SizeChanged += new System.EventHandler(this.SizeChangedHandler);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label NullImageLabel;
    }
}
