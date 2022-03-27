using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarAnalyst.UIComponent
{
    public partial class DLLTabPage : TabPage
    {
        public DLLTabPage(String tabCode, String text) : base(text)
        {
            Console.WriteLine("Init DLL Tab Page");
            this.Location = new System.Drawing.Point(4, 24);
            this.Name = tabCode;
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(1326, 633);
            this.TabIndex = 0;
            this.UseVisualStyleBackColor = true;

            Label lbl;
            lbl = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // 
            // 
            // 
            this.Controls.Add(lbl);
            lbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            lbl.AutoSize = true;
            lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbl.Name = "lbl_appName";
            lbl.Size = new System.Drawing.Size(796, 76);
            lbl.TabIndex = 0;
            lbl.Text = "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB";
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
