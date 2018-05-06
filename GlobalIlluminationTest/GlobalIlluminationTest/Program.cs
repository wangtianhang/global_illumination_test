using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GlobalIlluminationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int nx = 200;
            int ny = 100;
            //此数组位于第一象限
            Color[] data = new Color[nx * ny];

            for (int j = ny - 1; j >= 0; j-- )
            {
                for (int i = 0; i < nx; ++i )
                {
                    byte alpha = 255;
                    byte r = (byte)((float)i / (float)nx * 255);
                    byte g = (byte)((float)j / (float)ny * 255);
                    byte b = (byte)(0.2 * 255);
                    Color color = Color.FromArgb(alpha, r, g, b);
                    int index = j * nx + i;
                    data[index] = color;
                }
            }

            DrawHelper.DrawData("test.bmp", nx, ny, data, "by wth");

            Console.WriteLine("end");
            Console.ReadLine();
        }
    }
}
