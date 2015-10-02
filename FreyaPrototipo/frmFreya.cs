using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FreyaPrototipo
{
    public partial class frmFreya : Form
    {

        private bool isDev = false; //EZ-DEV

        public frmFreya()
        {
            InitializeComponent();
        }

        #region Events
        private void frmFreya_Load(object sender, EventArgs e)
        {
            Config config = new Config();
            wbContainer.ScrollBarsEnabled = false;
            wbContainer.ScriptErrorsSuppressed = true;
            GenerateScreenshot(Config.ConfigKeys.url);
        }
        
        private void timerSave_Tick(object sender, EventArgs e)
        {
            //Scrollbars control
            wbContainer.ScrollBarsEnabled = true;
            wbContainer.Document.Window.ScrollTo(wbContainer.Height, 90);

            //Transporting webbrowser to bmp. this old but GOLD
            Bitmap bitmap = new Bitmap(wbContainer.Width, wbContainer.Height);
            wbContainer.DrawToBitmap(bitmap, new Rectangle(0, 0, wbContainer.Width, wbContainer.Height));

            //Draw text to inform date and time with this screenshot have been taken.
            string stampString;
            DateTime dt = DateTime.Now;

            if (!string.IsNullOrEmpty("dd/MM/yyyy")) { stampString = dt.ToString("dd/MM/yy HH:mm"); }
            else { stampString = dt.ToString(); }

            stampString += " - www.wappenware.com.br/freya";
            
            Graphics g = Graphics.FromImage(bitmap);
            g.FillRectangle(Brushes.Black, 0, 0, bitmap.Width, 30);
            g.DrawString(stampString, new Font("Verdana", 15f), Brushes.White, 2, 2);

            //Save file - allehua
            bitmap.Save(@"" + Config.ConfigKeys.diretorio + Config.ConfigKeys.prefixo + "_" + dt.Hour.ToString() + "_" + dt.Minute.ToString() + "_" + dt.Day.ToString() + "_" + dt.Month.ToString() + ".png", ImageFormat.Png);
            
            timerSave.Stop();
            timerReload.Interval = 600000; //Take the next screenshot

            if (isDev)
            {
                timerReload.Interval = 10000;
            }

            timerReload.Start();
        }

        private void timerReload_Tick(object sender, EventArgs e)
        {
            GenerateScreenshot(Config.ConfigKeys.url);
            timerReload.Stop();
        }
        #endregion

        #region PrivateMethod
        public void GenerateScreenshot(string url)
        {

            //Making html with iframe, technique for executing scripts.
            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.Append("  <head><meta http-equiv='X-UA-Compatible' content='IE=edge'>");
            sb.Append("  </head>");
            sb.Append("  <body>");
            sb.Append("    <iframe id='frame1' src='" + url + "' style='min-height:800px;position:absolute;' width='1424px' height='500px;' noresize='yes' frameborder='0' marginheight='0' marginwidth='0' scrolling='no'></iframe>");
            sb.Append("  </body");
            sb.Append("</html>");

            //Load html
            wbContainer.DocumentText = sb.ToString();

            timerReload.Stop();
            timerSave.Interval = 40000;

            if (isDev)
            {
                timerSave.Interval = 5000;
            }

            timerSave.Start();
        }
        #endregion
    }
}
