namespace CustomControls.AboutBox
{
    partial class AboutBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.aboutInfo = new CustomControls.AboutBox.AboutInfo();
            this.SuspendLayout();
            // 
            // aboutInfo
            // 
            this.aboutInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutInfo.Location = new System.Drawing.Point(9, 9);
            this.aboutInfo.Margin = new System.Windows.Forms.Padding(0);
            this.aboutInfo.Name = "aboutInfo";
            this.aboutInfo.Picture = ((System.Drawing.Image)(resources.GetObject("aboutInfo.Picture")));
            this.aboutInfo.PictureBoxColumnWidth = 145;
            this.aboutInfo.PictureSizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.aboutInfo.Size = new System.Drawing.Size(442, 242);
            this.aboutInfo.TabIndex = 0;
            this.aboutInfo.MoreInfoButtonClicked += new System.EventHandler(this.aboutInfo_MoreInfoButtonClicked);
            this.aboutInfo.OkButtonClicked += new System.EventHandler(this.aboutInfo_OkButtonClicked);
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 260);
            this.Controls.Add(this.aboutInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(419, 254);
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutBox";
            this.Load += new System.EventHandler(this.AboutBox_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AboutInfo aboutInfo;

    }
}
