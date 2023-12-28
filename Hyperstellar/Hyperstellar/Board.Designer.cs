namespace Hyperstellar
{
    partial class Board
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.DialogLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DialogLabel
            // 
            this.DialogLabel.AutoSize = true;
            this.DialogLabel.BackColor = System.Drawing.Color.Transparent;
            this.DialogLabel.Location = new System.Drawing.Point(506, 128);
            this.DialogLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DialogLabel.Name = "DialogLabel";
            this.DialogLabel.Size = new System.Drawing.Size(35, 13);
            this.DialogLabel.TabIndex = 0;
            this.DialogLabel.Text = "label1";
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Hyperstellar.Properties.Resources.sky2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.DialogLabel);
            this.DoubleBuffered = true;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.DoubleBuffered = true;
            this.Name = "Board";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Board_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Board_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label DialogLabel;
    }
}

