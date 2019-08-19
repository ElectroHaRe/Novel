namespace NovelEditor
{
    partial class EditorTieStateBox
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
            this.addTieBox = new NovelFormLibrary.AddTieBox();
            this.SuspendLayout();
            // 
            // addTieBox
            // 
            this.addTieBox.BackColor = System.Drawing.Color.Transparent;
            this.addTieBox.Location = new System.Drawing.Point(0, 0);
            this.addTieBox.Name = "addTieBox";
            this.addTieBox.Size = new System.Drawing.Size(150, 80);
            this.addTieBox.TabIndex = 1;
            // 
            // EditorTieStateBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.addTieBox);
            this.Name = "EditorTieStateBox";
            this.Size = new System.Drawing.Size(150, 80);
            this.SizeChanged += new System.EventHandler(this.EditorTieFuncStateBox_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private NovelFormLibrary.AddTieBox addTieBox;
    }
}
