using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class LinearHistogramScale : Filter
    {
        private double intensityMax = -100000;
        private double intensityMin = 1000000;

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color curColor = sourceImage.GetPixel(x, y);
            double intensity = curColor.R * 0.36 + 0.53 * curColor.G + 0.11 * curColor.B;
            double newIntensity = (intensity - intensityMin) * (255.0 / (intensityMax - intensityMin));
            double scale = newIntensity / intensity;
            return Color.FromArgb(
                Clamp((int) (scale * curColor.R), 0, 255),
                Clamp((int) (scale * curColor.G), 0, 255),
                Clamp((int) (scale * curColor.B), 0, 255)
            );
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker bgWorker)
        {
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color curColor = sourceImage.GetPixel(i, j);
                    double intensity = curColor.R * 0.36 + 0.53 * curColor.G + 0.11 * curColor.B;
                    if (intensity > intensityMax)
                        intensityMax = intensity;
                    if (intensity < intensityMin)
                        intensityMin = intensity;
                }
            }
            return base.processImage(sourceImage, bgWorker);
        }
    }
}
