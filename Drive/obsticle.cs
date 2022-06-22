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
        internal string obsticle1;

        public obsticle(int _x, int _y, int _width, int _height, int _speed)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            speed = _speed;
            
            


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
