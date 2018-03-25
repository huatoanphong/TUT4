using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;

namespace TUT4
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> _imgInput;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _imgInput = new Image<Bgr, byte>(ofd.FileName);
                imageBox1.Image = _imgInput;
            }
            else
            {

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want Exit?", "System Messenger", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void canyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_imgInput == null)
            {
                return;
            }

            Image<Gray, byte> _imgCanny = new Image<Gray, byte>(_imgInput.Width, _imgInput.Height, new Gray(0));
            _imgCanny = _imgInput.Canny(50, 20);

            imageBox1.Image = _imgCanny;
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_imgInput == null)
            {
                return;
            }
            Image<Gray, byte> _imgGray = _imgInput.Convert<Gray, byte>();
            Image<Gray, float> _imgSobel = new Image<Gray, float>(_imgInput.Width, _imgInput.Height, new Gray(0));
            _imgSobel = _imgGray.Sobel(1, 1, 3);

            imageBox1.Image = _imgSobel;
        }

        private void laplacianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_imgInput == null)
            {
                return;
            }
            Image<Gray, byte> _imgGray = _imgInput.Convert<Gray, byte>();
            Image<Gray, float> _imgLaplacian = new Image<Gray, float>(_imgInput.Width, _imgInput.Height, new Gray(0));
            _imgLaplacian = _imgGray.Laplace(3);

            imageBox1.Image = _imgLaplacian;
        }
    }
}
