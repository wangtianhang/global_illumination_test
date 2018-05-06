using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Drawing;
using Common;

/// <summary>
/// 数学库底层为左手坐标系 camera坐标系为右手坐标系
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        int nx = 200;
        int ny = 100;
        int ns = 100;
        //此数组位于第一象限
        Color[] data = new Color[nx * ny];

        HitableList world = new HitableList();
        world.AddSphere(new Sphere(new Vector3(0, 0, -1), 0.5f));
        world.AddSphere(new Sphere(new Vector3(0, -100.5f, -1), 100f));

        Camera cam = new Camera();

        for (int j = ny - 1; j >= 0; j-- )
        {
            for (int i = 0; i < nx; ++i )
            {

                Color color = Color.clear;

                for(int s = 0; s < ns; s++)
                {
                    float u = (i + Common.Random.Range(0f, 1f)) / (float)nx;
                    float v = (j + Common.Random.Range(0f, 1f)) / (float)ny;
                    Ray ray = cam.GetRay(u, v);
                    color += GetColor(ray, world);
                }

                color /= (float)ns;

                //color.r = Mathf.Sqrt(color.r);
                //color.g = Mathf.Sqrt(color.g);
                //color.b = Mathf.Sqrt(color.b);

                int index = j * nx + i;
                data[index] = color;
            }
        }

        DrawHelper.DrawData("test" + DrawHelper.GetTime() +  ".bmp", nx, ny, data, "by wth");

        Console.WriteLine("end");
        Console.ReadLine();
    }

    static Vector3 RandomInUnitSphere()
    {
        Vector3 p = Vector3.zero;
        do
        {
            p = 2.0f * new Vector3(Common.Random.Range(0f, 1f), Common.Random.Range(0f, 1f), Common.Random.Range(0f, 1f)) - Vector3.one;
        }
        while (Vector3.Dot(p, p) >= 1.0f);
        return p;
    }

    static Color GetColor(Ray ray, HitableList world)
    {
        //Sphere sphere = new Sphere(new Vector3(0, 0, -1), 0.5f);
        //float enter = 0;
        HitRecord hitRecord = new HitRecord();
        if (world.Hit(ray, out hitRecord))
        {
            return 0.5f * new Color(hitRecord.m_normal.x + 1f, hitRecord.m_normal.y + 1f, hitRecord.m_normal.z + 1f);
            //Vector3 target = hitRecord.m_point + hitRecord.m_normal + RandomInUnitSphere();
            //return 0.5f * GetColor(new Ray(hitRecord.m_point, target - hitRecord.m_point), world);
        }
        else
        {
            //Color src = Color.white;
            //Color des = Color.blue;

            float y = ray.direction.y;
            float weight = (y + 1) / 2;
            //float range = 1 - (-1);
            //float weight = -1 + offset * range;

            //int r = (int)((1 - weight) * src.R + weight * des.R);
            //int g = (int)((1 - weight) * src.G + weight * des.G);
            //int b = (int)((1 - weight) * src.B + weight * des.B);

            //return Color.FromArgb(255, r, g, b);
            return Color.Lerp(Color.white, new Color(0.5f, 0.7f, 1.0f), weight);
        }

    }
}

