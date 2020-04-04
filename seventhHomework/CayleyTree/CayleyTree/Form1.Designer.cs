namespace CayleyTree
{
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
            this.draw = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.NUD_Recursion = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_Length = new System.Windows.Forms.TrackBar();
            this.TB_Per1 = new System.Windows.Forms.TrackBar();
            this.btn_Color_Changed = new System.Windows.Forms.Button();
            this.TB_Per2 = new System.Windows.Forms.TrackBar();
            this.TB_Th1 = new System.Windows.Forms.TrackBar();
            this.TB_Th2 = new System.Windows.Forms.TrackBar();
            this.panel_Draw = new System.Windows.Forms.Panel();
            this.length_Value = new System.Windows.Forms.Label();
            this.per1_Value = new System.Windows.Forms.Label();
            this.per2_Value = new System.Windows.Forms.Label();
            this.th1_Value = new System.Windows.Forms.Label();
            this.th2_Value = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Recursion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Per1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Per2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Th1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Th2)).BeginInit();
            this.SuspendLayout();
            // 
            // draw
            // 
            this.draw.Font = new System.Drawing.Font("宋体", 15F);
            this.draw.Location = new System.Drawing.Point(783, 453);
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(161, 53);
            this.draw.TabIndex = 0;
            this.draw.Text = "Cayley树";
            this.draw.UseVisualStyleBackColor = true;
            this.draw.Click += new System.EventHandler(this.draw_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(697, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "递归深度：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(697, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "主干长度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F);
            this.label3.Location = new System.Drawing.Point(697, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "右分支长度比：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F);
            this.label4.Location = new System.Drawing.Point(697, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "左分支长度比：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F);
            this.label5.Location = new System.Drawing.Point(697, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "右分支角度：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F);
            this.label7.Location = new System.Drawing.Point(697, 397);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "画笔颜色：";
            // 
            // NUD_Recursion
            // 
            this.NUD_Recursion.Font = new System.Drawing.Font("宋体", 9F);
            this.NUD_Recursion.Location = new System.Drawing.Point(939, 33);
            this.NUD_Recursion.Name = "NUD_Recursion";
            this.NUD_Recursion.Size = new System.Drawing.Size(120, 25);
            this.NUD_Recursion.TabIndex = 14;
            this.NUD_Recursion.ValueChanged += new System.EventHandler(this.NUD_Recursion_Changed);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15F);
            this.label8.Location = new System.Drawing.Point(697, 336);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 25);
            this.label8.TabIndex = 16;
            this.label8.Text = "左分支角度：";
            // 
            // TB_Length
            // 
            this.TB_Length.Location = new System.Drawing.Point(939, 83);
            this.TB_Length.Maximum = 200;
            this.TB_Length.Name = "TB_Length";
            this.TB_Length.Size = new System.Drawing.Size(104, 56);
            this.TB_Length.TabIndex = 18;
            this.TB_Length.ValueChanged += new System.EventHandler(this.TB_Length_Changed);
            // 
            // TB_Per1
            // 
            this.TB_Per1.LargeChange = 50;
            this.TB_Per1.Location = new System.Drawing.Point(939, 141);
            this.TB_Per1.Maximum = 100;
            this.TB_Per1.Name = "TB_Per1";
            this.TB_Per1.Size = new System.Drawing.Size(104, 56);
            this.TB_Per1.TabIndex = 19;
            this.TB_Per1.ValueChanged += new System.EventHandler(this.TB_Per1_Changed);
            // 
            // btn_Color_Changed
            // 
            this.btn_Color_Changed.Location = new System.Drawing.Point(939, 385);
            this.btn_Color_Changed.Name = "btn_Color_Changed";
            this.btn_Color_Changed.Size = new System.Drawing.Size(120, 42);
            this.btn_Color_Changed.TabIndex = 20;
            this.btn_Color_Changed.Text = "点击选择颜色";
            this.btn_Color_Changed.UseVisualStyleBackColor = true;
            this.btn_Color_Changed.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_Color_Changed_MouseClick);
            // 
            // TB_Per2
            // 
            this.TB_Per2.LargeChange = 50;
            this.TB_Per2.Location = new System.Drawing.Point(939, 203);
            this.TB_Per2.Maximum = 100;
            this.TB_Per2.Name = "TB_Per2";
            this.TB_Per2.Size = new System.Drawing.Size(104, 56);
            this.TB_Per2.TabIndex = 21;
            this.TB_Per2.ValueChanged += new System.EventHandler(this.TB_Per2_ValueChanged);
            // 
            // TB_Th1
            // 
            this.TB_Th1.LargeChange = 50;
            this.TB_Th1.Location = new System.Drawing.Point(939, 263);
            this.TB_Th1.Maximum = 180;
            this.TB_Th1.Name = "TB_Th1";
            this.TB_Th1.Size = new System.Drawing.Size(104, 56);
            this.TB_Th1.TabIndex = 22;
            this.TB_Th1.ValueChanged += new System.EventHandler(this.TB_Th1_ValueChanged);
            // 
            // TB_Th2
            // 
            this.TB_Th2.LargeChange = 50;
            this.TB_Th2.Location = new System.Drawing.Point(939, 323);
            this.TB_Th2.Maximum = 180;
            this.TB_Th2.Name = "TB_Th2";
            this.TB_Th2.Size = new System.Drawing.Size(104, 56);
            this.TB_Th2.TabIndex = 23;
            this.TB_Th2.ValueChanged += new System.EventHandler(this.TB_Th2_ValueChanged);
            // 
            // panel_Draw
            // 
            this.panel_Draw.Location = new System.Drawing.Point(12, 12);
            this.panel_Draw.Name = "panel_Draw";
            this.panel_Draw.Size = new System.Drawing.Size(679, 519);
            this.panel_Draw.TabIndex = 24;
            // 
            // length_Value
            // 
            this.length_Value.AutoSize = true;
            this.length_Value.Font = new System.Drawing.Font("宋体", 15F);
            this.length_Value.Location = new System.Drawing.Point(871, 99);
            this.length_Value.Name = "length_Value";
            this.length_Value.Size = new System.Drawing.Size(25, 25);
            this.length_Value.TabIndex = 25;
            this.length_Value.Text = "0";
            // 
            // per1_Value
            // 
            this.per1_Value.AutoSize = true;
            this.per1_Value.Font = new System.Drawing.Font("宋体", 15F);
            this.per1_Value.Location = new System.Drawing.Point(871, 159);
            this.per1_Value.Name = "per1_Value";
            this.per1_Value.Size = new System.Drawing.Size(25, 25);
            this.per1_Value.TabIndex = 26;
            this.per1_Value.Text = "0";
            // 
            // per2_Value
            // 
            this.per2_Value.AutoSize = true;
            this.per2_Value.Font = new System.Drawing.Font("宋体", 15F);
            this.per2_Value.Location = new System.Drawing.Point(871, 219);
            this.per2_Value.Name = "per2_Value";
            this.per2_Value.Size = new System.Drawing.Size(25, 25);
            this.per2_Value.TabIndex = 27;
            this.per2_Value.Text = "0";
            // 
            // th1_Value
            // 
            this.th1_Value.AutoSize = true;
            this.th1_Value.Font = new System.Drawing.Font("宋体", 15F);
            this.th1_Value.Location = new System.Drawing.Point(871, 279);
            this.th1_Value.Name = "th1_Value";
            this.th1_Value.Size = new System.Drawing.Size(25, 25);
            this.th1_Value.TabIndex = 28;
            this.th1_Value.Text = "0";
            // 
            // th2_Value
            // 
            this.th2_Value.AutoSize = true;
            this.th2_Value.Font = new System.Drawing.Font("宋体", 15F);
            this.th2_Value.Location = new System.Drawing.Point(871, 336);
            this.th2_Value.Name = "th2_Value";
            this.th2_Value.Size = new System.Drawing.Size(25, 25);
            this.th2_Value.TabIndex = 29;
            this.th2_Value.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 525);
            this.Controls.Add(this.th2_Value);
            this.Controls.Add(this.th1_Value);
            this.Controls.Add(this.per2_Value);
            this.Controls.Add(this.per1_Value);
            this.Controls.Add(this.length_Value);
            this.Controls.Add(this.TB_Th1);
            this.Controls.Add(this.panel_Draw);
            this.Controls.Add(this.TB_Th2);
            this.Controls.Add(this.draw);
            this.Controls.Add(this.NUD_Recursion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TB_Per2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Color_Changed);
            this.Controls.Add(this.TB_Length);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_Per1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Recursion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Per1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Per2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Th1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Th2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button draw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown NUD_Recursion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar TB_Length;
        private System.Windows.Forms.TrackBar TB_Per1;
        private System.Windows.Forms.Button btn_Color_Changed;
        private System.Windows.Forms.TrackBar TB_Per2;
        private System.Windows.Forms.TrackBar TB_Th1;
        private System.Windows.Forms.TrackBar TB_Th2;
        private System.Windows.Forms.Panel panel_Draw;
        private System.Windows.Forms.Label length_Value;
        private System.Windows.Forms.Label per1_Value;
        private System.Windows.Forms.Label per2_Value;
        private System.Windows.Forms.Label th1_Value;
        private System.Windows.Forms.Label th2_Value;
    }
}

