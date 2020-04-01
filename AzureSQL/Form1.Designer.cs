using System.Windows.Forms;

namespace AzureSQL
{

    /// <summary>
    /// 解决系统TabControl多余边距问题
    /// </summary>
    public class FullTabControl : System.Windows.Forms.TabControl
    {
        public FullTabControl()
        {
            SetStyles();
        }

        private void SetStyles()
        {
            base.SetStyle(
              
                ControlStyles.DoubleBuffer |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw , true);
            base.UpdateStyles();
        }

        public override System.Drawing.Rectangle DisplayRectangle
        {
            get
            {
                System.Drawing.Rectangle rect = base.DisplayRectangle;
                return new System.Drawing.Rectangle(rect.Left - 0, rect.Top - 0, rect.Width + 0, rect.Height + 0);
            }
        }
    }
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title7 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title8 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title9 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title10 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title11 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title12 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title13 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title14 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title15 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea16 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title16 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.保存图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.还原toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.button15 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new AzureSQL.FullTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button18 = new System.Windows.Forms.Button();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button13 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.button14 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dateTimePicker6 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker5 = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.button17 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.button16 = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dateTimePicker7 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker8 = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.button19 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.dateTimePicker9 = new System.Windows.Forms.DateTimePicker();
            this.button20 = new System.Windows.Forms.Button();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.chart15 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart14 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart13 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart12 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart11 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart10 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart9 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart8 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart7 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart6 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart5 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button7 = new System.Windows.Forms.Button();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.chart16 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel9 = new System.Windows.Forms.Panel();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.dateTimePicker10 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker11 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker12 = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button21 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pwdbox = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.pwdbtn = new System.Windows.Forms.Button();
            this.minbtn = new System.Windows.Forms.Button();
            this.maxbtn = new System.Windows.Forms.Button();
            this.closebtn = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart16)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.DodgerBlue;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 678);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1363, 26);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Image = global::AzureSQL.Properties.Resources.center0;
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(3, 4, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(136, 20);
            this.toolStripStatusLabel1.Text = "远程状态：NaN";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(17, 20);
            this.toolStripStatusLabel4.Text = "  ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel3.Image = global::AzureSQL.Properties.Resources.center0;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(136, 20);
            this.toolStripStatusLabel3.Text = "本地状态：NaN";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(18, 20);
            this.toolStripStatusLabel2.Text = "0";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存图像ToolStripMenuItem,
            this.还原toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 56);
            // 
            // 保存图像ToolStripMenuItem
            // 
            this.保存图像ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.保存图像ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.保存图像ToolStripMenuItem.Image = global::AzureSQL.Properties.Resources.savepic;
            this.保存图像ToolStripMenuItem.Name = "保存图像ToolStripMenuItem";
            this.保存图像ToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.保存图像ToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.保存图像ToolStripMenuItem.Text = "保存图像";
            this.保存图像ToolStripMenuItem.Click += new System.EventHandler(this.保存图像ToolStripMenuItem_Click);
            // 
            // 还原toolStripMenuItem1
            // 
            this.还原toolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.还原toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.还原toolStripMenuItem1.Image = global::AzureSQL.Properties.Resources.recovery;
            this.还原toolStripMenuItem1.Name = "还原toolStripMenuItem1";
            this.还原toolStripMenuItem1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.还原toolStripMenuItem1.Size = new System.Drawing.Size(142, 26);
            this.还原toolStripMenuItem1.Text = "还原";
            this.还原toolStripMenuItem1.Click += new System.EventHandler(this.还原toolStripMenuItem1_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(8, 464);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 14);
            this.label9.TabIndex = 44;
            this.label9.Text = "选中节点：null";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BackColor = System.Drawing.Color.Gray;
            this.treeView1.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(3, 25);
            this.treeView1.Margin = new System.Windows.Forms.Padding(0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(175, 432);
            this.treeView1.TabIndex = 43;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.Leave += new System.EventHandler(this.treeView1_Leave);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "gs200.png");
            this.imageList1.Images.SetKeyName(1, "stack24x24.png");
            this.imageList1.Images.SetKeyName(2, "cell24x24.png");
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.Color.DimGray;
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox3.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBox3.Location = new System.Drawing.Point(57, 13);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(0);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(65, 23);
            this.comboBox3.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(16, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "ESU";
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.BackColor = System.Drawing.Color.DodgerBlue;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(3, 51);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(176, 33);
            this.button8.TabIndex = 21;
            this.button8.Text = "本地数据测试";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.BackColor = System.Drawing.Color.Red;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button9.Location = new System.Drawing.Point(3, 12);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(176, 33);
            this.button9.TabIndex = 22;
            this.button9.Text = "初始化本地表";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(54, 10);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(58, 19);
            this.radioButton1.TabIndex = 23;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "本地";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.OnClick);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(128, 10);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 19);
            this.radioButton2.TabIndex = 24;
            this.radioButton2.Text = "远程";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.OnClick);
            // 
            // button15
            // 
            this.button15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button15.BackColor = System.Drawing.Color.DodgerBlue;
            this.button15.FlatAppearance.BorderSize = 0;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.ForeColor = System.Drawing.Color.White;
            this.button15.Location = new System.Drawing.Point(3, 90);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(176, 33);
            this.button15.TabIndex = 38;
            this.button15.Text = "数据更新";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel5.BackColor = System.Drawing.Color.DimGray;
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.treeView1);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Location = new System.Drawing.Point(3, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(183, 484);
            this.panel5.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(7, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 45;
            this.label7.Text = "堆栈结构";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.DimGray;
            this.splitContainer1.Location = new System.Drawing.Point(4, 37);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Gray;
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Gray;
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1354, 613);
            this.splitContainer1.SplitterDistance = 489;
            this.splitContainer1.TabIndex = 46;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 28);
            this.tabControl1.Location = new System.Drawing.Point(189, 4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1159, 484);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DimGray;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage2.Controls.Add(this.checkBox2);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1151, 448);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "电压";
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.checkBox2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox2.Location = new System.Drawing.Point(221, 421);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(89, 19);
            this.checkBox2.TabIndex = 45;
            this.checkBox2.Text = "显示数据";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(133, 426);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 15);
            this.label11.TabIndex = 44;
            this.label11.Text = "栈号";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(10, 426);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 15);
            this.label10.TabIndex = 43;
            this.label10.Text = "cell/栈";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.button18);
            this.panel2.Controls.Add(this.dateTimePicker3);
            this.panel2.Controls.Add(this.dateTimePicker2);
            this.panel2.Controls.Add(this.button13);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(8, 177);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 232);
            this.panel2.TabIndex = 42;
            // 
            // button18
            // 
            this.button18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button18.BackColor = System.Drawing.Color.DimGray;
            this.button18.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button18.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.ForeColor = System.Drawing.Color.White;
            this.button18.Image = global::AzureSQL.Properties.Resources.stack24x24;
            this.button18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button18.Location = new System.Drawing.Point(2, 104);
            this.button18.Name = "button18";
            this.button18.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button18.Size = new System.Drawing.Size(187, 30);
            this.button18.TabIndex = 41;
            this.button18.Text = "栈电压（a-b）";
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(50, 37);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(131, 25);
            this.dateTimePicker3.TabIndex = 29;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(50, 6);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(131, 25);
            this.dateTimePicker2.TabIndex = 26;
            // 
            // button13
            // 
            this.button13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button13.BackColor = System.Drawing.Color.DimGray;
            this.button13.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Image = global::AzureSQL.Properties.Resources.cell24x24;
            this.button13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button13.Location = new System.Drawing.Point(2, 68);
            this.button13.Name = "button13";
            this.button13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button13.Size = new System.Drawing.Size(187, 30);
            this.button13.TabIndex = 36;
            this.button13.Text = "CELL电压(a-b)";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(7, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 45);
            this.label5.TabIndex = 27;
            this.label5.Text = "日期\r\n\r\n范围";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "0,0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button14);
            this.panel1.Location = new System.Drawing.Point(8, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 150);
            this.panel1.TabIndex = 41;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.DimGray;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::AzureSQL.Properties.Resources.stack24x24;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(2, 73);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(187, 30);
            this.button2.TabIndex = 40;
            this.button2.Text = "栈电压";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(50, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(131, 25);
            this.dateTimePicker1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "日期";
            // 
            // button14
            // 
            this.button14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button14.BackColor = System.Drawing.Color.DimGray;
            this.button14.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.ForeColor = System.Drawing.Color.White;
            this.button14.Image = global::AzureSQL.Properties.Resources.cell24x24;
            this.button14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button14.Location = new System.Drawing.Point(2, 37);
            this.button14.Name = "button14";
            this.button14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button14.Size = new System.Drawing.Size(187, 30);
            this.button14.TabIndex = 37;
            this.button14.Text = "CELL电压";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(1059, 421);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(89, 26);
            this.button5.TabIndex = 13;
            this.button5.Text = "全部数据";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.chart1.BorderlineColor = System.Drawing.Color.DodgerBlue;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart1.BorderlineWidth = 0;
            this.chart1.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BorderSkin.BorderColor = System.Drawing.Color.White;
            this.chart1.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Angle = 90;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.Format = "N3";
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.CursorX.Interval = 0.001D;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.Interval = 0.0001D;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ContextMenuStrip = this.contextMenuStrip1;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(207, 2);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(945, 443);
            this.chart1.TabIndex = 14;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            title1.ForeColor = System.Drawing.Color.Snow;
            title1.Name = "Title1";
            this.chart1.Titles.Add(title1);
            this.chart1.MouseEnter += new System.EventHandler(this.chart1_MouseEnter);
            this.chart1.MouseLeave += new System.EventHandler(this.chart1_MouseLeave);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(932, 426);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 19);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "显示数据";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(850, 423);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(58, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "还原";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.DimGray;
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.chart2);
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1151, 448);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "温度";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Controls.Add(this.dateTimePicker6);
            this.panel4.Controls.Add(this.dateTimePicker5);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.button17);
            this.panel4.Location = new System.Drawing.Point(9, 166);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(191, 181);
            this.panel4.TabIndex = 49;
            // 
            // dateTimePicker6
            // 
            this.dateTimePicker6.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker6.Location = new System.Drawing.Point(51, 9);
            this.dateTimePicker6.Name = "dateTimePicker6";
            this.dateTimePicker6.Size = new System.Drawing.Size(131, 25);
            this.dateTimePicker6.TabIndex = 44;
            // 
            // dateTimePicker5
            // 
            this.dateTimePicker5.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker5.Location = new System.Drawing.Point(51, 40);
            this.dateTimePicker5.Name = "dateTimePicker5";
            this.dateTimePicker5.Size = new System.Drawing.Size(131, 25);
            this.dateTimePicker5.TabIndex = 47;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(8, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 45);
            this.label13.TabIndex = 45;
            this.label13.Text = "日期\r\n\r\n范围";
            // 
            // button17
            // 
            this.button17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button17.BackColor = System.Drawing.Color.DimGray;
            this.button17.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button17.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.ForeColor = System.Drawing.Color.White;
            this.button17.Image = global::AzureSQL.Properties.Resources.stack24x24;
            this.button17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button17.Location = new System.Drawing.Point(1, 71);
            this.button17.Name = "button17";
            this.button17.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button17.Size = new System.Drawing.Size(187, 30);
            this.button17.TabIndex = 43;
            this.button17.Text = "栈温度(a-b)";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.button17_Click_1);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.dateTimePicker4);
            this.panel3.Controls.Add(this.button16);
            this.panel3.Location = new System.Drawing.Point(8, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(192, 136);
            this.panel3.TabIndex = 48;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(8, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 15);
            this.label12.TabIndex = 42;
            this.label12.Text = "日期";
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker4.Location = new System.Drawing.Point(51, 8);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(131, 25);
            this.dateTimePicker4.TabIndex = 41;
            this.dateTimePicker4.ValueChanged += new System.EventHandler(this.button16_Click_1);
            // 
            // button16
            // 
            this.button16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button16.BackColor = System.Drawing.Color.DimGray;
            this.button16.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button16.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.ForeColor = System.Drawing.Color.White;
            this.button16.Image = global::AzureSQL.Properties.Resources.stack24x24;
            this.button16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button16.Location = new System.Drawing.Point(3, 39);
            this.button16.Name = "button16";
            this.button16.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button16.Size = new System.Drawing.Size(187, 30);
            this.button16.TabIndex = 40;
            this.button16.Text = "栈温度";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click_1);
            // 
            // chart2
            // 
            this.chart2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.chart2.BorderlineColor = System.Drawing.Color.DodgerBlue;
            this.chart2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart2.BorderlineWidth = 0;
            this.chart2.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart2.BorderSkin.BorderColor = System.Drawing.Color.White;
            this.chart2.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelStyle.Angle = 90;
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisX.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisX2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisX2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LabelStyle.Format = "N3";
            chartArea2.AxisY.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisY2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.CursorX.Interval = 0.001D;
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.CursorY.Interval = 0.0001D;
            chartArea2.CursorY.IsUserEnabled = true;
            chartArea2.CursorY.IsUserSelectionEnabled = true;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.ContextMenuStrip = this.contextMenuStrip1;
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.ForeColor = System.Drawing.Color.White;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(207, 2);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.LabelForeColor = System.Drawing.Color.White;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(945, 443);
            this.chart2.TabIndex = 15;
            this.chart2.Text = "结构";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            title2.ForeColor = System.Drawing.Color.White;
            title2.Name = "Title1";
            this.chart2.Titles.Add(title2);
            this.chart2.MouseEnter += new System.EventHandler(this.chart2_MouseEnter);
            this.chart2.MouseLeave += new System.EventHandler(this.chart2_MouseLeave);
            this.chart2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart2_MouseMove);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.DimGray;
            this.tabPage5.Controls.Add(this.panel6);
            this.tabPage5.Controls.Add(this.panel7);
            this.tabPage5.Controls.Add(this.chart3);
            this.tabPage5.Location = new System.Drawing.Point(4, 32);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1151, 448);
            this.tabPage5.TabIndex = 3;
            this.tabPage5.Text = "SOC";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DimGray;
            this.panel6.Controls.Add(this.dateTimePicker7);
            this.panel6.Controls.Add(this.dateTimePicker8);
            this.panel6.Controls.Add(this.label15);
            this.panel6.Controls.Add(this.button19);
            this.panel6.Location = new System.Drawing.Point(9, 166);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(191, 181);
            this.panel6.TabIndex = 52;
            // 
            // dateTimePicker7
            // 
            this.dateTimePicker7.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker7.Location = new System.Drawing.Point(51, 9);
            this.dateTimePicker7.Name = "dateTimePicker7";
            this.dateTimePicker7.Size = new System.Drawing.Size(131, 25);
            this.dateTimePicker7.TabIndex = 44;
            // 
            // dateTimePicker8
            // 
            this.dateTimePicker8.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker8.Location = new System.Drawing.Point(51, 40);
            this.dateTimePicker8.Name = "dateTimePicker8";
            this.dateTimePicker8.Size = new System.Drawing.Size(131, 25);
            this.dateTimePicker8.TabIndex = 47;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(8, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 45);
            this.label15.TabIndex = 45;
            this.label15.Text = "日期\r\n\r\n范围";
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.DimGray;
            this.button19.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button19.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.ForeColor = System.Drawing.Color.White;
            this.button19.Image = global::AzureSQL.Properties.Resources.stack24x24;
            this.button19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button19.Location = new System.Drawing.Point(1, 71);
            this.button19.Name = "button19";
            this.button19.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button19.Size = new System.Drawing.Size(187, 30);
            this.button19.TabIndex = 43;
            this.button19.Text = "栈SOC(a-b)";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DimGray;
            this.panel7.Controls.Add(this.label16);
            this.panel7.Controls.Add(this.dateTimePicker9);
            this.panel7.Controls.Add(this.button20);
            this.panel7.Location = new System.Drawing.Point(8, 13);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(192, 136);
            this.panel7.TabIndex = 51;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(8, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 15);
            this.label16.TabIndex = 42;
            this.label16.Text = "日期";
            // 
            // dateTimePicker9
            // 
            this.dateTimePicker9.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker9.Location = new System.Drawing.Point(51, 8);
            this.dateTimePicker9.Name = "dateTimePicker9";
            this.dateTimePicker9.Size = new System.Drawing.Size(131, 25);
            this.dateTimePicker9.TabIndex = 41;
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.DimGray;
            this.button20.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button20.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.ForeColor = System.Drawing.Color.White;
            this.button20.Image = global::AzureSQL.Properties.Resources.stack24x24;
            this.button20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button20.Location = new System.Drawing.Point(2, 39);
            this.button20.Name = "button20";
            this.button20.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button20.Size = new System.Drawing.Size(187, 30);
            this.button20.TabIndex = 40;
            this.button20.Text = "栈SOC";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // chart3
            // 
            this.chart3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.chart3.BorderlineColor = System.Drawing.Color.DodgerBlue;
            this.chart3.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart3.BorderlineWidth = 0;
            this.chart3.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart3.BorderSkin.BorderColor = System.Drawing.Color.White;
            this.chart3.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea3.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisX.IsLabelAutoFit = false;
            chartArea3.AxisX.LabelStyle.Angle = 90;
            chartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisX.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea3.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisX2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisX2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisY.LabelStyle.Format = "N3";
            chartArea3.AxisY.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea3.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisY2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisY2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea3.BackColor = System.Drawing.Color.Transparent;
            chartArea3.CursorX.Interval = 0.001D;
            chartArea3.CursorX.IsUserEnabled = true;
            chartArea3.CursorX.IsUserSelectionEnabled = true;
            chartArea3.CursorY.Interval = 0.0001D;
            chartArea3.CursorY.IsUserEnabled = true;
            chartArea3.CursorY.IsUserSelectionEnabled = true;
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            this.chart3.ContextMenuStrip = this.contextMenuStrip1;
            legend3.BackColor = System.Drawing.Color.Transparent;
            legend3.ForeColor = System.Drawing.Color.White;
            legend3.Name = "Legend1";
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new System.Drawing.Point(207, 2);
            this.chart3.Name = "chart3";
            this.chart3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.LabelForeColor = System.Drawing.Color.White;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart3.Series.Add(series3);
            this.chart3.Size = new System.Drawing.Size(945, 443);
            this.chart3.TabIndex = 50;
            this.chart3.Text = "结构";
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            title3.ForeColor = System.Drawing.Color.White;
            title3.Name = "Title1";
            this.chart3.Titles.Add(title3);
            this.chart3.MouseEnter += new System.EventHandler(this.chart3_MouseEnter);
            this.chart3.MouseLeave += new System.EventHandler(this.chart3_MouseLeave);
            this.chart3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart3_MouseMove);
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScroll = true;
            this.tabPage4.BackColor = System.Drawing.Color.DimGray;
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.button12);
            this.tabPage4.Controls.Add(this.button11);
            this.tabPage4.Controls.Add(this.button10);
            this.tabPage4.Controls.Add(this.chart15);
            this.tabPage4.Controls.Add(this.chart14);
            this.tabPage4.Controls.Add(this.chart13);
            this.tabPage4.Controls.Add(this.chart12);
            this.tabPage4.Controls.Add(this.chart11);
            this.tabPage4.Controls.Add(this.chart10);
            this.tabPage4.Controls.Add(this.chart9);
            this.tabPage4.Controls.Add(this.chart8);
            this.tabPage4.Controls.Add(this.chart7);
            this.tabPage4.Controls.Add(this.chart6);
            this.tabPage4.Controls.Add(this.chart5);
            this.tabPage4.Controls.Add(this.button7);
            this.tabPage4.Controls.Add(this.chart4);
            this.tabPage4.Location = new System.Drawing.Point(4, 32);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage4.Size = new System.Drawing.Size(1151, 448);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "历史曲线";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(411, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 30);
            this.label6.TabIndex = 32;
            this.label6.Text = "堆栈历史曲线";
            // 
            // button12
            // 
            this.button12.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.button12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.GreenYellow;
            this.button12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GreenYellow;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(143, 11);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(50, 30);
            this.button12.TabIndex = 31;
            this.button12.Text = "SOC";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click_1);
            // 
            // button11
            // 
            this.button11.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.button11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(76, 11);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(50, 30);
            this.button11.TabIndex = 30;
            this.button11.Text = "温度";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click_1);
            // 
            // button10
            // 
            this.button10.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(9, 11);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(50, 30);
            this.button10.TabIndex = 29;
            this.button10.Text = "电压";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click_2);
            // 
            // chart15
            // 
            this.chart15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.chart15.BorderlineColor = System.Drawing.Color.DodgerBlue;
            this.chart15.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart15.BorderlineWidth = 0;
            this.chart15.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart15.BorderSkin.BorderColor = System.Drawing.Color.White;
            this.chart15.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea4.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea4.AxisX.IsLabelAutoFit = false;
            chartArea4.AxisX.LabelStyle.Angle = 90;
            chartArea4.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea4.AxisX.LineColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea4.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea4.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea4.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea4.AxisX2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisX2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea4.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea4.AxisY.IsLabelAutoFit = false;
            chartArea4.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            chartArea4.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea4.AxisY.LabelStyle.Format = "N3";
            chartArea4.AxisY.LineColor = System.Drawing.Color.White;
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea4.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea4.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea4.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea4.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea4.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea4.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea4.AxisY2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisY2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea4.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea4.BackColor = System.Drawing.Color.Transparent;
            chartArea4.CursorX.Interval = 0.001D;
            chartArea4.CursorX.IsUserEnabled = true;
            chartArea4.CursorX.IsUserSelectionEnabled = true;
            chartArea4.CursorY.Interval = 0.0001D;
            chartArea4.CursorY.IsUserEnabled = true;
            chartArea4.CursorY.IsUserSelectionEnabled = true;
            chartArea4.Name = "ChartArea1";
            this.chart15.ChartAreas.Add(chartArea4);
            this.chart15.Location = new System.Drawing.Point(966, 817);
            this.chart15.Margin = new System.Windows.Forms.Padding(0);
            this.chart15.Name = "chart15";
            this.chart15.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            series4.LabelForeColor = System.Drawing.Color.White;
            series4.Name = "Series1";
            this.chart15.Series.Add(series4);
            this.chart15.Size = new System.Drawing.Size(480, 250);
            this.chart15.TabIndex = 27;
            this.chart15.Text = "chart15";
            title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            title4.ForeColor = System.Drawing.Color.Snow;
            title4.Name = "Title1";
            this.chart15.Titles.Add(title4);
            this.chart15.MouseEnter += new System.EventHandler(this.chart_MouseEnter);
            this.chart15.MouseLeave += new System.EventHandler(this.chart_MouseLeave);
            // 
            // chart14
            // 
            this.chart14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.chart14.BorderlineColor = System.Drawing.Color.DodgerBlue;
            this.chart14.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart14.BorderlineWidth = 0;
            this.chart14.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart14.BorderSkin.BorderColor = System.Drawing.Color.White;
            this.chart14.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea5.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea5.AxisX.IsLabelAutoFit = false;
            chartArea5.AxisX.LabelStyle.Angle = 90;
            chartArea5.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea5.AxisX.LineColor = System.Drawing.Color.Gainsboro;
            chartArea5.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea5.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea5.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea5.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea5.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea5.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea5.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea5.AxisX2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea5.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea5.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea5.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea5.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea5.AxisX2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea5.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea5.AxisY.IsLabelAutoFit = false;
            chartArea5.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            chartArea5.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea5.AxisY.LabelStyle.Format = "N3";
            chartArea5.AxisY.LineColor = System.Drawing.Color.White;
            chartArea5.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea5.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea5.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea5.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea5.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea5.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea5.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea5.AxisY2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea5.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea5.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea5.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea5.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea5.AxisY2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea5.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea5.BackColor = System.Drawing.Color.Transparent;
            chartArea5.CursorX.Interval = 0.001D;
            chartArea5.CursorX.IsUserEnabled = true;
            chartArea5.CursorX.IsUserSelectionEnabled = true;
            chartArea5.CursorY.Interval = 0.0001D;
            chartArea5.CursorY.IsUserEnabled = true;
            chartArea5.CursorY.IsUserSelectionEnabled = true;
            chartArea5.Name = "ChartArea1";
            this.chart14.ChartAreas.Add(chartArea5);
            this.chart14.Location = new System.Drawing.Point(485, 817);
            this.chart14.Margin = new System.Windows.Forms.Padding(0);
            this.chart14.Name = "chart14";
            this.chart14.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            series5.LabelForeColor = System.Drawing.Color.White;
            series5.Name = "Series1";
            this.chart14.Series.Add(series5);
            this.chart14.Size = new System.Drawing.Size(480, 250);
            this.chart14.TabIndex = 26;
            this.chart14.Text = "chart14";
            title5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            title5.ForeColor = System.Drawing.Color.Snow;
            title5.Name = "Title1";
            this.chart14.Titles.Add(title5);
            this.chart14.MouseEnter += new System.EventHandler(this.chart_MouseEnter);
            this.chart14.MouseLeave += new System.EventHandler(this.chart_MouseLeave);
            // 
            // chart13
            // 
            this.chart13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.chart13.BorderlineColor = System.Drawing.Color.DodgerBlue;
            this.chart13.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart13.BorderlineWidth = 0;
            this.chart13.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart13.BorderSkin.BorderColor = System.Drawing.Color.White;
            this.chart13.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea6.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea6.AxisX.IsLabelAutoFit = false;
            chartArea6.AxisX.LabelStyle.Angle = 90;
            chartArea6.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea6.AxisX.LineColor = System.Drawing.Color.Gainsboro;
            chartArea6.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea6.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea6.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea6.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea6.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea6.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea6.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea6.AxisX2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea6.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea6.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea6.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea6.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea6.AxisX2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea6.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea6.AxisY.IsLabelAutoFit = false;
            chartArea6.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            chartArea6.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea6.AxisY.LabelStyle.Format = "N3";
            chartArea6.AxisY.LineColor = System.Drawing.Color.White;
            chartArea6.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea6.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea6.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea6.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea6.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea6.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea6.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea6.AxisY2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea6.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea6.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea6.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea6.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea6.AxisY2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea6.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea6.BackColor = System.Drawing.Color.Transparent;
            chartArea6.CursorX.Interval = 0.001D;
            chartArea6.CursorX.IsUserEnabled = true;
            chartArea6.CursorX.IsUserSelectionEnabled = true;
            chartArea6.CursorY.Interval = 0.0001D;
            chartArea6.CursorY.IsUserEnabled = true;
            chartArea6.CursorY.IsUserSelectionEnabled = true;
            chartArea6.Name = "ChartArea1";
            this.chart13.ChartAreas.Add(chartArea6);
            this.chart13.Location = new System.Drawing.Point(4, 817);
            this.chart13.Margin = new System.Windows.Forms.Padding(0);
            this.chart13.Name = "chart13";
            this.chart13.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            series6.LabelForeColor = System.Drawing.Color.White;
            series6.Name = "Series1";
            this.chart13.Series.Add(series6);
            this.chart13.Size = new System.Drawing.Size(480, 250);
            this.chart13.TabIndex = 25;
            this.chart13.Text = "chart13";
            title6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            title6.ForeColor = System.Drawing.Color.Snow;
            title6.Name = "Title1";
            this.chart13.Titles.Add(title6);
            this.chart13.MouseEnter += new System.EventHandler(this.chart_MouseEnter);
            this.chart13.MouseLeave += new System.EventHandler(this.chart_MouseLeave);
            // 
            // chart12
            // 
            this.chart12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.chart12.BorderlineColor = System.Drawing.Color.DodgerBlue;
            this.chart12.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart12.BorderlineWidth = 0;
            this.chart12.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart12.BorderSkin.BorderColor = System.Drawing.Color.White;
            this.chart12.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea7.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea7.AxisX.IsLabelAutoFit = false;
            chartArea7.AxisX.LabelStyle.Angle = 90;
            chartArea7.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea7.AxisX.LineColor = System.Drawing.Color.Gainsboro;
            chartArea7.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea7.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea7.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea7.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea7.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea7.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea7.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea7.AxisX2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea7.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea7.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea7.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea7.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea7.AxisX2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea7.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea7.AxisY.IsLabelAutoFit = false;
            chartArea7.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            chartArea7.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea7.AxisY.LabelStyle.Format = "N3";
            chartArea7.AxisY.LineColor = System.Drawing.Color.White;
            chartArea7.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea7.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea7.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea7.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea7.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea7.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea7.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea7.AxisY2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea7.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea7.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea7.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea7.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea7.AxisY2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea7.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea7.BackColor = System.Drawing.Color.Transparent;
            chartArea7.CursorX.Interval = 0.001D;
            chartArea7.CursorX.IsUserEnabled = true;
            chartArea7.CursorX.IsUserSelectionEnabled = true;
            chartArea7.CursorY.Interval = 0.0001D;
            chartArea7.CursorY.IsUserEnabled = true;
            chartArea7.CursorY.IsUserSelectionEnabled = true;
            chartArea7.Name = "ChartArea1";
            this.chart12.ChartAreas.Add(chartArea7);
            this.chart12.Location = new System.Drawing.Point(966, 566);
            this.chart12.Margin = new System.Windows.Forms.Padding(0);
            this.chart12.Name = "chart12";
            this.chart12.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            series7.LabelForeColor = System.Drawing.Color.White;
            series7.Name = "Series1";
            this.chart12.Series.Add(series7);
            this.chart12.Size = new System.Drawing.Size(480, 250);
            this.chart12.TabIndex = 24;
            this.chart12.Text = "chart12";
            title7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            title7.ForeColor = System.Drawing.Color.Snow;
            title7.Name = "Title1";
            this.chart12.Titles.Add(title7);
            this.chart12.MouseEnter += new System.EventHandler(this.chart_MouseEnter);
            this.chart12.MouseLeave += new System.EventHandler(this.chart_MouseLeave);
            // 
            // chart11
            // 
            this.chart11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.chart11.BorderlineColor = System.Drawing.Color.DodgerBlue;
            this.chart11.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart11.BorderlineWidth = 0;
            this.chart11.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart11.BorderSkin.BorderColor = System.Drawing.Color.White;
            this.chart11.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea8.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea8.AxisX.IsLabelAutoFit = false;
            chartArea8.AxisX.LabelStyle.Angle = 90;
            chartArea8.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea8.AxisX.LineColor = System.Drawing.Color.Gainsboro;
            chartArea8.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea8.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea8.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea8.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea8.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea8.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea8.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea8.AxisX2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea8.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea8.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea8.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea8.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea8.AxisX2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea8.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea8.AxisY.IsLabelAutoFit = false;
            chartArea8.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            chartArea8.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea8.AxisY.LabelStyle.Format = "N3";
            chartArea8.AxisY.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea8.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea8.AxisY2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea8.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea8.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea8.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea8.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea8.AxisY2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea8.BackColor = System.Drawing.Color.Transparent;
            chartArea8.CursorX.Interval = 0.001D;
            chartArea8.CursorX.IsUserEnabled = true;
            chartArea8.CursorX.IsUserSelectionEnabled = true;
            chartArea8.CursorY.Interval = 0.0001D;
            chartArea8.CursorY.IsUserEnabled = true;
            chartArea8.CursorY.IsUserSelectionEnabled = true;
            chartArea8.Name = "ChartArea1";
            this.chart11.ChartAreas.Add(chartArea8);
            this.chart11.Location = new System.Drawing.Point(485, 566);
            this.chart11.Margin = new System.Windows.Forms.Padding(0);
            this.chart11.Name = "chart11";
            this.chart11.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            series8.LabelForeColor = System.Drawing.Color.White;
            series8.Name = "Series1";
            this.chart11.Series.Add(series8);
            this.chart11.Size = new System.Drawing.Size(480, 250);
            this.chart11.TabIndex = 23;
            this.chart11.Text = "chart11";
            title8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            title8.ForeColor = System.Drawing.Color.Snow;
            title8.Name = "Title1";
            this.chart11.Titles.Add(title8);
            this.chart11.MouseEnter += new System.EventHandler(this.chart_MouseEnter);
            this.chart11.MouseLeave += new System.EventHandler(this.chart_MouseLeave);
            // 
            // chart10
            // 
            this.chart10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.chart10.BorderlineColor = System.Drawing.Color.DodgerBlue;
            this.chart10.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart10.BorderlineWidth = 0;
            this.chart10.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart10.BorderSkin.BorderColor = System.Drawing.Color.White;
            this.chart10.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea9.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea9.AxisX.IsLabelAutoFit = false;
            chartArea9.AxisX.LabelStyle.Angle = 90;
            chartArea9.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea9.AxisX.LineColor = System.Drawing.Color.Gainsboro;
            chartArea9.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea9.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea9.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea9.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea9.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea9.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea9.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea9.AxisX2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea9.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea9.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea9.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea9.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea9.AxisX2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea9.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea9.AxisY.IsLabelAutoFit = false;
            chartArea9.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            chartArea9.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea9.AxisY.LabelStyle.Format = "N3";
            chartArea9.AxisY.LineColor = System.Drawing.Color.White;
            chartArea9.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea9.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea9.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea9.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea9.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea9.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea9.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea9.AxisY2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea9.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea9.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea9.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea9.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea9.AxisY2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea9.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea9.BackColor = System.Drawing.Color.Transparent;
            chartArea9.CursorX.Interval = 0.001D;
            chartArea9.CursorX.IsUserEnabled = true;
            chartArea9.CursorX.IsUserSelectionEnabled = true;
            chartArea9.CursorY.Interval = 0.0001D;
            chartArea9.CursorY.IsUserEnabled = true;
            chartArea9.CursorY.IsUserSelectionEnabled = true;
            chartArea9.Name = "ChartArea1";
            this.chart10.ChartAreas.Add(chartArea9);
            this.chart10.Location = new System.Drawing.Point(4, 566);
            this.chart10.Margin = new System.Windows.Forms.Padding(0);
            this.chart10.Name = "chart10";
            this.chart10.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            series9.LabelForeColor = System.Drawing.Color.White;
            series9.Name = "Series1";
            this.chart10.Series.Add(series9);
            this.chart10.Size = new System.Drawing.Size(480, 250);
            this.chart10.TabIndex = 22;
            this.chart10.Text = "chart10";
            title9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            title9.ForeColor = System.Drawing.Color.Snow;
            title9.Name = "Title1";
            this.chart10.Titles.Add(title9);
            this.chart10.MouseEnter += new System.EventHandler(this.chart_MouseEnter);
            this.chart10.MouseLeave += new System.EventHandler(this.chart_MouseLeave);
            // 
            // chart9
            // 
            this.chart9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.chart9.BorderlineColor = System.Drawing.Color.DodgerBlue;
            this.chart9.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart9.BorderlineWidth = 0;
            this.chart9.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart9.BorderSkin.BorderColor = System.Drawing.Color.White;
            this.chart9.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea10.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea10.AxisX.IsLabelAutoFit = false;
            chartArea10.AxisX.LabelStyle.Angle = 90;
            chartArea10.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea10.AxisX.LineColor = System.Drawing.Color.Gainsboro;
            chartArea10.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea10.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea10.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea10.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea10.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea10.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea10.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea10.AxisX2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea10.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea10.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea10.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea10.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea10.AxisX2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea10.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea10.AxisY.IsLabelAutoFit = false;
            chartArea10.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            chartArea10.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea10.AxisY.LabelStyle.Format = "N3";
            chartArea10.AxisY.LineColor = System.Drawing.Color.White;
            chartArea10.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea10.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea10.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea10.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea10.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea10.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea10.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea10.AxisY2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea10.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea10.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea10.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea10.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea10.AxisY2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea10.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea10.BackColor = System.Drawing.Color.Transparent;
            chartArea10.CursorX.Interval = 0.001D;
            chartArea10.CursorX.IsUserEnabled = true;
            chartArea10.CursorX.IsUserSelectionEnabled = true;
            chartArea10.CursorY.Interval = 0.0001D;
            chartArea10.CursorY.IsUserEnabled = true;
            chartArea10.CursorY.IsUserSelectionEnabled = true;
            chartArea10.Name = "ChartArea1";
            this.chart9.ChartAreas.Add(chartArea10);
            this.chart9.Location = new System.Drawing.Point(966, 315);
            this.chart9.Margin = new System.Windows.Forms.Padding(0);
            this.chart9.Name = "chart9";
            this.chart9.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            series10.LabelForeColor = System.Drawing.Color.White;
            series10.Name = "Series1";
            this.chart9.Series.Add(series10);
            this.chart9.Size = new System.Drawing.Size(480, 250);
            this.chart9.TabIndex = 21;
            this.chart9.Text = "chart9";
            title10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            title10.ForeColor = System.Drawing.Color.Snow;
            title10.Name = "Title1";
            this.chart9.Titles.Add(title10);
            this.chart9.MouseEnter += new System.EventHandler(this.chart_MouseEnter);
            this.chart9.MouseLeave += new System.EventHandler(this.chart_MouseLeave);
            // 
            // chart8
            // 
            this.chart8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.chart8.BorderlineColor = System.Drawing.Color.DodgerBlue;
            this.chart8.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart8.BorderlineWidth = 0;
            this.chart8.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart8.BorderSkin.BorderColor = System.Drawing.Color.White;
            this.chart8.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea11.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea11.AxisX.IsLabelAutoFit = false;
            chartArea11.AxisX.LabelStyle.Angle = 90;
            chartArea11.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea11.AxisX.LineColor = System.Drawing.Color.Gainsboro;
            chartArea11.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea11.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea11.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea11.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea11.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea11.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea11.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea11.AxisX2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea11.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea11.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea11.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea11.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea11.AxisX2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea11.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea11.AxisY.IsLabelAutoFit = false;
            chartArea11.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            chartArea11.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea11.AxisY.LabelStyle.Format = "N3";
            chartArea11.AxisY.LineColor = System.Drawing.Color.White;
            chartArea11.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea11.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea11.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea11.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea11.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea11.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea11.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea11.AxisY2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea11.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea11.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea11.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea11.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea11.AxisY2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea11.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea11.BackColor = System.Drawing.Color.Transparent;
            chartArea11.CursorX.Interval = 0.001D;
            chartArea11.CursorX.IsUserEnabled = true;
            chartArea11.CursorX.IsUserSelectionEnabled = true;
            chartArea11.CursorY.Interval = 0.0001D;
            chartArea11.CursorY.IsUserEnabled = true;
            chartArea11.CursorY.IsUserSelectionEnabled = true;
            chartArea11.Name = "ChartArea1";
            this.chart8.ChartAreas.Add(chartArea11);
            this.chart8.Location = new System.Drawing.Point(485, 315);
            this.chart8.Margin = new System.Windows.Forms.Padding(0);
            this.chart8.Name = "chart8";
            this.chart8.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            series11.LabelForeColor = System.Drawing.Color.White;
            series11.Name = "Series1";
            this.chart8.Series.Add(series11);
            this.chart8.Size = new System.Drawing.Size(480, 250);
            this.chart8.TabIndex = 20;
            this.chart8.Text = "chart8";
            title11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            title11.ForeColor = System.Drawing.Color.Snow;
            title11.Name = "Title1";
            this.chart8.Titles.Add(title11);
            this.chart8.MouseEnter += new System.EventHandler(this.chart_MouseEnter);
            this.chart8.MouseLeave += new System.EventHandler(this.chart_MouseLeave);
            // 
            // chart7
            // 
            this.chart7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.chart7.BorderlineColor = System.Drawing.Color.DodgerBlue;
            this.chart7.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart7.BorderlineWidth = 0;
            this.chart7.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart7.BorderSkin.BorderColor = System.Drawing.Color.White;
            this.chart7.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea12.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea12.AxisX.IsLabelAutoFit = false;
            chartArea12.AxisX.LabelStyle.Angle = 90;
            chartArea12.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea12.AxisX.LineColor = System.Drawing.Color.Gainsboro;
            chartArea12.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea12.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea12.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea12.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea12.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea12.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea12.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea12.AxisX2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea12.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea12.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea12.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea12.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea12.AxisX2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea12.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea12.AxisY.IsLabelAutoFit = false;
            chartArea12.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            chartArea12.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea12.AxisY.LabelStyle.Format = "N3";
            chartArea12.AxisY.LineColor = System.Drawing.Color.White;
            chartArea12.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea12.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea12.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea12.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea12.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea12.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea12.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea12.AxisY2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea12.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea12.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea12.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea12.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea12.AxisY2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea12.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea12.BackColor = System.Drawing.Color.Transparent;
            chartArea12.CursorX.Interval = 0.001D;
            chartArea12.CursorX.IsUserEnabled = true;
            chartArea12.CursorX.IsUserSelectionEnabled = true;
            chartArea12.CursorY.Interval = 0.0001D;
            chartArea12.CursorY.IsUserEnabled = true;
            chartArea12.CursorY.IsUserSelectionEnabled = true;
            chartArea12.Name = "ChartArea1";
            this.chart7.ChartAreas.Add(chartArea12);
            this.chart7.Location = new System.Drawing.Point(4, 315);
            this.chart7.Margin = new System.Windows.Forms.Padding(0);
            this.chart7.Name = "chart7";
            this.chart7.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            series12.LabelForeColor = System.Drawing.Color.White;
            series12.Name = "Series1";
            this.chart7.Series.Add(series12);
            this.chart7.Size = new System.Drawing.Size(480, 250);
            this.chart7.TabIndex = 19;
            this.chart7.Text = "chart7";
            title12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            title12.ForeColor = System.Drawing.Color.Snow;
            title12.Name = "Title1";
            this.chart7.Titles.Add(title12);
            this.chart7.MouseEnter += new System.EventHandler(this.chart_MouseEnter);
            this.chart7.MouseLeave += new System.EventHandler(this.chart_MouseLeave);
            // 
            // chart6
            // 
            this.chart6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.chart6.BorderlineColor = System.Drawing.Color.DodgerBlue;
            this.chart6.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart6.BorderlineWidth = 0;
            this.chart6.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart6.BorderSkin.BorderColor = System.Drawing.Color.White;
            this.chart6.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea13.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea13.AxisX.IsLabelAutoFit = false;
            chartArea13.AxisX.LabelStyle.Angle = 90;
            chartArea13.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea13.AxisX.LineColor = System.Drawing.Color.Gainsboro;
            chartArea13.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea13.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea13.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea13.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea13.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea13.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea13.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea13.AxisX2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea13.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea13.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea13.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea13.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea13.AxisX2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea13.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea13.AxisY.IsLabelAutoFit = false;
            chartArea13.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            chartArea13.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea13.AxisY.LabelStyle.Format = "N3";
            chartArea13.AxisY.LineColor = System.Drawing.Color.White;
            chartArea13.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea13.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea13.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea13.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea13.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea13.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea13.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea13.AxisY2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea13.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea13.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea13.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea13.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea13.AxisY2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea13.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea13.BackColor = System.Drawing.Color.Transparent;
            chartArea13.CursorX.Interval = 0.001D;
            chartArea13.CursorX.IsUserEnabled = true;
            chartArea13.CursorX.IsUserSelectionEnabled = true;
            chartArea13.CursorY.Interval = 0.0001D;
            chartArea13.CursorY.IsUserEnabled = true;
            chartArea13.CursorY.IsUserSelectionEnabled = true;
            chartArea13.Name = "ChartArea1";
            this.chart6.ChartAreas.Add(chartArea13);
            this.chart6.Location = new System.Drawing.Point(966, 64);
            this.chart6.Margin = new System.Windows.Forms.Padding(0);
            this.chart6.Name = "chart6";
            this.chart6.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            series13.LabelForeColor = System.Drawing.Color.White;
            series13.Name = "Series1";
            this.chart6.Series.Add(series13);
            this.chart6.Size = new System.Drawing.Size(480, 250);
            this.chart6.TabIndex = 18;
            this.chart6.Text = "chart6";
            title13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            title13.ForeColor = System.Drawing.Color.Snow;
            title13.Name = "Title1";
            this.chart6.Titles.Add(title13);
            this.chart6.MouseEnter += new System.EventHandler(this.chart_MouseEnter);
            this.chart6.MouseLeave += new System.EventHandler(this.chart_MouseLeave);
            // 
            // chart5
            // 
            this.chart5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.chart5.BorderlineColor = System.Drawing.Color.DodgerBlue;
            this.chart5.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart5.BorderlineWidth = 0;
            this.chart5.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart5.BorderSkin.BorderColor = System.Drawing.Color.White;
            this.chart5.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea14.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea14.AxisX.IsLabelAutoFit = false;
            chartArea14.AxisX.LabelStyle.Angle = 90;
            chartArea14.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea14.AxisX.LineColor = System.Drawing.Color.Gainsboro;
            chartArea14.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea14.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea14.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea14.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea14.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea14.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea14.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea14.AxisX2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea14.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea14.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea14.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea14.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea14.AxisX2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea14.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea14.AxisY.IsLabelAutoFit = false;
            chartArea14.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            chartArea14.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea14.AxisY.LabelStyle.Format = "N3";
            chartArea14.AxisY.LineColor = System.Drawing.Color.White;
            chartArea14.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea14.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea14.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea14.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea14.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea14.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea14.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea14.AxisY2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea14.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea14.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea14.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea14.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea14.AxisY2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea14.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea14.BackColor = System.Drawing.Color.Transparent;
            chartArea14.CursorX.Interval = 0.001D;
            chartArea14.CursorX.IsUserEnabled = true;
            chartArea14.CursorX.IsUserSelectionEnabled = true;
            chartArea14.CursorY.Interval = 0.0001D;
            chartArea14.CursorY.IsUserEnabled = true;
            chartArea14.CursorY.IsUserSelectionEnabled = true;
            chartArea14.Name = "ChartArea1";
            this.chart5.ChartAreas.Add(chartArea14);
            this.chart5.Location = new System.Drawing.Point(485, 64);
            this.chart5.Margin = new System.Windows.Forms.Padding(0);
            this.chart5.Name = "chart5";
            this.chart5.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series14.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            series14.LabelForeColor = System.Drawing.Color.White;
            series14.Name = "Series1";
            this.chart5.Series.Add(series14);
            this.chart5.Size = new System.Drawing.Size(480, 250);
            this.chart5.TabIndex = 17;
            this.chart5.Text = "chart5";
            title14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            title14.ForeColor = System.Drawing.Color.Snow;
            title14.Name = "Title1";
            this.chart5.Titles.Add(title14);
            this.chart5.MouseEnter += new System.EventHandler(this.chart_MouseEnter);
            this.chart5.MouseLeave += new System.EventHandler(this.chart_MouseLeave);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(874, -231);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 16;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // chart4
            // 
            this.chart4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.chart4.BorderlineColor = System.Drawing.Color.DodgerBlue;
            this.chart4.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart4.BorderlineWidth = 0;
            this.chart4.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart4.BorderSkin.BorderColor = System.Drawing.Color.White;
            this.chart4.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea15.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea15.AxisX.IsLabelAutoFit = false;
            chartArea15.AxisX.LabelStyle.Angle = 90;
            chartArea15.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea15.AxisX.LineColor = System.Drawing.Color.Gainsboro;
            chartArea15.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea15.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea15.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea15.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea15.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea15.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea15.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea15.AxisX2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea15.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea15.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea15.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea15.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea15.AxisX2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea15.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea15.AxisY.IsLabelAutoFit = false;
            chartArea15.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            chartArea15.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea15.AxisY.LabelStyle.Format = "N3";
            chartArea15.AxisY.LineColor = System.Drawing.Color.White;
            chartArea15.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea15.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea15.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea15.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea15.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea15.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea15.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea15.AxisY2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea15.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea15.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea15.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea15.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea15.AxisY2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea15.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea15.BackColor = System.Drawing.Color.Transparent;
            chartArea15.CursorX.Interval = 0.001D;
            chartArea15.CursorX.IsUserEnabled = true;
            chartArea15.CursorX.IsUserSelectionEnabled = true;
            chartArea15.CursorY.Interval = 0.0001D;
            chartArea15.CursorY.IsUserEnabled = true;
            chartArea15.CursorY.IsUserSelectionEnabled = true;
            chartArea15.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea15);
            this.chart4.Location = new System.Drawing.Point(4, 64);
            this.chart4.Margin = new System.Windows.Forms.Padding(0);
            this.chart4.Name = "chart4";
            this.chart4.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series15.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            series15.LabelForeColor = System.Drawing.Color.White;
            series15.Name = "Series1";
            this.chart4.Series.Add(series15);
            this.chart4.Size = new System.Drawing.Size(480, 250);
            this.chart4.TabIndex = 15;
            this.chart4.Text = "chart4";
            title15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            title15.ForeColor = System.Drawing.Color.Snow;
            title15.Name = "Title1";
            this.chart4.Titles.Add(title15);
            this.chart4.MouseEnter += new System.EventHandler(this.chart_MouseEnter);
            this.chart4.MouseLeave += new System.EventHandler(this.chart_MouseLeave);
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.DimGray;
            this.tabPage6.Controls.Add(this.chart16);
            this.tabPage6.Controls.Add(this.panel9);
            this.tabPage6.Controls.Add(this.panel10);
            this.tabPage6.Controls.Add(this.comboBox3);
            this.tabPage6.Controls.Add(this.label4);
            this.tabPage6.Location = new System.Drawing.Point(4, 32);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage6.Size = new System.Drawing.Size(1151, 448);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "ESU";
            // 
            // chart16
            // 
            this.chart16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.chart16.BorderlineColor = System.Drawing.Color.DodgerBlue;
            this.chart16.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart16.BorderlineWidth = 0;
            this.chart16.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart16.BorderSkin.BorderColor = System.Drawing.Color.White;
            this.chart16.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea16.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea16.AxisX.IsLabelAutoFit = false;
            chartArea16.AxisX.LabelStyle.Angle = 90;
            chartArea16.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea16.AxisX.LineColor = System.Drawing.Color.Gainsboro;
            chartArea16.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea16.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea16.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea16.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea16.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea16.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea16.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea16.AxisX2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea16.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea16.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea16.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea16.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea16.AxisX2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea16.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea16.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea16.AxisY.LabelStyle.Format = "N3";
            chartArea16.AxisY.LineColor = System.Drawing.Color.White;
            chartArea16.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea16.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea16.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea16.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea16.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea16.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea16.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea16.AxisY2.LineColor = System.Drawing.Color.Gainsboro;
            chartArea16.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea16.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea16.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea16.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea16.AxisY2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea16.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea16.BackColor = System.Drawing.Color.Transparent;
            chartArea16.CursorX.Interval = 0.001D;
            chartArea16.CursorX.IsUserEnabled = true;
            chartArea16.CursorX.IsUserSelectionEnabled = true;
            chartArea16.CursorY.Interval = 0.0001D;
            chartArea16.CursorY.IsUserEnabled = true;
            chartArea16.CursorY.IsUserSelectionEnabled = true;
            chartArea16.Name = "ChartArea1";
            this.chart16.ChartAreas.Add(chartArea16);
            this.chart16.ContextMenuStrip = this.contextMenuStrip1;
            legend4.BackColor = System.Drawing.Color.Transparent;
            legend4.ForeColor = System.Drawing.Color.White;
            legend4.Name = "Legend1";
            this.chart16.Legends.Add(legend4);
            this.chart16.Location = new System.Drawing.Point(207, 2);
            this.chart16.Name = "chart16";
            this.chart16.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series16.LabelForeColor = System.Drawing.Color.White;
            series16.Legend = "Legend1";
            series16.Name = "Series1";
            this.chart16.Series.Add(series16);
            this.chart16.Size = new System.Drawing.Size(945, 443);
            this.chart16.TabIndex = 45;
            this.chart16.Text = "结构";
            title16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            title16.ForeColor = System.Drawing.Color.White;
            title16.Name = "Title1";
            this.chart16.Titles.Add(title16);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.DimGray;
            this.panel9.Controls.Add(this.comboBox6);
            this.panel9.Controls.Add(this.comboBox7);
            this.panel9.Controls.Add(this.label19);
            this.panel9.Controls.Add(this.label20);
            this.panel9.Controls.Add(this.dateTimePicker10);
            this.panel9.Controls.Add(this.dateTimePicker11);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Location = new System.Drawing.Point(8, 223);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(192, 211);
            this.panel9.TabIndex = 44;
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "加热器温度",
            "液体温度",
            "压力",
            "泵速"});
            this.comboBox6.Location = new System.Drawing.Point(49, 129);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(131, 23);
            this.comboBox6.TabIndex = 23;
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Items.AddRange(new object[] {
            "加热器温度",
            "液体温度",
            "压力",
            "泵速"});
            this.comboBox7.Location = new System.Drawing.Point(49, 82);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(131, 23);
            this.comboBox7.TabIndex = 22;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(8, 134);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 15);
            this.label19.TabIndex = 23;
            this.label19.Text = "阴极";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(8, 83);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 15);
            this.label20.TabIndex = 22;
            this.label20.Text = "阳极";
            // 
            // dateTimePicker10
            // 
            this.dateTimePicker10.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker10.Location = new System.Drawing.Point(50, 37);
            this.dateTimePicker10.Name = "dateTimePicker10";
            this.dateTimePicker10.Size = new System.Drawing.Size(131, 25);
            this.dateTimePicker10.TabIndex = 29;
            // 
            // dateTimePicker11
            // 
            this.dateTimePicker11.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker11.Location = new System.Drawing.Point(50, 6);
            this.dateTimePicker11.Name = "dateTimePicker11";
            this.dateTimePicker11.Size = new System.Drawing.Size(131, 25);
            this.dateTimePicker11.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(7, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 45);
            this.label8.TabIndex = 27;
            this.label8.Text = "日期\r\n\r\n范围";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.DimGray;
            this.panel10.Controls.Add(this.label18);
            this.panel10.Controls.Add(this.label17);
            this.panel10.Controls.Add(this.comboBox5);
            this.panel10.Controls.Add(this.comboBox4);
            this.panel10.Controls.Add(this.dateTimePicker12);
            this.panel10.Controls.Add(this.label14);
            this.panel10.Location = new System.Drawing.Point(8, 45);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(192, 150);
            this.panel10.TabIndex = 43;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(8, 95);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 15);
            this.label18.TabIndex = 21;
            this.label18.Text = "阴极";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(8, 51);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 15);
            this.label17.TabIndex = 20;
            this.label17.Text = "阳极";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "加热器温度",
            "液体温度",
            "压力",
            "泵速"});
            this.comboBox5.Location = new System.Drawing.Point(49, 92);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(131, 23);
            this.comboBox5.TabIndex = 19;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "加热器温度",
            "液体温度",
            "压力",
            "泵速"});
            this.comboBox4.Location = new System.Drawing.Point(49, 48);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(131, 23);
            this.comboBox4.TabIndex = 18;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // dateTimePicker12
            // 
            this.dateTimePicker12.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dateTimePicker12.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dateTimePicker12.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker12.Location = new System.Drawing.Point(50, 6);
            this.dateTimePicker12.Name = "dateTimePicker12";
            this.dateTimePicker12.Size = new System.Drawing.Size(131, 25);
            this.dateTimePicker12.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(7, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 15);
            this.label14.TabIndex = 17;
            this.label14.Text = "日期";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DimGray;
            this.tabPage1.Controls.Add(this.button21);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1151, 448);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(436, 17);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(75, 23);
            this.button21.TabIndex = 47;
            this.button21.Text = "button21";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 6.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1022, 360);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridView1_DataError);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(8, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(366, 23);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(6, 58);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(282, 23);
            this.comboBox2.TabIndex = 14;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(320, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(1354, 120);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(947, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 34);
            this.button1.TabIndex = 47;
            this.button1.Text = "设置";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pwdbox
            // 
            this.pwdbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pwdbox.BackColor = System.Drawing.Color.Gainsboro;
            this.pwdbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pwdbox.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pwdbox.Location = new System.Drawing.Point(1026, 5);
            this.pwdbox.Name = "pwdbox";
            this.pwdbox.Size = new System.Drawing.Size(100, 23);
            this.pwdbox.TabIndex = 48;
            this.pwdbox.UseSystemPasswordChar = true;
            this.pwdbox.Visible = false;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel8.Controls.Add(this.button3);
            this.panel8.Controls.Add(this.button9);
            this.panel8.Controls.Add(this.button8);
            this.panel8.Controls.Add(this.button15);
            this.panel8.Location = new System.Drawing.Point(943, 33);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(182, 200);
            this.panel8.TabIndex = 48;
            this.panel8.Visible = false;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.DimGray;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(3, 129);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(176, 33);
            this.button3.TabIndex = 39;
            this.button3.Text = "关闭";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // pwdbtn
            // 
            this.pwdbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pwdbtn.BackColor = System.Drawing.Color.DimGray;
            this.pwdbtn.FlatAppearance.BorderSize = 0;
            this.pwdbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.pwdbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pwdbtn.Font = new System.Drawing.Font("黑体", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pwdbtn.ForeColor = System.Drawing.Color.White;
            this.pwdbtn.Location = new System.Drawing.Point(1131, 7);
            this.pwdbtn.Name = "pwdbtn";
            this.pwdbtn.Size = new System.Drawing.Size(49, 20);
            this.pwdbtn.TabIndex = 49;
            this.pwdbtn.Text = "确认";
            this.pwdbtn.UseVisualStyleBackColor = false;
            this.pwdbtn.Visible = false;
            this.pwdbtn.Click += new System.EventHandler(this.pwdbtn_Click);
            // 
            // minbtn
            // 
            this.minbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.minbtn.FlatAppearance.BorderSize = 0;
            this.minbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.minbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minbtn.Font = new System.Drawing.Font("等线", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.minbtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.minbtn.Location = new System.Drawing.Point(1225, 0);
            this.minbtn.Name = "minbtn";
            this.minbtn.Size = new System.Drawing.Size(45, 34);
            this.minbtn.TabIndex = 50;
            this.minbtn.Text = "━";
            this.minbtn.UseVisualStyleBackColor = false;
            this.minbtn.Click += new System.EventHandler(this.minbtn_Click);
            // 
            // maxbtn
            // 
            this.maxbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.maxbtn.FlatAppearance.BorderSize = 0;
            this.maxbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.maxbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maxbtn.Font = new System.Drawing.Font("等线", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.maxbtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.maxbtn.Location = new System.Drawing.Point(1271, 0);
            this.maxbtn.Name = "maxbtn";
            this.maxbtn.Size = new System.Drawing.Size(45, 34);
            this.maxbtn.TabIndex = 51;
            this.maxbtn.Text = "◻";
            this.maxbtn.UseVisualStyleBackColor = false;
            this.maxbtn.Click += new System.EventHandler(this.maxbtn_Click);
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.closebtn.FlatAppearance.BorderSize = 0;
            this.closebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("黑体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.closebtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.closebtn.Location = new System.Drawing.Point(1317, 0);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(45, 34);
            this.closebtn.TabIndex = 52;
            this.closebtn.Text = "×";
            this.closebtn.UseVisualStyleBackColor = false;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(4, 654);
            this.button6.Margin = new System.Windows.Forms.Padding(0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(65, 23);
            this.button6.TabIndex = 53;
            this.button6.Text = "消息";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1363, 704);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.closebtn);
            this.Controls.Add(this.maxbtn);
            this.Controls.Add(this.minbtn);
            this.Controls.Add(this.pwdbtn);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.pwdbox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart16)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimePicker5;
        private System.Windows.Forms.DateTimePicker dateTimePicker6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DateTimePicker dateTimePicker7;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.DateTimePicker dateTimePicker8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dateTimePicker9;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 还原toolStripMenuItem1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox pwdbox;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button pwdbtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button maxbtn;
        private System.Windows.Forms.Button closebtn;
        public System.Windows.Forms.Button minbtn;
        private System.Windows.Forms.Button button6;
        private FullTabControl tabControl1;
        private Timer timer1;
        private Timer timer2;
        private CheckBox checkBox2;
        private TabPage tabPage4;
        private Button button7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart15;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart14;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart13;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart12;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart11;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart10;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart9;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart8;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart7;
        private Button button10;
        private Button button12;
        private Button button11;
        private Label label6;
        private PictureBox pictureBox1;
        private TabPage tabPage6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart16;
        private Panel panel9;
        private DateTimePicker dateTimePicker10;
        private DateTimePicker dateTimePicker11;
        private Label label8;
        private Panel panel10;
        private DateTimePicker dateTimePicker12;
        private Label label14;
        private ComboBox comboBox5;
        private ComboBox comboBox4;
        private ComboBox comboBox6;
        private ComboBox comboBox7;
        private Label label19;
        private Label label20;
        private Label label18;
        private Label label17;
    }
}

