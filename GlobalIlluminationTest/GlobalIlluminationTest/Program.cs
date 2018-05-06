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
        //此数组位于第一象限
        Color[] data = new Color[nx * ny];

        Vector3 lower_left_corner = new Vector3(-2, -1, -1);
        Vector3 horizontal = new Vector3(4, 0, 0);
        Vector3 vertical = new Vector3(0, 2, 0);
        Vector3 origin = Vector3.zero;

        for (int j = ny - 1; j >= 0; j-- )
        {
            for (int i = 0; i < nx; ++i )
            {
                float u = (float)i / (float)nx;
                float v = (float)j / (float)ny;

//                 byte alpha = 255;
//                 byte r = (byte)((float)i / (float)nx * 255);
//                 byte g = (byte)((float)j / (float)ny * 255);
//                 byte b = (byte)(0.2 * 255);
                Ray ray = new Ray(origin, lower_left_corner + u * horizontal + v * vertical);
                //Color color = Color.FromArgb(255, r, g, b);
                Color color = ColorLerp(ray);

                int index = j * nx + i;
                data[index] = color;
            }
        }

        DrawHelper.DrawData("test.bmp", nx, ny, data, "by wth");

        Console.WriteLine("end");
        Console.ReadLine();
    }

    static Color ColorLerp(Ray ray)
    {
        Sphere sphere = new Sphere(new Vector3(0, 0, -1), 0.5f);
        float enter = 0;
        if(sphere.Raycast(ray, out enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            Vector3 normal = hitPoint - sphere.center;
            return Color.red;
        }

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
        return Color.Lerp(Color.white, Color.blue, weight);
    }
}

