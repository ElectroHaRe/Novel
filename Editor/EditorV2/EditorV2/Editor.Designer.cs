namespace EditorV2
{
    partial class Editor
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.functionalBox = new FormLibrary.FunctionalBox();
            this.worldOfElements = new FormLibrary.WorldOfElements();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // functionalBox
            // 
            this.functionalBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.functionalBox.Location = new System.Drawing.Point(620, 0);
            this.functionalBox.Name = "functionalBox";
            this.functionalBox.Size = new System.Drawing.Size(180, 450);
            this.functionalBox.TabIndex = 2;
            // 
            // worldOfElements
            // 
            this.worldOfElements.Location = new System.Drawing.Point(0, 0);
            this.worldOfElements.Name = "worldOfElements";
            this.worldOfElements.ScaleFactor = 0.5F;
            this.worldOfElements.Size = new System.Drawing.Size(620, 450);
            this.worldOfElements.TabIndex = 1;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.functionalBox);
            this.Controls.Add(this.worldOfElements);
            this.Name = "Editor";
            this.Text = "Form1";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion
        private FormLibrary.WorldOfElements worldOfElements;
        private FormLibrary.FunctionalBox functionalBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

