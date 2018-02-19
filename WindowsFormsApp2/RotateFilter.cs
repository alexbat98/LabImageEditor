using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class RotateFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int centerX = sourceImage.Width / 2;
            int centerY = sourceImage.Height / 2;
            int nX = (int)((x - centerX) * Math.Cos(Math.PI / 6) - (y - centerY) * Math.Sin(Math.PI / 6)) + centerX;
            int nY = (int)((x - centerX) * Math.Sin(Math.PI / 6) + (y - centerY) * Math.Cos(Math.PI / 6)) + centerY;

            if (nX >= sourceImage.Width || nX < 0 || nY >= sourceImage.Height || nY < 0)
            {
                return Color.Black;
            }

            return sourceImage.GetPixel(nX, nY);

        }
    }
}
