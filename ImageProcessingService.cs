using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    internal class ImageProcessingService
    {
        public Image CopyImage(Image originalImage)
        {
            try
            {
                Bitmap originalBitmap   = new Bitmap(originalImage);
                Bitmap copiedBitmap     = new Bitmap(originalBitmap.Width, originalBitmap.Height);

                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    for (int x = 0; x < originalBitmap.Width; x++)
                    {
                        Color pixel = originalBitmap.GetPixel(x, y);
                        copiedBitmap.SetPixel(x, y, pixel);
                    }
                }

                return (Image)copiedBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error copying image: " + ex.Message);
            }

            return null;
        }

        public Image GreyScaleImage(Image originalImage, int intensityFactor = 50)
        {
            try
            {
                Bitmap originalBitmap   = new Bitmap(originalImage);
                Bitmap greyScaleBitmap  = new Bitmap(originalBitmap.Width, originalBitmap.Height);

                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    for (int x = 0; x < originalBitmap.Width; x++)
                    {
                        Color pixel = originalBitmap.GetPixel(x, y);
                        int greyValue = (pixel.R + pixel.G + pixel.B) / 3;
                        double scale = intensityFactor / 50.0;
                        greyValue = (int)(greyValue * scale);
                        greyValue = greyValue > 255 ? 255 : greyValue;
                        Color greyPixel = Color.FromArgb(greyValue, greyValue, greyValue);
                        greyScaleBitmap.SetPixel(x, y, greyPixel);
                    }
                }

                return (Image)greyScaleBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying greyscale: " + ex.Message);
            }

            return null;
        }

        public Image InvertImage(Image originalImage)
        {
            try
            {
                Bitmap originalBitmap = new Bitmap(originalImage);
                Bitmap invertedBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    for (int x = 0; x < originalBitmap.Width; x++)
                    {
                        Color pixel = originalBitmap.GetPixel(x, y);
                        Color greyPixel = Color.FromArgb(255-pixel.R, 255 - pixel.G, 255 - pixel.B);
                        invertedBitmap.SetPixel(x, y, greyPixel);
                    }
                }

                return (Image)invertedBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inverting image: " + ex.Message);
            }

            return null;
        }

        public bool HistogramPlot(Image originalImage, ScottPlot.WinForms.FormsPlot histogramPlot)
        {
            try
            {
                Bitmap grayBitmap = (Bitmap)GreyScaleImage(originalImage);
                int[] histogram = new int[256];

                for (int y = 0; y < grayBitmap.Height; y++)
                {
                    for (int x = 0; x < grayBitmap.Width; x++)
                    {
                        Color pixel = grayBitmap.GetPixel(x, y);
                        histogram[pixel.R]++;
                    }
                }

                double[] counts = Array.ConvertAll(histogram, i => (double)i);
                double[] bins   = Enumerable.Range(0, 256).Select(i => (double)i).ToArray();

                var hist = ScottPlot.Statistics.Histogram.WithBinSize(1, bins);

                histogramPlot.Plot.Clear();

                var barPlot = histogramPlot.Plot.Add.Bars(bins, counts);

                foreach (var bar in barPlot.Bars)
                {
                    bar.Size = hist.FirstBinSize;
                    bar.LineWidth = 0;
                    bar.FillStyle.AntiAlias = false;
                    bar.FillColor = ScottPlot.Color.FromColor(Color.Gray);
                }

                histogramPlot.Plot.Axes.Margins(bottom: 0);
                histogramPlot.Refresh();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating histogram: " + ex.Message);
            }

            return false;
        }

        public Image SepiaImage(Image originalImage)
        {
            try
            {
                Bitmap originalBitmap = new Bitmap(originalImage);
                Bitmap sepiaBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    for (int x = 0; x < originalBitmap.Width; x++)
                    {
                        Color pixel = originalBitmap.GetPixel(x, y);

                        int sepiaRed    = (int)(.393 * pixel.R + .769 * pixel.G + .189 * pixel.B);
                        int sepiaGreen  = (int)(.349 * pixel.R + .686 * pixel.G + .168 * pixel.B);
                        int sepiaBlue   = (int)(.272 * pixel.R + .534 * pixel.G + .131 * pixel.B);

                        sepiaRed    = sepiaRed > 255 ? 255 : sepiaRed;
                        sepiaGreen  = sepiaGreen > 255 ? 255 : sepiaGreen;
                        sepiaBlue   = sepiaBlue > 255 ? 255 : sepiaBlue;

                        Color greyPixel = Color.FromArgb(sepiaRed, sepiaGreen, sepiaBlue);
                        sepiaBitmap.SetPixel(x, y, greyPixel);
                    }
                }

                return (Image)sepiaBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inverting image: " + ex.Message);
            }
            return null;
        }
    }
}
