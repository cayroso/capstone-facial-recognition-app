namespace parking.system.winform
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.lblTotalHours = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.pb6 = new System.Windows.Forms.PictureBox();
            this.pb5 = new System.Windows.Forms.PictureBox();
            this.pb4 = new System.Windows.Forms.PictureBox();
            this.pb3 = new System.Windows.Forms.PictureBox();
            this.pb2 = new System.Windows.Forms.PictureBox();
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.lvwParking = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRegistrations = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRegister = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tsbEntry = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lblTotalHours);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label3);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label2);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lblEnd);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lblStart);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pb6);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pb5);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pb4);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pb3);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pb2);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pb1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lvwParking);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1002, 523);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1002, 548);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // lblTotalHours
            // 
            this.lblTotalHours.AutoSize = true;
            this.lblTotalHours.Location = new System.Drawing.Point(858, 383);
            this.lblTotalHours.Name = "lblTotalHours";
            this.lblTotalHours.Size = new System.Drawing.Size(24, 13);
            this.lblTotalHours.TabIndex = 13;
            this.lblTotalHours.Text = "n/a";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(783, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Total Hours";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(783, 356);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Date Exit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(783, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Date Entry";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(858, 356);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(24, 13);
            this.lblEnd.TabIndex = 9;
            this.lblEnd.Text = "n/a";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(858, 326);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(24, 13);
            this.lblStart.TabIndex = 8;
            this.lblStart.Text = "n/a";
            // 
            // pb6
            // 
            this.pb6.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pb6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb6.Location = new System.Drawing.Point(888, 215);
            this.pb6.Name = "pb6";
            this.pb6.Size = new System.Drawing.Size(102, 102);
            this.pb6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb6.TabIndex = 7;
            this.pb6.TabStop = false;
            // 
            // pb5
            // 
            this.pb5.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pb5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb5.Location = new System.Drawing.Point(888, 109);
            this.pb5.Name = "pb5";
            this.pb5.Size = new System.Drawing.Size(102, 102);
            this.pb5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb5.TabIndex = 6;
            this.pb5.TabStop = false;
            // 
            // pb4
            // 
            this.pb4.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pb4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb4.Location = new System.Drawing.Point(888, 3);
            this.pb4.Name = "pb4";
            this.pb4.Size = new System.Drawing.Size(102, 102);
            this.pb4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb4.TabIndex = 5;
            this.pb4.TabStop = false;
            // 
            // pb3
            // 
            this.pb3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pb3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb3.Location = new System.Drawing.Point(782, 215);
            this.pb3.Name = "pb3";
            this.pb3.Size = new System.Drawing.Size(102, 102);
            this.pb3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb3.TabIndex = 4;
            this.pb3.TabStop = false;
            // 
            // pb2
            // 
            this.pb2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pb2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb2.Location = new System.Drawing.Point(782, 109);
            this.pb2.Name = "pb2";
            this.pb2.Size = new System.Drawing.Size(102, 102);
            this.pb2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb2.TabIndex = 3;
            this.pb2.TabStop = false;
            // 
            // pb1
            // 
            this.pb1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pb1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb1.Location = new System.Drawing.Point(782, 3);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(102, 102);
            this.pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb1.TabIndex = 2;
            this.pb1.TabStop = false;
            // 
            // lvwParking
            // 
            this.lvwParking.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvwParking.FullRowSelect = true;
            this.lvwParking.GridLines = true;
            this.lvwParking.Location = new System.Drawing.Point(0, 0);
            this.lvwParking.Name = "lvwParking";
            this.lvwParking.Size = new System.Drawing.Size(769, 523);
            this.lvwParking.TabIndex = 0;
            this.lvwParking.UseCompatibleStateImageBehavior = false;
            this.lvwParking.View = System.Windows.Forms.View.Details;
            this.lvwParking.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwParking_ItemSelectionChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRegistrations,
            this.toolStripSeparator1,
            this.tsbRefresh,
            this.toolStripSeparator2,
            this.tsbRegister,
            this.toolStripSeparator3,
            this.tsbExit,
            this.tsbEntry});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(195, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsbRegistrations
            // 
            this.tsbRegistrations.Image = ((System.Drawing.Image)(resources.GetObject("tsbRegistrations.Image")));
            this.tsbRegistrations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRegistrations.Name = "tsbRegistrations";
            this.tsbRegistrations.Size = new System.Drawing.Size(95, 22);
            this.tsbRegistrations.Text = "Registrations";
            this.tsbRegistrations.Visible = false;
            this.tsbRegistrations.Click += new System.EventHandler(this.tsbRegistrations_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(66, 22);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbRegister
            // 
            this.tsbRegister.Image = ((System.Drawing.Image)(resources.GetObject("tsbRegister.Image")));
            this.tsbRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRegister.Name = "tsbRegister";
            this.tsbRegister.Size = new System.Drawing.Size(115, 22);
            this.tsbRegister.Text = "Add Registration";
            this.tsbRegister.Visible = false;
            this.tsbRegister.Click += new System.EventHandler(this.tsbRegister_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(45, 22);
            this.tsbExit.Text = "Exit";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // tsbEntry
            // 
            this.tsbEntry.Image = ((System.Drawing.Image)(resources.GetObject("tsbEntry.Image")));
            this.tsbEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEntry.Name = "tsbEntry";
            this.tsbEntry.Size = new System.Drawing.Size(54, 22);
            this.tsbEntry.Text = "Entry";
            this.tsbEntry.Click += new System.EventHandler(this.tsbEntry_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 548);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parking System";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRegistrations;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbEntry;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbRegister;
        private System.Windows.Forms.ListView lvwParking;
        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.PictureBox pb6;
        private System.Windows.Forms.PictureBox pb5;
        private System.Windows.Forms.PictureBox pb4;
        private System.Windows.Forms.PictureBox pb3;
        private System.Windows.Forms.PictureBox pb2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblTotalHours;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}