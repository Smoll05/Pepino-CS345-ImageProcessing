using ScottPlot.TickGenerators.TimeUnits;

namespace ImageProcessing
{
    public partial class ImageProcessing : Form
    {
        ImageManagementService imageManagementService;
        WebcamManager webcamManager;
        bool hasImageLoaded;
        bool hasImageEdited;
        bool hasBackgroundLoaded;
        bool isCreatingHistogram;
        bool isCameraStarted;

        // 1 - Normal Edit
        // 2 - Subtract Edit
        // 3 - WebCam Subtract
        int panelNumberShown;

        public static FilterType CurrentImageFilter { get; set; } = FilterType.None;
        public static FilterType CurrentCamFilter { get; set; } = FilterType.None;

        public ImageProcessing()
        {
            InitializeComponent();

            cameraComboBox.Items.Insert(0, "-- None --");
            cameraComboBox.SelectedIndex = 0;
            cameraComboBox.SelectedIndexChanged += cameraComboBox_SelectedIndexChanged;

            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(subPanel1);
            subtractImageToolStripMenuItem.Visible = false;
            loadOriginalToolStripMenuItem.Visible = false;
            loadBackgroundToolStripMenuItem.Visible = false;
            subtractToolStripMenuItem.Visible = false;
            noneToolStripMenuItem.Visible = false;

            imageManagementService = new ImageManagementService();
            webcamManager = new WebcamManager(webcamDisplay);
            hasImageLoaded = false;
            hasImageEdited = false;
            isCreatingHistogram = false;
            isCameraStarted = false;
            panelNumberShown = 1;
        }

