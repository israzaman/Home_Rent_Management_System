namespace ToLet
{
    partial class SearchResultForm
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
            this.SeeResultTabControl = new System.Windows.Forms.TabControl();
            this.SeeResultTAB = new System.Windows.Forms.TabPage();
            this.SeeResultDG = new System.Windows.Forms.DataGridView();
            this.UserProfileTAB = new System.Windows.Forms.TabPage();
            this.AcceptBTN = new System.Windows.Forms.Button();
            this.UserNameTB = new System.Windows.Forms.TextBox();
            this.UserNameLBL = new System.Windows.Forms.Label();
            this.BackResultBTN = new System.Windows.Forms.PictureBox();
            this.DateOfBirthTB = new System.Windows.Forms.TextBox();
            this.ProfilePicPB = new System.Windows.Forms.PictureBox();
            this.EmailTB = new System.Windows.Forms.TextBox();
            this.AddressTB = new System.Windows.Forms.TextBox();
            this.EmailLBL = new System.Windows.Forms.Label();
            this.LastNameTB = new System.Windows.Forms.TextBox();
            this.BateOfBirthLBL = new System.Windows.Forms.Label();
            this.AddressLBL = new System.Windows.Forms.Label();
            this.MobileTB = new System.Windows.Forms.TextBox();
            this.LastNameLBL = new System.Windows.Forms.Label();
            this.NidTB = new System.Windows.Forms.TextBox();
            this.MobileLBL = new System.Windows.Forms.Label();
            this.NidLBL = new System.Windows.Forms.Label();
            this.FirstNameTB = new System.Windows.Forms.TextBox();
            this.FirstNameLBL = new System.Windows.Forms.Label();
            this.SeeResultTabControl.SuspendLayout();
            this.SeeResultTAB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeeResultDG)).BeginInit();
            this.UserProfileTAB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackResultBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicPB)).BeginInit();
            this.SuspendLayout();
            // 
            // SeeResultTabControl
            // 
            this.SeeResultTabControl.Controls.Add(this.SeeResultTAB);
            this.SeeResultTabControl.Controls.Add(this.UserProfileTAB);
            this.SeeResultTabControl.Location = new System.Drawing.Point(2, -36);
            this.SeeResultTabControl.Name = "SeeResultTabControl";
            this.SeeResultTabControl.SelectedIndex = 0;
            this.SeeResultTabControl.Size = new System.Drawing.Size(1018, 561);
            this.SeeResultTabControl.TabIndex = 0;
            // 
            // SeeResultTAB
            // 
            this.SeeResultTAB.BackgroundImage = global::ToLet.Properties.Resources.light_floor_texture_wood;
            this.SeeResultTAB.Controls.Add(this.SeeResultDG);
            this.SeeResultTAB.Location = new System.Drawing.Point(4, 25);
            this.SeeResultTAB.Name = "SeeResultTAB";
            this.SeeResultTAB.Padding = new System.Windows.Forms.Padding(3);
            this.SeeResultTAB.Size = new System.Drawing.Size(1010, 532);
            this.SeeResultTAB.TabIndex = 0;
            this.SeeResultTAB.Text = "SeeResultTAB";
            this.SeeResultTAB.UseVisualStyleBackColor = true;
            // 
            // SeeResultDG
            // 
            this.SeeResultDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SeeResultDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SeeResultDG.Location = new System.Drawing.Point(145, 124);
            this.SeeResultDG.Name = "SeeResultDG";
            this.SeeResultDG.RowTemplate.Height = 24;
            this.SeeResultDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SeeResultDG.Size = new System.Drawing.Size(718, 362);
            this.SeeResultDG.TabIndex = 0;
            this.SeeResultDG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SeeResultDG_CellClick);
            // 
            // UserProfileTAB
            // 
            this.UserProfileTAB.BackgroundImage = global::ToLet.Properties.Resources.light_floor_texture_wood;
            this.UserProfileTAB.Controls.Add(this.AcceptBTN);
            this.UserProfileTAB.Controls.Add(this.UserNameTB);
            this.UserProfileTAB.Controls.Add(this.UserNameLBL);
            this.UserProfileTAB.Controls.Add(this.BackResultBTN);
            this.UserProfileTAB.Controls.Add(this.DateOfBirthTB);
            this.UserProfileTAB.Controls.Add(this.ProfilePicPB);
            this.UserProfileTAB.Controls.Add(this.EmailTB);
            this.UserProfileTAB.Controls.Add(this.AddressTB);
            this.UserProfileTAB.Controls.Add(this.EmailLBL);
            this.UserProfileTAB.Controls.Add(this.LastNameTB);
            this.UserProfileTAB.Controls.Add(this.BateOfBirthLBL);
            this.UserProfileTAB.Controls.Add(this.AddressLBL);
            this.UserProfileTAB.Controls.Add(this.MobileTB);
            this.UserProfileTAB.Controls.Add(this.LastNameLBL);
            this.UserProfileTAB.Controls.Add(this.NidTB);
            this.UserProfileTAB.Controls.Add(this.MobileLBL);
            this.UserProfileTAB.Controls.Add(this.NidLBL);
            this.UserProfileTAB.Controls.Add(this.FirstNameTB);
            this.UserProfileTAB.Controls.Add(this.FirstNameLBL);
            this.UserProfileTAB.Location = new System.Drawing.Point(4, 25);
            this.UserProfileTAB.Name = "UserProfileTAB";
            this.UserProfileTAB.Padding = new System.Windows.Forms.Padding(3);
            this.UserProfileTAB.Size = new System.Drawing.Size(1010, 532);
            this.UserProfileTAB.TabIndex = 1;
            this.UserProfileTAB.Text = "UserProfileTAB";
            this.UserProfileTAB.UseVisualStyleBackColor = true;
            // 
            // AcceptBTN
            // 
            this.AcceptBTN.Location = new System.Drawing.Point(551, 432);
            this.AcceptBTN.Name = "AcceptBTN";
            this.AcceptBTN.Size = new System.Drawing.Size(170, 79);
            this.AcceptBTN.TabIndex = 50;
            this.AcceptBTN.Text = "Accept request";
            this.AcceptBTN.UseVisualStyleBackColor = true;
            this.AcceptBTN.Click += new System.EventHandler(this.AcceptBTN_Click);
            // 
            // UserNameTB
            // 
            this.UserNameTB.BackColor = System.Drawing.Color.BurlyWood;
            this.UserNameTB.Location = new System.Drawing.Point(284, 131);
            this.UserNameTB.Margin = new System.Windows.Forms.Padding(4);
            this.UserNameTB.Name = "UserNameTB";
            this.UserNameTB.ReadOnly = true;
            this.UserNameTB.Size = new System.Drawing.Size(269, 22);
            this.UserNameTB.TabIndex = 49;
            // 
            // UserNameLBL
            // 
            this.UserNameLBL.AutoSize = true;
            this.UserNameLBL.BackColor = System.Drawing.Color.Peru;
            this.UserNameLBL.Font = new System.Drawing.Font("Buxton Sketch", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UserNameLBL.Location = new System.Drawing.Point(127, 132);
            this.UserNameLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UserNameLBL.Name = "UserNameLBL";
            this.UserNameLBL.Size = new System.Drawing.Size(86, 25);
            this.UserNameLBL.TabIndex = 48;
            this.UserNameLBL.Text = "UserName:";
            // 
            // BackResultBTN
            // 
            this.BackResultBTN.Image = global::ToLet.Properties.Resources.woodenBack;
            this.BackResultBTN.Location = new System.Drawing.Point(43, 36);
            this.BackResultBTN.Margin = new System.Windows.Forms.Padding(4);
            this.BackResultBTN.Name = "BackResultBTN";
            this.BackResultBTN.Size = new System.Drawing.Size(65, 54);
            this.BackResultBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BackResultBTN.TabIndex = 47;
            this.BackResultBTN.TabStop = false;
            this.BackResultBTN.Click += new System.EventHandler(this.BackResultBTN_Click_1);
            // 
            // DateOfBirthTB
            // 
            this.DateOfBirthTB.BackColor = System.Drawing.Color.BurlyWood;
            this.DateOfBirthTB.Location = new System.Drawing.Point(284, 367);
            this.DateOfBirthTB.Margin = new System.Windows.Forms.Padding(4);
            this.DateOfBirthTB.Name = "DateOfBirthTB";
            this.DateOfBirthTB.ReadOnly = true;
            this.DateOfBirthTB.Size = new System.Drawing.Size(269, 22);
            this.DateOfBirthTB.TabIndex = 46;
            // 
            // ProfilePicPB
            // 
            this.ProfilePicPB.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ProfilePicPB.Image = global::ToLet.Properties.Resources._019005_glossy_waxed_wood_icon_symbols_shapes_smiley_happy2;
            this.ProfilePicPB.Location = new System.Drawing.Point(659, 155);
            this.ProfilePicPB.Margin = new System.Windows.Forms.Padding(4);
            this.ProfilePicPB.Name = "ProfilePicPB";
            this.ProfilePicPB.Size = new System.Drawing.Size(223, 214);
            this.ProfilePicPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProfilePicPB.TabIndex = 45;
            this.ProfilePicPB.TabStop = false;
            // 
            // EmailTB
            // 
            this.EmailTB.BackColor = System.Drawing.Color.BurlyWood;
            this.EmailTB.Location = new System.Drawing.Point(284, 263);
            this.EmailTB.Margin = new System.Windows.Forms.Padding(4);
            this.EmailTB.Name = "EmailTB";
            this.EmailTB.ReadOnly = true;
            this.EmailTB.Size = new System.Drawing.Size(269, 22);
            this.EmailTB.TabIndex = 40;
            // 
            // AddressTB
            // 
            this.AddressTB.BackColor = System.Drawing.Color.BurlyWood;
            this.AddressTB.Location = new System.Drawing.Point(284, 327);
            this.AddressTB.Margin = new System.Windows.Forms.Padding(4);
            this.AddressTB.Name = "AddressTB";
            this.AddressTB.ReadOnly = true;
            this.AddressTB.Size = new System.Drawing.Size(269, 22);
            this.AddressTB.TabIndex = 42;
            // 
            // EmailLBL
            // 
            this.EmailLBL.AutoSize = true;
            this.EmailLBL.BackColor = System.Drawing.Color.Peru;
            this.EmailLBL.Font = new System.Drawing.Font("Buxton Sketch", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EmailLBL.Location = new System.Drawing.Point(127, 264);
            this.EmailLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EmailLBL.Name = "EmailLBL";
            this.EmailLBL.Size = new System.Drawing.Size(52, 25);
            this.EmailLBL.TabIndex = 37;
            this.EmailLBL.Text = "Email:";
            // 
            // LastNameTB
            // 
            this.LastNameTB.BackColor = System.Drawing.Color.BurlyWood;
            this.LastNameTB.Location = new System.Drawing.Point(284, 198);
            this.LastNameTB.Margin = new System.Windows.Forms.Padding(4);
            this.LastNameTB.Name = "LastNameTB";
            this.LastNameTB.ReadOnly = true;
            this.LastNameTB.Size = new System.Drawing.Size(269, 22);
            this.LastNameTB.TabIndex = 43;
            // 
            // BateOfBirthLBL
            // 
            this.BateOfBirthLBL.AutoSize = true;
            this.BateOfBirthLBL.BackColor = System.Drawing.Color.Peru;
            this.BateOfBirthLBL.Font = new System.Drawing.Font("Buxton Sketch", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BateOfBirthLBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BateOfBirthLBL.Location = new System.Drawing.Point(127, 364);
            this.BateOfBirthLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BateOfBirthLBL.Name = "BateOfBirthLBL";
            this.BateOfBirthLBL.Size = new System.Drawing.Size(116, 25);
            this.BateOfBirthLBL.TabIndex = 36;
            this.BateOfBirthLBL.Text = "Date Of Birth:";
            // 
            // AddressLBL
            // 
            this.AddressLBL.AutoSize = true;
            this.AddressLBL.BackColor = System.Drawing.Color.Peru;
            this.AddressLBL.Font = new System.Drawing.Font("Buxton Sketch", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressLBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AddressLBL.Location = new System.Drawing.Point(127, 328);
            this.AddressLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AddressLBL.Name = "AddressLBL";
            this.AddressLBL.Size = new System.Drawing.Size(73, 25);
            this.AddressLBL.TabIndex = 35;
            this.AddressLBL.Text = "Address:";
            // 
            // MobileTB
            // 
            this.MobileTB.BackColor = System.Drawing.Color.BurlyWood;
            this.MobileTB.Location = new System.Drawing.Point(284, 231);
            this.MobileTB.Margin = new System.Windows.Forms.Padding(4);
            this.MobileTB.Name = "MobileTB";
            this.MobileTB.ReadOnly = true;
            this.MobileTB.Size = new System.Drawing.Size(269, 22);
            this.MobileTB.TabIndex = 44;
            // 
            // LastNameLBL
            // 
            this.LastNameLBL.AutoSize = true;
            this.LastNameLBL.BackColor = System.Drawing.Color.Peru;
            this.LastNameLBL.Font = new System.Drawing.Font("Buxton Sketch", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameLBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LastNameLBL.Location = new System.Drawing.Point(127, 199);
            this.LastNameLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LastNameLBL.Name = "LastNameLBL";
            this.LastNameLBL.Size = new System.Drawing.Size(94, 25);
            this.LastNameLBL.TabIndex = 34;
            this.LastNameLBL.Text = "Last Name :";
            // 
            // NidTB
            // 
            this.NidTB.BackColor = System.Drawing.Color.BurlyWood;
            this.NidTB.Location = new System.Drawing.Point(284, 295);
            this.NidTB.Margin = new System.Windows.Forms.Padding(4);
            this.NidTB.Name = "NidTB";
            this.NidTB.ReadOnly = true;
            this.NidTB.Size = new System.Drawing.Size(269, 22);
            this.NidTB.TabIndex = 41;
            // 
            // MobileLBL
            // 
            this.MobileLBL.AutoSize = true;
            this.MobileLBL.BackColor = System.Drawing.Color.Peru;
            this.MobileLBL.Font = new System.Drawing.Font("Buxton Sketch", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MobileLBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MobileLBL.Location = new System.Drawing.Point(127, 232);
            this.MobileLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MobileLBL.Name = "MobileLBL";
            this.MobileLBL.Size = new System.Drawing.Size(92, 25);
            this.MobileLBL.TabIndex = 33;
            this.MobileLBL.Text = "Mobile      :";
            // 
            // NidLBL
            // 
            this.NidLBL.AutoSize = true;
            this.NidLBL.BackColor = System.Drawing.Color.Peru;
            this.NidLBL.Font = new System.Drawing.Font("Buxton Sketch", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NidLBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NidLBL.Location = new System.Drawing.Point(127, 296);
            this.NidLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NidLBL.Name = "NidLBL";
            this.NidLBL.Size = new System.Drawing.Size(68, 25);
            this.NidLBL.TabIndex = 32;
            this.NidLBL.Text = "Nid No.:";
            // 
            // FirstNameTB
            // 
            this.FirstNameTB.BackColor = System.Drawing.Color.BurlyWood;
            this.FirstNameTB.Location = new System.Drawing.Point(284, 166);
            this.FirstNameTB.Margin = new System.Windows.Forms.Padding(4);
            this.FirstNameTB.Name = "FirstNameTB";
            this.FirstNameTB.ReadOnly = true;
            this.FirstNameTB.Size = new System.Drawing.Size(269, 22);
            this.FirstNameTB.TabIndex = 39;
            // 
            // FirstNameLBL
            // 
            this.FirstNameLBL.AutoSize = true;
            this.FirstNameLBL.BackColor = System.Drawing.Color.Peru;
            this.FirstNameLBL.Font = new System.Drawing.Font("Buxton Sketch", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameLBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FirstNameLBL.Location = new System.Drawing.Point(127, 167);
            this.FirstNameLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FirstNameLBL.Name = "FirstNameLBL";
            this.FirstNameLBL.Size = new System.Drawing.Size(94, 25);
            this.FirstNameLBL.TabIndex = 38;
            this.FirstNameLBL.Text = "First Name:";
            // 
            // SearchResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 529);
            this.Controls.Add(this.SeeResultTabControl);
            this.Name = "SearchResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchResultForm";
            this.SeeResultTabControl.ResumeLayout(false);
            this.SeeResultTAB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SeeResultDG)).EndInit();
            this.UserProfileTAB.ResumeLayout(false);
            this.UserProfileTAB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackResultBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl SeeResultTabControl;
        private System.Windows.Forms.TabPage SeeResultTAB;
        public System.Windows.Forms.DataGridView SeeResultDG;
        public System.Windows.Forms.TabPage UserProfileTAB;
        public System.Windows.Forms.TextBox DateOfBirthTB;
        public System.Windows.Forms.PictureBox ProfilePicPB;
        public System.Windows.Forms.TextBox EmailTB;
        public System.Windows.Forms.TextBox AddressTB;
        private System.Windows.Forms.Label EmailLBL;
        public System.Windows.Forms.TextBox LastNameTB;
        private System.Windows.Forms.Label BateOfBirthLBL;
        private System.Windows.Forms.Label AddressLBL;
        public System.Windows.Forms.TextBox MobileTB;
        private System.Windows.Forms.Label LastNameLBL;
        public System.Windows.Forms.TextBox NidTB;
        private System.Windows.Forms.Label MobileLBL;
        private System.Windows.Forms.Label NidLBL;
        public System.Windows.Forms.TextBox FirstNameTB;
        private System.Windows.Forms.Label FirstNameLBL;
        public System.Windows.Forms.PictureBox BackResultBTN;
        public System.Windows.Forms.TextBox UserNameTB;
        private System.Windows.Forms.Label UserNameLBL;
        public System.Windows.Forms.Button AcceptBTN;

    }
}