namespace ToLet
{
    partial class MailBox
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DeletMailBTN = new System.Windows.Forms.Button();
            this.MailIdLBL = new System.Windows.Forms.Label();
            this.MailTypeLBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(79, 46);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(486, 20);
            this.textBox1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(79, 90);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(486, 224);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "From :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Message:";
            // 
            // DeletMailBTN
            // 
            this.DeletMailBTN.Location = new System.Drawing.Point(367, 337);
            this.DeletMailBTN.Name = "DeletMailBTN";
            this.DeletMailBTN.Size = new System.Drawing.Size(197, 34);
            this.DeletMailBTN.TabIndex = 4;
            this.DeletMailBTN.Text = "Delet";
            this.DeletMailBTN.UseVisualStyleBackColor = true;
            this.DeletMailBTN.Click += new System.EventHandler(this.DeletMailBTN_Click);
            // 
            // MailIdLBL
            // 
            this.MailIdLBL.AutoSize = true;
            this.MailIdLBL.Location = new System.Drawing.Point(483, 9);
            this.MailIdLBL.Name = "MailIdLBL";
            this.MailIdLBL.Size = new System.Drawing.Size(38, 13);
            this.MailIdLBL.TabIndex = 5;
            this.MailIdLBL.Text = "Mail Id";
            this.MailIdLBL.Visible = false;
            // 
            // MailTypeLBL
            // 
            this.MailTypeLBL.AutoSize = true;
            this.MailTypeLBL.Location = new System.Drawing.Point(483, 22);
            this.MailTypeLBL.Name = "MailTypeLBL";
            this.MailTypeLBL.Size = new System.Drawing.Size(50, 13);
            this.MailTypeLBL.TabIndex = 6;
            this.MailTypeLBL.Text = "MailType";
            this.MailTypeLBL.Visible = false;
            // 
            // MailBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 392);
            this.Controls.Add(this.MailTypeLBL);
            this.Controls.Add(this.MailIdLBL);
            this.Controls.Add(this.DeletMailBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MailBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MailBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button DeletMailBTN;
        public System.Windows.Forms.Label MailIdLBL;
        public System.Windows.Forms.Label MailTypeLBL;
      


    }
}