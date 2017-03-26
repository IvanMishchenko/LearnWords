namespace LearnWords.Forms.dialogForms
{
    partial class FormTest
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
            this.label1 = new System.Windows.Forms.Label();
            this.WordLabel = new System.Windows.Forms.Label();
            this.RB1 = new System.Windows.Forms.RadioButton();
            this.RB2 = new System.Windows.Forms.RadioButton();
            this.RB = new System.Windows.Forms.RadioButton();
            this.RB4 = new System.Windows.Forms.RadioButton();
            this.RB5 = new System.Windows.Forms.RadioButton();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.NKnowButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.CategoryNameLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category name:";
            // 
            // WordLabel
            // 
            this.WordLabel.AutoSize = true;
            this.WordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WordLabel.Location = new System.Drawing.Point(12, 43);
            this.WordLabel.Name = "WordLabel";
            this.WordLabel.Size = new System.Drawing.Size(111, 24);
            this.WordLabel.TabIndex = 1;
            this.WordLabel.Text = "WordNone";
            this.WordLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // RB1
            // 
            this.RB1.AutoSize = true;
            this.RB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RB1.Location = new System.Drawing.Point(15, 80);
            this.RB1.Name = "RB1";
            this.RB1.Size = new System.Drawing.Size(56, 20);
            this.RB1.TabIndex = 2;
            this.RB1.Text = "none";
            this.RB1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB1.UseVisualStyleBackColor = true;
            this.RB1.CheckedChanged += new System.EventHandler(this.RbCheckedChanged);
            // 
            // RB2
            // 
            this.RB2.AutoSize = true;
            this.RB2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RB2.Location = new System.Drawing.Point(15, 103);
            this.RB2.Name = "RB2";
            this.RB2.Size = new System.Drawing.Size(56, 20);
            this.RB2.TabIndex = 3;
            this.RB2.Text = "none";
            this.RB2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB2.UseVisualStyleBackColor = true;
            this.RB2.CheckedChanged += new System.EventHandler(this.RbCheckedChanged);
            // 
            // RB
            // 
            this.RB.AutoSize = true;
            this.RB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RB.Location = new System.Drawing.Point(15, 126);
            this.RB.Name = "RB";
            this.RB.Size = new System.Drawing.Size(56, 20);
            this.RB.TabIndex = 4;
            this.RB.Text = "none";
            this.RB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB.UseVisualStyleBackColor = true;
            this.RB.CheckedChanged += new System.EventHandler(this.RbCheckedChanged);
            // 
            // RB4
            // 
            this.RB4.AutoSize = true;
            this.RB4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RB4.Location = new System.Drawing.Point(15, 149);
            this.RB4.Name = "RB4";
            this.RB4.Size = new System.Drawing.Size(56, 20);
            this.RB4.TabIndex = 5;
            this.RB4.Text = "none";
            this.RB4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB4.UseVisualStyleBackColor = true;
            this.RB4.CheckedChanged += new System.EventHandler(this.RbCheckedChanged);
            // 
            // RB5
            // 
            this.RB5.AutoSize = true;
            this.RB5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RB5.Location = new System.Drawing.Point(15, 172);
            this.RB5.Name = "RB5";
            this.RB5.Size = new System.Drawing.Size(56, 20);
            this.RB5.TabIndex = 6;
            this.RB5.Text = "none";
            this.RB5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB5.UseVisualStyleBackColor = true;
            this.RB5.CheckedChanged += new System.EventHandler(this.RbCheckedChanged);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SubmitButton.Location = new System.Drawing.Point(42, 212);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 7;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // NKnowButton
            // 
            this.NKnowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NKnowButton.Location = new System.Drawing.Point(123, 212);
            this.NKnowButton.Name = "NKnowButton";
            this.NKnowButton.Size = new System.Drawing.Size(75, 23);
            this.NKnowButton.TabIndex = 8;
            this.NKnowButton.Text = "Don\'t know";
            this.NKnowButton.UseVisualStyleBackColor = true;
            this.NKnowButton.Click += new System.EventHandler(this.DNKnowButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.Location = new System.Drawing.Point(204, 212);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 9;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // CategoryNameLabel
            // 
            this.CategoryNameLabel.AutoSize = true;
            this.CategoryNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CategoryNameLabel.Location = new System.Drawing.Point(120, 9);
            this.CategoryNameLabel.Name = "CategoryNameLabel";
            this.CategoryNameLabel.Size = new System.Drawing.Size(46, 16);
            this.CategoryNameLabel.TabIndex = 10;
            this.CategoryNameLabel.Text = "None";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LearnWords.Properties.Resources.no;
            this.pictureBox1.Location = new System.Drawing.Point(167, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 800;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 245);
            this.ControlBox = false;
            this.Controls.Add(this.CategoryNameLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.NKnowButton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.RB5);
            this.Controls.Add(this.RB4);
            this.Controls.Add(this.RB);
            this.Controls.Add(this.RB2);
            this.Controls.Add(this.RB1);
            this.Controls.Add(this.WordLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormTest";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose correct translation";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormTest_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormTest_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormTest_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label WordLabel;
        private System.Windows.Forms.RadioButton RB1;
        private System.Windows.Forms.RadioButton RB2;
        private System.Windows.Forms.RadioButton RB;
        private System.Windows.Forms.RadioButton RB4;
        private System.Windows.Forms.RadioButton RB5;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button NKnowButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label CategoryNameLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
}