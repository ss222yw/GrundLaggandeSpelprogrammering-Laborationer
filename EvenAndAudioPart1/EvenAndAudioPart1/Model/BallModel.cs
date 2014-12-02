using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EvenAndAudioPart1.Model
{
    class BallModel
    {
        public float diameter;
        public float XPosition;
        public float YPosition;
        public float speedX;
        public float speedY;
        public bool isDead;



        public BallModel(float XPosition, float YPosition, float speedX, float speedY)
        {
            this.XPosition = YPosition;
            this.YPosition = YPosition;
            this.speedX = speedX;
            this.speedY = speedY;
            diameter = 0.07f;
            isDead = false;
        }


        public Vector2 getBallPosition()
        {
            return new Vector2(XPosition, YPosition);
        }

    }
}
    