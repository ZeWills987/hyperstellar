using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Text;
using System.Xml.Linq;


namespace Hyperstellar
{
    public partial class Board : Form
    {

        // Crée une collection de polices privées
        PrivateFontCollection privateFonts = new PrivateFontCollection();


        public int Phase = 1;
        public static int AMOUNTWATER = 100;
        public static int AMOUNTENERGY = 100;
        public static int scoreMax = 149;
        public static Font FONT;
        public static Font TITLEFONT;
        private static Font FONTHUB;
        private static Font FONTSECTOR;
        private static Rectangle gameDialog;


        private int NUMBER_OF_PLAYER; 
        private Player actualPlayer;
        private readonly int widthSector = 200;
        private readonly int heighSector = 100;
        private readonly int widthCorridor = 40;
        private readonly int centerDistance = 100;
        private readonly int slotRay = 30;
        private Rectangle hub;


        public static List<Color> deck = new List<Color>();
        public static List<Color> discard = new List<Color>();
        private static List<Sector> listSectors = new List<Sector>();

        private List<Player> players = new List<Player>();
        private List<Rectangle> rectangleSector = new List<Rectangle>();
        private List<string> extensions = new List<string>(); // pas utilisé encore 
        private List<Color> colorList = new List<Color> { Color.Blue, Color.Green, Color.Red, Color.Yellow};
        private List<Rectangle> playerRectangles;

        public Board()
        {

            InitializeComponent();


            privateFonts.AddFontFile(Application.StartupPath + @"\CRYSISB.ttf");





            FONT = new Font(privateFonts.Families[0], 16, FontStyle.Bold, GraphicsUnit.Point);
            TITLEFONT = new Font(privateFonts.Families[0], 28, FontStyle.Bold, GraphicsUnit.Point);
            FONTSECTOR = new Font(privateFonts.Families[0], 15, FontStyle.Bold, GraphicsUnit.Point);
            FONTHUB = new Font(privateFonts.Families[0], 20, FontStyle.Bold, GraphicsUnit.Point);


            gameDialog = new Rectangle(0, 88, 1920, 100); // Attention, a initialiser avant le DialogLabel !!

            DialogLabel.Text = "Bienvenue dans HYPERSTELLAR !!";
            DialogLabel.Font = TITLEFONT;
            DialogLabel.ForeColor = Color.White;
            DialogLabel.Left = (ClientSize.Width - DialogLabel.Width) / 2;
            DialogLabel.Top = gameDialog.Y + (gameDialog.Height - DialogLabel.Height)/2;


            GenerateDeck(); // Genarate a deck 
            MixDeck(deck); // Mix a deck 
            ChoiceOfPlayerNumber();// Choice number of player in game 
            ChoiceOfExtension(); // Choice extention(s) for game 
            CreatePlayers(); // Create all players 
            InitSector(); //Initialize all sectors
            StartGame();
            //partGame(); //WHILE TRUE
            playerRectangles = new List<Rectangle>();
            players = new List<Player>();

            // Pour les tests
            Player p1 = new Player("Leo", 1, Color.AliceBlue);
            Player p2 = new Player("Ilan", 2, Color.AntiqueWhite);
            Player p3 = new Player("Tristan", 3, Color.Aqua);
            Player p4 = new Player("William", 4, Color.Aquamarine);
            Player p5 = new Player("FanDuJ", 5, Color.Azure);
            players.Add(p1);
            players.Add(p2);
            players.Add(p3);
            players.Add(p4);
            players.Add(p5);
            //


            int hudPlayerRectWidth = 150;
            int hudPlayerRectHeight = 300;

            Rectangle ship = new Rectangle(310, 250, 1300, 650);  // ship
            Rectangle player1 = new Rectangle(40,210, hudPlayerRectWidth, hudPlayerRectHeight);  // player 1
            Rectangle player2 =  new Rectangle(1730,210, hudPlayerRectWidth, hudPlayerRectHeight); // player 2
            Rectangle player3 =  new Rectangle(40, 610, hudPlayerRectWidth, hudPlayerRectHeight); // player 3
            Rectangle player4 = new Rectangle(1730, 610, hudPlayerRectWidth, hudPlayerRectHeight); // player 4
            Rectangle player5 = new Rectangle(450, 820, 1000, 130); // player 

            playerRectangles.Add(player1);
            playerRectangles.Add(player2);
            playerRectangles.Add(player3);
            playerRectangles.Add(player4);
            playerRectangles.Add(player5);

        }

