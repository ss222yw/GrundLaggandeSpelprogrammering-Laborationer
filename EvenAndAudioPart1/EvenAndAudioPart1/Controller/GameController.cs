using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using EvenAndAudioPart1.View;
using Microsoft.Xna.Framework;
using EvenAndAudioPart1.Model;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace EvenAndAudioPart1.Controller
{
    class GameController
    {
        private Microsoft.Xna.Framework.Graphics.GraphicsDevice m_GraphicsDevice;
        private Microsoft.Xna.Framework.Content.ContentManager m_Content;
        private BallSimulation m_BallSimulation;
        private SoundEffect m_soundEffect;
        private BallView m_ballView;
        private MouseView m_MouseView;
        private Camera m_camera;
        private List<BallSystem> m_ballSystem;


        public GameController(Microsoft.Xna.Framework.Graphics.GraphicsDevice GraphicsDevice, Microsoft.Xna.Framework.Content.ContentManager Content, BallSimulation BallSimulation)
        {
            // TODO: Complete member initialization
            this.m_GraphicsDevice = GraphicsDevice;
            this.m_Content = Content;
            this.m_BallSimulation = BallSimulation;
            m_camera = new Camera(GraphicsDevice.Viewport);
            m_MouseView = new MouseView(m_camera, m_Content);
            m_ballView = new BallView(GraphicsDevice, m_Content);
            m_soundEffect = m_Content.Load<SoundEffect>("fire");
            this.m_ballSystem = new List<BallSystem>();
        }

        internal void Update(float gameTime)
        {
            if (m_MouseView.hasClicked())
            {
                Vector2 mousePosition = m_MouseView.GetMousePosition();
                m_ballSystem.Add(new BallSystem(mousePosition, m_Content, m_camera));
                m_soundEffect.Play();
               //MediaPlayer.Play(m_soundEffect);
                //MediaPlayer.IsRepeating = true;
                m_BallSimulation.HasMeetTheBall(mousePosition);

            }

            foreach (BallSystem ballSystem in m_ballSystem)
            {
                ballSystem.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (BallSystem ballSystem in m_ballSystem)
            {
                ballSystem.Draw(spriteBatch);
            }
            m_MouseView.DrawCircle(spriteBatch);
        }
    }
}
