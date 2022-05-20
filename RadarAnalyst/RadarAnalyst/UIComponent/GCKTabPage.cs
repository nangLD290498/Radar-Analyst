using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using RadarAnalyst.UIComponent.ComponentI;
using RadarAnalyst.UIComponent.Element;
using Uno.UI.Xaml.Controls;
using RadarAnalyst.UIComponent.Class;

namespace RadarAnalyst.UIComponent
{
    public partial class GCKTabPage : TabPageCI
    {
        private const int lambdaValue = 2;
        private const String P_18M = "P_18M";
        private const String VRS_2DM = "VRS_2DM";
        private String modOn = P_18M;

        private ButtonCtm btn_P_18M;
        private ButtonCtm btn_VRS_2DM;
        private ButtonCtm btn_save;

        private LabelCtm label_beta_title;
        private NumericUpDown nud_beta;
        private LabelCtm label_alpha_title;

        private LabelCtm label_note_title;

        static int pictureBoxHeight = 600;
        static int pictureBoxWidth = 830;
        PointF centerCoordinates = new PointF(pictureBoxWidth / 2, pictureBoxHeight / 2 - 20F);

        private const float nud_beta_default_value = 7.5F;

        private Color groupBoxColor = System.Drawing.ColorTranslator.FromHtml("#19182a");
        private Color lineBlueColor = System.Drawing.ColorTranslator.FromHtml("#e35736");
        private Color violetColor = System.Drawing.ColorTranslator.FromHtml("#c74259");
        private Color textColor = System.Drawing.ColorTranslator.FromHtml("#7a8696");

        private List<GCKNudPair> nudPairCollection = new List<GCKNudPair>();

        Random rnd = new Random();

        public GCKTabPage(String tabCode, String text) : base(tabCode, text)
        {
            // create layout
            initRadarButton();

            initInputTable();

            initOutputTable();

            this.Controls.Remove(this.gb_ouputTable);

            this.gb_picture.Location = new System.Drawing.Point(458, 50);
            this.gb_picture.MaximumSize = new System.Drawing.Size(822, 545);
            this.gb_picture.MinimumSize = new System.Drawing.Size(822, 545);
            this.gb_picture.Size = new System.Drawing.Size(822, 545);
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
            this.btn_P_18M.Size = new System.Drawing.Size(135, 70);
            this.btn_P_18M.Click += new System.EventHandler(this.btn_P_18M_Click);

            // btn_VRS_2DM
            this.btn_VRS_2DM.Location = new System.Drawing.Point(47, 280);
            this.btn_VRS_2DM.Name = "btn_VRS_2DM";
            this.btn_VRS_2DM.Size = new System.Drawing.Size(135, 70);
            this.btn_VRS_2DM.Click += new System.EventHandler(this.btn_VRS_2DM_Click);
        }


