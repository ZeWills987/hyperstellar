namespace Hyperstellar
{
    partial class laboratoire
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Terminer = new System.Windows.Forms.Button();
            this.Valoriser = new System.Windows.Forms.Button();
            this.Piocher = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Terminer
            // 
            this.Terminer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Terminer.Location = new System.Drawing.Point(542, 203);
            this.Terminer.Name = "Terminer";
            this.Terminer.Size = new System.Drawing.Size(102, 35);
            this.Terminer.TabIndex = 1;
            this.Terminer.Text = "Terminer";
            this.Terminer.UseVisualStyleBackColor = true;
            // 
            // Valoriser
            // 
            this.Valoriser.Location = new System.Drawing.Point(191, 203);
            this.Valoriser.Name = "Valoriser";
            this.Valoriser.Size = new System.Drawing.Size(127, 35);
            this.Valoriser.TabIndex = 2;
            this.Valoriser.Text = "Valoriser";
            this.Valoriser.UseVisualStyleBackColor = true;
            this.Valoriser.Click += new System.EventHandler(this.ValoriserCards);
            // 
            // Piocher
            // 
            this.Piocher.Location = new System.Drawing.Point(352, 305);
            this.Piocher.Name = "Piocher";
            this.Piocher.Size = new System.Drawing.Size(141, 45);
            this.Piocher.TabIndex = 3;
            this.Piocher.Text = "Piocher";
            this.Piocher.UseVisualStyleBackColor = true;
            this.Piocher.Click += new System.EventHandler(this.PiocherCards);
            // 
            // laboratoire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Piocher);
            this.Controls.Add(this.Valoriser);
            this.Controls.Add(this.Terminer);
            this.Name = "laboratoire";
            this.Text = "laboratoire";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Terminer;
        private System.Windows.Forms.Button Valoriser;
        private System.Windows.Forms.Button Piocher;
    }
}