        #region Draw


        private void DrawPlayerHUD(Player player, PaintEventArgs e)
        {
            Rectangle rect = playerRectangles[player.getNumberPlayer() - 1];

            int marginx = 10;
            int marginy = 10;

            int x = rect.Location.X;
            int y = rect.Location.Y;
            int cardWidth = 40;
            int cardHeight = 60;
            int nbCards = 0;
            int resourceSide = 50;

            // Name of the player
            string playerInfo = player.getName();
            SizeF textSize = e.Graphics.MeasureString(playerInfo, TITLEFONT);
            x += (int)(rect.Width / 2 + marginx - textSize.Width / 2);
            y += marginy;
            e.Graphics.DrawString(playerInfo, TITLEFONT, Brushes.White, new PointF(x, y));

            x = rect.Location.X;

            // Score of the player

            y += (int)textSize.Height;
            playerInfo = player.getScore().ToString();
            textSize = e.Graphics.MeasureString(playerInfo, FONT);
            if (player.getNumberPlayer() != 5)
            {
                x += (int)(rect.Width - textSize.Width + marginx) / 2;
            }
            else
            {
                x = (int)(rect.Location.X + (rect.Width - textSize.Width) / 2);
            }

            e.Graphics.DrawString(playerInfo, FONT, Brushes.White, new PointF(x, y));

            x = rect.Location.X + 4 * (marginx + cardWidth);
            if (player.getNumberPlayer() != 5)
            {
                y -= cardHeight - 2 * marginy;
            }

            SolidBrush b = new SolidBrush(Color.White);
            Pen pen = new Pen(Color.White, 3);

            // Cards of the player
            foreach (CardsColor cardColor in Enum.GetValues(typeof(CardsColor)))
            {
                Color color = Color.FromName(cardColor.ToString()); // convertir la valeur de l'énumération en une couleur
                string numberOfCardsByColor = player.getNumberOfCardsByColor(color).ToString();
                textSize = e.Graphics.MeasureString(numberOfCardsByColor, FONT);
                if (player.getNumberPlayer() != 5)
                {
                    if (nbCards == 6)
                    {
                        x = rect.X + (rect.Width - cardWidth + marginx) / 2;
                        y += marginy + cardHeight;
                    }
                    else if (nbCards % 3 == 0)
                    {
                        y += marginy + cardHeight;
                        x = rect.X + marginx;
                    }
                    else
                    {
                        x += cardWidth + marginx;
                    }
                }
                else
                {
                    x += cardWidth + marginx;
                    y = rect.Location.Y + marginy + cardHeight + (int)textSize.Height;
                }

                Rectangle r = new Rectangle(x, y, cardWidth, cardHeight);
                b.Color = color;
                e.Graphics.FillRectangle(b, r);
                e.Graphics.DrawRectangle(pen, r);
                Point locText = new Point(r.X + (r.Width - (int)textSize.Width) / 2, r.Y + (r.Height - (int)textSize.Height) / 2);
                e.Graphics.DrawString(numberOfCardsByColor, FONT, new SolidBrush(Color.White), locText);
                nbCards++;
            }

            if (player.getNumberPlayer() != 5)
            {
                y = rect.Y + 4 * (marginy + cardHeight) + marginy;
                x = rect.X + (rect.Width - 2 * resourceSide) / 2;
            }
            else
            {
                x += marginx * 2 + cardWidth;
                y = rect.Location.Y + marginy + cardHeight + (int)textSize.Height;
            }
            // Resources 
            y += marginy;
            foreach (RessourcesColor ressourcesColor in Enum.GetValues(typeof(RessourcesColor)))
            {

                Color color = Color.FromName(ressourcesColor.ToString()); 
                string numberOfResource = player.getNumberOfResource(color).ToString();
                textSize = e.Graphics.MeasureString(numberOfResource, FONT);
                Rectangle r = new Rectangle(x, y, resourceSide, resourceSide);
                Point locText = new Point(r.X + (r.Width - (int)textSize.Width) / 2, r.Y + (r.Height - (int)textSize.Height) / 2);

                b.Color = color;
                e.Graphics.FillRectangle(b, r);
                e.Graphics.DrawRectangle(pen, r);
                e.Graphics.DrawString(numberOfResource, FONT, new SolidBrush(Color.White), locText);
                x += resourceSide + marginx;
            }



        }

