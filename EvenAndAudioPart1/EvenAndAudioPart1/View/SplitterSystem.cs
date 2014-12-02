using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace EvenAndAudioPart1.View
{
    class SplitterSystem
    {
        private List<SplitterParticle> splitterParticles = new List<SplitterParticle>();
        private const float NUM_PARTICLES = 100;
        private float totalTime = 0;
        private float delayTimeSeconds = 0;
        private Vector2 m_systemModelStartPosition;



        public SplitterSystem(Vector2 systemModelStartPosition)
        {
            this.m_systemModelStartPosition = systemModelStartPosition;
            Random rand = new Random();
            delayTimeSeconds = (float)(rand.NextDouble()) * 0.1f;
           
        }

        internal void Update(float gameTime)
        {
             totalTime += gameTime;

            if (totalTime >= delayTimeSeconds)
            {   
                totalTime = 0;

                if (splitterParticles.Count < NUM_PARTICLES)
                {
                    splitterParticles.Add(new SplitterParticle(m_systemModelStartPosition));
                }

            }

            for (int i = 0; i < splitterParticles.Count; i++)
            {
                splitterParticles[i].Update(gameTime);

                if (splitterParticles[i].IsDead())
                {
                    splitterParticles[i].rePlay();
                }
            }

        }

        internal void Draw(SpriteBatch spriteBatch, Texture2D m_SplitterTexture, Camera camera)
        {
            for (int i = 0; i < splitterParticles.Count; i++)
            {
                splitterParticles[i].Draw(spriteBatch, camera, m_SplitterTexture);
            }
        }
    }   
}

