namespace Log4NetConfigTool
{
    partial class Mainform
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupdbstring = new System.Windows.Forms.GroupBox();
            this.btnSample2 = new System.Windows.Forms.Button();
            this.txtDbstring2 = new System.Windows.Forms.TextBox();
            this.loggerView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnGetSimple = new System.Windows.Forms.Button();
            this.txtDBstring = new System.Windows.Forms.TextBox();
            this.lbldbstring = new System.Windows.Forms.Label();
            this.lblTip = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.chk_supportDb = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_supportFatal = new System.Windows.Forms.CheckBox();
            this.chk_supportError = new System.Windows.Forms.CheckBox();
            this.chk_supportWarn = new System.Windows.Forms.CheckBox();
            this.chk_supportDebug = new System.Windows.Forms.CheckBox();
            this.chk_supportInfo = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLoggerName = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfigPath = new System.Windows.Forms.TextBox();
            this.btn_GetPath = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLoggerFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectLoggerFilePath = new System.Windows.Forms.Button();
            this.lblconfigpath = new System.Windows.Forms.Label();
            this.lblConfigCodefile = new System.Windows.Forms.Label();
            this.lblSavepath = new System.Windows.Forms.Label();
            this.txtSaveDir = new System.Windows.Forms.TextBox();
            this.btnSavedir = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupdbstring.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loggerView)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 110);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1047, 548);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupdbstring);
            this.tabPage1.Controls.Add(this.loggerView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1039, 525);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "当前配置项目";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupdbstring
            // 
            this.groupdbstring.BackColor = System.Drawing.Color.PeachPuff;
            this.groupdbstring.Controls.Add(this.btnSample2);
            this.groupdbstring.Controls.Add(this.txtDbstring2);
            this.groupdbstring.Location = new System.Drawing.Point(203, 6);
            this.groupdbstring.Name = "groupdbstring";
            this.groupdbstring.Size = new System.Drawing.Size(831, 47);
            this.groupdbstring.TabIndex = 1;
            this.groupdbstring.TabStop = false;
            this.groupdbstring.Text = "配置数据库连接串";
            // 
            // btnSample2
            // 
            this.btnSample2.Location = new System.Drawing.Point(687, 21);
            this.btnSample2.Name = "btnSample2";
            this.btnSample2.Size = new System.Drawing.Size(75, 23);
            this.btnSample2.TabIndex = 1;
            this.btnSample2.Text = "例子";
            this.btnSample2.UseVisualStyleBackColor = true;
            this.btnSample2.Click += new System.EventHandler(this.btnSample2_Click);
            // 
            // txtDbstring2
            // 
            this.txtDbstring2.Location = new System.Drawing.Point(6, 20);
            this.txtDbstring2.Name = "txtDbstring2";
            this.txtDbstring2.Size = new System.Drawing.Size(675, 21);
            this.txtDbstring2.TabIndex = 0;
            // 
            // loggerView
            // 
            this.loggerView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.loggerView.Location = new System.Drawing.Point(0, 59);
            this.loggerView.Name = "loggerView";
            this.loggerView.RowTemplate.Height = 23;
            this.loggerView.Size = new System.Drawing.Size(1043, 463);
            this.loggerView.TabIndex = 0;
            this.loggerView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.loggerView_CellClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSavedir);
            this.tabPage2.Controls.Add(this.txtSaveDir);
            this.tabPage2.Controls.Add(this.lblSavepath);
            this.tabPage2.Controls.Add(this.btnGetSimple);
            this.tabPage2.Controls.Add(this.txtDBstring);
            this.tabPage2.Controls.Add(this.lbldbstring);
            this.tabPage2.Controls.Add(this.lblTip);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.chk_supportDb);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtLoggerName);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1039, 522);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "添加配置项目";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnGetSimple
            // 
            this.btnGetSimple.Location = new System.Drawing.Point(898, 229);
            this.btnGetSimple.Name = "btnGetSimple";
            this.btnGetSimple.Size = new System.Drawing.Size(52, 21);
            this.btnGetSimple.TabIndex = 11;
            this.btnGetSimple.Text = "例子";
            this.btnGetSimple.UseVisualStyleBackColor = true;
            this.btnGetSimple.Visible = false;
            this.btnGetSimple.Click += new System.EventHandler(this.btnGetSimple_Click);
            // 
            // txtDBstring
            // 
            this.txtDBstring.Location = new System.Drawing.Point(119, 229);
            this.txtDBstring.Name = "txtDBstring";
            this.txtDBstring.Size = new System.Drawing.Size(751, 21);
            this.txtDBstring.TabIndex = 10;
            // 
            // lbldbstring
            // 
            this.lbldbstring.AutoSize = true;
            this.lbldbstring.Location = new System.Drawing.Point(24, 235);
            this.lbldbstring.Name = "lbldbstring";
            this.lbldbstring.Size = new System.Drawing.Size(89, 12);
            this.lbldbstring.TabIndex = 7;
            this.lbldbstring.Text = "数据库连接串：";
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(344, 43);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(0, 12);
            this.lblTip.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(602, 276);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(106, 35);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "是否支持保存到数据库：";
            // 
            // chk_supportDb
            // 
            this.chk_supportDb.AutoSize = true;
            this.chk_supportDb.Location = new System.Drawing.Point(167, 204);
            this.chk_supportDb.Name = "chk_supportDb";
            this.chk_supportDb.Size = new System.Drawing.Size(15, 14);
            this.chk_supportDb.TabIndex = 3;
            this.chk_supportDb.UseVisualStyleBackColor = true;
            this.chk_supportDb.CheckedChanged += new System.EventHandler(this.chk_supportDb_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_supportFatal);
            this.groupBox1.Controls.Add(this.chk_supportError);
            this.groupBox1.Controls.Add(this.chk_supportWarn);
            this.groupBox1.Controls.Add(this.chk_supportDebug);
            this.groupBox1.Controls.Add(this.chk_supportInfo);
            this.groupBox1.Location = new System.Drawing.Point(26, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(682, 74);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "本地文件支持Log类型";
            // 
            // chk_supportFatal
            // 
            this.chk_supportFatal.AutoSize = true;
            this.chk_supportFatal.Location = new System.Drawing.Point(418, 40);
            this.chk_supportFatal.Name = "chk_supportFatal";
            this.chk_supportFatal.Size = new System.Drawing.Size(54, 16);
            this.chk_supportFatal.TabIndex = 4;
            this.chk_supportFatal.Text = "Fatal";
            this.chk_supportFatal.UseVisualStyleBackColor = true;
            // 
            // chk_supportError
            // 
            this.chk_supportError.AutoSize = true;
            this.chk_supportError.Location = new System.Drawing.Point(324, 40);
            this.chk_supportError.Name = "chk_supportError";
            this.chk_supportError.Size = new System.Drawing.Size(54, 16);
            this.chk_supportError.TabIndex = 3;
            this.chk_supportError.Text = "Error";
            this.chk_supportError.UseVisualStyleBackColor = true;
            // 
            // chk_supportWarn
            // 
            this.chk_supportWarn.AutoSize = true;
            this.chk_supportWarn.Location = new System.Drawing.Point(221, 40);
            this.chk_supportWarn.Name = "chk_supportWarn";
            this.chk_supportWarn.Size = new System.Drawing.Size(48, 16);
            this.chk_supportWarn.TabIndex = 2;
            this.chk_supportWarn.Text = "Warn";
            this.chk_supportWarn.UseVisualStyleBackColor = true;
            // 
            // chk_supportDebug
            // 
            this.chk_supportDebug.AutoSize = true;
            this.chk_supportDebug.Location = new System.Drawing.Point(119, 40);
            this.chk_supportDebug.Name = "chk_supportDebug";
            this.chk_supportDebug.Size = new System.Drawing.Size(54, 16);
            this.chk_supportDebug.TabIndex = 1;
            this.chk_supportDebug.Text = "Debug";
            this.chk_supportDebug.UseVisualStyleBackColor = true;
            // 
            // chk_supportInfo
            // 
            this.chk_supportInfo.AutoSize = true;
            this.chk_supportInfo.Location = new System.Drawing.Point(22, 40);
            this.chk_supportInfo.Name = "chk_supportInfo";
            this.chk_supportInfo.Size = new System.Drawing.Size(48, 16);
            this.chk_supportInfo.TabIndex = 0;
            this.chk_supportInfo.Text = "Info";
            this.chk_supportInfo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Logger名称：";
            // 
            // txtLoggerName
            // 
            this.txtLoggerName.Location = new System.Drawing.Point(120, 40);
            this.txtLoggerName.Name = "txtLoggerName";
            this.txtLoggerName.Size = new System.Drawing.Size(218, 21);
            this.txtLoggerName.TabIndex = 0;
            this.txtLoggerName.TextChanged += new System.EventHandler(this.txtLoggerName_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1062, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "配置文件路径:";
            // 
            // txtConfigPath
            // 
            this.txtConfigPath.Location = new System.Drawing.Point(97, 31);
            this.txtConfigPath.Name = "txtConfigPath";
            this.txtConfigPath.Size = new System.Drawing.Size(589, 21);
            this.txtConfigPath.TabIndex = 3;
            // 
            // btn_GetPath
            // 
            this.btn_GetPath.Location = new System.Drawing.Point(692, 28);
            this.btn_GetPath.Name = "btn_GetPath";
            this.btn_GetPath.Size = new System.Drawing.Size(75, 23);
            this.btn_GetPath.TabIndex = 4;
            this.btn_GetPath.Text = "浏览...";
            this.btn_GetPath.UseVisualStyleBackColor = true;
            this.btn_GetPath.Click += new System.EventHandler(this.btn_GetPath_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Logger.cs路径:";
            // 
            // txtLoggerFilePath
            // 
            this.txtLoggerFilePath.Location = new System.Drawing.Point(97, 63);
            this.txtLoggerFilePath.Name = "txtLoggerFilePath";
            this.txtLoggerFilePath.Size = new System.Drawing.Size(589, 21);
            this.txtLoggerFilePath.TabIndex = 6;
            // 
            // btnSelectLoggerFilePath
            // 
            this.btnSelectLoggerFilePath.Location = new System.Drawing.Point(692, 61);
            this.btnSelectLoggerFilePath.Name = "btnSelectLoggerFilePath";
            this.btnSelectLoggerFilePath.Size = new System.Drawing.Size(75, 23);
            this.btnSelectLoggerFilePath.TabIndex = 7;
            this.btnSelectLoggerFilePath.Text = "浏览...";
            this.btnSelectLoggerFilePath.UseVisualStyleBackColor = true;
            this.btnSelectLoggerFilePath.Click += new System.EventHandler(this.btnSelectLoggerFilePath_Click);
            // 
            // lblconfigpath
            // 
            this.lblconfigpath.AutoSize = true;
            this.lblconfigpath.Location = new System.Drawing.Point(792, 34);
            this.lblconfigpath.Name = "lblconfigpath";
            this.lblconfigpath.Size = new System.Drawing.Size(0, 12);
            this.lblconfigpath.TabIndex = 8;
            // 
            // lblConfigCodefile
            // 
            this.lblConfigCodefile.AutoSize = true;
            this.lblConfigCodefile.Location = new System.Drawing.Point(792, 66);
            this.lblConfigCodefile.Name = "lblConfigCodefile";
            this.lblConfigCodefile.Size = new System.Drawing.Size(0, 12);
            this.lblConfigCodefile.TabIndex = 9;
            // 
            // lblSavepath
            // 
            this.lblSavepath.AutoSize = true;
            this.lblSavepath.Location = new System.Drawing.Point(24, 78);
            this.lblSavepath.Name = "lblSavepath";
            this.lblSavepath.Size = new System.Drawing.Size(89, 12);
            this.lblSavepath.TabIndex = 12;
            this.lblSavepath.Text = "日志保存路径：";
            // 
            // txtSaveDir
            // 
            this.txtSaveDir.Location = new System.Drawing.Point(119, 69);
            this.txtSaveDir.Name = "txtSaveDir";
            this.txtSaveDir.Size = new System.Drawing.Size(589, 21);
            this.txtSaveDir.TabIndex = 13;
            // 
            // btnSavedir
            // 
            this.btnSavedir.Location = new System.Drawing.Point(714, 67);
            this.btnSavedir.Name = "btnSavedir";
            this.btnSavedir.Size = new System.Drawing.Size(75, 23);
            this.btnSavedir.TabIndex = 10;
            this.btnSavedir.Text = "浏览...";
            this.btnSavedir.UseVisualStyleBackColor = true;
            this.btnSavedir.Click += new System.EventHandler(this.btnSavedir_Click);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 659);
            this.Controls.Add(this.lblConfigCodefile);
            this.Controls.Add(this.lblconfigpath);
            this.Controls.Add(this.btnSelectLoggerFilePath);
            this.Controls.Add(this.txtLoggerFilePath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_GetPath);
            this.Controls.Add(this.txtConfigPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Mainform";
            this.Text = "Log4Net配置工具";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupdbstring.ResumeLayout(false);
            this.groupdbstring.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loggerView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConfigPath;
        private System.Windows.Forms.Button btn_GetPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chk_supportFatal;
        private System.Windows.Forms.CheckBox chk_supportError;
        private System.Windows.Forms.CheckBox chk_supportWarn;
        private System.Windows.Forms.CheckBox chk_supportDebug;
        private System.Windows.Forms.CheckBox chk_supportInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLoggerName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chk_supportDb;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLoggerFilePath;
        private System.Windows.Forms.Button btnSelectLoggerFilePath;
        private System.Windows.Forms.DataGridView loggerView;
        private System.Windows.Forms.Label lblconfigpath;
        private System.Windows.Forms.Label lblConfigCodefile;
        private System.Windows.Forms.TextBox txtDBstring;
        private System.Windows.Forms.Label lbldbstring;
        private System.Windows.Forms.Button btnGetSimple;
        private System.Windows.Forms.GroupBox groupdbstring;
        private System.Windows.Forms.Button btnSample2;
        private System.Windows.Forms.TextBox txtDbstring2;
        private System.Windows.Forms.Button btnSavedir;
        private System.Windows.Forms.TextBox txtSaveDir;
        private System.Windows.Forms.Label lblSavepath;
    }
}

