using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarAnalyst.UIComponent
{
    public partial class KTMPXTabPage : TabPage
    {

        public KTMPXTabPage(String tabCode, String text) : base(text)
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
            this.btn_radar2 = new System.Windows.Forms.Button();
            this.btn_radar1 = new System.Windows.Forms.Button();
            this.Controls.Add(this.btn_radar2);
            this.Controls.Add(this.btn_radar1);
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
            this.btn_radar2.Text = "ĐÀI RA ĐA \n VRS-2DM";
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
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_ha = new System.Windows.Forms.NumericUpDown();
            this.btn_ok = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.nud_ha)).BeginInit();

            // 
            // gb_inputTable
            // 
            this.gb_inputTable.Controls.Add(this.label7);
            this.gb_inputTable.Controls.Add(this.label1);
            this.gb_inputTable.Controls.Add(this.nud_ha);
            this.gb_inputTable.Controls.Add(this.btn_ok);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(21, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "ha    :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(207, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "m";
            // 
            // nud_ha
            // 
            this.nud_ha.Location = new System.Drawing.Point(87, 34);
            this.nud_ha.Name = "nud_dph";
            this.nud_ha.Size = new System.Drawing.Size(107, 23);
            this.nud_ha.TabIndex = 1;
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
        }


        private void initOutputTable()
        {
            this.label17 = new System.Windows.Forms.Label();
            this.lbl_result_rmax = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbl_result_rmin = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            // 
            // gb_ouputTable
            // 
            this.gb_ouputTable.Controls.Add(this.label17);
            this.gb_ouputTable.Controls.Add(this.lbl_result_rmax);
            this.gb_ouputTable.Controls.Add(this.label14);
            this.gb_ouputTable.Controls.Add(this.label15);
            this.gb_ouputTable.Controls.Add(this.lbl_result_rmin);
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
            // lbl_result_rmax
            // 
            this.lbl_result_rmax.AutoSize = true;
            this.lbl_result_rmax.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_result_rmax.ForeColor = System.Drawing.Color.Red;
            this.lbl_result_rmax.Location = new System.Drawing.Point(344, 96);
            this.lbl_result_rmax.Name = "lbl_result_rmax";
            this.lbl_result_rmax.Size = new System.Drawing.Size(66, 31);
            this.lbl_result_rmax.TabIndex = 4;
            this.lbl_result_rmax.Text = "1000";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(42, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(279, 31);
            this.label14.TabIndex = 3;
            this.label14.Text = "Bán kính max MPX: Rmax";
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
            // lbl_result_rmin
            // 
            this.lbl_result_rmin.AutoSize = true;
            this.lbl_result_rmin.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_result_rmin.ForeColor = System.Drawing.Color.Red;
            this.lbl_result_rmin.Location = new System.Drawing.Point(344, 47);
            this.lbl_result_rmin.Name = "lbl_result_rmin";
            this.lbl_result_rmin.Size = new System.Drawing.Size(66, 31);
            this.lbl_result_rmin.TabIndex = 1;
            this.lbl_result_rmin.Text = "1000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(42, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(296, 31);
            this.label8.TabIndex = 0;
            this.label8.Text = "Bán kính min MPX: Rmin";
        }


        private void initPicture()
        {
            //todo: draw picture
        }


        private void btn_radar1_Click(object sender, EventArgs e)
        {
            btn_radar1.BackColor = Color.LightBlue;
            btn_radar2.BackColor = Color.AliceBlue;
        }

        private void btn_radar2_Click(object sender, EventArgs e)
        {
            btn_radar1.BackColor = Color.AliceBlue;
            btn_radar2.BackColor = Color.LightBlue;
        }

        private Button btn_radar2;
        private Button btn_radar1;
        private GroupBox gb_picture;
        private GroupBox gb_ouputTable;
        private GroupBox gb_inputTable;
        private Button btn_ok;
        private NumericUpDown nud_ha;
        private Label label7;
        private Label label1;
        private Label label17;
        private Label lbl_result_rmax;
        private Label label14;
        private Label label15;
        private Label lbl_result_rmin;
        private Label label8;

    }
}
