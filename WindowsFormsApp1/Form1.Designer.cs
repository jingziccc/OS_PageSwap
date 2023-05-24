using System.Drawing;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public int a;
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
            this.FIFO_radioButton = new System.Windows.Forms.RadioButton();
            this.LRU_radioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Confirm_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.onestep_button = new System.Windows.Forms.Button();
            this.steps_button = new System.Windows.Forms.Button();
            this.label_curIns = new System.Windows.Forms.Label();
            this.label_misNum = new System.Windows.Forms.Label();
            this.label_misRate = new System.Windows.Forms.Label();
            this.instructionMessage = new System.Windows.Forms.RichTextBox();
            this.textBox_misRate = new System.Windows.Forms.TextBox();
            this.textBox_misNum = new System.Windows.Forms.TextBox();
            this.textBox_curIns = new System.Windows.Forms.TextBox();
            this.label_nextIns = new System.Windows.Forms.Label();
            this.textBox_nextIns = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_totalCount = new System.Windows.Forms.TextBox();
            this.button_Reset = new System.Windows.Forms.Button();
            this.label_about = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FIFO_radioButton
            // 
            this.FIFO_radioButton.AutoSize = true;
            this.FIFO_radioButton.Location = new System.Drawing.Point(0, 18);
            this.FIFO_radioButton.Name = "FIFO_radioButton";
            this.FIFO_radioButton.Size = new System.Drawing.Size(60, 19);
            this.FIFO_radioButton.TabIndex = 0;
            this.FIFO_radioButton.TabStop = true;
            this.FIFO_radioButton.Text = "FIFO";
            this.FIFO_radioButton.UseVisualStyleBackColor = true;
            this.FIFO_radioButton.CheckedChanged += new System.EventHandler(this.FIFO_radioButton_CheckedChanged);
            // 
            // LRU_radioButton
            // 
            this.LRU_radioButton.AutoSize = true;
            this.LRU_radioButton.Location = new System.Drawing.Point(92, 18);
            this.LRU_radioButton.Name = "LRU_radioButton";
            this.LRU_radioButton.Size = new System.Drawing.Size(52, 19);
            this.LRU_radioButton.TabIndex = 1;
            this.LRU_radioButton.TabStop = true;
            this.LRU_radioButton.Text = "LRU";
            this.LRU_radioButton.UseVisualStyleBackColor = true;
            this.LRU_radioButton.CheckedChanged += new System.EventHandler(this.LRU_radioButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LRU_radioButton);
            this.groupBox1.Controls.Add(this.FIFO_radioButton);
            this.groupBox1.Location = new System.Drawing.Point(158, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 43);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // Confirm_button
            // 
            this.Confirm_button.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Confirm_button.Location = new System.Drawing.Point(338, 25);
            this.Confirm_button.Name = "Confirm_button";
            this.Confirm_button.Size = new System.Drawing.Size(115, 43);
            this.Confirm_button.TabIndex = 3;
            this.Confirm_button.Text = "生成指令";
            this.Confirm_button.UseVisualStyleBackColor = true;
            this.Confirm_button.Click += new System.EventHandler(this.Confirm_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(49, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "选择算法";
            // 
            // onestep_button
            // 
            this.onestep_button.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.onestep_button.Location = new System.Drawing.Point(598, 24);
            this.onestep_button.Name = "onestep_button";
            this.onestep_button.Size = new System.Drawing.Size(109, 43);
            this.onestep_button.TabIndex = 5;
            this.onestep_button.Text = "单步执行";
            this.onestep_button.UseVisualStyleBackColor = true;
            this.onestep_button.Click += new System.EventHandler(this.onestep_button_Click);
            // 
            // steps_button
            // 
            this.steps_button.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.steps_button.Location = new System.Drawing.Point(772, 24);
            this.steps_button.Name = "steps_button";
            this.steps_button.Size = new System.Drawing.Size(109, 42);
            this.steps_button.TabIndex = 6;
            this.steps_button.Text = "连续执行";
            this.steps_button.UseVisualStyleBackColor = true;
            this.steps_button.Click += new System.EventHandler(this.steps_button_Click);
            // 
            // label_curIns
            // 
            this.label_curIns.AutoSize = true;
            this.label_curIns.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_curIns.Location = new System.Drawing.Point(641, 269);
            this.label_curIns.Name = "label_curIns";
            this.label_curIns.Size = new System.Drawing.Size(80, 18);
            this.label_curIns.TabIndex = 7;
            this.label_curIns.Text = "当前指令";
            // 
            // label_misNum
            // 
            this.label_misNum.AutoSize = true;
            this.label_misNum.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_misNum.Location = new System.Drawing.Point(659, 399);
            this.label_misNum.Name = "label_misNum";
            this.label_misNum.Size = new System.Drawing.Size(62, 18);
            this.label_misNum.TabIndex = 8;
            this.label_misNum.Text = "缺页数";
            // 
            // label_misRate
            // 
            this.label_misRate.AutoSize = true;
            this.label_misRate.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_misRate.Location = new System.Drawing.Point(659, 444);
            this.label_misRate.Name = "label_misRate";
            this.label_misRate.Size = new System.Drawing.Size(62, 18);
            this.label_misRate.TabIndex = 9;
            this.label_misRate.Text = "缺页率";
            // 
            // instructionMessage
            // 
            this.instructionMessage.Location = new System.Drawing.Point(598, 116);
            this.instructionMessage.Name = "instructionMessage";
            this.instructionMessage.Size = new System.Drawing.Size(283, 118);
            this.instructionMessage.TabIndex = 12;
            this.instructionMessage.Text = "";
            // 
            // textBox_misRate
            // 
            this.textBox_misRate.Location = new System.Drawing.Point(745, 436);
            this.textBox_misRate.Name = "textBox_misRate";
            this.textBox_misRate.ReadOnly = true;
            this.textBox_misRate.Size = new System.Drawing.Size(136, 25);
            this.textBox_misRate.TabIndex = 15;
            // 
            // textBox_misNum
            // 
            this.textBox_misNum.Location = new System.Drawing.Point(745, 392);
            this.textBox_misNum.Name = "textBox_misNum";
            this.textBox_misNum.ReadOnly = true;
            this.textBox_misNum.Size = new System.Drawing.Size(136, 25);
            this.textBox_misNum.TabIndex = 14;
            // 
            // textBox_curIns
            // 
            this.textBox_curIns.Location = new System.Drawing.Point(745, 262);
            this.textBox_curIns.Name = "textBox_curIns";
            this.textBox_curIns.ReadOnly = true;
            this.textBox_curIns.Size = new System.Drawing.Size(136, 25);
            this.textBox_curIns.TabIndex = 13;
            this.textBox_curIns.Text = " ";
            // 
            // label_nextIns
            // 
            this.label_nextIns.AutoSize = true;
            this.label_nextIns.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_nextIns.Location = new System.Drawing.Point(623, 316);
            this.label_nextIns.Name = "label_nextIns";
            this.label_nextIns.Size = new System.Drawing.Size(98, 18);
            this.label_nextIns.TabIndex = 16;
            this.label_nextIns.Text = "下一条指令";
            // 
            // textBox_nextIns
            // 
            this.textBox_nextIns.Location = new System.Drawing.Point(745, 309);
            this.textBox_nextIns.Name = "textBox_nextIns";
            this.textBox_nextIns.ReadOnly = true;
            this.textBox_nextIns.Size = new System.Drawing.Size(136, 25);
            this.textBox_nextIns.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(605, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "已运行指令数";
            // 
            // textBox_totalCount
            // 
            this.textBox_totalCount.Location = new System.Drawing.Point(745, 350);
            this.textBox_totalCount.Name = "textBox_totalCount";
            this.textBox_totalCount.ReadOnly = true;
            this.textBox_totalCount.Size = new System.Drawing.Size(136, 25);
            this.textBox_totalCount.TabIndex = 19;
            // 
            // button_Reset
            // 
            this.button_Reset.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Reset.Location = new System.Drawing.Point(475, 26);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(99, 39);
            this.button_Reset.TabIndex = 20;
            this.button_Reset.Text = "重置";
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
            // 
            // label_about
            // 
            this.label_about.AutoSize = true;
            this.label_about.Font = new System.Drawing.Font("Viner Hand ITC", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_about.Location = new System.Drawing.Point(0, 0);
            this.label_about.Name = "label_about";
            this.label_about.Size = new System.Drawing.Size(64, 29);
            this.label_about.TabIndex = 21;
            this.label_about.Text = "About";
            this.label_about.Click += new System.EventHandler(this.label_about_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 537);
            this.Controls.Add(this.label_about);
            this.Controls.Add(this.button_Reset);
            this.Controls.Add(this.textBox_totalCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_nextIns);
            this.Controls.Add(this.label_nextIns);
            this.Controls.Add(this.textBox_misRate);
            this.Controls.Add(this.textBox_misNum);
            this.Controls.Add(this.textBox_curIns);
            this.Controls.Add(this.instructionMessage);
            this.Controls.Add(this.label_misRate);
            this.Controls.Add(this.label_misNum);
            this.Controls.Add(this.label_curIns);
            this.Controls.Add(this.steps_button);
            this.Controls.Add(this.onestep_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Confirm_button);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "MemoryManage";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton FIFO_radioButton;
        private System.Windows.Forms.RadioButton LRU_radioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Confirm_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button onestep_button;
        private System.Windows.Forms.Button steps_button;
        private System.Windows.Forms.Label label_curIns;
        private System.Windows.Forms.Label label_misNum;
        private System.Windows.Forms.Label label_misRate;
        private System.Windows.Forms.RichTextBox instructionMessage;
        private System.Windows.Forms.TextBox textBox_misRate;
        private System.Windows.Forms.TextBox textBox_misNum;
        private System.Windows.Forms.TextBox textBox_curIns;
        private System.Windows.Forms.Label label_nextIns;
        private System.Windows.Forms.TextBox textBox_nextIns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_totalCount;
        private System.Windows.Forms.Button button_Reset;
        private System.Windows.Forms.Label label_about;
    }
}
