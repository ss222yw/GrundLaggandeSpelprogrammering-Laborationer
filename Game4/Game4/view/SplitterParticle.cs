using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game4.view
{
    class SplitterParticle
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
        

        public SplitterParticle(int seed, Vector2 systemStartPosition)
        {
            this.seed = seed;

           systemStartPosition = rePlay(seed, systemStartPosition);

        }

        private Vector2 rePlay(int seed, Vector2 systemStartPosition)
        {

            newVelocity = new Vector2();
            newPosition = new Vector2();
            model = new model.Model();
            model.totalTime = 0;
            this.systemStartPosition = systemStartPosition;
            position = new Vector2(systemStartPosition.X, systemStartPosition.Y);

            Random rand = new Random(seed);

            randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            randomDirection.Normalize();

            randomDirection = randomDirection * ((float)rand.NextDouble() * model.maxSpeed);
            acceleration = new Vector2(0.3f, -1.0f);

            delayTimeSeconds = (float)(rand.NextDouble()) * model.MaxTime;

            return systemStartPosition;
        }

        internal void Update(float gameTime)
        {
            
            model.totalTime += gameTime;


            if (isAlive())
            {
                lifePercent = getTimeLivedSeconds() / model.MaxTime;
                Size = model.minSize + lifePercent * model.maxSize;
              
                newVelocity.X = gameTime * acceleration.X + randomDirection.X;
                newVelocity.Y = gameTime * acceleration.Y + randomDirection.Y;

                newPosition.X = gameTime * newVelocity.X + position.X;
                newPosition.Y = gameTime * newVelocity.Y + position.Y;

                position = newPosition;
                randomDirection = newVelocity;

                if (model.totalTime > model.MaxTime)
                {
                    model.totalTime = 0;
                    rePlay(seed, systemStartPosition);
                }

            }
        }


        internal void Draw(SpriteBatch m_spriteBatch, Camera camera, Texture2D m_SplitterTexture)
        {
            //,Viewport port
            if (isAlive())
            {
                  Rectangle destrect = camera.translatRec(position.X, position.Y, Size);

               // Rectangle destrect = new Rectangle(0, 0, m_SplitterTexture.Width, m_SplitterTexture.Height);
               // t = getTimeLivedSeconds() / model.MaxTime;



                fade = model.endValue * lifePercent + (1.0f - lifePercent) * model.startValue;

                Color color = new Color(fade, fade, fade, fade);


               // Vector2 screenCenter = camera.scaleSmokeVector(position.X, position.Y);
               // Vector2 imageCenter = new Vector2(m_SplitterTexture.Width / 2f, m_SplitterTexture.Height / 2);

               // m_spriteBatch.Draw(m_SplitterTexture, screenCenter, destrect, color, model.a_rotation, imageCenter, Size, SpriteEffects.None, 0);
                m_spriteBatch.Draw(m_SplitterTexture, destrect, color);
            }
        }


        
        private float getTimeLivedSeconds()
        {
            if (isAlive())
            {
                return model.totalTime - delayTimeSeconds;
            }
            else
            {
                return 0;
            }
        }


        private bool isAlive()
        {
            return model.totalTime > delayTimeSeconds;
        }


    }
    
}
