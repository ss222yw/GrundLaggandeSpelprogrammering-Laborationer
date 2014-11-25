using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game5.view
{
    class Explosion
    {
        private float timeElapsed = 0;
        private float maxTime = 3.0f;
        private int numberOfFrames = 24;
        private float percent;
        private int frame;
      



        internal int Update(float gameTime)
        {
            timeElapsed += gameTime;

            percent = timeElapsed / maxTime;
            frame = (int)(percent * numberOfFrames);

            return frame;
        }
    }
}
