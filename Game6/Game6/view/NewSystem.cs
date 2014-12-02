using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game6.view
{
    class NewSystem
    {
        private NewParticle[] newParticles;
        private const int NUM_PARTICLES = 100;



        public NewSystem(Vector2 systemModelStartPosition)
        {
            newParticles = new NewParticle[NUM_PARTICLES];

            for (int i = 0; i < NUM_PARTICLES; i++)
            {
                newParticles[i] = new NewParticle(i, systemModelStartPosition);
            }
        }

        internal void Draw(SpriteBatch m_spriteBatch, Camera camera, Texture2D m_SplitterTexture)
        {
            for (int i = 0; i < NUM_PARTICLES; i++)
            {
                newParticles[i].Draw(m_spriteBatch, camera, m_SplitterTexture);
            }
        }

        internal void Update(float gameTime)
        {

            for (int i = 0; i < NUM_PARTICLES; i++)
            {
                newParticles[i].Update(gameTime);
            }


        }
    
    }
}
