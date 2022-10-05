using System;

namespace TelegramApp
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.textBoxmessage = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxtoken = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.youracctoken = new System.Windows.Forms.TextBox();
            this.yourreftoken = new System.Windows.Forms.TextBox();
            this.Access = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxmessage
            // 
            this.textBoxmessage.Location = new System.Drawing.Point(306, 54);
            this.textBoxmessage.Name = "textBoxmessage";
            this.textBoxmessage.Size = new System.Drawing.Size(160, 22);
            this.textBoxmessage.TabIndex = 0;
            this.textBoxmessage.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(472, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Отправить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(306, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Telegram: @squuambot";
            // 
            // textBoxtoken
            // 
            this.textBoxtoken.Location = new System.Drawing.Point(306, 141);
            this.textBoxtoken.Name = "textBoxtoken";
            this.textBoxtoken.Size = new System.Drawing.Size(160, 22);
            this.textBoxtoken.TabIndex = 4;
            this.textBoxtoken.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(306, 169);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 38);
            this.button3.TabIndex = 5;
            this.button3.Text = "SendToken";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.Location = new System.Drawing.Point(472, 141);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(71, 71);
            this.button4.TabIndex = 6;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // youracctoken
            // 
            this.youracctoken.Location = new System.Drawing.Point(366, 286);
            this.youracctoken.Name = "youracctoken";
            this.youracctoken.Size = new System.Drawing.Size(100, 22);
            this.youracctoken.TabIndex = 7;
            this.youracctoken.TextChanged += new System.EventHandler(this.youracctoken_TextChanged);
            // 
            // yourreftoken
            // 
            this.yourreftoken.Location = new System.Drawing.Point(366, 336);
            this.yourreftoken.Name = "yourreftoken";
            this.yourreftoken.Size = new System.Drawing.Size(100, 22);
            this.yourreftoken.TabIndex = 8;
            this.yourreftoken.TextChanged += new System.EventHandler(this.yourreftoken_TextChanged);
            // 
            // Access
            // 
            this.Access.AutoSize = true;
            this.Access.Location = new System.Drawing.Point(303, 292);
            this.Access.Name = "Access";
            this.Access.Size = new System.Drawing.Size(55, 16);
            this.Access.TabIndex = 9;
            this.Access.Text = "Access:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Refresh:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Access);
            this.Controls.Add(this.yourreftoken);
            this.Controls.Add(this.youracctoken);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBoxtoken);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxmessage);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxmessage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxtoken;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox youracctoken;
        private System.Windows.Forms.TextBox yourreftoken;
        private System.Windows.Forms.Label Access;
        private System.Windows.Forms.Label label2;
    }
}