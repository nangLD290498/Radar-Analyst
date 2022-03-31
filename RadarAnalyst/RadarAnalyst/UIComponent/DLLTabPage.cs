using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarAnalyst.UIComponent
{
    public partial class DLLTabPage : TabPage
    {
        private const int lambdaValue = 2;
        private const String P_18M = "P_18M";
        private const String VRS_2DM = "VRS_2DM";
        private String modOn = P_18M;

        private Button btn_P_18M;
        private Button btn_VRS_2DM;

        private GroupBox gb_picture;
        private GroupBox gb_ouputTable;
        private GroupBox gb_inputTable;
        private Button btn_ok;

        private Label label_ha_title;
        private NumericUpDown nud_ha;
        private Label label_ha_unit;

        private Label label_l_title;
        private NumericUpDown nud_l;
        private Label label_l_unit;

        private Label label_delta_H_tt_title;
        private NumericUpDown nud_delta_H_tt;
        private Label label_delta_H_tt_unit;

        private Label label_first_result_title;
        private Label label_first_result_value;
        private Label label_first_result_unit;

        private Label label_second_result_title;
        private Label label_second_result_value;

        private PictureBox pictureBox1 = new PictureBox();
        int pictureBoxHeight = 500;
        int pictureBoxWidth = 850;

        private const float nud_ha_default_value = 7.5F;
        private const float nud_l_default_value = 1000.0F;
        private const float nud_delta_h_default_value = 5.0F;
        private float hRotation = 1.5F;
        private float lRotation = 7.5F;

        public DLLTabPage(String tabCode, String text) : base(text)
        {
            Console.WriteLine("Init KTMPX Tab Page");
            this.Location = new System.Drawing.Point(4, 24);
            this.Name = tabCode;
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(1326, 633);
            this.TabIndex = 0;
            this.UseVisualStyleBackColor = true;
            this.SuspendLayout();
            // create layout
            initUI();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void initUI()
        {
            // radar buttons
            initRadarButton();
            // input
            this.gb_inputTable = new System.Windows.Forms.GroupBox();
            this.gb_inputTable.SuspendLayout();
            this.Controls.Add(this.gb_inputTable);
            this.gb_inputTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.gb_inputTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gb_inputTable.Location = new System.Drawing.Point(199, 197);
            this.gb_inputTable.MaximumSize = new System.Drawing.Size(253, 250);
            this.gb_inputTable.MinimumSize = new System.Drawing.Size(253, 250);
            this.gb_inputTable.Name = "gb_inputTable";
            this.gb_inputTable.Size = new System.Drawing.Size(253, 250);
            this.gb_inputTable.TabIndex = 3;
            this.gb_inputTable.TabStop = false;
            this.gb_inputTable.Text = "BẢNG NHẬP SỐ LIỆU";
            this.gb_inputTable.ResumeLayout(false);
            this.gb_inputTable.PerformLayout();
            initInputTable();
            // output
            this.gb_ouputTable = new System.Windows.Forms.GroupBox();
            this.gb_ouputTable.SuspendLayout();
            this.Controls.Add(this.gb_ouputTable);
            this.gb_ouputTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_ouputTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gb_ouputTable.Location = new System.Drawing.Point(458, 9);
            this.gb_ouputTable.MaximumSize = new System.Drawing.Size(822, 172);
            this.gb_ouputTable.MinimumSize = new System.Drawing.Size(822, 172);
            this.gb_ouputTable.Name = "gb_ouputTable";
            this.gb_ouputTable.Size = new System.Drawing.Size(822, 172);
            this.gb_ouputTable.TabIndex = 4;
            this.gb_ouputTable.TabStop = false;
            this.gb_ouputTable.Text = "KẾT QUẢ TÍNH TOÁN";
            this.gb_ouputTable.ResumeLayout(false);
            this.gb_ouputTable.PerformLayout();
            initOutputTable();
            //picture
            this.gb_picture = new System.Windows.Forms.GroupBox();
            this.Controls.Add(this.gb_picture);
            this.gb_picture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_picture.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gb_picture.Location = new System.Drawing.Point(458, 197);
            this.gb_picture.MaximumSize = new System.Drawing.Size(822, 396);
            this.gb_picture.MinimumSize = new System.Drawing.Size(822, 396);
            this.gb_picture.Name = "gb_picture";
            this.gb_picture.Size = new System.Drawing.Size(822, 396);
            this.gb_picture.TabIndex = 5;
            this.gb_picture.TabStop = false;

            // ======================================================================================
            // Dock the PictureBox to the form and set its background to white.
            //pictureBox1.Dock = DockStyle.Fill;
            //pictureBox1.Location = new Point(0, 0);
            //pictureBox1.Size = new System.Drawing.Size(pictureBoxWidth, pictureBoxHeight);
            //pictureBox1.BackColor = Color.LightGray;
            // Connect the Paint event of the PictureBox to the event handler method.
            //pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.drawGraph);
            // Add the PictureBox control to the Form.
            //this.gb_picture.Controls.Add(pictureBox1);
        }


        private void initRadarButton()
        {
            this.btn_VRS_2DM = new System.Windows.Forms.Button();
            this.btn_P_18M = new System.Windows.Forms.Button();
            this.Controls.Add(this.btn_VRS_2DM);
            this.Controls.Add(this.btn_P_18M);
            // 
            // btn_VRS_2DM
            // 
            this.btn_VRS_2DM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_VRS_2DM.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_VRS_2DM.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_VRS_2DM.Location = new System.Drawing.Point(47, 286);
            this.btn_VRS_2DM.MaximumSize = new System.Drawing.Size(135, 83);
            this.btn_VRS_2DM.MinimumSize = new System.Drawing.Size(135, 83);
            this.btn_VRS_2DM.Name = "btn_VRS_2DM";
            this.btn_VRS_2DM.Size = new System.Drawing.Size(135, 83);
            this.btn_VRS_2DM.TabIndex = 1;
            this.btn_VRS_2DM.Text = "ĐÀI RA ĐA \n VRS-2DM";
            this.btn_VRS_2DM.UseVisualStyleBackColor = false;
            this.btn_VRS_2DM.Click += new System.EventHandler(this.btn_VRS_2DM_Click);
            // 
            // btn_P_18M
            // 
            this.btn_P_18M.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_P_18M.BackColor = System.Drawing.Color.LightBlue;
            this.btn_P_18M.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_P_18M.Location = new System.Drawing.Point(47, 181);
            this.btn_P_18M.MaximumSize = new System.Drawing.Size(135, 83);
            this.btn_P_18M.MinimumSize = new System.Drawing.Size(135, 83);
            this.btn_P_18M.Name = "btn_P_18M";
            this.btn_P_18M.Size = new System.Drawing.Size(135, 83);
            this.btn_P_18M.TabIndex = 0;
            this.btn_P_18M.Text = "ĐÀI RA ĐA \n P-18 M";
            this.btn_P_18M.UseVisualStyleBackColor = false;
            this.btn_P_18M.Click += new System.EventHandler(this.btn_P_18M_Click);
        }


        private void initInputTable()
        {
            this.label_ha_title = new System.Windows.Forms.Label();
            this.label_ha_unit = new System.Windows.Forms.Label();
            this.label_l_title = new System.Windows.Forms.Label();
            this.label_l_unit = new System.Windows.Forms.Label();
            this.label_delta_H_tt_title = new System.Windows.Forms.Label();
            this.label_delta_H_tt_unit = new System.Windows.Forms.Label();
            this.nud_ha = new System.Windows.Forms.NumericUpDown();
            this.nud_l = new System.Windows.Forms.NumericUpDown();
            this.nud_delta_H_tt = new System.Windows.Forms.NumericUpDown();
            this.btn_ok = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.nud_ha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_l)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_delta_H_tt)).BeginInit();

            // 
            // gb_inputTable
            // 
            this.gb_inputTable.Controls.Add(this.label_ha_title);
            this.gb_inputTable.Controls.Add(this.label_ha_unit);
            this.gb_inputTable.Controls.Add(this.label_l_title);
            this.gb_inputTable.Controls.Add(this.label_l_unit);
            this.gb_inputTable.Controls.Add(this.label_delta_H_tt_title);
            this.gb_inputTable.Controls.Add(this.label_delta_H_tt_unit);
            this.gb_inputTable.Controls.Add(this.nud_ha);
            this.gb_inputTable.Controls.Add(this.nud_l);
            this.gb_inputTable.Controls.Add(this.nud_delta_H_tt);
            this.gb_inputTable.Controls.Add(this.btn_ok);

            // ================================================================
            // label_ha_title
            this.label_ha_title.AutoSize = true;
            this.label_ha_title.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_ha_title.Location = new System.Drawing.Point(21, 40);
            this.label_ha_title.Name = "label_ha_title";
            this.label_ha_title.Size = new System.Drawing.Size(58, 20);
            this.label_ha_title.TabIndex = 13;
            this.label_ha_title.Text = "ha";
            // nud_ha
            this.nud_ha.Location = new System.Drawing.Point(87, 40);
            this.nud_ha.Name = "nud_ha";
            this.nud_ha.Size = new System.Drawing.Size(107, 23);
            this.nud_ha.TabIndex = 6;
            this.nud_ha.Maximum = 9999999999;
            this.nud_ha.Minimum = 0;
            this.nud_ha.DecimalPlaces = 1;
            this.nud_ha.Increment = 0.1m;
            this.nud_ha.Value = new decimal(nud_ha_default_value);
            // label_ha_unit
            this.label_ha_unit.AutoSize = true;
            this.label_ha_unit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_ha_unit.Location = new System.Drawing.Point(207, 40);
            this.label_ha_unit.Name = "label_ha_unit";
            this.label_ha_unit.Size = new System.Drawing.Size(29, 20);
            this.label_ha_unit.TabIndex = 7;
            this.label_ha_unit.Text = "m";

            // ================================================================
            // label_l_title
            this.label_l_title.AutoSize = true;
            this.label_l_title.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_l_title.Location = new System.Drawing.Point(21, 80);
            this.label_l_title.Name = "label_l_title";
            this.label_l_title.Size = new System.Drawing.Size(58, 20);
            this.label_l_title.TabIndex = 13;
            this.label_l_title.Text = "L";
            // nud_hbd
            this.nud_l.Location = new System.Drawing.Point(87, 80);
            this.nud_l.Name = "nud_hbd";
            this.nud_l.Size = new System.Drawing.Size(107, 23);
            this.nud_l.TabIndex = 5;
            this.nud_l.Maximum = 9999999999;
            this.nud_l.Minimum = 0;
            this.nud_l.DecimalPlaces = 1;
            this.nud_l.Increment = 0.1m;
            this.nud_l.Value = new decimal(nud_l_default_value);
            // label_l_unit
            this.label_l_unit.AutoSize = true;
            this.label_l_unit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_l_unit.Location = new System.Drawing.Point(207, 80);
            this.label_l_unit.Name = "label_l_unit";
            this.label_l_unit.Size = new System.Drawing.Size(29, 20);
            this.label_l_unit.TabIndex = 7;
            this.label_l_unit.Text = "m";

            // ================================================================
            // label_l_title
            this.label_delta_H_tt_title.AutoSize = true;
            this.label_delta_H_tt_title.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_delta_H_tt_title.Location = new System.Drawing.Point(21, 120);
            this.label_delta_H_tt_title.Name = "label_delta_H_tt_title";
            this.label_delta_H_tt_title.Size = new System.Drawing.Size(58, 20);
            this.label_delta_H_tt_title.TabIndex = 13;
            this.label_delta_H_tt_title.Text = "Δhtt";
            // nud_hpx
            this.nud_delta_H_tt.Location = new System.Drawing.Point(87, 120);
            this.nud_delta_H_tt.Name = "nud_hpx";
            this.nud_delta_H_tt.Size = new System.Drawing.Size(107, 23);
            this.nud_delta_H_tt.TabIndex = 4;
            this.nud_delta_H_tt.Maximum = 9999999999;
            this.nud_delta_H_tt.Minimum = 0;
            this.nud_delta_H_tt.DecimalPlaces = 1;
            this.nud_delta_H_tt.Increment = 0.1m;
            this.nud_delta_H_tt.Value = new decimal(nud_delta_h_default_value);
            // label_l_unit
            this.label_delta_H_tt_unit.AutoSize = true;
            this.label_delta_H_tt_unit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_delta_H_tt_unit.Location = new System.Drawing.Point(207, 120);
            this.label_delta_H_tt_unit.Name = "label_delta_H_tt_unit";
            this.label_delta_H_tt_unit.Size = new System.Drawing.Size(29, 20);
            this.label_delta_H_tt_unit.TabIndex = 7;
            this.label_delta_H_tt_unit.Text = "m";

            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_ok.Location = new System.Drawing.Point(99, 200);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(61, 31);
            this.btn_ok.TabIndex = 0;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_click);

            ((System.ComponentModel.ISupportInitialize)(this.nud_ha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_l)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_delta_H_tt)).EndInit();
        }


        private void initOutputTable()
        {
            this.label_first_result_title = new System.Windows.Forms.Label();
            this.label_first_result_value = new System.Windows.Forms.Label();
            this.label_first_result_unit = new System.Windows.Forms.Label();

            this.label_second_result_title = new System.Windows.Forms.Label();
            this.label_second_result_value = new System.Windows.Forms.Label();

            // 
            // gb_ouputTable
            // 
            this.gb_ouputTable.Controls.Add(this.label_first_result_title);
            this.gb_ouputTable.Controls.Add(this.label_first_result_value);
            this.gb_ouputTable.Controls.Add(this.label_first_result_unit);

            this.gb_ouputTable.Controls.Add(this.label_second_result_title);
            this.gb_ouputTable.Controls.Add(this.label_second_result_value);

            // ================================================================
            // label_first_result_title
            this.label_first_result_title.AutoSize = true;
            this.label_first_result_title.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_first_result_title.Location = new System.Drawing.Point(30, 50);
            this.label_first_result_title.Name = "label_first_result_title";
            this.label_first_result_title.Size = new System.Drawing.Size(180, 31);
            this.label_first_result_title.TabIndex = 0;
            this.label_first_result_title.Text = "Độ lồi lõm cho phép: ";
            // label_first_result_value
            this.label_first_result_value.AutoSize = true;
            this.label_first_result_value.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_first_result_value.ForeColor = System.Drawing.Color.Red;
            this.label_first_result_value.Location = new System.Drawing.Point(220, 50);
            this.label_first_result_value.Name = "label_first_result_value";
            this.label_first_result_value.Size = new System.Drawing.Size(30, 31);
            this.label_first_result_value.TabIndex = 1;
            this.label_first_result_value.Text = "000000";
            // label17
            this.label_first_result_unit.AutoSize = true;
            this.label_first_result_unit.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_first_result_unit.Location = new System.Drawing.Point(300, 50);
            this.label_first_result_unit.Name = "label_first_result_unit";
            this.label_first_result_unit.Size = new System.Drawing.Size(10, 31);
            this.label_first_result_unit.TabIndex = 2;
            this.label_first_result_unit.Text = "m";

            // ================================================================
            // label_second_result_title
            this.label_second_result_title.AutoSize = true;
            this.label_second_result_title.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_second_result_title.Location = new System.Drawing.Point(30, 90);
            this.label_second_result_title.Name = "label_second_result_title";
            this.label_second_result_title.Size = new System.Drawing.Size(150, 31);
            this.label_second_result_title.TabIndex = 3;
            this.label_second_result_title.Text = "Đánh giá";
            // label_second_result_value
            this.label_second_result_value.AutoSize = true;
            this.label_second_result_value.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_second_result_value.ForeColor = System.Drawing.Color.Red;
            this.label_second_result_value.Location = new System.Drawing.Point(120, 90);
            this.label_second_result_value.Name = "label_second_result_value";
            this.label_second_result_value.Size = new System.Drawing.Size(66, 31);
            this.label_second_result_value.TabIndex = 4;
            this.label_second_result_value.Text = "Đạt/Không đạt";
        }
        private void btn_P_18M_Click(object sender, EventArgs e)
        {
            btn_P_18M.BackColor = Color.LightBlue;
            btn_VRS_2DM.BackColor = Color.AliceBlue;

            this.modOn = P_18M;
        }

        private void btn_VRS_2DM_Click(object sender, EventArgs e)
        {
            btn_P_18M.BackColor = Color.AliceBlue;
            btn_VRS_2DM.BackColor = Color.LightBlue;

            this.modOn = VRS_2DM;
        }

        private void btn_ok_click(object sender, EventArgs e)
        {
            float haValue = (float)Convert.ToDouble(nud_ha.Value);
            float lValue = (float)Convert.ToDouble(nud_l.Value);
            float delta_H_ttValue = (float)Convert.ToDouble(nud_delta_H_tt.Value);
            float deltaHValue = 0F;

            switch (this.modOn)
            {
                case P_18M:
                    deltaHValue = (lValue * lambdaValue) / (32 * haValue);
                    break;
                case VRS_2DM:
                    deltaHValue = (lValue * lambdaValue) / (16 * haValue);
                    break;
                default:
                    break;
            }

            // set result value 1
            label_first_result_value.Text = Math.Round(deltaHValue, 2).ToString();

            // set result value 2
            label_second_result_value.Text = deltaHValue >= delta_H_ttValue ? "Đạt yêu cầu" : "Không đạt yêu cầu";

            // ======================================================================================
            this.gb_picture.Controls.Remove(pictureBox1);
            // Dock the PictureBox to the form and set its background to white.
            //pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Size = new System.Drawing.Size(pictureBoxWidth, pictureBoxHeight);
            pictureBox1.BackColor = Color.LightGray;
            // Connect the Paint event of the PictureBox to the event handler method.
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.drawGraph);
            // Add the PictureBox control to the Form.
            this.gb_picture.Controls.Add(pictureBox1);
            
        }

        private void drawGraph(object sender, PaintEventArgs e)
        {
            float haValue = (float)Convert.ToDouble(nud_ha.Value);
            float lValue = (float)Convert.ToDouble(nud_l.Value);
            float deltaHValue = (float)Convert.ToDouble(nud_delta_H_tt.Value);
            float haBaseX = 150.0F;
            float haBaseY = 50.0F;
            float haOnPicMin = 20F;
            float haOnPicMax = 150F;
            float lOnPicMin = 300F;
            float lOnPicMax = 700F;
            float endLineY = 300F;
            float deltaHOnPicMin = 20F;
            float deltaHOnPicMax = 150F;

            // ========================================================================================================
            // draw begin line
            Pen pen = new Pen(Color.Black, 2);
            PointF point1 = new PointF(haBaseX - 50F, 50.0F);
            PointF point2 = new PointF(haBaseX + 50F, 50.0F);
            e.Graphics.DrawLine(pen, point1, point2);

            float haOnPic = haBaseY + haOnPicMin + haValue / hRotation;
            if(haOnPic > haOnPicMax) haOnPic = haOnPicMax;

            // ========================================================================================================
            // draw ha line black
            pen = new Pen(Color.Black, 2);
            PointF haTopPoint = new PointF(haBaseX, haBaseY);
            PointF haBotPoint = new PointF(haBaseX, haOnPic);
            e.Graphics.DrawLine(pen, haTopPoint, haBotPoint);

            // draw triangle
            //pen = new Pen(Brushes.Black, 2);
            //float haBaseXForTriangle = haBaseX - 15F;
            //e.Graphics.DrawLine(pen, new PointF(0F + haBaseXForTriangle, 30F + haOnPic), new PointF(30 + haBaseXForTriangle, 30F + haOnPic));
            //e.Graphics.DrawLine(pen, new PointF(0 + haBaseXForTriangle, 30F + haOnPic), new PointF(15 + haBaseXForTriangle, 0F + haOnPic));
            //e.Graphics.DrawLine(pen, new PointF(15 + haBaseXForTriangle, 0F + haOnPic), new PointF(30 + haBaseXForTriangle, 30F + haOnPic));

            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            PointF trianglePoint1 = new PointF(haBaseX, haOnPic);
            PointF trianglePoint3 = new PointF(haBaseX + 15F, haOnPic + 30F);
            PointF trianglePoint2 = new PointF(haBaseX - 15F, haOnPic + 30F);
            PointF[] triangleCurvePoints = { trianglePoint1, trianglePoint2, trianglePoint3 };
            e.Graphics.FillPolygon(blueBrush, triangleCurvePoints);


            // ========================================================================================================
            // draw ha line white
            pen = new Pen(Color.White, 2);
            haTopPoint = new PointF(haBaseX - 20F, haBaseY);
            haBotPoint = new PointF(haBaseX - 20F, 30F + haOnPic);
            e.Graphics.DrawLine(pen, haTopPoint, haBotPoint);
            // draw top arrow
            e.Graphics.DrawLine(pen, new PointF(haBaseX - 20F, haBaseY), new PointF(haBaseX - 25F, haBaseY + 5F));
            e.Graphics.DrawLine(pen, new PointF(haBaseX - 20F, haBaseY), new PointF(haBaseX - 15F, haBaseY + 5F));
            // draw bot arrow
            e.Graphics.DrawLine(pen, new PointF(haBaseX - 20F, 30F + haOnPic), new PointF(haBaseX - 25F, 25F + haOnPic));
            e.Graphics.DrawLine(pen, new PointF(haBaseX - 20F, 30F + haOnPic), new PointF(haBaseX - 15F, 25F + haOnPic));
            // draw text ha
            string text1 = " ha";
            using (Font font1 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point))
            {
                float haTextY = haBaseY + haOnPicMin + haValue / hRotation / 2;
                RectangleF rectF1 = new RectangleF(haBaseX - 60F, haOnPic >= haOnPicMax ? haBaseY + haOnPic / 2 - 20F: haTextY, 30, 20);
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                e.Graphics.DrawString(text1, font1, Brushes.Black, rectF1);
            }

            // draw dash line ha
            float[] dashValues = { 3, 3, 3, 3 };
            Pen dashPen = new Pen(Color.White, 2);
            dashPen.DashPattern = dashValues;
            e.Graphics.DrawLine(dashPen, new PointF(haBaseX, haBaseY + haOnPic - 15F), new PointF(haBaseX, endLineY + 50F));


            // ========================================================================================================
            // draw line L
            float lOnPic = haBaseX + lOnPicMin + lValue / lRotation;
            if (lOnPic > lOnPicMax) lOnPic = lOnPicMax;
            PointF lLineBeginPoint = new PointF(haBaseX, endLineY + 30F);
            PointF lLineEndPoint = new PointF(lOnPic, endLineY + 30F);
            e.Graphics.DrawLine(pen, lLineBeginPoint, lLineEndPoint);
            // draw left arrow
            e.Graphics.DrawLine(pen, new PointF(haBaseX, endLineY + 30F), new PointF(haBaseX + 5F, endLineY + 30F - 5F));
            e.Graphics.DrawLine(pen, new PointF(haBaseX, endLineY + 30F), new PointF(haBaseX + 5F, endLineY + 30F + 5F));
            // draw right arrow
            e.Graphics.DrawLine(pen, new PointF(lOnPic, endLineY + 30F), new PointF(lOnPic - 5F, endLineY + 30F - 5F));
            e.Graphics.DrawLine(pen, new PointF(lOnPic, endLineY + 30F), new PointF(lOnPic - 5F, endLineY + 30F + 5F));

            //draw text L
            string lText = "  L";
            using (Font font1 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point))
            {
                RectangleF rectF1 = new RectangleF(haBaseX + (lOnPic- haBaseX)/2 - 30/2, endLineY + 40F, 30, 20);
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                e.Graphics.DrawString(lText, font1, Brushes.Black, rectF1);
            }

            // ========================================================================================================
            // draw line delta h
            float deltaHOnPic = endLineY - deltaHOnPicMin * 2 - deltaHValue / hRotation;
            if (deltaHOnPic < (endLineY - deltaHOnPicMax)) deltaHOnPic = endLineY - deltaHOnPicMax;

            PointF deltaHTopPoint = new PointF(lOnPic, deltaHOnPic);
            PointF detaHBotPoint = new PointF(lOnPic, endLineY);
            e.Graphics.DrawLine(pen, deltaHTopPoint, detaHBotPoint);
            // draw top arrow
            e.Graphics.DrawLine(pen, new PointF(lOnPic, deltaHOnPic), new PointF(lOnPic - 5F, deltaHOnPic + 5F));
            e.Graphics.DrawLine(pen, new PointF(lOnPic, deltaHOnPic), new PointF(lOnPic + 5F, deltaHOnPic + 5F));
            // draw bot arrow
            e.Graphics.DrawLine(pen, new PointF(lOnPic, endLineY), new PointF(lOnPic + 5F, endLineY - 5F));
            e.Graphics.DrawLine(pen, new PointF(lOnPic, endLineY), new PointF(lOnPic - 5F, endLineY - 5F));
            //draw text delta h
            string deltaHText = "Δh";
            using (Font font1 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point))
            {
                float haTextY = haBaseY + haOnPicMin + haValue / hRotation / 2;
                RectangleF rectF1 = new RectangleF(lOnPic + 10F, deltaHOnPic - 20F, 30, 20);
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                e.Graphics.DrawString(deltaHText, font1, Brushes.Black, rectF1);
            }

            // draw dash line ha
            e.Graphics.DrawLine(dashPen, detaHBotPoint, new PointF(lOnPic, endLineY + 50));

            // ========================================================================================================
            // draw curve
            pen = new Pen(Color.Black, 3);

            // Create points that define curve.
            PointF curvePoint1 = new PointF(haBaseX - 75F, haBaseY + haOnPic + 50F);
            PointF curvePoint2 = new PointF(haBaseX + 20F, haBaseY + haOnPic - 15F);
            PointF curvePoint3 = new PointF(lOnPic - 150F, deltaHOnPic + 20F);
            PointF curvePoint4 = new PointF(lOnPic, deltaHOnPic - 5F);
            PointF curvePoint5 = new PointF(lOnPic + 100F, endLineY - 5F);
            PointF curvePoint6 = new PointF(lOnPic + 140F, endLineY - 20F);
            PointF[] curvePoints = { curvePoint1, curvePoint2, curvePoint3, curvePoint4, curvePoint5, curvePoint6 };
            e.Graphics.DrawCurve(pen, curvePoints);


            // ========================================================================================================
            // draw end line
            pen = new Pen(Color.White, 2);
            PointF endLineBeginPoint = new PointF(50.0F, endLineY);
            PointF endLineEndPoint = new PointF(750.0F, endLineY);
            e.Graphics.DrawLine(pen, endLineBeginPoint, endLineEndPoint);
        }
    }
}
