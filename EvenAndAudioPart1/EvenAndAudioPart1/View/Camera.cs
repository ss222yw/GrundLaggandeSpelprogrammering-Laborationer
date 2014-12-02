using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using EvenAndAudioPart1.Model;
using Microsoft.Xna.Framework;

namespace EvenAndAudioPart1.View
{
    class Camera
    {
        private float scale;
        private float scaleX;
        private float scaleY;   
        private static int frame = 12;
        private ParticlesModel model;


        public Camera(Viewport port)
        {
            model = new ParticlesModel();
            scaleX = (port.Width) - frame * 2;
            scaleY = (port.Height) - frame * 2;



            scale = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }
        }

        public float getScale()
        {
            return scale;
        }

        internal float toViewX(float x)
        {
            return x * scale + frame;
        }

        internal float toViewY(float y)
        {
            return y * scale + frame;
        }


        internal int getFrame()
        {
            return frame;
        }

        internal Microsoft.Xna.Framework.Rectangle translatRec(float x, float y, float z)
        {
            float vX = z * scaleX;
            float vY = z * scaleY;

            int screenX = (int)((x * scaleX) - vX);
            int screenY = (int)((y * scaleY) - vY);

            return new Microsoft.Xna.Framework.Rectangle(screenX, screenY, (int)(vX * 6f), (int)(vY * 2f));
        }
           

        internal Vector2 toModelPosition(float x, float y)
        {
            float modelX = (x - frame) / scale;
            float modelY = (y - frame) / scale;
            Vector2 modelPosition = new Vector2(modelX, modelY);

            return modelPosition;
        }
    }
}
