using ScottPlot.WinForms;

namespace ImageProcessing
{
    internal class ImageManagementService
    {

        public bool LoadImage(PictureBox pictureBox)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select an image";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var img = Image.FromFile(ofd.FileName);
                        pictureBox.Image = img;
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message);
                    }
                }
                return false;
            }
        }

        public bool SaveImage(PictureBox pictureBox)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Save Image As";
                sfd.Filter = "JPEG Image|*.jpg;*.jpeg|PNG Image|*.png|Bitmap Image|*.bmp|GIF Image|*.gif";
                sfd.DefaultExt = "jpg";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var format = System.Drawing.Imaging.ImageFormat.Jpeg;
                        switch (sfd.FilterIndex)
                        {
                            case 1: format = System.Drawing.Imaging.ImageFormat.Jpeg; break;
                            case 2: format = System.Drawing.Imaging.ImageFormat.Png; break;
                            case 3: format = System.Drawing.Imaging.ImageFormat.Bmp; break;
                            case 4: format = System.Drawing.Imaging.ImageFormat.Gif; break;
                        }
                        pictureBox.Image.Save(sfd.FileName, format);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Saving Image: " + ex.Message);
                    }
                }
            }
            return false;
        }

        public bool SaveHistogram(FormsPlot histogramPlot)
        {
            if (histogramPlot.Plot == null)
            {
                MessageBox.Show("No Edited Plot To Save!");
                return false;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Save Image As";
                sfd.Filter = "JPEG Image|*.jpg;*.jpeg|PNG Image|*.png|Bitmap Image|*.bmp|SVG Image|*.svg";
                sfd.DefaultExt = "jpg";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        switch (sfd.FilterIndex)
                        {
                            case 1: histogramPlot.Plot.SaveJpeg(sfd.FileName, 800, 800); break;
                            case 2: histogramPlot.Plot.SavePng(sfd.FileName, 800, 800); break;
                            case 3: histogramPlot.Plot.SaveBmp(sfd.FileName, 800, 800); break;
                            case 4: histogramPlot.Plot.SaveSvg(sfd.FileName, 800, 800); break;
                            default: histogramPlot.Plot.SaveJpeg(sfd.FileName, 800, 800); break;
                        }

                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Saving Image: " + ex.Message);
                    }
                }
            }
            return false;
        }
    }
}
