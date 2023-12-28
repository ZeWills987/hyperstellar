using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperstellar
{
    internal class Sector
    {
        private string name;
        private int sectorNumero;
        private List<Pawn> takens;
        private int nbPlacesMax;

        public Sector(string name, int sectorNumero, int nbPlacesMax)
        {
            this.name = name;
            this.sectorNumero = sectorNumero;
            this.nbPlacesMax = nbPlacesMax;
        }

        /**
         *Cette fonction permet de renvoyer le jouer à partir de son pion 
         * @param pawn : le pion en question
         * return : le joueur 
         * 
         * ENLEVER OR NULL
        */
        public Player getPlayerOrNull(Pawn pawn) //for takens
        {
            return pawn.getPlayer();
        }

        public Boolean containsPawn()
        {
            return this.takens.Count > 0;
        }

        public int nbPawns()
        {
            return this.takens.Count;
        }


        public Boolean full()
        {
            return this.nbPlacesMax <= takens.Count;
        }

        public void addPawn(Pawn p)
        {
            if (this.takens.Count < this.nbPlacesMax)
            {
                this.takens.Add(p);
            }
        }

        public Pawn getPawn(int nb)
        {
            return this.takens[nb];
        }

        public int getSectorNumero()
        {
            return this.sectorNumero;
        }
        public int getNbPlacesMax()
        {
            return this.nbPlacesMax;
        }

        public void addPawn(Player pl)
        {
            if (takens.Count < nbPlacesMax)
            {
                this.takens.Add(new Pawn(pl.getColor(), pl));
            }
        }
    }
}
