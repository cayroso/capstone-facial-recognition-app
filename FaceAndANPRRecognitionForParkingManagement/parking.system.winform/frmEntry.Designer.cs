namespace parking.system.winform
{
    partial class frmEntry
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
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.btnApproveEntry = new System.Windows.Forms.Button();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.btnCaptureFace = new System.Windows.Forms.Button();
            this.imgBox1 = new Emgu.CV.UI.ImageBox();
            this.imgBox2 = new Emgu.CV.UI.ImageBox();
            this.imgBox3 = new Emgu.CV.UI.ImageBox();
            this.imgBox4 = new Emgu.CV.UI.ImageBox();
            this.imgBox5 = new Emgu.CV.UI.ImageBox();
            this.imgBox6 = new Emgu.CV.UI.ImageBox();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lvwPlates = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageBox1.Location = new System.Drawing.Point(12, 5);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(400, 315);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // btnApproveEntry
            // 
            this.btnApproveEntry.Location = new System.Drawing.Point(632, 606);
            this.btnApproveEntry.Name = "btnApproveEntry";
            this.btnApproveEntry.Size = new System.Drawing.Size(100, 37);
            this.btnApproveEntry.TabIndex = 5;
            this.btnApproveEntry.Text = "Approve Entry";
            this.btnApproveEntry.UseVisualStyleBackColor = true;
            this.btnApproveEntry.Click += new System.EventHandler(this.btnApproveEntry_Click);
            // 
            // imageBox2
            // 
            this.imageBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.imageBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageBox2.Location = new System.Drawing.Point(12, 328);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(400, 315);
            this.imageBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imageBox2.TabIndex = 7;
            this.imageBox2.TabStop = false;
            
            // 
            // btnCaptureFace
            // 
            this.btnCaptureFace.Location = new System.Drawing.Point(632, 5);
            this.btnCaptureFace.Name = "btnCaptureFace";
            this.btnCaptureFace.Size = new System.Drawing.Size(100, 33);
            this.btnCaptureFace.TabIndex = 15;
            this.btnCaptureFace.Text = "Capture";
            this.btnCaptureFace.UseVisualStyleBackColor = true;
            this.btnCaptureFace.Click += new System.EventHandler(this.btnCaptureFace_Click);
            // 
            // imgBox1
            // 
            this.imgBox1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.imgBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox1.Location = new System.Drawing.Point(418, 7);
            this.imgBox1.Name = "imgBox1";
            this.imgBox1.Size = new System.Drawing.Size(101, 101);
            this.imgBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgBox1.TabIndex = 2;
            this.imgBox1.TabStop = false;
            // 
            // imgBox2
            // 
            this.imgBox2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.imgBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox2.Location = new System.Drawing.Point(418, 114);
            this.imgBox2.Name = "imgBox2";
            this.imgBox2.Size = new System.Drawing.Size(101, 101);
            this.imgBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgBox2.TabIndex = 17;
            this.imgBox2.TabStop = false;
            // 
            // imgBox3
            // 
            this.imgBox3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.imgBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox3.Location = new System.Drawing.Point(418, 221);
            this.imgBox3.Name = "imgBox3";
            this.imgBox3.Size = new System.Drawing.Size(101, 101);
            this.imgBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgBox3.TabIndex = 18;
            this.imgBox3.TabStop = false;
            // 
            // imgBox4
            // 
            this.imgBox4.BackColor = System.Drawing.SystemColors.HotTrack;
            this.imgBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox4.Location = new System.Drawing.Point(525, 7);
            this.imgBox4.Name = "imgBox4";
            this.imgBox4.Size = new System.Drawing.Size(101, 101);
            this.imgBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgBox4.TabIndex = 19;
            this.imgBox4.TabStop = false;
            // 
            // imgBox5
            // 
            this.imgBox5.BackColor = System.Drawing.SystemColors.HotTrack;
            this.imgBox5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox5.Location = new System.Drawing.Point(525, 114);
            this.imgBox5.Name = "imgBox5";
            this.imgBox5.Size = new System.Drawing.Size(101, 101);
            this.imgBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgBox5.TabIndex = 20;
            this.imgBox5.TabStop = false;
            // 
            // imgBox6
            // 
            this.imgBox6.BackColor = System.Drawing.SystemColors.HotTrack;
            this.imgBox6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox6.Location = new System.Drawing.Point(525, 221);
            this.imgBox6.Name = "imgBox6";
            this.imgBox6.Size = new System.Drawing.Size(101, 101);
            this.imgBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgBox6.TabIndex = 21;
            this.imgBox6.TabStop = false;
            // 
            // txtPlate
            // 
            this.txtPlate.Location = new System.Drawing.Point(418, 623);
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(208, 20);
            this.txtPlate.TabIndex = 22;
            
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(632, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 33);
            this.button1.TabIndex = 23;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lvwPlates
            // 
            this.lvwPlates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwPlates.FullRowSelect = true;
            this.lvwPlates.Location = new System.Drawing.Point(418, 328);
            this.lvwPlates.Name = "lvwPlates";
            this.lvwPlates.Size = new System.Drawing.Size(208, 289);
            this.lvwPlates.TabIndex = 24;
            this.lvwPlates.UseCompatibleStateImageBehavior = false;
            this.lvwPlates.View = System.Windows.Forms.View.Details;
            this.lvwPlates.SelectedIndexChanged += new System.EventHandler(this.lvwPlates_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Plate";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Confidence";
            // 
            // frmEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 649);
            this.Controls.Add(this.lvwPlates);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPlate);
            this.Controls.Add(this.imgBox6);
            this.Controls.Add(this.imgBox5);
            this.Controls.Add(this.imgBox4);
            this.Controls.Add(this.imgBox3);
            this.Controls.Add(this.imgBox2);
            this.Controls.Add(this.imgBox1);
            this.Controls.Add(this.btnCaptureFace);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.btnApproveEntry);
            this.Controls.Add(this.imageBox1);
            this.Name = "frmEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter Parking";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEntry_FormClosed);
            this.Load += new System.EventHandler(this.frmEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button btnApproveEntry;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Button btnCaptureFace;
        private Emgu.CV.UI.ImageBox imgBox1;
        private Emgu.CV.UI.ImageBox imgBox2;
        private Emgu.CV.UI.ImageBox imgBox3;
        private Emgu.CV.UI.ImageBox imgBox4;
        private Emgu.CV.UI.ImageBox imgBox5;
        private Emgu.CV.UI.ImageBox imgBox6;
        private System.Windows.Forms.TextBox txtPlate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lvwPlates;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}