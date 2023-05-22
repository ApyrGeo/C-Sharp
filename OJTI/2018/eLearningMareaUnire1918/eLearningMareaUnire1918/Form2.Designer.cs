namespace eLearningMareaUnire1918
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.raspunsbD = new System.Windows.Forms.RadioButton();
            this.raspunsaD = new System.Windows.Forms.RadioButton();
            this.raspunsdC = new System.Windows.Forms.RadioButton();
            this.raspunscC = new System.Windows.Forms.RadioButton();
            this.raspunsbC = new System.Windows.Forms.RadioButton();
            this.raspunsaC = new System.Windows.Forms.RadioButton();
            this.raspunsdB = new System.Windows.Forms.CheckBox();
            this.raspunscB = new System.Windows.Forms.CheckBox();
            this.raspunsbB = new System.Windows.Forms.CheckBox();
            this.raspunsaB = new System.Windows.Forms.CheckBox();
            this.textboxA = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelA = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.button5 = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Meniu elev";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(790, 499);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Carnet  de note";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(687, 101);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(79, 43);
            this.button4.TabIndex = 2;
            this.button4.Text = "Print";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(247, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(29, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(636, 411);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nota";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Data";
            this.Column2.Name = "Column2";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(790, 499);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Grafic de note";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series3.BorderWidth = 5;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "evolutie";
            series4.BorderWidth = 5;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "medie";
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(784, 493);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.PeachPuff;
            this.tabPage1.Controls.Add(this.raspunsbD);
            this.tabPage1.Controls.Add(this.raspunsaD);
            this.tabPage1.Controls.Add(this.raspunsdC);
            this.tabPage1.Controls.Add(this.raspunscC);
            this.tabPage1.Controls.Add(this.raspunsbC);
            this.tabPage1.Controls.Add(this.raspunsaC);
            this.tabPage1.Controls.Add(this.raspunsdB);
            this.tabPage1.Controls.Add(this.raspunscB);
            this.tabPage1.Controls.Add(this.raspunsbB);
            this.tabPage1.Controls.Add(this.raspunsaB);
            this.tabPage1.Controls.Add(this.textboxA);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.labelA);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(790, 499);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Teste";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // raspunsbD
            // 
            this.raspunsbD.AutoSize = true;
            this.raspunsbD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.raspunsbD.Location = new System.Drawing.Point(171, 245);
            this.raspunsbD.Name = "raspunsbD";
            this.raspunsbD.Size = new System.Drawing.Size(57, 24);
            this.raspunsbD.TabIndex = 17;
            this.raspunsbD.TabStop = true;
            this.raspunsbD.Text = "Fals";
            this.raspunsbD.UseVisualStyleBackColor = true;
            this.raspunsbD.Visible = false;
            this.raspunsbD.CheckedChanged += new System.EventHandler(this.raspunsbD_CheckedChanged);
            // 
            // raspunsaD
            // 
            this.raspunsaD.AutoSize = true;
            this.raspunsaD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.raspunsaD.Location = new System.Drawing.Point(171, 219);
            this.raspunsaD.Name = "raspunsaD";
            this.raspunsaD.Size = new System.Drawing.Size(91, 24);
            this.raspunsaD.TabIndex = 16;
            this.raspunsaD.TabStop = true;
            this.raspunsaD.Text = "Adevarat";
            this.raspunsaD.UseVisualStyleBackColor = true;
            this.raspunsaD.Visible = false;
            this.raspunsaD.CheckedChanged += new System.EventHandler(this.raspunsaD_CheckedChanged);
            // 
            // raspunsdC
            // 
            this.raspunsdC.AutoSize = true;
            this.raspunsdC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.raspunsdC.Location = new System.Drawing.Point(171, 298);
            this.raspunsdC.Name = "raspunsdC";
            this.raspunsdC.Size = new System.Drawing.Size(119, 24);
            this.raspunsdC.TabIndex = 15;
            this.raspunsdC.TabStop = true;
            this.raspunsdC.Text = "radioButton4";
            this.raspunsdC.UseVisualStyleBackColor = true;
            this.raspunsdC.Visible = false;
            this.raspunsdC.CheckedChanged += new System.EventHandler(this.raspunsdC_CheckedChanged);
            // 
            // raspunscC
            // 
            this.raspunscC.AutoSize = true;
            this.raspunscC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.raspunscC.Location = new System.Drawing.Point(171, 271);
            this.raspunscC.Name = "raspunscC";
            this.raspunscC.Size = new System.Drawing.Size(119, 24);
            this.raspunscC.TabIndex = 14;
            this.raspunscC.TabStop = true;
            this.raspunscC.Text = "radioButton3";
            this.raspunscC.UseVisualStyleBackColor = true;
            this.raspunscC.Visible = false;
            this.raspunscC.CheckedChanged += new System.EventHandler(this.raspunscC_CheckedChanged);
            // 
            // raspunsbC
            // 
            this.raspunsbC.AutoSize = true;
            this.raspunsbC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.raspunsbC.Location = new System.Drawing.Point(171, 242);
            this.raspunsbC.Name = "raspunsbC";
            this.raspunsbC.Size = new System.Drawing.Size(119, 24);
            this.raspunsbC.TabIndex = 13;
            this.raspunsbC.TabStop = true;
            this.raspunsbC.Text = "radioButton2";
            this.raspunsbC.UseVisualStyleBackColor = true;
            this.raspunsbC.Visible = false;
            this.raspunsbC.CheckedChanged += new System.EventHandler(this.raspunsbC_CheckedChanged);
            // 
            // raspunsaC
            // 
            this.raspunsaC.AutoSize = true;
            this.raspunsaC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.raspunsaC.Location = new System.Drawing.Point(171, 216);
            this.raspunsaC.Name = "raspunsaC";
            this.raspunsaC.Size = new System.Drawing.Size(119, 24);
            this.raspunsaC.TabIndex = 12;
            this.raspunsaC.TabStop = true;
            this.raspunsaC.Text = "radioButton1";
            this.raspunsaC.UseVisualStyleBackColor = true;
            this.raspunsaC.Visible = false;
            this.raspunsaC.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // raspunsdB
            // 
            this.raspunsdB.AutoSize = true;
            this.raspunsdB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.raspunsdB.Location = new System.Drawing.Point(171, 295);
            this.raspunsdB.Name = "raspunsdB";
            this.raspunsdB.Size = new System.Drawing.Size(106, 24);
            this.raspunsdB.TabIndex = 11;
            this.raspunsdB.Text = "checkBox4";
            this.raspunsdB.UseVisualStyleBackColor = true;
            this.raspunsdB.Visible = false;
            this.raspunsdB.CheckedChanged += new System.EventHandler(this.raspunsdB_CheckedChanged);
            // 
            // raspunscB
            // 
            this.raspunscB.AutoSize = true;
            this.raspunscB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.raspunscB.Location = new System.Drawing.Point(171, 269);
            this.raspunscB.Name = "raspunscB";
            this.raspunscB.Size = new System.Drawing.Size(106, 24);
            this.raspunscB.TabIndex = 10;
            this.raspunscB.Text = "checkBox3";
            this.raspunscB.UseVisualStyleBackColor = true;
            this.raspunscB.Visible = false;
            this.raspunscB.CheckedChanged += new System.EventHandler(this.raspunscB_CheckedChanged);
            // 
            // raspunsbB
            // 
            this.raspunsbB.AutoSize = true;
            this.raspunsbB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.raspunsbB.Location = new System.Drawing.Point(171, 243);
            this.raspunsbB.Name = "raspunsbB";
            this.raspunsbB.Size = new System.Drawing.Size(106, 24);
            this.raspunsbB.TabIndex = 9;
            this.raspunsbB.Text = "checkBox2";
            this.raspunsbB.UseVisualStyleBackColor = true;
            this.raspunsbB.Visible = false;
            this.raspunsbB.CheckedChanged += new System.EventHandler(this.raspunsbB_CheckedChanged);
            // 
            // raspunsaB
            // 
            this.raspunsaB.AutoSize = true;
            this.raspunsaB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.raspunsaB.Location = new System.Drawing.Point(171, 217);
            this.raspunsaB.Name = "raspunsaB";
            this.raspunsaB.Size = new System.Drawing.Size(106, 24);
            this.raspunsaB.TabIndex = 8;
            this.raspunsaB.Text = "checkBox1";
            this.raspunsaB.UseVisualStyleBackColor = true;
            this.raspunsaB.Visible = false;
            this.raspunsaB.CheckedChanged += new System.EventHandler(this.raspunsaB_CheckedChanged);
            // 
            // textboxA
            // 
            this.textboxA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textboxA.Location = new System.Drawing.Point(171, 216);
            this.textboxA.Name = "textboxA";
            this.textboxA.Size = new System.Drawing.Size(546, 26);
            this.textboxA.TabIndex = 7;
            this.textboxA.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(171, 56);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(546, 122);
            this.textBox1.TabIndex = 3;
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelA.Location = new System.Drawing.Point(74, 219);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(73, 20);
            this.labelA.TabIndex = 6;
            this.labelA.Text = "Raspuns";
            this.labelA.Visible = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Wheat;
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(649, 408);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 30);
            this.button3.TabIndex = 5;
            this.button3.Text = "Urmatorul";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Wheat;
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(649, 444);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "Raspunde";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Item nr. 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(151, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Punctaj: 1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Beige;
            this.button1.Location = new System.Drawing.Point(8, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start test";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabControl1.Location = new System.Drawing.Point(0, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(798, 528);
            this.tabControl1.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Linen;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button5.Location = new System.Drawing.Point(632, 10);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(158, 28);
            this.button5.TabIndex = 2;
            this.button5.Text = "Parasire aplicatie";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(798, 572);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "eLearning1918_Elev";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RadioButton raspunsbD;
        private System.Windows.Forms.RadioButton raspunsaD;
        private System.Windows.Forms.RadioButton raspunsdC;
        private System.Windows.Forms.RadioButton raspunscC;
        private System.Windows.Forms.RadioButton raspunsbC;
        private System.Windows.Forms.RadioButton raspunsaC;
        private System.Windows.Forms.CheckBox raspunsdB;
        private System.Windows.Forms.CheckBox raspunscB;
        private System.Windows.Forms.CheckBox raspunsbB;
        private System.Windows.Forms.CheckBox raspunsaB;
        private System.Windows.Forms.TextBox textboxA;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}