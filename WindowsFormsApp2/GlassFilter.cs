using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class GlassFilter : Filter
    {

        private double randomNumber;

        public GlassFilter()
        {
            Random rand = new Random();
            randomNumber = rand.NextDouble();
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            
            int nX = (int)(x + (randomNumber - 0.5) * 10);
            int nY = (int)(y + (randomNumber - 0.5) * 10);

            if (nX >= sourceImage.Width || nX < 0 || nY >= sourceImage.Height || nY < 0)
            {
                return Color.Black;
            }

            return sourceImage.GetPixel(nX, nY);
        }
    }
}
