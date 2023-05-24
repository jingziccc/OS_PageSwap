using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private const int InstructionNum = 320;
        private const int Rows = 10;
        private const int Columns = 4;
        private const int PageNum = 4;
        private int curIns;
        private int lastPage;//上次指令所在内存页
        private int missingCount;//缺页数
        private int totalCount;  //已运行指令数
        private Label[,] labels;  // 二维数组用于存储Label
        private string algorithm = "FIFO"; // 默认是FIFO算法
        private List<int> instructions;   //存生成的指令
        private int[] pageInMemory = new int[4];//存储内存中4页对应的指令页
        private Queue<int> q_Page;//FIFO中在内存中的页队列
        private int[] pageInMemoryLUT = new int[4];//记录内存中4页中LastUsedTime上次使用时间，这个可以使用当时执行的指令数来模拟
        public enum InstructionStatus
        {
            NOT_GENERATED, // 未生成
            NEWLY_GENERATED, // 新生成
            RUNNING, // 已运行
            OVER //已结束
        }
        private InstructionStatus insStatus = InstructionStatus.NOT_GENERATED;
        //表达指令的状态，0为未生成，1为新生成，2为已运行

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateLabels();
        }
        private void FIFO(int curInsPage)//传入要调入的页数
        {
            int pageOut = q_Page.Dequeue();//这是调出的页
            AddToLog(string.Format("缺页！将程序的第{0}页调入PAGE{1}", curInsPage + 1, pageOut + 1));
            pageInMemory[pageOut] = curInsPage;//调出的页中存入调入的页
            q_Page.Enqueue(pageOut);//再次调入
            lastPage = pageOut;
            changePage(pageOut, curInsPage * 10);
            YellowLabel(curIns % 10, pageOut);
        }
        private void LRU(int curInsPage)
        {
            //选择当前指令需要换入的页，找到最小值对应的下标
            int pageOut = 0;
            for (int i = 0; i < PageNum; i++)
            {
                if (pageInMemoryLUT[i] < pageInMemoryLUT[pageOut])
                    pageOut = i;
            }
            pageInMemory[pageOut] = curInsPage; //调出的内存页中存入调入的程序页
            AddToLog(string.Format("缺页！将程序的第{0}页调入PAGE{1}", curInsPage + 1, pageOut + 1));
            pageInMemoryLUT[pageOut] = totalCount;//这一页需要调走，并更新
            lastPage = pageOut;
            changePage(pageOut, curInsPage * 10);
            YellowLabel(curIns % 10, pageOut);
        }
        private void RUN()
        {
            insStatus = InstructionStatus.RUNNING;
            DefalutLabel(curIns % 10, lastPage);//将上次变化的标签恢复
            if (instructions.Count > 0)
            {
                AddToLog(string.Format("执行第{0}条指令", instructions[0]));
                curIns = instructions[0];
                totalCount++;
                instructions.RemoveAt(0);
            }
            else
            {
                insStatus = InstructionStatus.OVER;
                return;
            }
            bool isInMemory = false;
            int curInsPage = curIns / 10;//当前指令所在页
            int page;//查看在内存的第几页
            for (page = 0; page < PageNum; page++)
            {
                if (curInsPage == pageInMemory[page])
                {
                    isInMemory = true;
                    break;
                }
            }
            if (isInMemory)
            {
                //命中，标红显示
                AddToLog(string.Format("命中，在PAGE{0}", page));
                HighlightLabel(curIns % Rows, page);
                pageInMemoryLUT[page] = totalCount;
                lastPage = page;
            }
            //如果不在内存中，就需要选择算法进行页面调换
            else
            {
                missingCount++;
                switch (algorithm)
                {
                    case "FIFO":
                        FIFO(curInsPage);
                        break;
                    case "LRU":
                        LRU(curInsPage);
                        break;
                    // 可以添加其他算法的处理分支
                    default:
                        // 处理默认情况
                        break;
                }
            }
            updateUI();

        }
        private void updateUI()
        {
            textBox_curIns.Text = string.Format("{0}", curIns);
            if (curIns == -1)
                textBox_curIns.Text = "NULL";
            textBox_misNum.Text = string.Format("{0}", missingCount);
            if (instructions.Count > 0)
                textBox_nextIns.Text = string.Format("{0}", instructions[0]);
            else
                textBox_nextIns.Text = "NULL";
            double misRate = (double)missingCount / totalCount;
            string formattedMisRate = (misRate * 100).ToString("0.00") + "%";
            textBox_misRate.Text = formattedMisRate;
            textBox_totalCount.Text = string.Format("{0}", totalCount);
        }
        private void changePage(int page, int startNum)//表示page要修改界面第几页，startNum表示首个数字
        {
            for (int i = 0; i < Rows; i++)
                labels[i, page].Text = string.Format("{0}", startNum + i);
        }
        public void InitInstructions()
        {
            if (insStatus == InstructionStatus.NEWLY_GENERATED)
            {
                MessageBox.Show("指令已生成", "提示");
                return;
            }
            Restart();
            insStatus = InstructionStatus.NEWLY_GENERATED;
            if(algorithm=="FIFO")
                LRU_radioButton.Enabled = false;
            else
                FIFO_radioButton.Enabled = false;
            
            Random random = new Random();
            instructions = new List<int>();
            AddToLog("随机生成指令中...");
            // 初始化Memory
            for (int i = 0; i < PageNum; i++)
            {
                pageInMemory[i] = -1;
                pageInMemoryLUT[i] = 0;//都未被使用
            }

            // 清空FIFO队列
            q_Page = new Queue<int>(new[] { 0, 1, 2, 3 });
            while (instructions.Count < InstructionNum)
            {
                int m = random.Next(0, InstructionNum);
                instructions.Add(m);
                if (instructions.Count >= InstructionNum)
                    break;
                if (m == InstructionNum - 1)
                    continue;
                instructions.Add(m + 1);
                if (instructions.Count >= InstructionNum)
                    break;
                //范围是[0,m+1]
                m = random.Next(0, m + 2);
                instructions.Add(m);
                if (instructions.Count >= InstructionNum)
                    break;
                if (m == InstructionNum - 1)
                    continue;
                instructions.Add(m + 1);
                if (instructions.Count >= InstructionNum)
                    break;
                //范围是[m+2,319]
                m = random.Next(m + 2, InstructionNum);
                instructions.Add(m);
            }
            AddToLog("指令生成完成");
            updateUI();
        }

        private void CreateLabels()
        {
            int labelWidth = 80;  // 定义Label的宽度
            int labelHeight = 25; // 定义Label的高度
            int spacing_x = 20;     // 定义Label之间的间距
            int spacing_y = 5;
            int startX = (this.ClientSize.Width - (labelWidth * (Columns + 2) + spacing_x * (Columns - 1))) / 2;
            int startY = (this.ClientSize.Height - (labelHeight * Rows + spacing_y * (Rows - 1))) / 2;

            labels = new Label[Rows, Columns];  // 初始化二维数组
            for (int i = 0; i < Columns; i++)
            {
                Label label = new Label();
                label.Text = string.Format("PAGE {0}", i + 1);
                label.AutoSize = true;
                label.Font = new Font(label.Font.FontFamily, 12f, FontStyle.Regular); // 设置文本的字体和大小
                int x = startX - 5 + (labelWidth + spacing_x) * i;
                label.Location = new Point(x, startY);
                this.Controls.Add(label);
            }
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    Label label = new Label();
                    label.Text = "null";
                    label.AutoSize = true;
                    //label.BorderStyle = BorderStyle.FixedSingle;
                    //label.BackColor = Color.White;
                    // label.ForeColor = Color.Black;
                    label.Padding = new Padding(5);
                    int x = startX + (labelWidth + spacing_x) * col;
                    int y = startY + (labelHeight + spacing_y) * (row + 1);
                    label.Location = new Point(x, y);

                    labels[row, col] = label;  // 将Label添加到二维数组中
                    this.Controls.Add(label);
                }
            }


        }


        private void HighlightLabel(int row, int col)
        {

            //AddToLog(string.Format("被调用{0}行{1}列", row, col));
            // 首先检查传入的行列是否在有效范围内
            if (row >= 0 && row < Rows && col >= 0 && col < Columns)
                // 将指定行列的标签背景设置为红色
                labels[row, col].BackColor = Color.Red;
        }
        private void YellowLabel(int row, int col)
        {
            // 首先检查传入的行列是否在有效范围内
            if (row >= 0 && row < Rows && col >= 0 && col < Columns)
                // 将指定行列的标签背景设置为黄色
                labels[row, col].BackColor = Color.Yellow;
        }
        private void DefalutLabel(int row, int col)
        {
            // 首先检查传入的行列是否在有效范围内
            if (row >= 0 && row < Rows && col >= 0 && col < Columns)
            {
                // 将指定行列的标签背景设置为默认颜色
                labels[row, col].BackColor = SystemColors.Control;
            }
        }

        private void FIFO_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.algorithm = "FIFO";
        }

        private void LRU_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.algorithm = "LRU";
        }
        public void AddToLog(string content)
        {
            if (instructionMessage.InvokeRequired)
            {
                instructionMessage.Invoke(new Action<string>(AddToLog), content);
            }
            else
            {
                instructionMessage.AppendText(content + Environment.NewLine);
                instructionMessage.SelectionStart = instructionMessage.Text.Length;
                instructionMessage.ScrollToCaret();
            }
        }

        private void Confirm_button_Click(object sender, EventArgs e)
        {
            InitInstructions();
        }

        private void onestep_button_Click(object sender, EventArgs e)
        {
            if(insStatus == InstructionStatus.NOT_GENERATED)
                MessageBox.Show("指令未生成", "提示");
            else if (insStatus == InstructionStatus.OVER)
                MessageBox.Show("指令已运行完", "提示");
            else
                RUN();
        }

        private void steps_button_Click(object sender, EventArgs e)
        {
            if (insStatus == InstructionStatus.NOT_GENERATED)
                MessageBox.Show("指令未生成", "提示");
            else if(insStatus == InstructionStatus.OVER)
                MessageBox.Show("指令已运行完", "提示");
            else
            {
                while (instructions.Count > 0)
                {
                    RUN();
                    Application.DoEvents();
                }
            }
        }
        //重置函数
        private void Restart()
        {
            // 初始化缺页数和已运行指令数
            missingCount = 0;
            totalCount = 0;
            curIns = -1;
            textBox_curIns.Text = "NULL";
            textBox_misNum.Text = "NULL";
            textBox_nextIns.Text = "NULL";
            textBox_misRate.Text = "NULL";
            textBox_totalCount.Text = "NULL";
            insStatus = InstructionStatus.NOT_GENERATED;
            FIFO_radioButton.Enabled = true;
            LRU_radioButton.Enabled = true;
            instructionMessage.Clear();
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Columns; col++)
                {
                    labels[row, col].Text = "null";
                    labels[row, col].BackColor = SystemColors.Control;
                }
                
        }
        private void button_Reset_Click(object sender, EventArgs e)
        {
            Restart();
        }

        private void label_about_Click(object sender, EventArgs e)
        {
            string message = 
                "操作系统请求调页存储管理方式模拟项目\n" +
                "同济大学软件学院\n" +
                "2152831陈峥海\n" +
                "红色表示指令在内存中，命中";
            string caption = "About";
            MessageBox.Show(message, caption);
        }
    }
}

