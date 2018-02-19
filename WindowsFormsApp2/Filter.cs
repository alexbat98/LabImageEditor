﻿using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public abstract class Filter
    {

        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);

        public Bitmap processImage(Bitmap sourceImage, BackgroundWorker bgWorker)
        {
            Bitmap result = new Bitmap(sourceImage.Width, sourceImage.Height);

            //Parallel.For(0, sourceImage.Width, x =>
            for (int x = 0; x < sourceImage.Width; x++)
            {
                bgWorker.ReportProgress((int)((float)x / sourceImage.Width * 100));
                if (bgWorker.CancellationPending)
                    return null;
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    result.SetPixel(x, y, calculateNewPixelColor(sourceImage, x, y));
                }
            } //);

            return result;
        }
        protected int Clamp(int val, int min, int max)
        {
            if (val > max)
            {
                return max;
            }

            return val < min ? min : val;
        }
    }

    
}