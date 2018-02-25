using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class OpeningFilter : Filter
    {
        private DilationFilter dilationFilter;
        private ErosionFilter erosionFilter;

        public OpeningFilter(int w, int h, int[,] k)
        {

            dilationFilter = new DilationFilter(w, h, k);
            erosionFilter = new ErosionFilter(w, h, k);
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            if (sourceImage == null)
            {
                throw new ArgumentNullException(nameof(sourceImage));
            }

            return Color.White;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker bgWorker)
        {
            Bitmap res = erosionFilter.processImage(sourceImage, bgWorker);
            Bitmap finalRes = dilationFilter.processImage(res, bgWorker);

            return finalRes;
        }
    }
}

