using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace WindowsFormsApp2
{
    public static class Animation
    {
        private static int MoveStep = 1;
        private static Timer tmrAnim = null;
        private static Control control = null;
        private static int S_H = 0;
        public static Boolean isShow = false;
        private static int HS = 50;
        private static AutoResetEvent autoEvent = new AutoResetEvent(false);

        private static void InitTimer()
        {
            if (tmrAnim == null)
            {
                Console.WriteLine("创建 ");
                tmrAnim = new Timer();
                tmrAnim.Interval = 15;
                tmrAnim.Tick += new System.EventHandler(tmrAnim_Tick);
            }
        }

        private static void tmrAnim_Tick(object sender, System.EventArgs e)
        {
            if (isShow)
            {
                if (S_H == 0)
                {
                    if (HS > 0)
                    {
                        HS--;
                        if (HS >= 50)
                        {
                            control.Top = 0;
                        }
                    }
                    else
                    {
                        MoveStep++;
                        if (control.Top > -(control.Height - 1))
                        {
                            control.Top -= MoveStep;
                        }
                        else
                        {
                            control.Top = -(control.Height-1);
                            tmrAnim.Stop();
                            isShow = false;
                        }
                    }
                }
                else
                {


                    MoveStep++;
                    if (control.Top < 0)
                    {
                        control.Top += MoveStep;
                    }
                    else
                    {
                        control.Top = 0;
                        tmrAnim.Stop();
                        isShow = false;
                    }
                }


            }

        }

        public static void hide(Control control)
        {
            if (isShow) { return; }
            if (control.Top > 50)
            {
                HS = 50;
            }
            else {

                HS = 10;
            }
            control.Top = 0;
            isShow = true;
            S_H = 0;
            MoveStep = 1;
            InitTimer();
            Animation.control = control;
            tmrAnim.Start();
        }


        public static void show(Control control)
        {
            if (isShow) { return; }
            isShow = true;
            S_H = 1;
            MoveStep = 1;
            autoEvent.Set();
            InitTimer();

            Animation.control = control;
            tmrAnim.Start();
        }


        public static void hideF(Control control)
        {
            HS = 100;
            isShow = true;
            S_H = 0;
            MoveStep = 1;
            InitTimer();
            Animation.control = control;
            tmrAnim.Start();
        }

    }
}
