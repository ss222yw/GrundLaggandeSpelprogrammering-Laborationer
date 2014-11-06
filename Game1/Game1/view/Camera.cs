using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game1.model;
using Microsoft.Xna.Framework;

namespace Game1.view
{
    class Camera
    {
        private const int sizeOfTile = 64;
        private const int borderSize = 64;
        private model.GameModel model;
        private float scale;
        private int levelWidth;
        private int levelHeight;
        private int width;
        private int height;


        public Camera(int levelWidth, int levelHeight)
        {
            this.model = new GameModel();
            this.levelWidth = levelWidth;
            this.levelHeight = levelHeight;
        }

        internal void RenderWhite()
        {
            float logicalX = this.model.GetLogicalX();
            float logicalY = this.model.GetLogicalY();


            float visualX = borderSize + logicalX * sizeOfTile;
            float visualY = borderSize + logicalY * sizeOfTile;

            //Resultat : uppgift 1 

            //Logisk koordinat	Visuell koordinat

            //0,0	            64, 64
            //7,0	            512, 64
            //1,7	            128, 512
            //7,7	            512, 512

        }

        

        internal void RenderBlack()
        {
            float logicalX = this.model.GetLogicalX();
            float logicalY = this.model.GetLogicalY();

            float visualX = borderSize + (7 - logicalX) * sizeOfTile;
            float visualY = borderSize + (7 - logicalY) * sizeOfTile;


            //Resultat : uppgift 2

            //Logisk koordinat	Visuell koordinat

            //0,0	            512 , 512
            //6,0	            128 , 512
            //2,7	            384 , 64
            //7,7	            64 , 64

        }

        internal void setDimensions(int width, int height)
        {
            //throw new NotImplementedException();

            this.width = width;
            this.height = height;

            int scaleX = (width - borderSize * 2) / levelWidth;
            int scaleY = (height - borderSize * 2) / levelHeight;

            scale = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }

            // resultat för uppgift 3 är 16.
        }


        public float GetScale()
        {
            return scale;
        }


    }
}
