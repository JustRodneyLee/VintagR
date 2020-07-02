namespace VintagR
{
    partial class VintagR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VintagR));
            this.VintageButton = new System.Windows.Forms.Button();
            this.PreviewImage = new System.Windows.Forms.PictureBox();
            this.LoadImageButton = new System.Windows.Forms.Button();
            this.listViewImages = new System.Windows.Forms.ListView();
            this.RemoveImageButton = new System.Windows.Forms.Button();
            this.OutputDirButton = new System.Windows.Forms.Button();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewImage)).BeginInit();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // VintageButton
            // 
            this.VintageButton.Enabled = false;
            this.VintageButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VintageButton.Location = new System.Drawing.Point(474, 272);
            this.VintageButton.Name = "VintageButton";
            this.VintageButton.Size = new System.Drawing.Size(150, 40);
            this.VintageButton.TabIndex = 0;
            this.VintageButton.Text = "Process Image";
            this.VintageButton.UseVisualStyleBackColor = true;
            this.VintageButton.Click += new System.EventHandler(this.VintageButton_Click);
            // 
            // PreviewImage
            // 
            this.PreviewImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PreviewImage.Location = new System.Drawing.Point(12, 12);
            this.PreviewImage.Name = "PreviewImage";
            this.PreviewImage.Size = new System.Drawing.Size(300, 300);
            this.PreviewImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PreviewImage.TabIndex = 1;
            this.PreviewImage.TabStop = false;
            // 
            // LoadImageButton
            // 
            this.LoadImageButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadImageButton.Location = new System.Drawing.Point(318, 12);
            this.LoadImageButton.Name = "LoadImageButton";
            this.LoadImageButton.Size = new System.Drawing.Size(150, 40);
            this.LoadImageButton.TabIndex = 2;
            this.LoadImageButton.Text = "Load Images";
            this.LoadImageButton.UseVisualStyleBackColor = true;
            this.LoadImageButton.Click += new System.EventHandler(this.LoadImageButton_Click);
            // 
            // listViewImages
            // 
            this.listViewImages.HideSelection = false;
            this.listViewImages.Location = new System.Drawing.Point(318, 58);
            this.listViewImages.Name = "listViewImages";
            this.listViewImages.Size = new System.Drawing.Size(306, 208);
            this.listViewImages.TabIndex = 3;
            this.listViewImages.UseCompatibleStateImageBehavior = false;
            this.listViewImages.View = System.Windows.Forms.View.List;
            this.listViewImages.SelectedIndexChanged += new System.EventHandler(this.listViewImages_SelectedIndexChanged);
            // 
            // RemoveImageButton
            // 
            this.RemoveImageButton.Enabled = false;
            this.RemoveImageButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveImageButton.Location = new System.Drawing.Point(474, 12);
            this.RemoveImageButton.Name = "RemoveImageButton";
            this.RemoveImageButton.Size = new System.Drawing.Size(150, 40);
            this.RemoveImageButton.TabIndex = 4;
            this.RemoveImageButton.Text = "Remove Image";
            this.RemoveImageButton.UseVisualStyleBackColor = true;
            this.RemoveImageButton.Click += new System.EventHandler(this.RemoveImageButton_Click);
            // 
            // OutputDirButton
            // 
            this.OutputDirButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputDirButton.Location = new System.Drawing.Point(318, 272);
            this.OutputDirButton.Name = "OutputDirButton";
            this.OutputDirButton.Size = new System.Drawing.Size(150, 40);
            this.OutputDirButton.TabIndex = 5;
            this.OutputDirButton.Text = "Select Output";
            this.OutputDirButton.UseVisualStyleBackColor = true;
            this.OutputDirButton.Click += new System.EventHandler(this.OutputDirButton_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.ProgressBar});
            this.StatusStrip.Location = new System.Drawing.Point(0, 320);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(636, 22);
            this.StatusStrip.TabIndex = 6;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(39, 17);
            this.StatusLabel.Text = "Ready";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 16);
            this.ProgressBar.Visible = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image Files | *.png;*.jpg;*.jpeg;*.bmp";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // VintagR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 342);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.OutputDirButton);
            this.Controls.Add(this.RemoveImageButton);
            this.Controls.Add(this.listViewImages);
            this.Controls.Add(this.LoadImageButton);
            this.Controls.Add(this.PreviewImage);
            this.Controls.Add(this.VintageButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VintagR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VintagR";
            this.Load += new System.EventHandler(this.VintagR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PreviewImage)).EndInit();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button VintageButton;
        private System.Windows.Forms.PictureBox PreviewImage;
        private System.Windows.Forms.Button LoadImageButton;
        private System.Windows.Forms.ListView listViewImages;
        private System.Windows.Forms.Button RemoveImageButton;
        private System.Windows.Forms.Button OutputDirButton;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

