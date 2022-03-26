using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarAnalyst.UIComponent
{
    public partial class DCDDTabPage : TabPage
    {

        public DCDDTabPage(String tabCode, String text) : base(text)
        {
            Console.WriteLine("Init DCDD Tab Page");
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
            this.gb_inputTable.MaximumSize = new System.Drawing.Size(253, 396);
            this.gb_inputTable.MinimumSize = new System.Drawing.Size(253, 396);
            this.gb_inputTable.Name = "gb_inputTable";
            this.gb_inputTable.Size = new System.Drawing.Size(253, 396);
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
            initPicture();
        }


        private void initRadarButton()
        {
            this.btn_radar3 = new System.Windows.Forms.Button();
            this.btn_radar2 = new System.Windows.Forms.Button();
            this.btn_radar1 = new System.Windows.Forms.Button();
            this.Controls.Add(this.btn_radar3);
            this.Controls.Add(this.btn_radar2);
            this.Controls.Add(this.btn_radar1);
            // 
            // btn_radar3
            // 
            this.btn_radar3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_radar3.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_radar3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_radar3.Location = new System.Drawing.Point(47, 390);
            this.btn_radar3.MaximumSize = new System.Drawing.Size(135, 83);
            this.btn_radar3.MinimumSize = new System.Drawing.Size(135, 83);
            this.btn_radar3.Name = "btn_radar3";
            this.btn_radar3.Size = new System.Drawing.Size(135, 83);
            this.btn_radar3.TabIndex = 2;
            this.btn_radar3.Text = "ĐÀI RA ĐA \n VRS-2DM";
            this.btn_radar3.UseVisualStyleBackColor = false;
            this.btn_radar3.Click += new System.EventHandler(this.btn_radar3_Click);
            // 
            // btn_radar2
            // 
            this.btn_radar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_radar2.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_radar2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_radar2.Location = new System.Drawing.Point(47, 286);
            this.btn_radar2.MaximumSize = new System.Drawing.Size(135, 83);
            this.btn_radar2.MinimumSize = new System.Drawing.Size(135, 83);
            this.btn_radar2.Name = "btn_radar2";
            this.btn_radar2.Size = new System.Drawing.Size(135, 83);
            this.btn_radar2.TabIndex = 1;
            this.btn_radar2.Text = "ĐÀI RA ĐA \n 36D6M-1-1";
            this.btn_radar2.UseVisualStyleBackColor = false;
            this.btn_radar2.Click += new System.EventHandler(this.btn_radar2_Click);
            // 
            // btn_radar1
            // 
            this.btn_radar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_radar1.BackColor = System.Drawing.Color.LightBlue;
            this.btn_radar1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_radar1.Location = new System.Drawing.Point(47, 181);
            this.btn_radar1.MaximumSize = new System.Drawing.Size(135, 83);
            this.btn_radar1.MinimumSize = new System.Drawing.Size(135, 83);
            this.btn_radar1.Name = "btn_radar1";
            this.btn_radar1.Size = new System.Drawing.Size(135, 83);
            this.btn_radar1.TabIndex = 0;
            this.btn_radar1.Text = "ĐÀI RA ĐA \n P-18 M";
            this.btn_radar1.UseVisualStyleBackColor = false;
            this.btn_radar1.Click += new System.EventHandler(this.btn_radar1_Click);
        }


        private void initInputTable()
        {
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_ha = new System.Windows.Forms.NumericUpDown();
            this.nud_hbd = new System.Windows.Forms.NumericUpDown();
            this.nud_hpx = new System.Windows.Forms.NumericUpDown();
            this.nud_hmt = new System.Windows.Forms.NumericUpDown();
            this.nud_dmax = new System.Windows.Forms.NumericUpDown();
            this.nud_dph = new System.Windows.Forms.NumericUpDown();
            this.btn_ok = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.nud_ha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_hbd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_hpx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_hmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dph)).BeginInit();

            // 
            // gb_inputTable
            // 
            this.gb_inputTable.Controls.Add(this.label13);
            this.gb_inputTable.Controls.Add(this.label12);
            this.gb_inputTable.Controls.Add(this.label11);
            this.gb_inputTable.Controls.Add(this.label10);
            this.gb_inputTable.Controls.Add(this.label9);
            this.gb_inputTable.Controls.Add(this.label7);
            this.gb_inputTable.Controls.Add(this.label6);
            this.gb_inputTable.Controls.Add(this.label5);
            this.gb_inputTable.Controls.Add(this.label4);
            this.gb_inputTable.Controls.Add(this.label3);
            this.gb_inputTable.Controls.Add(this.label2);
            this.gb_inputTable.Controls.Add(this.label1);
            this.gb_inputTable.Controls.Add(this.nud_ha);
            this.gb_inputTable.Controls.Add(this.nud_hbd);
            this.gb_inputTable.Controls.Add(this.nud_hpx);
            this.gb_inputTable.Controls.Add(this.nud_hmt);
            this.gb_inputTable.Controls.Add(this.nud_dmax);
            this.gb_inputTable.Controls.Add(this.nud_dph);
            this.gb_inputTable.Controls.Add(this.btn_ok);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(21, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 20);
            this.label13.TabIndex = 19;
            this.label13.Text = "Dmax :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(21, 209);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 20);
            this.label12.TabIndex = 18;
            this.label12.Text = "Hpx   :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(21, 265);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "Hbđ   :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(21, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 20);
            this.label10.TabIndex = 16;
            this.label10.Text = "Hmt   :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(21, 321);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Ha     :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(21, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Dph    :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(207, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "m";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(207, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "m";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(207, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "m";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(207, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "m";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(207, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "km";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(207, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "km";
            // 
            // nud_ha
            // 
            this.nud_ha.Location = new System.Drawing.Point(87, 318);
            this.nud_ha.Name = "nud_ha";
            this.nud_ha.Size = new System.Drawing.Size(107, 23);
            this.nud_ha.TabIndex = 6;
            // 
            // nud_hbd
            // 
            this.nud_hbd.Location = new System.Drawing.Point(87, 262);
            this.nud_hbd.Name = "nud_hbd";
            this.nud_hbd.Size = new System.Drawing.Size(107, 23);
            this.nud_hbd.TabIndex = 5;
            // 
            // nud_hpx
            // 
            this.nud_hpx.Location = new System.Drawing.Point(87, 206);
            this.nud_hpx.Name = "nud_hpx";
            this.nud_hpx.Size = new System.Drawing.Size(107, 23);
            this.nud_hpx.TabIndex = 4;
            // 
            // nud_hmt
            // 
            this.nud_hmt.Location = new System.Drawing.Point(87, 149);
            this.nud_hmt.Name = "nud_hmt";
            this.nud_hmt.Size = new System.Drawing.Size(107, 23);
            this.nud_hmt.TabIndex = 3;
            // 
            // nud_dmax
            // 
            this.nud_dmax.Location = new System.Drawing.Point(87, 89);
            this.nud_dmax.Name = "nud_dmax";
            this.nud_dmax.Size = new System.Drawing.Size(107, 23);
            this.nud_dmax.TabIndex = 2;
            // 
            // nud_dph
            // 
            this.nud_dph.Location = new System.Drawing.Point(87, 34);
            this.nud_dph.Name = "nud_dph";
            this.nud_dph.Size = new System.Drawing.Size(107, 23);
            this.nud_dph.TabIndex = 1;
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_ok.Location = new System.Drawing.Point(99, 359);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(61, 31);
            this.btn_ok.TabIndex = 0;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;

            ((System.ComponentModel.ISupportInitialize)(this.nud_ha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_hbd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_hpx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_hmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dph)).EndInit();
        }


        private void initOutputTable()
        {
            this.label17 = new System.Windows.Forms.Label();
            this.lbl_result_ha2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbl_result_ha1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            // 
            // gb_ouputTable
            // 
            this.gb_ouputTable.Controls.Add(this.label17);
            this.gb_ouputTable.Controls.Add(this.lbl_result_ha2);
            this.gb_ouputTable.Controls.Add(this.label14);
            this.gb_ouputTable.Controls.Add(this.label15);
            this.gb_ouputTable.Controls.Add(this.lbl_result_ha1);
            this.gb_ouputTable.Controls.Add(this.label8);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(421, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 31);
            this.label17.TabIndex = 5;
            this.label17.Text = "m";
            // 
            // lbl_result_ha2
            // 
            this.lbl_result_ha2.AutoSize = true;
            this.lbl_result_ha2.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_result_ha2.ForeColor = System.Drawing.Color.Red;
            this.lbl_result_ha2.Location = new System.Drawing.Point(344, 96);
            this.lbl_result_ha2.Name = "lbl_result_ha2";
            this.lbl_result_ha2.Size = new System.Drawing.Size(66, 31);
            this.lbl_result_ha2.TabIndex = 4;
            this.lbl_result_ha2.Text = "1000";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(42, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(279, 31);
            this.label14.TabIndex = 3;
            this.label14.Text = "Độ cao anten phải lắp ha";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(421, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 31);
            this.label15.TabIndex = 2;
            this.label15.Text = "m";
            // 
            // lbl_result_ha1
            // 
            this.lbl_result_ha1.AutoSize = true;
            this.lbl_result_ha1.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_result_ha1.ForeColor = System.Drawing.Color.Red;
            this.lbl_result_ha1.Location = new System.Drawing.Point(344, 47);
            this.lbl_result_ha1.Name = "lbl_result_ha1";
            this.lbl_result_ha1.Size = new System.Drawing.Size(66, 31);
            this.lbl_result_ha1.TabIndex = 1;
            this.lbl_result_ha1.Text = "1000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(42, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(296, 31);
            this.label8.TabIndex = 0;
            this.label8.Text = "Độ cao anten tổng hợp Ha";
        }


        private void initPicture()
        {
            //todo: draw picture
        }


        private void btn_radar1_Click(object sender, EventArgs e)
        {
            btn_radar1.BackColor = Color.LightBlue;
            btn_radar2.BackColor = Color.AliceBlue;
            btn_radar3.BackColor = Color.AliceBlue;
        }

        private void btn_radar2_Click(object sender, EventArgs e)
        {
            btn_radar1.BackColor = Color.AliceBlue;
            btn_radar2.BackColor = Color.LightBlue;
            btn_radar3.BackColor = Color.AliceBlue;
        }

        private void btn_radar3_Click(object sender, EventArgs e)
        {
            btn_radar1.BackColor = Color.AliceBlue;
            btn_radar2.BackColor = Color.AliceBlue;
            btn_radar3.BackColor = Color.LightBlue;
        }

        private Button btn_radar3;
        private Button btn_radar2;
        private Button btn_radar1;
        private GroupBox gb_picture;
        private GroupBox gb_ouputTable;
        private GroupBox gb_inputTable;
        private Button btn_ok;
        private NumericUpDown nud_dph;
        private NumericUpDown nud_ha;
        private NumericUpDown nud_hbd;
        private NumericUpDown nud_hpx;
        private NumericUpDown nud_hmt;
        private NumericUpDown nud_dmax;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label17;
        private Label lbl_result_ha2;
        private Label label14;
        private Label label15;
        private Label lbl_result_ha1;
        private Label label8;
    }
}
