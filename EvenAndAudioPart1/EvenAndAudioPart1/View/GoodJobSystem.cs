using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EvenAndAudioPart1.View
{
    class GoodJobSystem
    {
        private GoodJobParticle[] goodJobParticles;
        private const int NUM_PARTICLES = 2;



        public GoodJobSystem(Vector2 systemModelStartPosition)
        {
            goodJobParticles = new GoodJobParticle[NUM_PARTICLES];

            for (int i = 0; i < NUM_PARTICLES; i++)
            {
                goodJobParticles[i] = new GoodJobParticle(i, systemModelStartPosition);
            }
        }

        internal void Draw(SpriteBatch m_spriteBatch, Camera camera, Texture2D m_GoodJobTexture, GraphicsDevice graphicsDevice)
        {
            for (int i = 0; i < NUM_PARTICLES; i++)
            {

                goodJobParticles[i].Draw(m_spriteBatch, camera, m_GoodJobTexture, graphicsDevice);
            }
        }

        internal void Update(float gameTime)
        {


            for (int i = 0; i < NUM_PARTICLES; i++)
            {
                goodJobParticles[i].Update(gameTime);
            }


        }
    }
}
