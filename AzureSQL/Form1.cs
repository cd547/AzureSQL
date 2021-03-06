﻿using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
//using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading.Tasks;
using System.IO;
using System.ServiceProcess;
using System.Runtime.InteropServices;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Diagnostics;

namespace AzureSQL
{

    /// <summary>
    /// SqlAuthenticationProvider - Is a public class that defines 3 different Azure AD
    /// authentication methods.  The methods are supported in the new .NET 4.7.2.
    ///  . 
    /// 1. Interactive,  2. Integrated,  3. Password
    ///  . 
    /// All 3 authentication methods are based on the Azure
    /// Active Directory Authentication Library (ADAL) managed library.
    /// </summary>
    /// 


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> txData2 = new List<string>();
        List<double> tyData2 = new List<double>();
        List<double> tyData3 = new List<double>();
        ToolTip toolTip = new ToolTip();
        string connectionStr = "Server=tcp:cnvizn.database.chinacloudapi.cn,1433;Initial Catalog=cnvizn;Persist Security Info=False;User ID=weview@weview.partner.onmschina.cn;Password=Wv5454794547;Connect Timeout=10;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=\"Active Directory Password\";";
        string connectionLocalStr = @"Data Source=DESKTOP-6PELLNP\SQLEXPRESS;Initial Catalog=azuredb;User ID=sa;Password=5454794547;Connect Timeout=10;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        //////自定义函数区///////
        /// <summary>
        /// chart初始化
        /// </summary>
        /// <param name="chart"></param>
        public void chart_init(Chart chart)
        {
            chart.Series.Clear();

            chart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            chart.ChartAreas[0].AxisX.ScrollBar.ButtonColor = System.Drawing.Color.Silver;
            chart.ChartAreas[0].AxisY.ScrollBar.ButtonColor = System.Drawing.Color.Silver;
            chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;
            chart.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = false;
            chart.ChartAreas[0].AxisX.ScrollBar.Size = 20;

            chart.ChartAreas[0].AxisX.ScaleView.Position = 1;//指当前(最右边)显示的是第几个点,可以设为当前一共的数据减去Size；
                                                             // chart.ChartAreas[0].AxisX.ScaleView.Size = 80;//视野范围内共有多少个数据点
            chart.ChartAreas[0].AxisX.ScaleView.MinSize = 0;//设置滚动一次，移动几格区域
            chart.ChartAreas[0].Axes[0].MajorGrid.LineDashStyle = ChartDashStyle.Dash; //网格类型 短横线
            chart.ChartAreas[0].Axes[0].MajorGrid.LineColor = Color.Gray;
            chart.ChartAreas[0].Axes[0].MajorTickMark.Enabled = true; // x轴上突出的小点
            chart.ChartAreas[0].Axes[0].MajorTickMark.Enabled = true;
            chart.ChartAreas[0].AxisX.MajorGrid.Interval = 0; //
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd HH:mm";
            chart.ChartAreas[0].AxisX.IsLabelAutoFit = true;
            // chart.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Minutes;
            // chart.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Minutes;

            chart.ChartAreas[0].Axes[1].MajorGrid.LineDashStyle = ChartDashStyle.Dash; //网格类型 短横线
            chart.ChartAreas[0].Axes[1].MajorGrid.LineColor = Color.Gray;
            //x区域放大
            chart.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart.ChartAreas[0].CursorX.Interval = 0;
            chart.ChartAreas[0].CursorX.IntervalOffset = 0;
            chart.ChartAreas[0].CursorX.IntervalType = DateTimeIntervalType.Minutes;
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            //Y区域放大
            chart.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            chart.Legends[0].LegendStyle = LegendStyle.Table;

            //chart.Legends[0].
            //chart.Legends[0].
        }
        /// <summary>
        /// 测试远程连接 
        /// localorRemote 
        /// 0：本地数据库。其他：远程数据库
        /// </summary>
        public void connected(int localorRemote)
        {
            string conn = null, localstr = "";
            ToolStripStatusLabel toolstripstatuslabel = null;
            bool signal = false;
            string msg = "";
            if (localorRemote == 0)
            {
                //本地
                conn = connectionLocalStr;
                localstr = "本地数据库";
                toolstripstatuslabel = toolStripStatusLabel3;
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    try
                    {
                        connection.Open();
                        if (connection.State == ConnectionState.Open)
                        {
                            signal = true;
                            msg = localstr + "连接成功！";
                            LogMessage(msg);
                        }
                        else
                        {
                            signal = false;
                            msg = localstr + "未连接！" + connection.State.ToString();
                            LogWarning(msg);
                            msg = localstr + "未连接！";
                        }
                    }
                    catch (SqlException exp)
                    {
                        StringBuilder errorMessages = new StringBuilder();
                        for (int i = 0; i < exp.Errors.Count; i++)
                        {
                            errorMessages.Append("Index #" + i + "\n" +
                                "Message: " + exp.Errors[i].Message + "\n" +
                                "LineNumber: " + exp.Errors[i].LineNumber + "\n" +
                                "Source: " + exp.Errors[i].Source + "\n" +
                                "Procedure: " + exp.Errors[i].Procedure + "\n");
                        }
                        MessageBox.Show(errorMessages.ToString());
                        signal = false;
                        msg = localstr + "连接失败！" + errorMessages.ToString();
                        LogError(msg);
                        msg = localstr + "连接失败！";
                    }

                }
            }
            else
            {
                //远程
                // conn = connectionStr;
                localstr = "远程数据库";
                toolstripstatuslabel = toolStripStatusLabel1;
                var provider = new ActiveDirectoryAuthProvider();
                System.Data.SqlClient.SqlAuthenticationProvider.SetProvider(
                    System.Data.SqlClient.SqlAuthenticationMethod.ActiveDirectoryInteractive,
                    //SC.SqlAuthenticationMethod.ActiveDirectoryIntegrated,  // Alternatives.
                    //SC.SqlAuthenticationMethod.ActiveDirectoryPassword,
                    provider);
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder["Data Source"] = "cnvizn.database.chinacloudapi.cn";

                builder.UserID = "weview@weview.partner.onmschina.cn";
                builder["Initial Catalog"] = "cnvizn";

                // This "Password" is not used with .ActiveDirectoryInteractive.
                //builder["Password"] = "<YOUR PASSWORD HERE>";

                builder["Connect Timeout"] = 15;
                builder["TrustServerCertificate"] = true;
                builder.Pooling = false;
                // Assigned enum value must match the enum given to .SetProvider().
                builder.Authentication = System.Data.SqlClient.SqlAuthenticationMethod.ActiveDirectoryInteractive;
                try
                {
                    using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(builder.ConnectionString))
                    {
                        try
                        {
                            connection.Open();
                            if (connection.State == ConnectionState.Open)
                            {
                                signal = true;
                                msg = localstr + "连接成功！";
                                LogMessage(msg);
                            }
                            else
                            {
                                signal = false;
                                msg = localstr + "未连接！" + connection.State.ToString();
                                LogWarning(msg);
                                msg = localstr + "未连接！";
                            }
                        }
                        catch (SqlException exp)
                        {
                            StringBuilder errorMessages = new StringBuilder();
                            for (int i = 0; i < exp.Errors.Count; i++)
                            {
                                errorMessages.Append("Index #" + i + "\n" +
                                    "Message: " + exp.Errors[i].Message + "\n" +
                                    "LineNumber: " + exp.Errors[i].LineNumber + "\n" +
                                    "Source: " + exp.Errors[i].Source + "\n" +
                                    "Procedure: " + exp.Errors[i].Procedure + "\n");
                            }
                            MessageBox.Show(errorMessages.ToString());
                            signal = false;
                            msg = localstr + "连接失败！" + errorMessages.ToString();
                            LogError(msg);
                            msg = localstr + "连接失败！";
                        }

                    }

                }
                catch (Exception exp)
                { LogWarning(exp.ToString()); signal = false; msg = localstr + "连接失败！"; }

            }


            this.BeginInvoke(new Action(() =>
            {
                if (localorRemote == 1)
                {
                    timer1.Stop();
                }
                else
                {
                    timer2.Stop();
                }
                toolstripstatuslabel.Image = signal ? Properties.Resources.center1 : Properties.Resources.center0;
                toolstripstatuslabel.Text = msg;
                toolstripstatuslabel.ForeColor = signal ? Color.WhiteSmoke : Color.Red;
                // this.button15.Enabled = signal ? true : false;
                if (this.toolStripStatusLabel1.Text == "远程数据库连接成功！" && this.toolStripStatusLabel3.Text == "本地数据库连接成功！")
                { this.button15.Enabled = true; }
                else
                { this.button15.Enabled = false; }


            }));


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static string Deserialize(string xml)
        {
            string st1 = "";
            XmlDocument xx = new XmlDocument();
            xx.LoadXml(xml);
            XmlNode xxNode1 = xx.SelectSingleNode("/ArrayOfString");
            try
            {
                foreach (XmlNode xxNode in xxNode1.ChildNodes)
                {

                    if (IsNumeric(xxNode.InnerText))
                    {
                        st1 += xxNode.InnerText + " ";
                    }
                    else
                    {
                        st1 += "NaN ";
                    }
                }
            }
            catch (Exception exp)
            {
                st1 = "err";
            }
            return st1;
        }
        /// <summary>
        /// 数据库查询
        /// </summary>
        /// <param name="sql"></param>
        public void DataQuery(string sql)
        {
            string conn = null;
            SqlConnection connection = null;
            if (this.radioButton1.Checked)
            {
                //本地
                conn = connectionLocalStr;
                connection = new SqlConnection(conn);
            }
            else
            {
                //远程
                conn = connectionStr;
                var provider = new ActiveDirectoryAuthProvider();
                System.Data.SqlClient.SqlAuthenticationProvider.SetProvider(
                    System.Data.SqlClient.SqlAuthenticationMethod.ActiveDirectoryInteractive,
                    //SC.SqlAuthenticationMethod.ActiveDirectoryIntegrated,  // Alternatives.
                    //SC.SqlAuthenticationMethod.ActiveDirectoryPassword,
                    provider);
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder["Data Source"] = "cnvizn.database.chinacloudapi.cn";

                builder.UserID = "weview@weview.partner.onmschina.cn";
                builder["Initial Catalog"] = "cnvizn";

                // This "Password" is not used with .ActiveDirectoryInteractive.
                //builder["Password"] = "<YOUR PASSWORD HERE>";

                builder["Connect Timeout"] = 15;
                builder["TrustServerCertificate"] = true;
                builder.Pooling = false;
                // Assigned enum value must match the enum given to .SetProvider().
                builder.Authentication = System.Data.SqlClient.SqlAuthenticationMethod.ActiveDirectoryInteractive;
                connection = new System.Data.SqlClient.SqlConnection(builder.ConnectionString);
            }
            using (connection)
            {
                try
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        this.toolStripStatusLabel1.Text = "连接成功！";
                        this.toolStripStatusLabel1.ForeColor = Color.Green;
                        string strCommand = sql;
                        SqlCommand cmd = new SqlCommand(strCommand, connection);
                        //cmd.CommandText = strCommand; // cmd是sqlCommand对象
                        SqlDataAdapter da = new SqlDataAdapter(strCommand, connection);
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        //fill
                        this.toolStripStatusLabel2.Text = dt.Rows.Count.ToString();
                        this.dataGridView1.DataSource = null;  //清空原有datagridview列表
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        this.toolStripStatusLabel1.Text = "未连接！" + connection.State.ToString();
                        this.toolStripStatusLabel1.ForeColor = Color.Red;
                    }
                }
                catch (SqlException exp)
                {
                    StringBuilder errorMessages = new StringBuilder();
                    for (int i = 0; i < exp.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + exp.Errors[i].Message + "\n" +
                            "LineNumber: " + exp.Errors[i].LineNumber + "\n" +
                            "Source: " + exp.Errors[i].Source + "\n" +
                            "Procedure: " + exp.Errors[i].Procedure + "\n");
                    }
                    MessageBox.Show(errorMessages.ToString());
                    this.toolStripStatusLabel1.Text = "连接失败！";
                    this.toolStripStatusLabel1.ForeColor = Color.Red;
                }
            }
        }

        #region 使用SqlBulkCopy将DataTable中的数据批量插入数据库中  
        /// <summary>  
        /// 注意：DataTable中的列需要与数据库表中的列完全一致。
        /// 已自测可用。
        /// </summary>  
        /// <param name="conStr">数据库连接串</param>
        /// <param name="strTableName">数据库中对应的表名</param>  
        /// <param name="dtData">数据集</param>  
        public void SqlBulkCopyInsert(string conStr, string strTableName, DataTable dtData)
        {
            try
            {
                using (SqlBulkCopy sqlRevdBulkCopy = new SqlBulkCopy(conStr))//引用SqlBulkCopy  
                {
                    sqlRevdBulkCopy.DestinationTableName = strTableName;//数据库中对应的表名  
                    sqlRevdBulkCopy.NotifyAfter = dtData.Rows.Count;//有几行数据  
                    sqlRevdBulkCopy.WriteToServer(dtData);//数据导入数据库  
                    sqlRevdBulkCopy.Close();//关闭连接  
                }
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
            }
        }
        #endregion

        #region 清空表内数据 ID=1
        /// <summary>  
        /// 注意：安全起见，只清空本地表。
        /// </summary>  
        /// <param name="conStr">数据库连接串</param>
        /// <param name="strTableName">数据库中对应的表名</param>  
        public int ClearDataTable(string conStr, string strTableName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionLocalStr))
                {
                    connection.Open();
                    int res = new SqlCommand("truncate table " + strTableName, connection).ExecuteNonQuery();
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
                throw (ex);
            }
        }
        #endregion
        /// <summary>
        /// 初始化本地表
        /// </summary>
        /// <param name="tablename"></param>
        public void InitalTable(string tablename)
        {
            var provider = new ActiveDirectoryAuthProvider();
            System.Data.SqlClient.SqlAuthenticationProvider.SetProvider(
                System.Data.SqlClient.SqlAuthenticationMethod.ActiveDirectoryInteractive,
                //SC.SqlAuthenticationMethod.ActiveDirectoryIntegrated,  // Alternatives.
                //SC.SqlAuthenticationMethod.ActiveDirectoryPassword,
                provider);
            System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
            builder["Data Source"] = "cnvizn.database.chinacloudapi.cn";

            builder.UserID = "weview@weview.partner.onmschina.cn";
            builder["Initial Catalog"] = "cnvizn";

            // This "Password" is not used with .ActiveDirectoryInteractive.
            //builder["Password"] = "<YOUR PASSWORD HERE>";

            builder["Connect Timeout"] = 15;
            builder["TrustServerCertificate"] = true;
            builder.Pooling = false;
            // Assigned enum value must match the enum given to .SetProvider().
            builder.Authentication = System.Data.SqlClient.SqlAuthenticationMethod.ActiveDirectoryInteractive;
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        //查询表
                        //string strCommand = "SELECT * FROM [dbo].[EsuValues] where Esu_Id=" + this.comboBox3.Text + " AND datediff(day, [Timestamp],'" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')= 0 order by [Timestamp] ASC";
                        string strCommand = "SELECT * FROM " + tablename;
                        SqlCommand cmd = new SqlCommand(strCommand, connection);
                        //cmd.CommandText = strCommand; // cmd是sqlCommand对象
                        SqlDataAdapter da = new SqlDataAdapter(strCommand, connection);
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet(tablename);
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        //clear local dbo.EsuValues
                        int res = ClearDataTable("", tablename);
                        // MessageBox.Show(res.ToString());
                        if (res < 0)
                        {
                            //fill local
                            SqlBulkCopyInsert(connectionLocalStr, tablename, dt);
                            // this.textBox1.Text = txt;
                        }
                        LogMessage("本地数据库连接成功！初始化" + tablename + "成功");
                    }
                    else
                    {
                        LogWarning("本地数据库未连接！" + connection.State.ToString());
                    }
                }
                catch (SqlException exp)
                {
                    StringBuilder errorMessages = new StringBuilder();
                    for (int i = 0; i < exp.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + exp.Errors[i].Message + "\n" +
                            "LineNumber: " + exp.Errors[i].LineNumber + "\n" +
                            "Source: " + exp.Errors[i].Source + "\n" +
                            "Procedure: " + exp.Errors[i].Procedure + "\n");
                    }
                    MessageBox.Show(errorMessages.ToString());
                    LogError("本地数据库连接失败！" + errorMessages.ToString());
                }
            }
            this.BeginInvoke(new Action(() =>
            {
                ///todo
            }));
        }
        /// <summary>
        /// 数据库查询返回表
        /// </summary>
        /// <param name="localorRemote"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable DataQueryTable(int localorRemote, string sql)
        {
            DataTable res;
            string conn = null, localstr = "";
            SqlConnection connection = null;
            ToolStripStatusLabel toolstripstatuslabel = null;
            if (localorRemote == 0)
            {
                //本地
                conn = connectionLocalStr;
                connection = new SqlConnection(conn);
                localstr = "本地数据库";
                toolstripstatuslabel = toolStripStatusLabel3;
            }
            else
            {
                //远程
                localstr = "远程数据库";
                toolstripstatuslabel = toolStripStatusLabel1;
                var provider = new ActiveDirectoryAuthProvider();
                System.Data.SqlClient.SqlAuthenticationProvider.SetProvider(
                    System.Data.SqlClient.SqlAuthenticationMethod.ActiveDirectoryInteractive,
                    //SC.SqlAuthenticationMethod.ActiveDirectoryIntegrated,  // Alternatives.
                    //SC.SqlAuthenticationMethod.ActiveDirectoryPassword,
                    provider);
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder["Data Source"] = "cnvizn.database.chinacloudapi.cn";

                builder.UserID = "weview@weview.partner.onmschina.cn";
                builder["Initial Catalog"] = "cnvizn";

                // This "Password" is not used with .ActiveDirectoryInteractive.
                //builder["Password"] = "<YOUR PASSWORD HERE>";

                builder["Connect Timeout"] = 15;
                builder["TrustServerCertificate"] = true;
                builder.Pooling = false;
                // Assigned enum value must match the enum given to .SetProvider().
                builder.Authentication = System.Data.SqlClient.SqlAuthenticationMethod.ActiveDirectoryInteractive;
                connection = new System.Data.SqlClient.SqlConnection(builder.ConnectionString);
            }
            using (connection)
            {
                try
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        toolstripstatuslabel.Text = localstr + "连接成功！";
                        toolstripstatuslabel.Image = Properties.Resources.center1;
                        string strCommand = sql;
                        SqlCommand cmd = new SqlCommand(strCommand, connection);
                        //cmd.CommandText = strCommand; // cmd是sqlCommand对象
                        SqlDataAdapter da = new SqlDataAdapter(strCommand, connection);
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        //fill
                        this.toolStripStatusLabel2.Text = dt.Rows.Count.ToString();
                        //this.dataGridView1.DataSource = null;  //清空原有datagridview列表
                        //dataGridView1.DataSource = ds.Tables[0];
                        LogMessage(localstr + "连接成功！查询数据表成功，SQL：" + sql);
                        return dt;
                    }
                    else
                    {
                        toolstripstatuslabel.Image = Properties.Resources.center0;
                        toolstripstatuslabel.Text = localstr + "未连接！" + connection.State.ToString();
                        toolstripstatuslabel.ForeColor = Color.Red;
                        LogWarning(localstr + "未连接！" + connection.State.ToString());
                        return null;
                    }
                }
                catch (SqlException exp)
                {
                    StringBuilder errorMessages = new StringBuilder();
                    for (int i = 0; i < exp.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + exp.Errors[i].Message + "\n" +
                            "LineNumber: " + exp.Errors[i].LineNumber + "\n" +
                            "Source: " + exp.Errors[i].Source + "\n" +
                            "Procedure: " + exp.Errors[i].Procedure + "\n");
                    }
                    MessageBox.Show(errorMessages.ToString());
                    toolstripstatuslabel.Image = Properties.Resources.center0;
                    toolstripstatuslabel.Text = localstr + "连接失败！";
                    toolstripstatuslabel.ForeColor = Color.Red;
                    LogError(localstr + "连接失败！" + errorMessages.ToString());
                    return null;
                }
            }
        }
        /// <summary>
        /// chart1电压图像
        /// </summary>
        /// <param name="n"></param>
        /// <param name="linename"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void drawLine_volt(int n, string linename, List<DateTime> x, List<double> y)
        {
            LogMessage("在chart1系列" + n.ToString() + ",绘制曲线：" + linename);
            //this.chart1.Series.Clear();
            // this.chart1.Series[0].Points.Clear();
            this.chart1.Series.Add(new Series(linename)); //添加一个图表序列
                                                          // ct.Series[0].XValueType = ChartValueType.String; //设置X轴上的值类型
            this.chart1.Series[n].XValueType = ChartValueType.DateTime;
            this.chart1.Series[n].Label = "#VAL"; //设置显示X Y的值 
            this.chart1.Series[n].ToolTip = linename + "\r#VALX{yyyy-MM-dd HH:mm} \r#VALV"; //鼠标移动到对应点显示数值
            this.chart1.Series[n].ChartArea = this.chart1.ChartAreas[0].Name; //设置图表背景框ChartArea 

            this.chart1.Series[n].IsValueShownAsLabel = false;
            this.chart1.Series[n].SmartLabelStyle.Enabled = false;
            this.chart1.Series[n].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.No;
            /*
            //开启小箭头及数据显示
            this.chart1.Series[n].IsValueShownAsLabel = false;
            this.chart1.Series[n].SmartLabelStyle.Enabled = false;
            this.chart1.Series[n].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.No;

            this.chart1.Series[n].LabelForeColor = Color.Transparent;
          

                this.chart1.Series[n].MarkerBorderColor = Color.Red; //标记点边框颜色
                this.chart1.Series[n].MarkerBorderWidth = 1; //标记点边框大小
                this.chart1.Series[n].MarkerColor = Color.Blue; //标记点中心颜色
                this.chart1.Series[n].MarkerSize = 1; //标记点大小
                this.chart1.Series[n].MarkerStyle = MarkerStyle.Circle; //标记点类型
               // this.chart1.Series[n].IsValueShownAsLabel = true;
               // this.chart1.Series[n].SmartLabelStyle.Enabled = true;
               // this.chart1.Series[n].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Partial;
               // this.chart1.Series[n].LabelForeColor = Color.Black;

            */
            this.chart1.Series[n].ChartType = SeriesChartType.FastLine; //图类型(折线)
            this.chart1.Series[n].BorderWidth = 2;
            this.chart1.Series[n].Points.DataBindXY(x, y); //添加数据
                                                           //Legend currentLegend = this.chart1.Legends.FindByName(this.chart1.Series[n].Legend);
                                                           //  LegendItem newItem = new LegendItem();
                                                           //  newItem.ImageStyle = LegendImageStyle.Rectangle;
                                                           // MessageBox.Show(this.chart1.Legends[0].CustomItems[0].Name);

            //  newItem.Color = this.chart1.Series[n].Color;
            //自定义legend
            /*
             * this.chart1.Series[n].IsVisibleInLegend = false;
            LegendItem legendItem = new LegendItem();
            //legendItem.ImageStyle = LegendImageStyle.Rectangle;
            LegendCell cell1 = new LegendCell(); 
            cell1.Name = "text"; 
            cell1.Text = linename; 
            // here you can specify alignment, color, ..., too 
            LegendCell cell2 = new LegendCell(); 
            cell2.Name = "Symbol"; 
            cell2.CellType = System.Windows.Forms.DataVisualization.Charting.LegendCellType.SeriesSymbol;
            legendItem.Cells.Add(cell2);
            legendItem.Cells.Add(cell1); 
            this.chart1.ApplyPaletteColors();
            legendItem.Color = this.chart1.Series[n].Color;
            this.chart1.Legends[0].CustomItems.Add(legendItem);
            */
        }
        /// <summary>
        /// 温度曲线chart2
        /// </summary>
        /// <param name="n"></param>
        /// <param name="linename"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void drawLine_temp(int n, string linename, List<DateTime> x, List<double> y)
        {
            LogMessage("在chart2系列" + n.ToString() + ",绘制曲线" + linename);
            //this.chart2.Series.Clear();
            // this.chart2.Series[0].Points.Clear();
            this.chart2.Series.Add(new Series(linename)); //添加一个图表序列
                                                          // ct.Series[0].XValueType = ChartValueType.String; //设置X轴上的值类型
            this.chart2.Series[n].XValueType = ChartValueType.DateTime;
            this.chart2.Series[n].Label = "#VAL"; //设置显示X Y的值 
            this.chart2.Series[n].ToolTip = linename + "\r#VALX{yyyy-MM-dd HH:mm}\r#VAL℃"; //鼠标移动到对应点显示数值
            this.chart2.Series[n].ChartArea = this.chart2.ChartAreas[0].Name; //设置图表背景框ChartArea 
            //开启小箭头及数据显示
            this.chart2.Series[n].IsValueShownAsLabel = false;
            this.chart2.Series[n].SmartLabelStyle.Enabled = false;
            this.chart2.Series[n].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.No;
            this.chart2.Series[n].LabelForeColor = Color.Transparent;
            if (this.checkBox1.Checked)
            {
                this.chart2.Series[n].MarkerBorderColor = Color.Red; //标记点边框颜色
                this.chart2.Series[n].MarkerBorderWidth = 1; //标记点边框大小
                this.chart2.Series[n].MarkerColor = Color.Blue; //标记点中心颜色
                this.chart2.Series[n].MarkerSize = 3; //标记点大小
                this.chart2.Series[n].MarkerStyle = MarkerStyle.Circle; //标记点类型
                this.chart2.Series[n].IsValueShownAsLabel = true;
                this.chart2.Series[n].SmartLabelStyle.Enabled = true;
                this.chart2.Series[n].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Partial;
                this.chart2.Series[n].LabelForeColor = Color.Black;
            }
            this.chart2.Series[n].ChartType = SeriesChartType.FastLine; //图类型(折线)
            this.chart2.Series[n].BorderWidth = 2;
            this.chart2.Series[n].Points.DataBindXY(x, y); //添加数据
                                                           //自定义legend
            /*
             this.chart2.Series[n].IsVisibleInLegend = false;
             LegendItem legendItem = new LegendItem();
             //legendItem.ImageStyle = LegendImageStyle.Rectangle;
             LegendCell cell1 = new LegendCell();
             cell1.Name = "text";
             cell1.Text = linename;
             // here you can specify alignment, color, ..., too 
             LegendCell cell2 = new LegendCell();
             cell2.Name = "Symbol";
             cell2.CellType = System.Windows.Forms.DataVisualization.Charting.LegendCellType.SeriesSymbol;
             legendItem.Cells.Add(cell2);
             legendItem.Cells.Add(cell1);
             this.chart2.ApplyPaletteColors();
             legendItem.Color = this.chart2.Series[n].Color;
             this.chart2.Legends[0].CustomItems.Add(legendItem);
             */
        }
        #region 日志记录、支持其他线程访问 
        public delegate void LogAppendDelegate(Color color, string text);
        /// <summary> 
        /// 追加显示文本 
        /// </summary> 
        /// <param name="color">文本颜色</param> 
        /// <param name="text">显示文本</param> 
        public void LogAppend(Color color, string text)
        {
            this.richTextBox1.SelectionColor = color;
            this.richTextBox1.AppendText(text);
            this.richTextBox1.AppendText("\n");
            //scroll滚到底部
            this.richTextBox1.SelectionStart = this.richTextBox1.Text.Length;
            this.richTextBox1.SelectionLength = 0;
            this.richTextBox1.Focus();
            //写入文件
            try
            {
                if (System.IO.Directory.Exists("log"))
                {
                    string logFileName = @"log/LogName" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                    using (TextWriter logFile = TextWriter.Synchronized(File.AppendText(logFileName)))
                    {
                        logFile.WriteLine(text);
                        logFile.Flush();
                        logFile.Close();
                    }
                }
                else
                {
                    Directory.CreateDirectory("log");//创建该文件
                    string logFileName = @"log/LogName" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                    using (TextWriter logFile = TextWriter.Synchronized(File.AppendText(logFileName)))
                    {
                        logFile.WriteLine(text);
                        logFile.Flush();
                        logFile.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Log Create Error:" + ex.Message.ToString());
            }

        }
        /// <summary> 
        /// 显示错误日志 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogError(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            this.richTextBox1.BeginInvoke(la, Color.Red, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " Error:" + text);
        }
        /// <summary> 
        /// 显示警告信息 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogWarning(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            this.richTextBox1.BeginInvoke(la, Color.Yellow, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " Warning:" + text);
        }
        /// <summary> 
        /// 显示信息 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogMessage(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            this.richTextBox1.BeginInvoke(la, Color.LightGray, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " Message:" + text);
        }
        #endregion
        //生成图片
        public void genpic(Chart chart, string chartname)
        {
            chart.ChartAreas[0].CursorX.LineWidth = 0;
            chart.ChartAreas[0].CursorY.LineWidth = 0;
            chart.SaveImage(chartname + ".png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
            chart.ChartAreas[0].CursorX.LineWidth = 1;
            chart.ChartAreas[0].CursorY.LineWidth = 1;
        }
        /// <summary>
        ///soc曲线chart3
        /// </summary>
        /// <param name="n"></param>
        /// <param name="linename"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void drawLine_SOC(int n, string linename, List<DateTime> x, List<double> y)
        {
            LogMessage("在chart3系列" + n.ToString() + ",绘制曲线" + linename);
            //this.chart2.Series.Clear();
            // this.chart2.Series[0].Points.Clear();
            this.chart3.Series.Add(new Series(linename)); //添加一个图表序列
                                                          // ct.Series[0].XValueType = ChartValueType.String; //设置X轴上的值类型
            this.chart3.Series[n].XValueType = ChartValueType.DateTime;
            this.chart3.Series[n].Label = "#VAL"; //设置显示X Y的值 
            this.chart3.Series[n].ToolTip = linename + "\r#VALX{yyyy-MM-dd HH:mm}\r#VAL%"; //鼠标移动到对应点显示数值
            this.chart3.Series[n].ChartArea = this.chart3.ChartAreas[0].Name; //设置图表背景框ChartArea 
            //开启小箭头及数据显示
            this.chart3.Series[n].IsValueShownAsLabel = false;
            this.chart3.Series[n].SmartLabelStyle.Enabled = false;
            this.chart3.Series[n].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.No;
            this.chart3.Series[n].LabelForeColor = Color.Transparent;
            if (this.checkBox1.Checked)
            {
                this.chart3.Series[n].MarkerBorderColor = Color.Red; //标记点边框颜色
                this.chart3.Series[n].MarkerBorderWidth = 1; //标记点边框大小
                this.chart3.Series[n].MarkerColor = Color.Blue; //标记点中心颜色
                this.chart3.Series[n].MarkerSize = 3; //标记点大小
                this.chart3.Series[n].MarkerStyle = MarkerStyle.Circle; //标记点类型
                this.chart3.Series[n].IsValueShownAsLabel = true;
                this.chart3.Series[n].SmartLabelStyle.Enabled = true;
                this.chart3.Series[n].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Partial;
                this.chart3.Series[n].LabelForeColor = Color.Black;
            }
            this.chart3.Series[n].ChartType = SeriesChartType.FastLine; //图类型(折线)
            this.chart3.Series[n].BorderWidth = 2;
            this.chart3.Series[n].Points.DataBindXY(x, y); //添加数据
            //自定义legend
            /*
            this.chart3.Series[n].IsVisibleInLegend = false;
            LegendItem legendItem = new LegendItem();
            //legendItem.ImageStyle = LegendImageStyle.Rectangle;
            LegendCell cell1 = new LegendCell();
            cell1.Name = "text";
            cell1.Text = linename;
            // here you can specify alignment, color, ..., too 
            LegendCell cell2 = new LegendCell();
            cell2.Name = "Symbol";
            cell2.CellType = System.Windows.Forms.DataVisualization.Charting.LegendCellType.SeriesSymbol;
            legendItem.Cells.Add(cell2);
            legendItem.Cells.Add(cell1);
            this.chart3.ApplyPaletteColors();
            legendItem.Color = this.chart3.Series[n].Color;
            this.chart3.Legends[0].CustomItems.Add(legendItem);
            */
        }

        //////自定义函数区//////


        private void Form1_Load(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2Collapsed = true;
            //string datestring = this.dateTimePicker1.Value.ToShortDateString();
            // MessageBox.Show(datestring);
            LogMessage("打开软件");
            this.toolStripStatusLabel1.Text = "远程数据库连接中...";
            this.toolStripStatusLabel3.Text = "本地数据库连接中...";
            this.button15.Enabled = false;
            Task t1 = Task.Factory.StartNew(() => connected(1));
            timer1.Start();
            //判断本地sql服务是否开启
            ServiceController scSQL = new ServiceController();
            scSQL.MachineName = "DESKTOP-6PELLNP";
            scSQL.ServiceName = "MSSQL$SQLEXPRESS";
            if (scSQL.Status == ServiceControllerStatus.Stopped)
            {
                try
                {
                    scSQL.Start();// 启动服务
                    scSQL.WaitForStatus(ServiceControllerStatus.Running);
                    this.toolStripStatusLabel3.Text = scSQL.ServiceName + "服务开启成功";
                    Task t2 = Task.Factory.StartNew(() => connected(0));
                    timer2.Start();
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("不能启动该服务！");
                }
            }
            else
            {
                this.toolStripStatusLabel3.Text = scSQL.ServiceName + "服务已经开启";
                Task t2 = Task.Factory.StartNew(() => connected(0));
                timer2.Start();
            }

            /*
                        using (SqlConnection connection = new SqlConnection(connectionStr))
                        {
                            try {
                                connection.Open();
                                if (connection.State == ConnectionState.Open)
                                {
                                    this.toolStripStatusLabel1.Text = "连接成功！";
                                    this.toolStripStatusLabel1.ForeColor = Color.Green;
                                    //查询表
                                    string strCommand = "SELECT SCHEMA_NAME(t.[schema_id])+'.'+t.name FROM sys.tables AS t ORDER BY SCHEMA_NAME(t.[schema_id]),t.name ASC";
                                    SqlCommand cmd = new SqlCommand(strCommand,connection);
                                    //cmd.CommandText = strCommand; // cmd是sqlCommand对象
                                    SqlDataAdapter da = new SqlDataAdapter(strCommand, connection);
                                    da.SelectCommand = cmd;
                                    DataSet ds = new DataSet();
                                    da.Fill(ds);
                                    DataTable dt = ds.Tables[0];
                                    //fill
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        this.comboBox1.Items.Add(dt.Rows[i][0]);
                                    }
                                    //获取表的字段名
                                    strCommand = "SELECT NAME FROM SYSCOLUMNS WHERE ID=OBJECT_ID('dbo.StackValues');";
                                    cmd = new SqlCommand(strCommand, connection);
                                    da = new SqlDataAdapter(strCommand, connection);
                                    da.SelectCommand = cmd;
                                    DataSet ds1 = new DataSet();
                                    da.Fill(ds1);
                                    DataTable dt1 = ds1.Tables[0];
                                    //fill
                                    for (int i = 0; i < dt1.Rows.Count; i++)
                                    {
                                        this.comboBox2.Items.Add(dt1.Rows[i][0]);
                                    }
                                    this.button15.Enabled = true;
                                }
                                else
                                {
                                    this.toolStripStatusLabel1.Text = "未连接！" + connection.State.ToString();
                                    this.toolStripStatusLabel1.ForeColor = Color.Red;
                                    this.button15.Enabled = false;
                                }
                            }
                            catch (SqlException exp)
                            {
                                StringBuilder errorMessages = new StringBuilder();
                                for (int i = 0; i < exp.Errors.Count; i++)
                                {
                                    errorMessages.Append("Index #" + i + "\n" +
                                        "Message: " + exp.Errors[i].Message + "\n" +
                                        "LineNumber: " + exp.Errors[i].LineNumber + "\n" +
                                        "Source: " + exp.Errors[i].Source + "\n" +
                                        "Procedure: " + exp.Errors[i].Procedure + "\n");
                                }
                                MessageBox.Show(errorMessages.ToString());
                                this.toolStripStatusLabel1.Text = "连接失败！";
                                this.toolStripStatusLabel1.ForeColor = Color.Red;
                                this.button15.Enabled = false;
                            }
                        }
                        */
            //初始化节点
            this.treeView1.Nodes.Add("GS200");
            TreeNode Fnode = this.treeView1.Nodes[0];
            Fnode.ImageIndex = 0;
            Font boldFont = new Font(treeView1.Font, FontStyle.Bold);
            Fnode.NodeFont = boldFont;
            Fnode.Text = "GS200";
            for (int i = 1; i <= 12; i++)
            {
                Fnode.Nodes.Add("Stack_" + i.ToString());
                Fnode.Nodes[i - 1].ImageIndex = 1;
                for (int j = 1; j <= 30; j++)
                {
                    Fnode.Nodes[i - 1].Nodes.Add("Cell_" + j.ToString());
                    Fnode.Nodes[i - 1].Nodes[j - 1].ImageIndex = 2;
                }
            }
            //初始化chart
            chart_init(this.chart1);
            chart_init(this.chart2);
            chart_init(this.chart3);
            chart_init(this.chart16);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text = this.comboBox1.Text;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        this.toolStripStatusLabel1.Text = "连接成功！";
                        this.toolStripStatusLabel1.ForeColor = Color.Green;
                        //查询表
                        if (this.toolStripStatusLabel2.Text == "dbo.EsuValues")
                        {
                            //this.dateTimePicker1.Value.ToShortDateString()
                            this.toolStripStatusLabel2.Text = this.toolStripStatusLabel2.Text + " where datediff(day,[Timestamp],'" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')=0";
                            //SELECT *FROM [dbo].[EsuValues] where datediff(day,[Timestamp],'2019-09-24')=0 
                            MessageBox.Show(this.toolStripStatusLabel2.Text);
                        }

                        string strCommand = "SELECT * FROM " + this.toolStripStatusLabel2.Text;

                        SqlCommand cmd = new SqlCommand(strCommand, connection);
                        //cmd.CommandText = strCommand; // cmd是sqlCommand对象
                        SqlDataAdapter da = new SqlDataAdapter(strCommand, connection);
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        //fill
                        this.toolStripStatusLabel2.Text = dt.Rows.Count.ToString();
                        this.dataGridView1.DataSource = null;  //清空原有datagridview列表
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        this.toolStripStatusLabel1.Text = "未连接！" + connection.State.ToString();
                        this.toolStripStatusLabel1.ForeColor = Color.Red;
                    }
                }
                catch (SqlException exp)
                {
                    StringBuilder errorMessages = new StringBuilder();
                    for (int i = 0; i < exp.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + exp.Errors[i].Message + "\n" +
                            "LineNumber: " + exp.Errors[i].LineNumber + "\n" +
                            "Source: " + exp.Errors[i].Source + "\n" +
                            "Procedure: " + exp.Errors[i].Procedure + "\n");
                    }
                    MessageBox.Show(errorMessages.ToString());
                    this.toolStripStatusLabel1.Text = "连接失败！";
                    this.toolStripStatusLabel1.ForeColor = Color.Red;
                }
            }
        }

        // private void Button1_Click(object sender, EventArgs e)
        //  {
        //this.label3.Text= Deserialize(this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value.ToString());
        // }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ;
        }

        //计算
        private void Button3_Click(object sender, EventArgs e)
        {
            txData2.Clear();
            tyData2.Clear();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        this.toolStripStatusLabel1.Text = "连接成功！";
                        this.toolStripStatusLabel1.ForeColor = Color.Green;
                        //查询表
                        string strCommand = "SELECT * FROM dss.UIHistory";
                        SqlCommand cmd = new SqlCommand(strCommand, connection);
                        //cmd.CommandText = strCommand; // cmd是sqlCommand对象
                        SqlDataAdapter da = new SqlDataAdapter(strCommand, connection);
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        //fill
                        //string txt="";
                        int n = dt.Rows.Count;
                        for (int i = 0; i < n; i++)
                        {
                            //add time
                            txData2.Add(dt.Rows[i][1].ToString());
                            //  txt += dt.Rows[i][1].ToString();
                            //add value
                            string s = Deserialize(dt.Rows[i][9].ToString());
                            //   txt += " " + s.Length.ToString() + "\r\n";
                            //判断是否有NaN err 空
                            if (s.Length == 0)
                            {
                                tyData2.Add(0);
                            }
                            else
                            {
                                if (s.IndexOf("NaN", StringComparison.OrdinalIgnoreCase) >= 0 || s.IndexOf("err", StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    tyData2.Add(0);
                                }
                                else
                                {
                                    string[] sArray = s.Split(' ');// 一定是单引 
                                    tyData2.Add(Convert.ToDouble(sArray[0]));
                                }
                            }
                        }
                        // this.textBox1.Text = txt;
                    }
                    else
                    {
                        this.toolStripStatusLabel1.Text = "未连接！" + connection.State.ToString();
                        this.toolStripStatusLabel1.ForeColor = Color.Red;
                    }
                }
                catch (SqlException exp)
                {
                    StringBuilder errorMessages = new StringBuilder();
                    for (int i = 0; i < exp.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + exp.Errors[i].Message + "\n" +
                            "LineNumber: " + exp.Errors[i].LineNumber + "\n" +
                            "Source: " + exp.Errors[i].Source + "\n" +
                            "Procedure: " + exp.Errors[i].Procedure + "\n");
                    }
                    MessageBox.Show(errorMessages.ToString());
                    this.toolStripStatusLabel1.Text = "连接失败！";
                    this.toolStripStatusLabel1.ForeColor = Color.Red;
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.chart1.ChartAreas[0].AxisX.ScaleView.Size = 100;
            this.chart1.ChartAreas[0].AxisX.ScaleView.Position = 1;
            this.chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            this.chart1.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
            chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
            // this.chart1.ChartAreas[0].AxisX.ScaleView.Size = tyData2.Count;
            // this.chart1.ChartAreas[0].AxisX.ScaleView.Position = 1;
            // this.chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            // this.chart1.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            // button2.PerformClick();
        }

        //AmpHours
        private void Button6_Click(object sender, EventArgs e)
        {
            txData2.Clear();
            tyData2.Clear();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        this.toolStripStatusLabel1.Text = "连接成功！";
                        this.toolStripStatusLabel1.ForeColor = Color.Green;
                        //查询表
                        string strCommand = "SELECT * FROM dbo.StackValues";
                        SqlCommand cmd = new SqlCommand(strCommand, connection);
                        //cmd.CommandText = strCommand; // cmd是sqlCommand对象
                        SqlDataAdapter da = new SqlDataAdapter(strCommand, connection);
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        //fill
                        //string txt="";
                        int n = dt.Rows.Count;
                        for (int i = 0; i < n; i++)
                        {
                            //add time
                            txData2.Add(dt.Rows[i][1].ToString());
                            //  txt += dt.Rows[i][1].ToString();
                            //add value
                            tyData2.Add(Math.Round(Convert.ToDouble(dt.Rows[i][8].ToString()), 2));
                        }
                        // this.textBox1.Text = txt;
                    }
                    else
                    {
                        this.toolStripStatusLabel1.Text = "未连接！" + connection.State.ToString();
                        this.toolStripStatusLabel1.ForeColor = Color.Red;
                    }
                }
                catch (SqlException exp)
                {
                    StringBuilder errorMessages = new StringBuilder();
                    for (int i = 0; i < exp.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + exp.Errors[i].Message + "\n" +
                            "LineNumber: " + exp.Errors[i].LineNumber + "\n" +
                            "Source: " + exp.Errors[i].Source + "\n" +
                            "Procedure: " + exp.Errors[i].Procedure + "\n");
                    }
                    MessageBox.Show(errorMessages.ToString());
                    this.toolStripStatusLabel1.Text = "连接失败！";
                    this.toolStripStatusLabel1.ForeColor = Color.Red;
                }
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox2.SelectedIndex.ToString());
        }

        //查询
        private void Button1_Click(object sender, EventArgs e)
        {
            string querysql = "SELECT * FROM[dbo].[EsuValues] where Esu_Id=" + this.comboBox3.Text + " AND datediff(day, [Timestamp],'" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')= 0 order by [Timestamp] ASC";
            DataQuery(querysql);
        }

        //SOC
        private void Button7_Click(object sender, EventArgs e)
        {
            txData2.Clear();
            tyData2.Clear();
            string conn = null;
            if (this.radioButton1.Checked)
            {
                //本地
                conn = connectionLocalStr;
            }
            else
            {
                //远程
                conn = connectionStr;
            }
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        this.toolStripStatusLabel1.Text = "连接成功！";
                        this.toolStripStatusLabel1.ForeColor = Color.Green;
                        //查询表
                        string strCommand = "SELECT * FROM[dbo].[EsuValues] where Esu_Id=" + this.comboBox3.Text + " AND datediff(day, [Timestamp],'" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')= 0 order by [Timestamp] ASC";
                        SqlCommand cmd = new SqlCommand(strCommand, connection);
                        //cmd.CommandText = strCommand; // cmd是sqlCommand对象
                        SqlDataAdapter da = new SqlDataAdapter(strCommand, connection);
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        //fill
                        //string txt="";
                        int n = dt.Rows.Count;
                        for (int i = 0; i < n; i++)
                        {
                            //add time
                            txData2.Add(dt.Rows[i][1].ToString());
                            //  txt += dt.Rows[i][1].ToString();
                            //add value
                            tyData2.Add(Math.Round(Convert.ToDouble(dt.Rows[i][9].ToString()), 2));
                        }
                        // this.textBox1.Text = txt;
                    }
                    else
                    {
                        this.toolStripStatusLabel1.Text = "未连接！" + connection.State.ToString();
                        this.toolStripStatusLabel1.ForeColor = Color.Red;
                    }
                }
                catch (SqlException exp)
                {
                    StringBuilder errorMessages = new StringBuilder();
                    for (int i = 0; i < exp.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + exp.Errors[i].Message + "\n" +
                            "LineNumber: " + exp.Errors[i].LineNumber + "\n" +
                            "Source: " + exp.Errors[i].Source + "\n" +
                            "Procedure: " + exp.Errors[i].Procedure + "\n");
                    }
                    MessageBox.Show(errorMessages.ToString());
                    this.toolStripStatusLabel1.Text = "连接失败！";
                    this.toolStripStatusLabel1.ForeColor = Color.Red;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionLocalStr))
            {
                try
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        // this.toolStripStatusLabel1.Text = "连接成功！";
                        //this.toolStripStatusLabel1.ForeColor = Color.Green;
                        this.button8.ForeColor = Color.Green;
                        //todo
                        DataTable dt = connection.GetSchema("Tables");
                        //用于存放表格的列表
                        List<string> tableNameList = new List<string>();
                        foreach (DataRow row in dt.Rows)
                        {
                            //得到表名
                            string tablename = (string)row[2];
                            MessageBox.Show(tablename);
                        }
                    }
                    else
                    {
                        //this.toolStripStatusLabel1.Text = "未连接！" + connection.State.ToString();
                        this.button8.ForeColor = Color.Red;
                    }
                }
                catch (SqlException exp)
                {
                    StringBuilder errorMessages = new StringBuilder();
                    for (int i = 0; i < exp.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + exp.Errors[i].Message + "\n" +
                            "LineNumber: " + exp.Errors[i].LineNumber + "\n" +
                            "Source: " + exp.Errors[i].Source + "\n" +
                            "Procedure: " + exp.Errors[i].Procedure + "\n");
                    }
                    MessageBox.Show(errorMessages.ToString());
                    //this.toolStripStatusLabel1.Text = "连接失败！";
                    this.button8.ForeColor = Color.Red;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult result =
         MessageBox.Show("确定初始化本地表吗？", "初始化", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Task t1 = Task.Factory.StartNew(() => {
                    LogMessage("<初始化本地表>");
                    InitalTable("dbo.EsuValues");
                    InitalTable("dbo.StackValues");
                    MessageBox.Show("初始化本地表完毕");
                });
            }
            else { return; }
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                //本地
                connected(0);
            }
            else
            {
                //远程
                connected(1);
            }
        }

        //SOC(a-b)
        private void button10_Click(object sender, EventArgs e)
        {
            txData2.Clear();
            tyData2.Clear();
            string conn = null;
            if (this.radioButton1.Checked)
            {
                //本地
                conn = connectionLocalStr;
            }
            else
            {
                //远程
                conn = connectionStr;
            }
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        this.toolStripStatusLabel1.Text = "连接成功！";
                        this.toolStripStatusLabel1.ForeColor = Color.Green;
                        //查询表
                        string strCommand = "SELECT * FROM [dbo].[EsuValues] where Esu_Id=" + this.comboBox3.Text + " AND ([Timestamp] between '" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and '" + this.dateTimePicker3.Value.ToString("yyyy-MM-dd") + "') order by [Timestamp] ASC";
                        SqlCommand cmd = new SqlCommand(strCommand, connection);
                        //cmd.CommandText = strCommand; // cmd是sqlCommand对象
                        SqlDataAdapter da = new SqlDataAdapter(strCommand, connection);
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        //fill
                        //string txt="";
                        int n = dt.Rows.Count;
                        for (int i = 0; i < n; i++)
                        {
                            //add time
                            txData2.Add(dt.Rows[i][1].ToString());
                            //  txt += dt.Rows[i][1].ToString();
                            //add value
                            tyData2.Add(Math.Round(Convert.ToDouble(dt.Rows[i][9].ToString()), 2));
                        }
                        // this.textBox1.Text = txt;
                    }
                    else
                    {
                        this.toolStripStatusLabel1.Text = "未连接！" + connection.State.ToString();
                        this.toolStripStatusLabel1.ForeColor = Color.Red;
                    }
                }
                catch (SqlException exp)
                {
                    StringBuilder errorMessages = new StringBuilder();
                    for (int i = 0; i < exp.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + exp.Errors[i].Message + "\n" +
                            "LineNumber: " + exp.Errors[i].LineNumber + "\n" +
                            "Source: " + exp.Errors[i].Source + "\n" +
                            "Procedure: " + exp.Errors[i].Procedure + "\n");
                    }
                    MessageBox.Show(errorMessages.ToString());
                    this.toolStripStatusLabel1.Text = "连接失败！";
                    this.toolStripStatusLabel1.ForeColor = Color.Red;
                }
            }
        }

        //查询(a-b)
        private void button11_Click(object sender, EventArgs e)
        {
            string querysql = "SELECT * FROM [dbo].[EsuValues] where Esu_Id=" + this.comboBox3.Text + " AND ([Timestamp] between '" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and '" + this.dateTimePicker3.Value.ToString("yyyy-MM-dd") + "') order by [Timestamp] ASC";
            MessageBox.Show(querysql);
            DataQuery(querysql);
        }


        // 查询(a-b)电压
        private void button12_Click(object sender, EventArgs e)
        {
            /// string querysql = "SELECT * FROM [dbo].[StackValues] where Stack_Id=" + this.comboBox4.Text + " AND  ([Timestamp] between '" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and '" + this.dateTimePicker3.Value.ToString("yyyy-MM-dd") + "') order by [Timestamp] ASC";
            // MessageBox.Show(querysql);
            // DataQuery(querysql);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode == null)
            { return; }
            this.chart1.Series.Clear();
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            chart1.ChartAreas[0].AxisX.Title = "时 间";
            chart1.ChartAreas[0].AxisY.Title = "电 压 V";
            if (this.treeView1.SelectedNode.Level != 1)
            { MessageBox.Show("请选择具体堆栈ID"); return; }
            if (this.tabControl1.SelectedIndex != 0)
            {
                this.tabControl1.SelectTab(0);
            }
            string Stack_Id = this.treeView1.SelectedNode.Text;
            string[] Stack_Id_num = Stack_Id.Split('_');
            //即可得到sArray[0]="GT123",sArray[1]="1";
            this.label10.Text = "cell";
            this.label11.Text = Stack_Id_num[1];
            string querysql = "SELECT DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),CellVoltages_Cell1,CellVoltages_Cell2,CellVoltages_Cell3,CellVoltages_Cell4,CellVoltages_Cell5,CellVoltages_Cell6,CellVoltages_Cell7,CellVoltages_Cell8,CellVoltages_Cell9,CellVoltages_Cell10,CellVoltages_Cell11,CellVoltages_Cell12,CellVoltages_Cell13,CellVoltages_Cell14,CellVoltages_Cell15,CellVoltages_Cell16,CellVoltages_Cell17,CellVoltages_Cell18,CellVoltages_Cell19,CellVoltages_Cell20,CellVoltages_Cell21,CellVoltages_Cell22,CellVoltages_Cell23,CellVoltages_Cell24,CellVoltages_Cell25,CellVoltages_Cell26,CellVoltages_Cell27,CellVoltages_Cell28,CellVoltages_Cell29,CellVoltages_Cell30 FROM [dbo].[StackValues] where Stack_Id=" + Stack_Id_num[1] + " AND  (DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) between '" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and '" + this.dateTimePicker3.Value.ToString("yyyy-MM-dd") + "') order by DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) ASC";
            //MessageBox.Show(querysql);
            DataTable dt = DataQueryTable(0, querysql);
            if (dt != null)
            {
                int n = dt.Rows.Count;
                if (n <= 0)
                {
                    MessageBox.Show("没有数据");
                    this.chart1.Titles[0].Text = "";
                    LogMessage("按钮<Cell电压图（a-b）> 没有查到数据。SQL：" + querysql);
                    return;
                }
                LogMessage("按钮<Cell电压图（a-b）> SQL：" + querysql);
                // MessageBox.Show(dt.TableName+"_"+n.ToString());
                this.chart1.Titles[0].Text = Stack_Id_num[1] + "#堆栈" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "到" + this.dateTimePicker3.Value.ToString("yyyy-MM-dd") + " CELL电压曲线";
                this.chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);//ZoomReset(0)表示撤销所有放大动作
                this.chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);//ZoomReset(1)表示撤销上一次放大动作
                for (int cellnum = 0; cellnum < 30; cellnum++)
                {
                    List<DateTime> x = new List<DateTime>(); List<double> y = new List<double>();
                    for (int i = 0; i < n; i++)
                    {
                        //add time
                        x.Add(Convert.ToDateTime(dt.Rows[i][0]));
                        //  txt += dt.Rows[i][1].ToString();
                        //add value
                        y.Add(Math.Round(Convert.ToDouble(dt.Rows[i][1 + cellnum].ToString()), 3));
                    }
                    drawLine_volt(cellnum, "Cell" + (cellnum + 1).ToString(), x, y);
                }
                if (System.IO.File.Exists("log"))
                {
                    this.BeginInvoke(new Action(() => {
                        genpic(this.chart1, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + this.chart1.Titles[0].Text);
                    }));
                }
                else
                {
                    //不存在文件
                    Directory.CreateDirectory("log");//创建该文件
                    this.BeginInvoke(new Action(() => {
                        genpic(this.chart1, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + this.chart1.Titles[0].Text);
                    }));
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode == null)
            { return; }
            this.chart1.Series.Clear();
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            if (this.treeView1.SelectedNode.Level != 1)
            { MessageBox.Show("请选择具体堆栈ID"); return; }
            if (this.tabControl1.SelectedIndex != 0)
            {
                this.tabControl1.SelectTab(0);
            }
            chart1.ChartAreas[0].AxisX.Title = "时 间";
            chart1.ChartAreas[0].AxisY.Title = "电 压 V";
            string Stack_Id = this.treeView1.SelectedNode.Text;
            string[] Stack_Id_num = Stack_Id.Split('_');
            this.label11.Text = Stack_Id_num[1];
            this.label10.Text = "cell";
            //即可得到sArray[0]="GT123",sArray[1]="1";
            string querysql = "SELECT DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),CellVoltages_Cell1,CellVoltages_Cell2,CellVoltages_Cell3,CellVoltages_Cell4,CellVoltages_Cell5,CellVoltages_Cell6,CellVoltages_Cell7,CellVoltages_Cell8,CellVoltages_Cell9,CellVoltages_Cell10,CellVoltages_Cell11,CellVoltages_Cell12,CellVoltages_Cell13,CellVoltages_Cell14,CellVoltages_Cell15,CellVoltages_Cell16,CellVoltages_Cell17,CellVoltages_Cell18,CellVoltages_Cell19,CellVoltages_Cell20,CellVoltages_Cell21,CellVoltages_Cell22,CellVoltages_Cell23,CellVoltages_Cell24,CellVoltages_Cell25,CellVoltages_Cell26,CellVoltages_Cell27,CellVoltages_Cell28,CellVoltages_Cell29,CellVoltages_Cell30 FROM [dbo].[StackValues] where Stack_Id=" + Stack_Id_num[1] + " AND  datediff(day, DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),'" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')= 0 order by DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) ASC";
            // MessageBox.Show(querysql);
            DataTable dt = DataQueryTable(0, querysql);
            if (dt != null)
            {
                int n = dt.Rows.Count;
                if (n <= 0)
                {
                    MessageBox.Show("没有数据");
                    this.chart1.Titles[0].Text = "";
                    LogMessage("按钮<Cell电压图> 没有查到数据。SQL：" + querysql);
                    return;
                }
                // MessageBox.Show(dt.TableName+"_"+n.ToString());
                LogMessage("按钮<Cell电压图> SQL：" + querysql);
                this.chart1.Titles[0].Text = Stack_Id_num[1] + "#堆栈" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + " CELL电压曲线";
                this.chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);//ZoomReset(0)表示撤销所有放大动作
                this.chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);//ZoomReset(1)表示撤销上一次放大动作
                for (int cellnum = 0; cellnum < 30; cellnum++)
                {
                    List<DateTime> x = new List<DateTime>(); List<double> y = new List<double>();
                    for (int i = 0; i < n; i++)
                    {
                        //add time
                        x.Add(Convert.ToDateTime(dt.Rows[i][0]));
                        //  txt += dt.Rows[i][1].ToString();
                        //add value
                        y.Add(Math.Round(Convert.ToDouble(dt.Rows[i][1 + cellnum].ToString()), 3));

                    }
                    drawLine_volt(cellnum, "Cell" + (cellnum + 1).ToString(), x, y);
                }
                if (System.IO.File.Exists("log"))
                {
                    this.BeginInvoke(new Action(() => {
                        genpic(this.chart1, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + this.chart1.Titles[0].Text);
                    }));
                }
                else
                {
                    //不存在文件
                    Directory.CreateDirectory("log");//创建该文件
                    this.BeginInvoke(new Action(() => {
                        genpic(this.chart1, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + this.chart1.Titles[0].Text);
                    }));
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.button15.Enabled = false;
            //查找需要更新的数量
            //本地表最大ID
            string sql = "select max(ID)from [dbo].[StackValues];";
            DataTable dt = null;
            dt = DataQueryTable(0, sql);


            //MessageBox.Show(dt.Rows[0][0].ToString());
            int localMaxID = Convert.ToInt32(dt.Rows[0][0]);
            //MessageBox.Show("local max ID:"+localMaxID.ToString());
            //远程最大ID
            dt = DataQueryTable(1, sql);

            int remoteMaxID = Convert.ToInt32(dt.Rows[0][0]);
            MessageBox.Show("local max ID:" + localMaxID.ToString() + "\n remote max ID:" + remoteMaxID.ToString());
            //查询数据
            sql = "select * from [dbo].[StackValues] where ID>" + localMaxID;
            dt = DataQueryTable(1, sql);
            //MessageBox.Show(dt.Rows[0][0].ToString());
            //fill local
            DialogResult result =
            MessageBox.Show("确定更新" + dt.Rows.Count.ToString() + "条记录吗？", "更新", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            LogMessage("<更新> 找到" + dt.Rows.Count.ToString() + "条记录需要更新");
            if (result == DialogResult.Yes)
            {
                Task t1 = Task.Factory.StartNew(() => {
                    SqlBulkCopyInsert(connectionLocalStr, "dbo.StackValues", dt);
                    MessageBox.Show("更新完毕");
                    LogMessage("<更新> 更新了" + dt.Rows.Count.ToString() + "条记录");
                    this.BeginInvoke(new Action(() => { this.button15.Enabled = true; }));
                });
            }
            else
            {
                this.button15.Enabled = true;
                return;
            }
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.chart1.Series.Count > 0)
            {
                this.chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
                this.chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
                this.chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                this.chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
                int _currentPointX = e.X;
                int _currentPointY = e.Y;
                this.chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(_currentPointX, _currentPointY), true);
                this.chart1.ChartAreas[0].CursorY.SetCursorPixelPosition(new PointF(_currentPointX, _currentPointY), true);
                //this.label2.Text = string.Format("{0},{1}", _currentPointX, _currentPointY);
                if (this.checkBox2.Checked)
                {
                    HitTestResult myTestResult = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);//获取命中测试的结果
                    if (myTestResult.ChartElementType == ChartElementType.DataPoint)
                    {
                        string showtext = "";
                        try
                        {
                            int i = myTestResult.PointIndex;
                            //时间
                            for (int j = 0; j < chart1.Series.Count; j++)
                            {
                                if (chart1.Series[j].Enabled)
                                {
                                    if (chart1.Series[j].Points.Count > 0)
                                    {
                                        DataPoint dp1 = chart1.Series[j].Points[i];
                                        showtext += chart1.Series[j].Name + ":" + dp1.YValues[0] + "\n";
                                    }
                                }
                            }
                        }
                        catch (Exception exp)
                        {
                            // MessageBox.Show(myTestResult.PointIndex.ToString()+ " " +exp.ToString()); 
                        }
                        toolTip.SetToolTip(this.chart1, showtext);
                    }
                }



                // toolTip.SetToolTip(this.chart1, showtext);
                // toolTip.Show(showtext, this.FormObjects.Win32Window, e.x + r.Left, e.y + r.Top);
                //this.label11.Text = "x:"+e.X.ToString()+"y:"+e.Y.ToString();
            }
            else
            {
                this.chart1.ChartAreas[0].CursorX.IsUserEnabled = false;
                this.chart1.ChartAreas[0].CursorY.IsUserEnabled = false;
                this.chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
                this.chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = false;
            }
        }

        private void chart2_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.chart2.Series.Count > 0)
            {
                this.chart2.ChartAreas[0].CursorX.IsUserEnabled = true;
                this.chart2.ChartAreas[0].CursorY.IsUserEnabled = true;
                this.chart2.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                this.chart2.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
                int _currentPointX = e.X;
                int _currentPointY = e.Y;
                this.chart2.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(_currentPointX, _currentPointY), true);
                this.chart2.ChartAreas[0].CursorY.SetCursorPixelPosition(new PointF(_currentPointX, _currentPointY), true);
                //this.label2.Text = string.Format("{0},{1}", _currentPointX, _currentPointY);
            }
            else
            {
                this.chart2.ChartAreas[0].CursorX.IsUserEnabled = false;
                this.chart2.ChartAreas[0].CursorY.IsUserEnabled = false;
                this.chart2.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
                this.chart2.ChartAreas[0].CursorY.IsUserSelectionEnabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.chart1.Series.Clear();
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            if (this.tabControl1.SelectedIndex != 0)
            {
                this.tabControl1.SelectTab(0);
            }
            chart1.ChartAreas[0].AxisX.Title = "时 间";
            chart1.ChartAreas[0].AxisY.Title = "电 压 V";
            this.chart1.Titles[0].Text = "堆栈" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 电压曲线";
            this.label10.Text = "stack";
            this.chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);//ZoomReset(0)表示撤销所有放大动作
            this.chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);//ZoomReset(1)表示撤销上一次放大动作
            string msginfo = "";
            for (int stack_id = 1; stack_id <= 12; stack_id++)
            {
                string querysql = "SELECT DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),Voltage FROM [dbo].[StackValues] where datediff(day, DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),'" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')= 0  AND Stack_Id=" + stack_id + " order by DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) ASC";
                //MessageBox.Show(querysql);
                DataTable dt = DataQueryTable(0, querysql);
                if (dt != null)
                {
                    int n = dt.Rows.Count;
                    if (n <= 0)
                    {
                        //MessageBox.Show("stack" + stack_id.ToString() + "没有数据");
                        msginfo += "stack" + stack_id.ToString() + "没有数据\n";
                        LogMessage("按钮<栈电压图> 没有查到数据。SQL：" + querysql);
                        //this.chart1.Titles[0].Text = "";
                        //return;
                    }
                    LogMessage("按钮<栈电压图> SQL：" + querysql);
                    List<DateTime> x = new List<DateTime>(); List<double> y = new List<double>();
                    for (int i = 0; i < n; i++)
                    {
                        //add time
                        x.Add(Convert.ToDateTime(dt.Rows[i][0]));
                        //  txt += dt.Rows[i][1].ToString();
                        //add value
                        y.Add(Math.Round(Convert.ToDouble(dt.Rows[i][1].ToString()), 3));
                    }
                    drawLine_volt(stack_id - 1, "stack" + stack_id.ToString(), x, y);
                }
                else { break; }
            }
            if (msginfo != "")
            {
                MessageBox.Show(msginfo);
            }
            if (System.IO.File.Exists("log"))
            {
                this.BeginInvoke(new Action(() => {
                    genpic(this.chart1, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + this.chart1.Titles[0].Text);
                }));
            }
            else
            {
                //不存在文件
                Directory.CreateDirectory("log");//创建该文件
                this.BeginInvoke(new Action(() => {
                    genpic(this.chart1, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + this.chart1.Titles[0].Text);
                }));
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.chart1.Series.Clear();
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            if (this.tabControl1.SelectedIndex != 0)
            {
                this.tabControl1.SelectTab(0);
            }
            chart1.ChartAreas[0].AxisX.Title = "时 间";
            chart1.ChartAreas[0].AxisY.Title = "电 压 V";
            this.chart1.Titles[0].Text = "堆栈" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "到" + this.dateTimePicker3.Value.ToString("yyyy-MM-dd") + " 电压曲线";
            this.label10.Text = "stack";
            this.chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);//ZoomReset(0)表示撤销所有放大动作
            this.chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);//ZoomReset(1)表示撤销上一次放大动作
            string msginfo = "";
            for (int stack_id = 1; stack_id <= 12; stack_id++)
            {
                string querysql = "SELECT DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),Voltage FROM [dbo].[StackValues] where (DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) between '" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and '" + this.dateTimePicker3.Value.ToString("yyyy-MM-dd") + "') AND Stack_Id=" + stack_id + " order by DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) ASC";
                //MessageBox.Show(querysql);
                DataTable dt = DataQueryTable(0, querysql);
                if (dt != null)
                {
                    int n = dt.Rows.Count;
                    if (n <= 0)
                    {
                        //MessageBox.Show("stack" + stack_id.ToString() + "没有数据");
                        msginfo += "stack" + stack_id.ToString() + "没有数据\n";
                        //this.chart1.Titles[0].Text = "";
                        //return;
                        LogMessage("按钮<栈电压图（a-b）> 没有查到数据。SQL：" + querysql);
                    }
                    List<DateTime> x = new List<DateTime>(); List<double> y = new List<double>();
                    LogMessage("按钮<栈电压图（a-b）> SQL：" + querysql);
                    for (int i = 0; i < n; i++)
                    {
                        //add time
                        x.Add(Convert.ToDateTime(dt.Rows[i][0]));
                        //  txt += dt.Rows[i][1].ToString();
                        //add value
                        y.Add(Math.Round(Convert.ToDouble(dt.Rows[i][1].ToString()), 3));
                    }
                    drawLine_volt(stack_id - 1, "stack" + stack_id.ToString(), x, y);
                }
                else { break; }
            }
            if (msginfo != "")
            {
                MessageBox.Show(msginfo);
            }
            if (System.IO.File.Exists("log"))
            {
                this.BeginInvoke(new Action(() => {
                    genpic(this.chart1, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + this.chart1.Titles[0].Text);
                }));
            }
            else
            {
                //不存在文件
                Directory.CreateDirectory("log");//创建该文件
                this.BeginInvoke(new Action(() => {
                    genpic(this.chart1, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + this.chart1.Titles[0].Text);
                }));
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.label9.Text = this.treeView1.SelectedNode.FullPath;
            TreeNode Fnode = this.treeView1.Nodes[0];
            Fnode.BackColor = Color.Gray;
            for (int i = 0; i < 12; i++)
            {
                Fnode.Nodes[i].BackColor = Color.Gray;
                for (int j = 0; j < 30; j++)
                {
                    Fnode.Nodes[i].Nodes[j].BackColor = Color.Gray;
                    // this.treeView1.Nodes[0].BackColor = Color.White;
                }
            }
            //图标保持不变
            this.treeView1.SelectedNode.SelectedImageIndex = this.treeView1.SelectedNode.Level;
            if (this.tabControl1.SelectedIndex == 0)//电压
            {
                if (this.chart1.Series.Count > 0)
                {
                    int n = this.chart1.Series.Count;
                    if (this.label10.Text == "cell")
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.chart1.Series[i].Enabled = false;
                        }
                        //MessageBox.Show(this.comboBox5.SelectedIndex.ToString());
                        if (this.treeView1.SelectedNode.Level == 1 && (this.treeView1.SelectedNode.Index + 1).ToString() == this.label11.Text)
                        {
                            for (int i = 0; i < n; i++)
                            {
                                this.chart1.Series[i].Enabled = true;
                            }
                            LogMessage("在电压标签状态下，标志是cell时选中了" + this.label11.Text + "#堆栈");
                        }
                        else if (this.treeView1.SelectedNode.Level == 2 && (this.treeView1.SelectedNode.Parent.Index + 1).ToString() == this.label11.Text)
                        {
                            this.chart1.Series[this.treeView1.SelectedNode.Index].Enabled = true;
                            LogMessage("在电压标签状态下，标志是cell时选中了" + this.label11.Text + "#堆栈里的cell" + (this.treeView1.SelectedNode.Index + 1).ToString());
                        }
                        else
                        {
                            ;
                            //MessageBox.Show("请选择正确堆栈号节点");
                        }
                    }
                    else if (this.label10.Text == "stack")
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.chart1.Series[i].Enabled = false;
                        }
                        //MessageBox.Show(this.comboBox5.SelectedIndex.ToString());
                        if (this.treeView1.SelectedNode.Level == 0)//gs200
                        {
                            for (int i = 0; i < n; i++)
                            {
                                this.chart1.Series[i].Enabled = true;
                            }
                            LogMessage("在电压标签状态下，标志是stack时，选中了所有堆栈");
                        }
                        else if (this.treeView1.SelectedNode.Level == 1)//stack
                        {
                            //查找选中的index是否和chart1里的Series的线段名一致
                            bool isfind = false;
                            for (int i = 0; i < n; i++)
                            {
                                // MessageBox.Show("stack" + (this.treeView1.SelectedNode.Index + 1).ToString() +"__"+ this.chart1.Series[i].Name);
                                //index从0开始，实际是1开始
                                if ("stack" + (this.treeView1.SelectedNode.Index + 1).ToString() == this.chart1.Series[i].Name)
                                {
                                    //找到了
                                    this.chart1.Series[this.treeView1.SelectedNode.Index].Enabled = true;
                                    isfind = true;
                                    break;
                                }
                            }

                            if (!isfind)
                            {
                                MessageBox.Show("没有找到堆栈" + (this.treeView1.SelectedNode.Index + 1).ToString() + "数据");
                                LogWarning("在电压标签状态下，标志是stack时，没有找到" + (this.treeView1.SelectedNode.Index + 1).ToString() + "#堆栈数据");
                            }
                            else
                            {
                                LogMessage("在电压标签状态下，标志是stack时，选中了" + (this.treeView1.SelectedNode.Index + 1).ToString() + "#堆栈");
                            }
                        }
                        else if (this.treeView1.SelectedNode.Level == 2)//cell
                        {
                            //查找选中的index是否和chart1里的Series的线段名一致
                            bool isfind = false;
                            for (int i = 0; i < n; i++)
                            {
                                // MessageBox.Show("stack" + (this.treeView1.SelectedNode.Index + 1).ToString() +"__"+ this.chart1.Series[i].Name);
                                //index从0开始，实际是1开始
                                if ("stack" + (this.treeView1.SelectedNode.Parent.Index + 1).ToString() == this.chart1.Series[i].Name)
                                {
                                    //找到了
                                    this.chart1.Series[this.treeView1.SelectedNode.Parent.Index].Enabled = true;
                                    isfind = true;
                                    break;
                                }
                            }
                            if (!isfind)
                            {
                                MessageBox.Show("没有找到堆栈" + (this.treeView1.SelectedNode.Parent.Index + 1).ToString() + "数据");
                                LogWarning("在电压标签状态下，标志是stack时，没有找到" + (this.treeView1.SelectedNode.Parent.Index + 1).ToString() + "#堆栈数据");
                            }
                            else
                            {
                                LogMessage("在电压标签状态下，标志是stack时，选中了" + (this.treeView1.SelectedNode.Parent.Index + 1).ToString() + "#堆栈");
                            }
                        }
                        else
                        {; }
                    }
                }
            }
            else if (this.tabControl1.SelectedIndex == 1) //温度
            {
                if (this.chart2.Series.Count > 0)
                {
                    int n = this.chart2.Series.Count;
                    for (int i = 0; i < n; i++)
                    {
                        this.chart2.Series[i].Enabled = false;
                    }
                    if (this.treeView1.SelectedNode.Level == 0)//gs200
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.chart2.Series[i].Enabled = true;
                        }
                        LogMessage("在温度标签状态下，选中了" + "整个堆栈");
                    }
                    else if (this.treeView1.SelectedNode.Level == 1)//stack
                    {
                        //查找选中的index是否和chart2里的Series的线段名一致
                        bool isfind = false;
                        for (int i = 0; i < n; i++)
                        {
                            //MessageBox.Show("stack" + (this.treeView1.SelectedNode.Index + 1).ToString() +"__"+ this.chart2.Series[i].Name);
                            //index从0开始，实际是1开始
                            if ("stack" + (this.treeView1.SelectedNode.Index + 1).ToString() == this.chart2.Series[i].Name)
                            {
                                //找到了
                                this.chart2.Series[this.treeView1.SelectedNode.Index].Enabled = true;
                                isfind = true;
                                break;
                            }
                        }
                        if (!isfind)
                        {
                            MessageBox.Show("没有找到堆栈" + (this.treeView1.SelectedNode.Index + 1).ToString() + "数据");
                            LogWarning("在温度标签状态下没有找到" + (this.treeView1.SelectedNode.Index + 1).ToString() + "#堆栈的数据");
                        }
                        else
                        {
                            LogMessage("在温度标签状态下，选中了" + (this.treeView1.SelectedNode.Index + 1).ToString() + "#堆栈");
                        }

                    }
                    else if (this.treeView1.SelectedNode.Level == 2)//cell
                    {
                        //查找选中的index是否和chart1里的Series的线段名一致
                        bool isfind = false;
                        for (int i = 0; i < n; i++)
                        {
                            // MessageBox.Show("stack" + (this.treeView1.SelectedNode.Index + 1).ToString() +"__"+ this.chart1.Series[i].Name);
                            //index从0开始，实际是1开始
                            if ("stack" + (this.treeView1.SelectedNode.Parent.Index + 1).ToString() == this.chart2.Series[i].Name)
                            {
                                //找到了
                                this.chart2.Series[this.treeView1.SelectedNode.Parent.Index].Enabled = true;
                                isfind = true;
                                break;
                            }
                        }
                        if (!isfind)
                        {
                            MessageBox.Show("没有找到堆栈" + (this.treeView1.SelectedNode.Parent.Index + 1).ToString() + "数据");
                            LogWarning("在温度标签状态下没有找到" + (this.treeView1.SelectedNode.Parent.Index + 1).ToString() + "#堆栈的数据");
                        }
                        else
                        {
                            LogMessage("在温度标签状态下，选中了" + (this.treeView1.SelectedNode.Parent.Index + 1).ToString() + "#堆栈");
                        }
                    }
                    else
                    {; }
                }
            }

            //
            else if (this.tabControl1.SelectedIndex == 2) //soc
            {
                if (this.chart3.Series.Count > 0)
                {
                    int n = this.chart3.Series.Count;
                    for (int i = 0; i < n; i++)
                    {
                        this.chart3.Series[i].Enabled = false;
                    }
                    if (this.treeView1.SelectedNode.Level == 0)//gs200
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.chart3.Series[i].Enabled = true;
                        }
                        LogMessage("在SOC标签状态下，选中了" + "整个堆栈");
                    }
                    else if (this.treeView1.SelectedNode.Level == 1)//stack
                    {
                        //查找选中的index是否和chart3里的Series的线段名一致
                        bool isfind = false;
                        for (int i = 0; i < n; i++)
                        {
                            //MessageBox.Show("stack" + (this.treeView1.SelectedNode.Index + 1).ToString() +"__"+ this.chart2.Series[i].Name);
                            //index从0开始，实际是1开始
                            if ("stack" + (this.treeView1.SelectedNode.Index + 1).ToString() == this.chart3.Series[i].Name)
                            {
                                //找到了
                                this.chart3.Series[this.treeView1.SelectedNode.Index].Enabled = true;
                                isfind = true;
                                break;
                            }
                        }
                        if (!isfind)
                        {
                            MessageBox.Show("没有找到堆栈" + (this.treeView1.SelectedNode.Index + 1).ToString() + "数据");
                            LogWarning("在SOC标签状态下没有找到" + (this.treeView1.SelectedNode.Index + 1).ToString() + "#堆栈的数据");
                        }
                        else
                        {
                            LogMessage("在SOC标签状态下，选中了" + (this.treeView1.SelectedNode.Index + 1).ToString() + "#堆栈");
                        }

                    }
                    else if (this.treeView1.SelectedNode.Level == 2)//cell
                    {
                        //查找选中的index是否和chart1里的Series的线段名一致
                        bool isfind = false;
                        for (int i = 0; i < n; i++)
                        {
                            // MessageBox.Show("stack" + (this.treeView1.SelectedNode.Index + 1).ToString() +"__"+ this.chart1.Series[i].Name);
                            //index从0开始，实际是1开始
                            if ("stack" + (this.treeView1.SelectedNode.Parent.Index + 1).ToString() == this.chart3.Series[i].Name)
                            {
                                //找到了
                                this.chart3.Series[this.treeView1.SelectedNode.Parent.Index].Enabled = true;
                                isfind = true;
                                break;
                            }
                        }
                        if (!isfind)
                        {
                            MessageBox.Show("没有找到堆栈" + (this.treeView1.SelectedNode.Parent.Index + 1).ToString() + "数据");
                            LogWarning("在SOC标签状态下没有找到" + (this.treeView1.SelectedNode.Parent.Index + 1).ToString() + "#堆栈的数据");
                        }
                        else
                        {
                            LogMessage("在SOC标签状态下，选中了" + (this.treeView1.SelectedNode.Parent.Index + 1).ToString() + "#堆栈");
                        }
                    }
                }
            }
        }

        private void treeView1_Leave(object sender, EventArgs e)
        {
            TreeNode Fnode = this.treeView1.Nodes[0];
            Fnode.BackColor = Color.Gray;
            for (int i = 0; i < 12; i++)
            {
                Fnode.Nodes[i].BackColor = Color.Gray;
                for (int j = 0; j < 30; j++)
                {
                    Fnode.Nodes[i].Nodes[j].BackColor = Color.Gray;
                    // this.treeView1.Nodes[0].BackColor = Color.White;
                }
            }
            if (this.treeView1.SelectedNode != null)
                this.treeView1.SelectedNode.BackColor = Color.DodgerBlue;
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            this.chart2.Series.Clear();
            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            if (this.tabControl1.SelectedIndex != 1)
            {
                this.tabControl1.SelectTab(1);
            }
            chart2.ChartAreas[0].AxisX.Title = "时 间";
            chart2.ChartAreas[0].AxisY.Title = "温 度 ℃";
            // MessageBox.Show(dt.TableName+"_"+n.ToString());
            this.chart2.Titles[0].Text = "堆栈" + this.dateTimePicker4.Value.ToString("yyyy-MM-dd") + " 温度曲线";
            this.chart2.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);//ZoomReset(0)表示撤销所有放大动作
            this.chart2.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);//ZoomReset(1)表示撤销上一次放大动作
            string msginfo = "";
            for (int stack_id = 1; stack_id <= 12; stack_id++)
            {
                string querysql = "SELECT DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),Temperature FROM [dbo].[StackValues] where datediff(day, DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),'" + this.dateTimePicker4.Value.ToString("yyyy-MM-dd") + "')= 0  AND Stack_Id=" + stack_id + " order by DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) ASC";
                //MessageBox.Show(querysql);
                DataTable dt = DataQueryTable(0, querysql);
                if (dt != null)
                {
                    int n = dt.Rows.Count;
                    if (n <= 0)
                    {
                        //MessageBox.Show("stack" + stack_id.ToString() + "没有数据");
                        msginfo += "stack" + stack_id.ToString() + "没有数据\n";
                        //this.chart1.Titles[0].Text = "";
                        //return;
                        LogMessage("按钮<栈温度图> 没有查到数据。SQL：" + querysql);
                    }
                    LogMessage("按钮<栈温度图> SQL：" + querysql);
                    List<DateTime> x = new List<DateTime>(); List<double> y = new List<double>();
                    for (int i = 0; i < n; i++)
                    {
                        //add time
                        x.Add(Convert.ToDateTime(dt.Rows[i][0]));
                        //  txt += dt.Rows[i][1].ToString();
                        //add value
                        y.Add(Math.Round(Convert.ToDouble(dt.Rows[i][1].ToString()), 3));

                    }
                    drawLine_temp(stack_id - 1, "stack" + stack_id.ToString(), x, y);
                }
                else { break; }
            }
            if (msginfo != "")
            {
                MessageBox.Show(msginfo);
            }
            if (System.IO.File.Exists("log"))
            {
                this.BeginInvoke(new Action(() => {
                    genpic(this.chart2, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + this.chart2.Titles[0].Text);
                }));
            }
            else
            {
                //不存在文件
                Directory.CreateDirectory("log");//创建该文件
                this.BeginInvoke(new Action(() => {
                    genpic(this.chart2, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + this.chart2.Titles[0].Text);
                }));
            }
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            this.chart2.Series.Clear();
            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }

            if (this.tabControl1.SelectedIndex != 1)
            {
                this.tabControl1.SelectTab(1);
            }
            chart2.ChartAreas[0].AxisX.Title = "时 间";
            chart2.ChartAreas[0].AxisY.Title = "温 度 ℃";
            // MessageBox.Show(dt.TableName+"_"+n.ToString());
            this.chart2.Titles[0].Text = "堆栈" + this.dateTimePicker6.Value.ToString("yyyy-MM-dd") + "到" + this.dateTimePicker5.Value.ToString("yyyy-MM-dd") + " 温度曲线";
            this.chart2.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);//ZoomReset(0)表示撤销所有放大动作
            this.chart2.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);//ZoomReset(1)表示撤销上一次放大动作
            string msginfo = "";
            for (int stack_id = 1; stack_id <= 12; stack_id++)
            {
                string querysql = "SELECT DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),Temperature FROM [dbo].[StackValues] where (DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) between '" + this.dateTimePicker6.Value.ToString("yyyy-MM-dd") + "' and '" + this.dateTimePicker5.Value.ToString("yyyy-MM-dd") + "')  AND Stack_Id=" + stack_id + " order by DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) ASC";
                //MessageBox.Show(querysql);
                DataTable dt = DataQueryTable(0, querysql);
                if (dt != null)
                {
                    int n = dt.Rows.Count;
                    if (n <= 0)
                    {
                        // MessageBox.Show("stack" + stack_id.ToString() + "没有数据");
                        msginfo += "stack" + stack_id.ToString() + "没有数据\n";
                        //this.chart1.Titles[0].Text = "";
                        //return;
                        LogMessage("按钮<栈温度图（a-b）> 没有查到数据。SQL：" + querysql);
                    }
                    List<DateTime> x = new List<DateTime>(); List<double> y = new List<double>();
                    LogMessage("按钮<栈温度图（a-b）> SQL：" + querysql);
                    for (int i = 0; i < n; i++)
                    {
                        //add time
                        x.Add(Convert.ToDateTime(dt.Rows[i][0]));
                        //  txt += dt.Rows[i][1].ToString();
                        //add value
                        y.Add(Math.Round(Convert.ToDouble(dt.Rows[i][1].ToString()), 3));
                    }
                    drawLine_temp(stack_id - 1, "stack" + stack_id.ToString(), x, y);
                }
                else { break; }
            }
            if (msginfo != "")
            {
                MessageBox.Show(msginfo);
            }
            if (System.IO.File.Exists("log"))
            {
                this.BeginInvoke(new Action(() => {
                    genpic(this.chart2, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + this.chart2.Titles[0].Text);
                }));
            }
            else
            {
                //不存在文件
                Directory.CreateDirectory("log");//创建该文件
                this.BeginInvoke(new Action(() => {
                    genpic(this.chart2, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + this.chart2.Titles[0].Text);
                }));
            }
        }
        //soc
        private void button20_Click(object sender, EventArgs e)
        {
            this.chart3.Series.Clear();
            foreach (var series in chart3.Series)
            {
                series.Points.Clear();
            }

            if (this.tabControl1.SelectedIndex != 2)
            {
                this.tabControl1.SelectTab(2);
            }
            chart3.ChartAreas[0].AxisX.Title = "时 间";
            chart3.ChartAreas[0].AxisY.Title = "S O C %";
            // MessageBox.Show(dt.TableName+"_"+n.ToString());
            this.chart3.Titles[0].Text = "堆栈" + this.dateTimePicker9.Value.ToString("yyyy-MM-dd") + " SOC曲线";
            this.chart3.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);//ZoomReset(0)表示撤销所有放大动作
            this.chart3.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);//ZoomReset(1)表示撤销上一次放大动作
            string msginfo = "";
            for (int stack_id = 1; stack_id <= 12; stack_id++)
            {
                string querysql = "SELECT DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),StateOfCharge FROM [dbo].[StackValues] where datediff(day, DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),'" + this.dateTimePicker9.Value.ToString("yyyy-MM-dd") + "')= 0  AND Stack_Id=" + stack_id + " order by DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) ASC";
                //MessageBox.Show(querysql);
                DataTable dt = DataQueryTable(0, querysql);
                if (dt != null)
                {
                    int n = dt.Rows.Count;
                    if (n <= 0)
                    {
                        //MessageBox.Show("stack" + stack_id.ToString() + "没有数据");
                        msginfo += "stack" + stack_id.ToString() + "没有数据\n";
                        //this.chart1.Titles[0].Text = "";
                        //return;
                        LogMessage("按钮<栈SOC图> 没有查到数据。SQL：" + querysql);
                    }
                    LogMessage("按钮<栈SOC图> SQL：" + querysql);
                    List<DateTime> x = new List<DateTime>(); List<double> y = new List<double>();
                    for (int i = 0; i < n; i++)
                    {
                        //add time
                        x.Add(Convert.ToDateTime(dt.Rows[i][0]));
                        //  txt += dt.Rows[i][1].ToString();
                        //add value
                        y.Add(Math.Round(Convert.ToDouble(dt.Rows[i][1].ToString()), 3));
                    }
                    drawLine_SOC(stack_id - 1, "stack" + stack_id.ToString(), x, y);
                }
                else { break; }
            }
            if (msginfo != "")
            {
                MessageBox.Show(msginfo);
            }
            if (System.IO.Directory.Exists("log"))
            {
                this.BeginInvoke(new Action(() => {
                    genpic(this.chart3, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + this.chart3.Titles[0].Text);
                }));
            }
            else
            {
                //不存在文件
                Directory.CreateDirectory("log");//创建该文件
                this.BeginInvoke(new Action(() => {
                    genpic(this.chart3, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + this.chart3.Titles[0].Text);
                }));
            }
        }

        private void chart3_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.chart3.Series.Count > 0)
            {
                this.chart3.ChartAreas[0].CursorX.IsUserEnabled = true;
                this.chart3.ChartAreas[0].CursorY.IsUserEnabled = true;
                this.chart3.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                this.chart3.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
                int _currentPointX = e.X;
                int _currentPointY = e.Y;
                this.chart3.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(_currentPointX, _currentPointY), true);
                this.chart3.ChartAreas[0].CursorY.SetCursorPixelPosition(new PointF(_currentPointX, _currentPointY), true);
                //this.label2.Text = string.Format("{0},{1}", _currentPointX, _currentPointY);
            }
            else
            {
                this.chart3.ChartAreas[0].CursorX.IsUserEnabled = false;
                this.chart3.ChartAreas[0].CursorY.IsUserEnabled = false;
                this.chart3.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
                this.chart3.ChartAreas[0].CursorY.IsUserSelectionEnabled = false;
            }

        }
        //soc a-b
        private void button19_Click(object sender, EventArgs e)
        {
            this.chart3.Series.Clear();
            foreach (var series in chart3.Series)
            {
                series.Points.Clear();
            }

            if (this.tabControl1.SelectedIndex != 2)
            {
                this.tabControl1.SelectTab(2);
            }
            chart3.ChartAreas[0].AxisX.Title = "时 间";
            chart3.ChartAreas[0].AxisY.Title = "S O C %";
            // MessageBox.Show(dt.TableName+"_"+n.ToString());
            this.chart3.Titles[0].Text = "堆栈" + this.dateTimePicker7.Value.ToString("yyyy-MM-dd") + "到" + this.dateTimePicker8.Value.ToString("yyyy-MM-dd") + " SOC曲线";
            this.chart3.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);//ZoomReset(0)表示撤销所有放大动作
            this.chart3.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);//ZoomReset(1)表示撤销上一次放大动作
            string msginfo = "";
            for (int stack_id = 1; stack_id <= 12; stack_id++)
            {
                string querysql = "SELECT DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),StateOfCharge FROM [dbo].[StackValues] where (DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) between '" + this.dateTimePicker7.Value.ToString("yyyy-MM-dd") + "' and '" + this.dateTimePicker8.Value.ToString("yyyy-MM-dd") + "')  AND Stack_Id=" + stack_id + " order by DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) ASC";
                //MessageBox.Show(querysql);
                DataTable dt = DataQueryTable(0, querysql);
                if (dt != null)
                {
                    int n = dt.Rows.Count;
                    if (n <= 0)
                    {
                        //MessageBox.Show("stack" + stack_id.ToString() + "没有数据");
                        msginfo += "stack" + stack_id.ToString() + "没有数据\n";
                        //this.chart1.Titles[0].Text = "";
                        //return;
                        LogMessage("按钮<栈SOC图（a-b）> 没有查到数据。SQL：" + querysql);
                    }
                    List<DateTime> x = new List<DateTime>(); List<double> y = new List<double>();
                    LogMessage("按钮<栈SOC图（a-b）> SQL：" + querysql);
                    for (int i = 0; i < n; i++)
                    {
                        //add time
                        x.Add(Convert.ToDateTime(dt.Rows[i][0]));
                        //  txt += dt.Rows[i][1].ToString();
                        //add value
                        y.Add(Math.Round(Convert.ToDouble(dt.Rows[i][1].ToString()), 3));

                    }
                    drawLine_SOC(stack_id - 1, "stack" + stack_id.ToString(), x, y);
                }
                else { break; }
            }
            if (msginfo != "")
            {
                MessageBox.Show(msginfo);
            }
            if (System.IO.Directory.Exists("log"))
            {
                this.BeginInvoke(new Action(() => {
                    genpic(this.chart3, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + this.chart3.Titles[0].Text);
                }));
            }
            else
            {
                //不存在文件
                Directory.CreateDirectory("log");//创建该文件
                this.BeginInvoke(new Action(() => {
                    genpic(this.chart3, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + this.chart3.Titles[0].Text);
                    // MessageBox.Show("创建log文件，截图成功");
                }));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogMessage("关闭程序");
        }

        private void 保存图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string whichcontrol_name = contextMenuStrip1.SourceControl.Name.Trim();
            Chart chart = (Chart)this.tabControl1.Controls.Find(whichcontrol_name, true)[0];
            if (chart.Series.Count > 0)
            {
                if (System.IO.Directory.Exists("log"))
                {
                    this.BeginInvoke(new Action(() => {
                        genpic(chart, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + chart.Titles[0].Text);
                        MessageBox.Show("截图成功");
                    }));
                }
                else
                {
                    //不存在文件
                    Directory.CreateDirectory("log");//创建该文件
                    this.BeginInvoke(new Action(() => {
                        genpic(chart, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + chart.Titles[0].Text);
                        MessageBox.Show("创建log文件，截图成功");
                    }));
                }
            }

        }

        private void 还原toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string whichcontrol_name = contextMenuStrip1.SourceControl.Name.Trim();
            Chart chart = (Chart)this.tabControl1.Controls.Find(whichcontrol_name, true)[0];
            if (chart.Series.Count > 0)
            {
                chart.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);//ZoomReset(0)表示撤销所有放大动作
                chart.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);//ZoomReset(1)表示撤销上一次放大动作
            }

        }

        private void button21_Click(object sender, EventArgs e)
        {
            string sql = "select max(ID)from [dbo].[StackValues];";
            DataTable dt = null;
            int localMaxID = 0;
            Task t2 = Task.Factory.StartNew(() => {
                dt = DataQueryTable(0, sql);
                //MessageBox.Show(dt.Rows[0][0].ToString());
                this.BeginInvoke(new Action(() => {
                    localMaxID = Convert.ToInt32(dt.Rows[0][0]);
                    //MessageBox.Show(localMaxID.ToString());
                    for (int i = 0; i < 9000000; i++)
                    { string a = ""; a = a + i.ToString(); }
                    this.button21.Text = localMaxID.ToString();
                    MessageBox.Show(localMaxID.ToString());
                }));

            }
             );



        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (this.pwdbox.Visible && this.pwdbtn.Visible)
            {
                this.pwdbox.Visible = false;
                this.pwdbtn.Visible = false;
            }
            else
            {
                this.pwdbox.Visible = true;
                this.pwdbtn.Visible = true;
            }

        }

        private void pwdbtn_Click(object sender, EventArgs e)
        {
            if (this.pwdbox.Text.Trim() == "111")
            {
                this.panel8.Visible = true;
                this.pwdbox.Text = null;
                this.pwdbox.Visible = false;
                this.pwdbtn.Visible = false;
                this.button1.BackColor = Color.FromArgb(40, 40, 40);
            }
            else
            {
                this.panel8.Visible = false;
                this.pwdbox.Text = null;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.panel8.Visible = false;
            this.pwdbox.Visible = false;
            this.pwdbox.Text = null;
            this.pwdbtn.Visible = false;
            this.button1.BackColor = Color.FromArgb(64, 64, 64);
            this.tabControl1.Refresh();//刷新界面

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minbtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maxbtn_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.maxbtn.Text = "◻";
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                this.WindowState = FormWindowState.Maximized;
                this.maxbtn.Text = "◱";
            }
        }


        #region 无边框拖动效果
        [DllImport("user32.dll")]//拖动无窗体的控件
        private extern static void ReleaseCapture();
        [DllImport("user32.dll")]
        private extern static void SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int HTCAPTION = 0x0002;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //拖动窗体
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        #endregion

        //FormBorderStyle.None时，支持改变窗体大小
        #region 支持改变窗体大小
        private const int Guying_HTLEFT = 10;
        private const int Guying_HTRIGHT = 11;
        private const int Guying_HTTOP = 12;
        private const int Guying_HTTOPLEFT = 13;
        private const int Guying_HTTOPRIGHT = 14;
        private const int Guying_HTBOTTOM = 15;
        private const int Guying_HTBOTTOMLEFT = 0x10;
        private const int Guying_HTBOTTOMRIGHT = 17;


        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF, (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMLEFT;
                        else
                            m.Result = (IntPtr)Guying_HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMRIGHT;
                        else
                            m.Result = (IntPtr)Guying_HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)Guying_HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)Guying_HTBOTTOM;
                    break;
                case 0x0201://鼠标左键按下的消息
                    m.Msg = 0x00A1;//更改消息为非客户区按下鼠标
                    m.LParam = IntPtr.Zero; //默认值
                    m.WParam = new IntPtr(2);//鼠标放在标题栏内
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        #endregion

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (this.splitContainer1.Panel2Collapsed)
            {
                this.splitContainer1.Panel2Collapsed = false;
                this.button6.ForeColor = Color.DodgerBlue;
            }
            else
            {
                this.splitContainer1.Panel2Collapsed = true;
                this.button6.ForeColor = Color.White;

            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {


            //获取TabControl主控件的工作区域
            Rectangle rec = tabControl1.ClientRectangle;

            //标签背景填充颜色
            SolidBrush BackBrush = new SolidBrush(Color.Gray);
            SolidBrush BackBrush1 = new SolidBrush(Color.DarkGray);
            //标签背景色
            e.Graphics.FillRectangle(BackBrush, 0, 0, tabControl1.Width, tabControl1.Height);
            //e.Graphics.DrawString(tabControl1.Name, new Font("宋体", 9), BackBrus1, tabControl1.Width, tabControl1.Height);
            //标签文字填充颜色
            SolidBrush FrontBrush = new SolidBrush(Color.White);
            SolidBrush FrontBrush0 = new SolidBrush(Color.WhiteSmoke);
            StringFormat StringF = new StringFormat();
            //设置文字对齐方式
            StringF.Alignment = StringAlignment.Center;
            StringF.LineAlignment = StringAlignment.Center;

            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                //获取标签头工作区域
                Rectangle Rec = tabControl1.GetTabRect(i);
                //绘制标签头背景颜色
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(115, 115, 115)), Rec);
                //绘制标签头文字
                e.Graphics.DrawString(tabControl1.TabPages[i].Text, new Font("宋体", 8), FrontBrush0, Rec, StringF);
                //e.Graphics.DrawString(((TabControl)sender).TabPages[e.Index].Text,System.Windows.Forms.SystemInformation.MenuFont, new SolidBrush(Color.WhiteSmoke), e.Bounds, StringF);
            }

            if (e.Index == tabControl1.SelectedIndex)
            {
                e.Graphics.FillRectangle(Brushes.DimGray, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                //tabControl1.GetTabRect(e.Index).Inflate(4, 4);
                e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, new Font("宋体", 9), FrontBrush, tabControl1.GetTabRect(e.Index), StringF);
                //e.Graphics.FillRectangle(Brushes.Gray, e.Bounds.X-4, e.Bounds.Y-4, e.Bounds.Width+4, e.Bounds.Height+4);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.Black, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            }


        }

        private void chart3_MouseEnter(object sender, EventArgs e)
        {
            this.chart3.BorderlineWidth = 1;
        }

        private void chart3_MouseLeave(object sender, EventArgs e)
        {
            this.chart3.BorderlineWidth = 0;
        }

        private void chart1_MouseEnter(object sender, EventArgs e)
        {
            this.chart1.BorderlineWidth = 1;
        }

        private void chart1_MouseLeave(object sender, EventArgs e)
        {
            this.chart1.BorderlineWidth = 0;
        }

        private void chart2_MouseEnter(object sender, EventArgs e)
        {
            this.chart2.BorderlineWidth = 1;
        }

        private void chart2_MouseLeave(object sender, EventArgs e)
        {
            this.chart2.BorderlineWidth = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.toolStripStatusLabel1.Text == "远程数据库连接中...")
            {
                this.toolStripStatusLabel1.Text = "远程数据库连接中.  ";

            }
            else if (this.toolStripStatusLabel1.Text == "远程数据库连接中.. ")
            {
                this.toolStripStatusLabel1.Text = "远程数据库连接中...";
            }
            else if (this.toolStripStatusLabel1.Text == "远程数据库连接中.  ")
            {
                this.toolStripStatusLabel1.Text = "远程数据库连接中.. ";
            }
            //timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.toolStripStatusLabel3.Text == "本地数据库连接中...")
            {
                this.toolStripStatusLabel3.Text = "本地数据库连接中.  ";
            }
            else if (this.toolStripStatusLabel3.Text == "本地数据库连接中.. ")
            {
                this.toolStripStatusLabel3.Text = "本地数据库连接中...";
            }
            else if (this.toolStripStatusLabel3.Text == "本地数据库连接中.  ")
            {
                this.toolStripStatusLabel3.Text = "本地数据库连接中.. ";
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {

            ;
        }

        public void drawLine(Chart chart, int n, string linename, List<DateTime> x, List<double> y, string showunite,int color = 0)
        {
            //LogMessage("在chart1系列" + n.ToString() + ",绘制曲线：" + linename);
            chart.Series.Clear();

            chart.Series.Add(new Series(linename)); //添加一个图表序列
                                                    // ct.Series[0].XValueType = ChartValueType.String; //设置X轴上的值类型
            chart.Series[n].XValueType = ChartValueType.DateTime;
            chart.Series[n].Label = "#VAL"; //设置显示X Y的值 
            chart.Series[n].ToolTip = linename + "\r#VALX{yyyy-MM-dd HH:mm} \r#VAL"+ showunite; //鼠标移动到对应点显示数值
            chart.Series[n].ChartArea = chart.ChartAreas[0].Name; //设置图表背景框ChartArea 

            chart.Series[n].IsValueShownAsLabel = false;
            chart.Series[n].SmartLabelStyle.Enabled = false;
            chart.Series[n].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.No;

            chart.Series[n].ChartType = SeriesChartType.FastLine; //图类型(折线)
            chart.Series[n].BorderWidth = 2;

            if (color == 0)
            {
                chart.Series[n].Color = Color.DodgerBlue;
            }
            else if (color == 1)
            {
                chart.Series[n].Color = Color.GreenYellow;
            }
            else if (color == 2)
            {
                chart.Series[n].Color = Color.Red;
            }


            //x区域放大
            chart.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart.ChartAreas[0].CursorX.Interval = 0;
            chart.ChartAreas[0].CursorX.IntervalOffset = 0;
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            //Y区域放大
            chart.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            chart.Series[n].Points.DataBindXY(x, y); //添加数据

        }


        public void drawLine_volt_s(Chart chart, int n, string linename, List<DateTime> x, List<double> y , int color=0)
        {
            //LogMessage("在chart1系列" + n.ToString() + ",绘制曲线：" + linename);
            chart.Series.Clear();

            chart.Series.Add(new Series(linename)); //添加一个图表序列
                                                    // ct.Series[0].XValueType = ChartValueType.String; //设置X轴上的值类型
            chart.Series[n].XValueType = ChartValueType.DateTime;
            chart.Series[n].Label = "#VAL"; //设置显示X Y的值 
            //chart.Series[n].ToolTip = linename + "\r#VALX{yyyy-MM-dd HH:mm} \r#VALV"; //鼠标移动到对应点显示数值
            chart.Series[n].ChartArea = chart.ChartAreas[0].Name; //设置图表背景框ChartArea 

            chart.Series[n].IsValueShownAsLabel = false;
            chart.Series[n].SmartLabelStyle.Enabled = false;
            chart.Series[n].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.No;

            chart.Series[n].ChartType = SeriesChartType.FastLine; //图类型(折线)
            chart.Series[n].BorderWidth = 2;

            if (color == 0)
            {
                chart.Series[n].Color = Color.DodgerBlue;
            }
            else if (color == 1)
            {
                chart.Series[n].Color = Color.GreenYellow;
            }
            else if (color ==2)
            {
                chart.Series[n].Color = Color.Red;
            }


            //x区域放大
            chart.ChartAreas[0].CursorX.IsUserEnabled = false;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
            chart.ChartAreas[0].CursorX.Interval = 0;
            chart.ChartAreas[0].CursorX.IntervalOffset = 0;
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
            //Y区域放大
            chart.ChartAreas[0].CursorY.IsUserEnabled = false;
            chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = false;

            chart.Series[n].Points.DataBindXY(x, y); //添加数据

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Chart chart5 = chart4;

            this.Controls.Add(chart5);
            tabPage4.Controls.Add(chart5);
            Chart chart6 = chart4;
            tabPage4.Controls.Add(chart6);
            Chart chart7 = chart4;
            tabPage4.Controls.Add(chart7);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ;
        }

        //
        public Tuple<List<DateTime>, List<double>> Xy_data_volt(int startchartnamenum)
        {
            string Stack_Id = (startchartnamenum - 3).ToString();
            //select year(Timestamp) 年,month(Timestamp) 月,day(Timestamp) 日,avg(CellVoltages_Cell1) CellVoltages_Cell1，avg(CellVoltages_Cell1) CellVoltages_Cell1，avg(CellVoltages_Cell1) CellVoltages_Cell1，avg(CellVoltages_Cell1) CellVoltages_Cell1from StackValuesgroup by year(Timestamp),month(Timestamp),day(Timestamp) order by 年,月,日

            string querysql = @"SELECT 
CONVERT(varchar(100), concat(year(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)), '-', month(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)), '-', day(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp))), 23),
year(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
month(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
day(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
avg(Voltage)
FROM[dbo].[StackValues]
WHERE Stack_Id = " + Stack_Id + @"
GROUP BY
year(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
month(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
day(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp))
ORDER BY
year(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
month(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
day(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp));";

            // MessageBox.Show(querysql);
            DataTable dt = DataQueryTable(0, querysql);
            if (dt != null)
            {

                int n = dt.Rows.Count;
                if (n <= 0)
                {
                    MessageBox.Show("没有数据");

                    // LogMessage("按钮<Cell电压图> 没有查到数据。SQL：" + querysql);
                    return null;
                }
                List<DateTime> x = new List<DateTime>(); List<double> y = new List<double>();
                for (int i = 0; i < n; i++)
                {
                    //add time
                    x.Add(Convert.ToDateTime(dt.Rows[i][0]));
                    //  txt += dt.Rows[i][1].ToString();
                    //add value
                    y.Add(Math.Round(Convert.ToDouble(dt.Rows[i][4].ToString()), 3));

                }
                 
                return new Tuple<List<DateTime>, List<double>>(x, y);
            }
            else
            {
                return null;
            }
        }

        public Tuple<List<DateTime>, List<double>> Xy_data_temp(int startchartnamenum)
        {
            string Stack_Id = (startchartnamenum - 3).ToString();
            //select year(Timestamp) 年,month(Timestamp) 月,day(Timestamp) 日,avg(CellVoltages_Cell1) CellVoltages_Cell1，avg(CellVoltages_Cell1) CellVoltages_Cell1，avg(CellVoltages_Cell1) CellVoltages_Cell1，avg(CellVoltages_Cell1) CellVoltages_Cell1from StackValuesgroup by year(Timestamp),month(Timestamp),day(Timestamp) order by 年,月,日

            string querysql = @"SELECT 
CONVERT(varchar(100), concat(year(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)), '-', month(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)), '-', day(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp))), 23),
year(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
month(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
day(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
avg(Temperature)
FROM[dbo].[StackValues]
WHERE Stack_Id = " + Stack_Id + @"
GROUP BY
year(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
month(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
day(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp))
ORDER BY
year(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
month(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
day(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp));";

            // MessageBox.Show(querysql);
            DataTable dt = DataQueryTable(0, querysql);
            if (dt != null)
            {

                int n = dt.Rows.Count;
                if (n <= 0)
                {
                    MessageBox.Show("没有数据");

                    // LogMessage("按钮<Cell电压图> 没有查到数据。SQL：" + querysql);
                    return null;
                }
                List<DateTime> x = new List<DateTime>(); List<double> y = new List<double>();
                for (int i = 0; i < n; i++)
                {
                    //add time
                    x.Add(Convert.ToDateTime(dt.Rows[i][0]));
                    //  txt += dt.Rows[i][1].ToString();
                    //add value
                    y.Add(Math.Round(Convert.ToDouble(dt.Rows[i][4].ToString()), 1));

                }

                return new Tuple<List<DateTime>, List<double>>(x, y);
            }
            else
            {
                return null;
            }
        }

        public Tuple<List<DateTime>, List<double>> Xy_data_soc(int startchartnamenum)
        {
            string Stack_Id = (startchartnamenum - 3).ToString();
            //select year(Timestamp) 年,month(Timestamp) 月,day(Timestamp) 日,avg(CellVoltages_Cell1) CellVoltages_Cell1，avg(CellVoltages_Cell1) CellVoltages_Cell1，avg(CellVoltages_Cell1) CellVoltages_Cell1，avg(CellVoltages_Cell1) CellVoltages_Cell1from StackValuesgroup by year(Timestamp),month(Timestamp),day(Timestamp) order by 年,月,日

            string querysql = @"SELECT 
CONVERT(varchar(100), concat(year(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)), '-', month(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)), '-', day(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp))), 23),
year(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
month(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
day(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
avg(StateOfCharge)
FROM[dbo].[StackValues]
WHERE Stack_Id = " + Stack_Id + @"
GROUP BY
year(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
month(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
day(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp))
ORDER BY
year(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
month(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp)),
day(DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), Timestamp));";

            // MessageBox.Show(querysql);
            DataTable dt = DataQueryTable(0, querysql);
            if (dt != null)
            {

                int n = dt.Rows.Count;
                if (n <= 0)
                {
                    MessageBox.Show("没有数据");

                    // LogMessage("按钮<Cell电压图> 没有查到数据。SQL：" + querysql);
                    return null;
                }
                List<DateTime> x = new List<DateTime>(); List<double> y = new List<double>();
                for (int i = 0; i < n; i++)
                {
                    //add time
                    x.Add(Convert.ToDateTime(dt.Rows[i][0]));
                    //  txt += dt.Rows[i][1].ToString();
                    //add value
                    y.Add(Math.Round(Convert.ToDouble(dt.Rows[i][4].ToString()), 1));

                }

                return new Tuple<List<DateTime>, List<double>>(x, y);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startchartnamenum"></param>
        public void showDrawLine_volt(Tuple<List<DateTime>, List<double>> tup , int startchartnamenum)
        {
            string Stack_Id = (startchartnamenum - 3).ToString();
            Chart ch = null;
            if (tup != null)
            {

                ch = (Chart)this.tabControl1.Controls.Find("chart" + startchartnamenum.ToString(), true)[0];
                ch.Series.Clear();
                foreach (var series in ch.Series)
                {
                    series.Points.Clear();
                }
                // ch.ChartAreas[0].AxisX.Title = "时 间";
                ch.ChartAreas[0].AxisY.Title = "电 压 V";

                int n = tup.Item1.Count;
                if (n <= 0)
                {
                    MessageBox.Show("没有数据");

                    ch.Titles[0].Text = "";

                   // LogMessage("按钮<Cell电压图> 没有查到数据。SQL：" + querysql);
                    return;
                }
              
                // MessageBox.Show(dt.TableName+"_"+n.ToString());
              //  LogMessage("按钮<Cell电压图> SQL：" + querysql);

                ch.Titles[0].Text = Stack_Id + "#堆栈栈电压历史曲线";
                ch.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);//ZoomReset(0)表示撤销所有放大动作
                ch.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);//ZoomReset(1)表示撤销上一次放大动作
                ch.ChartAreas[0].AxisY.LabelStyle.Format = "N1";
                drawLine_volt_s(ch, 0, "stack" + Stack_Id, tup.Item1, tup.Item2);

                /*
                if (System.IO.File.Exists("log"))
                {
                    this.BeginInvoke(new Action(() => {
                        genpic(ch, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + ch.Titles[0].Text);
                    }));
                }
                else
                {
                    //不存在文件
                    Directory.CreateDirectory("log");//创建该文件
                    this.BeginInvoke(new Action(() => {
                        genpic(ch, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + ch.Titles[0].Text);
                    }));
                }
                */
            }
        }

        public void showDrawLine_temp(Tuple<List<DateTime>, List<double>> tup, int startchartnamenum)
        {

            string Stack_Id = (startchartnamenum - 3).ToString();

            Chart ch = null;
            if (tup != null)
            {

                ch = (Chart)this.tabControl1.Controls.Find("chart" + startchartnamenum.ToString(), true)[0];
                ch.Series.Clear();
                foreach (var series in ch.Series)
                {
                    series.Points.Clear();
                }
                // ch.ChartAreas[0].AxisX.Title = "时 间";
                ch.ChartAreas[0].AxisY.Title = "温 度 ℃";

                int n = tup.Item1.Count;
                if (n <= 0)
                {
                    MessageBox.Show("没有数据");

                    ch.Titles[0].Text = "";

                    // LogMessage("按钮<Cell电压图> 没有查到数据。SQL：" + querysql);
                    return;
                }

                // MessageBox.Show(dt.TableName+"_"+n.ToString());
                //  LogMessage("按钮<Cell电压图> SQL：" + querysql);

                ch.Titles[0].Text = Stack_Id + "#堆栈栈温度历史曲线";
                ch.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);//ZoomReset(0)表示撤销所有放大动作
                ch.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);//ZoomReset(1)表示撤销上一次放大动作
                ch.ChartAreas[0].AxisY.LabelStyle.Format = "N1";
                drawLine_volt_s(ch, 0, "stack" + Stack_Id, tup.Item1, tup.Item2,2);

                /*
                if (System.IO.File.Exists("log"))
                {
                    this.BeginInvoke(new Action(() => {
                        genpic(ch, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + ch.Titles[0].Text);
                    }));
                }
                else
                {
                    //不存在文件
                    Directory.CreateDirectory("log");//创建该文件
                    this.BeginInvoke(new Action(() => {
                        genpic(ch, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + ch.Titles[0].Text);
                    }));
                }
                */
            }
        }

        public void showDrawLine_soc(Tuple<List<DateTime>, List<double>> tup, int startchartnamenum)
        {

            string Stack_Id = (startchartnamenum - 3).ToString();

            Chart ch = null;
            if (tup != null)
            {

                ch = (Chart)this.tabControl1.Controls.Find("chart" + startchartnamenum.ToString(), true)[0];
                ch.Series.Clear();
                foreach (var series in ch.Series)
                {
                    series.Points.Clear();
                }
                // ch.ChartAreas[0].AxisX.Title = "时 间";
                ch.ChartAreas[0].AxisY.Title = "S O C %";

                int n = tup.Item1.Count;
                if (n <= 0)
                {
                    MessageBox.Show("没有数据");

                    ch.Titles[0].Text = "";

                    // LogMessage("按钮<Cell电压图> 没有查到数据。SQL：" + querysql);
                    return;
                }

                // MessageBox.Show(dt.TableName+"_"+n.ToString());
                //  LogMessage("按钮<Cell电压图> SQL：" + querysql);

                ch.Titles[0].Text = Stack_Id + "#堆栈栈SOC历史曲线";
                ch.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);//ZoomReset(0)表示撤销所有放大动作
                ch.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);//ZoomReset(1)表示撤销上一次放大动作
                ch.ChartAreas[0].AxisY.LabelStyle.Format = "N1";
                drawLine_volt_s(ch, 0, "stack" + Stack_Id, tup.Item1, tup.Item2,1);

                /*
                if (System.IO.File.Exists("log"))
                {
                    this.BeginInvoke(new Action(() => {
                        genpic(ch, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + ch.Titles[0].Text);
                    }));
                }
                else
                {
                    //不存在文件
                    Directory.CreateDirectory("log");//创建该文件
                    this.BeginInvoke(new Action(() => {
                        genpic(ch, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + ch.Titles[0].Text);
                    }));
                }
                */
            }
        }


        private void button10_Click_2(object sender, EventArgs e)
        {
            //  Stopwatch sw = new Stopwatch();
            // sw.Start();
            //耗时程序
            List<Tuple<List<DateTime>, List<double>>> lt = new List<Tuple<List<DateTime>, List<double>>>();
            Parallel.For(4, 16, nu =>
            {
                // Task.Factory.StartNew(() => 
                lt.Add(Xy_data_volt(nu));
                this.BeginInvoke(new Action(() => { showDrawLine_volt(lt[nu - 4], nu); }));

                // );

            });
            this.label6.Text = "堆栈电压历史曲线";
            
            //   sw.Stop();
            //   TimeSpan ts = sw.Elapsed;
            //MessageBox.Show(ts.TotalMilliseconds.ToString());
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            List<Tuple<List<DateTime>, List<double>>> lt = new List<Tuple<List<DateTime>, List<double>>>();
            Parallel.For(4, 16, nu =>
            {
                // Task.Factory.StartNew(() => 
                lt.Add(Xy_data_temp(nu));
                this.BeginInvoke(new Action(() => { showDrawLine_temp(lt[nu - 4], nu); }));

                // );

            });
            this.label6.Text = "堆栈温度历史曲线";
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            List<Tuple<List<DateTime>, List<double>>> lt = new List<Tuple<List<DateTime>, List<double>>>();
            Parallel.For(4, 16, nu =>
            {
                // Task.Factory.StartNew(() => 
                lt.Add(Xy_data_soc(nu));
                this.BeginInvoke(new Action(() => { showDrawLine_soc(lt[nu - 4], nu); }));

                // );

            });
            this.label6.Text = "堆栈SOC历史曲线";
        }

        private void chart_MouseEnter(object sender, EventArgs e)
        {
            Chart chart = (Chart)sender;
            chart.BorderlineWidth = 1;
        }

        private void chart_MouseLeave(object sender, EventArgs e)
        {
            Chart chart = (Chart)sender;
            chart.BorderlineWidth = 0;
        }

        //默认数据查询返回二维list
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqltext"></param>
        /// <param name="colonum">列号</param>
        /// <param name="acur">精度</param>
        /// <returns></returns>
        public Tuple<List<DateTime>, List<double>> Xy_data(string sqltext,int colonum,int acur)
        {
            // MessageBox.Show(querysql);
            DataTable dt = DataQueryTable(0, sqltext);
            if (dt != null)
            {

                int n = dt.Rows.Count;
                if (n <= 0)
                {
                    MessageBox.Show("没有数据");

                    // LogMessage("按钮<Cell电压图> 没有查到数据。SQL：" + querysql);
                    return null;
                }
                List<DateTime> x = new List<DateTime>(); List<double> y = new List<double>();
                for (int i = 0; i < n; i++)
                {
                    //add time
                    x.Add(Convert.ToDateTime(dt.Rows[i][0]));
                    //  txt += dt.Rows[i][1].ToString();
                    //add value
                    y.Add(Math.Round(Convert.ToDouble(dt.Rows[i][colonum].ToString()), acur));

                }

                return new Tuple<List<DateTime>, List<double>>(x, y);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tup">XY数据</param>
        /// <param name="chartnamenum">chart名字</param>
        /// <param name="title">图标题</param>
        /// <param name="yTitle">Y轴标题</param>
        /// <param name="acur">数据精度</param>
        /// <param name="lineName">线名称</param>
        /// <param name="color">线颜色</param>
        public void showDrawLine(Tuple<List<DateTime>, List<double>> tup, int chartnamenum,string title,string yTitle,int acur,string lineName,int color,string showunite)
        {
            Chart ch = null;
            if (tup != null)
            {
                ch = (Chart)this.tabControl1.Controls.Find("chart" + chartnamenum.ToString(), true)[0];
                ch.Series.Clear();
                foreach (var series in ch.Series)
                {
                    series.Points.Clear();
                }
                // ch.ChartAreas[0].AxisX.Title = "时 间";
                ch.ChartAreas[0].AxisY.Title = yTitle;//"温 度 ℃";

                int n = tup.Item1.Count;
                if (n <= 0)
                {
                    MessageBox.Show("没有数据");
                    ch.Titles[0].Text = "";
                    // LogMessage("按钮<Cell电压图> 没有查到数据。SQL：" + querysql);
                    return;
                }

                // MessageBox.Show(dt.TableName+"_"+n.ToString());
                //  LogMessage("按钮<Cell电压图> SQL：" + querysql);

                ch.Titles[0].Text = title;//Stack_Id + "#堆栈栈温度历史曲线";
                ch.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);//ZoomReset(0)表示撤销所有放大动作
                ch.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);//ZoomReset(1)表示撤销上一次放大动作
                ch.ChartAreas[0].AxisY.LabelStyle.Format = "N"+ acur.ToString();
                drawLine(ch, 0, lineName, tup.Item1, tup.Item2, showunite, color);

                
                if (System.IO.File.Exists("log"))
                {
                    this.BeginInvoke(new Action(() => {
                        genpic(ch, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + ch.Titles[0].Text);
                    }));
                }
                else
                {
                    //不存在文件
                    Directory.CreateDirectory("log");//创建该文件
                    this.BeginInvoke(new Action(() => {
                        genpic(ch, "log/" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss ") + ch.Titles[0].Text);
                    }));
                }
                
            }
        }


        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.comboBox3.SelectedItem.ToString() == "1" || this.comboBox3.SelectedItem.ToString() == "2")
                {
                    if (comboBox4.SelectedIndex == 0)//阳极加热器温度
                    {
                        string sqltext = "SELECT DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),AnolyteTank_Heater_ElementTemperature FROM [dbo].[EsuValues] WHERE Esu_Id='" + this.comboBox3.SelectedItem.ToString() + "' AND  datediff(day, DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),'" + this.dateTimePicker12.Value.ToString("yyyy-MM-dd") + "')= 0 order by DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) ASC";
                        showDrawLine(Xy_data(sqltext, 1, 1), 16, this.dateTimePicker12.Value.ToString("yyyy-MM-dd") + "阳极加热器温度曲线", "温 度", 1, "ESU" + this.comboBox3.SelectedItem.ToString(), 2, "℃");

                    }
                    else if (comboBox4.SelectedIndex == 1)//液体温度
                    {
                        string sqltext = "SELECT DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),AnolyteTank_Heater_BathPrimaryTemperature FROM [dbo].[EsuValues] WHERE Esu_Id='" + this.comboBox3.SelectedItem.ToString() + "' AND  datediff(day, DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),'" + this.dateTimePicker12.Value.ToString("yyyy-MM-dd") + "')= 0 order by DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) ASC";
                        showDrawLine(Xy_data(sqltext, 1, 1), 16, this.dateTimePicker12.Value.ToString("yyyy-MM-dd") + "阳极液温度曲线", "温 度", 1, "ESU" + this.comboBox3.SelectedItem.ToString(), 2, "℃");
                    }
                    else if (comboBox4.SelectedIndex == 2)//压力
                    {
                        string sqltext = "SELECT DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),AnolyteTank_Pressure FROM [dbo].[EsuValues] WHERE Esu_Id='" + this.comboBox3.SelectedItem.ToString() + "' AND  datediff(day, DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),'" + this.dateTimePicker12.Value.ToString("yyyy-MM-dd") + "')= 0 order by DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) ASC";
                        showDrawLine(Xy_data(sqltext, 1, 4), 16, this.dateTimePicker12.Value.ToString("yyyy-MM-dd") + "阳极压力曲线", "压 力 PSI", 4, "ESU" + this.comboBox3.SelectedItem.ToString(), 4, "psi");

                    }
                    else if (comboBox4.SelectedIndex == 3)//  泵速
                    {
                        string sqltext = "SELECT DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),AnolyteTank_PumpSpeed FROM [dbo].[EsuValues] WHERE Esu_Id='" + this.comboBox3.SelectedItem.ToString() + "' AND  datediff(day, DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),'" + this.dateTimePicker12.Value.ToString("yyyy-MM-dd") + "')= 0 order by DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) ASC";
                        showDrawLine(Xy_data(sqltext, 1, 3), 16, this.dateTimePicker12.Value.ToString("yyyy-MM-dd") + "阳极泵速曲线", "泵 速 Hz", 3, "ESU" + this.comboBox3.SelectedItem.ToString(), 3, "Hz");

                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("ESU?");
            }
           
           


        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.comboBox3.SelectedItem.ToString() == "1" || this.comboBox3.SelectedItem.ToString() == "2")
                {
                    if (comboBox5.SelectedIndex == 0)//阴极加热器温度
                    {
                        string sqltext = "SELECT DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),CatholyteTank_Heater_ElementTemperature FROM [dbo].[EsuValues] WHERE Esu_Id='" + this.comboBox3.SelectedItem.ToString() + "' AND  datediff(day, DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),'" + this.dateTimePicker12.Value.ToString("yyyy-MM-dd") + "')= 0 order by DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) ASC";
                        showDrawLine(Xy_data(sqltext, 1, 1), 16, this.dateTimePicker12.Value.ToString("yyyy-MM-dd") + "阴极加热器温度曲线", "温 度", 1, "ESU" + this.comboBox3.SelectedItem.ToString(), 2, "℃");

                    }
                    else if (comboBox5.SelectedIndex == 1)//液体温度
                    {
                        string sqltext = "SELECT DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),CatholyteTank_Heater_BathPrimaryTemperature FROM [dbo].[EsuValues] WHERE Esu_Id='" + this.comboBox3.SelectedItem.ToString() + "' AND  datediff(day, DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),'" + this.dateTimePicker12.Value.ToString("yyyy-MM-dd") + "')= 0 order by DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) ASC";
                        showDrawLine(Xy_data(sqltext, 1, 1), 16, this.dateTimePicker12.Value.ToString("yyyy-MM-dd") + "阴极液温度曲线", "温 度", 1, "ESU" + this.comboBox3.SelectedItem.ToString(), 2, "℃");
                    }
                    else if (comboBox5.SelectedIndex == 2)//压力
                    {
                        string sqltext = "SELECT DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),CatholyteTank_Pressure FROM [dbo].[EsuValues] WHERE Esu_Id='" + this.comboBox3.SelectedItem.ToString() + "' AND  datediff(day, DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),'" + this.dateTimePicker12.Value.ToString("yyyy-MM-dd") + "')= 0 order by DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) ASC";
                        showDrawLine(Xy_data(sqltext, 1, 4), 16, this.dateTimePicker12.Value.ToString("yyyy-MM-dd") + "阴极压力曲线", "压 力 PSI", 4, "ESU" + this.comboBox3.SelectedItem.ToString(), 4, "psi");

                    }
                    else if (comboBox5.SelectedIndex == 3)//  泵速
                    {
                        string sqltext = "SELECT DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),CatholyteTank_PumpSpeed FROM [dbo].[EsuValues] WHERE Esu_Id='" + this.comboBox3.SelectedItem.ToString() + "' AND  datediff(day, DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp),'" + this.dateTimePicker12.Value.ToString("yyyy-MM-dd") + "')= 0 order by DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()),Timestamp) ASC";
                        showDrawLine(Xy_data(sqltext, 1, 3), 16, this.dateTimePicker12.Value.ToString("yyyy-MM-dd") + "阴极泵速曲线", "泵 速 Hz", 3, "ESU" + this.comboBox3.SelectedItem.ToString(), 3, "Hz");

                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("ESU?");
            }
            
              
        }
    }


    public class ActiveDirectoryAuthProvider : System.Data.SqlClient.SqlAuthenticationProvider
    {
        // ASSIGN YOUR VALUES TO THESE STATIC FIELDS !!
        // static public string Az_SQLDB_svrName = "cnvizn.database.chinacloudapi.cn";
        // static public string AzureAD_UserID = "weview@weview.partner.onmschina.cn";
        // static public string Initial_DatabaseName = "cnvizn";
        // Some scenarios do not need values for the following two fields:
        // static public readonly string ClientApplicationID = "49c0cc77-01cf-455c-834b-5e7f2aeaaf9a";
        // static public readonly Uri RedirectUri = new Uri("https://mywebserver.com/");
        // Program._ more static values that you set!

        private readonly string _clientId = "49c0cc77-01cf-455c-834b-5e7f2aeaaf9a";
        private readonly Uri _redirectUri = new Uri("https://login.microsoftonline.com/common/oauth2/nativeclient");

        public override async System.Threading.Tasks.Task<System.Data.SqlClient.SqlAuthenticationToken>
            AcquireTokenAsync(System.Data.SqlClient.SqlAuthenticationParameters parameters)
        {
            Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext authContext =
                new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(parameters.Authority);
            authContext.CorrelationId = parameters.ConnectionId;
            Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationResult result;

            switch (parameters.AuthenticationMethod)
            {
                case System.Data.SqlClient.SqlAuthenticationMethod.ActiveDirectoryInteractive:
                    Console.WriteLine("In method 'AcquireTokenAsync', case_0 == '.ActiveDirectoryInteractive'.");

                    result = await authContext.AcquireTokenAsync(
                        parameters.Resource,
                        _clientId,
                        _redirectUri,
                        new Microsoft.IdentityModel.Clients.ActiveDirectory.PlatformParameters(Microsoft.IdentityModel.Clients.ActiveDirectory.PromptBehavior.Auto),
                        new Microsoft.IdentityModel.Clients.ActiveDirectory.UserIdentifier(
                            parameters.UserId,
                            Microsoft.IdentityModel.Clients.ActiveDirectory.UserIdentifierType.RequiredDisplayableId));
                    break;

                case System.Data.SqlClient.SqlAuthenticationMethod.ActiveDirectoryIntegrated:
                    Console.WriteLine("In method 'AcquireTokenAsync', case_1 == '.ActiveDirectoryIntegrated'.");

                    result = await authContext.AcquireTokenAsync(
                        parameters.Resource,
                        _clientId,
                        new Microsoft.IdentityModel.Clients.ActiveDirectory.UserCredential());
                    break;

                case System.Data.SqlClient.SqlAuthenticationMethod.ActiveDirectoryPassword:
                    Console.WriteLine("In method 'AcquireTokenAsync', case_2 == '.ActiveDirectoryPassword'.");

                    result = await authContext.AcquireTokenAsync(
                        parameters.Resource,
                        _clientId,
                        new Microsoft.IdentityModel.Clients.ActiveDirectory.UserPasswordCredential(
                            parameters.UserId,
                            parameters.Password));
                    break;

                default: throw new InvalidOperationException();
            }
            return new System.Data.SqlClient.SqlAuthenticationToken(result.AccessToken, result.ExpiresOn);
        }

        public override bool IsSupported(System.Data.SqlClient.SqlAuthenticationMethod authenticationMethod)
        {
            return authenticationMethod == System.Data.SqlClient.SqlAuthenticationMethod.ActiveDirectoryIntegrated
                || authenticationMethod == System.Data.SqlClient.SqlAuthenticationMethod.ActiveDirectoryInteractive
                || authenticationMethod == System.Data.SqlClient.SqlAuthenticationMethod.ActiveDirectoryPassword;
        }
    } // EOClass ActiveDirectoryAuthProvider.

}