        /*
         * Form Events
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            var cameras = webcamManager.GetAvailableCameras();
            cameraComboBox.Items.AddRange(cameras.ToArray());
        }

        private void subPanel3_VisibleChange(object sender, EventArgs e)
        {
            webcamDisplay.Image = null;
        }

        private void ImageProcessing_FormClosing(object sender, FormClosingEventArgs e)
        {
            webcamManager.closeCamera();
            webcamManager = null;
        }

        /*
         * Image Management Service Calls
         */
        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 1)
            {
                hasImageLoaded = imageManagementService.LoadImage(originalImagePicture);
            }
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 3)
            {
                if (!isCameraStarted)
                {
                    MessageBox.Show("Start the Camera First");
                    return;
                }

                if (imageManagementService.SaveImage(webcamDisplay))
                {
                    MessageBox.Show("Image Saved!");
                }
                return;
            }

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
            }
            else if (panelNumberShown == 2)
            {
                if (imageManagementService.SaveImage(editedImagePicture))
                {
                    MessageBox.Show("Image Saved Successfully!");
                }
            }
        }


        /*
         * Image Processing Service Calls
         */
        private void copyStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!hasImageLoaded)
            {
                MessageBox.Show("Load An Image First!");
                return;
            }

            Image editedImage = ImageProcessingService.CopyImage(originalImagePicture.Image);
            if (editedImage != null)
            {
                editedImagePicture.Image = editedImage;
                editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                hasImageEdited = true;
                CurrentImageFilter = FilterType.Copy;
            }
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 1)
            {
                if (!hasImageLoaded)
                {
                    MessageBox.Show("Load An Image First!");
                    return;
                }

                Image editedImage = ImageProcessingService.GreyScaleImage(originalImagePicture.Image);
                if (editedImage != null)
                {
                    editedImagePicture.Image = editedImage;
                    editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    hasImageEdited = true;
                    CurrentImageFilter = FilterType.Grayscale;
                }
            }
            else if (panelNumberShown == 3)
            {
                if (!isCameraStarted)
                {
                    MessageBox.Show("Start the Camera First");
                    return;
                }

                CurrentCamFilter = FilterType.Grayscale;
            }
        }

        private void inverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 1)
            {
                if (!hasImageLoaded)
                {
                    MessageBox.Show("Load An Image First!");
                    return;
                }

                Image editedImage = ImageProcessingService.InvertImage(originalImagePicture.Image);
                if (editedImage != null)
                {
                    editedImagePicture.Image = editedImage;
                    editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    hasImageEdited = true;
                }

                CurrentImageFilter = FilterType.Invert;
            }
            else if (panelNumberShown == 3)
            {
                if (!isCameraStarted)
                {
                    MessageBox.Show("Start the Camera First");
                    return;
                }

                CurrentCamFilter = FilterType.Invert;
            }
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!hasImageLoaded)
            {
                MessageBox.Show("Load An Image First!");
                return;
            }

            isCreatingHistogram = ImageProcessingService.HistogramPlot(originalImagePicture.Image, histogramPlot);
            hasImageEdited = isCreatingHistogram;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 1)
            {
                if (!hasImageLoaded)
                {
                    MessageBox.Show("Load An Image First!");
                    return;
                }

                Image editedImage = ImageProcessingService.SepiaImage(originalImagePicture.Image);
                if (editedImage != null)
                {
                    editedImagePicture.Image = editedImage;
                    editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    hasImageEdited = true;
                    CurrentImageFilter = FilterType.Sepia;
                }
            }
            else if (panelNumberShown == 3)
            {
                if (!isCameraStarted)
                {
                    MessageBox.Show("Start the Camera First");
                    return;
                }

                CurrentCamFilter = FilterType.Sepia;
            }
        }
        private void loadOriginalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hasImageLoaded = imageManagementService.LoadImage(subtractImagePicture);
        }
        private void loadBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hasBackgroundLoaded = imageManagementService.LoadImage(subtractBackgroundPicture);
        }


        /*
         *  Tools Menu Calls
         */
        private void normalEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(subPanel1);

            panelNumberShown = 1;
            subtractImageToolStripMenuItem.Visible = false;
            loadOriginalToolStripMenuItem.Visible = false;
            loadBackgroundToolStripMenuItem.Visible = false;
            editImageToolStripMenuItem.Visible = true;
            subtractToolStripMenuItem.Visible = false;
            copyStripMenuItem.Visible = true;
            noneToolStripMenuItem.Visible = false;

            if (isCameraStarted)
            {
                webcamManager.StopCamera();
                cameraButton.Text = "Start Camera";
                isCameraStarted = false;
            }
        }

        private void subtractEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(subPanel2);

            panelNumberShown = 2;
            loadOriginalToolStripMenuItem.Visible = true;
            loadBackgroundToolStripMenuItem.Visible = true;
            editImageToolStripMenuItem.Visible = false;
            subtractImageToolStripMenuItem.Visible = true;
            subtractToolStripMenuItem.Visible = false;
            noneToolStripMenuItem.Visible = false;

            if (isCameraStarted)
            {
                webcamManager.StopCamera();
                cameraButton.Text = "Start Camera";
                isCameraStarted = false;
            }
        }

        private void webcamSubtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(subPanel3);

            panelNumberShown = 3;
            loadOriginalToolStripMenuItem.Visible = false;
            loadBackgroundToolStripMenuItem.Visible = false;
            editImageToolStripMenuItem.Visible = true;
            subtractToolStripMenuItem.Visible = false;
            subtractImageToolStripMenuItem.Visible = false;
            copyStripMenuItem.Visible = false;
            histogramToolStripMenuItem.Visible = false;
            noneToolStripMenuItem.Visible = true;
        }

        private void smoothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 1)
            {
                if (!hasImageLoaded)
                {
                    MessageBox.Show("Load An Image First!");
                    return;
                }

                Image editedImage = ImageProcessingService.Smooth(originalImagePicture.Image);
                if (editedImage != null)
                {
                    editedImagePicture.Image = editedImage;
                    editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    hasImageEdited = true;
                    CurrentImageFilter = FilterType.Smooth;
                }
            }
            else if (panelNumberShown == 3)
            {
                if (!isCameraStarted)
                {
                    MessageBox.Show("Start the Camera First");
                    return;
                }

                CurrentCamFilter = FilterType.Smooth;
            }
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 1)
            {
                if (!hasImageLoaded)
                {
                    MessageBox.Show("Load An Image First!");
                    return;
                }

                Image editedImage = ImageProcessingService.GaussianBlur(originalImagePicture.Image);
                if (editedImage != null)
                {
                    editedImagePicture.Image = editedImage;
                    editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    hasImageEdited = true;
                    CurrentImageFilter = FilterType.GaussianBlur;
                }
            }
            else if (panelNumberShown == 3)
            {
                if (!isCameraStarted)
                {
                    MessageBox.Show("Start the Camera First");
                    return;
                }

                CurrentCamFilter = FilterType.GaussianBlur;
            }
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 1)
            {
                if (!hasImageLoaded)
                {
                    MessageBox.Show("Load An Image First!");
                    return;
                }

                Image editedImage = ImageProcessingService.Sharpen(originalImagePicture.Image);
                if (editedImage != null)
                {
                    editedImagePicture.Image = editedImage;
                    editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    hasImageEdited = true;
                    CurrentImageFilter = FilterType.Sharpen;
                }
            }
            else if (panelNumberShown == 3)
            {
                if (!isCameraStarted)
                {
                    MessageBox.Show("Start the Camera First");
                    return;
                }

                CurrentCamFilter = FilterType.Sharpen;
            }
        }

        private void meanRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 1)
            {
                if (!hasImageLoaded)
                {
                    MessageBox.Show("Load An Image First!");
                    return;
                }

                Image editedImage = ImageProcessingService.MeanRemoval(originalImagePicture.Image);
                if (editedImage != null)
                {
                    editedImagePicture.Image = editedImage;
                    editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    hasImageEdited = true;
                    CurrentImageFilter = FilterType.MeanRemoval;
                }
            }
            else if (panelNumberShown == 3)
            {
                if (!isCameraStarted)
                {
                    MessageBox.Show("Start the Camera First");
                    return;
                }

                CurrentCamFilter = FilterType.MeanRemoval;
            }
        }

        private void laplacianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 1)
            {
                if (!hasImageLoaded)
                {
                    MessageBox.Show("Load An Image First!");
                    return;
                }

                Image editedImage = ImageProcessingService.EmbossLaplascian(originalImagePicture.Image);
                if (editedImage != null)
                {
                    editedImagePicture.Image = editedImage;
                    editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    hasImageEdited = true;
                    CurrentImageFilter = FilterType.EmbossLaplascian;
                }
            }
            else if (panelNumberShown == 3)
            {
                if (!isCameraStarted)
                {
                    MessageBox.Show("Start the Camera First");
                    return;
                }

                CurrentCamFilter = FilterType.EmbossLaplascian;
            }
        }

        private void horizontalVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 1)
            {
                if (!hasImageLoaded)
                {
                    MessageBox.Show("Load An Image First!");
                    return;
                }

                Image editedImage = ImageProcessingService.EmbossHorizontalAndVertical(originalImagePicture.Image);
                if (editedImage != null)
                {
                    editedImagePicture.Image = editedImage;
                    editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    hasImageEdited = true;
                    CurrentImageFilter = FilterType.EmbossHorizontalVertical;
                }
            }
            else if (panelNumberShown == 3)
            {
                if (!isCameraStarted)
                {
                    MessageBox.Show("Start the Camera First");
                    return;
                }

                CurrentCamFilter = FilterType.EmbossHorizontalVertical;
            }
        }

        private void allDirectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 1)
            {
                if (!hasImageLoaded)
                {
                    MessageBox.Show("Load An Image First!");
                    return;
                }

                Image editedImage = ImageProcessingService.EmbossAll(originalImagePicture.Image);
                if (editedImage != null)
                {
                    editedImagePicture.Image = editedImage;
                    editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    hasImageEdited = true;
                    CurrentImageFilter = FilterType.EmbossAll;
                }
            }
            else if (panelNumberShown == 3)
            {
                if (!isCameraStarted)
                {
                    MessageBox.Show("Start the Camera First");
                    return;
                }

                CurrentCamFilter = FilterType.EmbossAll;
            }
        }

        private void lossyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 1)
            {
                if (!hasImageLoaded)
                {
                    MessageBox.Show("Load An Image First!");
                    return;
                }

                Image editedImage = ImageProcessingService.EmbossLossy(originalImagePicture.Image);
                if (editedImage != null)
                {
                    editedImagePicture.Image = editedImage;
                    editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    hasImageEdited = true;
                    CurrentImageFilter = FilterType.EmbossLossy;
                }
            }
            else if (panelNumberShown == 3)
            {
                if (!isCameraStarted)
                {
                    MessageBox.Show("Start the Camera First");
                    return;
                }

                CurrentCamFilter = FilterType.EmbossLossy;
            }
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 1)
            {
                if (!hasImageLoaded)
                {
                    MessageBox.Show("Load An Image First!");
                    return;
                }

                Image editedImage = ImageProcessingService.EmbossHorizontal(originalImagePicture.Image);
                if (editedImage != null)
                {
                    editedImagePicture.Image = editedImage;
                    editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    hasImageEdited = true;
                    CurrentImageFilter = FilterType.EmbossHorizontal;
                }
            }
            else if (panelNumberShown == 3)
            {
                if (!isCameraStarted)
                {
                    MessageBox.Show("Start the Camera First");
                    return;
                }

                CurrentCamFilter = FilterType.EmbossHorizontal;
            }
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 1)
            {
                if (!hasImageLoaded)
                {
                    MessageBox.Show("Load An Image First!");
                    return;
                }

                Image editedImage = ImageProcessingService.EmbossVertical(originalImagePicture.Image);
                if (editedImage != null)
                {
                    editedImagePicture.Image = editedImage;
                    editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    hasImageEdited = true;
                    CurrentImageFilter = FilterType.EmbossVertical;
                }
            }
            else if (panelNumberShown == 3)
            {
                if (!isCameraStarted)
                {
                    MessageBox.Show("Start the Camera First");
                    return;
                }

                CurrentCamFilter = FilterType.EmbossVertical;
            }
        }


        /*
         *  UI Calls
         */
        private void intensityBar_Scroll(object sender, EventArgs e)
        {
            int intensityFactor = intensityBar.Value;
            if (hasImageLoaded)
            {
                Bitmap bitmap = new Bitmap(originalImagePicture.Image);
                Image editedImage = (Image)ImageProcessingService.GreyScaleImage(bitmap, intensityFactor);
                if (editedImage != null)
                {
                    editedImagePicture.Image = editedImage;
                    editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    hasImageEdited = true;
                }
            }
        }

        private void showIntesnityBar_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;
            string filterName = clickedItem.Text;

            if (filterName == "Greyscale")
            {
                intensityBar.Value = 50;
                intensityBarPanel.Visible = true;
            }
            else
            {
                intensityBarPanel.Visible = false;
            }
        }

        private void showHistogramChart_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;
            string filterName = clickedItem.Text;

            if (filterName != "Histogram")
            {
                histogramPanel.Visible = false;
                resultImagePanel.Visible = true;
                isCreatingHistogram = false;
                return;
            }
            else
            {
                histogramPanel.Visible = true;
                resultImagePanel.Visible = false;
                isCreatingHistogram = true;
            }
        }

        private void subtractImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!hasImageLoaded || !hasBackgroundLoaded)
            {
                MessageBox.Show("Load Both An Image And A Background First!");
                return;
            }

            Image editedImage = ImageProcessingService.SubtractImage(subtractImagePicture.Image, subtractBackgroundPicture.Image);
            if (editedImage != null)
            {
                subtractResultPicture.Image = editedImage;
                subtractResultPicture.SizeMode = PictureBoxSizeMode.Zoom;
                hasImageEdited = true;
            }
        }

        /*
         *  Camera Calls
         */
        private void cameraButton_Click(object sender, EventArgs e)
        {
            if (isCameraStarted)
            {
                webcamManager.StopCamera();
                cameraButton.Text = "Start Camera";
                isCameraStarted = false;

                if (webcamDisplay.Image != null)
                {
                    webcamDisplay.Image.Dispose();
                    webcamDisplay.Image = null;
                }
            }
            else
            {
                if (isCameraStarted = webcamManager.StartCamera())
                    cameraButton.Text = "Stop Camera";
            }
        }

        private void cameraComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            webcamManager.StopCamera();
            cameraButton.Text = "Start Camera";
            webcamManager.InitializeCamera(cameraComboBox.Text);
        }


        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!isCameraStarted)
            {
                MessageBox.Show("Start the Camera First");
                return;
            }

            CurrentCamFilter = FilterType.None;
        }
    }
}