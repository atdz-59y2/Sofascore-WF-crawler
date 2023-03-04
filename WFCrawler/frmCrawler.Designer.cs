namespace WFCrawler
{
    partial class frmCrawler
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbTeamLink = new System.Windows.Forms.Label();
            this.txtTeamLink = new System.Windows.Forms.TextBox();
            this.btnCrawl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTeamLink
            // 
            this.lbTeamLink.AutoSize = true;
            this.lbTeamLink.Location = new System.Drawing.Point(119, 123);
            this.lbTeamLink.Name = "lbTeamLink";
            this.lbTeamLink.Size = new System.Drawing.Size(57, 15);
            this.lbTeamLink.TabIndex = 0;
            this.lbTeamLink.Text = "Team link";
            // 
            // txtTeamLink
            // 
            this.txtTeamLink.Location = new System.Drawing.Point(224, 115);
            this.txtTeamLink.Name = "txtTeamLink";
            this.txtTeamLink.Size = new System.Drawing.Size(370, 23);
            this.txtTeamLink.TabIndex = 1;
            // 
            // btnCrawl
            // 
            this.btnCrawl.Location = new System.Drawing.Point(635, 115);
            this.btnCrawl.Name = "btnCrawl";
            this.btnCrawl.Size = new System.Drawing.Size(75, 23);
            this.btnCrawl.TabIndex = 2;
            this.btnCrawl.Text = "Crawl";
            this.btnCrawl.UseVisualStyleBackColor = true;
            this.btnCrawl.Click += new System.EventHandler(this.btnCrawl_Click);
            // 
            // frmCrawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCrawl);
            this.Controls.Add(this.txtTeamLink);
            this.Controls.Add(this.lbTeamLink);
            this.Name = "frmCrawler";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbTeamLink;
        private TextBox txtTeamLink;
        private Button btnCrawl;
    }
}