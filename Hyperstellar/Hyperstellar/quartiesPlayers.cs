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
    public partial class quartiesPlayers : Form
    {
        Player playerActu;
        public quartiesPlayers(Player player)
        {
            InitializeComponent();
            playerActu = player;
        }

        private void validate(object sender, EventArgs e)
        {
            playerActu.removeEnergy(1);
            playerActu.addWater(1);
        }
    }
}
