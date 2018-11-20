namespace WindowsFormsApp1
{
    partial class FormAdd
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
            this.junkPathGridView = new System.Windows.Forms.DataGridView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageJunk = new System.Windows.Forms.TabPage();
            this.btnJunkPathCancel = new System.Windows.Forms.Button();
            this.btnAddJunkPath = new System.Windows.Forms.Button();
            this.btnJunkPathOk = new System.Windows.Forms.Button();
            this.btnJunkPathDelete = new System.Windows.Forms.Button();
            this.lbJunkPkgName = new System.Windows.Forms.Label();
            this.tbJunkPkgName = new System.Windows.Forms.TextBox();
            this.tabPageDownload = new System.Windows.Forms.TabPage();
            this.btnDownloadPathCancel = new System.Windows.Forms.Button();
            this.btnAddDownloadPath = new System.Windows.Forms.Button();
            this.btnDownloadPathOk = new System.Windows.Forms.Button();
            this.btnDownloadPathDelete = new System.Windows.Forms.Button();
            this.downloadPathGridView = new System.Windows.Forms.DataGridView();
            this.tabPageResidual = new System.Windows.Forms.TabPage();
            this.btnResidualPathCancel = new System.Windows.Forms.Button();
            this.btnAddResidualPath = new System.Windows.Forms.Button();
            this.btnResidualPathOk = new System.Windows.Forms.Button();
            this.btnResidualPathDelete = new System.Windows.Forms.Button();
            this.lbResidualPkgName = new System.Windows.Forms.Label();
            this.tbResidualPkgName = new System.Windows.Forms.TextBox();
            this.residualPathGridView = new System.Windows.Forms.DataGridView();
            this.lbResidualAppName = new System.Windows.Forms.Label();
            this.tbResidualAppName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.junkPathGridView)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageJunk.SuspendLayout();
            this.tabPageDownload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downloadPathGridView)).BeginInit();
            this.tabPageResidual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.residualPathGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // junkPathGridView
            // 
            this.junkPathGridView.AllowUserToAddRows = false;
            this.junkPathGridView.AllowUserToDeleteRows = false;
            this.junkPathGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.junkPathGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.junkPathGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.junkPathGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.junkPathGridView.Location = new System.Drawing.Point(0, 3);
            this.junkPathGridView.Name = "junkPathGridView";
            this.junkPathGridView.RowTemplate.Height = 27;
            this.junkPathGridView.Size = new System.Drawing.Size(1269, 690);
            this.junkPathGridView.TabIndex = 16;
            this.junkPathGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.AddJunkPath_DataError);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageJunk);
            this.tabControl.Controls.Add(this.tabPageDownload);
            this.tabControl.Controls.Add(this.tabPageResidual);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1277, 815);
            this.tabControl.TabIndex = 23;
            // 
            // tabPageJunk
            // 
            this.tabPageJunk.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageJunk.Controls.Add(this.btnJunkPathCancel);
            this.tabPageJunk.Controls.Add(this.btnAddJunkPath);
            this.tabPageJunk.Controls.Add(this.btnJunkPathOk);
            this.tabPageJunk.Controls.Add(this.btnJunkPathDelete);
            this.tabPageJunk.Controls.Add(this.lbJunkPkgName);
            this.tabPageJunk.Controls.Add(this.tbJunkPkgName);
            this.tabPageJunk.Controls.Add(this.junkPathGridView);
            this.tabPageJunk.Location = new System.Drawing.Point(4, 25);
            this.tabPageJunk.Name = "tabPageJunk";
            this.tabPageJunk.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageJunk.Size = new System.Drawing.Size(1269, 786);
            this.tabPageJunk.TabIndex = 0;
            this.tabPageJunk.Text = "软件清理路径";
            // 
            // btnJunkPathCancel
            // 
            this.btnJunkPathCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJunkPathCancel.AutoSize = true;
            this.btnJunkPathCancel.Location = new System.Drawing.Point(1135, 718);
            this.btnJunkPathCancel.Name = "btnJunkPathCancel";
            this.btnJunkPathCancel.Size = new System.Drawing.Size(97, 40);
            this.btnJunkPathCancel.TabIndex = 24;
            this.btnJunkPathCancel.Text = "取消";
            this.btnJunkPathCancel.UseVisualStyleBackColor = true;
            this.btnJunkPathCancel.Click += new System.EventHandler(this.BtnJunkPathCancel_Click);
            // 
            // btnAddJunkPath
            // 
            this.btnAddJunkPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddJunkPath.Location = new System.Drawing.Point(28, 718);
            this.btnAddJunkPath.Name = "btnAddJunkPath";
            this.btnAddJunkPath.Size = new System.Drawing.Size(97, 40);
            this.btnAddJunkPath.TabIndex = 25;
            this.btnAddJunkPath.Text = "增加一行";
            this.btnAddJunkPath.UseVisualStyleBackColor = true;
            this.btnAddJunkPath.Click += new System.EventHandler(this.BtnAddJunkPath_Click);
            // 
            // btnJunkPathOk
            // 
            this.btnJunkPathOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJunkPathOk.AutoSize = true;
            this.btnJunkPathOk.Location = new System.Drawing.Point(997, 718);
            this.btnJunkPathOk.Name = "btnJunkPathOk";
            this.btnJunkPathOk.Size = new System.Drawing.Size(97, 40);
            this.btnJunkPathOk.TabIndex = 23;
            this.btnJunkPathOk.Text = "确定";
            this.btnJunkPathOk.UseVisualStyleBackColor = true;
            this.btnJunkPathOk.Click += new System.EventHandler(this.BtnJunkPathOk_Click);
            // 
            // btnJunkPathDelete
            // 
            this.btnJunkPathDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnJunkPathDelete.Location = new System.Drawing.Point(166, 718);
            this.btnJunkPathDelete.Name = "btnJunkPathDelete";
            this.btnJunkPathDelete.Size = new System.Drawing.Size(97, 40);
            this.btnJunkPathDelete.TabIndex = 26;
            this.btnJunkPathDelete.Text = "删除选中行";
            this.btnJunkPathDelete.UseVisualStyleBackColor = true;
            this.btnJunkPathDelete.Click += new System.EventHandler(this.BtnJunkPathDelete_Click);
            // 
            // lbJunkPkgName
            // 
            this.lbJunkPkgName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbJunkPkgName.AutoSize = true;
            this.lbJunkPkgName.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbJunkPkgName.Location = new System.Drawing.Point(300, 729);
            this.lbJunkPkgName.Name = "lbJunkPkgName";
            this.lbJunkPkgName.Size = new System.Drawing.Size(95, 19);
            this.lbJunkPkgName.TabIndex = 27;
            this.lbJunkPkgName.Text = "对应包名:";
            // 
            // tbJunkPkgName
            // 
            this.tbJunkPkgName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbJunkPkgName.Location = new System.Drawing.Point(410, 726);
            this.tbJunkPkgName.Name = "tbJunkPkgName";
            this.tbJunkPkgName.Size = new System.Drawing.Size(100, 25);
            this.tbJunkPkgName.TabIndex = 28;
            // 
            // tabPageDownload
            // 
            this.tabPageDownload.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageDownload.Controls.Add(this.btnDownloadPathCancel);
            this.tabPageDownload.Controls.Add(this.btnAddDownloadPath);
            this.tabPageDownload.Controls.Add(this.btnDownloadPathOk);
            this.tabPageDownload.Controls.Add(this.btnDownloadPathDelete);
            this.tabPageDownload.Controls.Add(this.downloadPathGridView);
            this.tabPageDownload.Location = new System.Drawing.Point(4, 25);
            this.tabPageDownload.Name = "tabPageDownload";
            this.tabPageDownload.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDownload.Size = new System.Drawing.Size(1269, 786);
            this.tabPageDownload.TabIndex = 1;
            this.tabPageDownload.Text = "下载路径";
            // 
            // btnDownloadPathCancel
            // 
            this.btnDownloadPathCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadPathCancel.AutoSize = true;
            this.btnDownloadPathCancel.Location = new System.Drawing.Point(1135, 718);
            this.btnDownloadPathCancel.Name = "btnDownloadPathCancel";
            this.btnDownloadPathCancel.Size = new System.Drawing.Size(97, 40);
            this.btnDownloadPathCancel.TabIndex = 34;
            this.btnDownloadPathCancel.Text = "取消";
            this.btnDownloadPathCancel.UseVisualStyleBackColor = true;
            this.btnDownloadPathCancel.Click += new System.EventHandler(this.BtnDownloadPathCancel_Click);
            // 
            // btnAddDownloadPath
            // 
            this.btnAddDownloadPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddDownloadPath.Location = new System.Drawing.Point(28, 718);
            this.btnAddDownloadPath.Name = "btnAddDownloadPath";
            this.btnAddDownloadPath.Size = new System.Drawing.Size(97, 40);
            this.btnAddDownloadPath.TabIndex = 35;
            this.btnAddDownloadPath.Text = "增加一行";
            this.btnAddDownloadPath.UseVisualStyleBackColor = true;
            this.btnAddDownloadPath.Click += new System.EventHandler(this.BtnAddDownloadPath_Click);
            // 
            // btnDownloadPathOk
            // 
            this.btnDownloadPathOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadPathOk.AutoSize = true;
            this.btnDownloadPathOk.Location = new System.Drawing.Point(997, 718);
            this.btnDownloadPathOk.Name = "btnDownloadPathOk";
            this.btnDownloadPathOk.Size = new System.Drawing.Size(97, 40);
            this.btnDownloadPathOk.TabIndex = 33;
            this.btnDownloadPathOk.Text = "确定";
            this.btnDownloadPathOk.UseVisualStyleBackColor = true;
            this.btnDownloadPathOk.Click += new System.EventHandler(this.BtnDownloadPathOk_Click);
            // 
            // btnDownloadPathDelete
            // 
            this.btnDownloadPathDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDownloadPathDelete.Location = new System.Drawing.Point(166, 718);
            this.btnDownloadPathDelete.Name = "btnDownloadPathDelete";
            this.btnDownloadPathDelete.Size = new System.Drawing.Size(97, 40);
            this.btnDownloadPathDelete.TabIndex = 36;
            this.btnDownloadPathDelete.Text = "删除选中行";
            this.btnDownloadPathDelete.UseVisualStyleBackColor = true;
            this.btnDownloadPathDelete.Click += new System.EventHandler(this.BtnDownloadPathDelete_Click);
            // 
            // downloadPathGridView
            // 
            this.downloadPathGridView.AllowUserToAddRows = false;
            this.downloadPathGridView.AllowUserToDeleteRows = false;
            this.downloadPathGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadPathGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.downloadPathGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.downloadPathGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.downloadPathGridView.Location = new System.Drawing.Point(0, 3);
            this.downloadPathGridView.Name = "downloadPathGridView";
            this.downloadPathGridView.RowTemplate.Height = 27;
            this.downloadPathGridView.Size = new System.Drawing.Size(1269, 690);
            this.downloadPathGridView.TabIndex = 25;
            this.downloadPathGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.AddDownloadPath_DataError);
            // 
            // tabPageResidual
            // 
            this.tabPageResidual.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageResidual.Controls.Add(this.lbResidualAppName);
            this.tabPageResidual.Controls.Add(this.tbResidualAppName);
            this.tabPageResidual.Controls.Add(this.btnResidualPathCancel);
            this.tabPageResidual.Controls.Add(this.btnAddResidualPath);
            this.tabPageResidual.Controls.Add(this.btnResidualPathOk);
            this.tabPageResidual.Controls.Add(this.btnResidualPathDelete);
            this.tabPageResidual.Controls.Add(this.lbResidualPkgName);
            this.tabPageResidual.Controls.Add(this.tbResidualPkgName);
            this.tabPageResidual.Controls.Add(this.residualPathGridView);
            this.tabPageResidual.Location = new System.Drawing.Point(4, 25);
            this.tabPageResidual.Name = "tabPageResidual";
            this.tabPageResidual.Size = new System.Drawing.Size(1269, 786);
            this.tabPageResidual.TabIndex = 2;
            this.tabPageResidual.Text = "卸载残留路径";
            // 
            // btnResidualPathCancel
            // 
            this.btnResidualPathCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResidualPathCancel.AutoSize = true;
            this.btnResidualPathCancel.Location = new System.Drawing.Point(1135, 718);
            this.btnResidualPathCancel.Name = "btnResidualPathCancel";
            this.btnResidualPathCancel.Size = new System.Drawing.Size(97, 40);
            this.btnResidualPathCancel.TabIndex = 27;
            this.btnResidualPathCancel.Text = "取消";
            this.btnResidualPathCancel.UseVisualStyleBackColor = true;
            this.btnResidualPathCancel.Click += new System.EventHandler(this.BtnResidualPathCancel_Click);
            // 
            // btnAddResidualPath
            // 
            this.btnAddResidualPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddResidualPath.Location = new System.Drawing.Point(28, 718);
            this.btnAddResidualPath.Name = "btnAddResidualPath";
            this.btnAddResidualPath.Size = new System.Drawing.Size(97, 40);
            this.btnAddResidualPath.TabIndex = 28;
            this.btnAddResidualPath.Text = "增加一行";
            this.btnAddResidualPath.UseVisualStyleBackColor = true;
            this.btnAddResidualPath.Click += new System.EventHandler(this.BtnAddResidualPath_Click);
            // 
            // btnResidualPathOk
            // 
            this.btnResidualPathOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResidualPathOk.AutoSize = true;
            this.btnResidualPathOk.Location = new System.Drawing.Point(997, 718);
            this.btnResidualPathOk.Name = "btnResidualPathOk";
            this.btnResidualPathOk.Size = new System.Drawing.Size(97, 40);
            this.btnResidualPathOk.TabIndex = 26;
            this.btnResidualPathOk.Text = "确定";
            this.btnResidualPathOk.UseVisualStyleBackColor = true;
            this.btnResidualPathOk.Click += new System.EventHandler(this.BtnResidualPathOk_Click);
            // 
            // btnResidualPathDelete
            // 
            this.btnResidualPathDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResidualPathDelete.Location = new System.Drawing.Point(166, 718);
            this.btnResidualPathDelete.Name = "btnResidualPathDelete";
            this.btnResidualPathDelete.Size = new System.Drawing.Size(97, 40);
            this.btnResidualPathDelete.TabIndex = 29;
            this.btnResidualPathDelete.Text = "删除选中行";
            this.btnResidualPathDelete.UseVisualStyleBackColor = true;
            this.btnResidualPathDelete.Click += new System.EventHandler(this.BtnResidualPathDelete_Click);
            // 
            // lbResidualPkgName
            // 
            this.lbResidualPkgName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbResidualPkgName.AutoSize = true;
            this.lbResidualPkgName.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbResidualPkgName.Location = new System.Drawing.Point(300, 729);
            this.lbResidualPkgName.Name = "lbResidualPkgName";
            this.lbResidualPkgName.Size = new System.Drawing.Size(95, 19);
            this.lbResidualPkgName.TabIndex = 30;
            this.lbResidualPkgName.Text = "对应包名:";
            // 
            // tbResidualPkgName
            // 
            this.tbResidualPkgName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbResidualPkgName.Location = new System.Drawing.Point(410, 726);
            this.tbResidualPkgName.Name = "tbResidualPkgName";
            this.tbResidualPkgName.Size = new System.Drawing.Size(100, 25);
            this.tbResidualPkgName.TabIndex = 31;
            // 
            // residualPathGridView
            // 
            this.residualPathGridView.AllowUserToAddRows = false;
            this.residualPathGridView.AllowUserToDeleteRows = false;
            this.residualPathGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.residualPathGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.residualPathGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.residualPathGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.residualPathGridView.Location = new System.Drawing.Point(0, 3);
            this.residualPathGridView.Name = "residualPathGridView";
            this.residualPathGridView.RowTemplate.Height = 27;
            this.residualPathGridView.Size = new System.Drawing.Size(1269, 690);
            this.residualPathGridView.TabIndex = 25;
            this.residualPathGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.AddResidualPath_DataError);
            // 
            // lbResidualAppName
            // 
            this.lbResidualAppName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbResidualAppName.AutoSize = true;
            this.lbResidualAppName.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbResidualAppName.Location = new System.Drawing.Point(565, 729);
            this.lbResidualAppName.Name = "lbResidualAppName";
            this.lbResidualAppName.Size = new System.Drawing.Size(125, 19);
            this.lbResidualAppName.TabIndex = 32;
            this.lbResidualAppName.Text = "对应APP名称:";
            // 
            // tbResidualAppName
            // 
            this.tbResidualAppName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbResidualAppName.Location = new System.Drawing.Point(705, 726);
            this.tbResidualAppName.Name = "tbResidualAppName";
            this.tbResidualAppName.Size = new System.Drawing.Size(100, 25);
            this.tbResidualAppName.TabIndex = 33;
            // 
            // FormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 815);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "路径添加";
            this.Load += new System.EventHandler(this.FormAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.junkPathGridView)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageJunk.ResumeLayout(false);
            this.tabPageJunk.PerformLayout();
            this.tabPageDownload.ResumeLayout(false);
            this.tabPageDownload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downloadPathGridView)).EndInit();
            this.tabPageResidual.ResumeLayout(false);
            this.tabPageResidual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.residualPathGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView junkPathGridView;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageJunk;
        private System.Windows.Forms.TabPage tabPageDownload;
        private System.Windows.Forms.TabPage tabPageResidual;
        private System.Windows.Forms.DataGridView downloadPathGridView;
        private System.Windows.Forms.DataGridView residualPathGridView;
        private System.Windows.Forms.Button btnJunkPathCancel;
        private System.Windows.Forms.Button btnAddJunkPath;
        private System.Windows.Forms.Button btnJunkPathOk;
        private System.Windows.Forms.Button btnJunkPathDelete;
        private System.Windows.Forms.Label lbJunkPkgName;
        private System.Windows.Forms.TextBox tbJunkPkgName;
        private System.Windows.Forms.Button btnResidualPathCancel;
        private System.Windows.Forms.Button btnAddResidualPath;
        private System.Windows.Forms.Button btnResidualPathOk;
        private System.Windows.Forms.Button btnResidualPathDelete;
        private System.Windows.Forms.Label lbResidualPkgName;
        private System.Windows.Forms.TextBox tbResidualPkgName;
        private System.Windows.Forms.Button btnDownloadPathCancel;
        private System.Windows.Forms.Button btnAddDownloadPath;
        private System.Windows.Forms.Button btnDownloadPathOk;
        private System.Windows.Forms.Button btnDownloadPathDelete;
        private System.Windows.Forms.Label lbResidualAppName;
        private System.Windows.Forms.TextBox tbResidualAppName;
    }
}