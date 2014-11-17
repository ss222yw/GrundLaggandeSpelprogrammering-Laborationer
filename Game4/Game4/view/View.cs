using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Game4.view
{
    class View
    {
        private SpriteBatch m_spriteBatch;
        private Texture2D m_SplitterTexture;
        private Camera camera;
        private SplitterSystem splitterSystem;
        private model.Model model;

        public View(Microsoft.Xna.Framework.Graphics.GraphicsDevice GraphicsDevice, Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            camera = new Camera(GraphicsDevice.Viewport);
            m_spriteBatch = new SpriteBatch(GraphicsDevice);
            model = new Game4.model.Model();
            splitterSystem = new SplitterSystem(model.getStartPosition());

            m_SplitterTexture = Content.Load<Texture2D>("particlesmoke");
        }

        //,GraphicsDevice graphicsDevice
        internal void draw(float gameTime)
        {
            splitterSystem.Update(gameTime);
            //, graphicsDevice
            m_spriteBatch.Begin();
            splitterSystem.Draw(m_spriteBatch, camera, m_SplitterTexture);
            m_spriteBatch.End();
        }
    }
}