        private void Board_Paint(object sender, PaintEventArgs e)
        {

            Pen pen = new Pen(Color.Black);

            String title = "HYPERSTELLAR";
            SizeF titleSize = e.Graphics.MeasureString(title, TITLEFONT);
            e.Graphics.DrawString(title, TITLEFONT, Brushes.White, new PointF(1920 / 2 - titleSize.Width / 2, 25));


            // Création d'un pinceau solide avec une couleur violette claire et un faible niveau de transparence
            SolidBrush brush = new SolidBrush(Color.FromArgb(50, 191, 144, 228));

            // Remplissage d'un rectangle avec le pinceau solide
            e.Graphics.FillRectangle(brush, gameDialog);

           
            pen.Dispose();
            foreach (Player p in players)
            {
                DrawPlayerHUD(p, e);
            }

            DrawShip(sender, e);
            DrawSlot(sender, e);


        }

        private void DrawShip(object sender, PaintEventArgs e)
        {

            Pen pen = new Pen(Color.Black, 3);
            Point p;
            Size size;
            Brush brush;
            Rectangle sector;

            Brush fontBrush = new SolidBrush(Color.Black);

            // Generation hub
            p = new Point(880, 440);
            size = new Size(180, 180);
            hub = new Rectangle(p, size);


            // Corridors
            brush = new SolidBrush(ColorTranslator.FromHtml("#f0f2f0"));
            p = new Point(hub.X - centerDistance - (widthSector) / 2, hub.Y + (hub.Height - widthCorridor) / 2);
            size = new Size(widthSector + 2 * (centerDistance) + hub.Width, widthCorridor);
            Rectangle corridor = new Rectangle(p, size);
            e.Graphics.FillRectangle(brush, corridor);
            e.Graphics.DrawRectangle(pen, corridor);

            p = new Point(hub.X + (hub.Width - widthCorridor) / 2, hub.Y - centerDistance - (heighSector) / 2);
            size = new Size(widthCorridor, heighSector + 2 * (centerDistance) + hub.Height);
            corridor = new Rectangle(p, size);
            e.Graphics.FillRectangle(brush, corridor);
            e.Graphics.DrawRectangle(pen, corridor);


            // Paint hub
            String s = "HUB";
            SizeF sizeString = e.Graphics.MeasureString(s, FONTHUB);
            brush = new SolidBrush(ColorTranslator.FromHtml("#1f628e"));
            e.Graphics.FillEllipse(brush, hub);
            e.Graphics.DrawEllipse(pen, hub);
            e.Graphics.DrawString(s, FONTHUB, fontBrush, hub.X + (hub.Width - sizeString.Width) / 2, hub.Y + 20);

            s = "Tour : X";
            sizeString = e.Graphics.MeasureString(s, FONTHUB);
            e.Graphics.DrawString(s, FONTHUB, fontBrush, hub.X + (hub.Width - sizeString.Width) / 2, hub.Y + 50);

            // Draw 4 principal sectors
            brush = new SolidBrush(ColorTranslator.FromHtml("#37abc8"));
            size = new Size(widthSector, heighSector);

            // Right
            p = new Point(hub.X + hub.Width + centerDistance, hub.Y + (hub.Height - heighSector) / 2);
            sector = new Rectangle(p, size);
            e.Graphics.FillRectangle(brush, sector);
            e.Graphics.DrawRectangle(pen, sector);
            rectangleSector.Add(sector);
            s = "Salle de recherche";
            sizeString = e.Graphics.MeasureString(s, FONTSECTOR);
            e.Graphics.DrawString(s, FONTSECTOR, fontBrush, p.X + (sector.Width - sizeString.Width) / 2, p.Y + 10);


            // Bottom
            p = new Point(hub.X - (widthSector - hub.Width) / 2, hub.Y + hub.Height + centerDistance);
            sector = new Rectangle(p, size);
            e.Graphics.FillRectangle(brush, sector);
            e.Graphics.DrawRectangle(pen, sector);
            rectangleSector.Add(sector);
            s = "Centre de recyclage";
            sizeString = e.Graphics.MeasureString(s, FONTSECTOR);
            e.Graphics.DrawString(s, FONTSECTOR, fontBrush, p.X + (sector.Width - sizeString.Width) / 2, p.Y + 10);

            // Left
            p = new Point(hub.X - (widthSector - hub.Width) / 2, hub.Y - heighSector - centerDistance);
            sector = new Rectangle(p, size);
            e.Graphics.FillRectangle(brush, sector);
            e.Graphics.DrawRectangle(pen, sector);
            rectangleSector.Add(sector);
            s = "Salle des machines";
            sizeString = e.Graphics.MeasureString(s, FONTSECTOR);
            e.Graphics.DrawString(s, FONTSECTOR, fontBrush, p.X + (sector.Width - sizeString.Width) / 2, p.Y + 10);

            // Top
            p = new Point(hub.X - widthSector - centerDistance, hub.Y + (hub.Height - heighSector) / 2);
            sector = new Rectangle(p, size);
            e.Graphics.FillRectangle(brush, sector);
            e.Graphics.DrawRectangle(pen, sector);
            rectangleSector.Add(sector);
            s = "Quartiers d'équipage";
            sizeString = e.Graphics.MeasureString(s, FONTSECTOR);
            e.Graphics.DrawString(s, FONTSECTOR, fontBrush, p.X + (sector.Width - sizeString.Width) / 2, p.Y + 10);

        }


