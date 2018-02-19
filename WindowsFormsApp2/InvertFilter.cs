using System.Drawing;

namespace WindowsFormsApp2
{
    public class InvertFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resColor = Color.FromArgb(
                Clamp(255 - sourceColor.R, 0, 255),
                Clamp(255 - sourceColor.G, 0, 255),
                Clamp(255 - sourceColor.B, 0, 255)
            );

            return resColor;
        }
    }
}