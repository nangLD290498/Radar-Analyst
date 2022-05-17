using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using RadarAnalyst.UIComponent.ComponentI;
using RadarAnalyst.UIComponent.Element;
using System.Windows.Forms.DataVisualization.Charting;

namespace RadarAnalyst.UIComponent
{
    public partial class GCKTabPage : TabPageCII
    {
        int pictureBoxHeight = 500;
        int pictureBoxWidth = 850;
        private Color groupBoxColor = System.Drawing.ColorTranslator.FromHtml("#19182a");

        private ButtonCtm btn_P_18M;
        private ButtonCtm btn_VRS_2DM;

        protected ButtonCtm lbl_beta;
        protected ButtonCtm lbl_anpha;
        protected ButtonCtm lbl_note;

        private NumericUpDown nud_beta_1;
        private NumericUpDown nud_beta_2;
        private NumericUpDown nud_beta_3;

        private NumericUpDown nud_anpha_1;
        private NumericUpDown nud_anpha_2;
        private NumericUpDown nud_anpha_3;

        private TextBox tb_note_1;
        private TextBox tb_note_2;
        private TextBox tb_note_3;

        private Chart c_polar;

        public GCKTabPage(String tabCode, String text) : base(tabCode, text)
        {
            // create layout
            initRadarButton();

            initInputTable();

            initUI();
        }

