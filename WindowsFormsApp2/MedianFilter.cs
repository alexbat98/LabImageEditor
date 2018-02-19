using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{

    class MedianFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {


            int radius = 4;

            if (x < radius || x >= sourceImage.Width - radius - 1
                || y < radius || y >= sourceImage.Height - radius - 1)
            {
                return sourceImage.GetPixel(x, y);
            }

            int[] reds = new int[(radius * 2 + 1) * (radius * 2 + 1)];
            
            for (int k = -radius; k <= radius; k++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    reds[(k+radius) * (radius * 2 + 1) + j + radius] = sourceImage.GetPixel(x + k, y + j).R;
                }
            }

            Array.Sort(reds);

            Color srcColor = sourceImage.GetPixel(x, y);
            //resColor.R = reds[reds.Length / 2];
            return Color.FromArgb(
                        reds[reds.Length / 2],
                        srcColor.G,
                        srcColor.B
                   );
        }
    }
}
