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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnParkingEntry = new System.Windows.Forms.Button();
            this.btnParkingExit = new System.Windows.Forms.Button();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnParkingExit);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnParkingEntry);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnRefresh);
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1002, 666);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1002, 666);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // lblTotalHours
            // 
            this.lblTotalHours.AutoSize = true;
            this.lblTotalHours.Location = new System.Drawing.Point(846, 526);
            this.lblTotalHours.Name = "lblTotalHours";
            this.lblTotalHours.Size = new System.Drawing.Size(24, 13);
            this.lblTotalHours.TabIndex = 13;
            this.lblTotalHours.Text = "n/a";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(783, 526);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Total Hours";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(907, 606);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Date Exit";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(783, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Date Entry";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(933, 581);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(24, 13);
            this.lblEnd.TabIndex = 9;
            this.lblEnd.Text = "n/a";
            this.lblEnd.Visible = false;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(846, 499);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(24, 13);
            this.lblStart.TabIndex = 8;
            this.lblStart.Text = "n/a";
            // 
            // pb6
            // 
            this.pb6.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pb6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb6.Location = new System.Drawing.Point(888, 382);
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
            this.pb5.Location = new System.Drawing.Point(888, 276);
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
            this.pb4.Location = new System.Drawing.Point(888, 170);
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
            this.pb3.Location = new System.Drawing.Point(782, 382);
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
            this.pb2.Location = new System.Drawing.Point(782, 276);
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
            this.pb1.Location = new System.Drawing.Point(782, 170);
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
            this.lvwParking.Size = new System.Drawing.Size(769, 666);
            this.lvwParking.TabIndex = 0;
            this.lvwParking.UseCompatibleStateImageBehavior = false;
            this.lvwParking.View = System.Windows.Forms.View.Details;
            this.lvwParking.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwParking_ItemSelectionChanged);
            this.lvwParking.SelectedIndexChanged += new System.EventHandler(this.lvwParking_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(782, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(208, 37);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnParkingEntry
            // 
            this.btnParkingEntry.Location = new System.Drawing.Point(782, 84);
            this.btnParkingEntry.Name = "btnParkingEntry";
            this.btnParkingEntry.Size = new System.Drawing.Size(208, 37);
            this.btnParkingEntry.TabIndex = 15;
            this.btnParkingEntry.Text = "Parking Entry";
            this.btnParkingEntry.UseVisualStyleBackColor = true;
            this.btnParkingEntry.Click += new System.EventHandler(this.btnParkingEntry_Click);
            // 
            // btnParkingExit
            // 
            this.btnParkingExit.Location = new System.Drawing.Point(782, 127);
            this.btnParkingExit.Name = "btnParkingExit";
            this.btnParkingExit.Size = new System.Drawing.Size(208, 37);
            this.btnParkingExit.TabIndex = 16;
            this.btnParkingExit.Text = "Parking Exit";
            this.btnParkingExit.UseVisualStyleBackColor = true;
            this.btnParkingExit.Click += new System.EventHandler(this.btnParkingExit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 666);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parking System";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ListView lvwParking;
        private System.Windows.Forms.PictureBox pb1;
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
        private System.Windows.Forms.Button btnParkingExit;
        private System.Windows.Forms.Button btnParkingEntry;
        private System.Windows.Forms.Button btnRefresh;
    }
}