using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class MotionBlur : MatrixFilter
    {
        public MotionBlur()
        {
            kernel = new float[,] { { 0.2f, 0, 0, 0, 0 }, { 0, 0.2f, 0, 0, 0}, {0, 0, 0.2f, 0, 0 }, 
                { 0, 0, 0, 0.2f, 0}, { 0, 0, 0, 0, 0.2f } };
        }
    }
}
