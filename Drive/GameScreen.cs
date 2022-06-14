using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Xml;

namespace Drive
{
    public partial class GameScreen : UserControl
    {
        Boolean leftArrowDown, rightArrowDown;
        Boolean canMove;

        Player player;


        // Brushes
        SolidBrush playerBrush = new SolidBrush(Color.Red);


        Image playerImage = Properties.Resources.r34skylinejif_1rescaled;


        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;
            canMove = true;
            //int playerImage = Properties.Resources.r34skylinejif_1rescaled;
            // setup starting player values and create player object
            int playerWidth = 50;
            int playerHeight = 80;
            int playerX = 300;//((this.Width / 2) - (playerWidth / 2));
            int playerY = 550;//(this.Height - playerHeight) - 60;
            int playerSpeed = 8;
            player = new Player(playerX, playerY, playerWidth, playerHeight, playerSpeed, Color.Red);


            gameTimer.Enabled = true;

        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Escape:
                    if (gameTimer.Enabled)
                    {
                        gameTimer.Enabled = false;
                        // MenuScreen.soundList[3].Play(); //Plays pause sound
                        //pauseLabel.Visible = true;
                        //pauseLabel.Text = $"PAUSED";
                    }
                    else
                    {
                        gameTimer.Enabled = true;
                        //MenuScreen.soundList[3].Play(); //Plays pause sound
                        //pauseLabel.Visible = false;
                    }

                    break;
            }
        }

       

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    canMove = true;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    canMove = true;
                    break;
               
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "working";
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            label1.Text = "working";

            if (leftArrowDown && player.x > 100 && canMove == true)
            {
                player.Move("left");
                canMove = false;
            }
            if (rightArrowDown && player.x < 500 && canMove == true)
            {
                player.Move("right");
                canMove = false;
            }

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            playerBrush.Color = player.colour;
            e.Graphics.FillRectangle(playerBrush, player.x, player.y, player.width, player.height);
            
            
            //e.Graphics.DrawImage(playerImage, player);
        }

    }
}
