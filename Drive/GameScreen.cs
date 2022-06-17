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
        //List<Rectangle> obsicles = new List<Rectangle>();
        
        


        // Brushes
        SolidBrush playerBrush = new SolidBrush(Color.Red);
        SolidBrush obsticleBrush = new SolidBrush(Color.Black);


        Image playerImage = Properties.Resources.carTransparent;

        int score;
        int obsticleTimer;

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


            //score 
            score = 0;
            //
            obsticleTimer = 0;

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
            scoreLable.Text = $"{score}";

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

            //check if it hits the bottom if yes get rid of it 
            if (obsticle.BottomCollision(this))
            {
                //remove enemy 

                obsticle.y = 0;


            }


            //every time the obsticle moves it increases in size 

            if (obsticleTimer % 4 == 0 && obsticle.y < 300)
            {
                obsticle.width = obsticle.width + 2;
                obsticle.height = obsticle.height + 2;
                obsticle.y += -1;
                obsticle.x += -1;

            }
            if (obsticle.y == 300)
            {
                obsticle.speed = obsticle.speed * 2;
            }





            obsticleTimer++;
            score++;
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            playerBrush.Color = player.colour;
            obsticleBrush.Color = obsticle.colour;
            e.Graphics.DrawImage(playerImage, player.x, player.y, player.width, player.height);
            e.Graphics.FillRectangle(obsticleBrush, obsticle.x, obsticle.y, obsticle.width, obsticle.height);
        }

        //highscores 
        public void loadDB()
        {
            XmlReader reader = XmlReader.Create("Resources/HighScore.xml", null);

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    string id = reader.ReadString();

                    reader.ReadToNextSibling("firstName");
                    string firstName = reader.ReadString();

                    reader.ReadToNextSibling("lastName");
                    string lastName = reader.ReadString();

                    reader.ReadToNextSibling("date");
                    string date = reader.ReadString();

                    reader.ReadToNextSibling("salary");
                    string salary = reader.ReadString();

                    Employee employee = new Employee(id, firstName, lastName, date, salary);
                    employeeDB.Add(employee);

                }
            }

            reader.Close();
        }
    }
}
