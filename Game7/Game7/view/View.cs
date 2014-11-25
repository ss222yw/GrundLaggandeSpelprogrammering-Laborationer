using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Game5.view;

namespace Game7.view
{
    class View
    {
        private SpriteBatch m_spriteBatch;
        private Texture2D m_ExplosionTexture;
        private Game5.model.Model model;
        private Camera camera;
        private Vector2 size;
        private Explosion explosion;
        private int numFramesX = 4;
        private int imgSize;
        

        public View(GraphicsDevice GraphicsDevice, ContentManager Content)
        {
            
            m_spriteBatch = new SpriteBatch(GraphicsDevice);
            model = new Game5.model.Model();
            m_ExplosionTexture = Content.Load<Texture2D>("explosion");
            camera = new Camera(GraphicsDevice.Viewport);
            imgSize = m_ExplosionTexture.Width / numFramesX;
            size = new Vector2(imgSize,imgSize);
            explosion = new Explosion();
        }


        internal void draw(float gameTime)
        {
            int frame = explosion.Update(gameTime);

            float frameX = frame % numFramesX;
            float frameY = frame / numFramesX;

            int visualX = (int)frameX * imgSize;
            int visualY = (int)frameY * imgSize;

            Rectangle destrect = new Rectangle(220,80, 300, 300);
            Rectangle sourceRectangle = new Rectangle(visualX, visualY, (int)size.X, (int)size.Y);

            m_spriteBatch.Begin();
            m_spriteBatch.Draw(m_ExplosionTexture, destrect, sourceRectangle, Color.White);
            m_spriteBatch.End();
        }
    }
}
