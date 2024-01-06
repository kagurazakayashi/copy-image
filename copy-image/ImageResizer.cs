using System;
using System.Drawing;

namespace copy_image
{
    // 圖片尺寸調整類
    internal class ImageResizer
    {
        // 定義一個靜態方法來計算圖片的新尺寸，以符合最大寬度和高度的限制
        public static int[] ImageNewSize(Image originalImage, int maxWidth, int maxHeight)
        {
            // 初始化一個整數陣列來儲存新的寬度和高度值
            int[] size = new int[2] { originalImage.Width, originalImage.Height };
            // 檢查原始圖片的寬度和高度是否已經小於或等於最大限制，如果是，則直接返回原始尺寸
            if (originalImage.Width <= maxWidth && originalImage.Height <= maxHeight)
            {
                return size; // 圖片已經符合最大尺寸限制，不需要調整
            }
            // 計算寬度和高度的縮放比例，以保持圖片比例不變
            double ratioX = (double)maxWidth / originalImage.Width;
            double ratioY = (double)maxHeight / originalImage.Height;
            // 選擇較小的縮放比例作為最終縮放比例，以確保圖片能夠完全顯示在指定的最大尺寸內
            double ratio = Math.Min(ratioX, ratioY);

            // 根據計算出的縮放比例調整圖片的寬度和高度
            size[0] = (int)(originalImage.Width * ratio);
            size[1] = (int)(originalImage.Height * ratio);
            // 返回新的尺寸
            return size;
        }

        // 定義一個靜態方法來調整圖片的尺寸到指定的新寬度和高度
        public static Image ResizeImage(Image originalImage, int newWidth, int newHeight)
        {
            // 建立一個新的Bitmap物件作為調整大小後的圖片
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            // 使用Graphics物件來處理圖片繪製
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                // 將原始圖片繪製到新圖片上，並調整到新的尺寸
                graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }
            // 返回調整大小後的圖片物件
            return newImage;
        }
    }

}
