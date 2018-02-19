using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Bitmap image;
        private int oldWidth;
        private int oldHeight;

        private Stack<Bitmap> oldImages = new Stack<Bitmap>();
        private Stack<Bitmap> newImages = new Stack<Bitmap>();

        public Form1()
        {
            InitializeComponent();
            oldWidth = 0;
            oldHeight = 0;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files | .jpg; *.jpeg; *.png; *.JPG; *.bmp | All Files (*.*) | *.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(ofd.FileName);

                //oldImages.Push(image);

                pictureBox1.Image = image;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Refresh();
            }
        }

        private void inversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter invertFilter = new InvertFilter();
            //pictureBox1.Image = invertFilter.processImage(image);
            //pictureBox1.Refresh();
            backgroundWorker1.RunWorkerAsync(invertFilter);
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filter) e.Argument).processImage(image, backgroundWorker1);
            if (!backgroundWorker1.CancellationPending)
            {
                image = newImage;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                oldImages.Push(new Bitmap(pictureBox1.Image));
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }

            progressBar1.Value = 0;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter f = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(f);
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GaussianBlur gb = new GaussianBlur();
            gb.createKernel(10, 3);
            backgroundWorker1.RunWorkerAsync(gb);
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrayScaleFilter gs = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(gs);
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SepiaFilter sf = new SepiaFilter();
            backgroundWorker1.RunWorkerAsync(sf);
        }

        private void lightenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LightenFilter lf = new LightenFilter();
            backgroundWorker1.RunWorkerAsync(lf);
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sharpenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SharpenFilter sf = new SharpenFilter();
            backgroundWorker1.RunWorkerAsync(sf);
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SobelFilter sf = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(sf);
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveFilter mf = new MoveFilter();
            backgroundWorker1.RunWorkerAsync(mf);
        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateFilter rf = new RotateFilter();
            backgroundWorker1.RunWorkerAsync(rf);
        }

        private void glassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlassFilter gf = new GlassFilter();
            backgroundWorker1.RunWorkerAsync(gf);
        }

        private void motionBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MotionBlur mb = new MotionBlur();
            backgroundWorker1.RunWorkerAsync(mb); 
        }

        private void scharrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScharrFilter sf = new ScharrFilter();
            backgroundWorker1.RunWorkerAsync(sf);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                fs.Close();
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (oldImages.Count > 0)
            {
                newImages.Push(image);
                image = oldImages.Pop();
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (newImages.Count > 0)
            {
                oldImages.Push(image);
                image = newImages.Pop();
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (oldWidth != 0 && oldHeight != 0)
            {
                int deltaX = Width - oldWidth;
                int deltaY = Height - oldHeight;

                pictureBox1.Height = pictureBox1.Height + deltaY;
                pictureBox1.Width = pictureBox1.Width + deltaX;

                progressBar1.Location = new Point(
                            progressBar1.Location.X,
                            progressBar1.Location.Y + deltaY
                       );

                progressBar1.Width = progressBar1.Width + deltaX;

                cancelBtn.Location = new Point(
                        cancelBtn.Location.X + deltaX,
                        cancelBtn.Location.Y + deltaY
                    );
            }

            oldHeight = Height;
            oldWidth = Width;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            oldHeight = Height;
            oldWidth = Width;
        }
    }
}
