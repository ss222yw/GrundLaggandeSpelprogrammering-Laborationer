using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game6.view
{
    class SmokeParticles
    {

        private Vector2 position;
        private Vector2 randomDirection;
        private Vector2 acceleration;
        private Vector2 newVelocity;
        private Vector2 newPosition;
        private Vector2 systemStartPosition;

        private model.Model model;

        private float delayTimeSeconds;
        private float lifePercent;
        private float Size;
        private float fade;
        private int seed;

        public SmokeParticles(int seed, Vector2 systemStartPosition)
        {
            this.seed = seed;

            systemStartPosition = rePlay(seed, systemStartPosition);

        }

        private Vector2 rePlay(int seed, Vector2 systemStartPosition)
        {
            newVelocity = new Vector2();
            newPosition = new Vector2();
            model = new model.Model();
            this.systemStartPosition = systemStartPosition;
            position = new Vector2(systemStartPosition.X, systemStartPosition.Y);

            Random rand = new Random(seed);

            randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            randomDirection.Normalize();

            randomDirection = randomDirection * ((float)rand.NextDouble() * model.maxSpeedSmoke);
            acceleration = new Vector2(0, 0);

            delayTimeSeconds = (float)(rand.NextDouble()) * model.MaxTimeSmoke;

            return systemStartPosition;
        }

        internal void Update(float gameTime)
        {
            model.totalTimeSmoke += gameTime;


            if (isAlive())
            {
                lifePercent = getTimeLivedSeconds() / model.MaxTimeSmoke;
                Size = model.minSizeSmoke + lifePercent * model.maxSizeSmoke;

                newVelocity.X = gameTime * acceleration.X + randomDirection.X;
                newVelocity.Y = gameTime * acceleration.Y + randomDirection.Y;

                newPosition.X = gameTime * newVelocity.X + position.X;
                newPosition.Y = gameTime * newVelocity.Y + position.Y;

                position = newPosition;
                randomDirection = newVelocity;

                if (model.totalTimeSmoke > model.MaxTimeSmoke)
                {
                    model.totalTimeSmoke = 0;
                    rePlay(seed, systemStartPosition);
                }

            }
        }


        internal void Draw(SpriteBatch m_spriteBatch, Camera camera, Texture2D m_SmokeTexture, GraphicsDevice graphicsDevice)
        {
           
            if (isAlive())
            {

                  fade = model.endValueSmoke * lifePercent + (1.0f - lifePercent) * model.startValueSmoke;
 
                  Color color = new Color(fade, fade, fade, fade);
                  Rectangle r = new Rectangle(0, 0, m_SmokeTexture.Width, m_SmokeTexture.Height);
  
                  Vector2 screenCenter = new Vector2(graphicsDevice.Viewport.Width / 2f, graphicsDevice.Viewport.Height / 2f);
                  Vector2 imageCenter = new Vector2(m_SmokeTexture.Width / 2f, m_SmokeTexture.Height / 2f);

                  m_spriteBatch.Draw(m_SmokeTexture, screenCenter,r , color, -5, imageCenter, Size, SpriteEffects.None, 0);
           
            }
        }



        private float getTimeLivedSeconds()
        {
            if (isAlive())
            {
                return model.totalTimeSmoke - delayTimeSeconds;
            }
            else
            {
                return 0;
            }
        }


        private bool isAlive()
        {
            return model.totalTimeSmoke > delayTimeSeconds;
        }
    }
    
}
