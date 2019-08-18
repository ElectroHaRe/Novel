namespace NovelEditor
{
    partial class NovelEditorForm
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
            this.funcSpaceBox = new NovelEditor.FuncSpaceBox();
            this.SuspendLayout();
            // 
            // funcSpaceBox
            // 
            this.funcSpaceBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.funcSpaceBox.Location = new System.Drawing.Point(611, 0);
            this.funcSpaceBox.Name = "funcSpaceBox";
            this.funcSpaceBox.Size = new System.Drawing.Size(190, 451);
            this.funcSpaceBox.TabIndex = 0;
            // 
            // NovelEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.funcSpaceBox);
            this.Name = "NovelEditorForm";
            this.Text = "Novel Editor";
            this.SizeChanged += new System.EventHandler(this.NovelEditorForm_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private FuncSpaceBox funcSpaceBox;
    }
}

