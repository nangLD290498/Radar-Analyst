using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using RadarAnalyst.UIComponent.Element;

namespace RadarAnalyst.UIComponent.ComponentI
{
    public partial class TabPageCII : TabPage
    {
        protected GroupBoxCtm gb_picture;
        protected GroupBoxCtm gb_inputTable;
        protected ButtonCtm btn_ok;

        protected PictureBox pictureBox1 = new PictureBox();

        public TabPageCII(String tabCode, String text) : base(text)
        {
            Console.WriteLine("Init KTMPX Tab Page");
            this.Location = new System.Drawing.Point(4, 24);
            this.Name = tabCode.ToUpper();
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(1326, 633);
            this.TabIndex = 0;
            this.UseVisualStyleBackColor = true;
            this.SuspendLayout();
            // create layout
            initUI();
            this.Paint += new PaintEventHandler(set_background);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        protected void initUI()
        {
            // input
            this.gb_inputTable = new GroupBoxCtm();
            this.gb_inputTable.SuspendLayout();
            this.Controls.Add(this.gb_inputTable);
            this.gb_inputTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.gb_inputTable.Font = new System.Drawing.Font("MonoLisa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gb_inputTable.Location = new System.Drawing.Point(199, 75);
            this.gb_inputTable.MaximumSize = new System.Drawing.Size(383, 500);
            this.gb_inputTable.MinimumSize = new System.Drawing.Size(383, 500);
            this.gb_inputTable.Name = "gb_inputTable";
            this.gb_inputTable.Size = new System.Drawing.Size(383, 500);
            this.gb_inputTable.TabIndex = 3;
            this.gb_inputTable.TabStop = false;
            this.gb_inputTable.Text = "BẢNG NHẬP SỐ LIỆU";
            this.gb_inputTable.ResumeLayout(false);
            this.gb_inputTable.PerformLayout();
            initInputTable();

            //picture
            this.gb_picture = new GroupBoxCtm();
            this.Controls.Add(this.gb_picture);
            this.gb_picture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_picture.Font = new System.Drawing.Font("MonoLisa", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gb_picture.Location = new System.Drawing.Point(588, 75);
            this.gb_picture.MaximumSize = new System.Drawing.Size(692, 500);
            this.gb_picture.MinimumSize = new System.Drawing.Size(692, 500);
            this.gb_picture.Name = "gb_picture";
            this.gb_picture.Size = new System.Drawing.Size(692, 500);
            this.gb_picture.TabIndex = 5;
            this.gb_picture.TabStop = false;
        }

        protected void initInputTable()
        {
            this.btn_ok = new ButtonCtm("OK");
            this.gb_inputTable.Controls.Add(this.btn_ok);
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_ok.Location = new System.Drawing.Point(140, 450);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(61, 31);
            this.btn_ok.TabIndex = 0;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_click);
        }


        public virtual void btn_ok_click(object sender, EventArgs e)
        {
        }

        protected void set_background(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            //define gradient's properties
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#07081d");

            Brush b = new LinearGradientBrush(gradient_rectangle, col, col, 65f);
            
            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
        }
    }
}
