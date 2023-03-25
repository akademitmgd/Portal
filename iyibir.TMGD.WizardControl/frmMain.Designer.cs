
namespace iyibir.TMGD.WizardControl
{
    partial class frmMain
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
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtLicenseNumber = new DevExpress.XtraEditors.TextEdit();
            this.wizardPageCustomerInfo = new DevExpress.XtraWizard.WizardPage();
            this.txtCustomerTelephone = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtCustomerEmail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCustomerCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.wizardPageConnectionParameter = new DevExpress.XtraWizard.WizardPage();
            this.btnTest = new DevExpress.XtraEditors.SimpleButton();
            this.txtDatabase = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtUserId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtServerName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.wizardPageProductList = new DevExpress.XtraWizard.WizardPage();
            this.gridControlProductList = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.wizardPageProductInstall = new DevExpress.XtraWizard.WizardPage();
            this.lblProductStatus = new DevExpress.XtraEditors.LabelControl();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.wizardPageSupplierList = new DevExpress.XtraWizard.WizardPage();
            this.gridControlSupplierList = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.wizardPageSupplierInstall = new DevExpress.XtraWizard.WizardPage();
            this.lblSupplierStatus = new DevExpress.XtraEditors.LabelControl();
            this.progressBarControl2 = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.welcomeWizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLicenseNumber.Properties)).BeginInit();
            this.wizardPageCustomerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerTelephone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerCode.Properties)).BeginInit();
            this.wizardPageConnectionParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).BeginInit();
            this.wizardPageProductList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.wizardPageProductInstall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            this.wizardPageSupplierList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSupplierList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.wizardPageSupplierInstall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.CancelText = "Vazgeç";
            this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPageCustomerInfo);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPageConnectionParameter);
            this.wizardControl1.Controls.Add(this.wizardPageProductList);
            this.wizardControl1.Controls.Add(this.wizardPageProductInstall);
            this.wizardControl1.Controls.Add(this.wizardPageSupplierList);
            this.wizardControl1.Controls.Add(this.wizardPageSupplierInstall);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.FinishText = "&Tamamlandı";
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextText = "&İleri >";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPageCustomerInfo,
            this.wizardPageConnectionParameter,
            this.wizardPageProductList,
            this.wizardPageProductInstall,
            this.wizardPageSupplierList,
            this.wizardPageSupplierInstall,
            this.completionWizardPage1});
            this.wizardControl1.Size = new System.Drawing.Size(833, 547);
            this.wizardControl1.Text = "Geri";
            this.wizardControl1.WizardStyle = DevExpress.XtraWizard.WizardStyle.WizardAero;
            this.wizardControl1.SelectedPageChanging += new DevExpress.XtraWizard.WizardPageChangingEventHandler(this.wizardControl1_SelectedPageChanging);
            this.wizardControl1.CancelClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_CancelClick);
            this.wizardControl1.FinishClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_FinishClick);
            this.wizardControl1.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.WizardControl1_NextClick);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.Controls.Add(this.labelControl1);
            this.welcomeWizardPage1.Controls.Add(this.txtLicenseNumber);
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(773, 380);
            this.welcomeWizardPage1.Text = "Lisans Bilgileri";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(67, 125);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Lisans Bilgileri";
            // 
            // txtLicenseNumber
            // 
            this.txtLicenseNumber.Location = new System.Drawing.Point(67, 145);
            this.txtLicenseNumber.Name = "txtLicenseNumber";
            this.txtLicenseNumber.Properties.Mask.EditMask = "[0-9A-F]{8}(-[0-9A-F]{4}){3}-[0-9A-F]{12}";
            this.txtLicenseNumber.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtLicenseNumber.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtLicenseNumber.Size = new System.Drawing.Size(638, 20);
            this.txtLicenseNumber.TabIndex = 0;
            // 
            // wizardPageCustomerInfo
            // 
            this.wizardPageCustomerInfo.Controls.Add(this.txtCustomerTelephone);
            this.wizardPageCustomerInfo.Controls.Add(this.labelControl4);
            this.wizardPageCustomerInfo.Controls.Add(this.txtCustomerEmail);
            this.wizardPageCustomerInfo.Controls.Add(this.labelControl5);
            this.wizardPageCustomerInfo.Controls.Add(this.txtCustomerName);
            this.wizardPageCustomerInfo.Controls.Add(this.labelControl3);
            this.wizardPageCustomerInfo.Controls.Add(this.txtCustomerCode);
            this.wizardPageCustomerInfo.Controls.Add(this.labelControl2);
            this.wizardPageCustomerInfo.Name = "wizardPageCustomerInfo";
            this.wizardPageCustomerInfo.Size = new System.Drawing.Size(773, 380);
            this.wizardPageCustomerInfo.Text = "Müşteri Bilgileri";
            // 
            // txtCustomerTelephone
            // 
            this.txtCustomerTelephone.Location = new System.Drawing.Point(214, 205);
            this.txtCustomerTelephone.Name = "txtCustomerTelephone";
            this.txtCustomerTelephone.Properties.ReadOnly = true;
            this.txtCustomerTelephone.Size = new System.Drawing.Size(425, 20);
            this.txtCustomerTelephone.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(116, 208);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(39, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Telefon";
            // 
            // txtCustomerEmail
            // 
            this.txtCustomerEmail.Location = new System.Drawing.Point(214, 179);
            this.txtCustomerEmail.Name = "txtCustomerEmail";
            this.txtCustomerEmail.Properties.ReadOnly = true;
            this.txtCustomerEmail.Size = new System.Drawing.Size(425, 20);
            this.txtCustomerEmail.TabIndex = 5;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(116, 182);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(38, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "E-Posta";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(214, 152);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(425, 20);
            this.txtCustomerName.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(116, 155);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Unvanı";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(214, 126);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Properties.ReadOnly = true;
            this.txtCustomerCode.Size = new System.Drawing.Size(425, 20);
            this.txtCustomerCode.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(116, 129);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(27, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Kodu";
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.Size = new System.Drawing.Size(773, 380);
            this.completionWizardPage1.Text = "Yükleme Tamamlandı..";
            // 
            // wizardPageConnectionParameter
            // 
            this.wizardPageConnectionParameter.Controls.Add(this.btnTest);
            this.wizardPageConnectionParameter.Controls.Add(this.txtDatabase);
            this.wizardPageConnectionParameter.Controls.Add(this.labelControl6);
            this.wizardPageConnectionParameter.Controls.Add(this.txtPassword);
            this.wizardPageConnectionParameter.Controls.Add(this.labelControl7);
            this.wizardPageConnectionParameter.Controls.Add(this.txtUserId);
            this.wizardPageConnectionParameter.Controls.Add(this.labelControl8);
            this.wizardPageConnectionParameter.Controls.Add(this.txtServerName);
            this.wizardPageConnectionParameter.Controls.Add(this.labelControl9);
            this.wizardPageConnectionParameter.Name = "wizardPageConnectionParameter";
            this.wizardPageConnectionParameter.Size = new System.Drawing.Size(773, 380);
            this.wizardPageConnectionParameter.Text = "LOGO Bağlantı Ayarları";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(559, 258);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(89, 23);
            this.btnTest.TabIndex = 16;
            this.btnTest.Text = "Bağlantı Testi";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(223, 220);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(425, 20);
            this.txtDatabase.TabIndex = 15;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(125, 223);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(81, 13);
            this.labelControl6.TabIndex = 14;
            this.labelControl6.Text = "LOGO Veritbanı";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(223, 194);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(425, 20);
            this.txtPassword.TabIndex = 13;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(125, 197);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(32, 13);
            this.labelControl7.TabIndex = 12;
            this.labelControl7.Text = "Parola";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(223, 167);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(425, 20);
            this.txtUserId.TabIndex = 11;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(125, 170);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(56, 13);
            this.labelControl8.TabIndex = 10;
            this.labelControl8.Text = "Kullanıcı Id";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(223, 141);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(425, 20);
            this.txtServerName.TabIndex = 9;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(125, 144);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(51, 13);
            this.labelControl9.TabIndex = 8;
            this.labelControl9.Text = "Server Adı";
            // 
            // wizardPageProductList
            // 
            this.wizardPageProductList.Controls.Add(this.gridControlProductList);
            this.wizardPageProductList.Name = "wizardPageProductList";
            this.wizardPageProductList.Size = new System.Drawing.Size(773, 380);
            this.wizardPageProductList.Text = "Tehlikeli Madde Ürün Listesi";
            // 
            // gridControlProductList
            // 
            this.gridControlProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlProductList.Location = new System.Drawing.Point(0, 0);
            this.gridControlProductList.MainView = this.gridView1;
            this.gridControlProductList.Name = "gridControlProductList";
            this.gridControlProductList.Size = new System.Drawing.Size(773, 380);
            this.gridControlProductList.TabIndex = 0;
            this.gridControlProductList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.gridControlProductList;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Ürün Kodu";
            this.gridColumn1.FieldName = "CODE";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ürün Adı";
            this.gridColumn2.FieldName = "NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "UN Kodu";
            this.gridColumn3.FieldName = "SPECODE";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // wizardPageProductInstall
            // 
            this.wizardPageProductInstall.Controls.Add(this.lblProductStatus);
            this.wizardPageProductInstall.Controls.Add(this.progressBarControl1);
            this.wizardPageProductInstall.Name = "wizardPageProductInstall";
            this.wizardPageProductInstall.Size = new System.Drawing.Size(773, 380);
            this.wizardPageProductInstall.Text = "Tehlikeli Madde Ürünleri Yükleniyor..";
            // 
            // lblProductStatus
            // 
            this.lblProductStatus.Location = new System.Drawing.Point(17, 135);
            this.lblProductStatus.Name = "lblProductStatus";
            this.lblProductStatus.Size = new System.Drawing.Size(38, 13);
            this.lblProductStatus.TabIndex = 1;
            this.lblProductStatus.Text = "Status..";
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(17, 154);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Size = new System.Drawing.Size(738, 31);
            this.progressBarControl1.TabIndex = 0;
            // 
            // wizardPageSupplierList
            // 
            this.wizardPageSupplierList.Controls.Add(this.gridControlSupplierList);
            this.wizardPageSupplierList.Name = "wizardPageSupplierList";
            this.wizardPageSupplierList.Size = new System.Drawing.Size(773, 380);
            this.wizardPageSupplierList.Text = "Tedarikçi Listesi";
            // 
            // gridControlSupplierList
            // 
            this.gridControlSupplierList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSupplierList.Location = new System.Drawing.Point(0, 0);
            this.gridControlSupplierList.MainView = this.gridView2;
            this.gridControlSupplierList.Name = "gridControlSupplierList";
            this.gridControlSupplierList.Size = new System.Drawing.Size(773, 380);
            this.gridControlSupplierList.TabIndex = 0;
            this.gridControlSupplierList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gridView2.GridControl = this.gridControlSupplierList;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Kodu";
            this.gridColumn4.FieldName = "CODE";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Unvanı";
            this.gridColumn5.FieldName = "DEFINITION_";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "E-Posta";
            this.gridColumn6.FieldName = "EMAILADDR";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Telefon";
            this.gridColumn7.FieldName = "TELNR1";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            // 
            // wizardPageSupplierInstall
            // 
            this.wizardPageSupplierInstall.Controls.Add(this.lblSupplierStatus);
            this.wizardPageSupplierInstall.Controls.Add(this.progressBarControl2);
            this.wizardPageSupplierInstall.Name = "wizardPageSupplierInstall";
            this.wizardPageSupplierInstall.Size = new System.Drawing.Size(773, 380);
            this.wizardPageSupplierInstall.Text = "Tedarikçiler Yükleniyor..";
            // 
            // lblSupplierStatus
            // 
            this.lblSupplierStatus.Location = new System.Drawing.Point(17, 156);
            this.lblSupplierStatus.Name = "lblSupplierStatus";
            this.lblSupplierStatus.Size = new System.Drawing.Size(38, 13);
            this.lblSupplierStatus.TabIndex = 2;
            this.lblSupplierStatus.Text = "Status..";
            // 
            // progressBarControl2
            // 
            this.progressBarControl2.Location = new System.Drawing.Point(17, 175);
            this.progressBarControl2.Name = "progressBarControl2";
            this.progressBarControl2.Size = new System.Drawing.Size(738, 31);
            this.progressBarControl2.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(833, 547);
            this.Controls.Add(this.wizardControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TMGD-Logo Aktarım Sihirbazı";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.welcomeWizardPage1.ResumeLayout(false);
            this.welcomeWizardPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLicenseNumber.Properties)).EndInit();
            this.wizardPageCustomerInfo.ResumeLayout(false);
            this.wizardPageCustomerInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerTelephone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerCode.Properties)).EndInit();
            this.wizardPageConnectionParameter.ResumeLayout(false);
            this.wizardPageConnectionParameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).EndInit();
            this.wizardPageProductList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.wizardPageProductInstall.ResumeLayout(false);
            this.wizardPageProductInstall.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            this.wizardPageSupplierList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSupplierList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.wizardPageSupplierInstall.ResumeLayout(false);
            this.wizardPageSupplierInstall.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPageCustomerInfo;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPageConnectionParameter;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtLicenseNumber;
        private DevExpress.XtraEditors.TextEdit txtCustomerTelephone;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtCustomerEmail;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtCustomerCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDatabase;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtUserId;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtServerName;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraWizard.WizardPage wizardPageProductList;
        private DevExpress.XtraGrid.GridControl gridControlProductList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraWizard.WizardPage wizardPageProductInstall;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraWizard.WizardPage wizardPageSupplierList;
        private DevExpress.XtraGrid.GridControl gridControlSupplierList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraWizard.WizardPage wizardPageSupplierInstall;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl2;
        private DevExpress.XtraEditors.SimpleButton btnTest;
        private DevExpress.XtraEditors.LabelControl lblProductStatus;
        private DevExpress.XtraEditors.LabelControl lblSupplierStatus;
    }
}