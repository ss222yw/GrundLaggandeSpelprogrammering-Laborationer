using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game6.view
{
    class ExplosionParticle
    {
        private Vector2 position;
        private Vector2 randomDirection;
        private Vector2 acceleration;
        private Vector2 newVelocity;
        private Vector2 newPosition;
        private Vector2 systemStartPosition;

        private static float Size = 0.02f;


        private model.Model model;

        private int seed;

        public ExplosionParticle(int seed, Vector2 systemStartPosition)
        {
            this.seed = seed;

           systemStartPosition = rePlay(seed, systemStartPosition);

        }

        private Vector2 rePlay(int seed, Vector2 systemStartPosition)
        {
            position = new Vector2();
            newVelocity = new Vector2();
            newPosition = new Vector2();

            model = new model.Model();


            this.systemStartPosition = systemStartPosition;
            position = new Vector2(systemStartPosition.X, systemStartPosition.Y);
            Random rand = new Random(seed);

            randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            randomDirection.Normalize();
            randomDirection = randomDirection * ((float)rand.NextDouble() * model.maxSpeedExpolsion);
            acceleration = new Vector2(0, 0.3f);
            return systemStartPosition;
        }

        internal void Draw(SpriteBatch m_spriteBatch, Camera camera, Texture2D m_SplitterTexture)
        {
           Rectangle destrect = camera.translatRec(position.X,position.Y,Size);

           m_spriteBatch.Draw(m_SplitterTexture, destrect,Color.Red);
        }

        internal void Update(float gameTime)
        {
                model.totalTimeExpolsion += gameTime;
            
                newVelocity.X = gameTime * acceleration.X + randomDirection.X;
                newVelocity.Y = gameTime * acceleration.Y + randomDirection.Y;

                newPosition.X = gameTime * newVelocity.X + position.X;
                newPosition.Y = gameTime * newVelocity.Y + position.Y;

                position = newPosition;
                randomDirection = newVelocity;
                if (model.totalTimeExpolsion > model.MaxTimeExpolsion)
                {
                    model.totalTimeExpolsion = 0;
                    rePlay(seed, systemStartPosition);
                }
        }

    }
}
