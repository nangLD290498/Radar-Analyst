using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RadarAnalyst.UIComponent.ComponentI;
using RadarAnalyst.UIComponent.Element;


namespace RadarAnalyst.UIComponent
{
    public partial class DCDDTabPage : TabPageCI
    {
        float result1 = 0F;
        float result2 = 0F;
        private const int lambdaValue = 2;
        private const float P_18M = 2.0F;
        private const float R36D6M_1_1 = 0.1F;
        private const float VRS_2DM = 0.2F;
        private float modOn = P_18M;

        private ButtonCtm btn_P_18M;
        private ButtonCtm btn_36D6M_1_1;
        private ButtonCtm btn_VRS_2DM;

        private LabelCtm label_dph_title;
        private NumericUpDown nud_dph;
        private LabelCtm label_dph_unit;

        private LabelCtm label_dmax_title;
        private NumericUpDown nud_dmax;
        private LabelCtm label_dmax_unit;

        private LabelCtm label_hmt_title;
        private NumericUpDown nud_hmt;
        private LabelCtm label_hmt_unit;

        private LabelCtm label_hpx_title;
        private NumericUpDown nud_hpx;
        private LabelCtm label_hpx_unit;

        private LabelCtm label_hbd_title;
        private NumericUpDown nud_hbd;
        private LabelCtm label_hbd_unit;

        private LabelCtm label_first_result_title;
        private LabelCtm label_first_result_value;
        private LabelCtm label_first_result_unit;

        private LabelCtm label_second_result_title;
        private LabelCtm label_second_result_value;
        private LabelCtm label_second_result_unit;

        int pictureBoxHeight = 500;
        int pictureBoxWidth = 850;

        private const float nud_dph_default_value = 150.0F;
        private const float nud_dmax_default_value = 300.0F;
        private const float nud_hmt_default_value = 4000.0F;
        private const float nud_hpx_default_value = 80.0F;
        private const float nud_hbd_default_value = 350.0F;
        private float hRotation = 1.5F;

        private Color groupBoxColor = System.Drawing.ColorTranslator.FromHtml("#19182a");
        private Color lineBlueColor = System.Drawing.ColorTranslator.FromHtml("#e35736");

        Bitmap radarImgBitmap = global::RadarAnalyst.Properties.Resources.P18M;
        private LabelCtm label_error;

        public DCDDTabPage(String tabCode, String text) : base(tabCode, text)
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
            this.btn_36D6M_1_1 = new ButtonCtm("ĐÀI RA ĐA \n 36D6M-1-1");
            this.Controls.Add(this.btn_VRS_2DM);
            this.Controls.Add(this.btn_36D6M_1_1);
            this.Controls.Add(this.btn_P_18M);

            // btn_P_18M
            this.btn_P_18M.is_active = true;
            this.btn_P_18M.setBackColor(true);
            this.btn_P_18M.Location = new System.Drawing.Point(47, 200);
            this.btn_P_18M.Name = "btn_P_18M";
            this.btn_P_18M.Size = new System.Drawing.Size(135, 70);
            this.btn_P_18M.Click += new System.EventHandler(this.btn_P_18M_Click);

            // btn_36D6M_1_1
            this.btn_36D6M_1_1.Location = new System.Drawing.Point(47, 280);
            this.btn_36D6M_1_1.Name = "btn_36D6M_1_1";
            this.btn_36D6M_1_1.Size = new System.Drawing.Size(135, 70);
            this.btn_36D6M_1_1.Click += new System.EventHandler(this.btn_36D6M_1_1_Click);

            // btn_VRS_2DM
            this.btn_VRS_2DM.Location = new System.Drawing.Point(47, 360);
            this.btn_VRS_2DM.Name = "btn_VRS_2DM";
            this.btn_VRS_2DM.Size = new System.Drawing.Size(135, 70);
            this.btn_VRS_2DM.Click += new System.EventHandler(this.btn_VRS_2DM_Click);
        }


