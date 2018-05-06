using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    struct HitRecord
    {
        public float m_t;
        public Vector3 m_point;
        public Vector3 m_normal;
    }

    class HitableList
    {
        List<Sphere> m_sphereList = new List<Sphere>();

        public void AddSphere(Sphere sphere)
        {
            m_sphereList.Add(sphere);
        }

        public bool Hit(Ray ray, out HitRecord hitRecord)
        {
            hitRecord.m_t = -1;
            hitRecord.m_point = Vector3.zero;
            hitRecord.m_normal = Vector3.zero;
            bool hit = false;
            float closest = float.MaxValue;
            foreach(var iter in m_sphereList)
            {
                float enter = 0;
                if(iter.Raycast(ray, out enter))
                {
                    if(enter < closest)
                    {
                        hit = true;
                        closest = enter;
                        hitRecord.m_t = enter;
                        hitRecord.m_point = ray.GetPoint(enter);
                        hitRecord.m_normal = hitRecord.m_point - iter.center;
                        hitRecord.m_normal.Normalize();
                    }
                }
            }
            return hit;
        }
    }
}

