namespace parking.system.winform
{
    partial class frmEntryPlate
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
            this.lvwPlates = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.btnApproveEntry = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lvwPlates
            // 
            this.lvwPlates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwPlates.FullRowSelect = true;
            this.lvwPlates.Location = new System.Drawing.Point(426, 14);
            this.lvwPlates.Name = "lvwPlates";
            this.lvwPlates.Size = new System.Drawing.Size(208, 289);
            this.lvwPlates.TabIndex = 29;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(640, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 33);
            this.button1.TabIndex = 28;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPlate
            // 
            this.txtPlate.Location = new System.Drawing.Point(426, 309);
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(208, 20);
            this.txtPlate.TabIndex = 27;
            // 
            // imageBox2
            // 
            this.imageBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.imageBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageBox2.Location = new System.Drawing.Point(20, 14);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(400, 315);
            this.imageBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imageBox2.TabIndex = 26;
            this.imageBox2.TabStop = false;
            // 
            // btnApproveEntry
            // 
            this.btnApproveEntry.Location = new System.Drawing.Point(640, 53);
            this.btnApproveEntry.Name = "btnApproveEntry";
            this.btnApproveEntry.Size = new System.Drawing.Size(100, 37);
            this.btnApproveEntry.TabIndex = 25;
            this.btnApproveEntry.Text = "Approve Entry";
            this.btnApproveEntry.UseVisualStyleBackColor = true;
            // 
            // frmEntryPlate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 342);
            this.Controls.Add(this.lvwPlates);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPlate);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.btnApproveEntry);
            this.Name = "frmEntryPlate";
            this.Text = "frmEntryPlate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEntryPlate_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwPlates;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPlate;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Button btnApproveEntry;
    }
}