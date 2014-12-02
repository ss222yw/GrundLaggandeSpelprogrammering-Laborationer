using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EvenAndAudioPart1.Model
{
    class ParticlesModel
    {
        public float XPositionExpolsion = 0.5f;
        public float YPositionExpolsion = 0.5f;
        public float maxSpeedExpolsion = 0.1f;
        public float totalTimeExpolsion = 0;
        public float MaxTimeExpolsion = 6.0f;


        public float XPositionSmoke = 0.45f;
        public float YPositionSmoke = 0.5f;
        public float maxSpeedSmoke = 1.0f;
        public float minSizeSmoke = 0.5f;
        public float maxSizeSmoke = 1.0f;
        public float startValueSmoke = 0.5f;
        public float endValueSmoke = 0.0f;
        public float totalTimeSmoke = 0;
        public float MaxTimeSmoke = 3.0f;

        public float maxSpeed = 0.22f;
        public float minSize = 3.0f;
        public float maxSize = 6.0f;
        public float startValue = 1.0f;
        public float endValue = 0.0f;
        public float totalTime = 0;
        public float MaxTime = 3.0f;
        public float a_rotation = 0;

        public Vector2 GetPosition()
        {
            return new Vector2(XPositionSmoke, YPositionSmoke);
        }
    }
}
