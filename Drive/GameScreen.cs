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
        obsticle obsticle2;
        obsticle obsticle3;


        List<Rectangle> obsicles = new List<Rectangle>();
        
        
        


        // Brushes
        SolidBrush playerBrush = new SolidBrush(Color.Red);
        SolidBrush obsticleBrush = new SolidBrush(Color.Black);


        Image playerImage = Properties.Resources.carTransparent;
        Image enemyImage = Properties.Resources.enemyImage;

        int score;
        string highscore;
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
            int obsticalSpeed = -1;
            int obsticalX = 295;
            int obsticalX2 = 275;
            int obsticalX3 = 315;
            int obsticalY = 130;
            
  
            obsticle = new obsticle(obsticalX, obsticalY, obsticalWidth, obsticalHeight, obsticalSpeed, Color.Black);
            obsticle2 = new obsticle(obsticalX2, obsticalY, obsticalWidth, obsticalHeight, obsticalSpeed, Color.Black);
            obsticle3 = new obsticle(obsticalX3, obsticalY, obsticalWidth, obsticalHeight, obsticalSpeed, Color.Black);



            //list things 
            //obsicles.Add(obsticle);
            //obsicles.Add(obsticle2);

            //score 
            score = 0;
            
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
            obsticle2.Move();
            //obsticle3.Move();

            //check if it hits the bottom if yes get rid of it 
            if (obsticle.BottomCollision(this))
            {
                //remove enemy 

                


            }


            //every time the obsticle moves it increases in size 
            //obsticle one 
            if (obsticleTimer % 4 == 0 && obsticle.y < 300)
            {
                obsticle.width = obsticle.width + 2;
                obsticle.height = obsticle.height + 2;
                obsticle.y += -1;
                obsticle.x += -1;

            }
            if (obsticle.y == 200)
            {
                obsticle.speed = obsticle.speed * 2;
            }

            //obsticle two 
            if (obsticleTimer % 4 == 0 )
            {
                //&& obsticle.y < 300
                obsticle2.width = obsticle.width + 2;
                obsticle2.height = obsticle.height + 2;
                obsticle2.y += -1;
                obsticle2.x += -3;

            }
            if (obsticle2.y == 200)
            {
                //obsticle2.speed = obsticle.speed * 2;
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
            e.Graphics.DrawImage(enemyImage, obsticle.x, obsticle.y, obsticle.width, obsticle.height);
            e.Graphics.DrawImage(enemyImage, obsticle2.x, obsticle2.y, obsticle2.width, obsticle2.height);
            e.Graphics.DrawImage(enemyImage, obsticle3.x, obsticle3.y, obsticle3.width, obsticle3.height);
           

        }

        //highscores 
        //public void loadDB()
        //{
        //    XmlReader reader = XmlReader.Create("Resources/HighScore.xml", null);

        //    while (reader.Read())
        //    {
        //        if (reader.NodeType == XmlNodeType.Text)
        //        {
        //            string id = reader.ReadString();

        //            reader.ReadToNextSibling("firstName");
        //            string firstName = reader.ReadString();

        //            reader.ReadToNextSibling("lastName");
        //            string lastName = reader.ReadString();

        //            reader.ReadToNextSibling("date");
        //            string date = reader.ReadString();

        //            reader.ReadToNextSibling("salary");
        //            string salary = reader.ReadString();

        //            Employee employee = new Employee(id, firstName, lastName, date, salary);
        //            employeeDB.Add(employee);

        //        }
        //    }

        //    reader.Close();
        //}

        //public void saveDB()
        //{

        //    // send saved values to the xml file 

        //    XmlWriter writer = XmlWriter.Create("Resources/HighScore.xml", null);

        //    writer.WriteStartElement("Employees");

        //    foreach (highscore emp in employeeDB)
        //    {
        //        writer.WriteStartElement("Employee");
        //        writer.WriteElementString("highscore", )


        //        writer.WriteElementString("id", emp.id);
        //        writer.WriteElementString("firstName", emp.firstName);
        //        writer.WriteElementString("lastName", emp.lastName);
        //        writer.WriteElementString("date", emp.date);
        //        writer.WriteElementString("salary", emp.salary);

        //        writer.WriteEndElement();

        //    }

        //    writer.WriteEndElement();
        //    writer.Close();
        //}
    }
}
