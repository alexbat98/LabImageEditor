using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class ScharrFilter : SobelFilter
    {
        public ScharrFilter()
        {
            kernelX = new float[,] { { 3, 10, -3 }, { 10, 0, -10 }, { 3, 0, -3 } };
            kernelY = new float[,] { { 3, 10, 3 }, { 0, 0, 0 }, { -3, -10, -3 } };
        }
    }
}
