namespace OptimaBaseForm.Views
{
    partial class ConnectionConfigView
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
            this.panelMainButtons = new System.Windows.Forms.Panel();
            this.btnCloseView = new System.Windows.Forms.Button();
            this.btnSaveView = new System.Windows.Forms.Button();
            this.panelMainView = new System.Windows.Forms.Panel();
            this.gbSql = new System.Windows.Forms.GroupBox();
            this.label81 = new System.Windows.Forms.Label();
            this.tbSqlOptBazaKonfigConnectionStr = new System.Windows.Forms.TextBox();
            this.cbSqlConnStringPobierajZOpt = new System.Windows.Forms.CheckBox();
            this.panelSql = new System.Windows.Forms.Panel();
            this.rbSqlAuth = new System.Windows.Forms.RadioButton();
            this.rbWindowsAuth = new System.Windows.Forms.RadioButton();
            this.tbNazwaSerweraSql = new System.Windows.Forms.TextBox();
            this.btnCheckSqlConnection = new System.Windows.Forms.Button();
            this.labelBaza = new System.Windows.Forms.Label();
            this.labelSerwer = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbNazwaBazySql = new System.Windows.Forms.TextBox();
            this.tbLoginSql = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbHasloSql = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbBLToken = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label167 = new System.Windows.Forms.Label();
            this.tbServerKey = new System.Windows.Forms.TextBox();
            this.labelOptHaslo = new System.Windows.Forms.Label();
            this.cbOptModulyUsera = new System.Windows.Forms.CheckBox();
            this.labelOptOperator = new System.Windows.Forms.Label();
            this.labelOptKatalog = new System.Windows.Forms.Label();
            this.tbOptPass = new System.Windows.Forms.TextBox();
            this.tbOptPath = new System.Windows.Forms.TextBox();
            this.tbOptUser = new System.Windows.Forms.TextBox();
            this.btnOptConnectionTest = new System.Windows.Forms.Button();
            this.btnPickOptPath = new System.Windows.Forms.Button();
            this.labelOptFirma = new System.Windows.Forms.Label();
            this.tbOptCompany = new System.Windows.Forms.TextBox();
            this.cbOptHAP = new System.Windows.Forms.CheckBox();
            this.cbOptKBP = new System.Windows.Forms.CheckBox();
            this.fbdOptPath = new System.Windows.Forms.FolderBrowserDialog();
            this.panelMainButtons.SuspendLayout();
            this.panelMainView.SuspendLayout();
            this.gbSql.SuspendLayout();
            this.panelSql.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMainButtons
            // 
            this.panelMainButtons.BackColor = System.Drawing.Color.White;
            this.panelMainButtons.Controls.Add(this.btnCloseView);
            this.panelMainButtons.Controls.Add(this.btnSaveView);
            this.panelMainButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMainButtons.Location = new System.Drawing.Point(0, 521);
            this.panelMainButtons.Name = "panelMainButtons";
            this.panelMainButtons.Padding = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.panelMainButtons.Size = new System.Drawing.Size(984, 40);
            this.panelMainButtons.TabIndex = 4;
            // 
            // btnCloseView
            // 
            this.btnCloseView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseView.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCloseView.FlatAppearance.BorderSize = 0;
            this.btnCloseView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseView.ForeColor = System.Drawing.Color.White;
            this.btnCloseView.Location = new System.Drawing.Point(786, 3);
            this.btnCloseView.Name = "btnCloseView";
            this.btnCloseView.Size = new System.Drawing.Size(92, 29);
            this.btnCloseView.TabIndex = 1;
            this.btnCloseView.Text = "Anuluj";
            this.btnCloseView.UseVisualStyleBackColor = false;
            // 
            // btnSaveView
            // 
            this.btnSaveView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveView.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSaveView.FlatAppearance.BorderSize = 0;
            this.btnSaveView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveView.ForeColor = System.Drawing.Color.White;
            this.btnSaveView.Location = new System.Drawing.Point(884, 3);
            this.btnSaveView.Name = "btnSaveView";
            this.btnSaveView.Size = new System.Drawing.Size(92, 29);
            this.btnSaveView.TabIndex = 0;
            this.btnSaveView.Text = "Zapisz";
            this.btnSaveView.UseVisualStyleBackColor = false;
            // 
            // panelMainView
            // 
            this.panelMainView.BackColor = System.Drawing.Color.White;
            this.panelMainView.Controls.Add(this.gbSql);
            this.panelMainView.Controls.Add(this.groupBox5);
            this.panelMainView.Controls.Add(this.groupBox2);
            this.panelMainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainView.Location = new System.Drawing.Point(0, 0);
            this.panelMainView.Name = "panelMainView";
            this.panelMainView.Size = new System.Drawing.Size(984, 561);
            this.panelMainView.TabIndex = 3;
            // 
            // gbSql
            // 
            this.gbSql.Controls.Add(this.label81);
            this.gbSql.Controls.Add(this.tbSqlOptBazaKonfigConnectionStr);
            this.gbSql.Controls.Add(this.cbSqlConnStringPobierajZOpt);
            this.gbSql.Controls.Add(this.panelSql);
            this.gbSql.Controls.Add(this.label26);
            this.gbSql.Location = new System.Drawing.Point(375, 2);
            this.gbSql.Margin = new System.Windows.Forms.Padding(2);
            this.gbSql.Name = "gbSql";
            this.gbSql.Padding = new System.Windows.Forms.Padding(2);
            this.gbSql.Size = new System.Drawing.Size(362, 362);
            this.gbSql.TabIndex = 7;
            this.gbSql.TabStop = false;
            this.gbSql.Text = "SQL";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(9, 286);
            this.label81.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(107, 15);
            this.label81.TabIndex = 52;
            this.label81.Text = "Konfig Connect Str";
            // 
            // tbSqlOptBazaKonfigConnectionStr
            // 
            this.tbSqlOptBazaKonfigConnectionStr.Location = new System.Drawing.Point(13, 306);
            this.tbSqlOptBazaKonfigConnectionStr.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbSqlOptBazaKonfigConnectionStr.Multiline = true;
            this.tbSqlOptBazaKonfigConnectionStr.Name = "tbSqlOptBazaKonfigConnectionStr";
            this.tbSqlOptBazaKonfigConnectionStr.Size = new System.Drawing.Size(326, 39);
            this.tbSqlOptBazaKonfigConnectionStr.TabIndex = 51;
            this.tbSqlOptBazaKonfigConnectionStr.UseSystemPasswordChar = true;
            // 
            // cbSqlConnStringPobierajZOpt
            // 
            this.cbSqlConnStringPobierajZOpt.AutoSize = true;
            this.cbSqlConnStringPobierajZOpt.Location = new System.Drawing.Point(111, 38);
            this.cbSqlConnStringPobierajZOpt.Margin = new System.Windows.Forms.Padding(2);
            this.cbSqlConnStringPobierajZOpt.Name = "cbSqlConnStringPobierajZOpt";
            this.cbSqlConnStringPobierajZOpt.Size = new System.Drawing.Size(118, 19);
            this.cbSqlConnStringPobierajZOpt.TabIndex = 49;
            this.cbSqlConnStringPobierajZOpt.Text = "Pobieraj z optimy";
            this.cbSqlConnStringPobierajZOpt.UseVisualStyleBackColor = true;
            this.cbSqlConnStringPobierajZOpt.CheckedChanged += new System.EventHandler(this.cbSqlConnStringPobierajZOpt_CheckedChanged);
            // 
            // panelSql
            // 
            this.panelSql.Controls.Add(this.rbSqlAuth);
            this.panelSql.Controls.Add(this.rbWindowsAuth);
            this.panelSql.Controls.Add(this.tbNazwaSerweraSql);
            this.panelSql.Controls.Add(this.btnCheckSqlConnection);
            this.panelSql.Controls.Add(this.labelBaza);
            this.panelSql.Controls.Add(this.labelSerwer);
            this.panelSql.Controls.Add(this.label8);
            this.panelSql.Controls.Add(this.tbNazwaBazySql);
            this.panelSql.Controls.Add(this.tbLoginSql);
            this.panelSql.Controls.Add(this.label9);
            this.panelSql.Controls.Add(this.tbHasloSql);
            this.panelSql.Location = new System.Drawing.Point(7, 61);
            this.panelSql.Margin = new System.Windows.Forms.Padding(2);
            this.panelSql.Name = "panelSql";
            this.panelSql.Size = new System.Drawing.Size(348, 220);
            this.panelSql.TabIndex = 50;
            // 
            // rbSqlAuth
            // 
            this.rbSqlAuth.AutoSize = true;
            this.rbSqlAuth.Location = new System.Drawing.Point(105, 90);
            this.rbSqlAuth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbSqlAuth.Name = "rbSqlAuth";
            this.rbSqlAuth.Size = new System.Drawing.Size(166, 19);
            this.rbSqlAuth.TabIndex = 47;
            this.rbSqlAuth.TabStop = true;
            this.rbSqlAuth.Text = "SQL Serwer Authentication";
            this.rbSqlAuth.UseVisualStyleBackColor = true;
            // 
            // rbWindowsAuth
            // 
            this.rbWindowsAuth.AutoSize = true;
            this.rbWindowsAuth.Location = new System.Drawing.Point(105, 66);
            this.rbWindowsAuth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbWindowsAuth.Name = "rbWindowsAuth";
            this.rbWindowsAuth.Size = new System.Drawing.Size(153, 19);
            this.rbWindowsAuth.TabIndex = 46;
            this.rbWindowsAuth.Text = "Windows Authentcation";
            this.rbWindowsAuth.UseVisualStyleBackColor = true;
            // 
            // tbNazwaSerweraSql
            // 
            this.tbNazwaSerweraSql.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbNazwaSerweraSql.Location = new System.Drawing.Point(105, 8);
            this.tbNazwaSerweraSql.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbNazwaSerweraSql.Name = "tbNazwaSerweraSql";
            this.tbNazwaSerweraSql.Size = new System.Drawing.Size(227, 23);
            this.tbNazwaSerweraSql.TabIndex = 38;
            // 
            // btnCheckSqlConnection
            // 
            this.btnCheckSqlConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckSqlConnection.Location = new System.Drawing.Point(105, 178);
            this.btnCheckSqlConnection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCheckSqlConnection.Name = "btnCheckSqlConnection";
            this.btnCheckSqlConnection.Size = new System.Drawing.Size(226, 32);
            this.btnCheckSqlConnection.TabIndex = 45;
            this.btnCheckSqlConnection.Text = "Sprawdź połączenie";
            this.btnCheckSqlConnection.UseVisualStyleBackColor = true;
            // 
            // labelBaza
            // 
            this.labelBaza.AutoSize = true;
            this.labelBaza.BackColor = System.Drawing.Color.Transparent;
            this.labelBaza.Location = new System.Drawing.Point(4, 38);
            this.labelBaza.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBaza.Name = "labelBaza";
            this.labelBaza.Size = new System.Drawing.Size(72, 15);
            this.labelBaza.TabIndex = 40;
            this.labelBaza.Text = "Nazwa bazy:";
            // 
            // labelSerwer
            // 
            this.labelSerwer.AutoSize = true;
            this.labelSerwer.BackColor = System.Drawing.Color.Transparent;
            this.labelSerwer.Location = new System.Drawing.Point(4, 10);
            this.labelSerwer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSerwer.Name = "labelSerwer";
            this.labelSerwer.Size = new System.Drawing.Size(88, 15);
            this.labelSerwer.TabIndex = 37;
            this.labelSerwer.Text = "Nazwa serwera:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 153);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 15);
            this.label8.TabIndex = 44;
            this.label8.Text = "Hasło:";
            // 
            // tbNazwaBazySql
            // 
            this.tbNazwaBazySql.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbNazwaBazySql.Location = new System.Drawing.Point(105, 38);
            this.tbNazwaBazySql.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbNazwaBazySql.Name = "tbNazwaBazySql";
            this.tbNazwaBazySql.Size = new System.Drawing.Size(227, 23);
            this.tbNazwaBazySql.TabIndex = 39;
            // 
            // tbLoginSql
            // 
            this.tbLoginSql.Location = new System.Drawing.Point(105, 119);
            this.tbLoginSql.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbLoginSql.Name = "tbLoginSql";
            this.tbLoginSql.Size = new System.Drawing.Size(227, 23);
            this.tbLoginSql.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 126);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 15);
            this.label9.TabIndex = 43;
            this.label9.Text = "Login:";
            // 
            // tbHasloSql
            // 
            this.tbHasloSql.Location = new System.Drawing.Point(105, 148);
            this.tbHasloSql.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbHasloSql.Name = "tbHasloSql";
            this.tbHasloSql.Size = new System.Drawing.Size(227, 23);
            this.tbHasloSql.TabIndex = 42;
            this.tbHasloSql.UseSystemPasswordChar = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(8, 20);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(339, 15);
            this.label26.TabIndex = 48;
            this.label26.Text = "Opcjonalnie, domyślnie połączenie z użytkownika optimowego";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbBLToken);
            this.groupBox5.Location = new System.Drawing.Point(24, 302);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(347, 62);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Token API Baselinker";
            // 
            // tbBLToken
            // 
            this.tbBLToken.Location = new System.Drawing.Point(15, 28);
            this.tbBLToken.Margin = new System.Windows.Forms.Padding(2);
            this.tbBLToken.Name = "tbBLToken";
            this.tbBLToken.Size = new System.Drawing.Size(319, 23);
            this.tbBLToken.TabIndex = 64;
            this.tbBLToken.UseSystemPasswordChar = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label167);
            this.groupBox2.Controls.Add(this.tbServerKey);
            this.groupBox2.Controls.Add(this.labelOptHaslo);
            this.groupBox2.Controls.Add(this.cbOptModulyUsera);
            this.groupBox2.Controls.Add(this.labelOptOperator);
            this.groupBox2.Controls.Add(this.labelOptKatalog);
            this.groupBox2.Controls.Add(this.tbOptPass);
            this.groupBox2.Controls.Add(this.tbOptPath);
            this.groupBox2.Controls.Add(this.tbOptUser);
            this.groupBox2.Controls.Add(this.btnOptConnectionTest);
            this.groupBox2.Controls.Add(this.btnPickOptPath);
            this.groupBox2.Controls.Add(this.labelOptFirma);
            this.groupBox2.Controls.Add(this.tbOptCompany);
            this.groupBox2.Controls.Add(this.cbOptHAP);
            this.groupBox2.Controls.Add(this.cbOptKBP);
            this.groupBox2.Location = new System.Drawing.Point(24, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(347, 288);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Optima";
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Location = new System.Drawing.Point(4, 132);
            this.label167.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(82, 15);
            this.label167.TabIndex = 65;
            this.label167.Text = "Serwer Klucza:";
            // 
            // tbServerKey
            // 
            this.tbServerKey.Location = new System.Drawing.Point(108, 129);
            this.tbServerKey.Margin = new System.Windows.Forms.Padding(2);
            this.tbServerKey.Name = "tbServerKey";
            this.tbServerKey.Size = new System.Drawing.Size(227, 23);
            this.tbServerKey.TabIndex = 64;
            // 
            // labelOptHaslo
            // 
            this.labelOptHaslo.AutoSize = true;
            this.labelOptHaslo.Location = new System.Drawing.Point(4, 80);
            this.labelOptHaslo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOptHaslo.Name = "labelOptHaslo";
            this.labelOptHaslo.Size = new System.Drawing.Size(40, 15);
            this.labelOptHaslo.TabIndex = 3;
            this.labelOptHaslo.Text = "Hasło:";
            // 
            // cbOptModulyUsera
            // 
            this.cbOptModulyUsera.AutoSize = true;
            this.cbOptModulyUsera.Location = new System.Drawing.Point(7, 161);
            this.cbOptModulyUsera.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbOptModulyUsera.Name = "cbOptModulyUsera";
            this.cbOptModulyUsera.Size = new System.Drawing.Size(178, 19);
            this.cbOptModulyUsera.TabIndex = 63;
            this.cbOptModulyUsera.Text = "Pobierz moduły użytkownika";
            this.cbOptModulyUsera.UseVisualStyleBackColor = true;
            this.cbOptModulyUsera.CheckedChanged += new System.EventHandler(this.cbOptModulyUsera_CheckedChanged);
            // 
            // labelOptOperator
            // 
            this.labelOptOperator.AutoSize = true;
            this.labelOptOperator.Location = new System.Drawing.Point(4, 52);
            this.labelOptOperator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOptOperator.Name = "labelOptOperator";
            this.labelOptOperator.Size = new System.Drawing.Size(57, 15);
            this.labelOptOperator.TabIndex = 2;
            this.labelOptOperator.Text = "Operator:";
            // 
            // labelOptKatalog
            // 
            this.labelOptKatalog.AutoSize = true;
            this.labelOptKatalog.BackColor = System.Drawing.Color.Transparent;
            this.labelOptKatalog.Location = new System.Drawing.Point(4, 26);
            this.labelOptKatalog.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOptKatalog.Name = "labelOptKatalog";
            this.labelOptKatalog.Size = new System.Drawing.Size(93, 15);
            this.labelOptKatalog.TabIndex = 50;
            this.labelOptKatalog.Text = "Katalog Optimy:";
            // 
            // tbOptPass
            // 
            this.tbOptPass.Location = new System.Drawing.Point(108, 77);
            this.tbOptPass.Margin = new System.Windows.Forms.Padding(2);
            this.tbOptPass.Name = "tbOptPass";
            this.tbOptPass.Size = new System.Drawing.Size(227, 23);
            this.tbOptPass.TabIndex = 1;
            this.tbOptPass.UseSystemPasswordChar = true;
            // 
            // tbOptPath
            // 
            this.tbOptPath.Location = new System.Drawing.Point(108, 25);
            this.tbOptPath.Margin = new System.Windows.Forms.Padding(2);
            this.tbOptPath.Name = "tbOptPath";
            this.tbOptPath.Size = new System.Drawing.Size(184, 23);
            this.tbOptPath.TabIndex = 51;
            // 
            // tbOptUser
            // 
            this.tbOptUser.Location = new System.Drawing.Point(108, 51);
            this.tbOptUser.Margin = new System.Windows.Forms.Padding(2);
            this.tbOptUser.Name = "tbOptUser";
            this.tbOptUser.Size = new System.Drawing.Size(227, 23);
            this.tbOptUser.TabIndex = 0;
            // 
            // btnOptConnectionTest
            // 
            this.btnOptConnectionTest.Location = new System.Drawing.Point(108, 223);
            this.btnOptConnectionTest.Margin = new System.Windows.Forms.Padding(2);
            this.btnOptConnectionTest.Name = "btnOptConnectionTest";
            this.btnOptConnectionTest.Size = new System.Drawing.Size(226, 33);
            this.btnOptConnectionTest.TabIndex = 60;
            this.btnOptConnectionTest.Text = "Sprawdź połączenie";
            this.btnOptConnectionTest.UseVisualStyleBackColor = true;
            // 
            // btnPickOptPath
            // 
            this.btnPickOptPath.Location = new System.Drawing.Point(296, 23);
            this.btnPickOptPath.Margin = new System.Windows.Forms.Padding(2);
            this.btnPickOptPath.Name = "btnPickOptPath";
            this.btnPickOptPath.Size = new System.Drawing.Size(38, 24);
            this.btnPickOptPath.TabIndex = 55;
            this.btnPickOptPath.Text = "...";
            this.btnPickOptPath.UseVisualStyleBackColor = true;
            this.btnPickOptPath.Click += new System.EventHandler(this.btnPickOptPath_Click);
            // 
            // labelOptFirma
            // 
            this.labelOptFirma.AutoSize = true;
            this.labelOptFirma.Location = new System.Drawing.Point(4, 105);
            this.labelOptFirma.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOptFirma.Name = "labelOptFirma";
            this.labelOptFirma.Size = new System.Drawing.Size(40, 15);
            this.labelOptFirma.TabIndex = 52;
            this.labelOptFirma.Text = "Firma:";
            // 
            // tbOptCompany
            // 
            this.tbOptCompany.Location = new System.Drawing.Point(108, 103);
            this.tbOptCompany.Margin = new System.Windows.Forms.Padding(2);
            this.tbOptCompany.Name = "tbOptCompany";
            this.tbOptCompany.Size = new System.Drawing.Size(227, 23);
            this.tbOptCompany.TabIndex = 53;
            // 
            // cbOptHAP
            // 
            this.cbOptHAP.AutoSize = true;
            this.cbOptHAP.Location = new System.Drawing.Point(165, 186);
            this.cbOptHAP.Margin = new System.Windows.Forms.Padding(2);
            this.cbOptHAP.Name = "cbOptHAP";
            this.cbOptHAP.Size = new System.Drawing.Size(89, 19);
            this.cbOptHAP.TabIndex = 61;
            this.cbOptHAP.Text = "Handel Plus";
            this.cbOptHAP.UseVisualStyleBackColor = true;
            // 
            // cbOptKBP
            // 
            this.cbOptKBP.AutoSize = true;
            this.cbOptKBP.Location = new System.Drawing.Point(7, 185);
            this.cbOptKBP.Margin = new System.Windows.Forms.Padding(2);
            this.cbOptKBP.Name = "cbOptKBP";
            this.cbOptKBP.Size = new System.Drawing.Size(104, 19);
            this.cbOptKBP.TabIndex = 62;
            this.cbOptKBP.Text = "Kasa Bank Plus";
            this.cbOptKBP.UseVisualStyleBackColor = true;
            // 
            // ConnectionConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panelMainButtons);
            this.Controls.Add(this.panelMainView);
            this.Name = "ConnectionConfigView";
            this.Text = "ConnectionConfig";
            this.panelMainButtons.ResumeLayout(false);
            this.panelMainView.ResumeLayout(false);
            this.gbSql.ResumeLayout(false);
            this.gbSql.PerformLayout();
            this.panelSql.ResumeLayout(false);
            this.panelSql.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelMainButtons;
        private Button btnCloseView;
        private Button btnSaveView;
        private Panel panelMainView;
        private GroupBox gbSql;
        private Label label81;
        private TextBox tbSqlOptBazaKonfigConnectionStr;
        private CheckBox cbSqlConnStringPobierajZOpt;
        private Panel panelSql;
        private RadioButton rbSqlAuth;
        private RadioButton rbWindowsAuth;
        private TextBox tbNazwaSerweraSql;
        private Button btnCheckSqlConnection;
        private Label labelBaza;
        public Label labelSerwer;
        private Label label8;
        private TextBox tbNazwaBazySql;
        private TextBox tbLoginSql;
        private Label label9;
        private TextBox tbHasloSql;
        private Label label26;
        private GroupBox groupBox5;
        private TextBox tbBLToken;
        private GroupBox groupBox2;
        private Label label167;
        private TextBox tbServerKey;
        private Label labelOptHaslo;
        private CheckBox cbOptModulyUsera;
        private Label labelOptOperator;
        public Label labelOptKatalog;
        protected internal TextBox tbOptPass;
        private TextBox tbOptPath;
        protected internal TextBox tbOptUser;
        private Button btnOptConnectionTest;
        private Button btnPickOptPath;
        private Label labelOptFirma;
        private TextBox tbOptCompany;
        private CheckBox cbOptHAP;
        private CheckBox cbOptKBP;
        private FolderBrowserDialog fbdOptPath;
    }
}