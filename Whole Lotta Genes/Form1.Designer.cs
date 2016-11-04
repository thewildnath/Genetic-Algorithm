namespace Whole_Lotta_Genes {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.labelGeneration = new System.Windows.Forms.Label();
            this.labelFitBest = new System.Windows.Forms.Label();
            this.pictureBoxBest = new System.Windows.Forms.PictureBox();
            this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
            this.labelOriginal = new System.Windows.Forms.Label();
            this.labelBest = new System.Windows.Forms.Label();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.labelSelectedImage = new System.Windows.Forms.Label();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // labelGeneration
            // 
            this.labelGeneration.AutoSize = true;
            this.labelGeneration.BackColor = System.Drawing.Color.Transparent;
            this.labelGeneration.Location = new System.Drawing.Point(12, 49);
            this.labelGeneration.Name = "labelGeneration";
            this.labelGeneration.Size = new System.Drawing.Size(81, 13);
            this.labelGeneration.TabIndex = 0;
            this.labelGeneration.Text = "labelGeneration";
            // 
            // labelFitBest
            // 
            this.labelFitBest.AutoSize = true;
            this.labelFitBest.BackColor = System.Drawing.Color.Transparent;
            this.labelFitBest.Location = new System.Drawing.Point(365, 434);
            this.labelFitBest.Name = "labelFitBest";
            this.labelFitBest.Size = new System.Drawing.Size(61, 13);
            this.labelFitBest.TabIndex = 1;
            this.labelFitBest.Text = "labelFitBest";
            // 
            // pictureBoxBest
            // 
            this.pictureBoxBest.BackColor = System.Drawing.Color.Black;
            this.pictureBoxBest.Location = new System.Drawing.Point(368, 68);
            this.pictureBoxBest.Name = "pictureBoxBest";
            this.pictureBoxBest.Size = new System.Drawing.Size(350, 350);
            this.pictureBoxBest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBest.TabIndex = 2;
            this.pictureBoxBest.TabStop = false;
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.BackColor = System.Drawing.Color.Black;
            this.pictureBoxOriginal.Location = new System.Drawing.Point(12, 68);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(350, 350);
            this.pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOriginal.TabIndex = 5;
            this.pictureBoxOriginal.TabStop = false;
            // 
            // labelOriginal
            // 
            this.labelOriginal.AutoSize = true;
            this.labelOriginal.BackColor = System.Drawing.Color.Transparent;
            this.labelOriginal.Location = new System.Drawing.Point(12, 421);
            this.labelOriginal.Name = "labelOriginal";
            this.labelOriginal.Size = new System.Drawing.Size(74, 13);
            this.labelOriginal.TabIndex = 8;
            this.labelOriginal.Text = "Original Image";
            // 
            // labelBest
            // 
            this.labelBest.AutoSize = true;
            this.labelBest.BackColor = System.Drawing.Color.Transparent;
            this.labelBest.Location = new System.Drawing.Point(365, 421);
            this.labelBest.Name = "labelBest";
            this.labelBest.Size = new System.Drawing.Size(60, 13);
            this.labelBest.TabIndex = 9;
            this.labelBest.Text = "Best Image";
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 39;
            this.button1.Text = "Select Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelSelectedImage
            // 
            this.labelSelectedImage.AutoSize = true;
            this.labelSelectedImage.Location = new System.Drawing.Point(112, 17);
            this.labelSelectedImage.Name = "labelSelectedImage";
            this.labelSelectedImage.Size = new System.Drawing.Size(98, 13);
            this.labelSelectedImage.TabIndex = 40;
            this.labelSelectedImage.Text = "No image selected.";
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(643, 17);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(75, 23);
            this.buttonPause.TabIndex = 41;
            this.buttonPause.Text = "Start";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(216, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 45;
            this.buttonSave.Text = "Save Best";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(575, 446);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(144, 13);
            this.label14.TabIndex = 46;
            this.label14.Text = "Made By Nathan Wildenberg";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 468);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.labelSelectedImage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelBest);
            this.Controls.Add(this.labelOriginal);
            this.Controls.Add(this.pictureBoxOriginal);
            this.Controls.Add(this.pictureBoxBest);
            this.Controls.Add(this.labelFitBest);
            this.Controls.Add(this.labelGeneration);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGeneration;
        private System.Windows.Forms.Label labelFitBest;
        private System.Windows.Forms.PictureBox pictureBoxBest;
        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.Label labelOriginal;
        private System.Windows.Forms.Label labelBest;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelSelectedImage;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label14;
    }
}

