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
using System.Collections.Generic;

namespace Drive
{
    public partial class GameScreen : UserControl
    {
        Boolean leftArrowDown, rightArrowDown;
        Boolean canMove;

        //objects 
        Player player;
        //obsticle obsticle;
        //obsticle obsticle2;
        //obsticle obsticle3;


        // setup starting player values and create player object
        int playerWidth = 100;
        int playerHeight = 70;
        int playerX = 240;
        int playerY = 380;
        int playerSpeed = 8;


        //values of obsticles 
            //int obsticalWidth = 10;
            //int obsticalHeight = 10;
            //int obsticalSpeed = -1;
            //int obsticalX = 295;
            //int obsticalX2 = 275;
            //int obsticalX3 = 315;
            //int obsticalY = 130;
            //int obsticalY2 = 130;
            //int obsticalY3 = 130;

        List<obsticle> obsicles = new List<obsticle>();
        
        List<int> highscores = new List<int>(new int[] {0,1,2});

        //random gen 
        Random randGen = new Random();
        public static int position;


        // Brushes
        SolidBrush playerBrush = new SolidBrush(Color.Red);
        SolidBrush obsticleBrush = new SolidBrush(Color.Black);


        Image playerImage = Properties.Resources.carTransparent;
        Image enemyImage = Properties.Resources.enemyImage;

