using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;

class DrawHelper
{
    public static string GetTime()
    {
        DateTime now = DateTime.Now;
        string ret = now.Year + "_" + now.Month + "_" + now.Day + "_" + now.Hour + "_" + now.Minute + "_" + now.Second;
        return ret;
    }

    public static void DrawData(string filePath, int width, int height, Common.Color[] data, string des)
    {
        Bitmap bitmap = DrawData(width, height, data);
        using (Graphics g = Graphics.FromImage(bitmap))
        {
            using (Font font = new Font("宋体", 16f))
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
                g.DrawString(des, font, Brushes.Black, new Point(20, 20));
            }

        }
        //string fileDir = Path.GetDirectoryName(filePath);
        //string fileName = Path.GetFileNameWithoutExtension(filePath);
        //bitmap.Save(fileDir + "/" + fileName + GetTime() + ".bmp");
        bitmap.Save(filePath);
    }

    public static Bitmap DrawData(int width, int height, Common.Color[] data)
    {
        Bitmap bitmap = new Bitmap(width, height);

        for (int j = height - 1; j >= 0; --j)
        {
            for (int i = 0; i < width; ++i)
            {
                int index = j * width + i;
                Common.Color color = data[index];
                Color sysColor = Color.FromArgb((byte)(255 * color.a), (byte)(255 * color.r), (byte)(255 * color.g), (byte)(255 * color.b));
                bitmap.SetPixel(i, height - j - 1, sysColor);
            }
        }
        return bitmap;
    }
}

