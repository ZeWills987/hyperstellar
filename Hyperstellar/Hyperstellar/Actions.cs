using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperstellar
{
    internal class Actions
    {

        /**
         *Cette fonction est l'action de la salle des machines. Elle ajoute 7 jetons énergy au joueur 
         * 
        */
        public static void machineRoomAction(Player player)
        {
            player.addEnergy(7);
        }


        public static void labRoomAction()
        {

        }

        public static void recycleRoomAction()
        {

        }

        public static void crewRoomAction(Player player)
        {
            if (1>0)
            {
                player.removeEnergy(5);
                player.addNewPawn();
            }
        }
    }
}
