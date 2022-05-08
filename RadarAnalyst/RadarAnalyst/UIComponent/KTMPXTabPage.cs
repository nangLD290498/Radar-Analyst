using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RadarAnalyst.UIComponent.ComponentI;
using RadarAnalyst.UIComponent.Element;

namespace RadarAnalyst.UIComponent
{
    public partial class KTMPXTabPage : TabPageCI
    {
        private const int lambdaValue = 2;
        private const float P_18M = 2.0F;
        private const float VRS_2DM = 0.2F;
        private float modOn = P_18M;

        private ButtonCtm btn_P_18M;
        private ButtonCtm btn_VRS_2DM;

        private LabelCtm label_ha_title;
        private NumericUpDown nud_ha;
        private LabelCtm label_ha_unit;

        private LabelCtm label_first_result_title;
        private LabelCtm label_first_result_value;
        private LabelCtm label_first_result_unit;

        private LabelCtm label_second_result_title;
        private LabelCtm label_second_result_value;
        private LabelCtm label_second_result_unit;

        float result1 = 0F;
        float result2 = 0F;

        int pictureBoxHeight = 500;
        int pictureBoxWidth = 850;

        private const float nud_ha_default_value = 60.0F;
        private float hRotation = 100F;

        private Color groupBoxColor = System.Drawing.ColorTranslator.FromHtml("#19182a");

        static float minHaP18 = 50, maxHaP18 = 70;
        static float minHaVrs2dm = 14, maxHaVrs2dm = 23;
        float minHaOnPic = minHaP18 , maxHaOnPic = maxHaP18;

        Bitmap radarImgBitmap = global::RadarAnalyst.Properties.Resources.MPX_P18M;
        public KTMPXTabPage(String tabCode, String text) : base(tabCode, text)
        {
            // create layout
            initRadarButton();

            initInputTable();

            initOutputTable();
        }

        private void initRadarButton()
        {
            this.btn_VRS_2DM = new ButtonCtm("ĐÀI RA ĐA \n VRS-2DM");
            this.btn_P_18M = new ButtonCtm("ĐÀI RA ĐA \n P-18 M");
            this.Controls.Add(this.btn_VRS_2DM);
            this.Controls.Add(this.btn_P_18M);

            // btn_P_18M
            this.btn_P_18M.is_active = true;
            this.btn_P_18M.setBackColor(true);
            this.btn_P_18M.Location = new System.Drawing.Point(47, 200);
            this.btn_P_18M.Name = "btn_P_18M";
            this.btn_P_18M.Size = new System.Drawing.Size(135, 50);
            this.btn_P_18M.Click += new System.EventHandler(this.btn_P_18M_Click);

            // btn_VRS_2DM
            this.btn_VRS_2DM.Location = new System.Drawing.Point(47, 260);
            this.btn_VRS_2DM.Name = "btn_VRS_2DM";
            this.btn_VRS_2DM.Size = new System.Drawing.Size(135, 50);
            this.btn_VRS_2DM.Click += new System.EventHandler(this.btn_VRS_2DM_Click);
        }


        private void initInputTable()
        {
            this.nud_ha = new System.Windows.Forms.NumericUpDown();
            this.label_ha_title = new LabelCtm();
            this.label_ha_unit = new LabelCtm();
            // 
            // gb_inputTable
            this.gb_inputTable.Controls.Add(this.label_ha_title);
            this.gb_inputTable.Controls.Add(this.label_ha_unit);
            this.gb_inputTable.Controls.Add(this.nud_ha);

            // label_ha_title
            this.label_ha_title.AutoSize = true;
            this.label_ha_title.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_ha_title.Location = new System.Drawing.Point(21, 40);
            this.label_ha_title.Name = "label_ha_title";
            this.label_ha_title.Size = new System.Drawing.Size(58, 20);
            this.label_ha_title.TabIndex = 13;
            this.label_ha_title.Text = "ha";
            // nud_ha
            this.nud_ha.Location = new System.Drawing.Point(87, 40);
            this.nud_ha.Name = "nud_ha";
            this.nud_ha.Size = new System.Drawing.Size(107, 23);
            this.nud_ha.TabIndex = 4;
            this.nud_ha.Maximum = 9999999999;
            this.nud_ha.Minimum = 0;
            this.nud_ha.DecimalPlaces = 1;
            this.nud_ha.Increment = 0.1m;
            this.nud_ha.Value = new decimal(nud_ha_default_value);
            // label_ha_unit
            this.label_ha_unit.AutoSize = true;
            this.label_ha_unit.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_ha_unit.Location = new System.Drawing.Point(207, 40);
            this.label_ha_unit.Name = "label_ha_unit";
            this.label_ha_unit.Size = new System.Drawing.Size(29, 20);
            this.label_ha_unit.TabIndex = 7;
            this.label_ha_unit.Text = "m";

            ((System.ComponentModel.ISupportInitialize)(this.nud_ha)).EndInit();
        }


