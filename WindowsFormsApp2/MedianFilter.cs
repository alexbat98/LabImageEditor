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

            Color[] colors = new Color[(radius * 2 + 1) * (radius * 2 + 1)];
            double[] intensities = new double[(radius * 2 + 1) * (radius * 2 + 1)];

            for (int k = -radius; k <= radius; k++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    colors[(k+radius) * (radius * 2 + 1) + j + radius] = sourceImage.GetPixel(x + k, y + j);
                    intensities[(k + radius) * (radius * 2 + 1) + j + radius] =
                        Intensity(colors[(k + radius) * (radius * 2 + 1) + j + radius]);
                }
            }

            bool flag = false;
            for (int i = 0; i < intensities.Length; i++)
            {
                for (int j = 1; j < intensities.Length; j++)
                {
                    if (intensities[j] < intensities[j - 1])
                    {
                        double tmpI = intensities[j];
                        Color tmpColor = colors[j];
                        intensities[j] = intensities[j - 1];
                        colors[j] = colors[j - 1];
                        intensities[j - 1] = tmpI;
                        colors[j - 1] = tmpColor;
                        flag = true;
                    }
                }

                if (!flag)
                {
                    break;
                }
            }

            return colors[colors.Length / 2];

//            int[] reds = new int[(radius * 2 + 1) * (radius * 2 + 1)];
//            
//            for (int k = -radius; k <= radius; k++)
//            {
//                for (int j = -radius; j <= radius; j++)
//                {
//                    reds[(k+radius) * (radius * 2 + 1) + j + radius] = sourceImage.GetPixel(x + k, y + j).R;
//                }
//            }
//
//            Array.Sort(reds);
//
//            Color srcColor = sourceImage.GetPixel(x, y);
//            //resColor.R = reds[reds.Length / 2];
//            return Color.FromArgb(
//                        reds[reds.Length / 2],
//                        srcColor.G,
//                        srcColor.B
//                   );
        }
    }
}
