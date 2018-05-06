using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    class Camera
    {
        Vector3 lower_left_corner = new Vector3(-2, -1, -1);
        Vector3 horizontal = new Vector3(4, 0, 0);
        Vector3 vertical = new Vector3(0, 2, 0);
        Vector3 origin = Vector3.zero;

        public Ray GetRay(float u, float v)
        {
            return new Ray(origin, lower_left_corner + u * horizontal + v * vertical);
        }
    }
}

