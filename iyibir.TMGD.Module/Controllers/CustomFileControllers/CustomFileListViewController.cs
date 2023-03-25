using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using iyibir.TMGD.Module.BusinessObjects;
using iyibir.TMGD.Module.NonPersistentObjects;

namespace iyibir.TMGD.Module.Controllers.CustomFileControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CustomFileListViewController : ViewController
    {
        public CustomFileListViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void createCustomFile_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace(typeof(NP_CustomFile));

            NP_CustomFile newFile = os.CreateObject<NP_CustomFile>();


            DetailView detailView = Application.CreateDetailView(os, newFile);
            detailView.ViewEditMode = ViewEditMode.Edit;

            e.View = detailView;
            e.DialogController.AcceptAction.Execute += NewFile_AcceptAction_Execute;
        }

        private void NewFile_AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            NP_CustomFile newFile = e.CurrentObject as NP_CustomFile;
            CustomFile selectedFile = View.CurrentObject as CustomFile;

            if (selectedFile != null)
            {
                IObjectSpace os = Application.CreateObjectSpace();

                CustomFile file = os.CreateObject<CustomFile>();
                file.ParentFile = os.GetObjectByKey<CustomFile>(selectedFile.Oid);
                file.Name = newFile.FileName;

                os.CommitChanges();
                View.RefreshDataSource();
                View.Refresh();
            }
            else
            {
                IObjectSpace os = Application.CreateObjectSpace();

                CustomFile file = os.CreateObject<CustomFile>();
                file.Name = newFile.FileName;

                os.CommitChanges();
                View.RefreshDataSource();
                View.Refresh();
            }
        }
    }
}
