namespace parking.system.winform
{
    partial class frmRegister
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
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.imgBox1 = new Emgu.CV.UI.ImageBox();
            this.imgBox2 = new Emgu.CV.UI.ImageBox();
            this.imgBox3 = new Emgu.CV.UI.ImageBox();
            this.imgBox4 = new Emgu.CV.UI.ImageBox();
            this.imgBox5 = new Emgu.CV.UI.ImageBox();
            this.imgBox6 = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox2
            // 
            this.imageBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageBox2.Location = new System.Drawing.Point(12, 12);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(344, 284);
            this.imageBox2.TabIndex = 2;
            this.imageBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(362, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 39);
            this.button1.TabIndex = 4;
            this.button1.Text = "Capture";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Full Name";
            // 
            // txtFullname
            // 
            this.txtFullname.Location = new System.Drawing.Point(72, 302);
            this.txtFullname.Multiline = true;
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.Size = new System.Drawing.Size(409, 42);
            this.txtFullname.TabIndex = 10;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(487, 302);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(193, 42);
            this.btnRegister.TabIndex = 11;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(530, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(151, 39);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // imgBox1
            // 
            this.imgBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox1.Location = new System.Drawing.Point(368, 68);
            this.imgBox1.Name = "imgBox1";
            this.imgBox1.Size = new System.Drawing.Size(100, 100);
            this.imgBox1.TabIndex = 2;
            this.imgBox1.TabStop = false;
            // 
            // imgBox2
            // 
            this.imgBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox2.Location = new System.Drawing.Point(474, 68);
            this.imgBox2.Name = "imgBox2";
            this.imgBox2.Size = new System.Drawing.Size(100, 100);
            this.imgBox2.TabIndex = 14;
            this.imgBox2.TabStop = false;
            // 
            // imgBox3
            // 
            this.imgBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox3.Location = new System.Drawing.Point(580, 68);
            this.imgBox3.Name = "imgBox3";
            this.imgBox3.Size = new System.Drawing.Size(100, 100);
            this.imgBox3.TabIndex = 15;
            this.imgBox3.TabStop = false;
            // 
            // imgBox4
            // 
            this.imgBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox4.Location = new System.Drawing.Point(368, 174);
            this.imgBox4.Name = "imgBox4";
            this.imgBox4.Size = new System.Drawing.Size(100, 100);
            this.imgBox4.TabIndex = 16;
            this.imgBox4.TabStop = false;
            // 
            // imgBox5
            // 
            this.imgBox5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox5.Location = new System.Drawing.Point(474, 174);
            this.imgBox5.Name = "imgBox5";
            this.imgBox5.Size = new System.Drawing.Size(100, 100);
            this.imgBox5.TabIndex = 17;
            this.imgBox5.TabStop = false;
            // 
            // imgBox6
            // 
            this.imgBox6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox6.Location = new System.Drawing.Point(580, 174);
            this.imgBox6.Name = "imgBox6";
            this.imgBox6.Size = new System.Drawing.Size(100, 100);
            this.imgBox6.TabIndex = 18;
            this.imgBox6.TabStop = false;
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 353);
            this.Controls.Add(this.imgBox6);
            this.Controls.Add(this.imgBox5);
            this.Controls.Add(this.imgBox4);
            this.Controls.Add(this.imgBox3);
            this.Controls.Add(this.imgBox2);
            this.Controls.Add(this.imgBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtFullname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imageBox2);
            this.Name = "frmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEntry_FormClosed);
            this.Load += new System.EventHandler(this.frmEntry_Load);
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
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFullname;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnReset;
        private Emgu.CV.UI.ImageBox imgBox1;
        private Emgu.CV.UI.ImageBox imgBox2;
        private Emgu.CV.UI.ImageBox imgBox3;
        private Emgu.CV.UI.ImageBox imgBox4;
        private Emgu.CV.UI.ImageBox imgBox5;
        private Emgu.CV.UI.ImageBox imgBox6;
    }
}