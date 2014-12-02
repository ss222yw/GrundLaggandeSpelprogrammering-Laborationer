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
        private float disp = 0;
        private model.Model model;

        private float lifePercent;
        private float Size;
        private float fade;
        

        public SplitterParticle()
        {
            
            model = new model.Model();
            rePlay();
        }

        public void rePlay()
        {
            acceleration = new Vector2(0.1f, -1.1f);
            model.totalTime = 0;
            position = new Vector2(model.XPosition, model.YPosition);
            Random rand = new Random();

            randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            randomDirection.Normalize();

            randomDirection = randomDirection * ((float)rand.NextDouble() * model.maxSpeed);
            
        }

        internal void Update(float gameTime)
        {
                disp += 0.01f;
                model.totalTime += gameTime;
               
                lifePercent = model.totalTime / model.MaxTime;

                Size = model.minSize + lifePercent * model.maxSize;

                newVelocity = new Vector2();
                newPosition = new Vector2();

                newVelocity.X = gameTime * acceleration.X + randomDirection.X;
                newVelocity.Y = gameTime * acceleration.Y + randomDirection.Y;

                newPosition.X = gameTime * newVelocity.X + position.X;
                newPosition.Y = gameTime * newVelocity.Y + position.Y;

                position = newPosition;
                randomDirection = newVelocity;
            
        }


        internal void Draw(SpriteBatch m_spriteBatch, Camera camera, Texture2D m_SplitterTexture)
        {
            if (lifePercent > 1.0f)
            {
                lifePercent = 1.0f;
                return;
            }
            Rectangle destrect = new Rectangle(0, 0, m_SplitterTexture.Width, m_SplitterTexture.Height);


            fade = model.endValue * lifePercent + (1.0f - lifePercent) * model.startValue;

            Color color = new Color(fade, fade, fade, fade);

            
            Vector2 imageCenter = new Vector2(m_SplitterTexture.Width / 2f, m_SplitterTexture.Height / 2);

            m_spriteBatch.Begin();
            m_spriteBatch.Draw(m_SplitterTexture, camera.scaleVector(position.X, position.Y), destrect, color, model.a_rotation, imageCenter, Size, SpriteEffects.None, 0);
            m_spriteBatch.End();
        }


        internal bool IsLive()
        {
            return model.totalTime >= model.MaxTime;
        }
    }
    
}
