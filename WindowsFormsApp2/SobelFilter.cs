using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class SobelFilter : MatrixFilter
    {

        protected float[,] kernelX;
        protected float[,] kernelY;

        public SobelFilter()
        {
            kernelX = new float[,] { { -1, 0, 1 }, { -2, 0, 1 }, { -1, 0, 1 } };
            kernelY = new float[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            kernel = kernelX;
            Color valueX = base.calculateNewPixelColor(sourceImage, x, y);
            kernel = kernelY;
            Color valueY = base.calculateNewPixelColor(sourceImage, x, y);

            return Color.FromArgb(
                    Clamp((int)Math.Sqrt(Math.Pow(valueX.R, 2) + Math.Pow(valueY.R, 2)), 0, 255),
                    Clamp((int)Math.Sqrt(Math.Pow(valueX.G, 2) + Math.Pow(valueY.G, 2)), 0, 255),
                    Clamp((int)Math.Sqrt(Math.Pow(valueX.B, 2) + Math.Pow(valueY.B, 2)), 0, 255)
                    );

        }

    }
}
