namespace Thermal_Camera
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
            this.goButton = new System.Windows.Forms.Button();
            this.saveTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.visualFrequencyTextBox = new System.Windows.Forms.TextBox();
            this.frameNumberTextBox = new System.Windows.Forms.TextBox();
            this.totalFrameTextBox = new System.Windows.Forms.TextBox();
            this.backButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(691, 37);
            this.goButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(118, 70);
            this.goButton.TabIndex = 0;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // saveTextBox
            // 
            this.saveTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveTextBox.Location = new System.Drawing.Point(31, 63);
            this.saveTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveTextBox.Name = "saveTextBox";
            this.saveTextBox.Size = new System.Drawing.Size(395, 35);
            this.saveTextBox.TabIndex = 1;
            this.saveTextBox.TextChanged += new System.EventHandler(this.saveTextBox_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(38, 120);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(807, 646);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(429, 44);
            this.browseButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(101, 62);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // visualFrequencyTextBox
            // 
            this.visualFrequencyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visualFrequencyTextBox.Location = new System.Drawing.Point(545, 56);
            this.visualFrequencyTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.visualFrequencyTextBox.Name = "visualFrequencyTextBox";
            this.visualFrequencyTextBox.Size = new System.Drawing.Size(129, 35);
            this.visualFrequencyTextBox.TabIndex = 4;
            this.visualFrequencyTextBox.TextChanged += new System.EventHandler(this.visualFrequencyTextBox_TextChanged);
            // 
            // frameNumberTextBox
            // 
            this.frameNumberTextBox.Location = new System.Drawing.Point(355, 780);
            this.frameNumberTextBox.Name = "frameNumberTextBox";
            this.frameNumberTextBox.Size = new System.Drawing.Size(44, 26);
            this.frameNumberTextBox.TabIndex = 5;
            this.frameNumberTextBox.TextChanged += new System.EventHandler(this.frameNumberTextBox_TextChanged);
            // 
            // totalFrameTextBox
            // 
            this.totalFrameTextBox.Location = new System.Drawing.Point(406, 780);
            this.totalFrameTextBox.Name = "totalFrameTextBox";
            this.totalFrameTextBox.ReadOnly = true;
            this.totalFrameTextBox.Size = new System.Drawing.Size(100, 26);
            this.totalFrameTextBox.TabIndex = 6;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(315, 776);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(34, 35);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "<";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // forwardButton
            // 
            this.forwardButton.Location = new System.Drawing.Point(512, 775);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(34, 32);
            this.forwardButton.TabIndex = 8;
            this.forwardButton.Text = ">";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(740, 774);
            this.exportButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(86, 31);
            this.exportButton.TabIndex = 9;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(12, 781);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.ReadOnly = true;
            this.fileNameTextBox.Size = new System.Drawing.Size(278, 26);
            this.fileNameTextBox.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 818);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.totalFrameTextBox);
            this.Controls.Add(this.frameNumberTextBox);
            this.Controls.Add(this.visualFrequencyTextBox);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.saveTextBox);
            this.Controls.Add(this.goButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.TextBox saveTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox visualFrequencyTextBox;
        private System.Windows.Forms.TextBox frameNumberTextBox;
        private System.Windows.Forms.TextBox totalFrameTextBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.TextBox fileNameTextBox;
    }
}