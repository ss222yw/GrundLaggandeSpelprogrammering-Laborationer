using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using EvenAndAudioPart1.Model;

namespace EvenAndAudioPart1.View
{
    class BallSystem
    {
        private Microsoft.Xna.Framework.Vector2 m_mousePosition;
        private Microsoft.Xna.Framework.Content.ContentManager m_Content;
        private Camera m_camera;
        private Texture2D m_SplitterTexture;
        private Texture2D m_SmokeTexture;
        private Texture2D m_ExplosionTexture;
        private SplitterSystem splitterSystem;
        private Explosion explosion;
        private ExplosionSystem explosionSystem;
        private ParticlesModel model;
        private BallSimulation ballSimulation;
        private Texture2D m_GoodJobTexture;
        private GoodJobSystem m_GoodJobSystem;
        private List<BallModel> balls;

        public BallSystem(Microsoft.Xna.Framework.Vector2 mousePosition, Microsoft.Xna.Framework.Content.ContentManager Content, Camera m_camera)
        {
            this.m_mousePosition = mousePosition;
            this.m_Content = Content;
            this.m_camera = m_camera;
            model = new ParticlesModel();
            ballSimulation = new BallSimulation();
            splitterSystem = new SplitterSystem(m_mousePosition);
            explosion = new Explosion(m_mousePosition);
            explosionSystem = new ExplosionSystem(m_mousePosition);
            m_GoodJobSystem = new GoodJobSystem(m_mousePosition);
            balls = new List<BallModel>();
       
            m_SplitterTexture = Content.Load<Texture2D>("particlesmoke");
            m_SmokeTexture = Content.Load<Texture2D>("explosion");
            m_ExplosionTexture = Content.Load<Texture2D>("spark");
            m_GoodJobTexture = Content.Load<Texture2D>("circle");  
        }

        internal void Update(float gameTime)
        {

            splitterSystem.Update(gameTime);
            explosion.Update(gameTime);
            explosionSystem.Update(gameTime);
            m_GoodJobSystem.Update(gameTime);
        }

        internal void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
   
            spriteBatch.Begin();
            splitterSystem.Draw(spriteBatch, m_SplitterTexture, m_camera);
            explosion.draw(spriteBatch, m_camera, m_SmokeTexture);
            explosionSystem.Draw(spriteBatch, m_camera, m_ExplosionTexture);
            m_GoodJobSystem.Draw(spriteBatch, m_camera, m_GoodJobTexture, spriteBatch.GraphicsDevice);
            spriteBatch.End();
       
        }

    }
}
