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
using static System.Collections.Specialized.BitVector32;

namespace Hyperstellar
{
    public partial class MenuDebut : Form
    {
        
        Rectangle screen = new Rectangle(0,0, 1920, 1080);
        Rectangle rectPlay;
        Rectangle rectExtensions;
        Rectangle rectQuit;
        Rectangle rectCredits;
        Font FONT_TITLE;
        Font FONT_BUTTON;
        Font FONT_CREDIT;
        PrivateFontCollection privateFonts = new PrivateFontCollection();
        String s;


        public MenuDebut()
        {
            InitializeComponent();
            privateFonts.AddFontFile(Application.StartupPath + @"\CRYSISB.ttf");
            FONT_TITLE = new Font(privateFonts.Families[0], 90, FontStyle.Bold, GraphicsUnit.Point);
            FONT_BUTTON = new Font(privateFonts.Families[0], 60, FontStyle.Bold, GraphicsUnit.Point);
            FONT_CREDIT = new Font(privateFonts.Families[0], 40, FontStyle.Bold, GraphicsUnit.Point);
        }

        private void MenuDebut_Paint(object sender, PaintEventArgs e)
        {
            int screenCenter = screen.Width / 2;
            // Title
            s = "HYPERSTELLAR";
            SizeF sizeTitle = e.Graphics.MeasureString(s, FONT_TITLE);
            SolidBrush brush = new SolidBrush(Color.White);
            e.Graphics.DrawString(s, FONT_TITLE, brush, screenCenter - (sizeTitle.Width) / 2, 15);
            

            // Line
            int sizeLine = 1100;
            Pen pen = new Pen(Color.White, 5);
            Point p1 = new Point(screenCenter - (sizeLine / 2), (int)sizeTitle.Height + 30);
            Point p2 = new Point(screenCenter + (sizeLine / 2), (int)sizeTitle.Height + 30);
            e.Graphics.DrawLine(pen, p1, p2);

            List<String> list = new List<String> { "JOUER", "EXTENSIONS", "QUITTER"};
            int x = screen.Width / 2;
            int y = p1.Y + 250;
            foreach (String name in list)
            {
                s = name;
                SizeF sizeButton = e.Graphics.MeasureString(s, FONT_BUTTON);
                Point point = new Point(x - (int)sizeButton.Width / 2, y);
                e.Graphics.DrawString(s, FONT_BUTTON, brush, point);
                y += (int)sizeButton.Height + 20;
            }

            // Credit button
            s = "CREDITS";
            SizeF sizeCredits = e.Graphics.MeasureString(s, FONT_CREDIT);
            Point pointCredits = new Point(screen.Width - (int)sizeCredits.Width - 10 , screen.Height - (int)sizeCredits.Height - 30);
            e.Graphics.DrawString(s, FONT_CREDIT, brush, pointCredits);
            rectCredits = new Rectangle(pointCredits.X, pointCredits.Y, (int)sizeCredits.Width, (int)sizeCredits.Height);
            
        }

        private void MenuDebut_MouseDown(object sender, MouseEventArgs e)
        {
            if (rectCredits.Contains(e.Location))
            {
                Credits credits = new Credits();
                credits.WindowState = FormWindowState.Maximized;
                credits.Show();
            }
        }
    }
}
