using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    struct Sphere
    {
        Vector3 _center;
        float _radius;

        public Sphere(Vector3 center, float radius)
        {
            _center = center;
            _radius = radius;
        }

        public Vector3 center
        {
            get { return _center; }
            set { _center = value; }
        }
        public float radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public bool Raycast(Ray ray, float t_min, float t_max, out HitRecord hitRecord)
        {
            /*Vector3 oc = ray.origin - _center;
            float a = Vector3.Dot(ray.direction, ray.direction);
            float b = 2.0f * Vector3.Dot(oc, ray.direction);
            float c = Vector3.Dot(oc, oc) - _radius * _radius;
            float discriminant = b * b - 4 * a * c;
            if(discriminant > 0)
            {
                float root1 = (-b + Mathf.Sqrt(discriminant)) / (2 * a);
                float root2 = (-b - Mathf.Sqrt(discriminant)) / (2 * a);
                if(root1 > 0 && root2 > 0)
                {
                    enter = Mathf.Min(root1, root2);
                    return true;
                }
                else if(root1 > 0)
                {
                    enter = root1;
                    return true;
                }
                else if(root2 > 0)
                {
                    enter = root2;
                    return true;
                }
                else
                {
                    enter = -1;
                    return false;
                }
            }
            else
            {
                enter = -1;
                return false;
            }*/
            hitRecord.m_t = -1;
            hitRecord.m_point = Vector3.zero;
            hitRecord.m_normal = Vector3.zero;
            Vector3 oc = ray.origin - _center;
            float a = Vector3.Dot(ray.direction, ray.direction);
            float b = Vector3.Dot(oc, ray.direction);
            float c = Vector3.Dot(oc, oc) - _radius * _radius;
            float discriminant = b * b - a * c;
            if(discriminant > 0)
            {
                float temp = (-b - Mathf.Sqrt(b * b - a * c)) / a;
                if(temp < t_max && temp > t_min)
                {
                    hitRecord.m_t = temp;
                    hitRecord.m_point = ray.GetPoint(temp);
                    hitRecord.m_normal = (hitRecord.m_point - _center) / _radius;
                    return true;
                }
                temp = (-b + Mathf.Sqrt(b * b - a * c)) / a;
                if (temp < t_max && temp > t_min)
                {
                    hitRecord.m_t = temp;
                    hitRecord.m_point = ray.GetPoint(temp);
                    hitRecord.m_normal = (hitRecord.m_point - _center) / _radius;
                    return true;
                }
            }
            return false;
        }
    }
}