        private void initOutputTable()
        {
            this.label_first_result_title = new LabelCtm();
            this.label_first_result_value = new LabelCtm();
            this.label_first_result_unit = new LabelCtm();

            this.label_second_result_title = new LabelCtm();
            this.label_second_result_value = new LabelCtm();
            this.label_second_result_unit = new LabelCtm();

            // 
            // gb_ouputTable
            // 
            this.gb_ouputTable.Controls.Add(this.label_first_result_title);
            this.gb_ouputTable.Controls.Add(this.label_first_result_value);
            this.gb_ouputTable.Controls.Add(this.label_first_result_unit);

            this.gb_ouputTable.Controls.Add(this.label_second_result_title);
            this.gb_ouputTable.Controls.Add(this.label_second_result_value);
            this.gb_ouputTable.Controls.Add(this.label_second_result_unit);

            // ================================================================
            // label_first_result_title
            this.label_first_result_title.AutoSize = true;
            this.label_first_result_title.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_first_result_title.Location = new System.Drawing.Point(30, 50);
            this.label_first_result_title.Name = "label_first_result_title";
            this.label_first_result_title.Size = new System.Drawing.Size(180, 31);
            this.label_first_result_title.TabIndex = 0;
            this.label_first_result_title.Text = "Bán kính min MPX: Rmin ";
            // label_first_result_value
            this.label_first_result_value.AutoSize = true;
            this.label_first_result_value.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_first_result_value.ForeColor = System.Drawing.Color.Red;
            this.label_first_result_value.Location = new System.Drawing.Point(230, 50);
            this.label_first_result_value.Name = "label_first_result_value";
            this.label_first_result_value.Size = new System.Drawing.Size(30, 31);
            this.label_first_result_value.TabIndex = 1;
            this.label_first_result_value.Text = "000000";
            // label17
            this.label_first_result_unit.AutoSize = true;
            this.label_first_result_unit.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_first_result_unit.Location = new System.Drawing.Point(300, 50);
            this.label_first_result_unit.Name = "label_first_result_unit";
            this.label_first_result_unit.Size = new System.Drawing.Size(10, 31);
            this.label_first_result_unit.TabIndex = 2;
            this.label_first_result_unit.Text = "m";

            // ================================================================
            // label_second_result_title
            this.label_second_result_title.AutoSize = true;
            this.label_second_result_title.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_second_result_title.Location = new System.Drawing.Point(30, 90);
            this.label_second_result_title.Name = "label_second_result_title";
            this.label_second_result_title.Size = new System.Drawing.Size(150, 31);
            this.label_second_result_title.TabIndex = 3;
            this.label_second_result_title.Text = "Bán kinh max MPX: Rmax  ";
            // label_second_result_value
            this.label_second_result_value.AutoSize = true;
            this.label_second_result_value.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_second_result_value.ForeColor = System.Drawing.Color.Red;
            this.label_second_result_value.Location = new System.Drawing.Point(230, 90);
            this.label_second_result_value.Name = "label_second_result_value";
            this.label_second_result_value.Size = new System.Drawing.Size(66, 31);
            this.label_second_result_value.TabIndex = 4;
            this.label_second_result_value.Text = "000000";
            // label17
            this.label_second_result_unit.AutoSize = true;
            this.label_second_result_unit.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_second_result_unit.Location = new System.Drawing.Point(300, 90);
            this.label_second_result_unit.Name = "label_second_result_unit";
            this.label_second_result_unit.Size = new System.Drawing.Size(10, 31);
            this.label_second_result_unit.TabIndex = 2;
            this.label_second_result_unit.Text = "m";
        }
        private void btn_P_18M_Click(object sender, EventArgs e)
        {
            this.modOn = P_18M;
            //clearPictureBox(btn_P_18M);
            btn_VRS_2DM.setBackColor(false);
            btn_P_18M.setBackColor(true);
            minHaOnPic = minHaP18;
            maxHaOnPic = maxHaP18;
            radarImgBitmap = global::RadarAnalyst.Properties.Resources.MPX_P18M;
        }

        private void btn_VRS_2DM_Click(object sender, EventArgs e)
        {
            this.modOn = VRS_2DM;
            //clearPictureBox(btn_VRS_2DM);
            btn_VRS_2DM.setBackColor(true);
            btn_P_18M.setBackColor(false);
            minHaOnPic = minHaVrs2dm;
            maxHaOnPic = maxHaVrs2dm;
            radarImgBitmap = global::RadarAnalyst.Properties.Resources.MPX_VRS_2DM;
        }

        private void clearPictureBox(ButtonCtm clickedButton)
        {
            if(clickedButton.is_active == false)
                this.gb_picture.Controls.Remove(this.pictureBox1);
        }

