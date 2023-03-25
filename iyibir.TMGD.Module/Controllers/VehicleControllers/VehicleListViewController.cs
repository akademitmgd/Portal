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

namespace iyibir.TMGD.Module.Controllers.VehicleControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class VehicleListViewController : ViewController
    {
        public VehicleListViewController()
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
        private void vehicleInspectionQuestioning_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Vehicle vehicle = View.CurrentObject as Vehicle;
            if (vehicle != null)
            {
                Employee employee = SecuritySystem.CurrentUser as Employee;
                if (employee != null)
                {
                    if (employee.EmployeeType == EmployeeType.Customer)
                    {
                        Customer customer = employee.Customer;
                        if (customer != null)
                        {
                            if (!string.IsNullOrEmpty(customer.UETDSUsername) && !string.IsNullOrEmpty(customer.UETDSPassword))
                            {
                                UetdsService.uetdsMuayeneSorguSonuc sonuc = new UETDSHelper.UETDSHelper(customer.UETDSUsername, customer.UETDSPassword).AracMuayeneBilgileri(vehicle.Plate);
                                if (sonuc != null)
                                {
                                    if (sonuc.sonucKodu == 0)
                                    {
                                        vehicle.InspectionValidityDate = sonuc.muayeneGecerlilikTarihi;

                                        View.ObjectSpace.SetModified(vehicle);
                                        View.ObjectSpace.CommitChanges();
                                        View.RefreshDataSource();
                                        View.Refresh();
                                    }
                                    else
                                    {
                                        throw new UserFriendlyException(sonuc.sonucMesaji);
                                    }
                                }
                                else
                                {
                                    throw new UserFriendlyException("Servis yanıtı bulunamadı..");
                                }
                            }
                            else
                                throw new UserFriendlyException("U-ETDS Kullanıcı Giriş Bilgileri Bulunamadı.. Lütfen Kontrol Ediniz..");

                        }
                        else
                            throw new UserFriendlyException("Kayıtlı Müşteri Bilgisi Bulunamadı.. Lütfen Kontrol Ediniz..");
                    }
                    else
                        throw new UserFriendlyException("Müşteri Türünde Olmayan Kullanıcılar İşlem Yapma Yetkisine Sahip Değildir..");
                }
            }
            else
            {
                throw new UserFriendlyException("Seçili öge bulunamadı..");
            }
        }
        private void documentValidityQuestioning_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Vehicle vehicle = View.CurrentObject as Vehicle;
            if (vehicle != null)
            {
                Employee employee = SecuritySystem.CurrentUser as Employee;
                if (employee != null)
                {
                    if (employee.EmployeeType == EmployeeType.Customer)
                    {
                        Customer customer = employee.Customer;
                        if (customer != null)
                        {
                            if (!string.IsNullOrEmpty(customer.UETDSUsername) && !string.IsNullOrEmpty(customer.UETDSPassword))
                            {
                                UetdsService.uetdsFirmaSonuc sonuc = new UETDSHelper.UETDSHelper(customer.UETDSUsername,customer.UETDSPassword).YetkiBelgesiKontrol(vehicle.Plate);
                                if (sonuc != null)
                                {
                                    if (sonuc.sonucKodu == 0)
                                    {
                                        vehicle.DocumentNumber = sonuc.belgeNo;
                                        vehicle.DocumentType = sonuc.belgeTuru;
                                        vehicle.DocumentValidityDate = sonuc.belgeGecerlilikTarihi;

                                        View.ObjectSpace.SetModified(vehicle);
                                        View.ObjectSpace.CommitChanges();
                                        View.RefreshDataSource();
                                        View.Refresh();
                                    }
                                    else
                                    {
                                        throw new UserFriendlyException(sonuc.sonucMesaji);
                                    }
                                }
                                else
                                {
                                    throw new UserFriendlyException("Servis yanıtı bulunamadı..");
                                }
                            }
                            else
                                throw new UserFriendlyException("U-ETDS Kullanıcı Giriş Bilgileri Bulunamadı.. Lütfen Kontrol Ediniz..");

                        }
                        else
                            throw new UserFriendlyException("Kayıtlı Müşteri Bilgisi Bulunamadı.. Lütfen Kontrol Ediniz..");
                    }
                    else
                        throw new UserFriendlyException("Müşteri Türünde Olmayan Kullanıcılar İşlem Yapma Yetkisine Sahip Değildir..");
                }
            }
            else
            {
                throw new UserFriendlyException("Seçili öge bulunamadı..");
            }
        }
    }
}
