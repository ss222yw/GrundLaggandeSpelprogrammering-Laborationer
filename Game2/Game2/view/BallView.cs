using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Game2.model;

namespace Game2.view
{
    class BallView
    {
        private SpriteBatch m_spriteBatch;
        private Texture2D m_ballTexture;
        private Camera camera;
        private int m_windowWidth;
        private int m_windowHeight;
        private Texture2D m_frameWall;
        private BallSimulation ballSimulation;
        

        public BallView(GraphicsDevice graphicsDevice, ContentManager content)
        {

            camera = new Camera(graphicsDevice.Viewport);
            ballSimulation = new BallSimulation(graphicsDevice.Viewport);
            m_windowWidth = graphicsDevice.Viewport.Width;
            m_windowHeight = graphicsDevice.Viewport.Height;
       
            m_spriteBatch = new SpriteBatch(graphicsDevice);

            m_ballTexture = content.Load<Texture2D>("Ball");

            m_frameWall = content.Load<Texture2D>("Wall");
        }

      

        internal void drawBall(BallSimulation ballSimulation)
        {
            //int visualX = (int)(ballSimulation.getPositionX() * m_windowWidth);
            //int visualY = (int)(ballSimulation.getPostionY() * m_windowHeight);
            int visualX = (int) (camera.toViewX(ballSimulation.getPositionX()));
            int visualY = (int) (camera.toViewY(ballSimulation.getPostionY()));
            int ballSize = (int)(ballSimulation.getBallDiameter() * camera.getScale());
            //int ballSize = 80;
            Rectangle destrect = new Rectangle(visualX - (ballSize / 2), visualY - ballSize / 2, ballSize, ballSize);
           
            m_spriteBatch.Begin();
            m_spriteBatch.Draw(m_ballTexture, destrect, Color.Silver);
            m_spriteBatch.End();
        }


        internal void drawFramWall()
        {
         
           //TODO:: komma på bättre sätt för att lösa detta istället för hårdkodning!!!!!!!
           // int scale = (int)camera.getScale();
            Rectangle rec = new Rectangle( -35,-35, m_windowWidth - 250, m_windowHeight + 80);
            m_spriteBatch.Begin();
            m_spriteBatch.Draw(m_frameWall, rec, Color.White);
            m_spriteBatch.End();
        }
    }
}   