        public override void btn_ok_click(object sender, EventArgs e)
        {
            float haValue = (float)Convert.ToDouble(nud_ha.Value);
            result1 = 0.7F * haValue * haValue / modOn;
            result2 = 23F * haValue * haValue / modOn;
            // set result value 1
            label_first_result_value.Text = Math.Round(result1, 2) == 0 ? "0" : Math.Round(result1, 2).ToString();
            label_first_result_value.ForeColor = System.Drawing.Color.Green;
            // set result value 2
            label_second_result_value.Text = Math.Round(result2, 2) == 0 ? "0" : Math.Round(result2, 2).ToString();
            label_second_result_value.ForeColor = System.Drawing.Color.Green;
            // ======================================================================================
            this.pictureBox1.Controls.Clear();
            this.gb_picture.Controls.Remove(this.pictureBox1);
            // Dock the PictureBox to the form and set its background to white.
            this.pictureBox1.Location = new Point(0, 0);
            this.pictureBox1.Size = new System.Drawing.Size(pictureBoxWidth, pictureBoxHeight);

            this.pictureBox1.BackColor = groupBoxColor;
            // Connect the Paint event of the PictureBox to the event handler method.
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.drawGraph);
            // Add the PictureBox control to the Form.
            this.gb_picture.Controls.Add(this.pictureBox1);
            
        }

