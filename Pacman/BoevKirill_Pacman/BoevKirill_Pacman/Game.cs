using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoevKirill_Pacman
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
            pacman.Location = p;
      
        }

        public static int x = 555;
        public static int y = 523;

        public static int x_g1 = 397;
        public static int y_g1 = 352;

        Random rnd;
        int ghost_rand = 0;
        int ghost_temp = 0;

        string move = "right";
        string move_ghost1 = "left";

        public static bool setLose = false;

        int coin_score = 0;

        Point p = new Point(x, y);
        Point p_g1 = new Point(x_g1, y_g1); 


        void moveXY(int _x, string l)
        {
            if (l == "x")
            {
                x += _x;
                p.X = x;
                pacman.Location = p;
                if (_x > 0)
                {
                    pacman.Image = Properties.Resources.pacman;
                }
                if (_x < 0)
                {
                    pacman.Image = Properties.Resources.pacman_left;
                }
            }
            if(l == "y")
            {
                y += _x;
                p.Y = y;
                pacman.Location = p;
                if (_x > 0)
                {
                    pacman.Image = Properties.Resources.pacman_down;
                }
                if (_x < 0)
                {
                    pacman.Image = Properties.Resources.pacman_up;
                }
            }
        }
        void moveXY_ghost(int _x, string l)
        {
            if(l == "x")
            {
                x_g1 += _x;
                p_g1.X = x_g1;
                ghost1.Location = p_g1;
            }
            if(l == "y")
            {
                y_g1 += _x;
                p_g1.Y = y_g1;
                ghost1.Location = p_g1;
            }
        }
        void collision(int _x, string l)
        {
            if(l == "x")
            {
                foreach (Control x1 in this.Controls)
                {
                    if ((string)x1.Tag == "wall")
                    {
                        if (pacman.Bounds.IntersectsWith(x1.Bounds))
                        {
                            x += _x;
                            p.X = x;
                            pacman.Location = p;


                            if(_x > 0)
                            {
                                pacman.Image = Properties.Resources.pacman_left;
                            }
                            if(_x < 0)
                            {
                                pacman.Image = Properties.Resources.pacman;
                            }
                            move = "null";

                        }
                    }

                    if ((string)x1.Tag == "coin")
                    {
                        if (x1.Visible == true)
                        {
                            if (pacman.Bounds.IntersectsWith(x1.Bounds))
                            {
                                coin_score++;
                                x1.Visible = false;
                            }
                        }
                    }
                    
                }
            }
            if(l == "y")
            {
                foreach (Control x1 in this.Controls)
                {
                    if ((string)x1.Tag == "wall")
                    {
                        if (pacman.Bounds.IntersectsWith(x1.Bounds))
                        {
                            y += _x;
                            p.Y = y;
                            pacman.Location = p;

                            if (_x > 0)
                            {
                                pacman.Image = Properties.Resources.pacman_up;
                            }
                            if (_x < 0)
                            {
                                pacman.Image = Properties.Resources.pacman_down;
                            }
                            move = "null";

                        }
                    }

                    if ((string)x1.Tag == "coin")
                    {
                        if (x1.Visible == true)
                        {
                            if (pacman.Bounds.IntersectsWith(x1.Bounds))
                            {
                                coin_score++;
                                x1.Visible = false;
                            }
                        }
                    }
                    
                }
            }
            
        }
        void collision_ghost(int _x, string l)
        {
            if(l == "x")
            {
                foreach (Control x1 in this.Controls)
                {
                    if ((string)x1.Tag == "wall")
                    {
                        if (ghost1.Bounds.IntersectsWith(x1.Bounds))
                        {
                            x_g1 += _x;
                            p_g1.X = x_g1;
                            ghost1.Location = p_g1;
                            ghost_temp++;

                            rnd = new Random();

                            ghost_rand = rnd.Next(0, 3);

                            if (ghost_rand == 0)
                            {
                                move_ghost1 = "left";
                            }
                            if (ghost_rand == 1)
                            {
                                move_ghost1 = "up";
                            }
                            if (ghost_rand == 2)
                            {
                                move_ghost1 = "right";
                            }
                            if (ghost_rand == 3)
                            {
                                move_ghost1 = "down";
                            }
                            if (ghost_temp == 3)
                            {
                                move_ghost1 = "down";
                                ghost_temp = 0;
                            }

                        }
                    }
                }
            }
            if(l == "y")
            {
                foreach (Control x1 in this.Controls)
                {
                    if ((string)x1.Tag == "wall")
                    {
                        if (ghost1.Bounds.IntersectsWith(x1.Bounds))
                        {
                            y_g1 += _x;
                            p_g1.Y = y_g1;
                            ghost1.Location = p_g1;
                            ghost_temp++;

                            rnd = new Random();

                            ghost_rand = rnd.Next(0, 3);

                            if (ghost_rand == 0)
                            {
                                move_ghost1 = "left";
                            }
                            if (ghost_rand == 1)
                            {
                                move_ghost1 = "up";
                            }
                            if (ghost_rand == 2)
                            {
                                move_ghost1 = "right";
                            }
                            if (ghost_rand == 3)
                            {
                                move_ghost1 = "down";
                            }
                            if (ghost_temp == 3)
                            {
                                move_ghost1 = "down";
                                ghost_temp = 0;
                            }

                        }
                    }
                }
            }
        }
        void collision_pacmanghost() 
        {
            foreach (Control x1 in this.Controls)
            {

                if ((string)x1.Tag == "ghost")
                {
                    if (pacman.Bounds.IntersectsWith(x1.Bounds))
                        setLose = true;

                }
            }
        }
        void teleport()
        {
            if (p.X > 1150)
            {
                x = -40;
                p.X = x;
                pacman.Location = p;
            }
            if (p.X < -40)
            {
                x = 1150;
                p.X = x;
                pacman.Location = p;
            }
        }
        void teleport_ghost()
        {
            if (p_g1.X > 1150)
            {
                x_g1 = -40;
                p_g1.X = x_g1;
                ghost1.Location = p_g1;
            }
            if (p_g1.X < -40)
            {
                x_g1 = 1150;
                p_g1.X = x_g1;
                ghost1.Location = p_g1;
            }
        }
        void win()
        {
            label3.ForeColor = Color.White;
            label3.Text = "You win";
            timer1.Stop();
        }
        void lose()
        {
            label3.ForeColor = Color.Red;
            label3.Text = "You lose";
            timer1.Stop();
        }

        void AutoMove()
        {
            switch (move)
            {
                case "right":

                    moveXY(4, "x");
                    collision(-4, "x");
                    break;

                case "left":

                    moveXY(-4, "x");
                    collision(4, "x");
                    break;

                case "up":

                    moveXY(-4, "y");
                    collision(4, "y");
                    break;

                case "down":

                    moveXY(4, "y");
                    collision(-4, "y");
                    break;
            }

            teleport();
            teleport_ghost();
            collision_pacmanghost();


            switch (move_ghost1)
            {
                case "left":

                    moveXY_ghost(-5, "x");
                    collision_ghost(5, "x");
                    break;

                case "down":

                    moveXY_ghost(5, "y");
                    collision_ghost(-5, "y");
                    break;

                case "up":

                    moveXY_ghost(-5, "y");
                    collision_ghost(5, "y");
                    break;

                case "right":

                    moveXY_ghost(5, "x");
                    collision_ghost(-5, "x");
                    break;
            }

            timer1.Start();
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == (char)Keys.W)
                move = "up";

            if (e.KeyValue == (char)Keys.S)
                move = "down";
            
            if (e.KeyValue == (char)Keys.A)
                move = "left";
            
            if (e.KeyValue == (char)Keys.D)
                move = "right";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = "SCORE: " + Convert.ToString(coin_score);

            AutoMove();

            if (coin_score == 49)
                win();
            
            if(setLose == true)
                lose();
        }















        private void Game_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pacman_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox65_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox63_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox60_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