        private void initInputTable()
        {
            this.label_beta_title = new LabelCtm();
            this.label_alpha_title = new LabelCtm();
            this.label_note_title = new LabelCtm();

            // 
            // gb_inputTable
            // 
            this.gb_inputTable.Controls.Add(this.label_beta_title);
            this.gb_inputTable.Controls.Add(this.label_alpha_title);
            this.gb_inputTable.Controls.Add(this.label_note_title);

            // ================================================================
            // header
            this.label_beta_title.AutoSize = true;
            this.label_beta_title.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_beta_title.Location = new System.Drawing.Point(20, 50);
            this.label_beta_title.Name = "label_beta_title";
            this.label_beta_title.Size = new System.Drawing.Size(58, 20);
            this.label_beta_title.TabIndex = 13;
            this.label_beta_title.Text = "β";

            this.label_alpha_title.AutoSize = true;
            this.label_alpha_title.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_alpha_title.Location = new System.Drawing.Point(100, 50);
            this.label_alpha_title.Name = "label_alpha_title";
            this.label_alpha_title.Size = new System.Drawing.Size(58, 20);
            this.label_alpha_title.TabIndex = 13;
            this.label_alpha_title.Text = "α";

            this.label_note_title.AutoSize = true;
            this.label_note_title.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_note_title.Location = new System.Drawing.Point(180, 50);
            this.label_note_title.Name = "label_note_title";
            this.label_note_title.Size = new System.Drawing.Size(58, 20);
            this.label_note_title.TabIndex = 13;
            this.label_note_title.Text = "ghi chú";



            // ================================================================
            //this.nud_beta = new System.Windows.Forms.NumericUpDown();
            //((System.ComponentModel.ISupportInitialize)(this.nud_beta)).BeginInit();
            //this.gb_inputTable.Controls.Add(this.nud_beta);
            //// nud_beta
            //this.nud_beta.Location = new System.Drawing.Point(5, 80);
            //this.nud_beta.Name = "nud_beta";
            //this.nud_beta.Size = new System.Drawing.Size(70, 30);
            //this.nud_beta.TabIndex = 6;
            //this.nud_beta.Maximum = 9999999999;
            //this.nud_beta.Minimum = 0;
            //this.nud_beta.DecimalPlaces = 1;
            //this.nud_beta.Increment = 0.1m;
            //this.nud_beta.Value = new decimal(nud_beta_default_value);
            //((System.ComponentModel.ISupportInitialize)(this.nud_beta)).EndInit();

            Panel panel = new Panel();
            panel.AutoScroll = true;
            panel.Height = 250;
            panel.Width = 250;
            panel.Location = new System.Drawing.Point(0, 80);

            for (int i = 0; i < 10; i++)
            {
                NumericUpDown nud_beta = new System.Windows.Forms.NumericUpDown();
                NumericUpDown nud_alpha = new System.Windows.Forms.NumericUpDown();
                TextBox tb_note = new TextBox();

                ((System.ComponentModel.ISupportInitialize)(nud_beta)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(nud_alpha)).BeginInit();

                // nud_beta
                nud_beta.Location = new System.Drawing.Point(0, 0 + i * 30);
                nud_beta.Name = "nud_beta";
                nud_beta.Size = new System.Drawing.Size(70, 30);
                nud_beta.TabIndex = 6;
                nud_beta.Maximum = 360;
                nud_beta.Minimum = 0;
                nud_beta.DecimalPlaces = 1;
                nud_beta.Increment = 1m;
                nud_beta.Value = new decimal(rnd.Next(0, 360));

                // nud_alpha
                nud_alpha.Location = new System.Drawing.Point(80, 0 + i * 30);
                nud_alpha.Name = "nud_alpha";
                nud_alpha.Size = new System.Drawing.Size(70, 30);
                nud_alpha.TabIndex = 6;
                nud_alpha.Maximum = 5;
                nud_alpha.Minimum = 0;
                nud_alpha.DecimalPlaces = 1;
                nud_alpha.Increment = 1m;
                nud_alpha.Value = new decimal(rnd.Next(0, 5));

                // tb_note
                tb_note.Location = new System.Drawing.Point(160, 0 + i * 30);

                panel.Controls.Add(nud_beta);
                panel.Controls.Add(nud_alpha);
                panel.Controls.Add(tb_note);

                GCKNudPair GCKNudPair = new GCKNudPair(nud_beta, nud_alpha, tb_note);
                this.nudPairCollection.Add(GCKNudPair);

                ((System.ComponentModel.ISupportInitialize)(nud_beta)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(nud_alpha)).EndInit();
            }

            this.gb_inputTable.Controls.Add(panel);
        }


        private void initOutputTable()
        {

        }
        private void btn_P_18M_Click(object sender, EventArgs e)
        {
            btn_VRS_2DM.setBackColor(false);
            btn_P_18M.setBackColor(true);
            this.modOn = P_18M;
        }

        private void btn_VRS_2DM_Click(object sender, EventArgs e)
        {
            btn_VRS_2DM.setBackColor(true);
            btn_P_18M.setBackColor(false);
            this.modOn = VRS_2DM;
        }

        public override void btn_ok_click(object sender, EventArgs e)
        {
            List<PointF> curvePointsList = getCurvePointList(this, centerCoordinates);
            for (int idx = 0; idx < this.nudPairCollection.Count; idx++)
            {
                GCKNudPair GCKNudPair = this.nudPairCollection[idx];

                PointF endPoint = GCKNudPair.getPoint();

                System.Windows.Forms.Button c1 = new System.Windows.Forms.Button();
                c1.Location = new Point((int)endPoint.X - 5, (int)endPoint.Y - 2);
                c1.Size = new Size(10, 10);
                c1.BackColor = Color.White;
                this.gb_picture.Controls.Add(c1);

                ToolTip toolTip1 = new ToolTip();
                toolTip1.ShowAlways = true;
                toolTip1.SetToolTip(c1, GCKNudPair.getTbNote().Text);
            }

            // ======================================================================================
            this.gb_picture.Controls.Remove(this.pictureBox1);
            // Dock the PictureBox to the form and set its background to white.
            this.pictureBox1.Location = new Point(0, 0);
            this.pictureBox1.Size = new System.Drawing.Size(pictureBoxWidth, pictureBoxHeight);

            this.pictureBox1.BackColor = groupBoxColor;
            // Connect the Paint event of the PictureBox to the event handler method.
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.drawGraph);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            // btn_save
            //this.btn_save = new ButtonCtm("Save");
            //this.gb_picture.Controls.Add(this.btn_save);
            //this.btn_save.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            //this.btn_save.Location = new System.Drawing.Point(710, 500);
            //this.btn_save.Name = "btn_save";
            //this.btn_save.Size = new System.Drawing.Size(50, 31);
            //this.btn_save.TabIndex = 0;
            //this.btn_save.Text = "Lưu đồ thị";
            //this.btn_save.UseVisualStyleBackColor = true;
            //this.btn_save.Click += new System.EventHandler(this.btn_save_click);

