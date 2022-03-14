
namespace SIMSrq2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.sigmaTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.modelTimeTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.NTB = new System.Windows.Forms.TextBox();
            this.label123 = new System.Windows.Forms.Label();
            this.mu2TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mu1TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lambdaTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(470, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 36);
            this.button2.TabIndex = 42;
            this.button2.Text = "Открыть Excel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // sigmaTB
            // 
            this.sigmaTB.Location = new System.Drawing.Point(224, 164);
            this.sigmaTB.Name = "sigmaTB";
            this.sigmaTB.Size = new System.Drawing.Size(100, 23);
            this.sigmaTB.TabIndex = 41;
            this.sigmaTB.Text = "3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 30);
            this.label7.TabIndex = 40;
            this.label7.Text = "Параметр времени \r\nзадержки на орбите:";
            // 
            // modelTimeTB
            // 
            this.modelTimeTB.Location = new System.Drawing.Point(224, 396);
            this.modelTimeTB.Name = "modelTimeTB";
            this.modelTimeTB.Size = new System.Drawing.Size(100, 23);
            this.modelTimeTB.TabIndex = 39;
            this.modelTimeTB.Text = "5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 399);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 15);
            this.label4.TabIndex = 38;
            this.label4.Text = "Время работы системы:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(635, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 36);
            this.button1.TabIndex = 37;
            this.button1.Text = "Запуск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NTB
            // 
            this.NTB.Location = new System.Drawing.Point(224, 209);
            this.NTB.Name = "NTB";
            this.NTB.Size = new System.Drawing.Size(100, 23);
            this.NTB.TabIndex = 36;
            this.NTB.Text = "10";
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Location = new System.Drawing.Point(20, 212);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(125, 15);
            this.label123.TabIndex = 35;
            this.label123.Text = "Размерность буфера:";
            // 
            // mu2TB
            // 
            this.mu2TB.Location = new System.Drawing.Point(224, 117);
            this.mu2TB.Name = "mu2TB";
            this.mu2TB.Size = new System.Drawing.Size(100, 23);
            this.mu2TB.TabIndex = 34;
            this.mu2TB.Text = "3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 30);
            this.label3.TabIndex = 33;
            this.label3.Text = "Интенсивность обслуживания\r\nна второй фазе:";
            // 
            // mu1TB
            // 
            this.mu1TB.Location = new System.Drawing.Point(224, 70);
            this.mu1TB.Name = "mu1TB";
            this.mu1TB.Size = new System.Drawing.Size(100, 23);
            this.mu1TB.TabIndex = 32;
            this.mu1TB.Text = "3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 30);
            this.label2.TabIndex = 31;
            this.label2.Text = "Интенсивность обслуживания\r\nна первой фазе:";
            // 
            // lambdaTB
            // 
            this.lambdaTB.Location = new System.Drawing.Point(224, 21);
            this.lambdaTB.Name = "lambdaTB";
            this.lambdaTB.Size = new System.Drawing.Size(100, 23);
            this.lambdaTB.TabIndex = 30;
            this.lambdaTB.Text = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 15);
            this.label1.TabIndex = 29;
            this.label1.Text = "Интенсивность входящего потока:";
            // 
            // pTB
            // 
            this.pTB.Location = new System.Drawing.Point(224, 256);
            this.pTB.Name = "pTB";
            this.pTB.Size = new System.Drawing.Size(100, 23);
            this.pTB.TabIndex = 44;
            this.pTB.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 15);
            this.label5.TabIndex = 43;
            this.label5.Text = "Вероятность выхода заявки:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.sigmaTB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.modelTimeTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NTB);
            this.Controls.Add(this.label123);
            this.Controls.Add(this.mu2TB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mu1TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lambdaTB);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox sigmaTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox modelTimeTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox NTB;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.TextBox mu2TB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mu1TB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lambdaTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pTB;
        private System.Windows.Forms.Label label5;
    }
}

