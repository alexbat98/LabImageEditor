using System.Drawing;

namespace WindowsFormsApp2
{

    class ErosionFilter : Filter
    {
        private int _kwidth;
        private int _kheight;
        private int[,] _kmatrix;

        public ErosionFilter(int w, int h, int[,] k)
        {
            _kwidth = w;
            _kheight = h;
            _kmatrix = k;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color min = Color.Black;
            double minIntensity = 100000;
            for (int j = -_kheight / 2; j <= _kheight / 2; j++)
            {
                for (int i = -_kwidth / 2; i <= _kwidth / 2; i++)
                {
                    int nx = Clamp(x + i, 0, sourceImage.Width-1);
                    int ny = Clamp(y + j, 0, sourceImage.Height-1);
                    if ((_kmatrix[_kwidth/2+i, _kheight/2+j] != 0) &&
                        (Intensity(sourceImage.GetPixel(nx, ny)) < minIntensity))
                    {
                        min = sourceImage.GetPixel(nx, ny);
                        minIntensity = Intensity(min);
                    }
                }
            }

            return min;
//            int radius = 5;
//            bool hasBlack = false;
//
//            for (int k = -radius; k <= radius; k++)
//            {
//                for (int l = -radius; l <= radius; l++)
//                {
//                    int nX = Clamp(x + k, 0, sourceImage.Width - 1);
//                    int nY = Clamp(y + l, 0, sourceImage.Height - 1);
//
//                    Color srcColor = sourceImage.GetPixel(nX, nY);
//
//                    if (srcColor.R <= 10 && srcColor.G <= 10 && srcColor.B <= 10)
//                    {
//                        hasBlack = true;
//                        break;
//                    }
//
//                }
//            }
//
//            if (hasBlack)
//                return Color.Black;
//            else
//                return Color.White;
        }
    }
}
