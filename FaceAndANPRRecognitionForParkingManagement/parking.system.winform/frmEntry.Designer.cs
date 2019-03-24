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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.btnApproveEntry = new System.Windows.Forms.Button();
            this.txtPlate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(10, 10);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(400, 300);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(416, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // txtFullname
            // 
            this.txtFullname.Location = new System.Drawing.Point(522, 10);
            this.txtFullname.Multiline = true;
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.Size = new System.Drawing.Size(266, 39);
            this.txtFullname.TabIndex = 4;
            // 
            // btnApproveEntry
            // 
            this.btnApproveEntry.Location = new System.Drawing.Point(522, 100);
            this.btnApproveEntry.Name = "btnApproveEntry";
            this.btnApproveEntry.Size = new System.Drawing.Size(266, 51);
            this.btnApproveEntry.TabIndex = 5;
            this.btnApproveEntry.Text = "Approve Entry";
            this.btnApproveEntry.UseVisualStyleBackColor = true;
            this.btnApproveEntry.Click += new System.EventHandler(this.btnApproveEntry_Click);
            // 
            // txtPlate
            // 
            this.txtPlate.Location = new System.Drawing.Point(522, 55);
            this.txtPlate.Multiline = true;
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(266, 39);
            this.txtPlate.TabIndex = 6;
            // 
            // frmEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 334);
            this.Controls.Add(this.txtPlate);
            this.Controls.Add(this.btnApproveEntry);
            this.Controls.Add(this.txtFullname);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.imageBox1);
            this.Name = "frmEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter Parking";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEntry_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtFullname;
        private System.Windows.Forms.Button btnApproveEntry;
        private System.Windows.Forms.TextBox txtPlate;
    }
}