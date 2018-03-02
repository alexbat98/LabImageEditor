using System;
using System.Drawing;

namespace WindowsFormsApp2
{
    class GlassFilter : Filter
    {

        private double randomNumber;
        private Random rand;

        public GlassFilter()
        {
            rand = new Random();
            //randomNumber = rand.NextDouble();
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            
            randomNumber = rand.NextDouble();
            int nX = Clamp((int)(x + (randomNumber - 0.5) * 10), 0, sourceImage.Width - 1);
            int nY = Clamp((int)(y + (randomNumber - 0.5) * 10), 0, sourceImage.Height - 1);

            return sourceImage.GetPixel(nX, nY);
        }
    }
}
