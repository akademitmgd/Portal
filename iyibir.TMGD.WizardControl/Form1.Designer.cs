
namespace iyibir.TMGD.WizardControl
{
    partial class Form1
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
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Form1layoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.fluentDesignFormContainer1item = new DevExpress.XtraLayout.LayoutControlItem();
            this.accordionControl1item = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl1item = new DevExpress.XtraLayout.LayoutControlGroup();
            this.wizardControl1item = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Form1layoutControl1ConvertedLayout)).BeginInit();
            this.Form1layoutControl1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormContainer1item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1item)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage1);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage1,
            this.completionWizardPage1});
            this.wizardControl1.Size = new System.Drawing.Size(754, 222);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(537, 90);
            // 
            // wizardPage1
            // 
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(722, 79);
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.Size = new System.Drawing.Size(537, 90);
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(263, 6);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(497, 222);
            this.fluentDesignFormContainer1.TabIndex = 2;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1});
            this.accordionControl1.Location = new System.Drawing.Point(6, 6);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(255, 222);
            this.accordionControl1.StyleController = this.Form1layoutControl1ConvertedLayout;
            this.accordionControl1.TabIndex = 3;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Element1";
            // 
            // Form1layoutControl1ConvertedLayout
            // 
            this.Form1layoutControl1ConvertedLayout.Controls.Add(this.fluentDesignFormContainer1);
            this.Form1layoutControl1ConvertedLayout.Controls.Add(this.accordionControl1);
            this.Form1layoutControl1ConvertedLayout.Controls.Add(this.wizardControl1);
            this.Form1layoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Form1layoutControl1ConvertedLayout.Location = new System.Drawing.Point(0, 0);
            this.Form1layoutControl1ConvertedLayout.Name = "Form1layoutControl1ConvertedLayout";
            this.Form1layoutControl1ConvertedLayout.Root = this.layoutControlGroup1;
            this.Form1layoutControl1ConvertedLayout.Size = new System.Drawing.Size(766, 458);
            this.Form1layoutControl1ConvertedLayout.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.fluentDesignFormContainer1item,
            this.accordionControl1item,
            this.groupControl1item});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(766, 458);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // fluentDesignFormContainer1item
            // 
            this.fluentDesignFormContainer1item.Control = this.fluentDesignFormContainer1;
            this.fluentDesignFormContainer1item.Location = new System.Drawing.Point(257, 0);
            this.fluentDesignFormContainer1item.Name = "fluentDesignFormContainer1item";
            this.fluentDesignFormContainer1item.Size = new System.Drawing.Size(499, 224);
            this.fluentDesignFormContainer1item.TextSize = new System.Drawing.Size(0, 0);
            this.fluentDesignFormContainer1item.TextVisible = false;
            // 
            // accordionControl1item
            // 
            this.accordionControl1item.Control = this.accordionControl1;
            this.accordionControl1item.Location = new System.Drawing.Point(0, 0);
            this.accordionControl1item.Name = "accordionControl1item";
            this.accordionControl1item.Size = new System.Drawing.Size(257, 224);
            this.accordionControl1item.TextSize = new System.Drawing.Size(0, 0);
            this.accordionControl1item.TextVisible = false;
            // 
            // groupControl1item
            // 
            this.groupControl1item.GroupBordersVisible = false;
            this.groupControl1item.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.wizardControl1item});
            this.groupControl1item.Location = new System.Drawing.Point(0, 224);
            this.groupControl1item.Name = "groupControl1item";
            this.groupControl1item.Size = new System.Drawing.Size(756, 224);
            this.groupControl1item.Text = "layoutControlGroup1";
            // 
            // wizardControl1item
            // 
            this.wizardControl1item.Control = this.wizardControl1;
            this.wizardControl1item.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1item.Name = "wizardControl1item";
            this.wizardControl1item.Size = new System.Drawing.Size(756, 224);
            this.wizardControl1item.TextSize = new System.Drawing.Size(0, 0);
            this.wizardControl1item.TextVisible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 458);
            this.Controls.Add(this.Form1layoutControl1ConvertedLayout);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Form1layoutControl1ConvertedLayout)).EndInit();
            this.Form1layoutControl1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormContainer1item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1item)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraLayout.LayoutControl Form1layoutControl1ConvertedLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem fluentDesignFormContainer1item;
        private DevExpress.XtraLayout.LayoutControlItem accordionControl1item;
        private DevExpress.XtraLayout.LayoutControlGroup groupControl1item;
        private DevExpress.XtraLayout.LayoutControlItem wizardControl1item;
    }
}

