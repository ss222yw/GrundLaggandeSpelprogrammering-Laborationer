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
        public float maxSpeed = 0.15f;
        public float minSize = 0.02f;
        public float maxSize = 0.1f;
        public float startValue = 1.0f;
        public float endValue = 0.0f;
        public float totalTime = 0;
        public float MaxTime = 10.0f;

        internal Vector2 getStartPosition()
        {
            return new Vector2(XPosition, YPosition);
        }
    }
}
