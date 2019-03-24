namespace parking.system.winform
{
    partial class frmRegistrations
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
            this.lvwRegistrations = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lvwRegistrations
            // 
            this.lvwRegistrations.Location = new System.Drawing.Point(12, 12);
            this.lvwRegistrations.Name = "lvwRegistrations";
            this.lvwRegistrations.Size = new System.Drawing.Size(563, 426);
            this.lvwRegistrations.TabIndex = 0;
            this.lvwRegistrations.UseCompatibleStateImageBehavior = false;
            this.lvwRegistrations.View = System.Windows.Forms.View.Details;
            this.lvwRegistrations.SelectedIndexChanged += new System.EventHandler(this.lvwRegistrations_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(581, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 194);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmRegistrations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lvwRegistrations);
            this.Name = "frmRegistrations";
            this.Text = "Registrations";
            this.Load += new System.EventHandler(this.frmRegistrations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwRegistrations;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}