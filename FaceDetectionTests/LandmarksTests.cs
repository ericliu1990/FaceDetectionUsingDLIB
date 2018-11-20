using Microsoft.VisualStudio.TestTools.UnitTesting;
using FaceDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DlibDotNet;
using DlibDotNet.Extensions;
using Dlib = DlibDotNet.Dlib;
using System.Drawing;

namespace FaceDetection.Tests
{
    [TestClass()]
    public class LandmarksTests
    {
        [TestMethod()]
        [DeploymentItem(@"D:\MyProject\FaceDetection\FaceDetectionUsingDLIB\FaceDetectionTests\bin\Debug", @"D:\MyProject\FaceDetection\FaceDetectionUsingDLIB\FaceDetectionTests\bin\Debug\out")]
        public void LandmarkTest()
        {
            using (var faceDetector = FrontalFaceDetector.GetFrontalFaceDetector())
            using (var shapePredictor = new ShapePredictor(Configuration.SHAP_PREDICTOR_CONFIG))
            {
                // convert image to dlib format
                var img = Utils.LoadImageAsBitmap("TestImage/pic01.jpg").ToArray2D<RgbPixel>();

                // detect faces
                var faces = faceDetector.Detect(img);

                // detect facial landmarks
                foreach (var rect in faces)
                {
                    // detect facial landmarks
                    var shape = shapePredictor.Detect(img, rect);

                    //The left eye using landmark index[42, 47].
                    Landmarks landmarkLeftEye = new Landmarks(42, 47, shape);
                    Assert.AreEqual(landmarkLeftEye.LandMarkPointList.Count,6);
                    //index range should be 0-67
                    Landmarks landmark2 = new Landmarks(42, 68, shape);
                    
                }
            }
        }

        [TestMethod()]
        public void GetLandmarkRectangleTest()
        {
            Assert.Fail();
        }
    }
}