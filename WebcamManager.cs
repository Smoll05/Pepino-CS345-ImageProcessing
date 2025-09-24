using AForge.Video;
using AForge.Video.DirectShow;

namespace ImageProcessing
{
    internal class WebcamManager
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private PictureBox webcamDisplay;

        public FilterType CurrentFilter { get; set; } = FilterType.None;

        public WebcamManager(PictureBox webcamDisplay)
        {
            this.webcamDisplay = webcamDisplay;
        }

        public void InitializeCamera(String cameraDevice)
        {
            if (videoDevices == null || videoDevices.Count == 0)
            {
                MessageBox.Show("No camera devices found.");
                return;
            }

            var selectedDevice = videoDevices.Cast<FilterInfo>().FirstOrDefault(d => d.Name == cameraDevice);

            if (selectedDevice == null)
            {
                MessageBox.Show("Selected camera device not found.");
                videoSource = null;
                return;
            }

            videoSource = new VideoCaptureDevice(selectedDevice.MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(Video_NewFrame);
        }

        private void Video_NewFrame(object sender, NewFrameEventArgs e)
        {
            if (webcamDisplay.IsDisposed || !webcamDisplay.IsHandleCreated)
                return;

            Bitmap frame = (Bitmap)e.Frame.Clone();
            Bitmap filtered = ImageProcessingService.ApplyWebCamFilter(frame, CurrentFilter);

            if (webcamDisplay.IsHandleCreated && !webcamDisplay.IsDisposed)
            {
                webcamDisplay.BeginInvoke((Action)(() =>
                {
                    webcamDisplay.Image?.Dispose();
                    webcamDisplay.Image = filtered;
                }));
            }
            else
            {
                filtered.Dispose();
            }
        }

        public bool StartCamera()
        {
            if (videoSource != null)
            {
                videoSource.Start();
                return true;
            }
            else
            {
                MessageBox.Show("No Camera Selected");
                return false;
            }
        }

        public void StopCamera()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
            webcamDisplay.Image?.Dispose();
            webcamDisplay.Image = null;
        }

        public void closeCamera()
        {
            if (videoSource != null)
            {
                StopCamera();
                videoSource.NewFrame -= Video_NewFrame;
                videoSource = null;
            }
        }

        public List<string> GetAvailableCameras()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            List<string> cameraNames = new List<string>();
            foreach (FilterInfo device in videoDevices)
                cameraNames.Add(device.Name);

            return cameraNames;
        }
    }
}
