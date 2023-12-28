using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperstellar
{
    public class Player
    {


        private string name;
        private int playerNumber;
        private int score = 0;
        private List<Color> hand = new List<Color>();
        private int energyToken = 0;
        private int waterToken = 0;
        private List<Pawn> pawns = new List<Pawn>();
        private int pawnLeft = 10;
        private Color playerColor;
        static Color[] playersColors = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown }; //
        public Player(string name, int playerNumber, Color color)
        {
            this.name = name;
            this.playerNumber = playerNumber;
            this.pawns.Add(new Pawn(color, this));
            this.pawns.Add(new Pawn(color, this));
            this.pawnLeft = 8;
            this.playerColor = color;
            this.playerColor = playersColors[playerNumber - 1]; //
        }

        public int getPlayerNumber()
        {
            return this.playerNumber;
        }

        public List<Color> getHand()
        {
            return this.hand;
        }

        /**
         * Cette fonction permet d'ajouter des jetons energy au joueur
         *@param nb : nombre de jetons énergy que l'on souhaite ajouter 
         *
        */
        public int getNumberOfResource(Color color)
        {
            return 999;
        }   
        public int getNumberOfCardsByColor(Color color)
        {
            return 10;
        }


        public int getScore()
        {
            return 149;
        }
        /*
        public int getNbCardsByColor(Color color)
        {
            return 88;
        }
        */

        public String getName()
        {
            return this.name;
        }
        public Color getColorPlayer()
        {
            return this.playerColor;
        }
        public int getNumberPlayer()
        {
            return this.playerNumber;
        }
        public void addEnergy(int nb)
        {
            if (Board.AMOUNTENERGY + nb >= 0)
            {
                this.energyToken += nb;
            }
            else
            {
                this.energyToken += Board.AMOUNTENERGY;
            }
        }


        /**
        * Cette fonction permet d'ajouter des jetons eau au joueur
        *@param nb : nombre de jetons eau que l'on souhaite ajouter 
        *
        */
        public void addWater(int nb)
        {
            if (Board.AMOUNTWATER + nb >= 0)
            {
                this.waterToken += nb;
            }
            else
            {
                this.waterToken += Board.AMOUNTWATER;
            }
        }

        /**
        * Cette fonction permet d'enlever des jetons energy au joueur
        *@param nb : nombre de jetons energy que l'on souhaite enlever 
        *
        */
        public void removeEnergy(int nb)
        {
            if (this.energyToken >= nb)
            {
                this.energyToken -= nb;
            }
            else
            {
                this.energyToken = 0;
            }
        }

        /**
        * Cette fonction permet d'enlever des jetons eau au joueur
        *@param nb : nombre de jetons eau que l'on souhaite enlever 
        *
        */
        public void removeWater(int nb)
        {
            if (this.waterToken >= nb)
            {
                this.waterToken -= nb;
            }
            else
            {
                this.waterToken = 0;
            }
        }

        /**
         * Cette fonction permet d'augmenter le score du joueur avec l'entier passé en paramètre
         * et si le score dépasse le scoreMaximal //...
         * @param nb : score que l'on veut ajouter
         * 
        */
        public void setScore(int nb)
        {
            this.score += nb;

            if (Board.scoreMax <= this.score)
            {
                //TODO
            }
        }

        /**
         *Cette fonction permet de si possible, ajouter un nouveau pion au joueur 
         * 
        */
        public void addNewPawn()
        {
            if (this.pawnLeft > 0)
            {
                this.pawns.Add(new Pawn(this.playerColor, this));
                this.pawnLeft--;
            }
        }

        public void removePawn()
        {
            if (this.pawns.Count() > 0)
            {
                this.pawns.Remove(new Pawn(this.playerColor, this));
                this.pawnLeft++;
            }
        }

        /**
         *Cette fonction permet d'obtenir le nombre de jetons energy du joueur 
         * 
        */
        public int getEnergy()
        {
            return this.energyToken;
        }

        /**
         *Cette fonction permet d'obtenir le nombre de jetons eau du joueur 
         * 
        */
        public int getWater()
        {
            return this.waterToken;
        }


        /**
         *Cette fonction permet d'obtenir le nombre de chercheurs du joueur 
         * 
        */
        public int getnbPawns()
        {
            return this.pawns.Count();
        }


        /**
         *Cette fonction permet de renvoyer le nombre de cartes de la couleur passé en paramètre dans la main du joueur 
         * @param color : couleur de la carte
         * return : le nombre de cartes de la couleur dans la main du joueur
         * 
        */
        public int getNbCardsByColor(Color color)
        {
            int res = 0;
            for (int i = 0; i < hand.Count(); i++)
            {
                if (hand[i] == color)
                {
                    res++;
                }
            }
            return res;
        }

        public Color getColor()
        {
            return this.playerColor;
        }
    }
}
