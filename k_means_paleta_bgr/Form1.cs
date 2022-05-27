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
            bmp = new Bitmap(@"C:\facial_detection_project\k_means_paleta_bgr\k_means_paleta_bgr\norge_1.jpg");
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
            Teste x = new Teste(bmp);

            KMeansBGR kmeans = new KMeansBGR();
            List<int[]> colors = kmeans.clu(x.pixelsArray, 12);
            palete1.BackColor = Color.FromArgb(colors[0][0], colors[0][1], colors[0][2]);
            palete2.BackColor = Color.FromArgb(colors[1][0], colors[1][1], colors[1][2]);
            palete3.BackColor = Color.FromArgb(colors[2][0], colors[2][1], colors[2][2]);
            palete4.BackColor = Color.FromArgb(colors[3][0], colors[3][1], colors[3][2]);
            palete5.BackColor = Color.FromArgb(colors[4][0], colors[4][1], colors[4][2]);
            palete6.BackColor = Color.FromArgb(colors[5][0], colors[5][1], colors[5][2]);
            palete7.BackColor = Color.FromArgb(colors[6][0], colors[6][1], colors[6][2]);
            panete8.BackColor = Color.FromArgb(colors[7][0], colors[7][1], colors[7][2]);
            palete9.BackColor = Color.FromArgb(colors[8][0], colors[8][1], colors[8][2]);
            palete10.BackColor = Color.FromArgb(colors[9][0], colors[9][1], colors[9][2]);
            palete11.BackColor = Color.FromArgb(colors[10][0], colors[10][1], colors[10][2]);
            palete12.BackColor = Color.FromArgb(colors[11][0], colors[11][1], colors[11][2]);
            cor1.Text = $"{ colors[0][0]}, {colors[0][1]}, {colors[0][2]}";
            cor2.Text = $"{colors[1][0]}, {colors[1][1]}, {colors[1][2]}";
            cor3.Text = $"{colors[2][0]}, {colors[2][1]}, {colors[2][2]}";
            cor4.Text = $"{colors[3][0]}, {colors[3][1]}, {colors[3][2]}";
            cor5.Text = $"{colors[4][0]}, {colors[4][1]}, {colors[4][2]}";
            cor6.Text = $"{colors[5][0]}, {colors[5][1]}, {colors[5][2]}";
            cor7.Text = $"{colors[6][0]}, {colors[6][1]}, {colors[6][2]}";
            cor8.Text = $"{colors[7][0]}, {colors[7][1]}, {colors[7][2]}";
            cor9.Text = $"{colors[8][0]}, {colors[8][1]}, {colors[8][2]}";
            cor10.Text = $"{colors[9][0]}, {colors[9][1]}, {colors[9][2]}";
            cor11.Text = $"{colors[10][0]}, {colors[10][1]}, {colors[10][2]}";
            cor12.Text = $"{colors[11][0]}, {colors[11][1]}, {colors[11][2]}";
            Console.WriteLine();
        }
    }
}
