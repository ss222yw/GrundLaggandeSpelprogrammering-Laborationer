using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using EvenAndAudioPart1.Model;

namespace EvenAndAudioPart1.View
{
    class Explosion
    {

        private float timeElapsed = 0;
        private float maxTime = 1.0f;
        private int numberOfFrames = 24;
        private float percent;
        private int frame;
        private Vector2 position;
        private int numFramesX = 4;
        private int imgSize;

        public Explosion(Vector2 position)
        {
            this.position = position;
        }

        internal int Update(float gameTime)
        {
            timeElapsed += gameTime;

            percent = timeElapsed / maxTime;
            frame = (int)(percent * numberOfFrames);

            return frame;
        }

        internal void draw(SpriteBatch spriteBatch, Camera camera, Texture2D explosionTexture)
        {
            imgSize = explosionTexture.Width / numFramesX;

            float frameX = frame % numFramesX;
            float frameY = frame / numFramesX;

            int visualFrameX = (int)frameX * imgSize;
            int visualFrameY = (int)frameY * imgSize;

            int visualX = (int)camera.toViewX(position.X);
            int visualY = (int)camera.toViewY(position.Y);

            Rectangle destrect = new Rectangle(visualX - (imgSize / 2), visualY - (imgSize / 2), imgSize, imgSize);
            Rectangle sourceRectangle = new Rectangle(visualFrameX, visualFrameY, imgSize, imgSize);
         
            spriteBatch.Draw(explosionTexture, destrect, sourceRectangle, Color.White);
    
        }
    }
}
