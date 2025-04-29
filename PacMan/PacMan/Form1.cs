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
        int pacmanspeed = 5;
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
        }

        //        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (goup)
            {
                pacman.Top -= pacmanspeed;
                pacman.Image = Properties.Resources.pacmanup;

            }
            else if (godown)
            {
                pacman.Top += pacmanspeed;
                pacman.Image = Properties.Resources.pacmandown;

            }
            else if (goleft)
            {
                pacman.Left -= pacmanspeed;
                pacman.Image = Properties.Resources.pacmanleft;

            }
            else if (goright)
            {
                pacman.Left += pacmanspeed;
                pacman.Image = Properties.Resources.pacman;
            }

            if (pacman.Bounds.IntersectsWith(pictureBox6.Bounds))
            
                if (pictureBox6.Visible)
                {
                score += 1;
                pictureBox6.Visible = false;
                }
                
            
            label2.Text = "Score: " + score;
            label1.Text = "X:" + pacman.Location.X + "Y:" + pacman.Location.Y;
        }


    }
}