        private void DrawSlot(object sender, PaintEventArgs e)
        {
            List<int> nbrSlot = new List<int> { 2, 5, 2, 4 };
            Pen pen = new Pen(Color.Black, 3);
            SolidBrush brush = new SolidBrush(ColorTranslator.FromHtml("#f0f2f0"));

            // Draw slots for the sectors
            for (int i = 0; i < 4; i++)
            {
                int margin = (widthSector - (nbrSlot[i] * slotRay)) / nbrSlot[i];
                Rectangle sector = rectangleSector[i];
                Point p = new Point(sector.X + (margin / 2), sector.Y + sector.Height - slotRay - 10);
                Size size = new Size(slotRay, slotRay);
                for (int j = 0; j < nbrSlot[i]; j++)
                {
                    Rectangle slot = new Rectangle(p, size);
                    p = new Point(p.X + slotRay + margin, p.Y);
                    e.Graphics.FillEllipse(brush, slot);
                    e.Graphics.DrawEllipse(pen, slot);
                }
            }


            // Draw Slots for the hub
            int marginHub = ((hub.Width - 10) - (4 * slotRay)) / 4; // Changer les 4 par le nombre de joueur
            Point pHub = new Point(hub.X + 5 + (marginHub / 2), hub.Y + 100);
            for (int i = 0; i < 4; i++)
            {
                Rectangle slot = new Rectangle(pHub, new Size(slotRay, slotRay));
                pHub = new Point(pHub.X + slotRay + marginHub, pHub.Y);
                e.Graphics.FillEllipse(brush, slot);
                e.Graphics.DrawEllipse(pen, slot);
            }
        }
        #endregion


