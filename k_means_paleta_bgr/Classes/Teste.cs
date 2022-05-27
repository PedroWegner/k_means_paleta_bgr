using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace k_means_paleta_bgr.Classes
{
    internal class Teste
    {
        private Bitmap _bmp { set; get; }
        public byte[] byteArray { get; set; }

        public int blueAverage { get; set; }
        public int greenAverage { get; set; }
        public int redAverage { get; set; }

        public List<int[]> pixelsArray { get; set; } = new List<int[]>();


        public Teste(Bitmap bmp)
        {
            _bmp = bmp;
            byteArrayMontage();
            pixelArrayMontage();
        }

        public void byteArrayMontage()
        {
            var rect = new Rectangle(0, 0, _bmp.Width, _bmp.Height);
            var data = _bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byteArray = new byte[data.Height * data.Stride];
            Marshal.Copy(data.Scan0, byteArray, 0, byteArray.Length);
            BGRAverage();
            _bmp.UnlockBits(data);
        }

        public void BGRAverage()
        {
            double blueSum = 0.0;
            double greenSum = 0.0;
            double redSum = 0.0;

            for (int i = 0; i < byteArray.Length; i += 3)
            {
                blueSum += byteArray[i + 0];
                greenSum += byteArray[i + 1];
                redSum += byteArray[i + 2];
            }
            double qtdPixel = (byteArray.Length / 3);
            blueAverage = (int)(blueSum / qtdPixel);
            greenAverage = (int)(greenSum / qtdPixel);
            redAverage = (int)(redSum / qtdPixel);

        }

        public void pixelArrayMontage()
        {
            for (int i = 0; i < byteArray.Length; i += 3)
            {
                int[] x = { byteArray[i + 0], byteArray[i + 1], byteArray[i + 2] };
                pixelsArray.Add(x);
            }
        }
    }
}
