using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using RadarAnalyst.UIComponent.ComponentI;
using RadarAnalyst.UIComponent.Element;
using RadarAnalyst.UIComponent.Class;

namespace RadarAnalyst.UIComponent
{
    public partial class PVPHMPTabPage : TabPageCI
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
        private LabelCtm label_stt_title;

        private LabelCtm label_note_title;

        static int pictureBoxHeight = 600;
        static int pictureBoxWidth = 830;
        PointF centerCoordinates = new PointF(pictureBoxWidth / 2, pictureBoxHeight / 2 - 20F);

        private const float nud_beta_default_value = 7.5F;

        private Color groupBoxColor = System.Drawing.ColorTranslator.FromHtml("#19182a");
        private Color lineBlueColor = System.Drawing.ColorTranslator.FromHtml("#e35736");
        private Color violetColor = System.Drawing.ColorTranslator.FromHtml("#c74259");
        private Color textColor = System.Drawing.ColorTranslator.FromHtml("#7a8696");

        private List<PVNudPair> nudPairCollection = new List<PVNudPair>();

        Random rnd = new Random();

        public PVPHMPTabPage(String tabCode, String text) : base(tabCode, text)
        {
            // create layout
            initRadarButton();

            initInputTable();

            initOutputTable();

            this.Controls.Remove(this.gb_ouputTable);

            // input table
            this.gb_inputTable.Location = new System.Drawing.Point(47, 197);
            this.gb_inputTable.MaximumSize = new System.Drawing.Size(400 * 2, 396 * 2);
            this.gb_inputTable.MinimumSize = new System.Drawing.Size(400, 396);
            this.gb_inputTable.Size = new System.Drawing.Size(400, 396);

            // input table
            this.gb_ouputTable.Location = new System.Drawing.Point(458, 9);
            this.gb_ouputTable.MaximumSize = new System.Drawing.Size(822 * 2, 172 * 2);
            this.gb_ouputTable.MinimumSize = new System.Drawing.Size(822, 172);
            this.gb_ouputTable.Size = new System.Drawing.Size(822, 172);

            // picture output
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
            this.btn_P_18M.Location = new System.Drawing.Point(47, 50);
            this.btn_P_18M.Name = "btn_P_18M";
            this.btn_P_18M.Size = new System.Drawing.Size(135, 60);
            this.btn_P_18M.Click += new System.EventHandler(this.btn_P_18M_Click);

            // btn_VRS_2DM
            this.btn_VRS_2DM.Location = new System.Drawing.Point(47, 50 + 70);
            this.btn_VRS_2DM.Name = "btn_VRS_2DM";
            this.btn_VRS_2DM.Size = new System.Drawing.Size(135, 60);
            this.btn_VRS_2DM.Click += new System.EventHandler(this.btn_VRS_2DM_Click);
        }


