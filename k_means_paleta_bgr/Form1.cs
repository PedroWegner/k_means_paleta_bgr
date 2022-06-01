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
            bmp = new Bitmap(@"C:\facial_detection_project\k_means_paleta_bgr\k_means_paleta_bgr\china.jpg");
            g = Graphics.FromImage(bmp);
            picture.Image = bmp;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;

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
            // OrderBy(c => c[0] + c[1] + c[2]).ToList();
            KMeansBGR kmeans = new KMeansBGR();
            List<Color> colors = kmeans.Cluterize(imgFormated.byteArray, 12, imgFormated.imgHeight, imgFormated.imgStride).OrderBy(c => c.R + c.G + c.B).ToList(); ;
            palete1.BackColor = Color.FromArgb(colors[0].R, colors[0].G, colors[0].B);
            palete2.BackColor = Color.FromArgb(colors[1].R, colors[1].G, colors[1].B);
            palete3.BackColor = Color.FromArgb(colors[2].R, colors[2].G, colors[2].B);
            palete4.BackColor = Color.FromArgb(colors[3].R, colors[3].G, colors[3].B);
            palete5.BackColor = Color.FromArgb(colors[4].R, colors[4].G, colors[4].B);
            palete6.BackColor = Color.FromArgb(colors[5].R, colors[5].G, colors[5].B);
            palete7.BackColor = Color.FromArgb(colors[6].R, colors[6].G, colors[6].B);
            panete8.BackColor = Color.FromArgb(colors[7].R, colors[7].G, colors[7].B);
            palete9.BackColor = Color.FromArgb(colors[8].R, colors[8].G, colors[8].B);
            palete10.BackColor = Color.FromArgb(colors[9].R, colors[9].G, colors[9].B);
            palete11.BackColor = Color.FromArgb(colors[10].R, colors[10].G, colors[10].B);
            palete12.BackColor = Color.FromArgb(colors[11].R, colors[11].G, colors[11].B);
            cor1.Text = $"{colors[0].R}, {colors[0].G}, {colors[0].B}";
            cor2.Text = $"{colors[1].R}, {colors[1].G}, {colors[1].B}";
            cor3.Text = $"{colors[2].R}, {colors[2].G}, {colors[2].B}";
            cor4.Text = $"{colors[3].R}, {colors[3].G}, {colors[3].B}";
            cor5.Text = $"{colors[4].R}, {colors[4].G}, {colors[4].B}";
            cor6.Text = $"{colors[5].R}, {colors[5].G}, {colors[5].B}";
            cor7.Text = $"{colors[6].R}, {colors[6].G}, {colors[6].B}";
            cor8.Text = $"{colors[7].R}, {colors[7].G}, {colors[7].B}";
            cor9.Text = $"{colors[8].R}, {colors[8].G}, {colors[8].B}";
            cor10.Text = $"{colors[9].R}, {colors[9].G}, {colors[9].B}";
            cor11.Text = $"{colors[10].R}, {colors[10].G}, {colors[10].B}";
            cor12.Text = $"{colors[11].R}, {colors[11].G}, {colors[11].B}";
            Console.WriteLine();
        }
    }
}
