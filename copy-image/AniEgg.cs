using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace copy_image
{
    internal class AniEgg
    {
        private double positionY = 0; // 當前位置
        private double velocityY = 0; // 當前速度
        private double bounceFactor = 0.9; // 回彈係數
        private double gravity = 1; // 重力加速度
        private int ground; // 窗體底部位置
        private int runTime = 0;
        private int runStop = 15000;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private PictureBox box;
        private Timer timer;

        public AniEgg(int clientHeight, PictureBox box, Timer timer)
        {
            this.box = box;
            this.box.Cursor = Cursors.PanSouth;
            //this.box.BorderStyle = BorderStyle.Fixed3D;
            this.ground = clientHeight - this.box.Height;
            this.timer = timer;
            this.timer.Start();
        }

        public void Tick()
        {
            runTime += timer.Interval;
            // 模擬重力加速度
            velocityY += gravity;
            positionY += velocityY;
            // 檢查是否觸地
            if (positionY >= ground)
            {
                positionY = ground; // 修正位置，防止控制元件“穿地”
                velocityY = -velocityY * bounceFactor; // 反向速度並應用回彈係數
            }
            // 更新控制元件位置
            box.Location = new Point(box.Location.X, (int)positionY);
            // 如果回彈高度太小，則停止動畫
            if (Math.Abs(velocityY) < 0.01 || runTime >= runStop)
            {
                Stop();
            }
        }

        public void Down() {
            if (box.Cursor == Cursors.SizeAll)
            {
                dragCursorPoint = Cursor.Position;
                dragFormPoint = box.Location;
                dragging = true;
            }
        }

        public void Move() {
            if (dragging && box.Cursor == Cursors.SizeAll)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                box.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        public void Up() {
            dragging = false;
        }

        public void Stop()
        {
            timer.Stop();
            box.Cursor = Cursors.SizeAll;
        }
    }
}