        private void drawGraph(object sender, PaintEventArgs e)
        {
            float circlePointX = 650.0F;
            float circlePointY = 200.0F;
            float haValue = (float)Convert.ToDouble(nud_ha.Value);
            // R Min
            float rMinOnpicValue = result1 * 5 / hRotation;
            float rMinMin = (0.7F * minHaOnPic * minHaOnPic / modOn) * 5 / hRotation;
            float rMinMax = (0.7F * maxHaOnPic * maxHaOnPic / modOn) * 5 / hRotation;
            float rMinOnpic = (rMinOnpicValue > rMinMax) ? rMinMax : (rMinOnpicValue < rMinMin) ? rMinMin : rMinOnpicValue;
            // Rmax 
            float rMaxOnpicValue = result2 * 0.5F / hRotation;
            float rMaxMin = (23F * minHaOnPic * minHaOnPic / modOn) * 0.5F / hRotation;
            float rMaxMax = (23F * maxHaOnPic * maxHaOnPic / modOn) * 0.5F / hRotation;
            float rMaxOnpic = (rMaxOnpicValue > rMaxMax) ? rMaxMax : (rMaxOnpicValue < rMaxMin) ? rMaxMin : rMaxOnpicValue;

            Pen pen = new Pen(Color.FromArgb(56, 93, 138), 2);
            //draw circles
            PointF centerPoint = new PointF(circlePointX, circlePointY);
            SolidBrush minBrush = new SolidBrush(groupBoxColor);
            SolidBrush maxBrush = new SolidBrush(Color.FromArgb(79,129,189));
            
            e.Graphics.FillEllipse(maxBrush, circlePointX - rMaxOnpic / 2, circlePointY - rMaxOnpic / 2, rMaxOnpic, rMaxOnpic);
            e.Graphics.FillEllipse(minBrush, circlePointX - rMinOnpic/2, circlePointY - rMinOnpic/2, rMinOnpic, rMinOnpic);
            e.Graphics.DrawEllipse(pen, circlePointX - rMaxOnpic / 2, circlePointY - rMaxOnpic / 2, rMaxOnpic, rMaxOnpic);
            e.Graphics.DrawEllipse(pen, circlePointX - rMinOnpic / 2, circlePointY - rMinOnpic / 2, rMinOnpic, rMinOnpic);
            // draw Rmin line white
            pen = new Pen(Color.White, 2);
            PointF rminTopPoint = centerPoint;
            PointF rminBotPoint = new PointF(centerPoint.X - rMinOnpic/2, centerPoint.Y);
            e.Graphics.DrawLine(pen, rminTopPoint, rminBotPoint);
            // draw bot arrow
            e.Graphics.DrawLine(pen, new PointF(centerPoint.X - rMinOnpic/2, centerPoint.Y), new PointF(centerPoint.X - rMinOnpic/2 + 5F, centerPoint.Y - 5F));
            e.Graphics.DrawLine(pen, new PointF(centerPoint.X - rMinOnpic/2, centerPoint.Y), new PointF(centerPoint.X - rMinOnpic/2 + 5F, centerPoint.Y + 5F));
            // draw text
            string textRmin = "Rmin";
            using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
            {
                RectangleF rectF1 = new RectangleF(centerPoint.X - rMinOnpic/4, centerPoint.Y + 5F, 50, 20); //note
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                e.Graphics.DrawString(textRmin, font1, Brushes.Black, rectF1);
            }
            // draw Rmax line white
            pen = new Pen(Color.White, 2);
            PointF rmaxTopPoint = centerPoint;
            PointF rmaxBotPoint = new PointF(centerPoint.X, centerPoint.Y - rMaxOnpic/2);
            e.Graphics.DrawLine(pen, rmaxTopPoint, rmaxBotPoint);
            // draw bot arrow
            e.Graphics.DrawLine(pen, new PointF(centerPoint.X , centerPoint.Y - rMaxOnpic / 2), new PointF(centerPoint.X + 5F, centerPoint.Y - rMaxOnpic / 2 + 5F));
            e.Graphics.DrawLine(pen, new PointF(centerPoint.X , centerPoint.Y - rMaxOnpic / 2), new PointF(centerPoint.X -  5F, centerPoint.Y - rMaxOnpic / 2 + 5F));
            // draw text
            string textRmax = "Rmax";
            using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
            {
                RectangleF rectF1 = new RectangleF(centerPoint.X + 5F, centerPoint.Y - rMaxOnpic / 4, 50, 20); 
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                e.Graphics.DrawString(textRmax, font1, Brushes.Black, rectF1);
            }
            //draw traigle
            PictureBox radar = new PictureBox();
            radar.Location = new Point(50, 180);
            radar.Size = new System.Drawing.Size(40,50);
            radar.SizeMode = PictureBoxSizeMode.StretchImage;
            radar.Image = radarImgBitmap;
            pictureBox1.Controls.Add(radar);
            // eclipse 
            int l = (int)(1.5F * (rMaxOnpic - rMinOnpic));
            PictureBox pic = new PictureBox();
            pic.Location = new Point(75 + (int)(rMinOnpic * 0.75), 232 - l/2);
            pic.Size = new System.Drawing.Size(l, l/2);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Image = global::RadarAnalyst.Properties.Resources.pic;
            pictureBox1.Controls.Add(pic);
            // arrow Rmin ------------------------------------------------------
            PointF minTopPoint = new PointF(93, 250);
            PointF minBotPoint = new PointF(minTopPoint.X + rMinOnpic - 20, 250);
            e.Graphics.DrawLine(pen, minTopPoint, minBotPoint);
            // draw top arrow
            e.Graphics.DrawLine(pen, minTopPoint, new PointF(minTopPoint.X + 5, minTopPoint.Y - 5F));
            e.Graphics.DrawLine(pen, minTopPoint, new PointF(minTopPoint.X + 5, minTopPoint.Y + 5F));
            // draw bot arrow
            e.Graphics.DrawLine(pen, minBotPoint, new PointF(minBotPoint.X - 5F, minBotPoint.Y - 5F));
            e.Graphics.DrawLine(pen, minBotPoint, new PointF(minBotPoint.X - 5F , minBotPoint.Y + 5F));
            // draw text ha
            string text1 = "Rmin";
            using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
            {
                
                RectangleF rectF1 = new RectangleF(30, 240, 50, 20);
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                e.Graphics.DrawString(text1, font1, Brushes.Black, rectF1);
            }
            // arrow Rmax ------------------------------------------------------
            PointF maxTopPoint = new PointF(93, 280);
            PointF maxBotPoint = new PointF(maxTopPoint.X + rMinOnpic + l/2 -20, 280);
            e.Graphics.DrawLine(pen, maxTopPoint, maxBotPoint);
            // draw top arrow
            e.Graphics.DrawLine(pen, maxTopPoint, new PointF(maxTopPoint.X + 5, maxTopPoint.Y - 5F));
            e.Graphics.DrawLine(pen, maxTopPoint, new PointF(maxTopPoint.X + 5, maxTopPoint.Y + 5F));
            // draw bot arrow
            e.Graphics.DrawLine(pen, maxBotPoint, new PointF(maxBotPoint.X - 5F, maxBotPoint.Y - 5F));
            e.Graphics.DrawLine(pen, maxBotPoint, new PointF(maxBotPoint.X - 5F, maxBotPoint.Y + 5F));
            // draw text ha
            string text2 = "Rmax";
            using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
            {

                RectangleF rectF1 = new RectangleF(30, 270, 50, 20);
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                e.Graphics.DrawString(text2, font1, Brushes.Black, rectF1);
            }
            // draw eclipse
            Pen eclipsePen = new Pen(Color.FromArgb(192, 80, 77), 2);
            Brush eclipseBrush  = new SolidBrush(Color.FromArgb(198, 217, 241));
            e.Graphics.FillEllipse(eclipseBrush, minBotPoint.X + 2, minBotPoint.Y - 5, l/2 , 15);
            e.Graphics.DrawEllipse(eclipsePen, minBotPoint.X + 2, minBotPoint.Y - 5 , l/2 , 15);

        }
    }
}
