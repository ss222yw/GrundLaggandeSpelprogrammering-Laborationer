using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Game4.view
{
    class Camera
    {
       

        public float scale;
        private float scaleX;
        private float scaleY;
        private static int frame = 1;
        private model.Model model;

        public Camera(Viewport port)
        {
            model = new Game4.model.Model();

            scaleX = port.Width - frame * 2;
            scaleY = port.Height - frame * 2;



            scale = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }
        }

        internal Microsoft.Xna.Framework.Rectangle translatRec(float x, float y, float p_3)
        {
            float vX = p_3 * scaleX;
            float vY = p_3 * scaleY;

            int screenX = (int)((x * scaleX + model.XPosition) - vX);
            int screenY = (int)((y * scaleY + model.YPosition) - vY);

            return new Microsoft.Xna.Framework.Rectangle(screenX, screenY, (int)(vX * 1f), (int)(vY * 1f));
        }
    }
    
}