        private void initInputTable()
        {
            this.label_stt_title = new LabelCtm();
            this.label_beta_title = new LabelCtm();
            this.label_alpha_title = new LabelCtm();
            this.label_note_title = new LabelCtm();
            LabelCtm label_h1 = new LabelCtm();
            LabelCtm label_h2 = new LabelCtm();
            LabelCtm label_h3 = new LabelCtm();

            // 
            // gb_inputTable
            // 
            this.gb_inputTable.Controls.Add(this.label_stt_title);
            this.gb_inputTable.Controls.Add(this.label_beta_title);
            this.gb_inputTable.Controls.Add(this.label_alpha_title);
            this.gb_inputTable.Controls.Add(this.label_note_title);
            this.gb_inputTable.Controls.Add(label_h1);
            this.gb_inputTable.Controls.Add(label_h2);
            this.gb_inputTable.Controls.Add(label_h3);

            // ================================================================
            // header

            this.label_stt_title.AutoSize = true;
            this.label_stt_title.Font = new System.Drawing.Font("MonoLisa", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_stt_title.Location = new System.Drawing.Point(0, 50);
            this.label_stt_title.Name = "label_stt_title";
            this.label_stt_title.Size = new System.Drawing.Size(20, 40);
            this.label_stt_title.TabIndex = 13;
            //this.label_stt_title.AutoSize = false;
            //this.label_stt_title.TextAlign = ContentAlignment.MiddleCenter;
            this.label_stt_title.Text = "STT";


            this.label_beta_title.AutoSize = true;
            this.label_beta_title.Font = new System.Drawing.Font("MonoLisa", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_beta_title.Location = new System.Drawing.Point(40, 50);
            this.label_beta_title.Name = "label_beta_title";
            this.label_beta_title.Size = new System.Drawing.Size(60, 20);
            this.label_beta_title.TabIndex = 13;
            this.label_beta_title.AutoSize = false;
            this.label_beta_title.TextAlign = ContentAlignment.MiddleCenter;
            this.label_beta_title.Text = "β";

            this.label_alpha_title.AutoSize = true;
            this.label_alpha_title.Font = new System.Drawing.Font("MonoLisa", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_alpha_title.Location = new System.Drawing.Point(100, 50);
            this.label_alpha_title.Name = "label_alpha_title";
            this.label_alpha_title.Size = new System.Drawing.Size(60, 20);
            this.label_alpha_title.TabIndex = 13;
            this.label_alpha_title.AutoSize = false;
            this.label_alpha_title.TextAlign = ContentAlignment.MiddleCenter;
            this.label_alpha_title.Text = "α";

            this.label_note_title.AutoSize = true;
            this.label_note_title.Font = new System.Drawing.Font("MonoLisa", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_note_title.Location = new System.Drawing.Point(180, 25);
            this.label_note_title.Name = "label_note_title";
            this.label_note_title.Size = new System.Drawing.Size(200, 20);
            //this.label_note_title.TabIndex = 13;
            this.label_note_title.AutoSize = false;
            this.label_note_title.TextAlign = ContentAlignment.MiddleCenter;
            this.label_note_title.Text = "Dph(km)";

            label_h1.AutoSize = true;
            label_h1.Font = new System.Drawing.Font("MonoLisa", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label_h1.Location = new System.Drawing.Point(180, 50);
            label_h1.Name = "label_note_title";
            label_h1.Size = new System.Drawing.Size(60, 20);
            label_h1.TabIndex = 13;
            label_h1.AutoSize = false;
            label_h1.TextAlign = ContentAlignment.MiddleCenter;
            label_h1.Text = "H=1000";

            label_h2.AutoSize = true;
            label_h2.Font = new System.Drawing.Font("MonoLisa", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label_h2.Location = new System.Drawing.Point(250, 50);
            label_h2.Name = "label_note_title";
            label_h2.Size = new System.Drawing.Size(60, 20);
            label_h2.TabIndex = 13;
            label_h2.AutoSize = false;
            label_h2.TextAlign = ContentAlignment.MiddleCenter;
            label_h2.Text = "H=3000";

            label_h3.AutoSize = true;
            label_h3.Font = new System.Drawing.Font("MonoLisa", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label_h3.Location = new System.Drawing.Point(320, 50);
            label_h3.Name = "label_note_title";
            label_h3.Size = new System.Drawing.Size(60, 20);
            label_h3.TabIndex = 13;
            label_h3.AutoSize = false;
            label_h3.TextAlign = ContentAlignment.MiddleCenter;
            label_h3.Text = "H=7000";

            Panel panel = new Panel();
            panel.AutoScroll = true;
            panel.Height = 250;
            panel.Width = 400;
            panel.Location = new System.Drawing.Point(0, 80);

            for (int i = 0; i < 20; i++)
            {
                NumericUpDown nud_beta = new System.Windows.Forms.NumericUpDown();
                NumericUpDown nud_alpha = new System.Windows.Forms.NumericUpDown();
                NumericUpDown nud_h1 = new System.Windows.Forms.NumericUpDown();
                NumericUpDown nud_h2 = new System.Windows.Forms.NumericUpDown();
                NumericUpDown nud_h3 = new System.Windows.Forms.NumericUpDown();
                LabelCtm label_stt_val = new LabelCtm();

                ((System.ComponentModel.ISupportInitialize)(nud_beta)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(nud_alpha)).BeginInit();

                // stt
                label_stt_val.AutoSize = true;
                label_stt_val.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label_stt_val.Location = new System.Drawing.Point(0, 0 + i * 30);
                label_stt_val.Name = "label_ha_unit";
                label_stt_val.Size = new System.Drawing.Size(20, 40);
                label_stt_val.TabIndex = 7;
                label_stt_val.Text = (i + 1).ToString();

                // nud_beta
                nud_beta.Location = new System.Drawing.Point(40, 0 + i * 30);
                nud_beta.Name = "nud_beta";
                nud_beta.Size = new System.Drawing.Size(60, 30);
                nud_beta.TabIndex = 6;
                nud_beta.Maximum = 360;
                nud_beta.Minimum = 0;
                nud_beta.DecimalPlaces = 1;
                nud_beta.Increment = 1m;
                nud_beta.Value = new decimal(rnd.Next(0, 360));

                // nud_alpha
                nud_alpha.Location = new System.Drawing.Point(110, 0 + i * 30);
                nud_alpha.Name = "nud_alpha";
                nud_alpha.Size = new System.Drawing.Size(60, 30);
                nud_alpha.TabIndex = 6;
                nud_alpha.Maximum = 180;
                nud_alpha.Minimum = 0;
                nud_alpha.DecimalPlaces = 1;
                nud_alpha.Increment = 1m;
                nud_alpha.Value = new decimal(rnd.Next(0, 5));

                // nud_h1
                nud_h1.Location = new System.Drawing.Point(180, 0 + i * 30);
                nud_h1.Name = "nud_h1";
                nud_h1.Size = new System.Drawing.Size(60, 30);
                nud_h1.TabIndex = 6;
                nud_h1.Maximum = 180;
                nud_h1.Minimum = 0;
                nud_h1.DecimalPlaces = 1;
                nud_h1.Increment = 1m;
                nud_h1.Value = new decimal(rnd.Next(4, 18)) * 10;

                // nud_h2
                nud_h2.Location = new System.Drawing.Point(250, 0 + i * 30);
                nud_h2.Name = "nud_h2";
                nud_h2.Size = new System.Drawing.Size(60, 30);
                nud_h2.TabIndex = 6;
                nud_h2.Maximum = 180;
                nud_h2.Minimum = 0;
                nud_h2.DecimalPlaces = 1;
                nud_h2.Increment = 1m;
                nud_h2.Value = new decimal(rnd.Next(4, 18)) * 10;

                // nud_h3
                nud_h3.Location = new System.Drawing.Point(320, 0 + i * 30);
                nud_h3.Name = "nud_h3";
                nud_h3.Size = new System.Drawing.Size(60, 30);
                nud_h3.TabIndex = 6;
                nud_h3.Maximum = 180;
                nud_h3.Minimum = 0;
                nud_h3.DecimalPlaces = 1;
                nud_h3.Increment = 1m;
                nud_h3.Value = new decimal(rnd.Next(4, 18)) * 10;

                panel.Controls.Add(label_stt_val);
                panel.Controls.Add(nud_beta);
                panel.Controls.Add(nud_alpha);
                panel.Controls.Add(nud_h1);
                panel.Controls.Add(nud_h2);
                panel.Controls.Add(nud_h3);

                PVNudPair PVNudPair = new PVNudPair(nud_beta, nud_alpha, nud_h1, nud_h2, nud_h3);
                this.nudPairCollection.Add(PVNudPair);

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
            this.gb_picture.Controls.Clear();
            List<PointF> curvePointsList = getCurvePointList(this, centerCoordinates);
            for (int idx = 0; idx < this.nudPairCollection.Count; idx++)
            {
                PVNudPair PVNudPair = this.nudPairCollection[idx];

                PointF endPointH1 = PVNudPair.getPointH1();
                PointF endPointH2 = PVNudPair.getPointH2();
                PointF endPointH3 = PVNudPair.getPointH3();
                List<PointF> pointFs = new List<PointF>(){
                    endPointH1, endPointH2, endPointH3
                };

                for(int i = 1; i <= 3; i++)
                {
                    PointF point = pointFs[i - 1];
                    System.Windows.Forms.Button c1 = new System.Windows.Forms.Button();
                    c1.Location = new Point((int)point.X - 5, (int)point.Y - 2);
                    c1.Size = new Size(10, 10);
                    c1.BackColor = Color.White;
                    this.gb_picture.Controls.Add(c1);

                    ToolTip toolTip1 = new ToolTip();
                    toolTip1.ShowAlways = true;
                    toolTip1.SetToolTip(c1, i == 1 ? "H=1000" : i == 2 ? "H=3000" : "H=7000");
                }
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

        private static void drawCurve(PaintEventArgs e, Color lineBlueColor, PVPHMPTabPage _this, PointF centerCoordinates)
        {
            //Sort numeric-up-down-pair list
            _this.nudPairCollection.Sort((p, q) => p.getNudBeta().Value.CompareTo(q.getNudBeta().Value));

            _this.nudPairCollection.Add(_this.nudPairCollection.First());

            getCurvePointList(_this, centerCoordinates);

            for (int index = 0; index < _this.nudPairCollection.Count - 1; index++)
            {
                PVNudPair nudPairStart = _this.nudPairCollection[index];
                PVNudPair nudPairEnd = _this.nudPairCollection[index + 1];

                drawCurveTwoPoint(e, lineBlueColor, _this, centerCoordinates, nudPairStart, nudPairEnd, index == _this.nudPairCollection.Count - 2);
            }
        }

        private static void drawCurveTwoPoint(PaintEventArgs e, Color lineBlueColor, PVPHMPTabPage _this, PointF centerCoordinates, PVNudPair nudPairStart, PVNudPair nudPairEnd, bool isLast)
        {
            for (int i = 1; i <= 3; i++)
            {
                List<PointF> curvePointsList = new List<PointF>();

                PointF startPoint;
                float endPointRadius;
                Color penColor;
                switch (i)
                {
                    case 1: 
                        startPoint = nudPairStart.getPointH1();
                        endPointRadius = nudPairEnd.getRadiusH1();
                        penColor = Color.Green;
                        break;
                    case 2: 
                        startPoint = nudPairStart.getPointH2(); 
                        endPointRadius = nudPairEnd.getRadiusH2();
                        penColor = Color.Green;
                        break;
                    default: 
                        startPoint = nudPairStart.getPointH3();
                        endPointRadius = nudPairEnd.getRadiusH3();
                        penColor = Color.Green;
                        break;
                }
                curvePointsList.Add(startPoint);


                PointF betweenPoint = getBeetwenPoint(centerCoordinates, nudPairStart, nudPairEnd, isLast, endPointRadius);
                curvePointsList.Add(betweenPoint);

                List<PointF> listPointFromBeetwenPointToEndPoint = getListPointFromBeetwenPointToEndPoint(centerCoordinates, nudPairStart, nudPairEnd, isLast, betweenPoint, endPointRadius);
                curvePointsList = curvePointsList.Concat(listPointFromBeetwenPointToEndPoint).ToList();

                PointF[] curvePoints = curvePointsList.ToArray();

                Pen pen = new Pen(penColor, 2);
                e.Graphics.DrawLines(pen, curvePoints);
            }
        }

        private static List<PointF> getListPointFromBeetwenPointToEndPoint(PointF centerCoordinates, PVNudPair nudPairStart, PVNudPair nudPairEnd, bool isLast, PointF beetwenPoint, float radiusX)
        {
            List<PointF> curvePointsList = new List<PointF>();

            // Lấy ra góc của điểm bắt đầu
            NumericUpDown numericUpDownBetaOfPointStart = nudPairStart.getNudBeta();
            float startAngle = (float)Convert.ToDouble(numericUpDownBetaOfPointStart.Value);

            // Xác định góc của đường thứ 2
            NumericUpDown numericUpDownBeta = nudPairEnd.getNudBeta();
            float numericUpDownBetaValue = (float)Convert.ToDouble(numericUpDownBeta.Value);
            float endAngle = numericUpDownBetaValue;

            // Lấy bán kính của điểm thứ 2
            //NumericUpDown numericUpDownH1 = nudPairEnd.getNudH1();
            //float numericUpDownH1Value = (float)Convert.ToDouble(numericUpDownH1.Value);
            //float radius = getRadius(centerCoordinates);
            //float numberOfCircle = (numericUpDownH1Value / 10);
            //float radiusX = (float)(numberOfCircle * (radius * 0.695 / 12.5));

            for (float _angle = startAngle; _angle <= endAngle; _angle++)
            {
                PointF endPoint = endPointRotation(centerCoordinates.X, centerCoordinates.Y, radiusX, _angle);
                curvePointsList.Add(endPoint);
            }

            if (isLast)
            {
                for (float _angle = startAngle; _angle <= 360; _angle++)
                {
                    PointF endPoint = endPointRotation(centerCoordinates.X, centerCoordinates.Y, radiusX, _angle);
                    curvePointsList.Add(endPoint);
                }

                for (float _angle = 0; _angle <= endAngle; _angle++)
                {
                    PointF endPoint = endPointRotation(centerCoordinates.X, centerCoordinates.Y, radiusX, _angle);
                    curvePointsList.Add(endPoint);
                }
            }

            return curvePointsList;
        }

        private static PointF getBeetwenPoint(PointF centerCoordinates, PVNudPair nudPairStart, PVNudPair nudPairEnd, bool isLast, float radiusX)
        {
            // Xác định góc của điểm thứ nhất
            NumericUpDown numericUpDownBeta = nudPairStart.getNudBeta();
            float numericUpDownBetaValue = (float)Convert.ToDouble(numericUpDownBeta.Value);
            float angle = numericUpDownBetaValue;

            // Lấy bán kính của điểm thứ 2
            //NumericUpDown numericUpDownH1 = nudPairEnd.getNudH1();
            //float numericUpDownH1Value = (float)Convert.ToDouble(numericUpDownH1.Value);
            //float radius = getRadius(centerCoordinates);
            //float numberOfCircle = (numericUpDownH1Value / 10);
            //float radiusX = (float)(numberOfCircle * (radius * 0.695 / 12.5));

            PointF endPoint = endPointRotation(centerCoordinates.X, centerCoordinates.Y, radiusX, angle);

            return endPoint;
        }

        private static List<PointF> getListStartPointSecond(PointF centerCoordinates, PVNudPair nudPairStart, PVNudPair nudPairEnd, bool isLast)
        {
            List<PointF> curvePointsList = new List<PointF>();

            // Xác định góc của đường thẳng
            NumericUpDown numericUpDownBeta = nudPairEnd.getNudBeta();
            float numericUpDownBetaValue = (float)Convert.ToDouble(numericUpDownBeta.Value);
            float angle = numericUpDownBetaValue;
            float lastAngle = getLastAngle(angle);

            // Lấy ra góc của điểm bắt đầu
            NumericUpDown numericUpDownBetaOfPointStart = nudPairStart.getNudBeta();
            float firstAngle = (float)Convert.ToDouble(numericUpDownBetaOfPointStart.Value);
            
            for (float _angle = firstAngle; _angle <= lastAngle; _angle++)
            {
                // Lấy bán kính của điểm thứ nhất
                NumericUpDown numericUpDownH1 = nudPairStart.getNudH1();
                float numericUpDownH1Value = (float)Convert.ToDouble(numericUpDownH1.Value);
                float radius = getRadius(centerCoordinates);
                float numberOfCircle = (numericUpDownH1Value / 10);
                float radiusX = (float)(numberOfCircle * (radius * 0.695 / 12.5));

                PointF endPoint = endPointRotation(centerCoordinates.X, centerCoordinates.Y, radiusX, _angle);
                curvePointsList.Add(endPoint);
            }

            if(isLast)
            {
                for (float _angle = firstAngle; _angle <= 360; _angle++)
                {
                    // Lấy bán kính của điểm thứ nhất
                    NumericUpDown numericUpDownH1 = nudPairStart.getNudH1();
                    float numericUpDownH1Value = (float)Convert.ToDouble(numericUpDownH1.Value);
                    float radius = getRadius(centerCoordinates);
                    float numberOfCircle = (numericUpDownH1Value / 10);
                    float radiusX = (float)(numberOfCircle * (radius * 0.695 / 12.5));

                    PointF endPoint = endPointRotation(centerCoordinates.X, centerCoordinates.Y, radiusX, _angle);
                    curvePointsList.Add(endPoint);
                }

                for (float _angle = 0; _angle <= lastAngle; _angle++)
                {
                    // Lấy bán kính của điểm thứ nhất
                    NumericUpDown numericUpDownH1 = nudPairStart.getNudH1();
                    float numericUpDownH1Value = (float)Convert.ToDouble(numericUpDownH1.Value);
                    float radius = getRadius(centerCoordinates);
                    float numberOfCircle = (numericUpDownH1Value / 10);
                    float radiusX = (float)(numberOfCircle * (radius * 0.695 / 12.5));

                    PointF endPoint = endPointRotation(centerCoordinates.X, centerCoordinates.Y, radiusX, _angle);
                    curvePointsList.Add(endPoint);
                }
            }

            return curvePointsList;
        }

        private static List<PointF> getListEndPointSecond(PointF centerCoordinates, PVNudPair nudPairStart, PVNudPair nudPairEnd)
        {
            List<PointF> curvePointsList = new List<PointF>();

            NumericUpDown numericUpDownBeta = nudPairEnd.getNudBeta();
            float numericUpDownBetaValue = (float)Convert.ToDouble(numericUpDownBeta.Value);
            float angle = numericUpDownBetaValue;
            float lastAngle = getLastAngle(angle);

            for (float _angle = lastAngle; _angle <= angle; _angle++)
            {
                NumericUpDown numericUpDownH1 = nudPairEnd.getNudH1();
                float numericUpDownH1Value = (float)Convert.ToDouble(numericUpDownH1.Value);
                float radius = getRadius(centerCoordinates);
                float numberOfCircle = (numericUpDownH1Value / 10);
                float radiusX = (float)(numberOfCircle * (radius * 0.695 / 12.5));

                PointF endPoint = endPointRotation(centerCoordinates.X, centerCoordinates.Y, radiusX, _angle);
                curvePointsList.Add(endPoint);
            }

            return curvePointsList;
        }

        /**
         * Tìm góc gần nhất chia hết cho 10 nằm ở trước nó,
         * Ví dụ: 13,4 trả lại 10; 89,7 thì trả lại 80; ...
         */
        private static float getLastAngle(float angle)
        {
            if (angle < 10)
                return 0; 

            int phanDu = (int) (angle / 10);

            return phanDu * 10F;
        }

        private static List<PointF> getCurvePointList(PVPHMPTabPage _this, PointF centerCoordinates)
        {
            List<PointF> curvePointsList = new List<PointF>();
            for (int idx = 0; idx < _this.nudPairCollection.Count; idx++)
            {
                PVNudPair PVNudPair = _this.nudPairCollection[idx];
                float radius = getRadius(centerCoordinates);

                NumericUpDown numericUpDownBeta = PVNudPair.getNudBeta();
                float numericUpDownBetaValue = (float)Convert.ToDouble(numericUpDownBeta.Value);
                //dựa vào β để xác định góc của điểm
                float angle = numericUpDownBetaValue;


                // H1
                NumericUpDown numericUpDownH1 = PVNudPair.getNudH1();
                float numericUpDownH1Value = (float)Convert.ToDouble(numericUpDownH1.Value);
                //α để xác định cự ly từ tâm đến điểm, Giá trị α chỉ nằm trong khoảng từ 0 đến 5 độ tương ứng với nó nằm trong khoảng từ vòng 1 đến vòng thứ 11
                
                float numberOfCircle = (numericUpDownH1Value / 10);
                float radiusX = (float)(numberOfCircle * (radius * 0.695 / 12.5));
                PointF endPointH1 = endPointRotation(centerCoordinates.X, centerCoordinates.Y, radiusX, angle);
                PVNudPair.setPointH1(endPointH1);
                PVNudPair.setNumberOfCircleH1((int)numberOfCircle);
                PVNudPair.setRadiusH1((int)radiusX);

                // H2
                NumericUpDown numericUpDownH2 = PVNudPair.getNudH2();
                float numericUpDownH2Value = (float)Convert.ToDouble(numericUpDownH2.Value);
                float numberOfCircleH2 = (numericUpDownH2Value / 10);
                float radiusXH2 = (float)(numberOfCircleH2 * (radius * 0.695 / 12.5));
                PointF endPointH2 = endPointRotation(centerCoordinates.X, centerCoordinates.Y, radiusXH2, angle);
                PVNudPair.setPointH2(endPointH2);
                PVNudPair.setNumberOfCircleH2((int)numberOfCircleH2);
                PVNudPair.setRadiusH2((int)radiusXH2);

                // H3
                NumericUpDown numericUpDownH3 = PVNudPair.getNudH3();
                float numericUpDownH3Value = (float)Convert.ToDouble(numericUpDownH3.Value);
                float numberOfCircleH3 = (numericUpDownH3Value / 10);
                float radiusXH3 = (float)(numberOfCircleH3 * (radius * 0.695 / 12.5));
                PointF endPointH3 = endPointRotation(centerCoordinates.X, centerCoordinates.Y, radiusXH3, angle);
                PVNudPair.setPointH3(endPointH3);
                PVNudPair.setNumberOfCircleH3((int)numberOfCircleH3);
                PVNudPair.setRadiusH3((int)radiusXH3);


                _this.nudPairCollection[idx] = PVNudPair;

                curvePointsList.Add(endPointH1);
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
            for (int numberOfCircle = 1; numberOfCircle <= 17; numberOfCircle++)
            {
                float radiusX = (float)(numberOfCircle * (radius * 0.695 / 12.5));

                Pen drawCirclePen = thickPen;
                if (numberOfCircle == 5 || numberOfCircle == 10 || numberOfCircle == 15)
                    
                    drawCirclePen = new Pen(grayColor, 3); ;

                drawCircle(e.Graphics, drawCirclePen, centerCoordinates.X, centerCoordinates.Y, radiusX);
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
                float xRotation = (angle == 360 || angle == 180) ? -10F : (angle < 180 ? Math.Abs(90 - angle) / 90 * 3F : -(Math.Abs(270 - angle) / 90 * 1F + 25F));
                float yRotation = (angle == 90 || angle == 270) ? -5F : ((angle > 90 && angle < 270) ? 0 : -15F);
                using (Font font1 = new Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point))
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


        //List<PointF> startPointSecond = getListStartPointSecond(centerCoordinates, nudPairStart, nudPairEnd, isLast);
        //curvePointsList = curvePointsList.Concat(startPointSecond).ToList();

        //List<PointF> endPointSecond = getListEndPointSecond(centerCoordinates, nudPairStart, nudPairEnd);
        //curvePointsList = curvePointsList.Concat(endPointSecond).ToList();

        //PointF endPoint = nudPairEnd.getPoint();
        //curvePointsList.Add(endPoint);
    }
}