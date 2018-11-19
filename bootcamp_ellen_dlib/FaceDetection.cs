using Accord.Video.DirectShow;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq;
using System.Windows.Forms;
using Accord.Vision.Detection;
using System.Drawing.Imaging;
using Accord.Imaging.Filters;
using DlibDotNet;
using DlibDotNet.Extensions;
using Dlib = DlibDotNet.Dlib;
using System.Collections.Generic;

namespace Bootcamp.CompVis.Ellen_Dlib
{
    public partial class FaceDetectionWindow : Form
    {
        /// <summary>
        /// Initialize MainForm.
        /// </summary>
        public FaceDetectionWindow()
        {
            InitializeComponent();
        }

        public Bitmap originalImageFromPics { get; set; }
        /// <summary>
        /// Called when MainForm loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FaceDetection_Load(object sender, EventArgs e)
        {
            //// load the input image
            //var bitmap = Bitmap.FromFile("./pic01.bmp") as Bitmap;

            //// show it
            //pictureBox.Image = bitmap;

            //// process image
            //var newBitmap = ProcessImage(bitmap);

            //// show new image
            //pictureBox.Image = newBitmap;
            if (!cbDetectFace.Checked)
            {
                cbDetectEye.Checked = false;
                cbDetectEye.Enabled = false;
                cbShowFaceLandmarks.Checked = false;
                cbShowFaceLandmarks.Enabled = false;
                pictureBox.Image = originalImageFromPics;
            }
            else
            {
                cbDetectEye.Enabled = true;
                cbShowFaceLandmarks.Enabled = true;
                pictureBox.Image = ProcessImage(originalImageFromPics);
            }
        }

