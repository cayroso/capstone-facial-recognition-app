namespace parking.system.winform
{
    partial class frmEntryFace
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
            this.btnNext = new System.Windows.Forms.Button();
            this.imgBox6 = new Emgu.CV.UI.ImageBox();
            this.imgBox5 = new Emgu.CV.UI.ImageBox();
            this.imgBox4 = new Emgu.CV.UI.ImageBox();
            this.imgBox3 = new Emgu.CV.UI.ImageBox();
            this.imgBox2 = new Emgu.CV.UI.ImageBox();
            this.imgBox1 = new Emgu.CV.UI.ImageBox();
            this.btnCaptureFace = new System.Windows.Forms.Button();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(642, 294);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 33);
            this.btnNext.TabIndex = 43;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // imgBox6
            // 
            this.imgBox6.BackColor = System.Drawing.SystemColors.HotTrack;
            this.imgBox6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox6.Location = new System.Drawing.Point(525, 228);
            this.imgBox6.Name = "imgBox6";
            this.imgBox6.Size = new System.Drawing.Size(101, 101);
            this.imgBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgBox6.TabIndex = 42;
            this.imgBox6.TabStop = false;
            // 
            // imgBox5
            // 
            this.imgBox5.BackColor = System.Drawing.SystemColors.HotTrack;
            this.imgBox5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox5.Location = new System.Drawing.Point(525, 121);
            this.imgBox5.Name = "imgBox5";
            this.imgBox5.Size = new System.Drawing.Size(101, 101);
            this.imgBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgBox5.TabIndex = 41;
            this.imgBox5.TabStop = false;
            // 
            // imgBox4
            // 
            this.imgBox4.BackColor = System.Drawing.SystemColors.HotTrack;
            this.imgBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox4.Location = new System.Drawing.Point(525, 14);
            this.imgBox4.Name = "imgBox4";
            this.imgBox4.Size = new System.Drawing.Size(101, 101);
            this.imgBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgBox4.TabIndex = 40;
            this.imgBox4.TabStop = false;
            // 
            // imgBox3
            // 
            this.imgBox3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.imgBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox3.Location = new System.Drawing.Point(418, 228);
            this.imgBox3.Name = "imgBox3";
            this.imgBox3.Size = new System.Drawing.Size(101, 101);
            this.imgBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgBox3.TabIndex = 39;
            this.imgBox3.TabStop = false;
            // 
            // imgBox2
            // 
            this.imgBox2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.imgBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox2.Location = new System.Drawing.Point(418, 121);
            this.imgBox2.Name = "imgBox2";
            this.imgBox2.Size = new System.Drawing.Size(101, 101);
            this.imgBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgBox2.TabIndex = 38;
            this.imgBox2.TabStop = false;
            // 
            // imgBox1
            // 
            this.imgBox1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.imgBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox1.Location = new System.Drawing.Point(418, 14);
            this.imgBox1.Name = "imgBox1";
            this.imgBox1.Size = new System.Drawing.Size(101, 101);
            this.imgBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgBox1.TabIndex = 35;
            this.imgBox1.TabStop = false;
            //this.imgBox1.DoubleClick += new System.EventHandler(this.imgBox_DoubleClick);
            // 
            // btnCaptureFace
            // 
            this.btnCaptureFace.Location = new System.Drawing.Point(632, 12);
            this.btnCaptureFace.Name = "btnCaptureFace";
            this.btnCaptureFace.Size = new System.Drawing.Size(100, 33);
            this.btnCaptureFace.TabIndex = 37;
            this.btnCaptureFace.Text = "Capture";
            this.btnCaptureFace.UseVisualStyleBackColor = true;
            this.btnCaptureFace.Click += new System.EventHandler(this.btnCaptureFace_Click);
            // 
            // imageBox1
            // 
            this.imageBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            this.imageBox1.Location = new System.Drawing.Point(12, 12);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(400, 315);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imageBox1.TabIndex = 36;
            this.imageBox1.TabStop = false;
            // 
            // frmEntryFace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 339);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.imgBox6);
            this.Controls.Add(this.imgBox5);
            this.Controls.Add(this.imgBox4);
            this.Controls.Add(this.imgBox3);
            this.Controls.Add(this.imgBox2);
            this.Controls.Add(this.imgBox1);
            this.Controls.Add(this.btnCaptureFace);
            this.Controls.Add(this.imageBox1);
            this.Name = "frmEntryFace";
            this.Text = "frmEntryFace";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEntryFace_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private Emgu.CV.UI.ImageBox imgBox6;
        private Emgu.CV.UI.ImageBox imgBox5;
        private Emgu.CV.UI.ImageBox imgBox4;
        private Emgu.CV.UI.ImageBox imgBox3;
        private Emgu.CV.UI.ImageBox imgBox2;
        private Emgu.CV.UI.ImageBox imgBox1;
        private System.Windows.Forms.Button btnCaptureFace;
        private Emgu.CV.UI.ImageBox imageBox1;
    }
}