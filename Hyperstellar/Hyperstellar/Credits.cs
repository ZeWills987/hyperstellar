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

namespace Hyperstellar
{
    public partial class Credits : Form
    {
        Rectangle screen = new Rectangle(0, 0, 1920, 1080);
        Rectangle rectBack;
        Font FONT_TITLE;
        Font FONT_SENTENCE;
        Font FONT_CREDITS;
        PrivateFontCollection privateFonts = new PrivateFontCollection();
        String s;
        

        public Credits()
        {
            InitializeComponent();
            privateFonts.AddFontFile(Application.StartupPath + @"\CRYSISB.ttf");
            FONT_TITLE = new Font(privateFonts.Families[0], 90, FontStyle.Bold, GraphicsUnit.Point);
            FONT_SENTENCE = new Font(privateFonts.Families[0], 40, FontStyle.Bold, GraphicsUnit.Point);
            FONT_CREDITS = new Font(privateFonts.Families[0], 40, FontStyle.Bold, GraphicsUnit.Point);

        }

        private void Credits_Paint(object sender, PaintEventArgs e)
        {
            int screenCenter = screen.Width / 2;

            // Title
            s = "CREDITS";
            SizeF sizeTitle = e.Graphics.MeasureString(s, FONT_TITLE);
            SolidBrush brush = new SolidBrush(Color.White);
            e.Graphics.DrawString(s, FONT_TITLE, brush, screenCenter - (sizeTitle.Width) / 2, 15);

            // Line
            int sizeLine = 500;
            Pen pen = new Pen(Color.White, 5);
            Point p1 = new Point(screenCenter - (sizeLine / 2), (int)sizeTitle.Height + 30);
            Point p2 = new Point(screenCenter + (sizeLine / 2), (int)sizeTitle.Height + 30);
            e.Graphics.DrawLine(pen, p1, p2);

            // Sentence
            s = "JEU CODÉ PAR :";
            SizeF sizeSentence = e.Graphics.MeasureString(s, FONT_SENTENCE);
            Point pointSentence = new Point(screenCenter - ((int)sizeSentence.Width) / 2, p1.Y + 160);
            e.Graphics.DrawString(s, FONT_SENTENCE, brush, pointSentence);


            List<String> listName = new List<String> {"Leo Graziani","Ilan Paillat","Tristan Petit","William Tchang" };
            int x = screen.Width/2;
            int y = pointSentence.Y + (int)sizeSentence.Height + 100;
            foreach (String name in listName)
            {
                s = name;
                SizeF size = e.Graphics.MeasureString(s, FONT_CREDITS);
                Point point = new Point(x - (int)size.Width/2, y);
                e.Graphics.DrawString(s, FONT_CREDITS, brush, point);
                y += (int)size.Height + 10;
            }

            // Back Button
            s = "BACK";
            SizeF sizeBack = e.Graphics.MeasureString(s, FONT_SENTENCE);
            brush = new SolidBrush(Color.White);
            Point pointBack = new Point(40, screen.Height - (int)sizeBack.Height - 40);
            e.Graphics.DrawString(s, FONT_SENTENCE, brush, pointBack);
            rectBack = new Rectangle(pointBack.X, pointBack.Y, (int)sizeBack.Width, (int)sizeBack.Height);
        }

        private void Credits_MouseDown(object sender, MouseEventArgs e)
        {
            if (rectBack.Contains(e.Location))
            {
                Close();
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Credits));
            this.SuspendLayout();
            // 
            // Credits
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Name = "Credits";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Credits_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Credits_MouseDown);
            this.ResumeLayout(false);

        }
    }
}
