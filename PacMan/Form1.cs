using System.Windows.Forms;

namespace PacMan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool goup, godown, goleft, goright = false;
        int pacmanspeed = 3;
        int score = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 5;
            timer1.Enabled = Enabled;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            goup = godown = goleft = goright = false;

            if (e.KeyCode == Keys.Up)
            {

                goup = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
            if (e.KeyCode == Keys.R)
            {
                Reset();
            }
        }

        //        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (goup)
            {
                if (pacman.Top < -50)
                {
                    pacman.Top = 450;
                }
                pacman.Top -= pacmanspeed;
                pacman.Image = Properties.Resources.pacmanup;

            }
            else if (godown)
            {
                if (pacman.Top > 450)
                {
                    pacman.Top = -50;
                }
                pacman.Top += pacmanspeed;
                pacman.Image = Properties.Resources.pacmandown;

            }
            else if (goleft)
            {
                if (pacman.Left < -50)
                {
                    pacman.Left = 800;
                }
                pacman.Left -= pacmanspeed;
                pacman.Image = Properties.Resources.pacmanleft;

            }
            else if (goright)
            {
                if (pacman.Left > 800)
                {
                    pacman.Left = -50;
                }
                pacman.Left += pacmanspeed;
                pacman.Image = Properties.Resources.pacman;
            }

            for (int i = 1; i <= 26; i++)
            {
                PictureBox gold = (PictureBox)this.Controls["gold" + i];
                if (gold != null && pacman.Bounds.IntersectsWith(gold.Bounds) && gold.Visible)
                {
                    score += 1;
                    gold.Visible = false;
                }
            }




            foreach (Control panel in this.Controls)
            {
                if (panel is Panel && panel.Name.StartsWith("panel"))
                {
                    if (pacman.Bounds.IntersectsWith(panel.Bounds))
                    {
                        goup = godown = goleft = goright = false;
                    }
                }
            }


            
            PictureBox[] ghosts = { picghostred, picghostblue, picghostyellow };

            foreach (PictureBox ghost in ghosts)
            {
                if (pacman.Bounds.IntersectsWith(ghost.Bounds))
                {
                    goup = godown = goleft = goright = false;
                    timer1.Enabled = false;
                }
            }



            label2.Text = "Score: " + score;
            label1.Text = "X:" + pacman.Location.X + "Y:" + pacman.Location.Y;
        }
        private void Reset()
        {
            for (int i = 1; i <= 26; i++)
            {
                PictureBox pictureBox = this.Controls.Find($"gold{i}", true).FirstOrDefault() as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Visible = true; // Εγ₯ά PictureBox
                }
            }
            timer1.Enabled = true;
            pacman.Top = 180;
            pacman.Left = 52;
        }


    }
    
}