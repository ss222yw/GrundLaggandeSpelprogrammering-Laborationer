using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game4.view
{
    class SplitterSystem
    {
        private List<SplitterParticle> splitterParticles = new List<SplitterParticle>();
        private const float NUM_PARTICLES = 100;
        private float totalTime = 0;
        private float delayTimeSeconds = 0;
        private Camera camera;
        private float MaxTime = 3.0f;


        public SplitterSystem(Viewport viewPort)
        {
            Random rand = new Random();
            delayTimeSeconds = (float)(rand.NextDouble()) * 0.1f;
            camera = new Camera(viewPort);
        }

        internal void Update(float gameTime)
        {
             totalTime += gameTime;

            if (totalTime >= delayTimeSeconds)
            {   
                totalTime = 0;

                if (splitterParticles.Count < NUM_PARTICLES)
                {
                    splitterParticles.Add(new SplitterParticle());
                }

            }

            for (int i = 0; i < splitterParticles.Count; i++)
            {
                splitterParticles[i].Update(gameTime);

                if (splitterParticles[i].IsLive())
                {
                    splitterParticles[i].rePlay();
                }
            }

        }


 



        internal void Draw(SpriteBatch spriteBatch, Texture2D m_SplitterTexture)
        {
            for (int i = 0; i < splitterParticles.Count; i++)
            {
                splitterParticles[i].Draw(spriteBatch, camera, m_SplitterTexture);
            }
        }
    }
}
    