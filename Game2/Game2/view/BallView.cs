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
        private Texture2D m_frameWall;
        private BallSimulation ballSimulation;
        private int borderWidth = 1;
 
        

        public BallView(GraphicsDevice graphicsDevice, ContentManager content)
        {
            camera = new Camera(graphicsDevice.Viewport);
            ballSimulation = new BallSimulation();
            m_spriteBatch = new SpriteBatch(graphicsDevice);
            m_ballTexture = content.Load<Texture2D>("Ball");
            
        }

        internal void drawParticle()
        {
            
        }

      

        internal void drawBall(BallSimulation ballSimulation)
        {

            int visualX = (int) (camera.toViewX(ballSimulation.getPositionX()));
            int visualY = (int) (camera.toViewY(ballSimulation.getPostionY()));
            int ballSize = (int)(ballSimulation.getBallDiameter() * camera.getScale());


            Rectangle destrect = new Rectangle(visualX - (ballSize / 2), visualY - ballSize / 2, ballSize, ballSize);


            m_spriteBatch.Begin();
            m_spriteBatch.Draw(m_ballTexture, destrect, Color.Silver);
            m_spriteBatch.End();



        }


        internal void drawFramWall(GraphicsDevice graphicsDevice)
        {
         
            int scale = (int)camera.getScale();
            var borderColor = Color.White;
            int Frame = camera.getFrame();

            m_frameWall = new Texture2D(graphicsDevice, 1, 1);
            m_frameWall.SetData(new Color[] { borderColor });


            Rectangle recTop = new Rectangle(Frame, Frame, scale, borderWidth);
            Rectangle recRight = new Rectangle(Frame + scale, Frame, borderWidth, scale);
            Rectangle recLeft = new Rectangle(Frame, Frame, borderWidth, scale);
            Rectangle recBottom = new Rectangle(Frame, scale + Frame, scale, borderWidth);

            m_spriteBatch.Begin();
            m_spriteBatch.Draw(m_frameWall, recTop, borderColor);
            m_spriteBatch.Draw(m_frameWall, recRight, borderColor);
            m_spriteBatch.Draw(m_frameWall, recLeft, borderColor);
            m_spriteBatch.Draw(m_frameWall, recBottom, borderColor);
            m_spriteBatch.End();  
            
        }

    }
}   
