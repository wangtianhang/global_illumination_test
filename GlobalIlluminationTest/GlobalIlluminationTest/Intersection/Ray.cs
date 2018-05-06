using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    struct Ray
    {
        Vector3 _origin;
        Vector3 _direction;

        public Ray(Vector3 origin, Vector3 direction)
        {
            _origin = origin;
            _direction = direction;
            _direction.Normalize();
        }

        public Vector3 origin 
        {
            get { return _origin; }
            set { _origin = value; }
        }

        public Vector3 direction 
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public Vector3 GetPoint(float distance)
        {
            return _origin + _direction * distance;
        }
    }
}