        private void initInputTable()
        {
            this.label_dph_title = new LabelCtm();
            this.label_dph_unit = new LabelCtm();
            this.label_dmax_title = new LabelCtm();
            this.label_dmax_unit = new LabelCtm();
            this.label_hmt_title = new LabelCtm();
            this.label_hmt_unit = new LabelCtm();
            this.label_hpx_title = new LabelCtm();
            this.label_hpx_unit = new LabelCtm();
            this.label_hbd_title = new LabelCtm();
            this.label_hbd_unit = new LabelCtm();
            this.nud_dph = new System.Windows.Forms.NumericUpDown();
            this.nud_dmax = new System.Windows.Forms.NumericUpDown();
            this.nud_hmt = new System.Windows.Forms.NumericUpDown();
            this.nud_hpx = new System.Windows.Forms.NumericUpDown();
            this.nud_hbd = new System.Windows.Forms.NumericUpDown();

            ((System.ComponentModel.ISupportInitialize)(this.nud_dph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_hmt)).BeginInit();

            // 
            // gb_inputTable
            // 
            this.gb_inputTable.Controls.Add(this.label_dph_title);
            this.gb_inputTable.Controls.Add(this.label_dph_unit);
            this.gb_inputTable.Controls.Add(this.label_dmax_title);
            this.gb_inputTable.Controls.Add(this.label_dmax_unit);
            this.gb_inputTable.Controls.Add(this.label_hmt_title);
            this.gb_inputTable.Controls.Add(this.label_hmt_unit);
            this.gb_inputTable.Controls.Add(this.nud_dph);
            this.gb_inputTable.Controls.Add(this.nud_dmax);
            this.gb_inputTable.Controls.Add(this.nud_hmt);
            this.gb_inputTable.Controls.Add(this.label_hpx_title);
            this.gb_inputTable.Controls.Add(this.label_hpx_unit);
            this.gb_inputTable.Controls.Add(this.label_hbd_title);
            this.gb_inputTable.Controls.Add(this.label_hbd_unit);
            this.gb_inputTable.Controls.Add(this.nud_hpx);
            this.gb_inputTable.Controls.Add(this.nud_hbd);

            // ================================================================
            // label_dph_title
            this.label_dph_title.AutoSize = true;
            this.label_dph_title.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_dph_title.Location = new System.Drawing.Point(21, 40);
            this.label_dph_title.Name = "label_dph_title";
            this.label_dph_title.Size = new System.Drawing.Size(58, 20);
            this.label_dph_title.TabIndex = 13;
            this.label_dph_title.Text = "Dph";
            // nud_dph
            this.nud_dph.Location = new System.Drawing.Point(87, 40);
            this.nud_dph.Name = "nud_dph";
            this.nud_dph.Size = new System.Drawing.Size(107, 23);
            this.nud_dph.TabIndex = 6;
            this.nud_dph.Maximum = 9999999999;
            this.nud_dph.Minimum = 0;
            this.nud_dph.DecimalPlaces = 1;
            this.nud_dph.Increment = 0.1m;
            this.nud_dph.Value = new decimal(nud_dph_default_value);
            // label_dph_unit
            this.label_dph_unit.AutoSize = true;
            this.label_dph_unit.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_dph_unit.Location = new System.Drawing.Point(207, 40);
            this.label_dph_unit.Name = "label_dph_unit";
            this.label_dph_unit.Size = new System.Drawing.Size(29, 20);
            this.label_dph_unit.TabIndex = 7;
            this.label_dph_unit.Text = "km";

            // ================================================================
            // label_dmax_title
            this.label_dmax_title.AutoSize = true;
            this.label_dmax_title.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_dmax_title.Location = new System.Drawing.Point(21, 80);
            this.label_dmax_title.Name = "label_dmax_title";
            this.label_dmax_title.Size = new System.Drawing.Size(58, 20);
            this.label_dmax_title.TabIndex = 13;
            this.label_dmax_title.Text = "Dmax";
            // nud_dmax
            this.nud_dmax.Location = new System.Drawing.Point(87, 80);
            this.nud_dmax.Name = "nud_dmax";
            this.nud_dmax.Size = new System.Drawing.Size(107, 23);
            this.nud_dmax.TabIndex = 5;
            this.nud_dmax.Maximum = 9999999999;
            this.nud_dmax.Minimum = 0;
            this.nud_dmax.DecimalPlaces = 1;
            this.nud_dmax.Increment = 0.1m;
            this.nud_dmax.Value = new decimal(nud_dmax_default_value);
            // label_dmax_unit
            this.label_dmax_unit.AutoSize = true;
            this.label_dmax_unit.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_dmax_unit.Location = new System.Drawing.Point(207, 80);
            this.label_dmax_unit.Name = "label_dmax_unit";
            this.label_dmax_unit.Size = new System.Drawing.Size(29, 20);
            this.label_dmax_unit.TabIndex = 7;
            this.label_dmax_unit.Text = "km";

            // ================================================================
            // label_hmt_title
            this.label_hmt_title.AutoSize = true;
            this.label_hmt_title.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_hmt_title.Location = new System.Drawing.Point(21, 120);
            this.label_hmt_title.Name = "label_hmt_title";
            this.label_hmt_title.Size = new System.Drawing.Size(58, 20);
            this.label_hmt_title.TabIndex = 13;
            this.label_hmt_title.Text = "Hmt";
            // nud_hmt
            this.nud_hmt.Location = new System.Drawing.Point(87, 120);
            this.nud_hmt.Name = "nud_hmt";
            this.nud_hmt.Size = new System.Drawing.Size(107, 23);
            this.nud_hmt.TabIndex = 4;
            this.nud_hmt.Maximum = 9999999999;
            this.nud_hmt.Minimum = 0;
            this.nud_hmt.DecimalPlaces = 1;
            this.nud_hmt.Increment = 0.1m;
            this.nud_hmt.Value = new decimal(nud_hmt_default_value);
            // label_hmt_unit
            this.label_hmt_unit.AutoSize = true;
            this.label_hmt_unit.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_hmt_unit.Location = new System.Drawing.Point(207, 120);
            this.label_hmt_unit.Name = "label_hmt_unit";
            this.label_hmt_unit.Size = new System.Drawing.Size(29, 20);
            this.label_hmt_unit.TabIndex = 7;
            this.label_hmt_unit.Text = "m";
            // ================================================================
            // label_hpx_title
            this.label_hpx_title.AutoSize = true;
            this.label_hpx_title.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_hpx_title.Location = new System.Drawing.Point(21, 160);
            this.label_hpx_title.Name = "label_hpx_title";
            this.label_hpx_title.Size = new System.Drawing.Size(58, 20);
            this.label_hpx_title.TabIndex = 13;
            this.label_hpx_title.Text = "Hpx";
            // nud_hpx
            this.nud_hpx.Location = new System.Drawing.Point(87, 160);
            this.nud_hpx.Name = "nud_hpx";
            this.nud_hpx.Size = new System.Drawing.Size(107, 23);
            this.nud_hpx.TabIndex = 6;
            this.nud_hpx.Maximum = 9999999999;
            this.nud_hpx.Minimum = 0;
            this.nud_hpx.DecimalPlaces = 1;
            this.nud_hpx.Increment = 0.1m;
            this.nud_hpx.Value = new decimal(nud_hpx_default_value);
            // label_hpx_unit
            this.label_hpx_unit.AutoSize = true;
            this.label_hpx_unit.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_hpx_unit.Location = new System.Drawing.Point(207, 160);
            this.label_hpx_unit.Name = "label_hpx_unit";
            this.label_hpx_unit.Size = new System.Drawing.Size(29, 20);
            this.label_hpx_unit.TabIndex = 7;
            this.label_hpx_unit.Text = "m";

            // ================================================================
            // label_hbd_title
            this.label_hbd_title.AutoSize = true;
            this.label_hbd_title.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_hbd_title.Location = new System.Drawing.Point(21, 200);
            this.label_hbd_title.Name = "label_hbd_title";
            this.label_hbd_title.Size = new System.Drawing.Size(58, 20);
            this.label_hbd_title.TabIndex = 13;
            this.label_hbd_title.Text = "Hđđ";
            // nud_hbd
            this.nud_hbd.Location = new System.Drawing.Point(87, 200);
            this.nud_hbd.Name = "nud_hbd";
            this.nud_hbd.Size = new System.Drawing.Size(107, 23);
            this.nud_hbd.TabIndex = 5;
            this.nud_hbd.Maximum = 9999999999;
            this.nud_hbd.Minimum = 0;
            this.nud_hbd.DecimalPlaces = 1;
            this.nud_hbd.Increment = 0.1m;
            this.nud_hbd.Value = new decimal(nud_hbd_default_value);
            // label_hbd_unit
            this.label_hbd_unit.AutoSize = true;
            this.label_hbd_unit.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_hbd_unit.Location = new System.Drawing.Point(207, 200);
            this.label_hbd_unit.Name = "label_hbd_unit";
            this.label_hbd_unit.Size = new System.Drawing.Size(29, 20);
            this.label_hbd_unit.TabIndex = 7;
            this.label_hbd_unit.Text = "m";

            ((System.ComponentModel.ISupportInitialize)(this.nud_dph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_hmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_hpx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_hbd)).EndInit();
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
            this.label_first_result_title.Text = "Độ cao ăng ten tổng hợp Ha ";
            // label_first_result_value
            this.label_first_result_value.AutoSize = true;
            this.label_first_result_value.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_first_result_value.ForeColor = System.Drawing.Color.Red;
            this.label_first_result_value.Location = new System.Drawing.Point(290, 50);
            this.label_first_result_value.Name = "label_first_result_value";
            this.label_first_result_value.Size = new System.Drawing.Size(30, 31);
            this.label_first_result_value.TabIndex = 1;
            this.label_first_result_value.Text = "000000";
            // label17
            this.label_first_result_unit.AutoSize = true;
            this.label_first_result_unit.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_first_result_unit.Location = new System.Drawing.Point(390, 50);
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
            this.label_second_result_title.Text = "Độ cao ăng ten phải lắp ha  ";
            // label_second_result_value
            this.label_second_result_value.AutoSize = true;
            this.label_second_result_value.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_second_result_value.ForeColor = System.Drawing.Color.Red;
            this.label_second_result_value.Location = new System.Drawing.Point(290, 90);
            this.label_second_result_value.Name = "label_second_result_value";
            this.label_second_result_value.Size = new System.Drawing.Size(66, 31);
            this.label_second_result_value.TabIndex = 4;
            this.label_second_result_value.Text = "000000";
            // label17
            this.label_second_result_unit.AutoSize = true;
            this.label_second_result_unit.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_second_result_unit.Location = new System.Drawing.Point(390, 90);
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
            btn_36D6M_1_1.setBackColor(false);
            radarImgBitmap = global::RadarAnalyst.Properties.Resources.P18M;
        }

