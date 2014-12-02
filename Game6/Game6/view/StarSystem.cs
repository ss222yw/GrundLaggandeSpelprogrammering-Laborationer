using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game6.view
{
    class StarSystem
    {
        private StarParticle[] starParticles;
        private const int NUM_PARTICLES = 100;



        public StarSystem(Vector2 systemModelStartPosition)
        {
            starParticles = new StarParticle[NUM_PARTICLES];

            for (int i = 0; i < NUM_PARTICLES; i++)
            {
                starParticles[i] = new StarParticle(i, systemModelStartPosition);
            }
        }

        internal void Draw(SpriteBatch m_spriteBatch, Camera camera, Texture2D m_SplitterTexture)
        {
            for (int i = 0; i < NUM_PARTICLES; i++)
            {
                starParticles[i].Draw(m_spriteBatch, camera, m_SplitterTexture);
            }
        }

        internal void Update(float gameTime)
        {

            for (int i = 0; i < NUM_PARTICLES; i++)
            {
                starParticles[i].Update(gameTime);
            }


        }
    }
}
