using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    internal class ConvMatrix
    {
        public int TopLeft = 0, TopMid = 0, TopRight = 0;
        public int MidLeft = 0, Pixel = 1, MidRight = 0;
        public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;
        public int Factor = 1;
        public int Offset = 0;

        public void SetAll(int nVal)
        {
            TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight =
                      BottomLeft = BottomMid = BottomRight = nVal;
        }

        public void Set(int tl, int tm, int tr,
                        int ml, int p, int mr,
                        int bl, int bm, int br,
                        int factor = 1, int offset = 0)
        {
            TopLeft = tl; TopMid = tm; TopRight = tr;
            MidLeft = ml; Pixel = p; MidRight = mr;
            BottomLeft = bl; BottomMid = bm; BottomRight = br;
            Factor = factor; Offset = offset;
        }
    }
}
