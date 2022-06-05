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
        private BitmapData _data { set; get; }
        private Rectangle _rect { set; get; }
        public byte[] byteArray { get; set; }

        public int blueAverage { get; set; }
        public int greenAverage { get; set; }
        public int redAverage { get; set; }

        public int imgHeight {get;set;}
        public int imgStride {get;set;}


        public Teste(Bitmap bmp)
        {
            _bmp = bmp;
            byteArrayMontage();
        }

        public void byteArrayMontage()
        {
            _rect = new Rectangle(0, 0, _bmp.Width, _bmp.Height);
            _data = _bmp.LockBits(_rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byteArray = new byte[_data.Height * _data.Stride];
            imgHeight = _data.Height;
            imgStride = _data.Stride;
            Marshal.Copy(_data.Scan0, byteArray, 0, byteArray.Length);
            BGRAverage();
            _bmp.UnlockBits(_data);
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

        public Bitmap RecolorImage(List<Color> colors)
        {
            _data = _bmp.LockBits(_rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byteArray = new byte[_data.Height * _data.Stride];
            Marshal.Copy(_data.Scan0, byteArray, 0, byteArray.Length);
            List<int> clusters = new List<int>();

            for(int i =0; i < colors.Count; i++)
            {
                clusters.Add(0);
            }

            for (int i = 0; i < byteArray.Length; i+=3)
            {

                int cluster = 0;
                long minorDist = int.MaxValue;
                for(int j = 0; j < clusters.Count; j++)
                {
                    long dist = (byteArray[i + 0] - colors[j].B) * (byteArray[i + 0] - colors[j].B) +
                       (byteArray[i + 1] - colors[j].G) * (byteArray[i + 1] - colors[j].G) +
                       (byteArray[i + 2] - colors[j].R) * (byteArray[i + 2] - colors[j].R);

                    if (dist < minorDist)
                    {
                        minorDist = dist;
                        cluster = j;
                    }
                }
                    byteArray[i + 0] = colors[cluster].B;
                    byteArray[i + 1] = colors[cluster].G;
                    byteArray[i + 2] = colors[cluster].R;
                    clusters[cluster]++;

            }
            Marshal.Copy(byteArray, 0, _data.Scan0, byteArray.Length);
            _bmp.UnlockBits(_data);

            return _bmp;

        }
    }
}
