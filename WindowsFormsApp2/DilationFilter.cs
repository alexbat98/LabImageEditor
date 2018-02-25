using System.Drawing;

namespace WindowsFormsApp2
{
    class DilationFilter : Filter
    {
        private int _kwidth;
        private int _kheight;
        private int[,] _kmatrix;

        public DilationFilter(int w, int h, int[,] k)
        {
            _kwidth = w;
            _kheight = h;
            _kmatrix = k;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {

            Color max = Color.Black;
            double maxIntensity = -100000;
            for (int j = -_kheight / 2; j <= _kheight / 2; j++)
            {
                for (int i = -_kwidth / 2; i <= _kwidth / 2; i++)
                {
                    int nx = Clamp(x + i, 0, sourceImage.Width-1);
                    int ny = Clamp(y + j, 0, sourceImage.Height-1);

                    if ((_kmatrix[_kwidth/2+i, _kheight/2+j] != 0) &&
                        (Intensity(sourceImage.GetPixel(nx, ny)) > maxIntensity))
                    {
                        max = sourceImage.GetPixel(nx, ny);
                        maxIntensity = Intensity(max);
                    }
                }
            }

            return max;

//            int radius = 5;
//            bool hasWhite = false;
//
//            for (int k = -radius; k <= radius; k++)
//            {
//                for (int l = -radius; l <= radius; l++)
//                {
//                    int nX = Clamp(x + k, 0, sourceImage.Width- 1);
//                    int nY = Clamp(y + l, 0, sourceImage.Height - 1);
//
//                    Color srcColor = sourceImage.GetPixel(nX, nY);
//
//                    if (srcColor.R >= 250 && srcColor.G >= 250 && srcColor.B >= 250)
//                    {
//                        hasWhite = true;
//                        break;
//                    }
//
//                }
//            }
//
//            if (hasWhite)
//                return Color.White;
//            else
//                return Color.Black;

        }
    }
}
