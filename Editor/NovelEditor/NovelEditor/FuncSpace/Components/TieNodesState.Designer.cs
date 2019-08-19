namespace NovelEditor
{
    partial class TieNodesState
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
            this.fromNode = new NovelFormLibrary.Node();
            this.tieText = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tieButton = new System.Windows.Forms.Button();
            this.destinationNode = new NovelFormLibrary.Node();
            this.chooseNodeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fromNode
            // 
            this.fromNode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fromNode.Image = null;
            this.fromNode.index = 0;
            this.fromNode.Location = new System.Drawing.Point(0, 0);
            this.fromNode.Name = "fromNode";
            this.fromNode.Size = new System.Drawing.Size(150, 60);
            this.fromNode.TabIndex = 0;
            // 
            // tieText
            // 
            this.tieText.Location = new System.Drawing.Point(0, 66);
            this.tieText.Multiline = true;
            this.tieText.Name = "tieText";
            this.tieText.Size = new System.Drawing.Size(150, 30);
            this.tieText.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(0, 197);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(150, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // tieButton
            // 
            this.tieButton.Location = new System.Drawing.Point(0, 168);
            this.tieButton.Name = "tieButton";
            this.tieButton.Size = new System.Drawing.Size(150, 23);
            this.tieButton.TabIndex = 3;
            this.tieButton.Text = "Tie Nodes";
            this.tieButton.UseVisualStyleBackColor = true;
            // 
            // destinationNode
            // 
            this.destinationNode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.destinationNode.Image = null;
            this.destinationNode.index = 0;
            this.destinationNode.Location = new System.Drawing.Point(0, 102);
            this.destinationNode.Name = "destinationNode";
            this.destinationNode.Size = new System.Drawing.Size(150, 60);
            this.destinationNode.TabIndex = 4;
            // 
            // chooseNodeLabel
            // 
            this.chooseNodeLabel.AutoSize = true;
            this.chooseNodeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chooseNodeLabel.Location = new System.Drawing.Point(39, 126);
            this.chooseNodeLabel.Name = "chooseNodeLabel";
            this.chooseNodeLabel.Size = new System.Drawing.Size(74, 15);
            this.chooseNodeLabel.TabIndex = 5;
            this.chooseNodeLabel.Text = "Choose Node";
            // 
            // TieNodesState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chooseNodeLabel);
            this.Controls.Add(this.destinationNode);
            this.Controls.Add(this.tieButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.tieText);
            this.Controls.Add(this.fromNode);
            this.Name = "TieNodesState";
            this.Size = new System.Drawing.Size(150, 220);
            this.SizeChanged += new System.EventHandler(this.TieNodesState_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NovelFormLibrary.Node fromNode;
        private System.Windows.Forms.TextBox tieText;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button tieButton;
        private NovelFormLibrary.Node destinationNode;
        private System.Windows.Forms.Label chooseNodeLabel;
    }
}
