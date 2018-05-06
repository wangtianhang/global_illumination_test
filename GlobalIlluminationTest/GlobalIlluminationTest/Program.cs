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
                    color += ColorLerp(ray, world);
                }

                color /= (float)ns;

                int index = j * nx + i;
                data[index] = color;
            }
        }

        DrawHelper.DrawData("test.bmp", nx, ny, data, "by wth");

        Console.WriteLine("end");
        Console.ReadLine();
    }

    static Color ColorLerp(Ray ray, HitableList world)
    {
        //Sphere sphere = new Sphere(new Vector3(0, 0, -1), 0.5f);
        //float enter = 0;
        HitRecord hitRecord = new HitRecord();
        if (world.Hit(ray, out hitRecord))
        {
            //Vector3 hitPoint = ray.GetPoint(enter);
            //Vector3 normal = hitPoint - sphere.center;
            //normal.Normalize();
            //return 0.5f * new Color(normal.x + 1f, normal.y + 1f, normal.z + 1f);
            return 0.5f * new Color(hitRecord.m_normal.x + 1f, hitRecord.m_normal.y + 1f, hitRecord.m_normal.z + 1f);
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