        private Bitmap ProcessImage(Bitmap image)
        {
            imagesPanel.Controls.Clear();

            if (cbDetectFace.Checked && image !=null)
            {
                List<DlibDotNet.Rectangle> rectList = new List<DlibDotNet.Rectangle>();
                // set up Dlib facedetectors and shapedetectors
                using (var fd = FrontalFaceDetector.GetFrontalFaceDetector())
                using (var sp = new ShapePredictor("shape_predictor_68_face_landmarks.dat"))
                {
                    // convert image to dlib format
                    var img = image.ToArray2D<RgbPixel>();

                    // detect faces
                    var faces = fd.Detect(img);

                    // detect facial landmarks
                    foreach (var rect in faces)
                    {
                        rectList.Add(rect);
                        // detect facial landmarks
                        var shape = sp.Detect(img, rect);

                        // extract face chip

                        var chip = Dlib.GetFaceChipDetails(shape);
                        var thumbnail = Dlib.ExtractImageChips<RgbPixel>(img, chip);

                        // add picturebox
                        var box = new PictureBox()
                        {
                            Image = thumbnail.ToBitmap<RgbPixel>(),
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Width = 60,
                            Height = 60
                        };
                        imagesPanel.Controls.Add(box);

                        //The right eye using [36, 42].
                        //The left eye with[42, 48].

                        // draw landmarks on main image
                        //var lines = Dlib.RenderFaceDetections(new FullObjectDetection[] { shape });

                        if (cbShowFaceLandmarks.Checked)
                        {
                            for (uint i = 0; i < shape.Parts; i++)
                            {
                                Dlib.DrawRectangle(
                                img,
                                new DlibDotNet.Rectangle(shape.GetPart(i)),
                                new RgbPixel { Red = 255 },
                                3);
                            }
                        }

                        if (cbDetectEye.Checked)
                        {

                            int leftEyeLeft = -1;
                            int leftEyeRight = -1;
                            int leftEyeTop = -1;
                            int leftEyeBottom = -1;
                            for (uint i = 36; i < 42; i++)
                            {
                                //Dlib.DrawRectangle(
                                //    img,
                                //    new DlibDotNet.Rectangle(shape.GetPart(i)),
                                //    new RgbPixel { Green = 255 },
                                //    3);
                                leftEyeLeft = (leftEyeLeft == -1 ? shape.GetPart(i).X : Math.Min(leftEyeLeft, shape.GetPart(i).X)) - 1;
                                leftEyeRight = (leftEyeRight == -1 ? shape.GetPart(i).X : Math.Max(leftEyeRight, shape.GetPart(i).X)) + 1;
                                leftEyeTop = (leftEyeTop == -1 ? shape.GetPart(i).Y : Math.Min(leftEyeTop, shape.GetPart(i).Y)) - 1;
                                leftEyeBottom = (leftEyeBottom == -1 ? shape.GetPart(i).Y : Math.Max(leftEyeBottom, shape.GetPart(i).Y)) + 1;
                            }


                            DlibDotNet.Rectangle fitRectL =
                                new DlibDotNet.Rectangle(
                                    new DlibDotNet.Point(leftEyeLeft, leftEyeTop),
                                    new DlibDotNet.Point(leftEyeRight, leftEyeBottom));
                            Dlib.DrawRectangle(img, fitRectL, new RgbPixel { Green = 255 }, 2);

                            leftEyeLeft = -1;
                            leftEyeRight = -1;
                            leftEyeTop = -1;
                            leftEyeBottom = -1;
                            for (uint i = 42; i < 48; i++)
                            {
                                //Dlib.DrawRectangle(
                                //    img,
                                //    new DlibDotNet.Rectangle(shape.GetPart(i)),
                                //    new RgbPixel { Green = 255 },
                                //    3);

                                leftEyeLeft = (leftEyeLeft == -1 ? shape.GetPart(i).X : Math.Min(leftEyeLeft, shape.GetPart(i).X)) - 1;
                                leftEyeRight = (leftEyeRight == -1 ? shape.GetPart(i).X : Math.Max(leftEyeRight, shape.GetPart(i).X)) + 1;
                                leftEyeTop = (leftEyeTop == -1 ? shape.GetPart(i).Y : Math.Min(leftEyeTop, shape.GetPart(i).Y)) - 1;
                                leftEyeBottom = (leftEyeBottom == -1 ? shape.GetPart(i).Y : Math.Max(leftEyeBottom, shape.GetPart(i).Y)) + 1;
                            }
                            DlibDotNet.Rectangle fitRectR =
                                    new DlibDotNet.Rectangle(
                                        new DlibDotNet.Point(leftEyeLeft, leftEyeTop),
                                        new DlibDotNet.Point(leftEyeRight, leftEyeBottom));
                            Dlib.DrawRectangle(img, fitRectR, new RgbPixel { Green = 255 }, 2);
                        }
                    }
                    foreach (var rect in rectList)
                    {
                        DlibDotNet.Rectangle fitRect = new DlibDotNet.Rectangle();
                        fitRect.Right = rect.Right < img.Rect.Right ? rect.Right : img.Rect.Right;
                        fitRect.Left = rect.Left > img.Rect.Left ? rect.Left : img.Rect.Left;
                        fitRect.Top = rect.Top > img.Rect.Top ? rect.Top : img.Rect.Top;
                        fitRect.Bottom = rect.Bottom < img.Rect.Bottom ? rect.Bottom : img.Rect.Bottom;
                        Dlib.DrawRectangle(img, fitRect, new RgbPixel { Blue = 255 }, 5);
                    }
   
                    return img.ToBitmap<RgbPixel>();
                }
            }
            return image;
        }

        private void LoadImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    originalImageFromPics = Bitmap.FromFile(openFileDialog.FileName) as Bitmap;
                    //UpdatePictureBox(sender,e);
                    Bitmap cloneImage = originalImageFromPics.Clone() as Bitmap;
                    pictureBox.Image = ProcessImage(cloneImage);

                }
                catch
                {
                    MessageBox.Show("Cannot open the file.");
                }

            }
        }

        //private void UpdatePictureBox(object sender, EventArgs e)
        //{
        //    pictureBox.Image = null;
        //    loadingLabel.Text = "Loading...";
        //}
    }
}
