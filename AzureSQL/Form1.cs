using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading.Tasks;

namespace AzureSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        List<string> txData2 = new List<string>();
        List<double> tyData2 = new List<double>();
        List<double> tyData3 = new List<double>();

        string connectionStr = "Server=tcp:cnvizn.database.chinacloudapi.cn,1433;Initial Catalog=cnvizn;Persist Security Info=False;User ID=weview@weview.partner.onmschina.cn;Password=Wv123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=\"Active Directory Password\";";
        string connectionLocalStr = @"Data Source=DESKTOP-6PELLNP\SQLEXPRESS;Initial Catalog=azuredb;User ID=sa;Password=5454794547;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        public void chart_init(Chart chart)
        {
            chart.Series.Clear();

            chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;//指滚动条位于图表区内还是图表区外
            chart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;
            chart.ChartAreas[0].AxisX.ScrollBar.Size = 20;

            chart.ChartAreas[0].AxisX.ScaleView.Position = 1;//指当前(最右边)显示的是第几个点,可以设为当前一共的数据减去Size；
                                                             // chart.ChartAreas[0].AxisX.ScaleView.Size = 80;//视野范围内共有多少个数据点
            chart.ChartAreas[0].Axes[0].MajorGrid.LineDashStyle = ChartDashStyle.Dash; //网格类型 短横线
            chart.ChartAreas[0].Axes[0].MajorGrid.LineColor = Color.Gray;
            chart.ChartAreas[0].Axes[0].MajorTickMark.Enabled = true; // x轴上突出的小点
            chart.ChartAreas[0].Axes[0].MajorTickMark.Enabled = true;
            chart.ChartAreas[0].AxisX.MajorGrid.Interval = 0; //
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd HH:mm";


            chart.ChartAreas[0].Axes[1].MajorGrid.LineDashStyle = ChartDashStyle.Dash; //网格类型 短横线
            chart.ChartAreas[0].Axes[1].MajorGrid.LineColor = Color.Gray;
            //x区域放大
            chart.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            //Y区域放大
            chart.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
        }
        public delegate string dele();
        private void Form1_Load(object sender, EventArgs e)
        {
            //string datestring = this.dateTimePicker1.Value.ToShortDateString();
            // MessageBox.Show(datestring);
            this.treeView1.Nodes.Add("GS200");
            TreeNode Fnode = this.treeView1.Nodes[0];
            Font boldFont = new Font(treeView1.Font,FontStyle.Bold);
            Fnode.NodeFont = boldFont;
            Fnode.Text = "GS200";
            for (int i = 1; i <= 12; i++)
            {
                Fnode.Nodes.Add("Stack_" + i.ToString());
                for (int j = 1; j <= 30; j++)
                {
                    Fnode.Nodes[i - 1].Nodes.Add("Cell_" + j.ToString());
                }
            }
            this.toolStripStatusLabel1.Text = "远程数据库连接中...";
            this.button15.Enabled = false;
            Task t1 = Task.Factory.StartNew(()=>connected());

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
            chart_init(this.chart1);
            chart_init(this.chart2);

        }

        public void connected()
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        this.Invoke(new Action(() => {
                            this.toolStripStatusLabel1.Text = "远程数据库连接成功！";
                            this.toolStripStatusLabel1.ForeColor = Color.Green;
                            this.button15.Enabled = true;
                            LogMessage("远程数据库连接成功！");
                        }));  
                    }
                    else
                    {
                        this.Invoke(new Action(() => {
                            this.toolStripStatusLabel1.Text = "远程数据库未连接！" + connection.State.ToString();
                            this.toolStripStatusLabel1.ForeColor = Color.Red;
                            this.button15.Enabled = false;
                            LogWarning("远程数据库未连接！" + connection.State.ToString());
                        }));
                      
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
                    LogError("远程数据库连接失败！" + errorMessages.ToString());
                    this.Invoke(new Action(() => {
                        this.toolStripStatusLabel1.Text = "远程数据库连接失败！";
                        this.toolStripStatusLabel1.ForeColor = Color.Red;
                        this.button15.Enabled = false;
                    }));
                }


            }
            
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

        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }

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



        // private void Button1_Click(object sender, EventArgs e)
        //  {
        //this.label3.Text= Deserialize(this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value.ToString());
        // }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.chart1.Series.Clear();
            // this.chart1.Series[0].Points.Clear();
            this.chart1.Series.Add(new Series("d")); //添加一个图表序列
                                                     // ct.Series[0].XValueType = ChartValueType.String; //设置X轴上的值类型
            this.chart1.Series[0].Label = "#VAL"; //设置显示X Y的值 
            this.chart1.Series[0].ToolTip = "#VALX\r#VAL"; //鼠标移动到对应点显示数值
            this.chart1.Series[0].ChartArea = this.chart1.ChartAreas[0].Name; //设置图表背景框ChartArea 



            //开启小箭头及数据显示
            this.chart1.Series[0].IsValueShownAsLabel = false;
            this.chart1.Series[0].SmartLabelStyle.Enabled = false;
            this.chart1.Series[0].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.No;

            this.chart1.Series[0].LabelForeColor = Color.Transparent;
            if (this.checkBox1.Checked)
            {
                this.chart1.Series[0].MarkerBorderColor = Color.Red; //标记点边框颜色
                this.chart1.Series[0].MarkerBorderWidth = 1; //标记点边框大小
                this.chart1.Series[0].MarkerColor = Color.Blue; //标记点中心颜色
                this.chart1.Series[0].MarkerSize = 3; //标记点大小
                this.chart1.Series[0].MarkerStyle = MarkerStyle.Circle; //标记点类型

                this.chart1.Series[0].IsValueShownAsLabel = true;
                this.chart1.Series[0].SmartLabelStyle.Enabled = true;
                this.chart1.Series[0].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Partial;

                this.chart1.Series[0].LabelForeColor = Color.Black;
            }


            this.chart1.Series[0].ChartType = SeriesChartType.Line; //图类型(折线)
            this.chart1.Series[0].BorderWidth = 2;
            this.chart1.Series[0].Points.DataBindXY(txData2, tyData2); //添加数据
        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ;
        }

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

        private void Button1_Click(object sender, EventArgs e)
        {
            string querysql = "SELECT * FROM[dbo].[EsuValues] where Esu_Id=" + this.comboBox3.Text + " AND datediff(day, [Timestamp],'" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')= 0 order by [Timestamp] ASC";
            DataQuery(querysql);
        }

        public void DataQuery(string sql)
        {
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
                throw (ex);

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
                throw (ex);
            }
        }
        #endregion





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
            LogMessage("<初始化本地表>");
            InitalTable("dbo.EsuValues");
            InitalTable("dbo.StackValues");

        }

        //初始化本地表
        public void InitalTable(string tablename)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        this.toolStripStatusLabel1.Text = "本地数据库连接成功！";
                        this.toolStripStatusLabel1.ForeColor = Color.Green;
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

                        LogMessage("本地数据库连接成功！初始化" + tablename+"成功");
                    }
                    else
                    {
                        this.toolStripStatusLabel1.Text = "本地数据库未连接！" + connection.State.ToString();
                        this.toolStripStatusLabel1.ForeColor = Color.Red;
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
                    this.toolStripStatusLabel1.Text = "本地数据库连接失败！";
                    this.toolStripStatusLabel1.ForeColor = Color.Red;
                    LogError("本地数据库连接失败！" + errorMessages.ToString());
                }

            }
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                //本地
                ;
            }
            else
            {
                //远程
                ;
            }
        }

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

        private void button11_Click(object sender, EventArgs e)
        {
            string querysql = "SELECT * FROM [dbo].[EsuValues] where Esu_Id=" + this.comboBox3.Text + " AND ([Timestamp] between '" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and '" + this.dateTimePicker3.Value.ToString("yyyy-MM-dd") + "') order by [Timestamp] ASC";
            MessageBox.Show(querysql);
            DataQuery(querysql);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            /// string querysql = "SELECT * FROM [dbo].[StackValues] where Stack_Id=" + this.comboBox4.Text + " AND  ([Timestamp] between '" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and '" + this.dateTimePicker3.Value.ToString("yyyy-MM-dd") + "') order by [Timestamp] ASC";
            // MessageBox.Show(querysql);
            // DataQuery(querysql);
        }

        public DataTable DataQueryTable(int localorRemote, string sql)
        {
            DataTable res;
            string conn = null,localstr="";
            if (localorRemote == 0)
            {
                //本地
                conn = connectionLocalStr;
                localstr = "本地数据库";
            }
            else
            {
                //远程
                conn = connectionStr;
                localstr = "远程数据库";
            }
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        this.toolStripStatusLabel1.Text = localstr+"连接成功！";
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
                        //this.dataGridView1.DataSource = null;  //清空原有datagridview列表

                        //dataGridView1.DataSource = ds.Tables[0];
                        LogMessage(localstr + "连接成功！查询数据表成功，SQL："+ sql);
                        return dt;
                    }
                    else
                    {
                        this.toolStripStatusLabel1.Text = localstr+"未连接！" + connection.State.ToString();
                        this.toolStripStatusLabel1.ForeColor = Color.Red;
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

                    this.toolStripStatusLabel1.Text = localstr+"连接失败！";
                    this.toolStripStatusLabel1.ForeColor = Color.Red;
                    LogError(localstr+"连接失败！" + errorMessages.ToString());
                    return null;
                }

            }
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
            chart1.ChartAreas[0].AxisY.Title = "电 压";
            if (this.treeView1.SelectedNode.Level != 1)
            { MessageBox.Show("请选择具体堆栈ID"); return; }
            if (this.tabControl1.SelectedIndex != 1)
            {
                this.tabControl1.SelectTab(1);
            }
            string Stack_Id = this.treeView1.SelectedNode.Text;
            string[] Stack_Id_num = Stack_Id.Split('_');
            //即可得到sArray[0]="GT123",sArray[1]="1";
            this.label10.Text = "cell";
            this.label11.Text = Stack_Id_num[1];
            string querysql = "SELECT * FROM [dbo].[StackValues] where Stack_Id=" + Stack_Id_num[1] + " AND  ([Timestamp] between '" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and '" + this.dateTimePicker3.Value.ToString("yyyy-MM-dd") + "') order by [Timestamp] ASC";
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
                for (int cellnum = 0; cellnum < 30; cellnum++)
                {
                    List<DateTime> x = new List<DateTime>(); List<double> y = new List<double>();
                    for (int i = 0; i < n; i++)
                    {
                        //add time
                        x.Add(Convert.ToDateTime(dt.Rows[i][1]));
                        //  txt += dt.Rows[i][1].ToString();
                        //add value
                        y.Add(Math.Round(Convert.ToDouble(dt.Rows[i][17 + cellnum].ToString()), 3));

                    }
                    drawLine_volt(cellnum, "Cell" + (cellnum + 1).ToString(), x, y);
                }
            }
           

        }

        public void drawLine_volt(int n, string linename, List<DateTime> x, List<double> y)
        {

            LogMessage("在chart1系列"+n.ToString()+",绘制曲线："+ linename);
            //this.chart1.Series.Clear();
            // this.chart1.Series[0].Points.Clear();
            this.chart1.Series.Add(new Series(linename)); //添加一个图表序列
                                                          // ct.Series[0].XValueType = ChartValueType.String; //设置X轴上的值类型
            this.chart1.Series[n].XValueType = ChartValueType.DateTime;
            this.chart1.Series[n].Label = "#VAL"; //设置显示X Y的值 
            this.chart1.Series[n].ToolTip = linename + "\r#VALX\r#VAL"; //鼠标移动到对应点显示数值
            this.chart1.Series[n].ChartArea = this.chart1.ChartAreas[0].Name; //设置图表背景框ChartArea 



            //开启小箭头及数据显示

            this.chart1.Series[n].IsValueShownAsLabel = false;
            this.chart1.Series[n].SmartLabelStyle.Enabled = false;
            this.chart1.Series[n].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.No;

            this.chart1.Series[n].LabelForeColor = Color.Transparent;
            if (this.checkBox1.Checked)
            {
                this.chart1.Series[n].MarkerBorderColor = Color.Red; //标记点边框颜色
                this.chart1.Series[n].MarkerBorderWidth = 1; //标记点边框大小
                this.chart1.Series[n].MarkerColor = Color.Blue; //标记点中心颜色
                this.chart1.Series[n].MarkerSize = 3; //标记点大小
                this.chart1.Series[n].MarkerStyle = MarkerStyle.Circle; //标记点类型

                this.chart1.Series[n].IsValueShownAsLabel = true;
                this.chart1.Series[n].SmartLabelStyle.Enabled = true;
                this.chart1.Series[n].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Partial;

                this.chart1.Series[n].LabelForeColor = Color.Black;
            }


            this.chart1.Series[n].ChartType = SeriesChartType.FastLine; //图类型(折线)
            this.chart1.Series[n].BorderWidth = 2;
            this.chart1.Series[n].Points.DataBindXY(x, y); //添加数据
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
            if (this.tabControl1.SelectedIndex != 1)
            {
                this.tabControl1.SelectTab(1);
            }
            chart1.ChartAreas[0].AxisX.Title = "时 间";
            chart1.ChartAreas[0].AxisY.Title = "电 压";
            string Stack_Id = this.treeView1.SelectedNode.Text;
            string[] Stack_Id_num = Stack_Id.Split('_');
            this.label11.Text = Stack_Id_num[1];
            this.label10.Text = "cell";
            //即可得到sArray[0]="GT123",sArray[1]="1";
            string querysql = "SELECT * FROM [dbo].[StackValues] where Stack_Id=" + Stack_Id_num[1] + " AND  datediff(day, [Timestamp],'" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')= 0 order by [Timestamp] ASC";
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
                for (int cellnum = 0; cellnum < 30; cellnum++)
                {
                    List<DateTime> x = new List<DateTime>(); List<double> y = new List<double>();
                    for (int i = 0; i < n; i++)
                    {
                        //add time
                        x.Add(Convert.ToDateTime(dt.Rows[i][1]));
                        //  txt += dt.Rows[i][1].ToString();
                        //add value
                        y.Add(Math.Round(Convert.ToDouble(dt.Rows[i][17 + cellnum].ToString()), 3));

                    }

                    drawLine_volt(cellnum, "Cell" + (cellnum + 1).ToString(), x, y);
                }
            }

        }



        private void button15_Click(object sender, EventArgs e)
        {
            //查找需要更新的数量
            //本地表最大ID
            string sql = "select max(ID)from [dbo].[StackValues];";
            DataTable dt = DataQueryTable(0, sql);
            //MessageBox.Show(dt.Rows[0][0].ToString());
            int localMaxID = Convert.ToInt32(dt.Rows[0][0]);
            //远程最大ID
            dt = DataQueryTable(1, sql);

            int remoteMaxID = Convert.ToInt32(dt.Rows[0][0]);
            //查询数据
            sql = "select * from [dbo].[StackValues] where ID>" + localMaxID;
            dt = DataQueryTable(1, sql);
            //MessageBox.Show(dt.Rows[0][0].ToString());
            //fill local
            DialogResult result =
            MessageBox.Show("确定更新" + dt.Rows.Count.ToString() + "条记录吗？", "更新", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            LogMessage("<更新> 找到"+ dt.Rows.Count.ToString() + "条记录需要更新");
            if (result == DialogResult.Yes)
            {
                Task t1 = Task.Factory.StartNew(() => {
                    SqlBulkCopyInsert(connectionLocalStr, "dbo.StackValues", dt);
                    MessageBox.Show("更新完毕");
                    LogMessage("<更新> 更新了" + dt.Rows.Count.ToString() + "条记录");
                });


            }
            else { return; }

        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            int _currentPointX = e.X;
            int _currentPointY = e.Y;

            this.chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(_currentPointX, _currentPointY), true);
            this.chart1.ChartAreas[0].CursorY.SetCursorPixelPosition(new PointF(_currentPointX, _currentPointY), true);
            //this.label2.Text = string.Format("{0},{1}", _currentPointX, _currentPointY);
            var pos = e.Location;
            var results = chart1.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    //  result.
                    var xVal = result.PointIndex;
                    var yVal = this.chart1.Series[0].Points[xVal].YValues[0];
                    this.label2.Text = string.Format("{0},{1}", DateTime.FromOADate(this.chart1.Series[0].Points[xVal].XValue), yVal);

                }
            }
        }

        public void drawLine_temp(int n, string linename, List<DateTime> x, List<double> y)
        {

            LogMessage("在chart2系列" + n.ToString() + ",绘制曲线" + linename);
            //this.chart2.Series.Clear();
            // this.chart2.Series[0].Points.Clear();
            this.chart2.Series.Add(new Series(linename)); //添加一个图表序列
                                                          // ct.Series[0].XValueType = ChartValueType.String; //设置X轴上的值类型
            this.chart2.Series[n].XValueType = ChartValueType.DateTime;
            this.chart2.Series[n].Label = "#VAL"; //设置显示X Y的值 
            this.chart2.Series[n].ToolTip = linename + "\r#VALX\r#VAL"; //鼠标移动到对应点显示数值
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
        }

        private void chart2_MouseMove(object sender, MouseEventArgs e)
        {
            int _currentPointX = e.X;
            int _currentPointY = e.Y;

            this.chart2.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(_currentPointX, _currentPointY), true);
            this.chart2.ChartAreas[0].CursorY.SetCursorPixelPosition(new PointF(_currentPointX, _currentPointY), true);
            //this.label2.Text = string.Format("{0},{1}", _currentPointX, _currentPointY);

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            this.chart1.Series.Clear();
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            if (this.tabControl1.SelectedIndex != 1)
            {
                this.tabControl1.SelectTab(1);
            }
            chart1.ChartAreas[0].AxisX.Title = "时 间";
            chart1.ChartAreas[0].AxisY.Title = "电 压";
            this.chart1.Titles[0].Text = "堆栈" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 电压曲线";
            this.label10.Text = "stack";
            for (int stack_id = 1; stack_id <= 12; stack_id++)
            {
                string querysql = "SELECT * FROM [dbo].[StackValues] where datediff(day, [Timestamp],'" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')= 0  AND Stack_Id=" + stack_id + " order by [Timestamp] ASC";
                //MessageBox.Show(querysql);
                DataTable dt = DataQueryTable(0, querysql);
                if (dt != null)
                {
                    int n = dt.Rows.Count;
                    if (n <= 0)
                    {
                        MessageBox.Show("stack" + stack_id.ToString() + "没有数据");
                        LogMessage("按钮<栈电压图> 没有查到数据。SQL：" + querysql);
                        //this.chart1.Titles[0].Text = "";
                        //return;
                    }
                    LogMessage("按钮<栈电压图> SQL：" + querysql);
                    List<DateTime> x = new List<DateTime>(); List<double> y = new List<double>();
                    for (int i = 0; i < n; i++)
                    {
                        //add time
                        x.Add(Convert.ToDateTime(dt.Rows[i][1]));
                        //  txt += dt.Rows[i][1].ToString();
                        //add value
                        y.Add(Math.Round(Convert.ToDouble(dt.Rows[i][6].ToString()), 3));

                    }
                    drawLine_volt(stack_id - 1, "stack" + stack_id.ToString(), x, y);
                }
                else { break; }
               
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.chart1.Series.Clear();
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            if (this.tabControl1.SelectedIndex != 1)
            {
                this.tabControl1.SelectTab(1);
            }
            chart1.ChartAreas[0].AxisX.Title = "时 间";
            chart1.ChartAreas[0].AxisY.Title = "电 压";

            this.chart1.Titles[0].Text = "堆栈" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "到" + this.dateTimePicker3.Value.ToString("yyyy-MM-dd") + " 电压曲线";
            this.label10.Text = "stack";
            for (int stack_id = 1; stack_id <= 12; stack_id++)
            {

                string querysql = "SELECT * FROM [dbo].[StackValues] where ([Timestamp] between '" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and '" + this.dateTimePicker3.Value.ToString("yyyy-MM-dd") + "') AND Stack_Id=" + stack_id + " order by [Timestamp] ASC";
                //MessageBox.Show(querysql);
                DataTable dt = DataQueryTable(0, querysql);
                if (dt != null)
                {
                    int n = dt.Rows.Count;
                    if (n <= 0)
                    {
                        MessageBox.Show("stack" + stack_id.ToString() + "没有数据");
                        //this.chart1.Titles[0].Text = "";
                        //return;
                        LogMessage("按钮<栈电压图（a-b）> 没有查到数据。SQL：" + querysql);
                    }
                    List<DateTime> x = new List<DateTime>(); List<double> y = new List<double>();
                    LogMessage("按钮<栈电压图（a-b）> SQL：" + querysql);
                    for (int i = 0; i < n; i++)
                    {
                        //add time
                        x.Add(Convert.ToDateTime(dt.Rows[i][1]));
                        //  txt += dt.Rows[i][1].ToString();
                        //add value
                        y.Add(Math.Round(Convert.ToDouble(dt.Rows[i][6].ToString()), 3));

                    }
                    drawLine_volt(stack_id - 1, "stack" + stack_id.ToString(), x, y);
                }
                else { break; }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.label9.Text = this.treeView1.SelectedNode.FullPath;
            TreeNode Fnode = this.treeView1.Nodes[0];
            Fnode.BackColor = Color.FromArgb(64, 64, 64);
            for (int i = 0; i < 12; i++)
            {
                Fnode.Nodes[i].BackColor = Color.FromArgb(64, 64, 64);
                for (int j = 0; j < 30; j++)
                {
                    Fnode.Nodes[i].Nodes[j].BackColor = Color.FromArgb(64, 64, 64);
                    // this.treeView1.Nodes[0].BackColor = Color.White;
                }
            }

            if (this.tabControl1.SelectedIndex == 1)//电压
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
                            LogMessage("在电压标签状态下，标志是cell时选中了"+ this.label11.Text + "#堆栈");
                        }
                        else if (this.treeView1.SelectedNode.Level == 2 && (this.treeView1.SelectedNode.Parent.Index + 1).ToString() == this.label11.Text)
                        {
                            this.chart1.Series[this.treeView1.SelectedNode.Index].Enabled = true;
                            LogMessage("在电压标签状态下，标志是cell时选中了" + this.label11.Text + "#堆栈里的cell"+ (this.treeView1.SelectedNode.Index+1).ToString());
                        }
                        else
                        { MessageBox.Show("请选择正确堆栈号节点"); }
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
            else if (this.tabControl1.SelectedIndex == 2) //温度
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
        }

        private void treeView1_Leave(object sender, EventArgs e)
        {

            TreeNode Fnode = this.treeView1.Nodes[0];
            Fnode.BackColor = Color.FromArgb(64,64,64);
            for (int i = 0; i < 12; i++)
            {
                Fnode.Nodes[i].BackColor = Color.FromArgb(64, 64, 64);
                for (int j = 0; j < 30; j++)
                {
                    Fnode.Nodes[i].Nodes[j].BackColor = Color.FromArgb(64, 64, 64);
                    // this.treeView1.Nodes[0].BackColor = Color.White;
                }
            }
            if (this.treeView1.SelectedNode != null)
                this.treeView1.SelectedNode.BackColor = Color.CornflowerBlue;
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            this.chart2.Series.Clear();
            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }

            if (this.tabControl1.SelectedIndex != 2)
            {
                this.tabControl1.SelectTab(2);
            }
            chart2.ChartAreas[0].AxisX.Title = "时 间";
            chart2.ChartAreas[0].AxisY.Title = "温 度";

            // MessageBox.Show(dt.TableName+"_"+n.ToString());
            this.chart2.Titles[0].Text = "堆栈" + this.dateTimePicker4.Value.ToString("yyyy-MM-dd") + " 温度曲线";
            for (int stack_id = 1; stack_id <= 12; stack_id++)
            {
                string querysql = "SELECT * FROM [dbo].[StackValues] where datediff(day, [Timestamp],'" + this.dateTimePicker4.Value.ToString("yyyy-MM-dd") + "')= 0  AND Stack_Id=" + stack_id + " order by [Timestamp] ASC";
                //MessageBox.Show(querysql);
                DataTable dt = DataQueryTable(0, querysql);
                if (dt != null)
                {
                    int n = dt.Rows.Count;
                    if (n <= 0)
                    {
                        MessageBox.Show("stack" + stack_id.ToString() + "没有数据");
                        //this.chart1.Titles[0].Text = "";
                        //return;
                        LogMessage("按钮<栈温度图> 没有查到数据。SQL：" + querysql);
                    }
                    LogMessage("按钮<栈温度图> SQL：" + querysql);
                    List<DateTime> x = new List<DateTime>(); List<double> y = new List<double>();
                    for (int i = 0; i < n; i++)
                    {
                        //add time
                        x.Add(Convert.ToDateTime(dt.Rows[i][1]));
                        //  txt += dt.Rows[i][1].ToString();
                        //add value
                        y.Add(Math.Round(Convert.ToDouble(dt.Rows[i][66].ToString()), 3));

                    }
                    drawLine_temp(stack_id - 1, "stack" + stack_id.ToString(), x, y);
                }
                else { break; }
            }
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            this.chart2.Series.Clear();
            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }

            if (this.tabControl1.SelectedIndex != 2)
            {
                this.tabControl1.SelectTab(2);
            }
            chart2.ChartAreas[0].AxisX.Title = "时 间";
            chart2.ChartAreas[0].AxisY.Title = "温 度";

            // MessageBox.Show(dt.TableName+"_"+n.ToString());
            this.chart2.Titles[0].Text = "堆栈" + this.dateTimePicker6.Value.ToString("yyyy-MM-dd") + "到" + this.dateTimePicker5.Value.ToString("yyyy-MM-dd") + " 温度曲线";
            for (int stack_id = 1; stack_id <= 12; stack_id++)
            {
                string querysql = "SELECT * FROM [dbo].[StackValues] where ([Timestamp] between '" + this.dateTimePicker6.Value.ToString("yyyy-MM-dd") + "' and '" + this.dateTimePicker5.Value.ToString("yyyy-MM-dd") + "')  AND Stack_Id=" + stack_id + " order by [Timestamp] ASC";
                //MessageBox.Show(querysql);
                DataTable dt = DataQueryTable(0, querysql);
                if (dt != null)
                {
                    int n = dt.Rows.Count;
                    if (n <= 0)
                    {
                        MessageBox.Show("stack" + stack_id.ToString() + "没有数据");
                        //this.chart1.Titles[0].Text = "";
                        //return;
                        LogMessage("按钮<栈温度图（a-b）> 没有查到数据。SQL：" + querysql);
                    }
                    List<DateTime> x = new List<DateTime>(); List<double> y = new List<double>();
                    LogMessage("按钮<栈温度图（a-b）> SQL：" + querysql);
                    for (int i = 0; i < n; i++)
                    {
                        //add time
                        x.Add(Convert.ToDateTime(dt.Rows[i][1]));
                        //  txt += dt.Rows[i][1].ToString();
                        //add value
                        y.Add(Math.Round(Convert.ToDouble(dt.Rows[i][66].ToString()), 3));

                    }
                    drawLine_temp(stack_id - 1, "stack" + stack_id.ToString(), x, y);
                }
                else { break; }
            }
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
            this.richTextBox1.SelectionStart = this.richTextBox1.Text.Length;
            this.richTextBox1.SelectionLength = 0;
            this.richTextBox1.Focus();
        }
        /// <summary> 
        /// 显示错误日志 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogError(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            this.richTextBox1.Invoke(la, Color.Red, DateTime.Now.ToString("HH:mm:ss ") +" Error:"+text);
        }
        /// <summary> 
        /// 显示警告信息 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogWarning(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            this.richTextBox1.Invoke(la, Color.Yellow, DateTime.Now.ToString("HH:mm:ss ") + " Warning:" + text);
        }
        /// <summary> 
        /// 显示信息 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogMessage(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            this.richTextBox1.Invoke(la, Color.LightGray, DateTime.Now.ToString("HH:mm:ss ") + " Message:" + text);
        }
        #endregion

    }
}
