using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;

namespace EvenAndAudioPart1.Model
{
    class BallSimulation
    {
        private BallModel ballModel;
        private float width = 1.0f;
        private float height = 1.0f;
        private int Max_BALLS = 10;
        private List<BallModel> m_balls;
        private float m_mouseAreaX = 0.1f;
        private float m_mouseAreaY = 0.1f;

        public BallSimulation()
        {
            m_balls = new List<BallModel>();
            Random rand = new Random();
            for (int i = 0; i < Max_BALLS; i++)
            {
                float Xposition = (float)rand.NextDouble() * (0.7f - 0.3f) + 0.2f;
                float Yposition = (float)rand.NextDouble() * (0.8f - 0.4f) + 0.3f;
                float speedX = (float)rand.NextDouble() * (0.9f - 0.5f) + 0.1f;
                float speedY = (float)rand.NextDouble() * (0.9f - 0.1f) + 0.5f;
                ballModel = new BallModel(Xposition, Yposition, speedX, speedY);
                m_balls.Add(ballModel);
            }
        }


        internal void Update(GameTime gameTime)
        {
            float elapsedTimeSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (BallModel ball in m_balls)
            {
                if (!ball.isDead)
                {
                    ball.XPosition = ball.XPosition + ball.speedX * elapsedTimeSeconds;
                    if (ball.XPosition + ball.diameter / 2 > width)
                    {
                        ball.speedX = ball.speedX * -1.0f;
                    }

                    if (ball.XPosition - ball.diameter / 2 < 0.0f)
                    {
                        ball.speedX = ball.speedX * -1.0f;
                    }


                    ball.YPosition = ball.YPosition + ball.speedY * elapsedTimeSeconds;


                    if (ball.YPosition + ball.diameter / 2 > height)
                    {
                        ball.speedY = ball.speedY * -1.0f;
                    }

                    if (ball.YPosition - ball.diameter / 2 < 0.0f)
                    {
                        ball.speedY = ball.speedY * -1.0f;
                    }
                }
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

        internal float getMouseX()
        {
            return m_mouseAreaX;
        }

        internal float getMouseY()
        {
            return m_mouseAreaY;
        }

        internal List<BallModel> getBalls()
        {
             return m_balls;           
        }

        internal void HasMeetTheBall(Vector2 mousePosition)
        {
            foreach (BallModel ballModel in m_balls)
            {
                if ((Vector2.Distance(mousePosition, ballModel.getBallPosition()) < m_mouseAreaX) 
                    && (Vector2.Distance(mousePosition, ballModel.getBallPosition()) < m_mouseAreaY))
                {
                    ballModel.isDead = true;
                }
            }
        }

    }
}
