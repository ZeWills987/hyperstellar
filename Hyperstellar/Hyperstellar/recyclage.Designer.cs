namespace Hyperstellar
{
    partial class recyclage
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
            this.choix1 = new System.Windows.Forms.Button();
            this.choix2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // choix1
            // 
            this.choix1.Location = new System.Drawing.Point(200, 173);
            this.choix1.Name = "choix1";
            this.choix1.Size = new System.Drawing.Size(75, 23);
            this.choix1.TabIndex = 0;
            this.choix1.Text = "choix1";
            this.choix1.UseVisualStyleBackColor = true;
            this.choix1.Click += new System.EventHandler(this.choice1);
            // 
            // choix2
            // 
            this.choix2.Location = new System.Drawing.Point(541, 173);
            this.choix2.Name = "choix2";
            this.choix2.Size = new System.Drawing.Size(75, 23);
            this.choix2.TabIndex = 1;
            this.choix2.Text = "choix2";
            this.choix2.UseVisualStyleBackColor = true;
            this.choix2.Click += new System.EventHandler(this.choice2);
            // 
            // recyclage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.choix2);
            this.Controls.Add(this.choix1);
            this.Name = "recyclage";
            this.Text = "recyclage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button choix1;
        private System.Windows.Forms.Button choix2;
    }
}