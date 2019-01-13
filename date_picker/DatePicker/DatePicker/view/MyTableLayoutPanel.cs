using DatePicker.myclass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatePicker
{
    class MyTableLayoutPanel:TableLayoutPanel
    {
        public MyTableLayoutPanel()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

        }
        Bitmap bmp = new Bitmap(global::DatePicker.Properties.Resources.rbg);

        Brush bush = new SolidBrush(Color.Green);//填充的颜色
        public int X = -100;
        public int Y = 50;
        GraphicsPath path = new GraphicsPath();

        public void Render()
        {
            this.Invalidate();
        }

        private void DrawRender(Graphics gs)
        {
            gs.Clear(this.BackColor);
          
            //环形；
           // path.AddEllipse(X - 50, Y - 50, 100, 100);
          //  path.AddEllipse(25, 25, 50, 50);
            //径向渐变刷
           // PathGradientBrush brush = new PathGradientBrush(path); //using System.Drawing.Drawing2D;
          //  brush.CenterColor = Color.White;
            //边缘颜色；
          //  brush.SurroundColors = new Color[] { Color.Transparent };
          //  gs.FillPath(brush, path);
            // gs.FillEllipse(bush, X - 50, Y - 50, 100, 100);//画填充椭圆的方法，x坐标、y坐标、宽、高，如果是100，则半径为50
           
            gs.DrawImage(
                     bmp,
                     new Rectangle(X - 100, Y - 100, 200, 200),
                     new Rectangle(0, 0, 200, 200),
                     GraphicsUnit.Pixel);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            DrawRender(pe.Graphics);
        }
    }
}
