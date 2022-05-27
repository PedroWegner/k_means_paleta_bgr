using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace k_means_paleta_bgr.Classes
{
    internal class KMeansBGR
    {
        public List<int[]> clu(List<int[]> list, int k)
        {
            #region Variables
            List<int[]> colors = new List<int[]>();
            Random random = new Random();
            List<List<int[]>> listClusters = new List<List<int[]>>();
            double minorDist = 1000.0;
            int cluster = 0;

            double x = 0;
            double y = 0;
            double z = 0;

            #endregion
            for (int i = 0; i < k; i++)
            {
                colors.Add(new int[] { random.Next(255), random.Next(255), random.Next(255) });
                listClusters.Add(new List<int[]>());
            }

            // aqui sao as iteracoes
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < list.Count; j++)
                //preciso calcular distancia entre o pixel e o nucleo
                {
                    minorDist = 1000.0;
                    for (int c = 0; c < colors.Count; c++)
                    {
                        double dist = Math.Sqrt(
                            Math.Pow((list[j][0] - colors[c][0]), 2) +
                            Math.Pow((list[j][1] - colors[c][1]), 2) +
                            Math.Pow((list[j][2] - colors[c][2]), 2)
                            );

                        if (dist < minorDist)
                        {
                            minorDist = dist;
                            cluster = c;

                        }
                    }
                    listClusters[cluster].Add(list[j]);
                }

                for (int m = 0; m < listClusters.Count; m++)
                {
                    x = 0;
                    y = 0;
                    z = 0;
                    foreach (int[] pixel in listClusters[m])
                    {
                        x += pixel[0];
                        y += pixel[1];
                        z += pixel[2];
                    }
                    if (listClusters[m].Count > 0)
                    {
                        x /= listClusters[m].Count;
                        y /= listClusters[m].Count;
                        z /= listClusters[m].Count;
                        colors[m] = new int[] { (int)(x), (int)(y), (int)(z) };
                    }
                    else
                    {
                        colors[m] = new int[] { 255, 255, 255 };
                    }

                }
            }
            return colors;
        } 
    }
}
