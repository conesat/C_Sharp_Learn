using nncqweekly.form;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace weekly_note
{
    static class Program
    {
        public static String homePath = System.Windows.Forms.Application.StartupPath;//启动路径
        public static String modelPath = homePath + "\\model";// 启动路径
        public static String xmlPath = homePath + "\\xml";//启动路径
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
         
            if (Directory.Exists(homePath) == false){
                Directory.CreateDirectory(homePath);
            }
            if (Directory.Exists(xmlPath) == false)
            {
                Directory.CreateDirectory(xmlPath);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
          
        }
    }
}
