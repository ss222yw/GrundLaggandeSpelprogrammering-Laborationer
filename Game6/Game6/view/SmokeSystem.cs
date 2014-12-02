using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game6.view
{
    class SmokeSystem
    {
        private SmokeParticles[] splitterParticles;
        private const int NUM_PARTICLES = 1;



        public SmokeSystem(Vector2 systemModelStartPosition)
        {
            splitterParticles = new SmokeParticles[NUM_PARTICLES];

            for (int i = 0; i < NUM_PARTICLES; i++)
            {
                splitterParticles[i] = new SmokeParticles(i, systemModelStartPosition);
            }
        }

        internal void Draw(SpriteBatch m_spriteBatch, Camera camera, Texture2D m_SmokeTexture,GraphicsDevice graphicsDevice)
        {
            for (int i = 0; i < NUM_PARTICLES; i++)
            {

                splitterParticles[i].Draw(m_spriteBatch, camera, m_SmokeTexture, graphicsDevice);
            }
        }

        internal void Update(float gameTime)
        {


            for (int i = 0; i < NUM_PARTICLES; i++)
            {
                splitterParticles[i].Update(gameTime);
            }


        }
    }
}