        public Boolean AllSectorFull()
        {
            foreach (Sector s in listSectors)
            {
                if (!s.full())
                {
                    return false;
                }
            }
            return true;
        }

        #region Enums
        private enum CardsColor
        {
            Yellow,
            Purple,
            Red,
            Green,
            Pink,
            Black,
            White 
        }

        private enum RessourcesColor
        {
            Aqua,
            LawnGreen
        }
        #endregion



        public void ChoiceOfPlayerNumber()
        {
            NUMBER_OF_PLAYER = 4; // Drop for the front 
            //NUMBER_OF_PLAYER =  ; Completed !!!!
        }

        

        public void ChoiceOfExtension()
        {
            // Choise of extention(s) to completed
        }

        public void AddSector(String name, int sectorNumero, int nbPlaces)
        {
            listSectors.Add(new Sector(name, sectorNumero, nbPlaces));
        }
        public void InitSector()
        {
            AddSector("Salle des machines", 1, 2);
            AddSector("Laboratoire", 2, 2);
            AddSector("Recyclage", 3, 5);
            AddSector("Quartiers", 4, 4);
        }
        public void StartGame()
        {
            // All ressources of players in start Game
            for (int i = 0; i < players.Count; i++)
            {
                players[i].addEnergy(10);
                players[i].addWater(10);
                actualPlayer = (Player)players[i];
                AddPawns(2);
            }
        }
        /**
 * Add pawns for one player and discard it of gamePanw.
 * @param p : the player
 * @param num : number of pawn want to add
 */
        public void AddPawns(int num)
        {
            for (int i = 0; i < num; i++)
            {
                actualPlayer.addNewPawn();
            }
        }
        /**
 * Create all players. 
 */
        public void CreatePlayers()
        {
            int numPlayers = players.Count;
            Player p = new Player("Player " + numPlayers + 1, numPlayers + 1, colorList[numPlayers]);
            players.Add(p);
        }
        /**
         *Cette fonction permet de générer un deck en début de jeu 
         * 
        */
        public void GenerateDeck()
        {
            deck = new List<Color>();
            discard = new List<Color>();

            for (int i = 0; i < 20; i++)
            {
                deck.Add(Color.Yellow);
                deck.Add(Color.Blue);
                deck.Add(Color.Red);
                deck.Add(Color.Green);
            }
            for (int i = 0; i < 10; i++)
            {
                deck.Add(Color.Purple);
            }
            for (int i = 0; i < 8; i++)
            {
                deck.Add(Color.Black);
        }
            deck.Add(Color.White);
            deck.Add(Color.White);
        }

        /**
         *Cette fonction permet de mélanger le deck passé en paramètre, dans le deck principal
         *@param list : deck que l'on souhaite mélanger
         * 
        */
        public static void MixDeck(List<Color> list)
        {
            deck = list.OrderBy(a => Guid.NewGuid()).ToList();

        }

        /**
         *Cette fonction permet transformer la défausse en un nouveau deck 
         * 
        */
        public void DiscardToDeck()
        {
            MixDeck(discard);
        }

        
        public static void DrawCards(Player player, int nb)
        {
            if (nb > deck.Count)
            {
                int nbMaxCards = deck.Count;
                for (int j = 0; j < nbMaxCards; j++)
                {
                    player.getHand().Add(deck.Last());
                    deck.RemoveAt(deck.Count - 1);
                }
                MixDeck(deck);
                for (int k = 0; k < nb - nbMaxCards; k++)
                {
                    player.getHand().Add(deck.Last());
                    deck.RemoveAt(deck.Count - 1);
                }
            }
            for (int i = 0; i < nb; i++)
            {
                player.getHand().Add(deck.Last());
                deck.RemoveAt(deck.Count - 1);
            }
        }

