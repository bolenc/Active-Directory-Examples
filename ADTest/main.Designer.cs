namespace ADDemo
{
    partial class main
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
            this.search = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.TextBox();
            this.queryString = new System.Windows.Forms.TextBox();
            this.searchType = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.userDetail = new System.Windows.Forms.GroupBox();
            this.userEnabled = new System.Windows.Forms.CheckBox();
            this.userSAMAccountName = new System.Windows.Forms.TextBox();
            this.lblSamName = new System.Windows.Forms.Label();
            this.userPassword2 = new System.Windows.Forms.TextBox();
            this.lblPasswordRepeat = new System.Windows.Forms.Label();
            this.userPassword1 = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.newGroup = new System.Windows.Forms.TextBox();
            this.removeGroup = new System.Windows.Forms.Button();
            this.addGroup = new System.Windows.Forms.Button();
            this.lblGroups = new System.Windows.Forms.Label();
            this.userGroups = new System.Windows.Forms.ListBox();
            this.userMainPhone = new System.Windows.Forms.TextBox();
            this.lblMainPhone = new System.Windows.Forms.Label();
            this.userDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.userEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.userDisplayName = new System.Windows.Forms.TextBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.userSurname = new System.Windows.Forms.TextBox();
            this.lblSurname = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.queryStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.save = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.searchResults = new System.Windows.Forms.DataGridView();
            this.userDetail.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchResults)).BeginInit();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(417, 9);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(51, 23);
            this.search.TabIndex = 2;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(84, 19);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(114, 20);
            this.userName.TabIndex = 0;
            // 
            // queryString
            // 
            this.queryString.Location = new System.Drawing.Point(232, 12);
            this.queryString.Name = "queryString";
            this.queryString.Size = new System.Drawing.Size(179, 20);
            this.queryString.TabIndex = 1;
            this.queryString.Enter += new System.EventHandler(this.queryString_Enter);
            // 
            // searchType
            // 
            this.searchType.FormattingEnabled = true;
            this.searchType.Items.AddRange(new object[] {
            "Users",
            "Groups",
            "Users In Group",
            "All"});
            this.searchType.Location = new System.Drawing.Point(12, 12);
            this.searchType.Name = "searchType";
            this.searchType.Size = new System.Drawing.Size(121, 21);
            this.searchType.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name";
            // 
            // userDetail
            // 
            this.userDetail.Controls.Add(this.userEnabled);
            this.userDetail.Controls.Add(this.userSAMAccountName);
            this.userDetail.Controls.Add(this.lblSamName);
            this.userDetail.Controls.Add(this.userPassword2);
            this.userDetail.Controls.Add(this.lblPasswordRepeat);
            this.userDetail.Controls.Add(this.userPassword1);
            this.userDetail.Controls.Add(this.lblPassword);
            this.userDetail.Controls.Add(this.newGroup);
            this.userDetail.Controls.Add(this.removeGroup);
            this.userDetail.Controls.Add(this.addGroup);
            this.userDetail.Controls.Add(this.lblGroups);
            this.userDetail.Controls.Add(this.userGroups);
            this.userDetail.Controls.Add(this.userMainPhone);
            this.userDetail.Controls.Add(this.lblMainPhone);
            this.userDetail.Controls.Add(this.userDescription);
            this.userDetail.Controls.Add(this.lblDescription);
            this.userDetail.Controls.Add(this.userEmail);
            this.userDetail.Controls.Add(this.lblEmail);
            this.userDetail.Controls.Add(this.userDisplayName);
            this.userDetail.Controls.Add(this.lblDisplayName);
            this.userDetail.Controls.Add(this.userSurname);
            this.userDetail.Controls.Add(this.lblSurname);
            this.userDetail.Controls.Add(this.userName);
            this.userDetail.Controls.Add(this.lblName);
            this.userDetail.Location = new System.Drawing.Point(12, 200);
            this.userDetail.Name = "userDetail";
            this.userDetail.Size = new System.Drawing.Size(428, 291);
            this.userDetail.TabIndex = 4;
            this.userDetail.TabStop = false;
            this.userDetail.Text = "User";
            // 
            // userEnabled
            // 
            this.userEnabled.AutoSize = true;
            this.userEnabled.Location = new System.Drawing.Point(308, 184);
            this.userEnabled.Name = "userEnabled";
            this.userEnabled.Size = new System.Drawing.Size(65, 17);
            this.userEnabled.TabIndex = 25;
            this.userEnabled.Text = "Enabled";
            this.userEnabled.UseVisualStyleBackColor = true;
            // 
            // userSAMAccountName
            // 
            this.userSAMAccountName.Location = new System.Drawing.Point(308, 48);
            this.userSAMAccountName.Name = "userSAMAccountName";
            this.userSAMAccountName.Size = new System.Drawing.Size(114, 20);
            this.userSAMAccountName.TabIndex = 3;
            // 
            // lblSamName
            // 
            this.lblSamName.AutoSize = true;
            this.lblSamName.Location = new System.Drawing.Point(224, 48);
            this.lblSamName.Name = "lblSamName";
            this.lblSamName.Size = new System.Drawing.Size(78, 13);
            this.lblSamName.TabIndex = 22;
            this.lblSamName.Text = "Account Name";
            // 
            // userPassword2
            // 
            this.userPassword2.Location = new System.Drawing.Point(308, 158);
            this.userPassword2.Name = "userPassword2";
            this.userPassword2.Size = new System.Drawing.Size(114, 20);
            this.userPassword2.TabIndex = 12;
            this.userPassword2.TextChanged += new System.EventHandler(this.userPassword2_TextChanged);
            // 
            // lblPasswordRepeat
            // 
            this.lblPasswordRepeat.AutoSize = true;
            this.lblPasswordRepeat.Location = new System.Drawing.Point(237, 161);
            this.lblPasswordRepeat.Name = "lblPasswordRepeat";
            this.lblPasswordRepeat.Size = new System.Drawing.Size(42, 13);
            this.lblPasswordRepeat.TabIndex = 19;
            this.lblPasswordRepeat.Text = "Repeat";
            // 
            // userPassword1
            // 
            this.userPassword1.Location = new System.Drawing.Point(308, 129);
            this.userPassword1.Name = "userPassword1";
            this.userPassword1.Size = new System.Drawing.Size(114, 20);
            this.userPassword1.TabIndex = 11;
            this.userPassword1.TextChanged += new System.EventHandler(this.userPassword1_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(237, 132);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 17;
            this.lblPassword.Text = "Password";
            // 
            // newGroup
            // 
            this.newGroup.Location = new System.Drawing.Point(84, 126);
            this.newGroup.Name = "newGroup";
            this.newGroup.Size = new System.Drawing.Size(114, 20);
            this.newGroup.TabIndex = 7;
            // 
            // removeGroup
            // 
            this.removeGroup.Location = new System.Drawing.Point(204, 155);
            this.removeGroup.Name = "removeGroup";
            this.removeGroup.Size = new System.Drawing.Size(21, 23);
            this.removeGroup.TabIndex = 10;
            this.removeGroup.Text = "-";
            this.removeGroup.UseVisualStyleBackColor = true;
            this.removeGroup.Click += new System.EventHandler(this.removeGroup_Click);
            // 
            // addGroup
            // 
            this.addGroup.Location = new System.Drawing.Point(204, 126);
            this.addGroup.Name = "addGroup";
            this.addGroup.Size = new System.Drawing.Size(22, 23);
            this.addGroup.TabIndex = 8;
            this.addGroup.Text = "+";
            this.addGroup.UseVisualStyleBackColor = true;
            this.addGroup.Click += new System.EventHandler(this.addGroup_Click);
            // 
            // lblGroups
            // 
            this.lblGroups.AutoSize = true;
            this.lblGroups.Location = new System.Drawing.Point(9, 126);
            this.lblGroups.Name = "lblGroups";
            this.lblGroups.Size = new System.Drawing.Size(41, 13);
            this.lblGroups.TabIndex = 15;
            this.lblGroups.Text = "Groups";
            // 
            // userGroups
            // 
            this.userGroups.FormattingEnabled = true;
            this.userGroups.Location = new System.Drawing.Point(84, 152);
            this.userGroups.Name = "userGroups";
            this.userGroups.Size = new System.Drawing.Size(114, 95);
            this.userGroups.TabIndex = 9;
            // 
            // userMainPhone
            // 
            this.userMainPhone.Location = new System.Drawing.Point(308, 103);
            this.userMainPhone.Name = "userMainPhone";
            this.userMainPhone.Size = new System.Drawing.Size(114, 20);
            this.userMainPhone.TabIndex = 6;
            // 
            // lblMainPhone
            // 
            this.lblMainPhone.AutoSize = true;
            this.lblMainPhone.Location = new System.Drawing.Point(237, 106);
            this.lblMainPhone.Name = "lblMainPhone";
            this.lblMainPhone.Size = new System.Drawing.Size(64, 13);
            this.lblMainPhone.TabIndex = 14;
            this.lblMainPhone.Text = "Main Phone";
            // 
            // userDescription
            // 
            this.userDescription.Location = new System.Drawing.Point(84, 74);
            this.userDescription.Name = "userDescription";
            this.userDescription.Size = new System.Drawing.Size(322, 20);
            this.userDescription.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(9, 77);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Description";
            // 
            // userEmail
            // 
            this.userEmail.Location = new System.Drawing.Point(82, 100);
            this.userEmail.Name = "userEmail";
            this.userEmail.Size = new System.Drawing.Size(116, 20);
            this.userEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(9, 103);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email";
            // 
            // userDisplayName
            // 
            this.userDisplayName.Location = new System.Drawing.Point(84, 48);
            this.userDisplayName.Name = "userDisplayName";
            this.userDisplayName.Size = new System.Drawing.Size(114, 20);
            this.userDisplayName.TabIndex = 2;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Location = new System.Drawing.Point(6, 51);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(72, 13);
            this.lblDisplayName.TabIndex = 8;
            this.lblDisplayName.Text = "Display Name";
            // 
            // userSurname
            // 
            this.userSurname.Location = new System.Drawing.Point(308, 19);
            this.userSurname.Name = "userSurname";
            this.userSurname.Size = new System.Drawing.Size(114, 20);
            this.userSurname.TabIndex = 1;
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(253, 19);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(49, 13);
            this.lblSurname.TabIndex = 6;
            this.lblSurname.Text = "Surname";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.queryStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 507);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(541, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // queryStatusLabel
            // 
            this.queryStatusLabel.Name = "queryStatusLabel";
            this.queryStatusLabel.Size = new System.Drawing.Size(51, 17);
            this.queryStatusLabel.Text = "Stopped";
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(446, 200);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 5;
            this.save.Text = "&Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(474, 10);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(47, 23);
            this.newButton.TabIndex = 3;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(446, 229);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 23;
            this.deleteButton.Text = "&Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // searchResults
            // 
            this.searchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchResults.Location = new System.Drawing.Point(12, 40);
            this.searchResults.Name = "searchResults";
            this.searchResults.Size = new System.Drawing.Size(509, 150);
            this.searchResults.TabIndex = 24;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 529);
            this.Controls.Add(this.searchResults);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.save);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.userDetail);
            this.Controls.Add(this.searchType);
            this.Controls.Add(this.queryString);
            this.Controls.Add(this.search);
            this.Name = "main";
            this.Text = "Form1";
            this.userDetail.ResumeLayout(false);
            this.userDetail.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox queryString;
        private System.Windows.Forms.ComboBox searchType;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox userDetail;
        private System.Windows.Forms.TextBox userSurname;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel queryStatusLabel;
        private System.Windows.Forms.TextBox userMainPhone;
        private System.Windows.Forms.Label lblMainPhone;
        private System.Windows.Forms.TextBox userDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox userEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox userDisplayName;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label lblGroups;
        private System.Windows.Forms.ListBox userGroups;
        private System.Windows.Forms.Button removeGroup;
        private System.Windows.Forms.Button addGroup;
        private System.Windows.Forms.TextBox newGroup;
        private System.Windows.Forms.TextBox userPassword2;
        private System.Windows.Forms.Label lblPasswordRepeat;
        private System.Windows.Forms.TextBox userPassword1;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.TextBox userSAMAccountName;
        private System.Windows.Forms.Label lblSamName;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.CheckBox userEnabled;
        private System.Windows.Forms.DataGridView searchResults;
    }
}

