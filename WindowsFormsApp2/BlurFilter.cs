namespace WindowsFormsApp2
{
    public class BlurFilter : MatrixFilter
    {
        public BlurFilter()
        {
            int sizeX = 3, sizeY = 3;
            kernel = new float[sizeX,sizeY];
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    kernel[x, y] = 1.0f / (float) (sizeX * sizeY);
                }
            }
        }
    }
}