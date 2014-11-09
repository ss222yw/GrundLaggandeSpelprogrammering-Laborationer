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
        private model.BallModel model;
        private static int frame = 1;
    

        public Camera(Viewport port)
        {
            model = new BallModel();
            scaleX = port.Width / model.LogicalX;
            scaleY = port.Height / model.LogicalY;

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

    }
}
