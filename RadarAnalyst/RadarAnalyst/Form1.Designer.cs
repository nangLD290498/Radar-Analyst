namespace RadarAnalyst
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ms_mainMenu = new System.Windows.Forms.MenuStrip();
            this.smi_vtddrd = new System.Windows.Forms.ToolStripMenuItem();
            this.smi_kvctd = new System.Windows.Forms.ToolStripMenuItem();
            this.smi_dcdd = new System.Windows.Forms.ToolStripMenuItem();
            this.smi_mpx = new System.Windows.Forms.ToolStripMenuItem();
            this.smi_ktmpx = new System.Windows.Forms.ToolStripMenuItem();
            this.smi_dll = new System.Windows.Forms.ToolStripMenuItem();
            this.smi_dn = new System.Windows.Forms.ToolStripMenuItem();
            this.smi_mcdh = new System.Windows.Forms.ToolStripMenuItem();
            this.smi_gck = new System.Windows.Forms.ToolStripMenuItem();
            this.smi_pvphmp = new System.Windows.Forms.ToolStripMenuItem();
            this.smi_help = new System.Windows.Forms.ToolStripMenuItem();
            this.tc_mainTap = new System.Windows.Forms.TabControl();
            this.ms_mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ms_mainMenu
            // 
            this.ms_mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smi_vtddrd,
            this.smi_mpx,
            this.smi_mcdh,
            this.smi_gck,
            this.smi_pvphmp,
            this.smi_help});
            this.ms_mainMenu.Location = new System.Drawing.Point(0, 0);
            this.ms_mainMenu.Name = "ms_mainMenu";
            this.ms_mainMenu.Size = new System.Drawing.Size(1277, 24);
            this.ms_mainMenu.TabIndex = 0;
            this.ms_mainMenu.Text = "Main Menu";
            // 
            // smi_vtddrd
            // 
            this.smi_vtddrd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smi_kvctd,
            this.smi_dcdd});
            this.smi_vtddrd.Name = "smi_vtddrd";
            this.smi_vtddrd.Size = new System.Drawing.Size(129, 20);
            this.smi_vtddrd.Text = "VỊ TRÍ ĐẶT ĐÀI RADA";
            // 
            // smi_kvctd
            // 
            this.smi_kvctd.Name = "smi_kvctd";
            this.smi_kvctd.Size = new System.Drawing.Size(179, 22);
            this.smi_kvctd.Text = "KHU VỰC CHỌN TĐ";
            this.smi_kvctd.Click += new System.EventHandler(this.smi_kvctd_Click);
            // 
            // smi_dcdd
            // 
            this.smi_dcdd.Name = "smi_dcdd";
            this.smi_dcdd.Size = new System.Drawing.Size(179, 22);
            this.smi_dcdd.Text = "ĐỘ CAO Đ. ĐÀI";
            this.smi_dcdd.Click += new System.EventHandler(this.smi_dcdd_Click);
            // 
            // smi_mpx
            // 
            this.smi_mpx.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smi_ktmpx,
            this.smi_dll,
            this.smi_dn});
            this.smi_mpx.Name = "smi_mpx";
            this.smi_mpx.Size = new System.Drawing.Size(98, 20);
            this.smi_mpx.Text = "MẶT PHẢN XẠ";
            // 
            // smi_ktmpx
            // 
            this.smi_ktmpx.Name = "smi_ktmpx";
            this.smi_ktmpx.Size = new System.Drawing.Size(172, 22);
            this.smi_ktmpx.Text = "KÍCH THƯỚC MPX";
            this.smi_ktmpx.Click += new System.EventHandler(this.smi_ktmpx_Click);
            // 
            // smi_dll
            // 
            this.smi_dll.Name = "smi_dll";
            this.smi_dll.Size = new System.Drawing.Size(172, 22);
            this.smi_dll.Text = "ĐỘ LỒI LÕM";
            this.smi_dll.Click += new System.EventHandler(this.smi_dll_Click);
            // 
            // smi_dn
            // 
            this.smi_dn.Name = "smi_dn";
            this.smi_dn.Size = new System.Drawing.Size(172, 22);
            this.smi_dn.Text = "ĐỘ NGHIÊNG";
            this.smi_dn.Click += new System.EventHandler(this.smi_dn_Click);
            // 
            // smi_mcdh
            // 
            this.smi_mcdh.Name = "smi_mcdh";
            this.smi_mcdh.Size = new System.Drawing.Size(124, 20);
            this.smi_mcdh.Text = "MẶT CẮT ĐỊA HÌNH";
            this.smi_mcdh.Click += new System.EventHandler(this.smi_mcdh_Click);
            // 
            // smi_gck
            // 
            this.smi_gck.Name = "smi_gck";
            this.smi_gck.Size = new System.Drawing.Size(111, 20);
            this.smi_gck.Text = "GÓC CHE KHUẤT";
            this.smi_gck.Click += new System.EventHandler(this.smi_gck_Click);
            // 
            // smi_pvphmp
            // 
            this.smi_pvphmp.Name = "smi_pvphmp";
            this.smi_pvphmp.Size = new System.Drawing.Size(150, 20);
            this.smi_pvphmp.Text = "PHẠM VI PHÁT HIỆN MP";
            this.smi_pvphmp.Click += new System.EventHandler(this.smi_pvphmp_Click);
            // 
            // smi_help
            // 
            this.smi_help.Name = "smi_help";
            this.smi_help.Size = new System.Drawing.Size(47, 20);
            this.smi_help.Text = "HELP";
            // 
            // tc_mainTap
            // 
            this.tc_mainTap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tc_mainTap.Location = new System.Drawing.Point(12, 37);
            this.tc_mainTap.Name = "tc_mainTap";
            this.tc_mainTap.SelectedIndex = 0;
            this.tc_mainTap.Size = new System.Drawing.Size(1500, 700);
            this.tc_mainTap.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 700);
            this.Controls.Add(this.tc_mainTap);
            this.Controls.Add(this.ms_mainMenu);
            this.MainMenuStrip = this.ms_mainMenu;
            //this.MaximizeBox = true;
            //this.MaximumSize = new System.Drawing.Size(1500, 700);
            //this.MinimumSize = new System.Drawing.Size(1500, 700);
            this.Name = "Form1";
            this.Text = "Rada Analyst";
            this.ms_mainMenu.ResumeLayout(false);
            this.ms_mainMenu.PerformLayout();
            this.ResumeLayout(false);
            addWelcomeTabPage();
            this.PerformLayout();

        }

        #endregion

        private MenuStrip ms_mainMenu;
        private ToolStripMenuItem smi_vtddrd;
        private ToolStripMenuItem smi_kvctd;
        private ToolStripMenuItem smi_dcdd;
        private ToolStripMenuItem smi_mpx;
        private ToolStripMenuItem smi_ktmpx;
        private ToolStripMenuItem smi_dll;
        private ToolStripMenuItem smi_dn;
        private ToolStripMenuItem smi_mcdh;
        private ToolStripMenuItem smi_gck;
        private ToolStripMenuItem smi_pvphmp;
        private ToolStripMenuItem smi_help;

        private TabControl tc_mainTap;

    }
}