            // Add the PictureBox control to the Form.
            this.gb_picture.Controls.Add(this.pictureBox1);
        }

        public void btn_save_click(object sender, EventArgs e)
        {
            float x = (float)Convert.ToDouble(this.nud_beta.Value);
            String betaValue = x.ToString();
            //String filename = betaValue + "-" + DateTime.Now.ToString("ddMMyyyy-hhmmss") + ".png";
            String filename = betaValue + "°" + ".png";
            string path = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + "/Images/" + filename;

            using (Bitmap bmp = new Bitmap(pictureBox1.ClientSize.Width,
                               pictureBox1.ClientSize.Height - 50))
            {
                pictureBox1.DrawToBitmap(bmp, pictureBox1.ClientRectangle);
                bmp.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            }

            MessageBox.Show("Đã lưu đồ thị: " + path);
        }

        private void drawGraph(object sender, PaintEventArgs e)
        {
            drawCoordinateAxis(e, centerCoordinates);

            drawCurve(e, lineBlueColor, this, centerCoordinates);
        }

        private static void drawCurve(PaintEventArgs e, Color lineBlueColor, GCKTabPage _this, PointF centerCoordinates)
        {
            // draw curve
            Pen pen = new Pen(Color.Red, 2);
            SolidBrush brush = new SolidBrush(Color.White);
            float oX = 60F;
            float oY = 290.0F;
            
            //Sort numeric-up-down-pair list
            _this.nudPairCollection.Sort((p, q) => p.getNudBeta().Value.CompareTo(q.getNudBeta().Value));

            // Create points that define curve.
            List<PointF> curvePointsList = getCurvePointList(_this, centerCoordinates);

            curvePointsList.Add(curvePointsList.First());

            PointF[] curvePoints = curvePointsList.ToArray();

            e.Graphics.DrawLines(pen, curvePoints);
        }

        private static List<PointF> getCurvePointList(GCKTabPage _this, PointF centerCoordinates)
        {
            List<PointF> curvePointsList = new List<PointF>();
            for (int idx = 0; idx < _this.nudPairCollection.Count; idx++)
            {
                GCKNudPair GCKNudPair = _this.nudPairCollection[idx];

                NumericUpDown numericUpDownBeta = GCKNudPair.getNudBeta();
                float numericUpDownBetaValue = (float)Convert.ToDouble(numericUpDownBeta.Value);
                //dựa vào β để xác định góc của điểm
                float angle = numericUpDownBetaValue;

                NumericUpDown numericUpDownAlpha = GCKNudPair.getNudAlpha();
                float numericUpDownAlphaValue = (float)Convert.ToDouble(numericUpDownAlpha.Value);
                //α để xác định cự ly từ tâm đến điểm, Giá trị α chỉ nằm trong khoảng từ 0 đến 5 độ tương ứng với nó nằm trong khoảng từ vòng 1 đến vòng thứ 11
                float radius = getRadius(centerCoordinates);
                float numberOfCircle = (numericUpDownAlphaValue * 2) + 1;
                float radiusX = (float)(numberOfCircle * (radius * 0.8 / 12.5));

                PointF endPoint = endPointRotation(centerCoordinates.X, centerCoordinates.Y, radiusX, angle);

                GCKNudPair.setPoint(endPoint);
                _this.nudPairCollection[idx] = GCKNudPair;

                curvePointsList.Add(endPoint);
            }

            return curvePointsList;
        }

