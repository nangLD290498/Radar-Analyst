using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarAnalyst.UIComponent
{
    public partial class KTMPXTabPage : TabPage
    {
        Button daiRadaP18MButton;
        Button daiRadaVRS2DMButton;
        Label resultLbl;
        int Rmin = 150;
        int Rmax = 850;

        public KTMPXTabPage(String tabCode, String text) : base(text)
        {
            Console.WriteLine("Init KTMPX Tab Page");
            this.Location = new System.Drawing.Point(4, 24);
            this.Name = tabCode;
            this.Size = new System.Drawing.Size(1245, 575);
            this.TabIndex = 0;
            this.UseVisualStyleBackColor = true;

            

            this.SuspendLayout();

            // 
            // 
            // 
            //Label lbl;
            //lbl = new System.Windows.Forms.Label();
            //this.Controls.Add(lbl);
            //lbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            //lbl.AutoSize = true;
            //lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            //lbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            //lbl.Name = "lbl_appName";
            //lbl.Size = new System.Drawing.Size(796, 76);
            //lbl.TabIndex = 0;
            //lbl.Text = "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB";
            //lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.initUI();


            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void initUI()
        {
            daiRadaP18MButton = new Button();
            this.Controls.Add(daiRadaP18MButton);
            // Set the location of the button
            daiRadaP18MButton.Location = new Point(30, 200);
            // Set text inside the button
            daiRadaP18MButton.Text = "ĐÀI RA ĐA \n P-18 M";
            // Set the AutoSize property of the button
            daiRadaP18MButton.AutoSize = true;
            // Set the background color of the button
            daiRadaP18MButton.BackColor = Color.LightBlue;
            // Set the padding of the button
            daiRadaP18MButton.Padding = new Padding(6);
            // Set font of the text present in the button
            daiRadaP18MButton.Font = new Font("Segoe UI", 16);

            daiRadaP18MButton.Click += new EventHandler(this.daiRadaP18MButtonClick);


            daiRadaVRS2DMButton = new Button();
            this.Controls.Add(daiRadaVRS2DMButton);
            // Set the location of the button
            daiRadaVRS2DMButton.Location = new Point(30, 300);
            // Set text inside the button
            daiRadaVRS2DMButton.Text = "ĐÀI RA ĐA \n VRS-2DM";
            // Set the AutoSize property of the button
            daiRadaVRS2DMButton.AutoSize = true;
            // Set the background color of the button
            daiRadaVRS2DMButton.BackColor = Color.LightBlue;
            // Set the padding of the button
            daiRadaVRS2DMButton.Padding = new Padding(6);
            // Set font of the text present in the button
            daiRadaVRS2DMButton.Font = new Font("Segoe UI", 16);

            daiRadaVRS2DMButton.Click += new EventHandler(this.daiRadaVRS2DMButtonClick);


            resultLbl = new System.Windows.Forms.Label();
            this.Controls.Add(resultLbl);
            //resultLbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            resultLbl.Location = new Point(700, 30);
            resultLbl.AutoSize = true;
            resultLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resultLbl.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            resultLbl.Name = "resultLbl_appName";
            resultLbl.Size = new System.Drawing.Size(796, 76);
            resultLbl.TabIndex = 0;
            resultLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            String text = "Kết quả tính toán\n";
            text += "Bán kính min MPX: Rmin " + Rmin + " m\n";
            text += "Bán kính max MPX: Rmax " + Rmax + " m\n";


            resultLbl.Text = text;
        }

        void daiRadaP18MButtonClick(object sender, System.EventArgs e)
        {
            Rmin = 1000;

            String text = "Kết quả tính toán\n";
            text += "Bán kính min MPX: Rmin " + Rmin + " m\n";
            text += "Bán kính max MPX: Rmax " + Rmax + " m\n";

            resultLbl.Text = text;
        }

        void daiRadaVRS2DMButtonClick(object sender, System.EventArgs e)
        {
            Rmax = 10000;

            String text = "Kết quả tính toán\n";
            text += "Bán kính min MPX: Rmin " + Rmin + " m\n";
            text += "Bán kính max MPX: Rmax " + Rmax + " m\n";

            resultLbl.Text = text;
        }
    }
}
