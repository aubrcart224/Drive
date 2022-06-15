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
        obsticle obsticle;


        // Brushes
        SolidBrush playerBrush = new SolidBrush(Color.Red);
        SolidBrush obsticleBrush = new SolidBrush(Color.Black);


        Image playerImage = Properties.Resources.carTransparent;


        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;
            canMove = true;
            
            // setup starting player values and create player object
            int playerWidth = 100;
            int playerHeight = 70;
            int playerX = 240;//((this.Width / 2) - (playerWidth / 2));
            int playerY = 380;//(this.Height - playerHeight) - 60;
            int playerSpeed = 8;
            player = new Player(playerX, playerY, playerWidth, playerHeight, playerSpeed, Color.Red);

            //values of obsticles 
            int obsticalWidth = 10;
            int obsticalHeight = 10;
            int obsticalX = 300;
            int obsticalY = 150;
            int obsticalSpeed = -1;
            obsticle = new obsticle(obsticalX, obsticalY, obsticalWidth, obsticalHeight, obsticalSpeed, Color.Black);

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

        

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            label1.Text = "working";

            if (leftArrowDown && player.x > 100 && canMove == true)
            {
                player.Move("left");
                canMove = false;
            }
            if (rightArrowDown && player.x < 400 && canMove == true)
            {
                player.Move("right");
                canMove = false;
            }

            obsticle.Move();


            //every time the obsticle moves it increases in size 

            if (obsticle.y > 1 && obsticle.width < 50)
            {
                //obsticle.width = obsticle.width + 2;
                //obsticle.height = obsticle.height + 2;
                //obsticle.y += -1;
                //obsticle.x += -1;


            }

            if (obsticle.y %obsticle.y == 0)
            {
                obsticle.width = obsticle.width + 2;
                obsticle.height = obsticle.height + 2;
                obsticle.y += -1;
                obsticle.x += -1;
            }

            if (obsticle.y > 200)
            {
                //make the width and height greater by 4
                //shift x value left 2
                //shift y value up 2
            }

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            playerBrush.Color = player.colour;
            obsticleBrush.Color = obsticle.colour;
           // e.Graphics.FillRectangle(playerBrush, player.x, player.y, player.width, player.height);


            e.Graphics.DrawImage(playerImage, player.x, player.y, player.width, player.height);
            e.Graphics.FillRectangle(obsticleBrush, obsticle.x, obsticle.y, obsticle.width, obsticle.height);
        }

    }
}
