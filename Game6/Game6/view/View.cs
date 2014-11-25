using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game6.view
{
    class View
    {
        private SpriteBatch m_spriteBatch;
        private Texture2D m_SplitterTexture;
        private Texture2D m_SmokeTexture;
        private Texture2D m_ExplosionTexture;
        private SplitterSystem splitterSystem;
        private SmokeSystem smokeSystem;
        private ExplosionSystem explosionSystem;
        private model.Model model;
        private Texture2D m_fireTexture;
        private Camera camera;
        private Vector2 size;
     


        public View(Microsoft.Xna.Framework.Graphics.GraphicsDevice GraphicsDevice, Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            camera = new Camera(GraphicsDevice.Viewport);
            m_spriteBatch = new SpriteBatch(GraphicsDevice);
            model = new Game6.model.Model();
            splitterSystem = new SplitterSystem(model.getStartPosition());
            smokeSystem = new SmokeSystem(model.getStartPositionSmoke());
            explosionSystem = new ExplosionSystem(model.getStartPositionExplosion());
            model.timeElapsed = 0;
            m_fireTexture = Content.Load<Texture2D>("explosion2");
            model.imgSize = m_fireTexture.Width / model.numFramesX;
            size = new Vector2(model.imgSize, model.imgSize);

            m_SplitterTexture = Content.Load<Texture2D>("particlesmoke");
            m_SmokeTexture = Content.Load<Texture2D>("particlesmoke");
            m_ExplosionTexture = Content.Load<Texture2D>("spark");
            
        }


        internal void draw(float gameTime, GraphicsDevice graphicsDevice)
        {
            splitterSystem.Update(gameTime);
            smokeSystem.Update(gameTime);
            explosionSystem.Update(gameTime);
            Update(gameTime);

            int visualX;
            int visualY;
            rePlay(out visualX, out visualY);
            int x = (int)model.XPositionFire;
            int y = (int)model.YPositionFire;
            Rectangle destrect = new Rectangle(x, y, 300, 300);
            Rectangle sourceRectangle = new Rectangle(visualX, visualY, (int)size.X, (int)size.Y);
           
            m_spriteBatch.Begin();
            splitterSystem.Draw(m_spriteBatch, camera, m_SplitterTexture);
            smokeSystem.Draw(m_spriteBatch, camera, m_SmokeTexture, graphicsDevice);
            explosionSystem.Draw(m_spriteBatch, camera, m_ExplosionTexture);
            m_spriteBatch.Draw(m_fireTexture, destrect, sourceRectangle, Color.White);
            m_spriteBatch.End();
        }

        private void rePlay(out int visualX, out int visualY)
        {
            float frameX = model.frame % model.numFramesX;
            float frameY = model.frame / model.numFramesX;

            visualX = (int)frameX * model.imgSize;
            visualY = (int)frameY * model.imgSize;
        }

        internal int Update(float gameTime)
        {
            model.timeElapsed += gameTime;




            model.percent = model.timeElapsed / model.maxTime;
            model.frame = (int)(model.percent * model.numberOfFrames);
            if (model.timeElapsed > model.MaxTimeSmoke)
            {
                model.timeElapsed = 0;
                int visualX;
                int visualY;
                rePlay(out visualX, out visualY);

            }
            return model.frame;
        }
    }
}
