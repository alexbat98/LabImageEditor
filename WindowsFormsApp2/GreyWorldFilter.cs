using System.ComponentModel;
using System.Drawing;

namespace WindowsFormsApp2
{
    public class GreyWorldFilter : Filter
    {
        public double avgR;
        public double avgG;
        public double avgB;
        public double avgAll;

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color = sourceImage.GetPixel(x, y);
            return Color.FromArgb(
                Clamp((int) (color.R * avgAll / avgR), 0, 255),
                Clamp((int) (color.G * avgAll / avgG), 0, 255),
                Clamp((int) (color.B * avgAll / avgB), 0, 255)
            );
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker bgWorker)
        {
            double sumR = 0;
            double sumG = 0;
            double sumB = 0;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color curColor = sourceImage.GetPixel(i, j);
                    sumR += curColor.R;
                    sumG += curColor.G;
                    sumB += curColor.G;
                }
            }

            avgR = sumR / (sourceImage.Width * sourceImage.Height);
            avgG = sumG / (sourceImage.Width * sourceImage.Height);
            avgB = sumB / (sourceImage.Width * sourceImage.Height);

            avgAll = (avgR + avgB + avgG) / 3;

            return base.processImage(sourceImage, bgWorker);
        }
    }
}