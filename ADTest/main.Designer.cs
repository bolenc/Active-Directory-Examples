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
            this.userPostalCode = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.userManager = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.userDepartment = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.userTitle = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.userEmployeeType = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.userCountry = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.userState = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.userCity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.userAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.userPDON = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.userPager = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.userMobile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.userIPPhone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
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
            this.ADField = new System.Windows.Forms.ComboBox();
            this.userUPN = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.userDetail.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchResults)).BeginInit();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(768, 13);
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
            this.queryString.Location = new System.Drawing.Point(583, 16);
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
            this.searchType.Location = new System.Drawing.Point(12, 14);
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
            this.userDetail.Controls.Add(this.userUPN);
            this.userDetail.Controls.Add(this.label14);
            this.userDetail.Controls.Add(this.userPostalCode);
            this.userDetail.Controls.Add(this.label13);
            this.userDetail.Controls.Add(this.userManager);
            this.userDetail.Controls.Add(this.label11);
            this.userDetail.Controls.Add(this.userDepartment);
            this.userDetail.Controls.Add(this.label12);
            this.userDetail.Controls.Add(this.userTitle);
            this.userDetail.Controls.Add(this.label10);
            this.userDetail.Controls.Add(this.userEmployeeType);
            this.userDetail.Controls.Add(this.label9);
            this.userDetail.Controls.Add(this.userCountry);
            this.userDetail.Controls.Add(this.label8);
            this.userDetail.Controls.Add(this.userState);
            this.userDetail.Controls.Add(this.label7);
            this.userDetail.Controls.Add(this.userCity);
            this.userDetail.Controls.Add(this.label6);
            this.userDetail.Controls.Add(this.userAddress);
            this.userDetail.Controls.Add(this.label5);
            this.userDetail.Controls.Add(this.userPDON);
            this.userDetail.Controls.Add(this.label4);
            this.userDetail.Controls.Add(this.userPager);
            this.userDetail.Controls.Add(this.label3);
            this.userDetail.Controls.Add(this.userMobile);
            this.userDetail.Controls.Add(this.label2);
            this.userDetail.Controls.Add(this.userIPPhone);
            this.userDetail.Controls.Add(this.label1);
            this.userDetail.Controls.Add(this.userCompany);
            this.userDetail.Controls.Add(this.lblCompany);
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
            this.userDetail.Location = new System.Drawing.Point(12, 202);
            this.userDetail.Name = "userDetail";
            this.userDetail.Size = new System.Drawing.Size(780, 302);
            this.userDetail.TabIndex = 4;
            this.userDetail.TabStop = false;
            this.userDetail.Text = "User";
            // 
            // userPostalCode
            // 
            this.userPostalCode.Location = new System.Drawing.Point(660, 39);
            this.userPostalCode.Name = "userPostalCode";
            this.userPostalCode.Size = new System.Drawing.Size(114, 20);
            this.userPostalCode.TabIndex = 52;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(603, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 53;
            this.label13.Text = "Post CD";
            // 
            // userManager
            // 
            this.userManager.Location = new System.Drawing.Point(660, 171);
            this.userManager.Name = "userManager";
            this.userManager.Size = new System.Drawing.Size(114, 20);
            this.userManager.TabIndex = 50;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(603, 174);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 51;
            this.label11.Text = "Mgr";
            // 
            // userDepartment
            // 
            this.userDepartment.Location = new System.Drawing.Point(660, 145);
            this.userDepartment.Name = "userDepartment";
            this.userDepartment.Size = new System.Drawing.Size(114, 20);
            this.userDepartment.TabIndex = 48;
            // 
            // label12
            // 
            this.label12.AllowDrop = true;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(603, 148);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 49;
            this.label12.Text = "Dept";
            // 
            // userTitle
            // 
            this.userTitle.Location = new System.Drawing.Point(660, 119);
            this.userTitle.Name = "userTitle";
            this.userTitle.Size = new System.Drawing.Size(114, 20);
            this.userTitle.TabIndex = 46;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(603, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Title";
            // 
            // userEmployeeType
            // 
            this.userEmployeeType.Location = new System.Drawing.Point(660, 93);
            this.userEmployeeType.Name = "userEmployeeType";
            this.userEmployeeType.Size = new System.Drawing.Size(114, 20);
            this.userEmployeeType.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(603, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Emp Type";
            // 
            // userCountry
            // 
            this.userCountry.Location = new System.Drawing.Point(660, 67);
            this.userCountry.Name = "userCountry";
            this.userCountry.Size = new System.Drawing.Size(114, 20);
            this.userCountry.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(603, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Cntry";
            // 
            // userState
            // 
            this.userState.Location = new System.Drawing.Point(660, 13);
            this.userState.Name = "userState";
            this.userState.Size = new System.Drawing.Size(114, 20);
            this.userState.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(603, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "State";
            // 
            // userCity
            // 
            this.userCity.Location = new System.Drawing.Point(481, 169);
            this.userCity.Name = "userCity";
            this.userCity.Size = new System.Drawing.Size(114, 20);
            this.userCity.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(424, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "City";
            // 
            // userAddress
            // 
            this.userAddress.Location = new System.Drawing.Point(481, 143);
            this.userAddress.Name = "userAddress";
            this.userAddress.Size = new System.Drawing.Size(114, 20);
            this.userAddress.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(424, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Addr";
            // 
            // userPDON
            // 
            this.userPDON.Location = new System.Drawing.Point(481, 117);
            this.userPDON.Name = "userPDON";
            this.userPDON.Size = new System.Drawing.Size(114, 20);
            this.userPDON.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(424, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "PDON";
            // 
            // userPager
            // 
            this.userPager.Location = new System.Drawing.Point(481, 91);
            this.userPager.Name = "userPager";
            this.userPager.Size = new System.Drawing.Size(114, 20);
            this.userPager.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Pager";
            // 
            // userMobile
            // 
            this.userMobile.Location = new System.Drawing.Point(481, 65);
            this.userMobile.Name = "userMobile";
            this.userMobile.Size = new System.Drawing.Size(114, 20);
            this.userMobile.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Mobile";
            // 
            // userIPPhone
            // 
            this.userIPPhone.Location = new System.Drawing.Point(481, 39);
            this.userIPPhone.Name = "userIPPhone";
            this.userIPPhone.Size = new System.Drawing.Size(114, 20);
            this.userIPPhone.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(424, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "ipPhone";
            // 
            // userCompany
            // 
            this.userCompany.Location = new System.Drawing.Point(481, 13);
            this.userCompany.Name = "userCompany";
            this.userCompany.Size = new System.Drawing.Size(114, 20);
            this.userCompany.TabIndex = 26;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(424, 16);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(51, 13);
            this.lblCompany.TabIndex = 27;
            this.lblCompany.Text = "Company";
            // 
            // userEnabled
            // 
            this.userEnabled.AutoSize = true;
            this.userEnabled.Location = new System.Drawing.Point(306, 184);
            this.userEnabled.Name = "userEnabled";
            this.userEnabled.Size = new System.Drawing.Size(65, 17);
            this.userEnabled.TabIndex = 25;
            this.userEnabled.Text = "Enabled";
            this.userEnabled.UseVisualStyleBackColor = true;
            // 
            // userSAMAccountName
            // 
            this.userSAMAccountName.Location = new System.Drawing.Point(481, 195);
            this.userSAMAccountName.Name = "userSAMAccountName";
            this.userSAMAccountName.Size = new System.Drawing.Size(114, 20);
            this.userSAMAccountName.TabIndex = 3;
            // 
            // lblSamName
            // 
            this.lblSamName.AutoSize = true;
            this.lblSamName.Location = new System.Drawing.Point(433, 198);
            this.lblSamName.Name = "lblSamName";
            this.lblSamName.Size = new System.Drawing.Size(29, 13);
            this.lblSamName.TabIndex = 22;
            this.lblSamName.Text = "SAN";
            // 
            // userPassword2
            // 
            this.userPassword2.Location = new System.Drawing.Point(294, 152);
            this.userPassword2.Name = "userPassword2";
            this.userPassword2.Size = new System.Drawing.Size(114, 20);
            this.userPassword2.TabIndex = 12;
            this.userPassword2.TextChanged += new System.EventHandler(this.userPassword2_TextChanged);
            // 
            // lblPasswordRepeat
            // 
            this.lblPasswordRepeat.AutoSize = true;
            this.lblPasswordRepeat.Location = new System.Drawing.Point(246, 155);
            this.lblPasswordRepeat.Name = "lblPasswordRepeat";
            this.lblPasswordRepeat.Size = new System.Drawing.Size(42, 13);
            this.lblPasswordRepeat.TabIndex = 19;
            this.lblPasswordRepeat.Text = "Repeat";
            // 
            // userPassword1
            // 
            this.userPassword1.Location = new System.Drawing.Point(294, 126);
            this.userPassword1.Name = "userPassword1";
            this.userPassword1.Size = new System.Drawing.Size(114, 20);
            this.userPassword1.TabIndex = 11;
            this.userPassword1.TextChanged += new System.EventHandler(this.userPassword1_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(235, 131);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 17;
            this.lblPassword.Text = "Password";
            // 
            // newGroup
            // 
            this.newGroup.Location = new System.Drawing.Point(82, 126);
            this.newGroup.Name = "newGroup";
            this.newGroup.Size = new System.Drawing.Size(114, 20);
            this.newGroup.TabIndex = 7;
            // 
            // removeGroup
            // 
            this.removeGroup.Location = new System.Drawing.Point(202, 155);
            this.removeGroup.Name = "removeGroup";
            this.removeGroup.Size = new System.Drawing.Size(21, 23);
            this.removeGroup.TabIndex = 10;
            this.removeGroup.Text = "-";
            this.removeGroup.UseVisualStyleBackColor = true;
            this.removeGroup.Click += new System.EventHandler(this.removeGroup_Click);
            // 
            // addGroup
            // 
            this.addGroup.Location = new System.Drawing.Point(202, 126);
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
            this.lblGroups.Location = new System.Drawing.Point(7, 126);
            this.lblGroups.Name = "lblGroups";
            this.lblGroups.Size = new System.Drawing.Size(41, 13);
            this.lblGroups.TabIndex = 15;
            this.lblGroups.Text = "Groups";
            // 
            // userGroups
            // 
            this.userGroups.FormattingEnabled = true;
            this.userGroups.Location = new System.Drawing.Point(82, 152);
            this.userGroups.Name = "userGroups";
            this.userGroups.Size = new System.Drawing.Size(114, 95);
            this.userGroups.TabIndex = 9;
            // 
            // userMainPhone
            // 
            this.userMainPhone.Location = new System.Drawing.Point(293, 100);
            this.userMainPhone.Name = "userMainPhone";
            this.userMainPhone.Size = new System.Drawing.Size(114, 20);
            this.userMainPhone.TabIndex = 6;
            // 
            // lblMainPhone
            // 
            this.lblMainPhone.AutoSize = true;
            this.lblMainPhone.Location = new System.Drawing.Point(223, 104);
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
            this.userSurname.Location = new System.Drawing.Point(293, 19);
            this.userSurname.Name = "userSurname";
            this.userSurname.Size = new System.Drawing.Size(114, 20);
            this.userSurname.TabIndex = 1;
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(238, 19);
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
            this.statusStrip1.Size = new System.Drawing.Size(885, 22);
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
            this.save.Location = new System.Drawing.Point(798, 202);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 5;
            this.save.Text = "&Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(825, 14);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(47, 23);
            this.newButton.TabIndex = 3;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(798, 231);
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
            this.searchResults.Location = new System.Drawing.Point(12, 42);
            this.searchResults.Name = "searchResults";
            this.searchResults.Size = new System.Drawing.Size(861, 150);
            this.searchResults.TabIndex = 24;
            // 
            // ADField
            // 
            this.ADField.FormattingEnabled = true;
            this.ADField.Location = new System.Drawing.Point(456, 15);
            this.ADField.Name = "ADField";
            this.ADField.Size = new System.Drawing.Size(121, 21);
            this.ADField.TabIndex = 25;
            this.ADField.SelectedIndexChanged += new System.EventHandler(this.ADField_SelectedIndexChanged);
            // 
            // userUPN
            // 
            this.userUPN.Location = new System.Drawing.Point(660, 195);
            this.userUPN.Name = "userUPN";
            this.userUPN.Size = new System.Drawing.Size(114, 20);
            this.userUPN.TabIndex = 54;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(612, 198);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 55;
            this.label14.Text = "UPN";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 529);
            this.Controls.Add(this.ADField);
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
            this.Load += new System.EventHandler(this.main_Load);
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
        private System.Windows.Forms.TextBox userCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TextBox userManager;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox userDepartment;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox userTitle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox userEmployeeType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox userCountry;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox userState;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox userCity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox userAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox userPDON;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox userPager;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userMobile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userIPPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userPostalCode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox ADField;
        private System.Windows.Forms.TextBox userUPN;
        private System.Windows.Forms.Label label14;
    }
}

