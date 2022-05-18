using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using RadarAnalyst.UIComponent.ComponentI;
using RadarAnalyst.UIComponent.Element;
using Uno.UI.Xaml.Controls;

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

        private LabelCtm label_beta_title;
        private NumericUpDown nud_beta;
        private LabelCtm label_D_title;

        private LabelCtm label_delta_h_title;
        //private NumericUpDown nud_d;
        private LabelCtm label_l_unit;

        private LabelCtm label_delta_H_tt_title;
        //private NumericUpDown nud_delta_h;
        private LabelCtm label_delta_H_tt_unit;

        private LabelCtm label_first_result_title;
        private LabelCtm label_first_result_value;
        private LabelCtm label_first_result_unit;

        private LabelCtm label_second_result_title;
        private LabelCtm label_second_result_value;

        int pictureBoxHeight = 390;
        int pictureBoxWidth = 830;

        private const float nud_beta_default_value = 7.5F;
        private const float nud_d_default_value = 1000.0F;
        private const float nud_delta_h_default_value = 5.0F;
        private float hRotation = 1.5F;
        private float lRotation = 7.5F;

        private Color groupBoxColor = System.Drawing.ColorTranslator.FromHtml("#19182a");
        private Color lineBlueColor = System.Drawing.ColorTranslator.FromHtml("#e35736");
        private Color violetColor = System.Drawing.ColorTranslator.FromHtml("#c74259");
        private Color textColor = System.Drawing.ColorTranslator.FromHtml("#7a8696");

        private List<NumericUpDown> nudDCollection = new List<NumericUpDown>();
        private List<NumericUpDown> nudDeltaHCollection = new List<NumericUpDown>();

        public MCDHTabPage(String tabCode, String text) : base(tabCode, text)
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

            //ScrollBar hSBar = new ScrollBar();
            //hSBar.Orientation = Orientation.Horizontal;
            //hSBar.HorizontalAlignment = HorizontalAlignment.Left;
            //hSBar.Width = 250;
            //hSBar.Height = 30;
            //hSBar.Background = new SolidColorBrush(Colors.LightSalmon);
            //hSBar.Minimum = 1;
            //hSBar.Maximum = 240;
            //hSBar.Value = 50;
            //LayoutRoot.Children.Add(hSBar);

            //ScrollViewer viewer = new();
            //viewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            Panel panel = new Panel();
            panel.AutoScroll = true;
            //panel.HorizontalScroll = true;
            //panel.SetAutoScrollMargin(0, 222);
            //panel.BackColor = Color.AliceBlue;
            panel.Height = 250;
            panel.Width = 175;
            panel.Location = new System.Drawing.Point(80, 80);

            for (int i = 0; i< 10; i++)
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
                nud_d.Maximum = 9999999999;
                nud_d.Minimum = 0;
                nud_d.DecimalPlaces = 1;
                nud_d.Increment = 0.1m;
                nud_d.Value = new decimal(0);

                // nud_delta_h
                nud_delta_h.Location = new System.Drawing.Point(80, 0 + i * 30);
                nud_delta_h.Name = "nud_delta_h";
                nud_delta_h.Size = new System.Drawing.Size(70, 30);
                nud_delta_h.TabIndex = 6;
                nud_delta_h.Maximum = 9999999999;
                nud_delta_h.Minimum = 0;
                nud_delta_h.DecimalPlaces = 1;
                nud_delta_h.Increment = 0.1m;
                nud_delta_h.Value = new decimal(0);

                panel.Controls.Add(nud_d);
                panel.Controls.Add(nud_delta_h);
                //this.gb_inputTable.Controls.Add(nud_d);
                //this.gb_inputTable.Controls.Add(nud_delta_h);

                this.nudDCollection.Add(nud_d);
                this.nudDeltaHCollection.Add(nud_delta_h);

                ((System.ComponentModel.ISupportInitialize)(nud_d)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(nud_delta_h)).EndInit();
            }

            this.gb_inputTable.Controls.Add(panel);
        }


        private void initOutputTable()
        {
            this.label_first_result_title = new LabelCtm();
            this.label_first_result_value = new LabelCtm();
            this.label_first_result_unit = new LabelCtm();

            //this.label_second_result_title = new LabelCtm();
            //this.label_second_result_value = new LabelCtm();

            // 
            // gb_ouputTable
            // 
            this.gb_ouputTable.Controls.Add(this.label_first_result_title);
            this.gb_ouputTable.Controls.Add(this.label_first_result_value);
            this.gb_ouputTable.Controls.Add(this.label_first_result_unit);

            //this.gb_ouputTable.Controls.Add(this.label_second_result_title);
            //this.gb_ouputTable.Controls.Add(this.label_second_result_value);

            // ================================================================
            // label_first_result_title
            this.label_first_result_title.AutoSize = true;
            this.label_first_result_title.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_first_result_title.Location = new System.Drawing.Point(30, 50);
            this.label_first_result_title.Name = "label_first_result_title";
            this.label_first_result_title.Size = new System.Drawing.Size(180, 31);
            this.label_first_result_title.TabIndex = 0;
            this.label_first_result_title.Text = "Độ nghiêng trung bình: ";
            // label_first_result_value
            this.label_first_result_value.AutoSize = true;
            this.label_first_result_value.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_first_result_value.ForeColor = System.Drawing.Color.Red;
            this.label_first_result_value.Location = new System.Drawing.Point(270, 50);
            this.label_first_result_value.Name = "label_first_result_value";
            this.label_first_result_value.Size = new System.Drawing.Size(30, 31);
            this.label_first_result_value.TabIndex = 1;
            this.label_first_result_value.Text = "";
            // label17
            this.label_first_result_unit.AutoSize = true;
            this.label_first_result_unit.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_first_result_unit.Location = new System.Drawing.Point(380, 50);
            this.label_first_result_unit.Name = "label_first_result_unit";
            this.label_first_result_unit.Size = new System.Drawing.Size(10, 31);
            this.label_first_result_unit.TabIndex = 2;
            this.label_first_result_unit.Text = "độ";

            //// ================================================================
            //// label_second_result_title
            //this.label_second_result_title.AutoSize = true;
            //this.label_second_result_title.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            //this.label_second_result_title.Location = new System.Drawing.Point(30, 90);
            //this.label_second_result_title.Name = "label_second_result_title";
            //this.label_second_result_title.Size = new System.Drawing.Size(150, 31);
            //this.label_second_result_title.TabIndex = 3;
            //this.label_second_result_title.Text = "Đánh giá";
            //// label_second_result_value
            //this.label_second_result_value.AutoSize = true;
            //this.label_second_result_value.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            //this.label_second_result_value.ForeColor = System.Drawing.Color.Red;
            //this.label_second_result_value.Location = new System.Drawing.Point(120, 90);
            //this.label_second_result_value.Name = "label_second_result_value";
            //this.label_second_result_value.Size = new System.Drawing.Size(66, 31);
            //this.label_second_result_value.TabIndex = 4;
            //this.label_second_result_value.Text = "Đạt/Không đạt";
        }
        private void btn_P_18M_Click(object sender, EventArgs e)
        {
            //btn_P_18M.BackColor = Color.LightBlue;
            //btn_VRS_2DM.BackColor = Color.AliceBlue;
            btn_VRS_2DM.setBackColor(false);
            btn_P_18M.setBackColor(true);
            this.modOn = P_18M;
        }

        private void btn_VRS_2DM_Click(object sender, EventArgs e)
        {
            //btn_P_18M.BackColor = Color.AliceBlue;
            //btn_VRS_2DM.BackColor = Color.LightBlue;
            btn_VRS_2DM.setBackColor(true);
            btn_P_18M.setBackColor(false);
            this.modOn = VRS_2DM;
        }

        public override void btn_ok_click(object sender, EventArgs e)
        {
            //            float haValue = (float)Convert.ToDouble(nud_beta.Value);
            //            float lValue = (float)Convert.ToDouble(nud_d.Value);
            //            float delta_H_ttValue = (float)Convert.ToDouble(nud_delta_h.Value);
            //            float deltaHValue = 0F;

            //            switch (this.modOn)
            //            {
            //                case P_18M:
            //                    deltaHValue = 3440 - (haValue * delta_H_ttValue) / lValue;
            //                    break;
            //                case VRS_2DM:
            //                    deltaHValue = 3440 - (haValue * delta_H_ttValue) / lValue;
            //                    break;
            //                default:
            //                    break;
            //            }

            //            // set result value 1
            //            label_first_result_value.Text = Math.Round(deltaHValue, 2).ToString();

            // ======================================================================================
            this.gb_picture.Controls.Remove(this.pictureBox1);
            // Dock the PictureBox to the form and set its background to white.
            //this.pictureBox1.Dock = DockStyle.Fill;
            this.pictureBox1.Location = new Point(0, 0);
            this.pictureBox1.Size = new System.Drawing.Size(pictureBoxWidth, pictureBoxHeight);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            //string path = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            //this.pictureBox1.ImageLocation = path + "/Images/DoNghiengTrungBinh.jpg";

            this.pictureBox1.BackColor = groupBoxColor;
            // Connect the Paint event of the PictureBox to the event handler method.
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.drawGraph);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            // Add the PictureBox control to the Form.
            this.gb_picture.Controls.Add(this.pictureBox1);
        }

        private void drawGraph(object sender, PaintEventArgs e)
        {
            Color whiteColor = Color.White;
            // draw x line
            Pen pen = new Pen(whiteColor, 2);
            PointF point1 = new PointF(60F, 20.0F);
            PointF point2 = new PointF(60F, 380.0F);
            e.Graphics.DrawLine(pen, point1, point2);
            // draw top arrow
            e.Graphics.DrawLine(pen, new PointF(60F, 20.0F), new PointF(60F - 10F, 20.0F + 10F));
            e.Graphics.DrawLine(pen, new PointF(60F - 1F, 20.0F), new PointF(60F - 1F + 10F, 20.0F + 10F));
            // draw H text
            string Htext = "H";
            using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
            {
                RectangleF rectF1 = new RectangleF(25F, 20F, 15, 15);
                SolidBrush whiteBrush = new SolidBrush(groupBoxColor);
                e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                e.Graphics.DrawString(Htext, font1, Brushes.White, rectF1);
            }
            // draw vạch
            float textUnit = 8;
            for (int i = 2; i <= 10; i++)
            {
                float unitX = 30F;
                point1 = new PointF(60F, i * unitX + 20F);
                point2 = new PointF(55F, i * unitX + 20F);
                e.Graphics.DrawLine(pen, point1, point2);

                // draw text ha
                string unitTextDisplay = (textUnit > 0) ? textUnit.ToString() : (0 - textUnit).ToString();
                using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
                {
                    RectangleF rectF1 = new RectangleF(unitTextDisplay == "0" ? 25F : 35F, i * unitX + 10F, 15, 15);
                    SolidBrush whiteBrush = new SolidBrush(groupBoxColor);
                    e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                    e.Graphics.DrawString((unitTextDisplay == "0") ? "O" : unitTextDisplay, font1, Brushes.White, rectF1);
                }
                textUnit -= 2;
            }
            for (int i = 7; i <= 10; i++)
            {
                float unitX = 30F;
                point1 = new PointF(60F, i * unitX + 20F);
                point2 = new PointF(50F, i * unitX + 20F);
                e.Graphics.DrawLine(pen, point1, point2);

                // draw text ha
                using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
                {
                    RectangleF rectF1 = new RectangleF(25F, i * unitX + 10F, 10, 15);
                    SolidBrush whiteBrush = new SolidBrush(groupBoxColor);
                    e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                    e.Graphics.DrawString("-", font1, Brushes.White, rectF1);
                }
            }

            // draw y line
            pen = new Pen(whiteColor, 2);
            point1 = new PointF(60F, 200.0F);
            point2 = new PointF(750F, 200.0F);
            e.Graphics.DrawLine(pen, point1, point2);
            // draw right arrow
            e.Graphics.DrawLine(pen, new PointF(750F, 200.0F), new PointF(750F - 10F, 200.0F - 10F));
            e.Graphics.DrawLine(pen, new PointF(750F, 200.0F), new PointF(750F - 10F, 200.0F + 10F));
            // draw vạch
            float ytextUnit = 200;
            for (int i = 1; i <= 7; i++)
            {
                float unitY = 80F;
                point1 = new PointF(60F + i * unitY, 200F);
                point2 = new PointF(60F + i * unitY, 210F);
                e.Graphics.DrawLine(pen, point1, point2);

                // draw text ha
                string unitTextDisplay = ytextUnit.ToString();
                float div = 15F;
                if (ytextUnit >= 1000) div = 22F;
                using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
                {
                    RectangleF rectF1 = new RectangleF(60F - div + i * unitY, 215F, 45, 15);
                    SolidBrush whiteBrush = new SolidBrush(groupBoxColor);
                    e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                    e.Graphics.DrawString(unitTextDisplay, font1, Brushes.White, rectF1);
                }
                ytextUnit += 200;
            }

            // draw curve
            pen = new Pen(lineBlueColor, 2);
            float oX = 60F;
            float oY = 200F;
            // Create points that define curve.
            List<PointF> curvePointsList = new List<PointF>();
            for (int idx = 0; idx < this.nudDCollection.Count; idx++)
            {
                NumericUpDown numericUpDownD = this.nudDCollection[idx];
                float x = (float) Convert.ToDouble(numericUpDownD.Value);

                NumericUpDown numericUpDownH = this.nudDeltaHCollection[idx];
                float y = (float)Convert.ToDouble(numericUpDownH.Value);

                curvePointsList.Add(new PointF(oX + (x * 150F / 200F) * 80F, oY - (y * 0F / 2F) * 30F));
            }

            PointF[] curvePoints = curvePointsList.ToArray();

            //PointF curvePoint1 = new PointF(oX + (150F / 200F) * 80F, oY - (0F / 2F) * 30F);
            //PointF curvePoint2 = new PointF(oX + (250F / 200F) * 80F, oY - (2F / 2F) * 30F);
            //PointF curvePoint3 = new PointF(oX + (310F / 200F) * 80F, oY - (1F / 2F) * 30F);
            //PointF curvePoint4 = new PointF(oX + (420F / 200F) * 80F, oY - (1F / 2F) * 30F);
            //PointF curvePoint5 = new PointF(oX + (500F / 200F) * 80F, oY - (-2F / 2F) * 30F);
            //PointF curvePoint6 = new PointF(oX + (700F / 200F) * 80F, oY - (-3F / 2F) * 30F);
            //PointF[] curvePoints = { curvePoint1, curvePoint2, curvePoint3, curvePoint4, curvePoint5, curvePoint6,
            //    new PointF(oX + (900F / 200F) * 80F, oY - (-2F / 2F) * 30F),
            //    new PointF(oX + (1170F / 200F) * 80F, oY - (-4F / 2F) * 30F),
            //    new PointF(oX + (1500F / 200F) * 80F, oY - (2F / 2F) * 30F)
            //};
            e.Graphics.DrawLines(pen, curvePoints);
        }
    }
}