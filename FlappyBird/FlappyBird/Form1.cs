using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 6;
        int gravity = 5;
        int score = 0;
        bool gameOver=false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed; 
           pipeUp.Left -= pipeSpeed;
            scoreText.Text = "Score : " + score;
            if(pipeBottom.Left < -50)
            {
                pipeBottom.Left = 400;
                score++;
            }
            if(pipeUp.Left < -80)
            {
                pipeUp.Left = 500;
                 
            }
            if(flappyBird.Bounds.IntersectsWith(pipeUp.Bounds) || flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds)
                || flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25)
            {
                endGame();

            }
            if(score > 20)
            {
                pipeSpeed = 8; 
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += ("  Game Over !!! Press R to retry.");
            gameOver=true;
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -5;
               

            }

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;

            }
            if(e.KeyCode ==Keys.R && gameOver == true)
            {
                RestartGame();
            }

        }

        private void RestartGame()
        {
            gameOver = false;
            flappyBird.Location = new Point(84,209);
            pipeUp.Left = 200;
            pipeBottom.Left = 400;
            score = 0;
            pipeSpeed = 6;
            scoreText.Text = "Score : " + score;
            gameTimer.Start();
        }

        private void ground_Click(object sender, EventArgs e)
        {

        }
    }
}
