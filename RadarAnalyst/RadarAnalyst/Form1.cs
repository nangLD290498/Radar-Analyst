namespace RadarAnalyst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addWelcomeTabPage()
        {
            TabPage tp_welcome;
            Label lbl_appName;
            PictureBox pictureBox1;
            tp_welcome = new System.Windows.Forms.TabPage();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            lbl_appName = new System.Windows.Forms.Label();
            tp_welcome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            tc_mainTap.Controls.Add(tp_welcome);
            // 
            // tp_welcome
            // 
            tp_welcome.Controls.Add(pictureBox1);
            //tp_welcome.Controls.Add(lbl_appName);
            tp_welcome.Location = new System.Drawing.Point(4, 24);
            tp_welcome.Name = "tp_welcome";
            tp_welcome.Size = new System.Drawing.Size(tc_mainTap.Width, tc_mainTap.Height);
            tp_welcome.TabIndex = 0;
            tp_welcome.Text = "Welcome";
            tp_welcome.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            pictureBox1.Image = global::RadarAnalyst.Properties.Resources.c300b4e006e5c3bb9af4;
            pictureBox1.Location = new System.Drawing.Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(tp_welcome.Width, tp_welcome.Height);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //pictureBox1.Size = new System.Drawing.Size((tc_mainTap.Width) - 100 , 480);
            pictureBox1.TabIndex = 1;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabStop = false;
            pictureBox1.Controls.Add(lbl_appName);
            // 
            // lbl_appName
            // 
            lbl_appName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            lbl_appName.AutoSize = true;
            lbl_appName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lbl_appName.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            
            lbl_appName.Name = "lbl_appName";
            lbl_appName.Size = new System.Drawing.Size(796, 76);
            lbl_appName.TabIndex = 0;
            lbl_appName.Text = "PHẦN MỀM TÍNH TOÁN CÁC THAM SỐ TRẬN ĐỊA CỦA TRẠM RAĐA PHÒNG KHÔNG ";
            lbl_appName.Location = new System.Drawing.Point((tc_mainTap.Width - lbl_appName.Width) / 2 - 50, 50);
            lbl_appName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            tp_welcome.ResumeLayout(false);
            tp_welcome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            tc_mainTap.ContextMenuStrip = null;
        }
        private void addTabPage(string tabCode)
        {
            // cant not open a new tab if it is up running
            bool isAdded = false;
            foreach (TabPage tp in tc_mainTap.TabPages)
            {
                if (tp.Name == tabCode)
                {
                    MessageBox.Show("Cua so dang chay !", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isAdded = true;
                    break;
                }
            }
            if (!isAdded)
            {
                tc_mainTap.TabPages.Clear();
                Console.WriteLine("Form1::addTabPage");
                TabPage myTabPage = Factory.TabFactory.getTab(tabCode);
                tc_mainTap.TabPages.Add(myTabPage);
            }
            // add close button
            ContextMenuStrip cms_close = new ContextMenuStrip();
            ToolStripMenuItem tsmi_close = new ToolStripMenuItem();
            tsmi_close.Text = "Close";
            cms_close.Items.Add(tsmi_close);
            tc_mainTap.ContextMenuStrip = cms_close;
            tsmi_close.Click += new System.EventHandler(tsmi_close_Click);
        }


        private void tsmi_close_Click(object sender, EventArgs e)
        {
            tc_mainTap.TabPages.Remove(tc_mainTap.SelectedTab);
        }

        private void smi_kvctd_Click(object sender, EventArgs e)
        {
            addTabPage(Util.Constant.KVCTD);
            clearTabPageColor();
            smi_vtddrd.BackColor = Color.WhiteSmoke;
        }

        private void smi_dcdd_Click(object sender, EventArgs e)
        {
            addTabPage(Util.Constant.DCDD);
            clearTabPageColor();
            smi_vtddrd.BackColor = Color.WhiteSmoke;
        }

        private void smi_ktmpx_Click(object sender, EventArgs e)
        {
            addTabPage(Util.Constant.KTMPX);
            clearTabPageColor();
            smi_mpx.BackColor = Color.WhiteSmoke;
        }

        private void smi_dll_Click(object sender, EventArgs e)
        {
            addTabPage(Util.Constant.DLL);
            clearTabPageColor();
            smi_mpx.BackColor = Color.WhiteSmoke;
        }

        private void smi_dn_Click(object sender, EventArgs e)
        {
            addTabPage(Util.Constant.DN);
            clearTabPageColor();
            smi_mpx.BackColor = Color.WhiteSmoke;
        }

        private void smi_mcdh_Click(object sender, EventArgs e)
        {
            addTabPage(Util.Constant.MCDH);
            clearTabPageColor();
            smi_mcdh.BackColor = Color.WhiteSmoke;
        }

        private void smi_gck_Click(object sender, EventArgs e)
        {
            addTabPage(Util.Constant.GCK);
            clearTabPageColor();
            smi_gck.BackColor = Color.WhiteSmoke;
        }

        private void smi_pvphmp_Click(object sender, EventArgs e)
        {
            addTabPage(Util.Constant.PVPHMP);
            clearTabPageColor();
            smi_pvphmp.BackColor = Color.WhiteSmoke;
        }

        private void smi_help_Click(object sender, EventArgs e)
        {
            addTabPage(Util.Constant.HELP);
            clearTabPageColor();
            smi_help.BackColor = Color.WhiteSmoke;
        }

        private void smi_vtddrd_CheckedChanged(object sender, EventArgs e)
        {
                smi_vtddrd.BackColor = Color.Blue;
        }

        private void smi_vtddrd_CheckStateChanged(object sender, EventArgs e)
        {
                smi_vtddrd.BackColor = Color.Blue;
        }

        private void smi_vtddrd_Click(object sender, EventArgs e)
        {
       
        }

        public void clearTabPageColor()
        {
            smi_vtddrd.BackColor = Color.White;
            smi_mpx.BackColor = Color.White;
            smi_mcdh.BackColor = Color.White;
            smi_gck.BackColor = Color.White;
            smi_pvphmp.BackColor = Color.White;
            smi_help.BackColor = Color.White;
        }
    }
}