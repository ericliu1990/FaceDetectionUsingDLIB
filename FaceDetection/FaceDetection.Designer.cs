namespace FaceDetection
{
    partial class FaceDetectionWindow
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.imagesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.LoadImage = new System.Windows.Forms.Button();
            this.cbDetectEye = new System.Windows.Forms.CheckBox();
            this.cbDetectFace = new System.Windows.Forms.CheckBox();
            this.cbShowFaceLandmarks = new System.Windows.Forms.CheckBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.loadingLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(11, 11);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(846, 560);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // imagesPanel
            // 
            this.imagesPanel.Location = new System.Drawing.Point(7, 606);
            this.imagesPanel.Margin = new System.Windows.Forms.Padding(2);
            this.imagesPanel.Name = "imagesPanel";
            this.imagesPanel.Size = new System.Drawing.Size(1097, 110);
            this.imagesPanel.TabIndex = 1;
            // 
            // LoadImage
            // 
            this.LoadImage.Location = new System.Drawing.Point(875, 13);
            this.LoadImage.Margin = new System.Windows.Forms.Padding(4);
            this.LoadImage.Name = "LoadImage";
            this.LoadImage.Size = new System.Drawing.Size(116, 28);
            this.LoadImage.TabIndex = 17;
            this.LoadImage.Text = "Load Image";
            this.LoadImage.UseVisualStyleBackColor = true;
            this.LoadImage.Click += new System.EventHandler(this.LoadImage_Click);
            // 
            // cbDetectEye
            // 
            this.cbDetectEye.AutoSize = true;
            this.cbDetectEye.Checked = true;
            this.cbDetectEye.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDetectEye.Location = new System.Drawing.Point(875, 89);
            this.cbDetectEye.Margin = new System.Windows.Forms.Padding(4);
            this.cbDetectEye.Name = "cbDetectEye";
            this.cbDetectEye.Size = new System.Drawing.Size(221, 21);
            this.cbDetectEye.TabIndex = 16;
            this.cbDetectEye.Text = "Detect Eye (Green Rectangle)";
            this.cbDetectEye.UseVisualStyleBackColor = true;
            this.cbDetectEye.CheckedChanged += new System.EventHandler(this.FaceDetection_Load);
            // 
            // cbDetectFace
            // 
            this.cbDetectFace.AutoSize = true;
            this.cbDetectFace.Checked = true;
            this.cbDetectFace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDetectFace.Location = new System.Drawing.Point(875, 60);
            this.cbDetectFace.Margin = new System.Windows.Forms.Padding(4);
            this.cbDetectFace.Name = "cbDetectFace";
            this.cbDetectFace.Size = new System.Drawing.Size(216, 21);
            this.cbDetectFace.TabIndex = 15;
            this.cbDetectFace.Text = "Detect Face (Blue Rectangle)";
            this.cbDetectFace.UseVisualStyleBackColor = true;
            this.cbDetectFace.CheckedChanged += new System.EventHandler(this.FaceDetection_Load);
            // 
            // cbShowFaceLandmarks
            // 
            this.cbShowFaceLandmarks.AutoSize = true;
            this.cbShowFaceLandmarks.Location = new System.Drawing.Point(875, 118);
            this.cbShowFaceLandmarks.Margin = new System.Windows.Forms.Padding(4);
            this.cbShowFaceLandmarks.Name = "cbShowFaceLandmarks";
            this.cbShowFaceLandmarks.Size = new System.Drawing.Size(231, 21);
            this.cbShowFaceLandmarks.TabIndex = 18;
            this.cbShowFaceLandmarks.Text = "ShowFaceLandmarks (Red Dot)";
            this.cbShowFaceLandmarks.UseVisualStyleBackColor = true;
            this.cbShowFaceLandmarks.CheckedChanged += new System.EventHandler(this.FaceDetection_Load);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image Files (*.bmp;*.gif;*.exif;*.jpg;*.png;*.tiff)|*.bmp;*.gif;*.exif;*.jpg;*.jp" +
    "eg;*.png;*.tiff|All Files (*.*)|*.*";
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.BackColor = System.Drawing.Color.Transparent;
            this.loadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel.Location = new System.Drawing.Point(405, 269);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(0, 25);
            this.loadingLabel.TabIndex = 19;
            // 
            // FaceDetectionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1112, 582);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.cbShowFaceLandmarks);
            this.Controls.Add(this.LoadImage);
            this.Controls.Add(this.cbDetectEye);
            this.Controls.Add(this.cbDetectFace);
            this.Controls.Add(this.imagesPanel);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FaceDetectionWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Face Detection";
            this.Load += new System.EventHandler(this.FaceDetection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.FlowLayoutPanel imagesPanel;
        private System.Windows.Forms.Button LoadImage;
        private System.Windows.Forms.CheckBox cbDetectEye;
        private System.Windows.Forms.CheckBox cbDetectFace;
        private System.Windows.Forms.CheckBox cbShowFaceLandmarks;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label loadingLabel;
    }
}

