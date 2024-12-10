using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using iyibir.TMGD.Module.BusinessObjects;
using UETDS.Module;
using UETDSClient;

namespace iyibir.TMGD.Module.Controllers.VehicleControllers;

public partial class VehicleListViewController : ViewController
{
    public VehicleListViewController()
    {
        InitializeComponent();
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
                            var client = UETDSProvider.GetClient(customer.UETDSUsername, customer.UETDSPassword);

								aracMuayeneSorgulaRequest request = new aracMuayeneSorgulaRequest();
								request.plaka = vehicle.Plate;
								request.wsuser = UETDSProvider.GetWsUser(customer.UETDSUsername, customer.UETDSPassword);

								uetdsMuayeneSorguSonuc sonuc = UETDSProvider.aracMuayeneSorgula(client, request);

								//UetdsService.uetdsMuayeneSorguSonuc sonuc = new UETDSHelper.UETDSHelper(customer.UETDSUsername, customer.UETDSPassword).AracMuayeneBilgileri(vehicle.Plate);
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
                            var client = UETDSProvider.GetClient(customer.UETDSUsername, customer.UETDSPassword);

								yetkiBelgesiKontrolRequest request = new yetkiBelgesiKontrolRequest();
								request.plaka = vehicle.Plate;
                            request.wsuser = UETDSProvider.GetWsUser(customer.UETDSUsername, customer.UETDSPassword);

								uetdsFirmaSonuc sonuc = UETDSProvider.yetkiBelgesiKontrol(client, request);

								//UetdsService.uetdsFirmaSonuc sonuc = new UETDSHelper.UETDSHelper(customer.UETDSUsername,customer.UETDSPassword).YetkiBelgesiKontrol(vehicle.Plate);
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
