using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperstellar
{
    internal class Pawn
    {
        private Color color;
        private Player playerActu;


        public Pawn(Color color, Player playerActu)
        {
            this.color = color;
            this.playerActu = playerActu;
        }
    
        /**
         *Cette fonction permet de renvoyer le joueur du pion 
         *return  : le joueur
         * 
        */
        public Player getPlayer()
        {
            return playerActu;
        }
         public Color getColor()
        {
            return color;
        }
    }

}
