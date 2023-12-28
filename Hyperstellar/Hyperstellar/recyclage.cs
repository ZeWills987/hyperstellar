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
    public partial class recyclage : Form
    {
        Player playerActu;
        List<Player> allPlayersActu;

        public recyclage(Player player, List<Player > allPlayers)
        {
            InitializeComponent();
            playerActu = player;
            allPlayersActu = allPlayers;
        }

        private void choice1(object sender, EventArgs e)
        {
            playerActu.removeEnergy(2);
            playerActu.addWater(4);

            foreach (Player p in allPlayersActu)
            {
                if (p.getColor() != playerActu.getColor())
                {
                    quartiesPlayers quartsPlayer = new quartiesPlayers(p);
                    quartsPlayer.Show();
                }
            }
        }

        private void choice2(object sender, EventArgs e)
        {
            playerActu.removeEnergy(5);
            playerActu.addWater(7);

            foreach (Player p in allPlayersActu)
            {
                if (p.getColor() != playerActu.getColor())
                {
                    p.addWater(1);
                }
            }
        }
    }
}
