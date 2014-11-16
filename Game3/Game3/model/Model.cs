using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game3.model
{
    class Model
    {
        public float XPosition = 0.5f;
        public float YPosition = 0.6f;

        public float maxSpeed = 0.2f;

        internal Vector2 getStartPosition()
        {
            return new Vector2(XPosition, YPosition);
        }
    }
}
