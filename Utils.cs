using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    internal static class Utils
    {
        public static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static Color GetColor()
        {
            using (ColorDialog cd = new ColorDialog())
            {
                cd.AllowFullOpen = true;
                cd.ShowHelp = true;

                if (cd.ShowDialog() == DialogResult.OK)
                {
                    return cd.Color;
                }
            }
            return Color.Empty;
        }

        public static Bitmap ResizeBitmap(Image original, int newWidth, int newHeight)
        {
            Bitmap resized = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(original, 0, 0, newWidth, newHeight);
            }

            return resized;
        }
    }
}
