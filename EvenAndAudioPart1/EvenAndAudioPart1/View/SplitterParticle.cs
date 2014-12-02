using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EvenAndAudioPart1.Model;

namespace EvenAndAudioPart1.View
{
    class SplitterParticle
    {
        private Vector2 position;
        private Vector2 randomDirection;
        private Vector2 acceleration;
        private Vector2 newVelocity;
        private Vector2 newPosition;
        private float disp = 0;
        private ParticlesModel model;
        private float lifePercent;
        private float Size;
        private float fade;


        public SplitterParticle(Vector2 position)
        {
            this.position = position;
            model = new ParticlesModel();
            rePlay();
        }

        public void rePlay()
        {
            acceleration = new Vector2(0.0f, -0.4f);
            model.totalTime = 0;
            Size = 0;
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
    
            Rectangle destrect = new Rectangle(0, 0, m_SplitterTexture.Width, m_SplitterTexture.Height);


            fade = model.endValue * lifePercent + (1.0f - lifePercent) * model.startValue;

            Color color = new Color(fade, fade, fade, fade);

            int visualX = (int)camera.toViewX(position.X);
            int visualY = (int)camera.toViewY(position.Y);

            Vector2 imageCenter = new Vector2(m_SplitterTexture.Width / 2, m_SplitterTexture.Height / 2);
            Vector2 Vposition = new Vector2(visualX - Size / 2, visualY - Size / 2);

            m_spriteBatch.Draw(m_SplitterTexture, Vposition, destrect, color, model.a_rotation, imageCenter, Size, SpriteEffects.None, 0);
         
        }


        internal bool IsDead()
        {
            return model.totalTime >= model.MaxTime;
        }
    }
}
