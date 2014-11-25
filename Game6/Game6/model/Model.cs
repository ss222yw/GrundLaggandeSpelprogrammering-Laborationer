using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game6.model
{
    class Model
    {
        public float XPositionExpolsion = 0.51f;
        public float YPositionExpolsion = 0.5f;
        public float maxSpeedExpolsion = 0.1f;
        public float totalTimeExpolsion = 0;
        public float MaxTimeExpolsion = 6.0f;

        public float XPositionSmoke = 0.5f;
        public float YPositionSmoke = 0.5f;
        public float maxSpeedSmoke = 1.0f;
        public float minSizeSmoke = 2.5f;
        public float maxSizeSmoke = 3.0f;
        public float startValueSmoke = 0.5f;
        public float endValueSmoke = 0.0f;
        public float totalTimeSmoke = 0;
        public float MaxTimeSmoke = 6.0f;

        public float XPosition = 0.5f;
        public float YPosition = 0.52f;
        public float maxSpeed = 0.2f;
        public float minSize = 0.03f;
        public float maxSize = 1.0f;
        public float startValue = 0.5f;
        public float endValue = 0.0f;
        public float totalTime = 0;
        public float MaxTime = 6.0f;

        public int numFramesX = 4;
        public int imgSize;
        public int frame;
        public float timeElapsed;
        public float maxTime = 1.0f;
        public int numberOfFrames = 24;
        public float percent;
        public float XPositionFire = 250.0f;
        public float YPositionFire = 60.0f;

        internal Vector2 getStartPosition()
        {
            return new Vector2(XPosition, YPosition);
        }

        internal Vector2 getStartPositionExplosion()
        {
            return new Vector2(XPositionExpolsion, YPositionExpolsion);
        }

        internal Vector2 getStartPositionSmoke()
        {
            return new Vector2(XPositionSmoke, YPositionSmoke);
        }
    }
}