        private void initUI() {
            this.gb_inputTable.Text = "BẢNG SỐ LIỆU TRẬN ĐỊA KIM SƠN";
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
            // lable beta
            this.lbl_beta = new ButtonCtm("OK");
            this.gb_inputTable.Controls.Add(this.lbl_beta);
            this.lbl_beta.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_beta.Location = new System.Drawing.Point(30, 50);
            this.lbl_beta.Name = "lbl_beta";
            this.lbl_beta.TabIndex = 0;
            this.lbl_beta.Text = "β";
            this.lbl_beta.Enabled = false;
            this.lbl_beta.UseVisualStyleBackColor = false;
            //lable anpha
            this.lbl_anpha = new ButtonCtm("OK");
            this.gb_inputTable.Controls.Add(this.lbl_anpha);
            this.lbl_anpha.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_anpha.Location = new System.Drawing.Point(140, 50);
            this.lbl_anpha.Name = "lbl_anpha";
            this.lbl_anpha.TabIndex = 0;
            this.lbl_anpha.Text = "α";
            this.lbl_anpha.Enabled = false;
            this.lbl_anpha.UseVisualStyleBackColor = true;
            //lable note
            this.lbl_note = new ButtonCtm("OK");
            this.gb_inputTable.Controls.Add(this.lbl_note);
            this.lbl_note.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_note.Location = new System.Drawing.Point(250, 50);
            this.lbl_note.Name = "lbl_note";
            this.lbl_note.TabIndex = 0;
            this.lbl_note.Text = "Ghi chú";
            this.lbl_note.Enabled = false;
            this.lbl_note.UseVisualStyleBackColor = true;
            // beta input 1 
            this.gb_inputTable.Controls.Add(this.nud_beta_1);
            this.nud_beta_1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud_beta_1)).BeginInit();
            this.gb_inputTable.Controls.Add(this.nud_beta_1);
            this.nud_beta_1.Location = new System.Drawing.Point(30, 100);
            this.nud_beta_1.Name = "nud_beta_1";
            this.nud_beta_1.Size = new System.Drawing.Size(100, 23);
            this.nud_beta_1.TabIndex = 5;
            this.nud_beta_1.Maximum = 9999999999;
            this.nud_beta_1.Minimum = 0;
            this.nud_beta_1.DecimalPlaces = 1;
            this.nud_beta_1.Increment = 0.1m;
            // beta input 2 
            this.gb_inputTable.Controls.Add(this.nud_beta_2);
            this.nud_beta_2 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud_beta_2)).BeginInit();
            this.gb_inputTable.Controls.Add(this.nud_beta_2);
            this.nud_beta_2.Location = new System.Drawing.Point(30, 130);
            this.nud_beta_2.Name = "nud_beta_2";
            this.nud_beta_2.Size = new System.Drawing.Size(100, 23);
            this.nud_beta_2.TabIndex = 5;
            this.nud_beta_2.Maximum = 9999999999;
            this.nud_beta_2.Minimum = 0;
            this.nud_beta_2.DecimalPlaces = 1;
            this.nud_beta_2.Increment = 0.1m;
            // beta input 3 
            this.gb_inputTable.Controls.Add(this.nud_beta_3);
            this.nud_beta_3 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud_beta_3)).BeginInit();
            this.gb_inputTable.Controls.Add(this.nud_beta_3);
            this.nud_beta_3.Location = new System.Drawing.Point(30, 160);
            this.nud_beta_3.Name = "nud_beta_3";
            this.nud_beta_3.Size = new System.Drawing.Size(100, 23);
            this.nud_beta_3.TabIndex = 5;
            this.nud_beta_3.Maximum = 9999999999;
            this.nud_beta_3.Minimum = 0;
            this.nud_beta_3.DecimalPlaces = 1;
            this.nud_beta_3.Increment = 0.1m;
            // anpha input 1 
            this.gb_inputTable.Controls.Add(this.nud_anpha_1);
            this.nud_anpha_1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud_anpha_1)).BeginInit();
            this.gb_inputTable.Controls.Add(this.nud_anpha_1);
            this.nud_anpha_1.Location = new System.Drawing.Point(140, 100);
            this.nud_anpha_1.Name = "nud_anpha_1";
            this.nud_anpha_1.Size = new System.Drawing.Size(100, 23);
            this.nud_anpha_1.TabIndex = 5;
            this.nud_anpha_1.Maximum = 9999999999;
            this.nud_anpha_1.Minimum = 0;
            this.nud_anpha_1.DecimalPlaces = 1;
            this.nud_anpha_1.Increment = 0.1m;
            //  anpha input 2 
            this.gb_inputTable.Controls.Add(this.nud_anpha_2);
            this.nud_anpha_2 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud_anpha_2)).BeginInit();
            this.gb_inputTable.Controls.Add(this.nud_anpha_2);
            this.nud_anpha_2.Location = new System.Drawing.Point(140, 130);
            this.nud_anpha_2.Name = "nud_anpha_2";
            this.nud_anpha_2.Size = new System.Drawing.Size(100, 23);
            this.nud_anpha_2.TabIndex = 5;
            this.nud_anpha_2.Maximum = 9999999999;
            this.nud_anpha_2.Minimum = 0;
            this.nud_anpha_2.DecimalPlaces = 1;
            this.nud_anpha_2.Increment = 0.1m;
            // anpha input 3
            this.gb_inputTable.Controls.Add(this.nud_anpha_3);
            this.nud_anpha_3 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud_anpha_3)).BeginInit();
            this.gb_inputTable.Controls.Add(this.nud_anpha_3);
            this.nud_anpha_3.Location = new System.Drawing.Point(140, 160);
            this.nud_anpha_3.Name = "nud_anpha_3";
            this.nud_anpha_3.Size = new System.Drawing.Size(100, 23);
            this.nud_anpha_3.TabIndex = 5;
            this.nud_anpha_3.Maximum = 9999999999;
            this.nud_anpha_3.Minimum = 0;
            this.nud_anpha_3.DecimalPlaces = 1;
            this.nud_anpha_3.Increment = 0.1m;

            // note 1
            this.gb_inputTable.Controls.Add(this.tb_note_1);
            this.tb_note_1 = new TextBox();
            this.gb_inputTable.Controls.Add(this.tb_note_1);
            this.tb_note_1.Location = new System.Drawing.Point(250, 100);
            this.tb_note_1.Name = "tb_note_1";
            this.tb_note_1.Size = new System.Drawing.Size(100, 23);
            this.tb_note_1.TabIndex = 5;
            // note 2
            this.gb_inputTable.Controls.Add(this.tb_note_2);
            this.tb_note_2 = new TextBox();
            this.gb_inputTable.Controls.Add(this.tb_note_2);
            this.tb_note_2.Location = new System.Drawing.Point(250, 130);
            this.tb_note_2.Name = "tb_note_2";
            this.tb_note_2.Size = new System.Drawing.Size(100, 23);
            this.tb_note_2.TabIndex = 5;
            // note 3
            this.gb_inputTable.Controls.Add(this.tb_note_3);
            this.tb_note_3 = new TextBox();
            this.gb_inputTable.Controls.Add(this.tb_note_3);
            this.tb_note_3.Location = new System.Drawing.Point(250, 160);
            this.tb_note_3.Name = "tb_note_3";
            this.tb_note_3.Size = new System.Drawing.Size(100, 23);
            this.tb_note_3.TabIndex = 5;
        }


        private void btn_P_18M_Click(object sender, EventArgs e)
        {
            btn_VRS_2DM.setBackColor(false);
            btn_P_18M.setBackColor(true);
        }

        private void btn_VRS_2DM_Click(object sender, EventArgs e)
        {
            btn_VRS_2DM.setBackColor(true);
            btn_P_18M.setBackColor(false);
        }

        public override void btn_ok_click(object sender, EventArgs e)
        {
            // ======================================================================================
            this.pictureBox1.Controls.Clear();
            this.gb_picture.Controls.Remove(this.pictureBox1);
            // Dock the PictureBox to the form and set its background to white.
            //this.pictureBox1.Dock = DockStyle.Fill;

            //this.c_polar.Location = new System.Drawing.Point(0, 0);
            //this.c_polar.Size = new System.Drawing.Size(pictureBoxWidth, pictureBoxHeight);

            ////this.c_polar.BackColor = groupBoxColor;
            // Connect the Paint event of the PictureBox to the event handler method.
            //this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.drawGraph);
            //drawGraph();
            // Add the PictureBox control to the Form.
            //c_polar = new Chart();
            //((System.ComponentModel.ISupportInitialize)(this.c_polar)).BeginInit();
            drawGraph();
            
        }

        private void drawGraph()
        {

            Chart chart = new Chart();
            Series series = new Series();
            ChartArea chartArea1 = new ChartArea();
            chartArea1.Name = "ChartArea1";
            chart.ChartAreas.Add(chartArea1);
            series.BorderWidth = 2;
            series.BorderDashStyle = ChartDashStyle.Solid;
            series.ChartType = SeriesChartType.Line;
            series.Color = Color.Green;
            List<double> values = new List<double>();
            values.Add(12);
            values.Add(15);
            values.Add(16);
            values.Add(13);
            for (int i = 0; i < values.Count; i++)
            {
                series.Points.AddXY(i, values[i]);
            }
            chart.BorderlineColor = Color.Red;
            chart.BorderlineWidth = 1;
            chart.Series.Add(series);
            chart.Titles.Add("chart");
            chart.Invalidate();
            chart.Palette = ChartColorPalette.Fire;
            chartArea1.AxisY.Minimum = values.Min();
            chartArea1.AxisY.Maximum = values.Max();
            this.gb_picture.Controls.Add(chart);


        }
    }
}
