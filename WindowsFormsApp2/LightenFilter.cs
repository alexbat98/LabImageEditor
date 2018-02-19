using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class LightenFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return Color.FromArgb(
                    Clamp(sourceImage.GetPixel(x, y).R + 30, 0, 255),
                    Clamp(sourceImage.GetPixel(x, y).G + 30, 0, 255),
                    Clamp(sourceImage.GetPixel(x, y).B + 30, 0, 255));
        }
    }
}
