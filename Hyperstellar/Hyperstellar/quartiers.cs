using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hyperstellar
{
    public partial class quartiers : Form
    {
        Player playerActu;

        public quartiers(Player player)
        {
            InitializeComponent();

            playerActu = player;
            InstructionLabel.Text = playerActu.getName() + " vous avez " + playerActu.getnbPawns()+ " pions dans le quartier d'équipage";
            InstructionLabel.Font = Board.FONT;
            InstructionLabel.ForeColor = Color.White;
            InstructionLabel.Left = (this.ClientSize.Width - InstructionLabel.Width) / 2;
            TitleLabel.Font = Board.TITLEFONT; // Remplacer par TITLEFONT de Board.cs
            TitleLabel.ForeColor = Color.White;
            TitleLabel.Left = (this.ClientSize.Width - TitleLabel.Width) / 2;
            Annuler.Font = Board.FONT;
            Annuler.ForeColor = Color.White;
            Valider.Font = Board.FONT;
            Valider.ForeColor = Color.White;
            EnergyCostLabel.Font = Board.TITLEFONT;
            EnergyCostLabel.ForeColor = Color.White;
            PawnGainLabel.Font = Board.TITLEFONT;
            PawnGainLabel.ForeColor = Color.White;
            this.Opacity = 0.99;


        }

        private void NewPawn(object sender, EventArgs e)
        {
            playerActu.removeEnergy(5);
            playerActu.addNewPawn();
            this.Close();
        }

    }
}
