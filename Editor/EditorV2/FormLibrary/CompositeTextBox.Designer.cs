namespace FormLibrary
{
    partial class CompositeTextBox
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
            this.minusButton = new System.Windows.Forms.Label();
            this.arrowButton = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(35, 0);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(180, 60);
            this.textBox.TabIndex = 0;
            this.textBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClickHandler);
            this.textBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownHendler);
            this.textBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpHendler);
            // 
            // minusButton
            // 
            this.minusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minusButton.Location = new System.Drawing.Point(0, 6);
            this.minusButton.Margin = new System.Windows.Forms.Padding(0);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(30, 38);
            this.minusButton.TabIndex = 1;
            this.minusButton.Text = "-";
            this.minusButton.Click += new System.EventHandler(this.MinusClickHendler);
            this.minusButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClickHandler);
            this.minusButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownHendler);
            this.minusButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpHendler);
            // 
            // arrowButton
            // 
            this.arrowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.arrowButton.Location = new System.Drawing.Point(220, 10);
            this.arrowButton.Margin = new System.Windows.Forms.Padding(0);
            this.arrowButton.Name = "arrowButton";
            this.arrowButton.Size = new System.Drawing.Size(30, 40);
            this.arrowButton.TabIndex = 2;
            this.arrowButton.Text = ">";
            this.arrowButton.Click += new System.EventHandler(this.ArrowClickHandler);
            this.arrowButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClickHandler);
            this.arrowButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownHendler);
            this.arrowButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpHendler);
            // 
            // CompositeTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.arrowButton);
            this.Controls.Add(this.minusButton);
            this.Controls.Add(this.textBox);
            this.Name = "CompositeTextBox";
            this.Size = new System.Drawing.Size(250, 60);
            this.SizeChanged += new System.EventHandler(this.CompositeTextBox_SizeChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClickHandler);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownHendler);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpHendler);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label minusButton;
        private System.Windows.Forms.Label arrowButton;
    }
}
