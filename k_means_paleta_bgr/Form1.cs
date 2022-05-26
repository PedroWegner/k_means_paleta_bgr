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
            bmp = new Bitmap(imageFile);
            g = Graphics.FromImage(bmp);
            picture.Image = bmp;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            Teste x = new Teste(new Bitmap(@"C:\facial_detection_project\k_means_paleta_bgr\k_means_paleta_bgr\red.jpg"));
            label1.Text = x.blueAverage.ToString();
            label2.Text = x.greenAverage.ToString();
            label3.Text = x.redAverage.ToString();
        }
    }
}
