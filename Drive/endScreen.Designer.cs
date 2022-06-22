namespace Drive
{
    partial class endScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(endScreen));
            this.endLable = new System.Windows.Forms.Label();
            this.endTextLable = new System.Windows.Forms.Label();
            this.menuButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // endLable
            // 
            this.endLable.AutoSize = true;
            this.endLable.BackColor = System.Drawing.Color.Transparent;
            this.endLable.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endLable.ForeColor = System.Drawing.Color.LimeGreen;
            this.endLable.Location = new System.Drawing.Point(210, 15);
            this.endLable.Name = "endLable";
            this.endLable.Size = new System.Drawing.Size(403, 80);
            this.endLable.TabIndex = 0;
            this.endLable.Text = "Game Over";
            // 
            // endTextLable
            // 
            this.endTextLable.AutoSize = true;
            this.endTextLable.BackColor = System.Drawing.Color.Transparent;
            this.endTextLable.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endTextLable.ForeColor = System.Drawing.Color.LimeGreen;
            this.endTextLable.Location = new System.Drawing.Point(319, 184);
            this.endTextLable.Name = "endTextLable";
            this.endTextLable.Size = new System.Drawing.Size(170, 47);
            this.endTextLable.TabIndex = 1;
            this.endTextLable.Text = "label1";
            // 
            // menuButton
            // 
            this.menuButton.BackColor = System.Drawing.Color.Transparent;
            this.menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButton.ForeColor = System.Drawing.Color.Black;
            this.menuButton.Location = new System.Drawing.Point(327, 411);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(177, 73);
            this.menuButton.TabIndex = 2;
            this.menuButton.Text = "Menu";
            this.menuButton.UseVisualStyleBackColor = false;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // endScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.endTextLable);
            this.Controls.Add(this.endLable);
            this.Name = "endScreen";
            this.Size = new System.Drawing.Size(801, 550);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label endLable;
        private System.Windows.Forms.Label endTextLable;
        private System.Windows.Forms.Button menuButton;
    }
}
