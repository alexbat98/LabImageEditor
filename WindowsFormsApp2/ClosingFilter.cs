using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{

    class ClosingFilter : Filter
    {

        private DilationFilter dilationFilter = new DilationFilter();
        private ErosionFilter erosionFilter = new ErosionFilter();
       
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return Color.White;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker bgWorker)
        {
            Bitmap res = dilationFilter.processImage(sourceImage, bgWorker);
            Bitmap finalRes = erosionFilter.processImage(res, bgWorker);

            return finalRes;
        }
    }
}
