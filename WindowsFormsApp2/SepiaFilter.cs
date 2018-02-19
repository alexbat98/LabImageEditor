using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class SepiaFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float intensity = (float)0.36 * sourceImage.GetPixel(x, y).R
                + (float)0.53 * sourceImage.GetPixel(x, y).G
                + (float)0.11 * sourceImage.GetPixel(x, y).B;

            int k = 15;

            return Color.FromArgb(
                    Clamp((int)intensity + 2 * k, 0, 255),
                    Clamp((int)intensity + (int)(0.5 * k), 0, 255),
                    Clamp((int)intensity - k, 0, 255));
        }
    }
}
