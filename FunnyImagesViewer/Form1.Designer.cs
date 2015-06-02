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
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.addressBox = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.MaximumSize = new System.Drawing.Size(440, 0);
            this.pictureBox.MinimumSize = new System.Drawing.Size(440, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(440, 0);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // prevButton
            // 
            this.prevButton.Enabled = false;
            this.prevButton.Location = new System.Drawing.Point(12, 434);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(75, 23);
            this.prevButton.TabIndex = 4;
            this.prevButton.Text = "<- previous";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(397, 434);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 5;
            this.nextButton.Text = "next ->";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Location = new System.Drawing.Point(12, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 390);
            this.panel1.TabIndex = 6;
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(478, 38);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(485, 390);
            this.outputBox.TabIndex = 7;
            this.outputBox.Text = "";
            this.outputBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.outputBox_LinkClicked);
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(479, 12);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(402, 20);
            this.addressBox.TabIndex = 8;
            // 
            // imgurProcessButton
            // 
            this.imgurProcessButton.Location = new System.Drawing.Point(969, 376);
            this.imgurProcessButton.Name = "imgurProcessButton";
            this.imgurProcessButton.Size = new System.Drawing.Size(75, 23);
            this.imgurProcessButton.TabIndex = 9;
            this.imgurProcessButton.Text = "imgur";
            this.imgurProcessButton.UseVisualStyleBackColor = true;
            this.imgurProcessButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // gagCheckBox
            // 
            this.gagCheckBox.AutoSize = true;
            this.gagCheckBox.Location = new System.Drawing.Point(968, 12);
            this.gagCheckBox.Name = "gagCheckBox";
            this.gagCheckBox.Size = new System.Drawing.Size(50, 17);
            this.gagCheckBox.TabIndex = 10;
            this.gagCheckBox.Text = "9gag";
            this.gagCheckBox.UseVisualStyleBackColor = true;
            this.gagCheckBox.CheckedChanged += new System.EventHandler(this.gagCheckBox_CheckedChanged);
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(969, 405);
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
            this.countLabel.Location = new System.Drawing.Point(367, 439);
            this.countLabel.Name = "countLabel";
            this.countLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.countLabel.Size = new System.Drawing.Size(24, 13);
            this.countLabel.TabIndex = 12;
            this.countLabel.Text = "0/0";
            this.countLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titleLabel.Location = new System.Drawing.Point(9, 12);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(460, 20);
            this.titleLabel.TabIndex = 13;
            this.titleLabel.Text = "Title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(479, 434);
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
            this.imgurCheckBox.Location = new System.Drawing.Point(968, 35);
            this.imgurCheckBox.Name = "imgurCheckBox";
            this.imgurCheckBox.Size = new System.Drawing.Size(52, 17);
            this.imgurCheckBox.TabIndex = 15;
            this.imgurCheckBox.Text = "Imgur";
            this.imgurCheckBox.UseVisualStyleBackColor = true;
            this.imgurCheckBox.CheckedChanged += new System.EventHandler(this.imgurCheckBox_CheckedChanged);
            // 
            // siteLabel
            // 
            this.siteLabel.AutoSize = true;
            this.siteLabel.Location = new System.Drawing.Point(93, 439);
            this.siteLabel.Name = "siteLabel";
            this.siteLabel.Size = new System.Drawing.Size(35, 13);
            this.siteLabel.TabIndex = 16;
            this.siteLabel.Text = "label1";
            // 
            // _9gagProcessButton
            // 
            this._9gagProcessButton.Location = new System.Drawing.Point(970, 347);
            this._9gagProcessButton.Name = "_9gagProcessButton";
            this._9gagProcessButton.Size = new System.Drawing.Size(75, 23);
            this._9gagProcessButton.TabIndex = 17;
            this._9gagProcessButton.Text = "9gag";
            this._9gagProcessButton.UseVisualStyleBackColor = true;
            this._9gagProcessButton.Click += new System.EventHandler(this._9gagProcessButton_Click);
            // 
            // kwejkProcessButton
            // 
            this.kwejkProcessButton.Location = new System.Drawing.Point(970, 318);
            this.kwejkProcessButton.Name = "kwejkProcessButton";
            this.kwejkProcessButton.Size = new System.Drawing.Size(75, 23);
            this.kwejkProcessButton.TabIndex = 18;
            this.kwejkProcessButton.Text = "kwejk";
            this.kwejkProcessButton.UseVisualStyleBackColor = true;
            // 
            // demotywatoryProcessButton
            // 
            this.demotywatoryProcessButton.Location = new System.Drawing.Point(970, 289);
            this.demotywatoryProcessButton.Name = "demotywatoryProcessButton";
            this.demotywatoryProcessButton.Size = new System.Drawing.Size(75, 23);
            this.demotywatoryProcessButton.TabIndex = 19;
            this.demotywatoryProcessButton.Text = "demotywatory";
            this.demotywatoryProcessButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 469);
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
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.KeyPreview = true;
            this.Name = "Form1";
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
        private System.Windows.Forms.RichTextBox outputBox;
        private System.Windows.Forms.TextBox addressBox;
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

    }
}