        public static int score;
        // int highscore; 
        int obsticleTimer;

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }
        public void OnStart()
        {

            //set vlaues to zero 
            
            obsticleTimer = 0;

            //reset score lable and score 
            scoreLable.Text = "";
            score = 0;

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;
            canMove = true;

            //set player 
            player = new Player(playerX, playerY, playerWidth, playerHeight, playerSpeed, Color.Red);

            //start game 
            gameTimer.Enabled = true;

            //clear lists 
            obsicles.Clear();

        }
        private void GameScreen_Load(object sender, EventArgs e)
        {

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;
            canMove = true;
            
            
            

            
            
  
            //obsticle = new obsticle(obsticalX, obsticalY, obsticalWidth, obsticalHeight, obsticalSpeed, Color.Black);
            //obsticle2 = new obsticle(obsticalX2, obsticalY2, obsticalWidth, obsticalHeight, obsticalSpeed, Color.Black);
            //obsticle3 = new obsticle(obsticalX3, obsticalY3, obsticalWidth, obsticalHeight, obsticalSpeed, Color.Black);



            //list things 
            //obsicles.Add(obsticle);
            //obsicles.Add(obsticle2);
            //obsicles.Add(obsticle3);

            

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

            //choose a random position to spawn a car if a car is not within a certain radius to each other 

            if (obsticleTimer % 100 == 0)
            {
                position = randGen.Next(0, 2);
                if (position == 0)
                {

                    int obsticalWidth = 10;
                    int obsticalHeight = 10;
                    int obsticalSpeed = -1;
                    int obsticalX = 295;
                    int obsticalY = 130;

                    
                    obsticle obsticle1 = new obsticle(10, 10, -1, 295, 130);
                    obsicles.Add(obsticle1);
                    //obsicles[0] = new obsticle(obsticalWidth, obsticalHeight, obsticalSpeed, obsticalX, obsticalY);
                    //obsicles.Add(new obsticle(obsticalWidth, obsticalHeight, obsticalSpeed, obsticalX, obsticalY));
                    
                    foreach (var obsticle in obsicles)
                    {
                        if (obsticle1.y == obsticalHeight)
                        obsticle1.y += 3;
                    }

                    ////obsicles.Add(new obsticle(o.x, o.y, Height, Width))
                    ////blocks.Add(new Block(this.Width - x, y, height, length));
                    ////obsticle obsticle;
                    ////obsticle obsticle2;
                    //obsicles.Add(new obsticle(x, y,width,height, speed,Color));
                    //obsicles.Add(obsticle);
                }
                if (position == 1)
                {
                    int obstical2Width = 10;
                    int obstical2Height = 10;
                    int obstical2Speed = -1;
                    int obstical2X = 295;
                    int obstical2Y = 130;

                    obsticle obsticle2 = new obsticle(10, 10, -1, 275, 130);
                    obsicles.Add(obsticle2);

                    //obsicles[1] = new obsticle(obstical2Width, obstical2Height, obstical2Speed, obstical2X, obstical2Y);
                    //obsicles.Add(new obsticle(obstical2Width, obstical2Height, obstical2Speed, obstical2X, obstical2Y));

                    //obsticle obsticle2;
                    //obsticle2 = new obsticle(obsticalX2, obsticalY2, obsticalWidth, obsticalHeight, obsticalSpeed, Color.Black);
                    //obsicles.Add(obsticle2);
                }
                if (position == 2)
                {
                    
                    int obstical3Width = 10;
                    int obstical3Height = 10;
                    int obstical3Speed = -1;
                    int obstical3X = 295;
                    int obstical3Y = 130;


                    obsticle obsticle3 = new obsticle(10, 10, -1, 315, 130);

                    obsicles.Add(obsticle3);

                    //obsicles[3] = new obsticle(obstical3X, obstical3Height, obstical3Speed, obstical3X, obstical3Y);
                    //obsicles.Add(new obsticle(obstical3Width, obstical3Height, obstical3Speed, obstical3X, obstical3Y));
                    //obsticle obsticle3;
                    //obsticle3 = new obsticle(obsticalX3, obsticalY3, obsticalWidth, obsticalHeight, obsticalSpeed, Color.Black);
                    //obsicles.Add(obsticle3);

                }
            }


            foreach(obsticle o in obsicles)
            {
                //obsicles[1].Move();
                o.Move();

            }

            //obsticle2.Move();
            //obsticle3.Move();

            //check if it hits the bottom if yes get rid of it 
            //obsicles.Remove(obsticle(i));
            foreach (obsticle o in obsicles)
            {
                if (o.y > 550)
                {

                    obsicles.Remove(o);

                    break;
                }
            }


            foreach (obsticle o in obsicles)
            {
                //if (o.Collision(player))
                {

                   // score = 0;

                }
            }


            




            //every time the obsticle moves it increases in size changes position and chnages its speed to keep it consistant as the pixel count increases
            //obsticle one 
            
                if (obsticleTimer % 4 == 0)
                {

                    foreach (var o in obsicles.Where(x => x.obsticle1 == "obsticalWidth"))
                    {
                        o.width = +100;

                    }



                    o.width = o.width + 2;
                    o.height = o.height + 2;
                    o.y += 3;
                    o.x += -1;
                    //obsticle obsticle3
                    //obsticle1.wdith +=2

                    //obsicles[0].width = o.width + 2;
                    //obsicles[0].height = o.height + 2;
                    //obsicles[0].y += 3;
                    //obsicles[0].x += -1;

                    //obsticle.width = obsticle.width + 2;
                    //obsticle.height = obsticle.height + 2;
                    //obsticle.y += 3;
                    //obsticle.x += -1;

                }

                //obsticle two 
                if (obsticleTimer % 4 == 0)
                {
                    o.width = o.width + 2;
                    o.height = o.height + 2;
                    o.y += 3;
                    o.x += -3;
                    //obsicles[1].width = o.width + 2;
                    //obsicles[1].height = o.height + 2;
                    //obsicles[1].y += 3;
                    //obsicles[1].x += -1;
                    //obsticle2.width = obsticle2.width + 2;
                    //obsticle2.height = obsticle2.height + 2;
                    //obsticle2.y += 3;
                    //obsticle2.x += -3;

                }
                if (o.y > 200 && obsticleTimer % 1 == 0)
                {
                    o.x += -1;
                }

                //obsticle 3
                if (obsticleTimer % 4 == 0)
                {
                    o.width = o.width + 2;
                    o.height = o.height + 2;
                    o.y += 3;
                    o.x += 1;
                    //obsicles[2].width = o.width + 2;
                    //obsicles[2].height = o.height + 2;
                    //obsicles[2].y += 3;
                    //obsicles[2].x += -1;
                    //obsticle3.width = obsticle3.width + 2;
                    //obsticle3.height = obsticle3.height + 2;
                    //obsticle3.y += 3;
                    //obsticle3.x += 1;
                }

                if (o.y > 200 && obsticleTimer % 1 == 0)
                {
                    o.x += 1;
                }
            

            obsticleTimer++;
            score++;
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //playerBrush.Color = player.colour;
            //obsticleBrush.Color = obsticle.colour;
            
            //draw player  
            e.Graphics.DrawImage(playerImage, player.x, player.y, player.width, player.height);


            foreach (obsticle o in obsicles)
            {
                e.Graphics.DrawImage(enemyImage, o.x, o.y, o.width, o.height);
            }
            //e.Graphics.DrawImage(enemyImage, obsticle.x, obsticle.y, obsticle.width, obsticle.height);
            //e.Graphics.DrawImage(enemyImage, obsticle2.x, obsticle2.y, obsticle2.width, obsticle2.height);
            //e.Graphics.DrawImage(enemyImage, obsticle3.x, obsticle3.y, obsticle3.width, obsticle3.height);


        }

        //highscores 
        public void loadDB()
        {
            XmlReader reader = XmlReader.Create("Resources/HighScore.xml", null);



            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {

                    string name = reader.ReadString();

                    reader.ReadToNextSibling("HighScore");
                    string highscore = reader.ReadString();

                    //highScoreLabel.Text = $"{highscore}";
                    //nameLabel.Text = $"{name}:";

                }
                reader.Close();
            }
        }

        //public void saveDB()
        //{

        //    send saved values to the xml file

        //   XmlWriter writer = XmlWriter.Create("Resources/HighScore.xml", null);

        //    writer.WriteStartElement("HighScore");

        //    foreach (highscore Hs in highscores)
        //    {
        //        writer.WriteStartElement("Employee");
        //        writer.WriteElementString("highscore", );


        //        writer.WriteElementString("id", emp.id);
        //        writer.WriteElementString("firstName", emp.firstName);
        //        writer.WriteElementString("lastName", emp.lastName);
        //        writer.WriteElementString("date", emp.date);
        //        writer.WriteElementString("salary", emp.salary);

        //        writer.WriteElementString(highscores));

        //        writer.WriteElementString("HighScore", Convert.ToString(score));

        //        writer.WriteEndElement();

        //    }

        //    writer.WriteEndElement();
        //    writer.Close();
        }
    }