        public static void RemoveColorHand(Player player, Color color)//del peut etre toutes les cartes de la couleur
        {
            player.getHand().Remove(color);
            discard.Add(color);
        }

        public Boolean MoyeuIsEmpty()
        {
            return false;
        }

        public void PartGame()
        {
            int revolution = 0;
            while (!IsEnd())
            {
                revolution = revolution + 1;
                PlacementPhase();
                ActionPhase();
                MaintenancePhase();
            }
        }

        public void PlacementPhase()
        {
            Sector actualSector = null;
            int rotation = 0;
            while (!MoyeuIsEmpty() || AllSectorFull())
            {
                rotation = rotation + 1;
                foreach (Player pl in players)
                {
                    if (pl.getnbPawns() > 0 && actualSector.getNbPlacesMax() > 0)
                    {
                        actualPlayer = pl;
                        actualSector.addPawn(actualPlayer);
                        //pl.placePawn();
                        // action de placement du pion par le player
                    }
                }
            }
        }

        public void ActionPhase()
        {
            foreach (Sector s in listSectors)
            {
                int[] listPlayer = new int[players.Count];
                for (int j = 0; j < players.Count; j++)
                {
                    listPlayer[j] = 0;
                }
                for (int i = 0; i < s.nbPawns(); i++)
                {
                    Player playerSecteur = s.getPawn(i).getPlayer();
                    listPlayer[playerSecteur.getPlayerNumber()] += 1;
                    if (listPlayer[playerSecteur.getPlayerNumber()] <= 1 || s.getSectorNumero() == 4)
                    {
                        switch (s.getSectorNumero())
                        {
                            case 1:
                                playerSecteur.addEnergy(7);
                                break;
                            case 2:
                                laboratoire label = new laboratoire(playerSecteur);
                                label.ShowDialog();
                                break;
                            case 3:
                                recyclage recycl = new recyclage(playerSecteur, players);
                                recycl.ShowDialog();
                                break;
                            case 4:
                                if (listPlayer[playerSecteur.getPlayerNumber()] >= 2)
                                {
                                    quartiers q = new quartiers(playerSecteur);
                                    q.ShowDialog();
                                }
                                break;
                        }
                    }
                    //isEnd();
                }
            }
        }

        

        public void MaintenancePhase()
        {
            int nbWater;
            int nbPawns;
            foreach (Player pl in players)
            {
                actualPlayer = pl;
                nbWater = actualPlayer.getWater();
                nbPawns = actualPlayer.getnbPawns();
                if (nbWater < nbPawns)
                {
                    actualPlayer.removePawn();
                }
                else
                {
                    actualPlayer.removeWater(nbPawns);
                }
            }
        }

        public bool IsEnd()
        {
            bool isEnd = false;
            int i = 0;
            Player pl;
            while (!isEnd || i < players.Count)
            {
                pl = players[i];
                if (pl.getnbPawns() == 0)
                {
                    isEnd = true;
                }
            }
            return isEnd;
        }
       

        private void ChangeDialog(string text)
        {
            DialogLabel.Text = text;
            DialogLabel.Left = (this.ClientSize.Width - DialogLabel.Width) / 2;
        }
        private void Board_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ChangeDialog("Joueur 5 c'est à vous de placer un pion");
            }
            else
            {
                ChangeDialog("Commençons la partie !!!!");

            }

            // POUR TESTER LES QUARTIERS
            // quartiers q = new quartiers(new Player("Tristan",1,Color.Red));
            // q.ShowDialog();
        }
    }
}
