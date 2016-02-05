namespace ASAT2016
{
    partial class MediaManagement
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lbSelectedItem = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btUplodFile = new System.Windows.Forms.Button();
            this.btUpDeselectAll = new System.Windows.Forms.Button();
            this.btUpSelectAll = new System.Windows.Forms.Button();
            this.dgvMediaUploadList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DirectoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbSelectedLesson = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lbLoginInfo = new System.Windows.Forms.Label();
            this.tpMediaUpload = new System.Windows.Forms.TabPage();
            this.dgvMediaList = new System.Windows.Forms.DataGridView();
            this.DocID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SynSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SynProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DownPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SavePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Async = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReviseTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectItems = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btDownload = new System.Windows.Forms.Button();
            this.btDeselectAll = new System.Windows.Forms.Button();
            this.btSelectAll = new System.Windows.Forms.Button();
            this.fbdGetSavePath = new System.Windows.Forms.FolderBrowserDialog();
            this.tpMediaDownload = new System.Windows.Forms.TabPage();
            this.tcMediaListPage = new System.Windows.Forms.TabControl();
            this.tvw_display = new System.Windows.Forms.TreeView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMediaUploadList)).BeginInit();
            this.tpMediaUpload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMediaList)).BeginInit();
            this.tpMediaDownload.SuspendLayout();
            this.tcMediaListPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbSelectedItem
            // 
            this.lbSelectedItem.AutoSize = true;
            this.lbSelectedItem.Location = new System.Drawing.Point(6, 11);
            this.lbSelectedItem.Name = "lbSelectedItem";
            this.lbSelectedItem.Size = new System.Drawing.Size(146, 13);
            this.lbSelectedItem.TabIndex = 6;
            this.lbSelectedItem.Text = "Please Select Upload Lesson";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(349, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Open Local Media Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btUplodFile
            // 
            this.btUplodFile.Location = new System.Drawing.Point(553, 391);
            this.btUplodFile.Name = "btUplodFile";
            this.btUplodFile.Size = new System.Drawing.Size(171, 23);
            this.btUplodFile.TabIndex = 4;
            this.btUplodFile.Text = "Start Uplod Media to Server";
            this.btUplodFile.UseVisualStyleBackColor = true;
            this.btUplodFile.Click += new System.EventHandler(this.btUplodFile_Click);
            // 
            // btUpDeselectAll
            // 
            this.btUpDeselectAll.Location = new System.Drawing.Point(649, 6);
            this.btUpDeselectAll.Name = "btUpDeselectAll";
            this.btUpDeselectAll.Size = new System.Drawing.Size(75, 23);
            this.btUpDeselectAll.TabIndex = 3;
            this.btUpDeselectAll.Text = "Deselect All";
            this.btUpDeselectAll.UseVisualStyleBackColor = true;
            this.btUpDeselectAll.Click += new System.EventHandler(this.btUpDeselectAll_Click);
            // 
            // btUpSelectAll
            // 
            this.btUpSelectAll.Location = new System.Drawing.Point(553, 6);
            this.btUpSelectAll.Name = "btUpSelectAll";
            this.btUpSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btUpSelectAll.TabIndex = 2;
            this.btUpSelectAll.Text = "Select All";
            this.btUpSelectAll.UseVisualStyleBackColor = true;
            this.btUpSelectAll.Click += new System.EventHandler(this.btUpSelectAll_Click);
            // 
            // dgvMediaUploadList
            // 
            this.dgvMediaUploadList.AllowUserToAddRows = false;
            this.dgvMediaUploadList.AllowUserToDeleteRows = false;
            this.dgvMediaUploadList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMediaUploadList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewCheckBoxColumn1,
            this.DirectoryName});
            this.dgvMediaUploadList.Location = new System.Drawing.Point(0, 36);
            this.dgvMediaUploadList.Name = "dgvMediaUploadList";
            this.dgvMediaUploadList.RowHeadersVisible = false;
            this.dgvMediaUploadList.Size = new System.Drawing.Size(727, 341);
            this.dgvMediaUploadList.TabIndex = 1;
            this.dgvMediaUploadList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMediaUploadList_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "File Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "FileSize";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Revise Time";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Process";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "SelectItems";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // DirectoryName
            // 
            this.DirectoryName.HeaderText = "Directory Name";
            this.DirectoryName.Name = "DirectoryName";
            // 
            // lbSelectedLesson
            // 
            this.lbSelectedLesson.AutoSize = true;
            this.lbSelectedLesson.Location = new System.Drawing.Point(6, 11);
            this.lbSelectedLesson.Name = "lbSelectedLesson";
            this.lbSelectedLesson.Size = new System.Drawing.Size(160, 13);
            this.lbSelectedLesson.TabIndex = 7;
            this.lbSelectedLesson.Text = "Please Select Download Lesson";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lbLoginInfo
            // 
            this.lbLoginInfo.AutoSize = true;
            this.lbLoginInfo.Location = new System.Drawing.Point(239, 15);
            this.lbLoginInfo.Name = "lbLoginInfo";
            this.lbLoginInfo.Size = new System.Drawing.Size(35, 13);
            this.lbLoginInfo.TabIndex = 9;
            this.lbLoginInfo.Text = "label1";
            // 
            // tpMediaUpload
            // 
            this.tpMediaUpload.Controls.Add(this.lbSelectedLesson);
            this.tpMediaUpload.Controls.Add(this.dgvMediaList);
            this.tpMediaUpload.Controls.Add(this.btDownload);
            this.tpMediaUpload.Controls.Add(this.btDeselectAll);
            this.tpMediaUpload.Controls.Add(this.btSelectAll);
            this.tpMediaUpload.Location = new System.Drawing.Point(4, 22);
            this.tpMediaUpload.Name = "tpMediaUpload";
            this.tpMediaUpload.Padding = new System.Windows.Forms.Padding(3);
            this.tpMediaUpload.Size = new System.Drawing.Size(730, 420);
            this.tpMediaUpload.TabIndex = 0;
            this.tpMediaUpload.Text = "Media Download";
            this.tpMediaUpload.UseVisualStyleBackColor = true;
            // 
            // dgvMediaList
            // 
            this.dgvMediaList.AllowUserToAddRows = false;
            this.dgvMediaList.AllowUserToDeleteRows = false;
            this.dgvMediaList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMediaList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DocID,
            this.FileName,
            this.FileSize,
            this.SynSpeed,
            this.SynProgress,
            this.DownPath,
            this.SavePath,
            this.Async,
            this.ReviseTime,
            this.SelectItems});
            this.dgvMediaList.Location = new System.Drawing.Point(0, 36);
            this.dgvMediaList.Name = "dgvMediaList";
            this.dgvMediaList.RowHeadersVisible = false;
            this.dgvMediaList.Size = new System.Drawing.Size(727, 341);
            this.dgvMediaList.TabIndex = 0;
            this.dgvMediaList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMediaList_CellContentClick);
            // 
            // DocID
            // 
            this.DocID.HeaderText = "id";
            this.DocID.Name = "DocID";
            this.DocID.Visible = false;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            this.FileName.Width = 200;
            // 
            // FileSize
            // 
            this.FileSize.HeaderText = "FileSize";
            this.FileSize.Name = "FileSize";
            // 
            // SynSpeed
            // 
            this.SynSpeed.HeaderText = "Speed";
            this.SynSpeed.Name = "SynSpeed";
            this.SynSpeed.Visible = false;
            // 
            // SynProgress
            // 
            this.SynProgress.HeaderText = "Process";
            this.SynProgress.Name = "SynProgress";
            // 
            // DownPath
            // 
            this.DownPath.HeaderText = "DownPath";
            this.DownPath.Name = "DownPath";
            this.DownPath.Visible = false;
            // 
            // SavePath
            // 
            this.SavePath.HeaderText = "SavePath";
            this.SavePath.Name = "SavePath";
            // 
            // Async
            // 
            this.Async.HeaderText = "Async";
            this.Async.Name = "Async";
            this.Async.Visible = false;
            // 
            // ReviseTime
            // 
            this.ReviseTime.HeaderText = "Revise Time";
            this.ReviseTime.Name = "ReviseTime";
            // 
            // SelectItems
            // 
            this.SelectItems.HeaderText = "SelectItems";
            this.SelectItems.Name = "SelectItems";
            // 
            // btDownload
            // 
            this.btDownload.Location = new System.Drawing.Point(609, 391);
            this.btDownload.Name = "btDownload";
            this.btDownload.Size = new System.Drawing.Size(115, 23);
            this.btDownload.TabIndex = 3;
            this.btDownload.Text = "Start Download";
            this.btDownload.UseVisualStyleBackColor = true;
            this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
            // 
            // btDeselectAll
            // 
            this.btDeselectAll.Location = new System.Drawing.Point(649, 6);
            this.btDeselectAll.Name = "btDeselectAll";
            this.btDeselectAll.Size = new System.Drawing.Size(75, 23);
            this.btDeselectAll.TabIndex = 2;
            this.btDeselectAll.Text = "Deselect All";
            this.btDeselectAll.UseVisualStyleBackColor = true;
            this.btDeselectAll.Click += new System.EventHandler(this.btDeselectAll_Click);
            // 
            // btSelectAll
            // 
            this.btSelectAll.Location = new System.Drawing.Point(553, 6);
            this.btSelectAll.Name = "btSelectAll";
            this.btSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btSelectAll.TabIndex = 1;
            this.btSelectAll.Text = "Select All";
            this.btSelectAll.UseVisualStyleBackColor = true;
            this.btSelectAll.Click += new System.EventHandler(this.btSelectAll_Click);
            // 
            // tpMediaDownload
            // 
            this.tpMediaDownload.Controls.Add(this.lbSelectedItem);
            this.tpMediaDownload.Controls.Add(this.button1);
            this.tpMediaDownload.Controls.Add(this.btUplodFile);
            this.tpMediaDownload.Controls.Add(this.btUpDeselectAll);
            this.tpMediaDownload.Controls.Add(this.btUpSelectAll);
            this.tpMediaDownload.Controls.Add(this.dgvMediaUploadList);
            this.tpMediaDownload.Location = new System.Drawing.Point(4, 22);
            this.tpMediaDownload.Name = "tpMediaDownload";
            this.tpMediaDownload.Padding = new System.Windows.Forms.Padding(3);
            this.tpMediaDownload.Size = new System.Drawing.Size(730, 420);
            this.tpMediaDownload.TabIndex = 1;
            this.tpMediaDownload.Text = "Media Upload";
            this.tpMediaDownload.UseVisualStyleBackColor = true;
            // 
            // tcMediaListPage
            // 
            this.tcMediaListPage.Controls.Add(this.tpMediaUpload);
            this.tcMediaListPage.Controls.Add(this.tpMediaDownload);
            this.tcMediaListPage.Location = new System.Drawing.Point(238, 36);
            this.tcMediaListPage.Name = "tcMediaListPage";
            this.tcMediaListPage.SelectedIndex = 0;
            this.tcMediaListPage.Size = new System.Drawing.Size(738, 446);
            this.tcMediaListPage.TabIndex = 8;
            this.tcMediaListPage.Tag = "";
            // 
            // tvw_display
            // 
            this.tvw_display.Location = new System.Drawing.Point(3, 36);
            this.tvw_display.Name = "tvw_display";
            this.tvw_display.Size = new System.Drawing.Size(229, 446);
            this.tvw_display.TabIndex = 7;
            this.tvw_display.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvw_display_AfterSelect);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // MediaManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 486);
            this.Controls.Add(this.lbLoginInfo);
            this.Controls.Add(this.tcMediaListPage);
            this.Controls.Add(this.tvw_display);
            this.Name = "MediaManagement";
            this.Text = "MediaManagement";
            this.Load += new System.EventHandler(this.MediaManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMediaUploadList)).EndInit();
            this.tpMediaUpload.ResumeLayout(false);
            this.tpMediaUpload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMediaList)).EndInit();
            this.tpMediaDownload.ResumeLayout(false);
            this.tpMediaDownload.PerformLayout();
            this.tcMediaListPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lbSelectedItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btUplodFile;
        private System.Windows.Forms.Button btUpDeselectAll;
        private System.Windows.Forms.Button btUpSelectAll;
        private System.Windows.Forms.DataGridView dgvMediaUploadList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DirectoryName;
        private System.Windows.Forms.Label lbSelectedLesson;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lbLoginInfo;
        private System.Windows.Forms.TabPage tpMediaUpload;
        private System.Windows.Forms.DataGridView dgvMediaList;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn SynSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn SynProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn DownPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn SavePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Async;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReviseTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectItems;
        private System.Windows.Forms.Button btDownload;
        private System.Windows.Forms.Button btDeselectAll;
        private System.Windows.Forms.Button btSelectAll;
        private System.Windows.Forms.FolderBrowserDialog fbdGetSavePath;
        private System.Windows.Forms.TabPage tpMediaDownload;
        private System.Windows.Forms.TabControl tcMediaListPage;
        private System.Windows.Forms.TreeView tvw_display;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}