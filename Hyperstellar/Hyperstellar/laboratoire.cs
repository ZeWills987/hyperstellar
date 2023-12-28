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

    public partial class laboratoire : Form
    {
        Player playerActu;
        int[] nbCards = new int [7];
        int[] nbCardsPerColor = new int [7];
        Color[] listColor = {Color.Yellow, Color.Blue, Color.Red, Color.Green, Color.Purple, Color.Black, Color.White};
        int nbDifferent = 0;
        int nb5 = 0;
        int nb1 = 0;
        int nbCardsChoice = 0;

        public laboratoire(Player player)
        {
            InitializeComponent();
            playerActu = player;
            Valoriser.Enabled = false;
            for (int i = 0; i < nbCards.Length; i++)
            {
                nbCards[i] = 0;
            }

            if (playerActu.getEnergy() < 2)
            {
                Piocher.Enabled = false;
                MessageBox.Show("Pas assez d'energy pour piocher ou pour valoriser !!");
            }

            for (int j = 0; j < nbCardsPerColor.Length; j++)
            {
                nbCardsPerColor[j] = playerActu.getNbCardsByColor(listColor[j]);
            }
        }

        public void isValorisable()//utiliser des que changement
        {
            for (int i = 0; i < nbCards.Length; i++)
            {
                if (nbCards[i] >= 1)
                {
                    nbCardsChoice++;

                }
                if (nbCards[i] == 1)
                {
                    nbDifferent++;
                    if (playerActu.getColor() == listColor[i])
                    {
                        nb1++;
                    }
                }
                if (nbCards[i] == 5)
                {
                    nb5++;
                }
            }
            if (nbDifferent == 4 ^ nbDifferent == 6 ^ nbDifferent == 7 ^  nb5 == 5 ^ nb1 == 1)
            {
                Valoriser.Enabled = true;
            }
            else
            {
                Valoriser.Enabled = false;
            }
        }

        private void ValoriserCards(object sender, EventArgs e)
        {
            Piocher.Enabled = false;
            if (nbDifferent == 7)
            {
                playerActu.removeEnergy(14);
                playerActu.setScore(50);
            }else if (nbDifferent == 6)
            {
                playerActu.removeEnergy(12);
                playerActu.setScore(30);
            }
            else if (nbDifferent == 4)
            {
                playerActu.removeEnergy(8);
                playerActu.setScore(10);
            }
            else if (nb5 == 5)
            {
                playerActu.removeEnergy(10);
                playerActu.setScore(7);
            }
            else
            {
                playerActu.removeEnergy(2);
                playerActu.setScore(3);
            }
            DelCards();
        }

        /**
         *Cette fonction permet d'ajouter 2 cartes sciences au joueur 
         * 
        */
        private void PiocherCards(object sender, EventArgs e)
        {
            Valoriser.Enabled = false;
            playerActu.removeEnergy(2);
            Board.DrawCards(playerActu, 2);
        }

        /**
         *Cette fonction supprimes les cartes choisis du joueur de sa main 
         * 
         * 
        */
        public void DelCards()
        {
            for (int i = 0; i < nbCards.Length; i++)
            {
                if (nbCards[i] > 0)
                {
                    for (int j = 0; j < nbCards[i]; j++)
                    {
                        Board.RemoveColorHand(playerActu, listColor[i]);
                    }
                }
            }
        }

        /**
         *Cette fonction teste si le joueur à assez d'energy pour valoriser ses cartes choisies 
         * sinon affiche un message et annule l'action
         * 
        */
        public void enoughEnergy()//appeler à chaque modification
        {
            if (nbCardsChoice *2 > playerActu.getEnergy())
            {
                MessageBox.Show("Pas assez d'energy");
            }
        }
    }
}

//Tester la main(nombre de carte par couleur) dans le clique
