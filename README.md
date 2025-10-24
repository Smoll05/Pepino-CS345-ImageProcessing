# 🖼️ ImageProcessing App

A simple yet powerful **Windows Forms application** for experimenting with image processing.
This project demonstrates common image editing techniques and basic webcam integration using C# and .NET.

---

## ✨ Features

### 🖼 Image Editing

* 📋 **Copy** – Duplicate an image.
* ⚫ **Greyscale** – Convert images to black & white.
* 🌑 **Inverse** – Invert image colors.
* 🎨 **Sepia** – Apply a warm, vintage look.
* 📊 **Histogram** – View the intensity distribution of your image.
* ➖ **Subtract** – Perform pixel-by-pixel subtraction between two images.
* 🧮 **Convolutional Matrix Filters** – Apply advanced effects using matrix-based convolution filters:

  * 🌫 **Gaussian Blur** – Smooths the image and reduces noise.
  * 🔪 **Sharpen** – Enhances edges and fine details.
  * ⚙️ **Mean Removal** – Increases contrast by emphasizing differences in pixel intensity.
  * 💫 **Embossing (Laplacian)** – Creates a raised, 3D-like texture using the Laplacian operator.
  * ↔️ **Embossing (Horizontal/Vertical)** – Highlights edges in specific directions.
  * 🌀 **Embossing (All Directions)** – Applies multi-directional embossing for stronger texture.
  * 🧱 **Embossing (Lossy)** – Produces a stylized embossed effect with reduced detail.

You can use these filters either by **uploading a photo** or **opening the webcam** for live processing.

---

### 🎥 Webcam Support

* Open your **webcam** directly inside the app.
* Apply **Greyscale**, **Inverse**, **Sepia**, or **Convolutional Filters** in real time.
* Switch back to **Normal** view anytime.

---

### 💾 Save Your Work

* Save any edited image to your computer.
* Supports common image formats (`.png`, `.jpg`, `.bmp`, `.svg`).

---

## 🛠 Installation & Usage

1. **Download the Latest Release**
   Go to the [Releases](../../releases) section and download the latest ZIP file.

2. **Extract the Files**
   Right-click the downloaded ZIP → “Extract All…”

3. **Run the App**
   Open the extracted folder and double-click **`ImageProcessing.exe`**.

---

## 📦 Tech Stack

* **Language:** C#
* **Framework:** .NET 8 + Windows Forms
* **Libraries:** AForge.NET (for webcam support)

---

Made with ❤️ by **Carl Angelo T. Pepino** – BSCS-3 @ CIT-U
