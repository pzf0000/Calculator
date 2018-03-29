namespace Calculator
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_CalculateString = new System.Windows.Forms.TextBox();
            this.label_calculateString = new System.Windows.Forms.Label();
            this.button_Calculate = new System.Windows.Forms.Button();
            this.label_Result = new System.Windows.Forms.Label();
            this.textBox_Result = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_CalculateString
            // 
            this.textBox_CalculateString.Location = new System.Drawing.Point(60, 10);
            this.textBox_CalculateString.Name = "textBox_CalculateString";
            this.textBox_CalculateString.Size = new System.Drawing.Size(470, 21);
            this.textBox_CalculateString.TabIndex = 0;
            // 
            // label_calculateString
            // 
            this.label_calculateString.AutoSize = true;
            this.label_calculateString.Location = new System.Drawing.Point(13, 13);
            this.label_calculateString.Name = "label_calculateString";
            this.label_calculateString.Size = new System.Drawing.Size(41, 12);
            this.label_calculateString.TabIndex = 1;
            this.label_calculateString.Text = "算式：";
            // 
            // button_Calculate
            // 
            this.button_Calculate.Location = new System.Drawing.Point(15, 48);
            this.button_Calculate.Name = "button_Calculate";
            this.button_Calculate.Size = new System.Drawing.Size(515, 23);
            this.button_Calculate.TabIndex = 2;
            this.button_Calculate.Text = "计算";
            this.button_Calculate.UseVisualStyleBackColor = true;
            this.button_Calculate.Click += new System.EventHandler(this.button_Calculate_Click);
            // 
            // label_Result
            // 
            this.label_Result.AutoSize = true;
            this.label_Result.Location = new System.Drawing.Point(15, 92);
            this.label_Result.Name = "label_Result";
            this.label_Result.Size = new System.Drawing.Size(41, 12);
            this.label_Result.TabIndex = 3;
            this.label_Result.Text = "结果：";
            // 
            // textBox_Result
            // 
            this.textBox_Result.Location = new System.Drawing.Point(63, 88);
            this.textBox_Result.Name = "textBox_Result";
            this.textBox_Result.Size = new System.Drawing.Size(467, 21);
            this.textBox_Result.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 127);
            this.Controls.Add(this.textBox_Result);
            this.Controls.Add(this.label_Result);
            this.Controls.Add(this.button_Calculate);
            this.Controls.Add(this.label_calculateString);
            this.Controls.Add(this.textBox_CalculateString);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_CalculateString;
        private System.Windows.Forms.Label label_calculateString;
        private System.Windows.Forms.Button button_Calculate;
        private System.Windows.Forms.Label label_Result;
        private System.Windows.Forms.TextBox textBox_Result;
    }
}

