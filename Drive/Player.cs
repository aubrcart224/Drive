using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Drive
{
    internal class Player
    {
        public int x, y, width, height, speed;
        public Color colour;

        public Player(int _x, int _y, int _width, int _height, int _speed, Color _colour)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            speed = _speed;
            //image = _image;
            colour = _colour;
        }

        public void Move(string direction)
        {
            if (direction == "left")
            {
                x = x - 180;
            }

            if (direction == "right")
            {
                x = x + 180;
            }
        }

        public bool Collision(obsticle o)
        {
            Rectangle obsticleRec = new Rectangle(o.x, o.y, o.width, o.height);
            Rectangle playerRec = new Rectangle(x, y, width, height);

            if (obsticleRec.IntersectsWith(playerRec))
            {
                GameScreen.score = 0;
                return true;
            }
            return false;


        }
        



    }
}
