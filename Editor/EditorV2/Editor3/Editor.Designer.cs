namespace Editor3
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
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.funcBox = new FormLibrary.FunctionalBox();
            this.worldBox = new FormLibrary.WorldOfElements();
            this.SuspendLayout();
            // 
            // openDialog
            // 
            this.openDialog.FileName = "Novel Tree";
            // 
            // funcBox
            // 
            this.funcBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.funcBox.Location = new System.Drawing.Point(620, 0);
            this.funcBox.Name = "funcBox";
            this.funcBox.Size = new System.Drawing.Size(180, 450);
            this.funcBox.TabIndex = 0;
            // 
            // worldBox
            // 
            this.worldBox.Location = new System.Drawing.Point(0, 0);
            this.worldBox.Name = "worldBox";
            this.worldBox.ScaleFactor = 0.5F;
            this.worldBox.Size = new System.Drawing.Size(620, 450);
            this.worldBox.TabIndex = 1;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.worldBox);
            this.Controls.Add(this.funcBox);
            this.Name = "Editor";
            this.Text = "Editor";
            this.SizeChanged += new System.EventHandler(this.SizeChangedHandler);
            this.ResumeLayout(false);

        }

        #endregion

        private FormLibrary.FunctionalBox funcBox;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private FormLibrary.WorldOfElements worldBox;
    }
}

