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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iyibir.TMGD.Module.Web.Controllers.CustomControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CustomWebShowStartupNavigationItemController : ViewController
    {
        public CustomWebShowStartupNavigationItemController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }

        //protected override void ShowStartupNavigationItem()
        //{
            //base.ShowStartupNavigationItem();
            //Prior to 18.1  
            //WebWindow.CurrentRequestPage.LoadComplete += (s, e) => {  
            //IObjectSpace os = Application.CreateObjectSpace(typeof(NP_DateControl));
            //IObjectSpace objectspace = Application.CreateObjectSpace();
            //Employee employee = SecuritySystem.CurrentUser as Employee;
            //if (employee.EmployeeType == EmployeeType.Customer)
            //{
            //    NP_DateControl dateControl = os.CreateObject<NP_DateControl>();
            //    DetailView dv = Application.CreateDetailView(os, dateControl, true);
            //    dv.ViewEditMode = ViewEditMode.View;

            //    #region Customer Control
            //    Customer customer = employee.Customer;
            //    if (customer.ActivityCertificateDate.AddMonths(-1) <= DateTime.Now.Date)
            //    {
            //        NP_DateControlList controlList = os.CreateObject<NP_DateControlList>();
            //        controlList.Date = customer.ActivityCertificateDate;
            //        controlList.Name = "TMFB Durumu";
            //        controlList.Description = "Geçerlilik Tarihi";

            //        dateControl.List.Add(controlList);
            //    }
            //    #endregion

            //    #region MSDS Control
            //    IList<Product> products = objectspace.GetObjects<Product>(CriteriaOperator.Parse("Customer.Oid = ?", employee.Customer.Oid));
            //    if (products.ToList().Exists(x => x.MSDSDateOfValidity.AddMonths(-1) <= DateTime.Now.Date))
            //    {
            //        foreach (Product product in products.ToList().Where(x => x.MSDSDateOfValidity.AddMonths(-1) <= DateTime.Now.Date))
            //        {
            //            NP_DateControlList controlList = os.CreateObject<NP_DateControlList>();
            //            controlList.Date = product.MSDSDateOfValidity;
            //            controlList.Name = "MSDS Durumu";
            //            controlList.Description = "Geçerlilik Tarihi";

            //            dateControl.List.Add(controlList);
            //        }
            //    }
            //    #endregion

            //    #region Vehicle Control
            //    IList<Vehicle> vehicles = objectspace.GetObjects<Vehicle>(CriteriaOperator.Parse("Customer.Oid = ?", employee.Customer.Oid));
            //    if (vehicles.ToList().Exists(x => x.InsurancePolicy.AddMonths(-1) <= DateTime.Now.Date))
            //    {
            //        foreach (Vehicle vehicle in vehicles.ToList().Where(x => x.InsurancePolicy.AddMonths(-1) <= DateTime.Now.Date))
            //        {
            //            NP_DateControlList controlList = os.CreateObject<NP_DateControlList>();
            //            controlList.Date = vehicle.InsurancePolicy;
            //            controlList.Name = string.Format("{0} Sigorta Poliçesi Durumu",vehicle.Plate);
            //            controlList.Description = "Geçerlilik Tarihi";

            //            dateControl.List.Add(controlList);
            //        }

            //        foreach (Vehicle vehicle in vehicles.ToList().Where(x => x.TmgdInsurancePolicy.AddMonths(-1) <= DateTime.Now.Date))
            //        {
            //            NP_DateControlList controlList = os.CreateObject<NP_DateControlList>();
            //            controlList.Date = vehicle.TmgdInsurancePolicy;
            //            controlList.Name = string.Format("{0} Tehlikeli Madde Mali Zorunluluk Sigorta Poliçesi Durumu",vehicle.Plate);
            //            controlList.Description = "Geçerlilik Tarihi";

            //            dateControl.List.Add(controlList);
            //        }
            //    }
            //    #endregion

            //    #region Driver Control
            //    IList<VehicleDriver> drivers = objectspace.GetObjects<VehicleDriver>(CriteriaOperator.Parse("Customer.Oid = ?", employee.Customer.Oid));
            //    if (drivers.ToList().Exists(x => x.SRCDateOfValidity.AddMonths(-1) <= DateTime.Now.Date))
            //    {
            //        foreach (VehicleDriver driver in drivers.ToList().Where(x => x.SRCDateOfValidity.AddMonths(-1) <= DateTime.Now.Date))
            //        {
            //            NP_DateControlList controlList = os.CreateObject<NP_DateControlList>();
            //            controlList.Date = driver.SRCDateOfValidity;
            //            controlList.Name = string.Format("{0} SRC 5 Durumu",driver.FullName);
            //            controlList.Description = "Geçerlilik Tarihi";

            //            dateControl.List.Add(controlList);
            //        }
            //    }
            //    #endregion


            //    Application.ShowViewStrategy.ShowViewInPopupWindow(dv);
            //}


            //};  
        //}

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
