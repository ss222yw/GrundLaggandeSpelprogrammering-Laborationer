using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Game5.view
{
    class Camera
    {
        private float scaleX;
        private float scaleY;
  

        public Camera(Viewport port)
        {
            scaleX = (port.Width);
            scaleY = (port.Height);
        }



        internal float toViewX(float x)
        {
            return x * scaleX;
        }

        internal float toViewY(float y)
        {
            return y * scaleY;
        }
       
    }
}
