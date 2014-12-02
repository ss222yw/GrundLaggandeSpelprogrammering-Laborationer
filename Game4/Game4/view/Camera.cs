using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game4.view
{
    class Camera
    {
       

        public float scale;
        private float scaleX;
        private float scaleY;
        private static int frame = 10;
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




        internal Vector2 scaleVector(float p, float p_2)
        {
            int vX = (int)(p * scale + frame);
            int vY = (int)(p_2 * scale + frame);

            return new Vector2(vX, vY);
        }

    }
    
}
