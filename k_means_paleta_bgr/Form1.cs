using k_means_paleta_bgr.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k_means_paleta_bgr
{
    public partial class Form1 : Form
    {
        #region Variables
        Bitmap bmp = null;
        Graphics g = null;
        string imageFile = @"C:\facial_detection_project\k_means_paleta_bgr\k_means_paleta_bgr\norge_1.jpg";

        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(@"C:\facial_detection_project\k_means_paleta_bgr\k_means_paleta_bgr\01.jpeg");
            g = Graphics.FromImage(bmp);
            picture.Image = bmp;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Teste imgFormated = new Teste(bmp);
            KMeansBGR kmeans = new KMeansBGR();
            List<Color> colors = kmeans.Cluterize(imgFormated.byteArray, 24, imgFormated.imgHeight, imgFormated.imgStride).OrderBy(c => c.R + c.G + c.B).ToList();

            flp.Controls.Clear();
            foreach(var color in colors)
            {
                Panel p = new Panel();
                p.BackColor = color;
                p.Size = new Size(30, 30);
                flp.Controls.Add(p);
            };
            bmp = imgFormated.RecolorImage(colors);
            g = Graphics.FromImage(bmp);
            picture.Image = bmp;
        }
    }
}
