namespace RegexSearch
{
    partial class Search
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
            this.rtxtText = new System.Windows.Forms.RichTextBox();
            this.lstMatched = new System.Windows.Forms.ListBox();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.lblMatched = new System.Windows.Forms.Label();
            this.lblPattern = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtxtText
            // 
            this.rtxtText.Location = new System.Drawing.Point(24, 35);
            this.rtxtText.Name = "rtxtText";
            this.rtxtText.Size = new System.Drawing.Size(292, 186);
            this.rtxtText.TabIndex = 0;
            this.rtxtText.Text = "";
            // 
            // lstMatched
            // 
            this.lstMatched.FormattingEnabled = true;
            this.lstMatched.Location = new System.Drawing.Point(346, 35);
            this.lstMatched.Name = "lstMatched";
            this.lstMatched.Size = new System.Drawing.Size(239, 186);
            this.lstMatched.TabIndex = 1;
            // 
            // txtPattern
            // 
            this.txtPattern.Location = new System.Drawing.Point(71, 232);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(245, 20);
            this.txtPattern.TabIndex = 2;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(21, 12);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(28, 13);
            this.lblText.TabIndex = 3;
            this.lblText.Text = "Text";
            // 
            // lblMatched
            // 
            this.lblMatched.AutoSize = true;
            this.lblMatched.Location = new System.Drawing.Point(343, 12);
            this.lblMatched.Name = "lblMatched";
            this.lblMatched.Size = new System.Drawing.Size(49, 13);
            this.lblMatched.TabIndex = 4;
            this.lblMatched.Text = "Matched";
            // 
            // lblPattern
            // 
            this.lblPattern.AutoSize = true;
            this.lblPattern.Location = new System.Drawing.Point(21, 235);
            this.lblPattern.Name = "lblPattern";
            this.lblPattern.Size = new System.Drawing.Size(44, 13);
            this.lblPattern.TabIndex = 5;
            this.lblPattern.Text = "Pattern:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(346, 232);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 270);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblPattern);
            this.Controls.Add(this.lblMatched);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.txtPattern);
            this.Controls.Add(this.lstMatched);
            this.Controls.Add(this.rtxtText);
            this.Name = "Search";
            this.Text = "Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtText;
        private System.Windows.Forms.ListBox lstMatched;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblMatched;
        private System.Windows.Forms.Label lblPattern;
        private System.Windows.Forms.Button btnSearch;
    }
}

