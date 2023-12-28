namespace Hyperstellar
{
    partial class quartiers
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
            this.Valider = new System.Windows.Forms.Button();
            this.Annuler = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.EnergyImage = new System.Windows.Forms.Label();
            this.PawnImage = new System.Windows.Forms.Label();
            this.InstructionLabel = new System.Windows.Forms.Label();
            this.EnergyCostLabel = new System.Windows.Forms.Label();
            this.PawnGainLabel = new System.Windows.Forms.Label();
            this.ArrowImage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Valider
            // 
            this.Valider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(93)))), ((int)(((byte)(160)))));
            this.Valider.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Valider.FlatAppearance.BorderSize = 7;
            this.Valider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Valider.Location = new System.Drawing.Point(853, 526);
            this.Valider.Name = "Valider";
            this.Valider.Size = new System.Drawing.Size(218, 77);
            this.Valider.TabIndex = 0;
            this.Valider.Text = "OK";
            this.Valider.UseVisualStyleBackColor = false;
            this.Valider.Click += new System.EventHandler(this.NewPawn);
            // 
            // Annuler
            // 
            this.Annuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(93)))), ((int)(((byte)(160)))));
            this.Annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Annuler.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Annuler.FlatAppearance.BorderSize = 7;
            this.Annuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Annuler.Location = new System.Drawing.Point(226, 526);
            this.Annuler.Margin = new System.Windows.Forms.Padding(0);
            this.Annuler.Name = "Annuler";
            this.Annuler.Size = new System.Drawing.Size(218, 77);
            this.Annuler.TabIndex = 1;
            this.Annuler.Text = "Annuler";
            this.Annuler.UseVisualStyleBackColor = false;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(448, 33);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(364, 42);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "Quartiers d\'équipage";
            // 
            // EnergyImage
            // 
            this.EnergyImage.BackColor = System.Drawing.Color.Transparent;
            this.EnergyImage.Image = global::Hyperstellar.Properties.Resources.BoltLogo;
            this.EnergyImage.Location = new System.Drawing.Point(223, 210);
            this.EnergyImage.Name = "EnergyImage";
            this.EnergyImage.Size = new System.Drawing.Size(221, 290);
            this.EnergyImage.TabIndex = 3;
            // 
            // PawnImage
            // 
            this.PawnImage.BackColor = System.Drawing.Color.Transparent;
            this.PawnImage.Image = global::Hyperstellar.Properties.Resources.PawnLogo;
            this.PawnImage.Location = new System.Drawing.Point(853, 236);
            this.PawnImage.Name = "PawnImage";
            this.PawnImage.Size = new System.Drawing.Size(218, 264);
            this.PawnImage.TabIndex = 4;
            // 
            // InstructionLabel
            // 
            this.InstructionLabel.AutoSize = true;
            this.InstructionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionLabel.Location = new System.Drawing.Point(593, 135);
            this.InstructionLabel.Name = "InstructionLabel";
            this.InstructionLabel.Size = new System.Drawing.Size(29, 42);
            this.InstructionLabel.TabIndex = 5;
            this.InstructionLabel.Text = "";
            // 
            // EnergyCostLabel
            // 
            this.EnergyCostLabel.AutoSize = true;
            this.EnergyCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnergyCostLabel.Location = new System.Drawing.Point(153, 337);
            this.EnergyCostLabel.Name = "EnergyCostLabel";
            this.EnergyCostLabel.Size = new System.Drawing.Size(51, 42);
            this.EnergyCostLabel.TabIndex = 6;
            this.EnergyCostLabel.Text = "-5";
            // 
            // PawnGainLabel
            // 
            this.PawnGainLabel.AutoSize = true;
            this.PawnGainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PawnGainLabel.Location = new System.Drawing.Point(811, 337);
            this.PawnGainLabel.Name = "PawnGainLabel";
            this.PawnGainLabel.Size = new System.Drawing.Size(61, 42);
            this.PawnGainLabel.TabIndex = 7;
            this.PawnGainLabel.Text = "+1";
            // 
            // ArrowImage
            // 
            this.ArrowImage.BackColor = System.Drawing.Color.Transparent;
            this.ArrowImage.Image = global::Hyperstellar.Properties.Resources.WhiteArrowLogo;
            this.ArrowImage.Location = new System.Drawing.Point(483, 297);
            this.ArrowImage.Name = "ArrowImage";
            this.ArrowImage.Size = new System.Drawing.Size(285, 127);
            this.ArrowImage.TabIndex = 8;
            // 
            // quartiers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(81)))), ((int)(((byte)(122)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1189, 700);
            this.Controls.Add(this.ArrowImage);
            this.Controls.Add(this.PawnGainLabel);
            this.Controls.Add(this.EnergyCostLabel);
            this.Controls.Add(this.InstructionLabel);
            this.Controls.Add(this.PawnImage);
            this.Controls.Add(this.EnergyImage);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.Annuler);
            this.Controls.Add(this.Valider);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "quartiers";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "(";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Valider;
        private System.Windows.Forms.Button Annuler;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label EnergyImage;
        private System.Windows.Forms.Label PawnImage;
        private System.Windows.Forms.Label InstructionLabel;
        private System.Windows.Forms.Label EnergyCostLabel;
        private System.Windows.Forms.Label PawnGainLabel;
        private System.Windows.Forms.Label ArrowImage;
    }
}