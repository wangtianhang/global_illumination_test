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
                //float enter = 0;
                HitRecord hitRecordTmp = new HitRecord();
                if (iter.Raycast(ray, 0, closest, out hitRecordTmp))
                {
                    //if (hitRecordTmp.m_t < closest)
                    {
                        hit = true;
                        closest = hitRecordTmp.m_t;
                        hitRecord = hitRecordTmp;
                    }
                }
            }
            return hit;
        }
    }
}

