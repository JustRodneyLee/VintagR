using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Flann;

namespace VintagR
{
    public partial class VintagR : Form
    {
        Dictionary<string, Image> ImagePreviews;
        Dictionary<string, Mat> Images;
        Mat magentaOverlay;
        const double contrast = 2;

        public VintagR()
        {
            InitializeComponent();
        }

        private void VintagR_Load(object sender, EventArgs e)
        {
            ImagePreviews = new Dictionary<string, Image>();
            Images = new Dictionary<string, Mat>();
            //MakeImageVintage("lol", Cv2.ImRead("E:/Desktop/1.png"));
        }

        private void VintageButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.SelectedPath == "")
            {
                MessageBox.Show("Please select an output directory!");
                folderBrowserDialog.ShowDialog();                
            }
            else
            {
                ProgressBar.Visible = true;
                ProgressBar.Maximum = Images.Count * 3;
                ProgressBar.Value = 0;
                LoadImageButton.Enabled = false;
                RemoveImageButton.Enabled = false;
                OutputDirButton.Enabled = false;
                foreach (KeyValuePair<string, Mat> img in Images)
                {
                    StatusLabel.Text = "Vintaging " + img.Key;
                    MakeImageVintage(img.Key, img.Value);
                }
                ProgressBar.Visible = false;
                LoadImageButton.Enabled = true;
                RemoveImageButton.Enabled = true;
                OutputDirButton.Enabled = true;
                StatusLabel.Text = "Ready";
            }            
        }

        private void MakeImageVintage(string name, Mat img)
        {            
            int dataSize = (int)(img.Total() * img.Channels());
            byte[] imgData = new byte[dataSize];
            byte[] vintageImgData = new byte[dataSize];            
            Mat vintageImg = new Mat();
            img.ConvertTo(vintageImg, -1, 1.25, -35); //Contrast and Brightness adjustments
            var mat3 = new Mat<Vec3b>(vintageImg);
            var indexer = mat3.GetIndexer();
            //Cv2.CvtColor(vintageImg, vintageImg, ColorConversionCodes.RGB2HSV); //Convert to HSV
            Mat hsvImg = new Mat();
            Cv2.CvtColor(vintageImg, hsvImg, ColorConversionCodes.BGR2HSV);
            ProgressBar.Value++;
            Mat[] hsv = Cv2.Split(hsvImg);
            hsv[0] -= 5; //Hue change
            hsv[1] += 20; //Saturation increase
            hsv[2] -= 10; //Lightness increase
            Cv2.Merge(hsv, hsvImg);
            Cv2.CvtColor(hsvImg, vintageImg, ColorConversionCodes.HSV2BGR);
            ProgressBar.Value++;
            magentaOverlay = new Mat(img.Rows, img.Cols, img.Type(), new Scalar(144, 0, 255)); //BGR            
            double temp;
            for (int y = 0; y < vintageImg.Height; y++)
                for (int x = 0; x < vintageImg.Width; x++)
                {
                    Vec3b pix = vintageImg.At<Vec3b>(y, x);//BGR                    

                    temp = pix.Item0 * 0.7 + 32;
                    if (temp >= 255) temp = 255;
                    pix.Item0 = (byte)temp;                    

                    temp = 0.00001 * Math.Pow(pix.Item1, 3) - 0.006 * Math.Pow(pix.Item1, 2) + 1.9 * pix.Item1;
                    if (temp >= 255) temp = 255;
                    pix.Item1 = (byte)temp;
                    
                    temp = 1.125 * pix.Item2;
                    if (temp >= 255) temp = 255;
                    pix.Item2 = (byte)temp;

                    vintageImg.At<Vec3b>(y, x) = pix;
                }
            Cv2.AddWeighted(magentaOverlay, 0.12, vintageImg, 0.9, 0, vintageImg);
            vintageImg.ConvertTo(vintageImg, -1, 1.1, -10);
            ProgressBar.Value++;            
            //Cv2.ImShow("Preview", vintageImg);
            Cv2.ImWrite(folderBrowserDialog.SelectedPath + "/" + name, vintageImg);
        }

        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        void AddImage(string path)
        {
            string fileName = Path.GetFileName(path);
            Mat mat = Cv2.ImRead(path, ImreadModes.Color);
            Images.Add(fileName, mat);
            ImagePreviews.Add(fileName, Image.FromFile(path));                        
            listViewImages.Items.Add(fileName);
        }

        void RemoveImage(string name)
        {
            Images.Remove(name);
            ImagePreviews.Remove(name);            
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            ProgressBar.Visible = true;
            ProgressBar.Maximum = openFileDialog.FileNames.Count();
            ProgressBar.Value = 0;
            foreach (string path in openFileDialog.FileNames)
            {
                StatusLabel.Text = "Loading image " + path;
                try
                {
                    AddImage(path);                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Unable to load image " + path + ":" + ex.ToString());
                }
                finally
                {
                    ProgressBar.Value++;
                }
            }
            CheckImageCount();
            StatusLabel.Text = "Ready";
            ProgressBar.Visible = false;
        }

        private void listViewImages_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (listViewImages.SelectedItems.Count > 1)
            {
                RemoveImageButton.Text = "Remove Images";
                RemoveImageButton.Enabled = true;
                PreviewImage.Image = ImagePreviews[listViewImages.SelectedItems[listViewImages.SelectedItems.Count - 1].Text];
            }                
            else if (listViewImages.SelectedItems.Count == 0)
            {
                RemoveImageButton.Enabled = false;
                PreviewImage.Image = null;
            }                
            else if (listViewImages.SelectedItems.Count == 1)
            {
                RemoveImageButton.Text = "Remove Image";
                RemoveImageButton.Enabled = true;
                PreviewImage.Image = ImagePreviews[listViewImages.SelectedItems[listViewImages.SelectedItems.Count - 1].Text];
            }                
        }

        void CheckImageCount()
        {
            if (Images.Count > 1)
            {
                VintageButton.Enabled = true;
                VintageButton.Text = "Process Images";
            }
            else if (Images.Count == 1)
            {
                VintageButton.Enabled = true;
                VintageButton.Text = "Process Image";
            }
            else
            {
                VintageButton.Enabled = false;
            }
        }

        void RemoveImage()
        {
            List<int> indices = new List<int>();
            foreach (ListViewItem item in listViewImages.SelectedItems)
            {
                Images.Remove(item.Text);
                ImagePreviews.Remove(item.Text);
                indices.Add(item.Index);
            }            
            foreach (int index in indices)
            {
                listViewImages.Items.RemoveAt(index);
            }            
            CheckImageCount();
        }

        private void RemoveImageButton_Click(object sender, EventArgs e)
        {
            RemoveImage();
        }

        private void OutputDirButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
        }
    }
}
