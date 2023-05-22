namespace Puzzle
{
    partial class Form4
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
            this.t1 = new System.Windows.Forms.PictureBox();
            this.t2 = new System.Windows.Forms.PictureBox();
            this.t3 = new System.Windows.Forms.PictureBox();
            this.t4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.t1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t4)).BeginInit();
            this.SuspendLayout();
            // 
            // t1
            // 
            this.t1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.t1.Location = new System.Drawing.Point(40, 25);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(200, 200);
            this.t1.TabIndex = 0;
            this.t1.TabStop = false;
            this.t1.Visible = false;
            // 
            // t2
            // 
            this.t2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.t2.Location = new System.Drawing.Point(246, 25);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(200, 200);
            this.t2.TabIndex = 1;
            this.t2.TabStop = false;
            this.t2.Visible = false;
            // 
            // t3
            // 
            this.t3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.t3.Location = new System.Drawing.Point(40, 231);
            this.t3.Name = "t3";
            this.t3.Size = new System.Drawing.Size(200, 200);
            this.t3.TabIndex = 2;
            this.t3.TabStop = false;
            this.t3.Visible = false;
            // 
            // t4
            // 
            this.t4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.t4.Location = new System.Drawing.Point(246, 231);
            this.t4.Name = "t4";
            this.t4.Size = new System.Drawing.Size(200, 200);
            this.t4.TabIndex = 3;
            this.t4.TabStop = false;
            this.t4.Visible = false;
            this.t4.Click += new System.EventHandler(this.t4_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 483);
            this.Controls.Add(this.t4);
            this.Controls.Add(this.t3);
            this.Controls.Add(this.t2);
            this.Controls.Add(this.t1);
            this.Name = "Form4";
            this.Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)(this.t1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox t1;
        private System.Windows.Forms.PictureBox t2;
        private System.Windows.Forms.PictureBox t3;
        private System.Windows.Forms.PictureBox t4;
    }
}