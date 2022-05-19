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
    public partial class MCDHTabPage : TabPageCI
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
        private LabelCtm label_D_title;

        private LabelCtm label_delta_h_title;

        int pictureBoxHeight = 600;
        int pictureBoxWidth = 830;

        private const float nud_beta_default_value = 7.5F;

        private Color groupBoxColor = System.Drawing.ColorTranslator.FromHtml("#19182a");
        private Color lineBlueColor = System.Drawing.ColorTranslator.FromHtml("#e35736");
        private Color violetColor = System.Drawing.ColorTranslator.FromHtml("#c74259");
        private Color textColor = System.Drawing.ColorTranslator.FromHtml("#7a8696");

        private List<NudPair> nudPairCollection = new List<NudPair>();

        Random rnd = new Random();

        public MCDHTabPage(String tabCode, String text) : base(tabCode, text)
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
            this.label_D_title = new LabelCtm();
            this.label_delta_h_title = new LabelCtm();

            // 
            // gb_inputTable
            // 
            this.gb_inputTable.Controls.Add(this.label_beta_title);
            this.gb_inputTable.Controls.Add(this.label_D_title);
            this.gb_inputTable.Controls.Add(this.label_delta_h_title);

            // ================================================================
            // header
            this.label_beta_title.AutoSize = true;
            this.label_beta_title.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_beta_title.Location = new System.Drawing.Point(20, 50);
            this.label_beta_title.Name = "label_beta_title";
            this.label_beta_title.Size = new System.Drawing.Size(58, 20);
            this.label_beta_title.TabIndex = 13;
            this.label_beta_title.Text = "β";

            this.label_D_title.AutoSize = true;
            this.label_D_title.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_D_title.Location = new System.Drawing.Point(100, 50);
            this.label_D_title.Name = "label_D_title";
            this.label_D_title.Size = new System.Drawing.Size(58, 20);
            this.label_D_title.TabIndex = 13;
            this.label_D_title.Text = "D";

            this.label_delta_h_title.AutoSize = true;
            this.label_delta_h_title.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_delta_h_title.Location = new System.Drawing.Point(180, 50);
            this.label_delta_h_title.Name = "label_delta_h_title";
            this.label_delta_h_title.Size = new System.Drawing.Size(58, 20);
            this.label_delta_h_title.TabIndex = 13;
            this.label_delta_h_title.Text = "Δh";



            // ================================================================
            this.nud_beta = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud_beta)).BeginInit();
            this.gb_inputTable.Controls.Add(this.nud_beta);
            // nud_beta
            this.nud_beta.Location = new System.Drawing.Point(5, 80);
            this.nud_beta.Name = "nud_beta";
            this.nud_beta.Size = new System.Drawing.Size(70, 30);
            this.nud_beta.TabIndex = 6;
            this.nud_beta.Maximum = 9999999999;
            this.nud_beta.Minimum = 0;
            this.nud_beta.DecimalPlaces = 1;
            this.nud_beta.Increment = 0.1m;
            this.nud_beta.Value = new decimal(nud_beta_default_value);
            ((System.ComponentModel.ISupportInitialize)(this.nud_beta)).EndInit();

            Panel panel = new Panel();
            panel.AutoScroll = true;
            panel.Height = 250;
            panel.Width = 175;
            panel.Location = new System.Drawing.Point(80, 80);

            for (int i = 0; i < 10; i++)
            {
                NumericUpDown nud_d = new System.Windows.Forms.NumericUpDown();
                NumericUpDown nud_delta_h = new System.Windows.Forms.NumericUpDown();

                ((System.ComponentModel.ISupportInitialize)(nud_d)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(nud_delta_h)).BeginInit();

                // nud_d
                nud_d.Location = new System.Drawing.Point(0, 0 + i * 30);
                nud_d.Name = "nud_d";
                nud_d.Size = new System.Drawing.Size(70, 30);
                nud_d.TabIndex = 6;
                nud_d.Maximum = 9999999;
                nud_d.Minimum = 0;
                nud_d.DecimalPlaces = 1;
                nud_d.Increment = 0.1m;
                nud_d.Value = new decimal(rnd.Next(1, 200));

                // nud_delta_h
                nud_delta_h.Location = new System.Drawing.Point(80, 0 + i * 30);
                nud_delta_h.Name = "nud_delta_h";
                nud_delta_h.Size = new System.Drawing.Size(70, 30);
                nud_delta_h.TabIndex = 6;
                nud_delta_h.Maximum = 9999999;
                nud_delta_h.Minimum = -9999999;
                nud_delta_h.DecimalPlaces = 1;
                nud_delta_h.Increment = 0.1m;
                nud_delta_h.Value = new decimal(rnd.Next(-20, 20));

                panel.Controls.Add(nud_d);
                panel.Controls.Add(nud_delta_h);

                NudPair nudPair = new NudPair(nud_d, nud_delta_h);
                this.nudPairCollection.Add(nudPair);

                ((System.ComponentModel.ISupportInitialize)(nud_d)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(nud_delta_h)).EndInit();
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
            this.btn_save = new ButtonCtm("Save");
            this.gb_picture.Controls.Add(this.btn_save);
            this.btn_save.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_save.Location = new System.Drawing.Point(710, 500);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(50, 31);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "Lưu đồ thị";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_click);

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
            drawOy(e, groupBoxColor);
            drawOx(e, groupBoxColor);
            drawCurve(e, lineBlueColor, this);
        }

        private static void drawCurve(PaintEventArgs e, Color lineBlueColor, MCDHTabPage _this)
        {
            // draw curve
            Pen pen = new Pen(lineBlueColor, 2);
            float oX = 60F;
            float oY = 290.0F;

            //Sort numeric-up-down-pair list
            _this.nudPairCollection.Sort((p, q) => p.getNudD().Value.CompareTo(q.getNudD().Value));

            // Create points that define curve.
            List<PointF> curvePointsList = new List<PointF>();
            curvePointsList.Add(new PointF(oX, oY));
            for (int idx = 0; idx < _this.nudPairCollection.Count; idx++)
            {
                NudPair nudPair = _this.nudPairCollection[idx];

                NumericUpDown numericUpDownD = nudPair.getNudD();
                float x = (float)Convert.ToDouble(numericUpDownD.Value);

                NumericUpDown numericUpDownH = nudPair.getNudDeltaH();
                float y = (float)Convert.ToDouble(numericUpDownH.Value);

                // sum delta H if exist pre numeric up down
                NudPair preNudPair = null;
                float preY = 0;
                if (idx > 0)
                {
                    preNudPair = _this.nudPairCollection[idx - 1];
                    NumericUpDown preNumericUpDownH = preNudPair.getNudDeltaH();
                    preY = (float)Convert.ToDouble(preNumericUpDownH.Value);
                    y = y + preY;
                }

                if (x == 0 && y == 0)
                    continue;

                float pointX = oX + (x / 10) * 35F;
                float pointY = oY - (y / 5) * 30F;
                curvePointsList.Add(new PointF(pointX, pointY));

                // draw dash line ha
                float[] dashValues = { 3, 3, 3, 3 };
                Pen dashPen = new Pen(Color.White, 1);
                dashPen.DashPattern = dashValues;
                e.Graphics.DrawLine(dashPen, new PointF(oX, pointY), new PointF(pointX, pointY));
                e.Graphics.DrawLine(dashPen, new PointF(pointX, oY), new PointF(pointX, pointY));
            }

            PointF[] curvePoints = curvePointsList.ToArray();

            e.Graphics.DrawLines(pen, curvePoints);
        }

        private static void drawOy(PaintEventArgs e, Color groupBoxColor)
        {
            Color whiteColor = Color.White;
            // draw x line
            Pen pen = new Pen(whiteColor, 2);
            float topY = 50.0F;
            PointF point1 = new PointF(60F, topY);
            PointF point2 = new PointF(60F, 500.0F);
            e.Graphics.DrawLine(pen, point1, point2);
            // draw top arrow
            e.Graphics.DrawLine(pen, new PointF(60F, topY), new PointF(60F - 10F, topY + 10F));
            e.Graphics.DrawLine(pen, new PointF(60F - 1F, topY), new PointF(60F - 1F + 10F, topY + 10F));
            // draw H text
            string Htext = "H (m)";
            using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
            {
                RectangleF rectF1 = new RectangleF(0F, topY, 50, 15);
                SolidBrush whiteBrush = new SolidBrush(groupBoxColor);
                e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                e.Graphics.DrawString(Htext, font1, Brushes.White, rectF1);
            }

            // draw vạch
            float textUnit = 30;
            int numberOfVach = 12;
            int startIndex = 3;
            for (int i = startIndex; i <= startIndex + numberOfVach; i++)
            {
                float unitX = 30F;
                point1 = new PointF(60F, i * unitX + 20F);
                point2 = new PointF(55F, i * unitX + 20F);
                e.Graphics.DrawLine(pen, point1, point2);

                // draw text ha
                string unitTextDisplay = (textUnit > 0) ? textUnit.ToString() : (0 - textUnit).ToString();
                using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
                {
                    RectangleF rectF1 = new RectangleF(unitTextDisplay == "0" ? 25F : 25F, i * unitX + 10F, 25, 15);
                    SolidBrush whiteBrush = new SolidBrush(groupBoxColor);
                    e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                    e.Graphics.DrawString((unitTextDisplay == "0") ? "O" : unitTextDisplay, font1, Brushes.White, rectF1);
                }
                textUnit -= 5;
            }
            for (int i = startIndex + numberOfVach / 2 + 1; i <= startIndex + numberOfVach; i++)
            {
                float unitX = 30F;
                point1 = new PointF(60F, i * unitX + 20F);
                point2 = new PointF(50F, i * unitX + 20F);
                e.Graphics.DrawLine(pen, point1, point2);

                // draw text ha
                using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
                {
                    RectangleF rectF1 = new RectangleF(15F, i * unitX + 10F, 10, 15);
                    SolidBrush whiteBrush = new SolidBrush(groupBoxColor);
                    e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                    e.Graphics.DrawString("-", font1, Brushes.White, rectF1);
                }
            }
        }

        private static void drawOx(PaintEventArgs e, Color groupBoxColor)
        {
            float oyPosition = 290.0F;
            Color whiteColor = Color.White;
            // draw y line
            Pen pen = new Pen(whiteColor, 2);
            PointF point1 = new PointF(60F, oyPosition);
            PointF point2 = new PointF(800F, oyPosition);
            e.Graphics.DrawLine(pen, point1, point2);
            // draw right arrow
            e.Graphics.DrawLine(pen, new PointF(800F, oyPosition), new PointF(800F - 10F, oyPosition - 10F));
            e.Graphics.DrawLine(pen, new PointF(800F, oyPosition), new PointF(800F - 10F, oyPosition + 10F));
            // draw vạch
            float ytextUnit = 10;
            for (int i = 1; i <= 20; i++)
            {
                float unitY = 35F;
                point1 = new PointF(60F + i * unitY, oyPosition);
                point2 = new PointF(60F + i * unitY, oyPosition + 10F);
                e.Graphics.DrawLine(pen, point1, point2);

                // draw text ha
                string unitTextDisplay = ytextUnit.ToString();
                float div = 15F;
                if (ytextUnit >= 1000) div = 22F;
                using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
                {
                    RectangleF rectF1 = new RectangleF(60F - div + i * unitY, oyPosition + 15F, 45, 15);
                    SolidBrush whiteBrush = new SolidBrush(groupBoxColor);
                    e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                    e.Graphics.DrawString(unitTextDisplay, font1, Brushes.White, rectF1);
                }
                ytextUnit += 10;
            }

            // draw D text
            string Htext = "D (km)";
            using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
            {
                RectangleF rectF1 = new RectangleF(770F, oyPosition - 30F, 60, 15);
                SolidBrush whiteBrush = new SolidBrush(groupBoxColor);
                e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                e.Graphics.DrawString(Htext, font1, Brushes.White, rectF1);
            }
        }
    }
}