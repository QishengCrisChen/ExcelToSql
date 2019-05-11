namespace openExcelToSql
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialogSource = new System.Windows.Forms.OpenFileDialog();
            this.buttonopen = new System.Windows.Forms.Button();
            this.ctlPath = new System.Windows.Forms.ComboBox();
            this.gridSource = new System.Windows.Forms.DataGridView();
            this.tb = new System.Windows.Forms.TextBox();
            this.btnsr = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridSource)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialogSource
            // 
            this.openFileDialogSource.FileName = "openFileDialog1";
            // 
            // buttonopen
            // 
            this.buttonopen.Location = new System.Drawing.Point(308, 26);
            this.buttonopen.Name = "buttonopen";
            this.buttonopen.Size = new System.Drawing.Size(75, 23);
            this.buttonopen.TabIndex = 0;
            this.buttonopen.Text = "Open";
            this.buttonopen.UseVisualStyleBackColor = true;
            this.buttonopen.Click += new System.EventHandler(this.buttonopen_Click);
            // 
            // ctlPath
            // 
            this.ctlPath.FormattingEnabled = true;
            this.ctlPath.Location = new System.Drawing.Point(12, 26);
            this.ctlPath.Name = "ctlPath";
            this.ctlPath.Size = new System.Drawing.Size(277, 20);
            this.ctlPath.TabIndex = 1;
            // 
            // gridSource
            // 
            this.gridSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSource.Location = new System.Drawing.Point(12, 52);
            this.gridSource.Name = "gridSource";
            this.gridSource.RowTemplate.Height = 23;
            this.gridSource.Size = new System.Drawing.Size(711, 481);
            this.gridSource.TabIndex = 3;
            // 
            // tb
            // 
            this.tb.Location = new System.Drawing.Point(580, 26);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(121, 21);
            this.tb.TabIndex = 4;
            // 
            // btnsr
            // 
            this.btnsr.Location = new System.Drawing.Point(499, 26);
            this.btnsr.Name = "btnsr";
            this.btnsr.Size = new System.Drawing.Size(75, 23);
            this.btnsr.TabIndex = 5;
            this.btnsr.Text = "收入导入";
            this.btnsr.UseVisualStyleBackColor = true;
            this.btnsr.Click += new System.EventHandler(this.btnsr_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 512);
            this.Controls.Add(this.btnsr);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.gridSource);
            this.Controls.Add(this.ctlPath);
            this.Controls.Add(this.buttonopen);
            this.Name = "MainForm";
            this.Text = "Job Sales Import";
            ((System.ComponentModel.ISupportInitialize)(this.gridSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogSource;
        private System.Windows.Forms.Button buttonopen;
        private System.Windows.Forms.ComboBox ctlPath;
        private System.Windows.Forms.DataGridView gridSource;
        private System.Windows.Forms.TextBox tb;
        private System.Windows.Forms.Button btnsr;
    }
}

