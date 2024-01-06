using System;
using System.Drawing;
using System.Windows.Forms;

namespace copy_image
{
    internal class AniEgg
    {
        private double positionY = 0; // 當前位置Y軸座標
        private double velocityY = 0; // 當前Y軸速度
        private readonly double bounceFactor = 0.9; // 彈跳係數，控制彈跳時的能量損耗
        private readonly double gravity = 1; // 重力加速度，模擬重力對物體的影響
        private readonly int ground; // 地面位置，即窗體底部的Y軸座標
        private int runTime = 0; // 已運行時間，用於控制動畫運行時間
        private readonly int runStop = 15000; // 動畫停止時間，設定動畫執行的最大時限
        private bool dragging = false; // 是否正在拖曳標誌
        private Point dragCursorPoint; // 拖曳時，鼠標的初始位置
        private Point dragFormPoint; // 拖曳時，控制元件的初始位置
        private PictureBox box; // 圖片框控制元件，用於顯示動畫效果
        private Timer timer; // 定時器控制元件，用於控制動畫的更新頻率

        public AniEgg(int clientHeight, PictureBox box, Timer timer)
        {
            this.box = box; // 初始化圖片框控制元件
            this.box.Cursor = Cursors.PanSouth; // 設定鼠標在圖片框上的樣式
                                                //this.box.BorderStyle = BorderStyle.Fixed3D; // 設定圖片框的邊框樣式，此行已註解
            ground = clientHeight - this.box.Height; // 計算地面位置
            this.timer = timer; // 初始化定時器控制元件
            this.timer.Start(); // 啟動定時器，開始動畫
        }

        public void Tick()
        {
            runTime += timer.Interval; // 更新已運行時間
            velocityY += gravity; // 模擬重力對速度的影響
            positionY += velocityY; // 更新位置
            if (positionY >= ground) // 檢查是否觸地
            {
                positionY = ground; // 防止穿透地面，修正位置
                velocityY = -velocityY * bounceFactor; // 反轉速度並應用彈跳係數，模擬彈跳效果
            }
            box.Location = new Point(box.Location.X, (int)positionY); // 更新圖片框的位置，實現動畫效果
            if (Math.Abs(velocityY) < 0.01 || runTime >= runStop) // 判斷動畫是否應該停止
            {
                Stop(); // 停止動畫
            }
        }

        public void Down()
        {
            if (box.Cursor == Cursors.SizeAll) // 判斷鼠標樣式是否為可以拖曳的樣式
            {
                dragCursorPoint = Cursor.Position; // 記錄拖曳開始時的鼠標位置
                dragFormPoint = box.Location; // 記錄拖曳開始時的圖片框位置
                dragging = true; // 設定正在拖曳標誌為真
            }
        }

        public void Move()
        {
            if (dragging && box.Cursor == Cursors.SizeAll) // 如果正在拖曳且鼠標樣式正確
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint)); // 計算鼠標移動的距離
                box.Location = Point.Add(dragFormPoint, new Size(dif)); // 更新圖片框位置，實現拖曳效果
            }
        }

        public void Up()
        {
            dragging = false; // 設定正在拖曳標誌為假，結束拖曳
        }

        public void Stop()
        {
            timer.Stop(); // 停止定時器，結束動畫
            box.Cursor = Cursors.SizeAll; // 將鼠標樣式設定為可拖曳的樣式，以示動畫已停止
        }
    }

}