        private void btn_36D6M_1_1_Click(object sender, EventArgs e)
        {
            this.modOn = R36D6M_1_1;
            //clearPictureBox(btn_36D6M_1_1);
            btn_VRS_2DM.setBackColor(false);
            btn_P_18M.setBackColor(false);
            btn_36D6M_1_1.setBackColor(true);
            radarImgBitmap = global::RadarAnalyst.Properties.Resources._36D6;
        }

        private void btn_VRS_2DM_Click(object sender, EventArgs e)
        {
            this.modOn = VRS_2DM;
            //clearPictureBox(btn_VRS_2DM);
            btn_VRS_2DM.setBackColor(true);
            btn_P_18M.setBackColor(false);
            btn_36D6M_1_1.setBackColor(false);
            radarImgBitmap = global::RadarAnalyst.Properties.Resources.VRS_2DM;
        }

        public override void btn_ok_click(object sender, EventArgs e)
        {
            float dphValue = (float)Convert.ToDouble(nud_dph.Value) * 1000;
            float dmaxValue = (float)Convert.ToDouble(nud_dmax.Value) * 1000;
            float hmtValue = (float)Convert.ToDouble(nud_hmt.Value);
            float hpxValue = (float)Convert.ToDouble(nud_hpx.Value);
            float hbdValue = (float)Convert.ToDouble(nud_hbd.Value);
            float deltaHValue = dphValue * dphValue / (2 * 1.33F * 6370);

            result1 = dphValue * modOn * (float)Math.Asin(dphValue / dmaxValue) / (360 * (hmtValue - deltaHValue));
            result2 = result1 + hpxValue - hbdValue;

            // set result value 1
            label_first_result_value.Text = Math.Round(result1, 2) == 0 ? "0" : Math.Round(result1, 2).ToString();
            if (Math.Round(result1, 2) > 0)
                label_first_result_value.ForeColor = System.Drawing.Color.Green;
            else
                label_first_result_value.ForeColor = System.Drawing.Color.Red;
            // set result value 2
            label_second_result_value.Text = Math.Round(result2, 2) == 0 ? "0" : Math.Round(result2, 2).ToString();
            if (Math.Round(result2, 2) > 0)
                label_second_result_value.ForeColor = System.Drawing.Color.Green;
            else
                label_second_result_value.ForeColor = System.Drawing.Color.Red;
            //=======================================================================================
            this.pictureBox1.Controls.Clear();
            this.gb_picture.Controls.Remove(this.pictureBox1);
            bool isValid = true;
            //if (result1 <= 0 || result2 <= 0 || result1 < result2) isValid = false;
            if (!isValid)
            {
                showError();
                this.gb_picture.Controls.Add(this.label_error);
                return;
            }
            // ======================================================================================
            // Dock the PictureBox to the form and set its background to white.
            this.pictureBox1.Location = new Point(0, 0);
            this.pictureBox1.Size = new System.Drawing.Size(pictureBoxWidth, pictureBoxHeight);

            this.pictureBox1.BackColor = groupBoxColor;
            // Connect the Paint event of the PictureBox to the event handler method.
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.drawGraph);
            // Add the PictureBox control to the Form.
            this.gb_picture.Controls.Add(this.pictureBox1);

        }

        private void clearPictureBox(ButtonCtm clickedButton)
        {
            if (clickedButton.is_active == false)
                this.gb_picture.Controls.Remove(this.pictureBox1);
        }


        private void drawGraph(object sender, PaintEventArgs e)
        {
            //hpx
            float hpxValue = (float)Convert.ToDouble(nud_hpx.Value) * 0.5F;
            float hpxOnPicMin = 15F;
            float hpxOnPicMax = 50F;
            float hpxOnPic = (hpxValue > hpxOnPicMax) ? hpxOnPicMax : (hpxValue < hpxOnPicMin) ? hpxOnPicMin : hpxValue;
            //hdd
            float hddValue = (float)Convert.ToDouble(nud_hbd.Value) * 0.5F;
            float hddOnPicMin = 150F;
            float hddOnPicMax = 200F;
            float hddOnPic = (hddValue > hddOnPicMax) ? hddOnPicMax : (hddValue < hddOnPicMin) ? hddOnPicMin : hddValue;
            //ha
            float haValue = result2;
            float haOnPicMin = 70F;
            float haOnPicMax = 120F;
            float haOnPic = (haValue > haOnPicMax) ? haOnPicMax : (haValue < haOnPicMin) ? haOnPicMin : haValue;

            float haBaseX = 200.0F;
            float haBaseY = 50.0F;
            float endLineY = 350F;

            // ========================================================================================================
            // draw begin line
            Pen pen = new Pen(lineBlueColor, 2);
            PointF point1 = new PointF(haBaseX - 50F, endLineY - haOnPic - hddOnPic);
            PointF point2 = new PointF(haBaseX + 50F, endLineY - haOnPic - hddOnPic);
            e.Graphics.DrawLine(pen, point1, point2);

            // ========================================================================================================
            // draw end line
            pen = new Pen(lineBlueColor, 2);
            PointF endLineBeginPoint = new PointF(50.0F, endLineY);
            PointF endLineEndPoint = new PointF(750.0F, endLineY);
            e.Graphics.DrawLine(pen, endLineBeginPoint, endLineEndPoint);

            if (haOnPic > haOnPicMax) haOnPic = haOnPicMax;

            // ========================================================================================================
            // draw triangle
            PictureBox radar = new PictureBox();
            radar.Location = new Point((int)haBaseX - 21, (int)(endLineY - hddOnPic - 52F));
            radar.Size = new System.Drawing.Size(40, 50);
            radar.SizeMode = PictureBoxSizeMode.StretchImage;
            radar.Image = radarImgBitmap;
            pictureBox1.Controls.Add(radar);

            // ========================================================================================================
            // draw ha line black
            pen = new Pen(lineBlueColor, 2);
            PointF haTopPoint = new PointF(haBaseX, endLineY - haOnPic - hddOnPic);
            PointF haBotPoint = new PointF(haBaseX, endLineY - hddOnPic - 28F);
            e.Graphics.DrawLine(pen, haTopPoint, haBotPoint);
            // draw ha line white
            pen = new Pen(Color.White, 2);
            haTopPoint = new PointF(haBaseX - 25F, endLineY - haOnPic - hddOnPic);
            haBotPoint = new PointF(haBaseX - 25F, endLineY - hddOnPic - 3);
            e.Graphics.DrawLine(pen, haTopPoint, haBotPoint);
            // draw top arrow
            e.Graphics.DrawLine(pen, new PointF(haBaseX - 25F, endLineY - haOnPic - hddOnPic), new PointF(haBaseX - 30F, endLineY - haOnPic - hddOnPic + 5F));
            e.Graphics.DrawLine(pen, new PointF(haBaseX - 25F, endLineY - haOnPic - hddOnPic), new PointF(haBaseX - 20F, endLineY - haOnPic - hddOnPic + 5F));
            // draw bot arrow
            e.Graphics.DrawLine(pen, new PointF(haBaseX - 25F, endLineY - hddOnPic - 3), new PointF(haBaseX - 30F, endLineY - hddOnPic - 3 - 5F));
            e.Graphics.DrawLine(pen, new PointF(haBaseX - 25F, endLineY - hddOnPic - 3), new PointF(haBaseX - 20F, endLineY - hddOnPic - 3 - 5F));
            // draw text ha
            string text1 = "ha";
            using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
            {
                float haTextY = haBaseY + haOnPicMin + haValue / hRotation / 2;
                RectangleF rectF1 = new RectangleF(haBaseX - 70F, (endLineY - haOnPic - hddOnPic + endLineY - hddOnPic) / 2, 40, 20);
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                e.Graphics.DrawString(text1, font1, Brushes.Black, rectF1);
            }
            // ========================================================================================================
            // draw Hpx line white
            pen = new Pen(Color.White, 2);
            PointF hpxTopPoint = new PointF(haBaseX - 75F, endLineY - hpxOnPic); // nang
            PointF hpxBotPoint = new PointF(haBaseX - 75F, endLineY);
            e.Graphics.DrawLine(pen, hpxTopPoint, hpxBotPoint);
            // draw top arrow
            e.Graphics.DrawLine(pen, new PointF(haBaseX - 75F, endLineY - hpxOnPic), new PointF(haBaseX - 75F + 5F, endLineY - hpxOnPic + 5F)); // nang
            e.Graphics.DrawLine(pen, new PointF(haBaseX - 75F, endLineY - hpxOnPic), new PointF(haBaseX - 75F - 5F, endLineY - hpxOnPic + 5F)); //nang
            // draw bot arrow
            e.Graphics.DrawLine(pen, new PointF(haBaseX - 75F, endLineY), new PointF(haBaseX - 75F + 5F, endLineY - 5F));
            e.Graphics.DrawLine(pen, new PointF(haBaseX - 75F, endLineY), new PointF(haBaseX - 75F - 5F, endLineY - 5F));
            // draw text hpx
            string textHpx = "Hpx";
            using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
            {
                RectangleF rectF1 = new RectangleF(haBaseX - 75F - 55F, (endLineY - hpxOnPic + endLineY) / 2 - 10F, 50, 20); //note
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                e.Graphics.DrawString(textHpx, font1, Brushes.Black, rectF1);
            }
            // ========================================================================================================
            // draw Hbd line white
            pen = new Pen(Color.White, 2);
            PointF hbdTopPoint = new PointF(haBaseX, endLineY - hddOnPic); // nang
            PointF hbdBotPoint = new PointF(haBaseX, endLineY - hpxOnPic); // nang
            e.Graphics.DrawLine(pen, hbdTopPoint, hbdBotPoint);
            // draw top arrow
            e.Graphics.DrawLine(pen, new PointF(haBaseX, endLineY - hddOnPic), new PointF(haBaseX + 5F, endLineY - hddOnPic + 5F)); // note
            e.Graphics.DrawLine(pen, new PointF(haBaseX, endLineY - hddOnPic), new PointF(haBaseX - 5F, endLineY - hddOnPic + 5F)); //note
            // draw bot arrow
            e.Graphics.DrawLine(pen, new PointF(haBaseX, endLineY - hpxOnPic), new PointF(haBaseX + 5F, endLineY - hpxOnPic - 5F)); //note
            e.Graphics.DrawLine(pen, new PointF(haBaseX, endLineY - hpxOnPic), new PointF(haBaseX - 5F, endLineY - hpxOnPic - 5F)); //note
            // draw text hbd
            string textHbd = "Hbd";
            using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
            {
                RectangleF rectF1 = new RectangleF(haBaseX - 55F, (endLineY - hddOnPic + endLineY - hpxOnPic) / 2, 50, 20); //note
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                e.Graphics.DrawString(textHbd, font1, Brushes.Black, rectF1);
            }
            // ========================================================================================================
            // draw horizontal line 
            PointF beginPoint = new PointF(50F, endLineY - hpxOnPic); // nang
            PointF endPoint = new PointF(750F, endLineY - hpxOnPic); // nang
            e.Graphics.DrawLine(pen, beginPoint, endPoint);

            // ========================================================================================================
            // draw curve
            pen = new Pen(lineBlueColor, 1);
            // Create points that define curve.
            PointF curvePoint1 = new PointF(haBaseX - 150F, endLineY - hddOnPic + 20F);
            PointF curvePoint2 = new PointF(haBaseX + 40F, endLineY - hddOnPic + 5F);
            PointF curvePoint3 = new PointF(700F - 200F, endLineY - hpxOnPic - 15F);
            PointF curvePoint5 = new PointF(750F, endLineY - hpxOnPic - 25F);
            PointF[] curvePoints = { curvePoint1, curvePoint2, curvePoint3, curvePoint5 };
            e.Graphics.DrawCurve(pen, curvePoints);

            // ========================================================================================================
            // draw line delta Ha
            pen = new Pen(Color.White, 2);
            PointF HaTopPoint = new PointF(haBaseX + 150F, endLineY - haOnPic - hddOnPic);
            PointF HaBotPoint = new PointF(haBaseX + 150F, endLineY - hpxOnPic); // note
            e.Graphics.DrawLine(pen, HaTopPoint, HaBotPoint);
            // draw top arrow
            e.Graphics.DrawLine(pen, new PointF(haBaseX + 150F, endLineY - haOnPic - hddOnPic), new PointF(haBaseX + 150F - 5F, endLineY - haOnPic - hddOnPic + 5F));
            e.Graphics.DrawLine(pen, new PointF(haBaseX + 150F, endLineY - haOnPic - hddOnPic), new PointF(haBaseX + 150F + 5F, endLineY - haOnPic - hddOnPic + 5F));
            // draw bot arrow
            e.Graphics.DrawLine(pen, new PointF(haBaseX + 150F, endLineY - hpxOnPic - 2F), new PointF(haBaseX + 150F + 5F, endLineY - hpxOnPic - 7F)); //note
            e.Graphics.DrawLine(pen, new PointF(haBaseX + 150F, endLineY - hpxOnPic - 2F), new PointF(haBaseX + 150F - 5F, endLineY - hpxOnPic - 7F)); // note
            //draw text delta Ha
            string deltaHText = "Ha";
            using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
            {
                float haTextY = haBaseY + haOnPicMin + haValue / hRotation / 2;
                RectangleF rectF1 = new RectangleF(haBaseX + 160F, (endLineY - haOnPic - hddOnPic + endLineY - hpxOnPic - 2F) / 2, 40, 20);
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(whiteBrush, Rectangle.Round(rectF1));
                e.Graphics.DrawString(deltaHText, font1, Brushes.Black, rectF1);
            }

        }

        private void showError()
        {
            this.label_error = new LabelCtm();
            this.label_error.AutoSize = true;
            this.label_error.Font = new System.Drawing.Font("MonoLisa", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_error.Location = new System.Drawing.Point(340, 150);
            this.label_error.Name = "label_dph_title";
            this.label_error.Size = new System.Drawing.Size(58, 20);
            this.label_error.TabIndex = 13;
            this.label_error.Text = "Không thể hiển thị !";
        }
    }
}