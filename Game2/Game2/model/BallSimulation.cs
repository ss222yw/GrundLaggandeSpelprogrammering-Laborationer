using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.model
{
    class BallSimulation
    {
        BallModel ballModel;
        private Viewport viewport;



        public BallSimulation(Viewport viewport)
        {
            // TODO: Complete member initialization
            this.viewport = viewport;

            ballModel = new BallModel();


        }

       
        internal void Update(GameTime gameTime)
        {
            float elapsedTimeSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            ballModel.XPosition = ballModel.XPosition + ballModel.speedX * elapsedTimeSeconds;

           // int windowsWidth = viewport.Width;
           // int windowsHeight = viewport.Height;

            if (ballModel.XPosition + ballModel.diameter/2 > 1.0f)
            {
                ballModel.speedX = ballModel.speedX * -1.0f;
            }

            if (ballModel.XPosition - ballModel.diameter/2 < 0)
            {
                ballModel.speedX = ballModel.speedX * -1.0f;
            }


            ballModel.YPosition = ballModel.YPosition + ballModel.speedY * elapsedTimeSeconds;


            if (ballModel.YPosition + ballModel.diameter / 2 > 1.0f)
            {
                ballModel.speedY = ballModel.speedY * -1.0f;
            }

            if (ballModel.YPosition - ballModel.diameter / 2 < 0)
            {
                ballModel.speedY = ballModel.speedY * -1.0f;
            }

        }


        internal float getPositionX()
        {
            return ballModel.XPosition;
        }

        internal float getPostionY()
        {
            return ballModel.YPosition;
        }

        internal float getBallDiameter()
        {
            return ballModel.diameter;
        }

     
    }
}
