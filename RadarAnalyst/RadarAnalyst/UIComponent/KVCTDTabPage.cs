using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.SqlServer;

namespace RadarAnalyst.UIComponent
{
    
    public partial class KVCTDTabPage : TabPage
    {
        public KVCTDTabPage(String tabCode, String text) : base(text)
        {   
           
            Console.WriteLine("Init KVCTD Tab Page");
            this.Location = new System.Drawing.Point(4, 24);
            this.Name = tabCode;
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(1326, 633);
            this.TabIndex = 0;
            this.UseVisualStyleBackColor = true;

            Label lbl;
            lbl = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // Mapinfo
            MapInfo.MapInfoApplication mapinfo = new MapInfo.MapInfoApplication();

            // Get the handle to the whole MapInfo application.
            // 9 = SYS_INFO_MAPINFOWND.
            string handle = mapinfo.Eval("SystemInfo(9)");

            // Convert the handle to an IntPtr type.
            IntPtr oldhandle = new IntPtr(Convert.ToInt32(handle));

            //Make mapinfo visible otherwise it won't show up in our control.
            mapinfo.Visible = true;

            //Set the parent of MapInfo to a picture box on the form.
            SetParent(oldhandle, this.Handle);

            //Get current window style of MapInfo window
            int style = GetWindowLong(oldhandle, GWL_STYLE);

            //Take current window style and remove WS_CAPTION(title bar) from it
            SetWindowLong(oldhandle, GWL_STYLE, (style & ~WS_CAPTION));

            //Maximize MapInfo so that it fits into our control
            mapinfo.Do("Set Window 1011 Max");

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Sets the parent of a window.
        [DllImport("User32", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndParent);

        //Sets window attributes
        [DllImport("USER32.DLL")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        //Gets window attributes
        [DllImport("USER32.DLL")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        //assorted constants needed
        public static int GWL_STYLE = -16;
        public static int WS_CHILD = 0x40000000; //child window
        public static int WS_BORDER = 0x00800000; //window with border
        public static int WS_DLGFRAME = 0x00400000; //window with double border but no title
        public static int WS_CAPTION = WS_BORDER | WS_DLGFRAME; //window with a title bar
        public static int WS_MAXIMIZE = 0x1000000;

    }
}
