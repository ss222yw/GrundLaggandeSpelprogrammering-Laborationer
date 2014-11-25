using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game4.model
{
    class Model
    {
        public float XPosition = 0.5f;
        public float YPosition = 1.0f;
        public float maxSpeed = 0.22f;
        public float minSize = 0.03f;
        public float maxSize = 2.5f;
        public float startValue = 1.0f;
        public float endValue = 0.0f;
        public float totalTime = 0;
        public float MaxTime = 6.0f;
        public float a_rotation = 0;

        internal Vector2 getStartPosition()
        {
            return new Vector2(XPosition, YPosition);
        }
    }
}
