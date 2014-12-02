using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EvenAndAudioPart1.Model;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace EvenAndAudioPart1.View
{
    class BallView
    {
        private SpriteBatch m_spriteBatch;
        private Texture2D m_ballTexture;
        private Camera camera;
        private Texture2D m_frameWall;
        private int borderWidth = 1;
        private GraphicsDevice graphicsDevice;
        private ParticlesModel model;

        



        public BallView(GraphicsDevice graphicsDevice, ContentManager Content)
        {
            this.graphicsDevice = graphicsDevice;
            camera = new Camera(graphicsDevice.Viewport);
            m_spriteBatch = new SpriteBatch(graphicsDevice);
            model = new ParticlesModel();
            m_ballTexture = Content.Load<Texture2D>("Ball");
        }


        internal void drawBall(float p, float p_2, float p_3, bool p_4)
        {

            int visualX = (int)(p * camera.getScale() + camera.getFrame());
            int visualY = (int)(p_2 * camera.getScale() + camera.getFrame());
            int ballSize = (int)(p_3 * camera.getScale());

            
            Rectangle destrect = new Rectangle(visualX - (ballSize / 2), visualY - ballSize / 2, ballSize, ballSize);
            if (!p_4)
            {

                m_spriteBatch.Begin();
                m_spriteBatch.Draw(m_ballTexture, destrect, Color.White);
                m_spriteBatch.End();

            }
            else
            {
                m_spriteBatch.Begin();
                m_spriteBatch.Draw(m_ballTexture, destrect, Color.Red);
                m_spriteBatch.End();
               
            }

         
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
