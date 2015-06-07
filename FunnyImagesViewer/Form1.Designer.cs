namespace FunnyImagesViewer
{
    partial class Form1
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
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgurProcessButton = new System.Windows.Forms.Button();
            this.gagCheckBox = new System.Windows.Forms.CheckBox();
            this.goButton = new System.Windows.Forms.Button();
            this.countLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.imgurCheckBox = new System.Windows.Forms.CheckBox();
            this.siteLabel = new System.Windows.Forms.Label();
            this._9gagProcessButton = new System.Windows.Forms.Button();
            this.kwejkProcessButton = new System.Windows.Forms.Button();
            this.demotywatoryProcessButton = new System.Windows.Forms.Button();
            this.demotywatoryCheckBox = new System.Windows.Forms.CheckBox();
            this.kwejkCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(330, 0);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // prevButton
            // 
            this.prevButton.Enabled = false;
            this.prevButton.Location = new System.Drawing.Point(96, 73);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(75, 23);
            this.prevButton.TabIndex = 4;
            this.prevButton.Text = "<- previous";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Enabled = false;
            this.nextButton.Location = new System.Drawing.Point(177, 73);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 5;
            this.nextButton.Text = "next ->";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Location = new System.Drawing.Point(18, 102);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.MaximumSize = new System.Drawing.Size(1400, 900);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.panel1.Size = new System.Drawing.Size(355, 0);
            this.panel1.TabIndex = 6;
            // 
            // imgurProcessButton
            // 
            this.imgurProcessButton.Location = new System.Drawing.Point(177, 38);
            this.imgurProcessButton.Name = "imgurProcessButton";
            this.imgurProcessButton.Size = new System.Drawing.Size(75, 23);
            this.imgurProcessButton.TabIndex = 9;
            this.imgurProcessButton.Text = "imgur";
            this.imgurProcessButton.UseVisualStyleBackColor = true;
            this.imgurProcessButton.Visible = false;
            this.imgurProcessButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // gagCheckBox
            // 
            this.gagCheckBox.AutoSize = true;
            this.gagCheckBox.Checked = true;
            this.gagCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gagCheckBox.Location = new System.Drawing.Point(15, 12);
            this.gagCheckBox.Name = "gagCheckBox";
            this.gagCheckBox.Size = new System.Drawing.Size(50, 17);
            this.gagCheckBox.TabIndex = 10;
            this.gagCheckBox.Text = "9gag";
            this.gagCheckBox.UseVisualStyleBackColor = true;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(15, 73);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 11;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(294, 13);
            this.countLabel.Name = "countLabel";
            this.countLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.countLabel.Size = new System.Drawing.Size(24, 13);
            this.countLabel.TabIndex = 12;
            this.countLabel.Text = "0/0";
            this.countLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titleLabel.Location = new System.Drawing.Point(12, 41);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(400, 20);
            this.titleLabel.TabIndex = 13;
            this.titleLabel.Text = "Title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(258, 73);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "Save image";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // imgurCheckBox
            // 
            this.imgurCheckBox.AutoSize = true;
            this.imgurCheckBox.Location = new System.Drawing.Point(71, 12);
            this.imgurCheckBox.Name = "imgurCheckBox";
            this.imgurCheckBox.Size = new System.Drawing.Size(52, 17);
            this.imgurCheckBox.TabIndex = 15;
            this.imgurCheckBox.Text = "Imgur";
            this.imgurCheckBox.UseVisualStyleBackColor = true;
            // 
            // siteLabel
            // 
            this.siteLabel.AutoSize = true;
            this.siteLabel.Location = new System.Drawing.Point(334, 13);
            this.siteLabel.Name = "siteLabel";
            this.siteLabel.Size = new System.Drawing.Size(35, 13);
            this.siteLabel.TabIndex = 16;
            this.siteLabel.Text = "label1";
            // 
            // _9gagProcessButton
            // 
            this._9gagProcessButton.Location = new System.Drawing.Point(258, 38);
            this._9gagProcessButton.Name = "_9gagProcessButton";
            this._9gagProcessButton.Size = new System.Drawing.Size(75, 23);
            this._9gagProcessButton.TabIndex = 17;
            this._9gagProcessButton.Text = "9gag";
            this._9gagProcessButton.UseVisualStyleBackColor = true;
            this._9gagProcessButton.Visible = false;
            this._9gagProcessButton.Click += new System.EventHandler(this._9gagProcessButton_Click);
            // 
            // kwejkProcessButton
            // 
            this.kwejkProcessButton.Location = new System.Drawing.Point(96, 38);
            this.kwejkProcessButton.Name = "kwejkProcessButton";
            this.kwejkProcessButton.Size = new System.Drawing.Size(75, 23);
            this.kwejkProcessButton.TabIndex = 18;
            this.kwejkProcessButton.Text = "kwejk";
            this.kwejkProcessButton.UseVisualStyleBackColor = true;
            this.kwejkProcessButton.Visible = false;
            this.kwejkProcessButton.Click += new System.EventHandler(this.kwejkProcessButton_Click);
            // 
            // demotywatoryProcessButton
            // 
            this.demotywatoryProcessButton.Location = new System.Drawing.Point(15, 38);
            this.demotywatoryProcessButton.Name = "demotywatoryProcessButton";
            this.demotywatoryProcessButton.Size = new System.Drawing.Size(75, 23);
            this.demotywatoryProcessButton.TabIndex = 19;
            this.demotywatoryProcessButton.Text = "demotywatory";
            this.demotywatoryProcessButton.UseVisualStyleBackColor = true;
            this.demotywatoryProcessButton.Visible = false;
            this.demotywatoryProcessButton.Click += new System.EventHandler(this.demotywatoryProcessButton_Click);
            // 
            // demotywatoryCheckBox
            // 
            this.demotywatoryCheckBox.AutoSize = true;
            this.demotywatoryCheckBox.Checked = true;
            this.demotywatoryCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.demotywatoryCheckBox.Location = new System.Drawing.Point(137, 12);
            this.demotywatoryCheckBox.Name = "demotywatoryCheckBox";
            this.demotywatoryCheckBox.Size = new System.Drawing.Size(91, 17);
            this.demotywatoryCheckBox.TabIndex = 20;
            this.demotywatoryCheckBox.Text = "demotywatory";
            this.demotywatoryCheckBox.UseVisualStyleBackColor = true;
            // 
            // kwejkCheckBox
            // 
            this.kwejkCheckBox.AutoSize = true;
            this.kwejkCheckBox.Checked = true;
            this.kwejkCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kwejkCheckBox.Location = new System.Drawing.Point(234, 12);
            this.kwejkCheckBox.Name = "kwejkCheckBox";
            this.kwejkCheckBox.Size = new System.Drawing.Size(54, 17);
            this.kwejkCheckBox.TabIndex = 21;
            this.kwejkCheckBox.Text = "kwejk";
            this.kwejkCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(379, 124);
            this.Controls.Add(this.kwejkCheckBox);
            this.Controls.Add(this.demotywatoryCheckBox);
            this.Controls.Add(this.demotywatoryProcessButton);
            this.Controls.Add(this.kwejkProcessButton);
            this.Controls.Add(this._9gagProcessButton);
            this.Controls.Add(this.siteLabel);
            this.Controls.Add(this.imgurCheckBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.gagCheckBox);
            this.Controls.Add(this.imgurProcessButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Image scrapper";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button imgurProcessButton;
        private System.Windows.Forms.CheckBox gagCheckBox;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox imgurCheckBox;
        private System.Windows.Forms.Label siteLabel;
        private System.Windows.Forms.Button _9gagProcessButton;
        private System.Windows.Forms.Button kwejkProcessButton;
        private System.Windows.Forms.Button demotywatoryProcessButton;
        private System.Windows.Forms.CheckBox demotywatoryCheckBox;
        private System.Windows.Forms.CheckBox kwejkCheckBox;

    }
}

