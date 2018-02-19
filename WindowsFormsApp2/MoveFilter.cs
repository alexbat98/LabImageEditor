using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class MoveFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            if (x + 150 >= sourceImage.Width)
            {
                return Color.FromArgb(0, 0, 0);
            } else {
                return sourceImage.GetPixel(x + 150, y);
            }

        }
    }
}
