using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class DilationFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radius = 1;
            bool hasWhite = false;

            for (int k = -radius; k <= radius; k++)
            {
                for (int l = -radius; l <= radius; l++)
                {
                    int nX = Clamp(x + k, 0, sourceImage.Width- 1);
                    int nY = Clamp(y + l, 0, sourceImage.Height - 1);

                    Color srcColor = sourceImage.GetPixel(nX, nY);

                    if (srcColor.R >= 250 && srcColor.G >= 250 && srcColor.B >= 250)
                    {
                        hasWhite = true;
                        break;
                    }

                }
            }

            if (hasWhite)
                return Color.White;
            else
                return Color.Black;

        }
    }
}
