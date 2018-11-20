using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DlibDotNet;
using DlibDotNet.Extensions;
using Dlib = DlibDotNet.Dlib;
using System.Collections.Generic;

namespace FaceDetection
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
        /// <summary>
        /// Get the image with detected faces highlighted by the rectangle
        /// </summary>
        /// <param name="image"></param>
        /// <param name="numOfFaceDetected"></param>
        /// <returns></returns>
        public Bitmap FaceDetectionFromImage(Bitmap image, out int numOfFaceDetected)
        {
            numOfFaceDetected = 0;
            if (image !=null)
            {
                // set up Dlib facedetectors and shapedetectors
                using (var faceDetector = FrontalFaceDetector.GetFrontalFaceDetector())
                using (var shapePredictor = new ShapePredictor(Configuration.SHAP_PREDICTOR_CONFIG))
                {
                    // convert image to dlib format
                    var img = image.ToArray2D<RgbPixel>();

                    // detect faces
                    var faces = faceDetector.Detect(img);

                    // detect facial landmarks
                    foreach (var rect in faces)
                    {
                        // detect facial landmarks
                        var shape = shapePredictor.Detect(img, rect);

                        //The left eye using landmark index[42, 47].
                        Landmarks landmarkLeftEye = new Landmarks(42, 47, shape);
                        //The right eye using landmark index [36, 41].
                        Landmarks landmarkRightEye = new Landmarks(36, 41, shape);
                        //draw landmark rectangle
                        var leftEyeRect = Utils.RectangleAdjust(landmarkLeftEye.GetLandmarkRectangle(),img);
                        var rightEyeRect = Utils.RectangleAdjust(landmarkRightEye.GetLandmarkRectangle(),img);
                        var adjustedFaceRect = Utils.RectangleAdjust(rect, img);

                        Dlib.DrawRectangle(img, adjustedFaceRect, new RgbPixel { Blue = 255 }, 5);
                        Dlib.DrawRectangle(img, leftEyeRect, new RgbPixel { Green = 255 }, 2);
                        Dlib.DrawRectangle(img, rightEyeRect, new RgbPixel { Green = 255 }, 2);
                        
                    }
                    numOfFaceDetected = faces.Length;
                    return img.ToBitmap<RgbPixel>();
                }
            }
            return image;
        }
        /// <summary>
        /// Function to load the image
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">Event arguments</param>
        private void LoadImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //load image as bitmap
                    var imageAsBitmap = Utils.LoadImageAsBitmap(openFileDialog.FileName);
                    //face detection
                    int numOfFaceDetected = 0;
                    var bitmapWithDetectedResult = FaceDetectionFromImage(imageAsBitmap, out numOfFaceDetected);
                    
                    //bitmap rendering
                    pictureBox.Image = bitmapWithDetectedResult;
                    string msgBoxStr = string.Format("{0} Face(s) Detected!", numOfFaceDetected);
                    MessageBox.Show(msgBoxStr);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(string.Format("Cannot open the file : {0}",ex.Message));
                }
            }
        }
    }
}
