using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game3.view
{
    class View
    {
        private SpriteBatch m_spriteBatch;
        private Texture2D m_SplitterTexture;
        private Camera camera;
        private SplitterSystem splitterSystem;
        private model.Model model;

        public View(GraphicsDevice graphicsDevice, ContentManager content)
        {
            camera = new Camera(graphicsDevice.Viewport);
            m_spriteBatch = new SpriteBatch(graphicsDevice);
            model = new Game3.model.Model();
            splitterSystem = new SplitterSystem(model.getStartPosition());
            m_SplitterTexture = content.Load<Texture2D>("spark");

        }


        internal void draw(float gameTime)
        {
            splitterSystem.Update(gameTime);

            m_spriteBatch.Begin();
            splitterSystem.Draw(m_spriteBatch, camera, m_SplitterTexture);
            m_spriteBatch.End();
        }
    }
}
