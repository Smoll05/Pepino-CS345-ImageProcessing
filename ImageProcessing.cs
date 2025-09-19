namespace ImageProcessing
{
    public partial class ImageProcessing : Form
    {
        ImageManagementService imageManagementService;
        ImageProcessingService imageProcessingService;
        bool hasImageLoaded;
        bool hasImageEdited;
        bool isCreatingHistogram;

        public ImageProcessing()
        {
            InitializeComponent();
            imageManagementService = new ImageManagementService(
                originalImagePicture, editedImagePicture, histogramPlot
            );

            imageProcessingService = new ImageProcessingService();
            hasImageLoaded = false;
            hasImageEdited = false;
            isCreatingHistogram = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hasImageLoaded = imageManagementService.LoadImage();
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hasImageEdited)
            {
                if (imageManagementService.SaveImage(isCreatingHistogram))
                {
                    MessageBox.Show("Image Saved Successfully!");
                }
            }
            else
            {
                MessageBox.Show("No Edited Image To Save!");
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
            hasImageEdited      = isCreatingHistogram;
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
    }
}
