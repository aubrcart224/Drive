using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Drive
{
    internal class obsticle
    {
        public int x, y, width, height, speed;
        public Color colour;

        public obsticle(int _x, int _y, int _width, int _height, int _speed, Color _colour)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            speed = _speed;
            //image = _image;
            colour = _colour;


        }

        public void Move()
        {
            y -= speed;
        }

        public bool BottomCollision(GameScreen GS)
        {
            Boolean didCollide = false;

            if (y >= GS.Height)
            {
                //MenuScreen.soundList[5].Play(); //
                didCollide = true;
            }

            return didCollide;
        }
    }
}
