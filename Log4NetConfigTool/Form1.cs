/********************************************************
 * Encapsulation of log4net for programer
 * Written by Alex Yu (yubhbh@gmail.com)
 * 
 * Released to the public domain, use at your own risk!
 ********************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;

namespace Log4NetConfigTool
{
    public partial class Mainform : Form
    {
        string sample = "Data Source=172.16.132.50;Initial Catalog=数据库名;Persist Security Info=True;User ID=账号;Password=密码";
        public Mainform()
        {
            InitializeComponent();

            getConfigXml();

        }

        private void bindLoggerGridView()
        {
                var chkMsg = ConfigHandler.CheckConfig(this.txtConfigPath.Text.Trim(), this.txtLoggerFilePath.Text.Trim());
                if (chkMsg != "success")
                {
                    if (chkMsg.Contains("Log4Net"))
                    {
                        lblconfigpath.ForeColor = Color.OrangeRed;
                        lblconfigpath.Text = "请先添加文件Log4Net.config添加到此目录下";
                    }
                    if (chkMsg.Contains("Logger"))
                    {
                        lblConfigCodefile.ForeColor = Color.OrangeRed;
                        lblConfigCodefile.Text = "请先添加文件Logger.cs添加到此目录下!";
                    }
                    return;
                }
                lblconfigpath.Text = lblConfigCodefile.Text = string.Empty;
            
               if (this.txtConfigPath.Text.Trim() != ""){
                ConfigHandler config = new ConfigHandler(this.txtConfigPath.Text, this.txtLoggerFilePath.Text);
                List<LoggerEntity> listLogger = config.GetLoggerList();

                List<BindLogger> listbindLogger = new List<BindLogger>();
                foreach (var l in listLogger)
                {
                    BindLogger bl = new BindLogger();
                    bl.loggerName = l.loggerName;
                    foreach (var ap in l.traceList)
                    {
                        if (ap.Value)
                        {
                            switch (ap.Key)
                            {
                                case "INFO":  bl.INFO = true; break;
                                case "DEBUG": bl.DEBUG = true; break;
                                case "WARN": bl.WARN = true; break;
                                case "ERROR": bl.ERROR = true; break;
                                case "FATAL": bl.FATAL = true; break;
                                case "AdoNetAppender_sqlserver": bl.Sqlserver = true; break;
                             

                            }
                        }

                    }
                    listbindLogger.Add(bl);

                }


                while (this.loggerView.Columns.Count != 0)
                {
                    this.loggerView.Columns.RemoveAt(0);
                }

                 loggerView.DataSource = listbindLogger;
     
 
                DataGridViewButtonColumn update = new DataGridViewButtonColumn();
                 update.UseColumnTextForButtonValue = true;
                update.Name = "update";
                update.DataPropertyName = "update";
                update.Text = "update";
                update.HeaderText = "更新";
                loggerView.Columns.Add(update);


                DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
                delete.UseColumnTextForButtonValue = true;
                delete.Name = "delete";
                delete.DataPropertyName = "delete";
                delete.HeaderText = "删除";
                delete.Text = "delete";
                loggerView.Columns.Add(delete);
                loggerView.Columns[0].ReadOnly = true;

                tabControl1.SelectedIndex = 0;

              }

        }
 

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_GetPath_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.txtConfigPath.Text = folderBrowserDialog1.SelectedPath;
                setConfigXml();
                bindLoggerGridView();
            }                         
        }

        private void btnSelectLoggerFilePath_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.txtLoggerFilePath.Text = folderBrowserDialog1.SelectedPath;
                setConfigXml();
                bindLoggerGridView();
            }   
     
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(this.txtConfigPath.Text.Trim()==""){
                MessageBox.Show("请选择log4net配置文件的路径!");
                return;
            }

            if (this.txtLoggerFilePath.Text.Trim() == "")
            {
                MessageBox.Show("请选择logger.cs文件的路径!");
                return;
            }

            var chkMsg = ConfigHandler.CheckConfig(this.txtConfigPath.Text.Trim(),this.txtLoggerFilePath.Text.Trim());
            if(chkMsg!="success"){
                 MessageBox.Show(chkMsg);
                return;
            }

            if (this.txtLoggerName.Text.Trim() == "")
            {
                MessageBox.Show("填写logger名称!");
                return;
            }

            LoggerEntity logger = new LoggerEntity();
            logger.loggerName = this.txtLoggerName.Text;
 
            logger.traceList["INFO"] = chk_supportInfo.Checked;
            logger.traceList["DEBUG"] =chk_supportDebug.Checked;
            logger.traceList["WARN"] = chk_supportWarn.Checked;
            logger.traceList["ERROR"] = chk_supportError.Checked;
            logger.traceList["FATAL"] = chk_supportFatal.Checked;
            logger.traceList["AdoNetAppender_sqlserver"] = chk_supportDb.Checked;
            logger.sqlConnstring = txtDBstring.Text.Trim();
            logger.saveDir = txtSaveDir.Text.Trim();

    

            if (logger.traceList["AdoNetAppender_sqlserver"] && logger.sqlConnstring == string.Empty || logger.sqlConnstring.Contains("数据库名"))
            {
                MessageBox.Show("请填写正确的数据库连接字段串!数据库名,账号，密码请填对");
                return;
            }

            if (logger.isAllTraceSetFalse())
            {
               MessageBox.Show("至少选择一个Appnder!!!");
               return;
            }

             ConfigHandler config = new ConfigHandler(this.txtConfigPath.Text, this.txtLoggerFilePath.Text);
             if (config.IsExistLogger(logger.loggerName))
             {
                 lblTip.Text = "已经存在此logger名称：" + txtLoggerName.Text;
                 return;

             }
             else
             {
                 lblTip.Text = "";
             }


             try
             {
                 if (config.AddLogger(logger))
                 {
                     bindLoggerGridView();

                     setConfigXml();
                     MessageBox.Show("OK，创建logger成功!");
                 }
                 else
                 {
                     MessageBox.Show("Err----OH!，创建logger失败!");
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show("SORRY" + ex.ToString());
             }
          
        }

        private void txtLoggerName_TextChanged(object sender, EventArgs e)
        {
            lblTip.ForeColor = Color.OrangeRed;
            if (this.txtConfigPath.Text.Trim() == "")
            {
                lblTip.Text = "请先选择log4net配置文件的路径!";
                return;
            }

            if (this.txtLoggerFilePath.Text.Trim() == "")
            {
                lblTip.Text = "请选择logger.cs文件的路径!";
                return;
            }

            if (txtLoggerName.Text.Trim() != "")
            {
                ConfigHandler config = new ConfigHandler(this.txtConfigPath.Text, this.txtLoggerFilePath.Text);
                if (config.IsExistLogger(txtLoggerName.Text.Trim()))
                {
                    lblTip.Text = "已经存在此logger名称：" + txtLoggerName.Text;
                  
                }
                else
                {
                    lblTip.Text = "";
                }
            }

        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            bindLoggerGridView();
            groupdbstring.Visible = false;
        }

        private void loggerView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1) return;

            if (this.txtConfigPath.Text.Trim() == "")
            {
                MessageBox.Show("请选择log4net配置文件的路径!");
                return;
            }

            if (this.txtLoggerFilePath.Text.Trim() == "")
            {
                MessageBox.Show("请选择logger.cs文件的路径!");
                return;
            }
            var chkMsg = ConfigHandler.CheckConfig(this.txtConfigPath.Text.Trim(), this.txtLoggerFilePath.Text.Trim());
            if (chkMsg != "success")
            {
                MessageBox.Show(chkMsg);
                return;
            }


            string action = loggerView.Columns[e.ColumnIndex].Name;//操作类型
            ConfigHandler config = new ConfigHandler(this.txtConfigPath.Text, this.txtLoggerFilePath.Text);
            switch (action)
            {
                case "update":
                     LoggerEntity logger = new LoggerEntity();
                     logger.loggerName = loggerView.Rows[e.RowIndex].Cells[0].Value.ToString();
            
                     logger.traceList["INFO"] = loggerView.Rows[e.RowIndex].Cells[1].Value.ToString() == "True";
                     logger.traceList["DEBUG"] = loggerView.Rows[e.RowIndex].Cells[2].Value.ToString() == "True";
                     logger.traceList["WARN"] = loggerView.Rows[e.RowIndex].Cells[3].Value.ToString() == "True";
                     logger.traceList["ERROR"] = loggerView.Rows[e.RowIndex].Cells[4].Value.ToString() == "True";
                     logger.traceList["FATAL"] = loggerView.Rows[e.RowIndex].Cells[5].Value.ToString() == "True";
                     logger.traceList["AdoNetAppender_sqlserver"] = loggerView.Rows[e.RowIndex].Cells[6].Value.ToString() == "True";
                     logger.sqlConnstring = string.Empty; //连接串之前添加时已经添加了，所以这里不用再设置了。
                     logger.saveDir = txtSaveDir.Text.Trim();

                     logger.sqlConnstring = txtDbstring2.Text.Trim();
                     if (logger.traceList["AdoNetAppender_sqlserver"] && logger.sqlConnstring == string.Empty || logger.sqlConnstring.Contains("数据库名"))
                     {
                        MessageBox.Show("请填写正确的数据库连接字段串!数据库名,账号，密码请填对");
                        groupdbstring.Visible = true;
                        return;
                     }
                     groupdbstring.Visible = false;

 
                     if (logger.isAllTraceSetFalse())
                     {
                         MessageBox.Show("至少选择一个Appnder!!!");
                         return;
                     }

             
                    try
                    {
                        if (config.updateLogger(logger))
                        {
                            bindLoggerGridView();
                            setConfigXml();

                            MessageBox.Show("OK，更新logger成功!");
                        }
                        else
                        {
                            MessageBox.Show("Err----OH!，更新logger失败!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("SORRY" + ex.ToString());
                    }


                    break;
                case "delete":
                    if (MessageBox.Show("确定删除吗?", "删除提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        var loggerName = loggerView.Rows[e.RowIndex].Cells[0].Value.ToString();
                        try
                        {
                            config.RemoveLogger(loggerName);
                            bindLoggerGridView();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Sorry  ,删除失败了" + ex.ToString());
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void setConfigXml()
        {
            var configPath = AppDomain.CurrentDomain.BaseDirectory + "config.xml";
            XDocument doc = XDocument.Load(configPath);
            if (txtConfigPath.Text.Trim() != "")
            {
                doc.Descendants("loggerConfigPath").ToList()[0].Value =txtConfigPath.Text.Trim();
            }
            if (txtLoggerFilePath.Text.Trim() != "")
            {
                doc.Descendants("loggerCodeFilePath").ToList()[0].Value = txtLoggerFilePath.Text.Trim();
            }

            if (txtSaveDir.Text.Trim() != "")
            {
                doc.Descendants("saveDir").ToList()[0].Value = txtSaveDir.Text.Trim();
            }

            

            if (txtDBstring.Text.Trim() != "")
            {
                doc.Descendants("sqlConnstring").ToList()[0].Value = txtDBstring.Text.Trim();
                txtDbstring2.Text = txtDBstring.Text.Trim();
            }
            else{
               if (txtDbstring2.Text.Trim() != "")
               {
                doc.Descendants("sqlConnstring").ToList()[0].Value = txtDbstring2.Text.Trim();
                txtDBstring.Text = txtDBstring.Text.Trim();
               }
            }

            doc.Save(configPath);

        }

        private void getConfigXml()
        {
            var configPath = AppDomain.CurrentDomain.BaseDirectory + "config.xml";
            XDocument doc = XDocument.Load(configPath);
            if (doc.Descendants("loggerConfigPath").ToList()[0].Value.Trim() !="")
            {
                txtConfigPath.Text = doc.Descendants("loggerConfigPath").ToList()[0].Value;
            }
            if (doc.Descendants("loggerCodeFilePath").ToList()[0].Value.Trim()!= "")
            {
                txtLoggerFilePath.Text = doc.Descendants("loggerCodeFilePath").ToList()[0].Value;
            }

            if (doc.Descendants("sqlConnstring").ToList()[0].Value.Trim() != "")
            {
                txtDBstring.Text = txtDbstring2.Text = doc.Descendants("sqlConnstring").ToList()[0].Value;
            }
            if (doc.Descendants("saveDir").ToList()[0].Value.Trim() != "")
            {
                txtSaveDir.Text =   doc.Descendants("saveDir").ToList()[0].Value;
            }

        }

        private void chk_supportDb_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_supportDb.Checked)
            {
                lbldbstring.Visible = txtDBstring.Visible = btnGetSimple.Visible = true;
               
            }
            else
            {
                lbldbstring.Visible = txtDBstring.Visible = btnGetSimple.Visible = false;
            }
        }

        private void btnGetSimple_Click(object sender, EventArgs e)
        {
          
            txtDBstring.Text = sample;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                groupdbstring.Visible = false;
            }

            if (tabControl1.SelectedIndex == 1)
            {

                getConfigXml();
                lbldbstring.Visible = txtDBstring.Visible = btnGetSimple.Visible = false;
                txtLoggerName.Text = string.Empty;
                chk_supportDb.Checked = false;
                chk_supportInfo.Checked = false;
                chk_supportDebug.Checked = false;
                chk_supportWarn.Checked = false;
                chk_supportError.Checked = false;
                chk_supportFatal.Checked = false;
            }


        }

        private void btnSample2_Click(object sender, EventArgs e)
        {
            txtDbstring2.Text = sample;
        }

        private void btnSavedir_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.txtSaveDir.Text = folderBrowserDialog1.SelectedPath;

            }   
        }


 
    }

    public class BindLogger
    {
        public BindLogger()
        {
            INFO = false;
            DEBUG = false;
            WARN = false;
            ERROR = false;
            FATAL = false;
            Sqlserver = false;
        }
        public string loggerName { get; set; }
        public bool INFO { get; set; }
        public bool DEBUG { get; set; }
        public bool WARN { get; set; }
        public bool ERROR { get; set; }
        public bool FATAL { get; set; }
        public bool Sqlserver { get; set; }
    }
}
