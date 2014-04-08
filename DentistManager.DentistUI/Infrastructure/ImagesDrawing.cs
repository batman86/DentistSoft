using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using DentistManager.Domain.Common;
using DentistManager.Domain.DAL.Concrete;
using DentistManager.Domain.ViewModel;

namespace DentistManager.DentistUI.Infrastructure
{
    public class ImagesDrawing
    {



        int smallSize = 50, mediumWidth = 150, mediumHeight = 200, largeWidth = 200, largeHeight = 250;

        private string getValidImageName(string serverPath)
        {
            PatientRepository pr = new PatientRepository();
            GeneratRandomValue randomValue = new GeneratRandomValue();

            string imageName = randomValue.generatRandomValue();
            string imagePath = ImagePathMaker(serverPath, imageName, ImageSize.large);

            while (pr.checkIfImagePathExist(imagePath))
            {
                imageName = randomValue.generatRandomValue();
                imagePath = ImagePathMaker(serverPath, imageName, ImageSize.large);
            }

            return imageName;
        }

        public void PatientImageSaver(Image image, string serverPath, string PathForDB, ImagesViewModel imageViewModel)
        {
            string imageName = getValidImageName(serverPath);
            string pathHolder = string.Empty;
            string pathHolderDB = string.Empty;
            bool check = false;

            pathHolder = ImagePathMaker(serverPath, imageName, ImageSize.large);
            pathHolderDB = ImagePathMaker(PathForDB, imageName, ImageSize.large);
            imageViewModel.FullImageURL = pathHolderDB;
            DrawingFullImage(pathHolder, image);

            pathHolder = ImagePathMaker(serverPath, imageName, ImageSize.medium);
            pathHolderDB = ImagePathMaker(PathForDB, imageName, ImageSize.medium);
            imageViewModel.MediumImageURL = pathHolderDB;
            Drawing(mediumWidth, mediumHeight, pathHolder, image);

            pathHolder= ImagePathMaker(serverPath, imageName, ImageSize.small);
            pathHolderDB = ImagePathMaker(PathForDB, imageName, ImageSize.small);
            imageViewModel.MinImageURL = pathHolderDB;
            Drawing(smallSize, smallSize, pathHolder, image);

            image.Dispose();

            imageViewModel.LocalImageURL = "NA";
            PatientRepository pr = new PatientRepository();
            check = pr.addNewPatinetImages(imageViewModel);
        }

        private string ImagePathMaker(string serverPath, string imageName, ImageSize imageSize)
        {
            return serverPath + "/"+ imageSize.ToString() + "/" + imageName + "." + ImageExtension.jpeg;
        }

        private void DrawingFullImage(string SaveingPath, System.Drawing.Image img)
        {
            try
            {
                img.Save(SaveingPath, System.Drawing.Imaging.ImageFormat.Bmp);

            }
            catch
            { }
        }
        private void Drawing(int bitmapWidth, int bitmapHeight, string SaveingPath, System.Drawing.Image img)
        {
            Bitmap bit = new Bitmap(bitmapWidth, bitmapHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            try
            {
                Graphics gr = Graphics.FromImage(bit);
                gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                gr.DrawImage(img, 0, 0, bitmapWidth, bitmapHeight);

                foreach (int s in bit.PropertyIdList)
                    bit.RemovePropertyItem(s);

                bit.Save(SaveingPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                bit.Dispose();

                gr.Dispose();
            }
            catch
            { }
            finally
            {
                bit.Dispose();
            }
        }

        public void deleteMovieImage(string serverPath, string imageName)
        {
            System.IO.File.Delete(serverPath + "/PatientImages/" + ImageSize.large + "/" + imageName + "." + ImageExtension.jpeg);

        }
    }
}