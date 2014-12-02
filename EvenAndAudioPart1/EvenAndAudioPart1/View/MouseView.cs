using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using EvenAndAudioPart1.Model;

namespace EvenAndAudioPart1.View
{
    class MouseView
    {
        private Camera m_camera;
        private MouseState previousMouseState;
        private MouseState currentMouseState;
        private BallSimulation m_ballSimulation;
        private Texture2D m_CircleTexture;

        public MouseView(Camera m_camera, ContentManager Content)
        {
            // TODO: Complete member initialization
            this.m_camera = m_camera;
            m_ballSimulation = new BallSimulation();
            m_CircleTexture = Content.Load<Texture2D>("circle");
        }

        internal bool hasClicked()
        {
            currentMouseState = Mouse.GetState();
            bool Clicked = false;

            if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                Clicked = true;
            }

            previousMouseState = currentMouseState;

            return Clicked;
        }

        internal Microsoft.Xna.Framework.Vector2 GetMousePosition()
        {
            currentMouseState = Mouse.GetState();

            float x = currentMouseState.X;
            float y = currentMouseState.Y;

            Vector2 mouseModelPos = m_camera.toModelPosition(x, y);

            return mouseModelPos;
        }

        public void DrawCircle(SpriteBatch spriteBatch)
        {

            int Circle = (int)((m_ballSimulation.getMouseX() * m_camera.getScale()) + (m_ballSimulation.getMouseY() * m_camera.getScale()));
            Rectangle circle = new Rectangle(currentMouseState.X - Circle / 2, currentMouseState.Y - Circle / 2, Circle, Circle);
            spriteBatch.Begin();
            spriteBatch.Draw(m_CircleTexture, circle, Color.White);
            spriteBatch.End();
        }

    }
}
