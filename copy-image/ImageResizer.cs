using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace copy_image
{
    internal class ImageResizer
    {
        public static int[] ImageNewSize(Image originalImage, int maxWidth, int maxHeight)
        {
            int[] size = new int[2] { originalImage.Width, originalImage.Height };
            // 檢查圖片是否需要調整大小
            if (originalImage.Width <= maxWidth && originalImage.Height <= maxHeight)
            {
                return size; // 圖片已在限制範圍內，無需調整
            }
            // 計算新的圖片大小
            double ratioX = (double)maxWidth / originalImage.Width;
            double ratioY = (double)maxHeight / originalImage.Height;
            double ratio = Math.Min(ratioX, ratioY);

            size[0] = (int)(originalImage.Width * ratio);
            size[1] = (int)(originalImage.Height * ratio);
            return size;
        }

        public static Image ResizeImage(Image originalImage, int newWidth, int newHeight)
        {
            // 建立新的圖片物件
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }
    }
}
