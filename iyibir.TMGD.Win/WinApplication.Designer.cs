﻿namespace iyibir.TMGD.Win {
    partial class TMGDWindowsFormsApplication {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
            this.module2 = new DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule();
            this.module3 = new iyibir.TMGD.Module.TMGDModule();
            this.module4 = new iyibir.TMGD.Module.Win.TMGDWindowsFormsModule();
            this.auditTrailModule = new DevExpress.ExpressApp.AuditTrail.AuditTrailModule();
            this.objectsModule = new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule();
            this.chartModule = new DevExpress.ExpressApp.Chart.ChartModule();
            this.chartWindowsFormsModule = new DevExpress.ExpressApp.Chart.Win.ChartWindowsFormsModule();
            this.cloneObjectModule = new DevExpress.ExpressApp.CloneObject.CloneObjectModule();
            this.conditionalAppearanceModule = new DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule();
            this.dashboardsModule = new DevExpress.ExpressApp.Dashboards.DashboardsModule();
            this.dashboardsWindowsFormsModule = new DevExpress.ExpressApp.Dashboards.Win.DashboardsWindowsFormsModule();
            this.fileAttachmentsWindowsFormsModule = new DevExpress.ExpressApp.FileAttachments.Win.FileAttachmentsWindowsFormsModule();
            this.notificationsModule = new DevExpress.ExpressApp.Notifications.NotificationsModule();
            this.notificationsWindowsFormsModule = new DevExpress.ExpressApp.Notifications.Win.NotificationsWindowsFormsModule();
            this.pivotChartModuleBase = new DevExpress.ExpressApp.PivotChart.PivotChartModuleBase();
            this.pivotChartWindowsFormsModule = new DevExpress.ExpressApp.PivotChart.Win.PivotChartWindowsFormsModule();
            this.pivotGridModule = new DevExpress.ExpressApp.PivotGrid.PivotGridModule();
            this.pivotGridWindowsFormsModule = new DevExpress.ExpressApp.PivotGrid.Win.PivotGridWindowsFormsModule();
            this.reportsModuleV2 = new DevExpress.ExpressApp.ReportsV2.ReportsModuleV2();
            this.reportsWindowsFormsModuleV2 = new DevExpress.ExpressApp.ReportsV2.Win.ReportsWindowsFormsModuleV2();
            this.scriptRecorderModuleBase = new DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase();
            this.scriptRecorderWindowsFormsModule = new DevExpress.ExpressApp.ScriptRecorder.Win.ScriptRecorderWindowsFormsModule();
            this.treeListEditorsModuleBase = new DevExpress.ExpressApp.TreeListEditors.TreeListEditorsModuleBase();
            this.treeListEditorsWindowsFormsModule = new DevExpress.ExpressApp.TreeListEditors.Win.TreeListEditorsWindowsFormsModule();
            this.validationModule = new DevExpress.ExpressApp.Validation.ValidationModule();
            this.validationWindowsFormsModule = new DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule();
            this.securityModule1 = new DevExpress.ExpressApp.Security.SecurityModule();
            this.schedulerModuleBase1 = new DevExpress.ExpressApp.Scheduler.SchedulerModuleBase();
            this.schedulerWindowsFormsModule1 = new DevExpress.ExpressApp.Scheduler.Win.SchedulerWindowsFormsModule();
            this.securityStrategyComplex1 = new DevExpress.ExpressApp.Security.SecurityStrategyComplex();
            this.authenticationStandard1 = new DevExpress.ExpressApp.Security.AuthenticationStandard();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // auditTrailModule
            // 
            this.auditTrailModule.AuditDataItemPersistentType = typeof(DevExpress.Persistent.BaseImpl.AuditDataItemPersistent);
            // 
            // cloneObjectModule
            // 
            this.cloneObjectModule.ClonerType = null;
            // 
            // dashboardsModule
            // 
            this.dashboardsModule.DashboardDataType = typeof(DevExpress.Persistent.BaseImpl.DashboardData);
            // 
            // dashboardsWindowsFormsModule
            // 
            this.dashboardsWindowsFormsModule.DesignerFormStyle = DevExpress.XtraBars.Ribbon.RibbonFormStyle.Ribbon;
            // 
            // notificationsModule
            // 
            this.notificationsModule.CanAccessPostponedItems = false;
            this.notificationsModule.NotificationsRefreshInterval = System.TimeSpan.Parse("00:05:00");
            this.notificationsModule.NotificationsStartDelay = System.TimeSpan.Parse("00:00:05");
            this.notificationsModule.ShowDismissAllAction = false;
            this.notificationsModule.ShowNotificationsWindow = true;
            this.notificationsModule.ShowRefreshAction = false;
            // 
            // pivotChartModuleBase
            // 
            this.pivotChartModuleBase.DataAccessMode = DevExpress.ExpressApp.CollectionSourceDataAccessMode.Client;
            this.pivotChartModuleBase.ShowAdditionalNavigation = false;
            // 
            // reportsModuleV2
            // 
            this.reportsModuleV2.EnableInplaceReports = true;
            this.reportsModuleV2.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.ReportDataV2);
            this.reportsModuleV2.ReportStoreMode = DevExpress.ExpressApp.ReportsV2.ReportStoreModes.XML;
            // 
            // validationModule
            // 
            this.validationModule.AllowValidationDetailsAccess = true;
            this.validationModule.IgnoreWarningAndInformationRules = false;
            // 
            // securityStrategyComplex1
            // 
            this.securityStrategyComplex1.AllowAnonymousAccess = false;
            this.securityStrategyComplex1.Authentication = this.authenticationStandard1;
            this.securityStrategyComplex1.PermissionsReloadMode = DevExpress.ExpressApp.Security.PermissionsReloadMode.NoCache;
            this.securityStrategyComplex1.RoleType = typeof(iyibir.TMGD.Module.BusinessObjects.EmployeeRole);
            this.securityStrategyComplex1.UserType = typeof(iyibir.TMGD.Module.BusinessObjects.Employee);
            // 
            // authenticationStandard1
            // 
            this.authenticationStandard1.LogonParametersType = typeof(DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters);
            // 
            // TMGDWindowsFormsApplication
            // 
            this.ApplicationName = "iyibir.TMGD";
            this.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
            this.Modules.Add(this.module1);
            this.Modules.Add(this.module2);
            this.Modules.Add(this.auditTrailModule);
            this.Modules.Add(this.objectsModule);
            this.Modules.Add(this.chartModule);
            this.Modules.Add(this.cloneObjectModule);
            this.Modules.Add(this.conditionalAppearanceModule);
            this.Modules.Add(this.dashboardsModule);
            this.Modules.Add(this.notificationsModule);
            this.Modules.Add(this.pivotChartModuleBase);
            this.Modules.Add(this.pivotGridModule);
            this.Modules.Add(this.reportsModuleV2);
            this.Modules.Add(this.scriptRecorderModuleBase);
            this.Modules.Add(this.treeListEditorsModuleBase);
            this.Modules.Add(this.validationModule);
            this.Modules.Add(this.securityModule1);
            this.Modules.Add(this.module3);
            this.Modules.Add(this.chartWindowsFormsModule);
            this.Modules.Add(this.dashboardsWindowsFormsModule);
            this.Modules.Add(this.fileAttachmentsWindowsFormsModule);
            this.Modules.Add(this.notificationsWindowsFormsModule);
            this.Modules.Add(this.pivotChartWindowsFormsModule);
            this.Modules.Add(this.pivotGridWindowsFormsModule);
            this.Modules.Add(this.reportsWindowsFormsModuleV2);
            this.Modules.Add(this.scriptRecorderWindowsFormsModule);
            this.Modules.Add(this.treeListEditorsWindowsFormsModule);
            this.Modules.Add(this.validationWindowsFormsModule);
            this.Modules.Add(this.schedulerModuleBase1);
            this.Modules.Add(this.schedulerWindowsFormsModule1);
            this.Modules.Add(this.module4);
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Localization.PreviewControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Localization.XafFilterUIElementResXLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.GridControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.LayoutControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.NavBarControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.BarControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.DocumentManagerControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.DockManagerLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.RichEditControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.TreeListControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.VerticalGridControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.XtraEditorsLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.LargeStringEditFindFormLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.MainFormTemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.DetailViewFormTemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.MainFormV2TemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.LightStyleMainFormTemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.DetailFormV2TemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.MainRibbonFormV2TemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.OutlookStyleMainRibbonFormTemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.LightStyleMainRibbonFormTemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.DetailRibbonFormV2TemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.NestedFrameTemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.NestedFrameTemplateV2Localizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.LookupControlTemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.PopupFormTemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.PivotChart.PivotGridLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.PivotChart.ChartLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.PivotChart.AnalysisControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.PivotGrid.PivotGridListEditorLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Security.ServerDataLogLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Dashboards.Win.DashboardControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.ReportsV2.Win.ReportControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Scheduler.SchedulerModuleBaseLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Scheduler.Win.SchedulerControlLocalizer));
            this.Security = this.securityStrategyComplex1;
            this.UseOldTemplates = false;
            this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.TMGDWindowsFormsApplication_DatabaseVersionMismatch);
            this.CustomizeLanguagesList += new System.EventHandler<DevExpress.ExpressApp.CustomizeLanguagesListEventArgs>(this.TMGDWindowsFormsApplication_CustomizeLanguagesList);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.ExpressApp.SystemModule.SystemModule module1;
        private DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule module2;
        private iyibir.TMGD.Module.TMGDModule module3;
        private iyibir.TMGD.Module.Win.TMGDWindowsFormsModule module4;
        private DevExpress.ExpressApp.AuditTrail.AuditTrailModule auditTrailModule;
        private DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule objectsModule;
        private DevExpress.ExpressApp.Chart.ChartModule chartModule;
        private DevExpress.ExpressApp.Chart.Win.ChartWindowsFormsModule chartWindowsFormsModule;
        private DevExpress.ExpressApp.CloneObject.CloneObjectModule cloneObjectModule;
        private DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule conditionalAppearanceModule;
        private DevExpress.ExpressApp.Dashboards.DashboardsModule dashboardsModule;
        private DevExpress.ExpressApp.Dashboards.Win.DashboardsWindowsFormsModule dashboardsWindowsFormsModule;
        private DevExpress.ExpressApp.FileAttachments.Win.FileAttachmentsWindowsFormsModule fileAttachmentsWindowsFormsModule;
        private DevExpress.ExpressApp.Notifications.NotificationsModule notificationsModule;
        private DevExpress.ExpressApp.Notifications.Win.NotificationsWindowsFormsModule notificationsWindowsFormsModule;
        private DevExpress.ExpressApp.PivotChart.PivotChartModuleBase pivotChartModuleBase;
        private DevExpress.ExpressApp.PivotChart.Win.PivotChartWindowsFormsModule pivotChartWindowsFormsModule;
        private DevExpress.ExpressApp.PivotGrid.PivotGridModule pivotGridModule;
        private DevExpress.ExpressApp.PivotGrid.Win.PivotGridWindowsFormsModule pivotGridWindowsFormsModule;
        private DevExpress.ExpressApp.ReportsV2.ReportsModuleV2 reportsModuleV2;
        private DevExpress.ExpressApp.ReportsV2.Win.ReportsWindowsFormsModuleV2 reportsWindowsFormsModuleV2;
        private DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase scriptRecorderModuleBase;
        private DevExpress.ExpressApp.ScriptRecorder.Win.ScriptRecorderWindowsFormsModule scriptRecorderWindowsFormsModule;
        private DevExpress.ExpressApp.TreeListEditors.TreeListEditorsModuleBase treeListEditorsModuleBase;
        private DevExpress.ExpressApp.TreeListEditors.Win.TreeListEditorsWindowsFormsModule treeListEditorsWindowsFormsModule;
        private DevExpress.ExpressApp.Validation.ValidationModule validationModule;
        private DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule validationWindowsFormsModule;
        private DevExpress.ExpressApp.Security.SecurityModule securityModule1;
        private DevExpress.ExpressApp.Scheduler.SchedulerModuleBase schedulerModuleBase1;
        private DevExpress.ExpressApp.Scheduler.Win.SchedulerWindowsFormsModule schedulerWindowsFormsModule1;
        private DevExpress.ExpressApp.Security.SecurityStrategyComplex securityStrategyComplex1;
        private DevExpress.ExpressApp.Security.AuthenticationStandard authenticationStandard1;
    }
}
