namespace ASAT2016
{
    partial class MediaMangementLogin
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btSubmit = new System.Windows.Forms.Button();
            this.tbUserAccount = new System.Windows.Forms.TextBox();
            this.tbApiUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Server Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "User Name:";
            // 
            // btSubmit
            // 
            this.btSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSubmit.Location = new System.Drawing.Point(193, 181);
            this.btSubmit.Name = "btSubmit";
            this.btSubmit.Size = new System.Drawing.Size(75, 23);
            this.btSubmit.TabIndex = 7;
            this.btSubmit.Text = "Submit";
            this.btSubmit.UseVisualStyleBackColor = true;
            this.btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
            // 
            // tbUserAccount
            // 
            this.tbUserAccount.Location = new System.Drawing.Point(90, 123);
            this.tbUserAccount.Name = "tbUserAccount";
            this.tbUserAccount.Size = new System.Drawing.Size(178, 20);
            this.tbUserAccount.TabIndex = 6;
            this.tbUserAccount.Text = "yehui";
            // 
            // tbApiUrl
            // 
            this.tbApiUrl.Location = new System.Drawing.Point(90, 58);
            this.tbApiUrl.Name = "tbApiUrl";
            this.tbApiUrl.Size = new System.Drawing.Size(178, 20);
            this.tbApiUrl.TabIndex = 5;
            this.tbApiUrl.Text = "http://prod.x-in-y.com/newcompile/api/read/";
            this.tbApiUrl.TextChanged += new System.EventHandler(this.tbApiUrl_TextChanged);
            // 
            // MediaMangementLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSubmit);
            this.Controls.Add(this.tbUserAccount);
            this.Controls.Add(this.tbApiUrl);
            this.Name = "MediaMangementLogin";
            this.Text = "MediaMangementLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSubmit;
        private System.Windows.Forms.TextBox tbUserAccount;
        private System.Windows.Forms.TextBox tbApiUrl;
    }
}