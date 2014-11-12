using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Game2.model;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.view
{
    class Camera
    {
     
        private float scale;
        private float scaleX;
        private float scaleY;
        private static int frame = 12;

    

        public Camera(Viewport port)
        {
            scaleX = port.Width - frame * 2;
            scaleY = port.Height - frame * 2;

           

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
    }
}
