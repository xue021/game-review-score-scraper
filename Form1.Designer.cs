
using System;
using System.Windows.Forms;

namespace GameReviewScoreScraper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnFetch = new System.Windows.Forms.Button();
            this.txtMainTxt = new System.Windows.Forms.RichTextBox();
            this.numericYear = new System.Windows.Forms.NumericUpDown();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblNumResults = new System.Windows.Forms.Label();
            this.numericNumResults = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblGuide = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumResults)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFetch
            // 
            this.btnFetch.Location = new System.Drawing.Point(12, 86);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(85, 23);
            this.btnFetch.TabIndex = 0;
            this.btnFetch.Text = "Fetch";
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // txtMainTxt
            // 
            this.txtMainTxt.Location = new System.Drawing.Point(12, 144);
            this.txtMainTxt.Name = "txtMainTxt";
            this.txtMainTxt.ReadOnly = true;
            this.txtMainTxt.Size = new System.Drawing.Size(371, 393);
            this.txtMainTxt.TabIndex = 2;
            this.txtMainTxt.Text = "";
            // 
            // numericYear
            // 
            this.numericYear.Location = new System.Drawing.Point(50, 38);
            this.numericYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numericYear.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericYear.Name = "numericYear";
            this.numericYear.Size = new System.Drawing.Size(47, 20);
            this.numericYear.TabIndex = 4;
            this.numericYear.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numericYear.ValueChanged += new System.EventHandler(this.numericYear_ValueChanged);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(12, 40);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(32, 13);
            this.lblYear.TabIndex = 5;
            this.lblYear.Text = "Year:";
            // 
            // lblNumResults
            // 
            this.lblNumResults.AutoSize = true;
            this.lblNumResults.Location = new System.Drawing.Point(12, 60);
            this.lblNumResults.Name = "lblNumResults";
            this.lblNumResults.Size = new System.Drawing.Size(55, 13);
            this.lblNumResults.TabIndex = 6;
            this.lblNumResults.Text = "# Results:";
            // 
            // numericNumResults
            // 
            this.numericNumResults.Location = new System.Drawing.Point(63, 60);
            this.numericNumResults.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericNumResults.Name = "numericNumResults";
            this.numericNumResults.Size = new System.Drawing.Size(34, 20);
            this.numericNumResults.TabIndex = 7;
            this.numericNumResults.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericNumResults.ValueChanged += new System.EventHandler(this.numericNumResults_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 456);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 9;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 115);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(371, 23);
            this.progressBar.TabIndex = 17;
            this.progressBar.Visible = false;
            // 
            // lblGuide
            // 
            this.lblGuide.AutoSize = true;
            this.lblGuide.Location = new System.Drawing.Point(12, 9);
            this.lblGuide.Name = "lblGuide";
            this.lblGuide.Size = new System.Drawing.Size(273, 13);
            this.lblGuide.TabIndex = 18;
            this.lblGuide.Text = "Scrape the web for game review scores for a given year.\r\n";
            
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(395, 549);
            this.Controls.Add(this.lblGuide);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericNumResults);
            this.Controls.Add(this.lblNumResults);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.numericYear);
            this.Controls.Add(this.txtMainTxt);
            this.Controls.Add(this.btnFetch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Game Score Scraper";
            
            ((System.ComponentModel.ISupportInitialize)(this.numericYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.RichTextBox txtMainTxt;
        private System.Windows.Forms.NumericUpDown numericYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblNumResults;
        private System.Windows.Forms.NumericUpDown numericNumResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblGuide;
    }
}

