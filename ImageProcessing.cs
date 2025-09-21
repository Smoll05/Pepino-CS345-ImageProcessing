namespace ImageProcessing
{
    public partial class ImageProcessing : Form
    {
        ImageManagementService imageManagementService;
        ImageProcessingService imageProcessingService;
        bool hasImageLoaded;
        bool hasImageEdited;
        bool hasBackgroundLoaded;
        bool isCreatingHistogram;

        // 1 - Normal Edit
        // 2 - Subtract Edit
        // 3 - WebCam Subtract
        int panelNumberShown;

        public ImageProcessing()
        {
            InitializeComponent();

            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(subPanel1);
            subtractImageToolStripMenuItem.Visible = false;
            subtractWebcamToolStripMenuItem.Visible = false;
            loadOriginalToolStripMenuItem.Visible = false;
            loadBackgroundToolStripMenuItem.Visible = false;
            panelNumberShown = 1;

            imageManagementService = new ImageManagementService();
            imageProcessingService = new ImageProcessingService();
            hasImageLoaded = false;
            hasImageEdited = false;
            isCreatingHistogram = false;
            panelNumberShown = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 1)
            {
                hasImageLoaded = imageManagementService.LoadImage(originalImagePicture);
            }
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!hasImageEdited)
            {
                MessageBox.Show("No Edited Image To Save!");
                return;
            }

            if (panelNumberShown == 1)
            {
                if (isCreatingHistogram)
                {
                    if (imageManagementService.SaveHistogram(histogramPlot))
                    {
                        MessageBox.Show("Histogram Saved Successfully!");
                    }
                }
                else
                {
                    if (imageManagementService.SaveImage(editedImagePicture))
                    {
                        MessageBox.Show("Image Saved Successfully!");
                    }
                }

                return;
            }

            if (panelNumberShown == 2)
            {
                if (imageManagementService.SaveImage(subtractResultPicture))
                {
                    MessageBox.Show("Image Saved Successfully!");
                }
            }
        }

        private void copyStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!hasImageLoaded)
            {
                MessageBox.Show("Load An Image First!");
                return;
            }

            Image editedImage = imageProcessingService.CopyImage(originalImagePicture.Image);
            if (editedImage != null)
            {
                editedImagePicture.Image = editedImage;
                editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                hasImageEdited = true;
            }
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!hasImageLoaded)
            {
                MessageBox.Show("Load An Image First!");
                return;
            }

            Image editedImage = imageProcessingService.GreyScaleImage(originalImagePicture.Image);
            if (editedImage != null)
            {
                editedImagePicture.Image = editedImage;
                editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                hasImageEdited = true;
            }
        }

        private void inverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!hasImageLoaded)
            {
                MessageBox.Show("Load An Image First!");
                return;
            }

            Image editedImage = imageProcessingService.InvertImage(originalImagePicture.Image);
            if (editedImage != null)
            {
                editedImagePicture.Image = editedImage;
                editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                hasImageEdited = true;
            }
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!hasImageLoaded)
            {
                MessageBox.Show("Load An Image First!");
                return;
            }

            isCreatingHistogram = imageProcessingService.HistogramPlot(originalImagePicture.Image, histogramPlot);
            hasImageEdited = isCreatingHistogram;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!hasImageLoaded)
            {
                MessageBox.Show("Load An Image First!");
                return;
            }

            Image editedImage = imageProcessingService.SepiaImage(originalImagePicture.Image);
            if (editedImage != null)
            {
                editedImagePicture.Image = editedImage;
                editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                hasImageEdited = true;
            }
        }

        private void intensityBar_Scroll(object sender, EventArgs e)
        {
            int intensityFactor = intensityBar.Value;
            if (hasImageLoaded)
            {
                Image editedImage = imageProcessingService.GreyScaleImage(originalImagePicture.Image, intensityFactor);
                if (editedImage != null)
                {
                    editedImagePicture.Image = editedImage;
                    editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    hasImageEdited = true;
                }
            }
        }

        private void hideIntesnityBar_Click(object sender, EventArgs e)
        {
            intensityBarPanel.Visible = false;
        }

        private void showIntesnityBar_Click(object sender, EventArgs e)
        {
            intensityBar.Value = 50;
            intensityBarPanel.Visible = true;
        }

        private void showHistogramChart_Click(object sender, EventArgs e)
        {
            histogramPanel.Visible = true;
            resultImagePanel.Visible = false;
        }

        private void hideHistogramChart_Click(object sender, EventArgs e)
        {
            histogramPanel.Visible = false;
            resultImagePanel.Visible = true;
        }

        private void normalEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelNumberShown = 1;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(subPanel1);
            subtractImageToolStripMenuItem.Visible = false;
            subtractWebcamToolStripMenuItem.Visible = false;
            loadOriginalToolStripMenuItem.Visible = false;
            loadBackgroundToolStripMenuItem.Visible = false;
            editImageToolStripMenuItem.Visible = true;
        }

        private void subtractEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelNumberShown = 2;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(subPanel2);
            loadOriginalToolStripMenuItem.Visible = true;
            loadBackgroundToolStripMenuItem.Visible = true;
            editImageToolStripMenuItem.Visible = false;
            subtractImageToolStripMenuItem.Visible = true;
        }

        private void webcamSubtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelNumberShown = 3;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(subPanel3);
            loadOriginalToolStripMenuItem.Visible = false;
            loadBackgroundToolStripMenuItem.Visible = false;
            editImageToolStripMenuItem.Visible = false;
            subtractWebcamToolStripMenuItem.Visible = true;
        }

        private void loadOriginalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hasImageLoaded = imageManagementService.LoadImage(subtractImagePicture);
        }

        private void loadBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hasBackgroundLoaded = imageManagementService.LoadImage(subtractBackgroundPicture);
        }

        private void subtractImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!hasImageLoaded || !hasBackgroundLoaded)
            {
                MessageBox.Show("Load Both An Image And A Background First!");
                return;
            }

            Image editedImage = imageProcessingService.SubtractImage(subtractImagePicture.Image, subtractBackgroundPicture.Image);
            if (editedImage != null)
            {
                subtractResultPicture.Image = editedImage;
                subtractResultPicture.SizeMode = PictureBoxSizeMode.Zoom;
                hasImageEdited = true;
            }
        }
    }
}
