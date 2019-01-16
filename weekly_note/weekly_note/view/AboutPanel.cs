using System.Drawing;
using System.Windows.Forms;

namespace nncqweekly.view
{
    class AboutPanel:Panel
    {
        public AboutPanel()
        {
           // Control.CheckForIllegalCrossThreadCalls = false;//不加这句  子线程更新视图会报错
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        public int X = 0;
        public int Y = 0;
        public int R = 0;

        public void Render()
        {
            this.Invalidate();
        }

        private void DrawRender(Graphics gra)
        {
            gra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Brush bush = new SolidBrush(System.Drawing.SystemColors.Control);//填充的颜色
            gra.FillEllipse(bush, X-R, Y-R, R*2, R*2);//画填充椭圆的方法，x坐标、y坐标、宽、高，如果是100，则半径为50
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            DrawRender(pe.Graphics);
        }

    }
}