        private static void drawCoordinateAxis(PaintEventArgs e, PointF centerCoordinates)
        {
            Color whiteColor = Color.White;
            Color grayColor = Color.Gray;
            Pen thickPen = new Pen(grayColor, 1);
            Pen boldPen = new Pen(whiteColor, 2);
            float radius = getRadius(centerCoordinates);

            //draw line
            for (int angle = 10; angle <= 360; angle += 10)
            {
                drawLine(e, centerCoordinates, angle, radius);
            }

            e.Graphics.DrawLine(boldPen, new PointF(centerCoordinates.X - radius, centerCoordinates.Y), new PointF(centerCoordinates.X + radius, centerCoordinates.Y));

            // draw circle
            drawCircle(e.Graphics, boldPen, centerCoordinates.X, centerCoordinates.Y, radius);
            for (int numberOfCircle = 1; numberOfCircle <= 11; numberOfCircle++)
            {
                float radiusX = (float)(numberOfCircle * (radius * 0.8 / 12.5));
                drawCircle(e.Graphics, thickPen, centerCoordinates.X, centerCoordinates.Y, radiusX);
            }
        }

        private static float getRadius(PointF centerCoordinates)
        {
            float startX = centerCoordinates.X; // <------------|
            float startY = centerCoordinates.Y; // <------------|
            float endX = centerCoordinates.X + 250F;   // <------------|
            float endY = centerCoordinates.Y;   // <-define these
            float radius = (float)Math.Pow(Math.Pow(endX - startX, 2) + Math.Pow(endY - startY, 2), 0.5);

            return radius;
        }

        private static void drawLine(PaintEventArgs e, PointF centerCoordinates, float angle, float radius)
        {
            drawPartLine(e, centerCoordinates, angle, radius);

            // vẽ đối xứng
            //drawPartLine(e, centerCoordinates, angle + 180);
        }

        private static void drawPartLine(PaintEventArgs e, PointF centerCoordinates, float angle, float radius)
        {
            Color groupBoxColor = System.Drawing.ColorTranslator.FromHtml("#19182a");
            Graphics g = e.Graphics;
            Color whiteColor = Color.White;
            Color grayColor = Color.Gray;
            Color blackColor = Color.Black;
            Color redColor = Color.Red;
            Pen thickPen = new Pen(whiteColor, 1);
            Pen boldPen = new Pen(whiteColor, 2);
            Pen grayPen = new Pen(grayColor, 1);
            Pen blackPen = new Pen(blackColor, 2);
            Pen redPen = new Pen(redColor, 2);

            float startX = centerCoordinates.X; // <------------|
            float startY = centerCoordinates.Y; // <------------|
            float endX = centerCoordinates.X + radius;   // <------------|
            float endY = centerCoordinates.Y;   // <-define these

            //g.DrawLine(boldPen, new PointF(startX - radius, startY), new PointF(endX, endY)); //this is the original line

            PointF endPoint = endPointRotation(startX, startY, radius, angle);

            g.DrawLine(angle % 30 == 0 ? boldPen : grayPen, new PointF(startX, startY), endPoint);

            if (angle % 30 == 0)
            {
                float length = (float)Math.Pow(Math.Pow(endX - startX, 2) + Math.Pow(endY - startY, 2), 0.5);
                float xChange = (float)(length * Math.Cos(Util.Common.ConvertToRadians(angle - 90)));
                float yChange = (float)(length * Math.Sin(Util.Common.ConvertToRadians(angle - 90)));

                // draw angle text
                string Htext = angle.ToString();
                float xRotation = (angle == 360 || angle == 180) ? -20F : (angle < 180 ? Math.Abs(90 - angle) / 90 * 1F : - (Math.Abs(270 - angle) / 90 * 1F + 30F));
                float yRotation = (angle == 90 || angle == 270) ? -10F : ((angle > 90 && angle < 270) ? 0 : -20F);
                using (Font font1 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point))
                {
                    RectangleF rectF1 = new RectangleF(startX + xChange + xRotation, startY + yChange + yRotation, 40, 15);
                    SolidBrush whiteBrush = new SolidBrush(groupBoxColor);
                    e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                    e.Graphics.DrawString(Htext, font1, Brushes.White, rectF1);
                }
            }
        }

        private static PointF endPointRotation(float startX, float startY, float radius, float angle)
        {
            //float length = (float)Math.Pow(Math.Pow(endX - startX, 2) + Math.Pow(endY - startY, 2), 0.5);
            float xChange = (float)(radius * Math.Cos(Util.Common.ConvertToRadians(angle - 90)));
            float yChange = (float)(radius * Math.Sin(Util.Common.ConvertToRadians(angle - 90)));

            PointF endPoint = new PointF(startX + xChange, startY + yChange);

            return endPoint;
        }

        public static void drawCircle(Graphics g, Pen pen,
                                  float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        //ToolTip tip = new ToolTip();
        //private void textBox_MouseMove(object sender, MouseEventArgs e, )
        //{
        //    tip.SetToolTip(textBox3, "Tooltip text"); // you can change the first parameter (textbox3) on any control you wanna focus
        //}
    }
}