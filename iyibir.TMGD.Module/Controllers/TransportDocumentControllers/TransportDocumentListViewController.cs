using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
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

namespace iyibir.TMGD.Module.Controllers.TransportDocumentControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class TransportDocumentListViewController : ViewController
    {
        private SimpleAction CalcPoint;
        public TransportDocumentListViewController()
        {
            InitializeComponent();
            TargetObjectType = typeof(TransportDocument);

            #region Delete Substitution Vehicle
            CalcPoint = new SimpleAction(this, "CalcPoint", PredefinedCategory.View);
            CalcPoint.TypeOfView = typeof(TransportDocument);
            CalcPoint.TargetViewType = ViewType.ListView;
            CalcPoint.TargetObjectsCriteriaMode = TargetObjectsCriteriaMode.TrueForAll;
            CalcPoint.ImageName = "BO_Transition";
            CalcPoint.Execute += CalcPoint_Execute;
            #endregion

        }

        private void CalcPoint_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            var selectedItems = View.SelectedObjects;
            if (selectedItems.Count > 0)
            {
                double totalPoint = default;
                foreach ( TransportDocument item in selectedItems )
                    totalPoint += item.ScoreQuantity;

                if (totalPoint > 1000)
                {
                    Application.ShowViewStrategy.ShowMessage($"Toplam Puan : {totalPoint} -> 1.1.3.6 muafiyet kapsamında taşıyamaz.",InformationType.Error,6000);
                }
                else
                {
                    Application.ShowViewStrategy.ShowMessage($"Toplam Puan : {totalPoint} -> 1.1.3.6 muafiyet kapsamında taşıyabiir.", InformationType.Success, 6000);
                }
                
            }
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            new Helpers.Helper().FilterTransportDocumentDocument(View, SecuritySystem.CurrentUser as Employee);
            if (View is ListView)
            {
                this.Actions["showSeferDetay"].Active.SetItemValue("Hide", false);
                this.Actions["sendToUetdsSystem"].Active.SetItemValue("Hide", false);
                this.Actions["yeniSeferEkle"].Active.SetItemValue("Hide", false);
            }
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

        private void sendToUetdsSystem_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            #region OldCode
            UetdsService.uetdsEsyaParamIptalTuruSonuc sonuc = new UETDSHelper.UETDSHelper("", "").IptalTurleri();
            if (sonuc != null)
            {
                if (sonuc.sonucKodu == 0)
                {
                    List<UetdsService.paramIptalTurListesi> list = new List<UetdsService.paramIptalTurListesi>();

                    UetdsService.paramIptalTurListesi[] array = sonuc.iptalTuruListesi;

                    list = array.ToList();

                }
            }
            #endregion
        }

        private void yeniSeferEkle_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TransportDocument document = View.CurrentObject as TransportDocument;
            if (document != null)
            {
                IObjectSpace np_os = Application.CreateObjectSpace();
                NP_YeniSeferEkle seferEkle = np_os.CreateObject<NP_YeniSeferEkle>();

                DetailView detailView = Application.CreateDetailView(np_os, seferEkle);
                detailView.ViewEditMode = ViewEditMode.Edit;
                e.View = detailView;
                e.DialogController.AcceptAction.Execute += yeniSeferEkle_AcceptAction_Execute;
            }
            else
            {
                throw new UserFriendlyException("Seçili öge bulunamadı..");
            }
        }

        private void yeniSeferEkle_AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            #region OldCode
            //TransportDocument document = View.CurrentObject as TransportDocument;
            //if (document != null)
            //{
            //    NP_YeniSeferEkle seferEkle = e.CurrentObject as NP_YeniSeferEkle;
            //    if (seferEkle != null)
            //    {
            //        try
            //        {
            //            string baslangicSaati = string.Format("{0}:{1}", seferEkle.StartTime.Hours.ToString().PadLeft(2, '0'), seferEkle.StartTime.ToString().PadLeft(2, '0'));
            //            string baslangicTarihi = string.Format("{0}/{1}/{2}", seferEkle.StartDate.Day.ToString().PadLeft(2, '0'), seferEkle.StartDate.Month.ToString().PadLeft(2, '0'), seferEkle.StartDate.Year);

            //            string bitisSaati = string.Format("{0}:{1}", seferEkle.EndTime.Hours.ToString().PadLeft(2, '0'), seferEkle.EndTime.ToString().PadLeft(2, '0'));
            //            string bitisTarihi = string.Format("{0}/{1}/{2}", seferEkle.StartDate.Day.ToString().PadLeft(2, '0'), seferEkle.StartDate.Month.ToString().PadLeft(2, '0'), seferEkle.StartDate.Year);

            //            UetdsService.uetdsEsyaSeferEkleSonucV3 sonuc = new UETDSHelper.UETDSHelper().YeniSeferEkle(baslangicSaati, baslangicTarihi, bitisSaati, bitisTarihi, string.Empty, document.Vehicle.Plate, string.Empty, document.Driver.TCKN, string.Empty);
            //            if (sonuc.sonucKodu == 0)
            //            {
            //                using (TransactionScope scope = new TransactionScope())
            //                {
            //                    document.SeferId = Convert.ToInt32(sonuc.seferId);
            //                    document.Status = TransportDocumentStatus.Send;

            //                    View.ObjectSpace.SetModified(document);
            //                    View.ObjectSpace.CommitChanges();
            //                    View.RefreshDataSource();
            //                    View.Refresh();

            //                    scope.Complete();
            //                }
            //            }
            //            else
            //            {
            //                throw new UserFriendlyException(sonuc.sonucMesaji);
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            throw new UserFriendlyException(ex.Message);
            //        }
            //    }
            //    else
            //    {
            //        throw new UserFriendlyException("Sefer bilgileri ekranı bulunamadı..");
            //    }
            //}
            //else
            //{
            //    throw new UserFriendlyException("Seçili öge bulunamadı..");
            //} 
            #endregion
        }

        private void showSeferDetay_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            #region OldCOde
            //TransportDocument document = View.CurrentObject as TransportDocument;
            //if (document != null)
            //{
            //    IObjectSpace np_os = Application.CreateObjectSpace(typeof(NP_SeferDetay));
            //    NP_SeferDetay seferDetay = np_os.CreateObject<NP_SeferDetay>();

            //    UetdsService.uetdsEsyaSeferDetayiSonucV3 sonuc = new UETDSHelper.UETDSHelper().GetSeferDetayi(document.SeferId);
            //    if (sonuc != null)
            //    {
            //        if (sonuc.sonucKodu == 0)
            //        {
            //            seferDetay.BaslangicSaati = sonuc.seferDetayi.baslangicSaati;
            //            seferDetay.BaslangicTarihi = sonuc.seferDetayi.baslangicTarihi;
            //            seferDetay.BildirimTarihi = sonuc.seferDetayi.bildirimTarihi;
            //            seferDetay.BitisSaati = sonuc.seferDetayi.bitisSaati;
            //            seferDetay.BitisTarihi = sonuc.seferDetayi.bitisTarihi;
            //            seferDetay.Durum = sonuc.seferDetayi.durum;
            //            seferDetay.FirmaSeferNo = sonuc.seferDetayi.firmaSeferNo;
            //            seferDetay.IptalAciklama = sonuc.seferDetayi.iptalAciklama;
            //            seferDetay.IptalTarihi = sonuc.seferDetayi.iptalTarihi;
            //            seferDetay.IptalTurAciklama = sonuc.seferDetayi.iptalTurAciklama;
            //            seferDetay.IptalTurKodu = sonuc.seferDetayi.iptalTurKodu;
            //            seferDetay.Plaka1 = sonuc.seferDetayi.plaka1;
            //            seferDetay.Plaka2 = sonuc.seferDetayi.plaka2;
            //            seferDetay.Sofor1TCKNo = sonuc.seferDetayi.sofor1TCNo;
            //            seferDetay.Sofor2TCKNo = sonuc.seferDetayi.sofor2TCNo;
            //            seferDetay.SonGuncellemeTarihi = sonuc.seferDetayi.sonGuncellemeTarihi;

            //            //foreach (UetdsService.wsUetdsEsyaSeferYukListesi item in sonuc.yukListesi)
            //            //{
            //            //    item.
            //            //}
            //        }
            //        else
            //        {
            //            throw new UserFriendlyException(sonuc.sonucMesaji);
            //        }
            //    }
            //    else
            //    {
            //        throw new UserFriendlyException("Sonuç Bulunamadı..");
            //    }

            //    DetailView detail = Application.CreateDetailView(np_os, seferDetay);
            //    detail.ViewEditMode = ViewEditMode.View;
            //    e.View = detail;

            //}
            //else
            //{
            //    throw new UserFriendlyException("Seçili öge bulunamadı..");
            //} 
            #endregion
        }

        private void createNewVoyage_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TransportDocument document = View.CurrentObject as TransportDocument;
            if (document != null)
            {
                IObjectSpace os = Application.CreateObjectSpace();

                VoyageNotification voyageNotification = os.CreateObject<VoyageNotification>();
                voyageNotification.Driver1TCKN = document.Driver != null ? document.Driver.TCKN : string.Empty;
                voyageNotification.Plate1 = document.Vehicle != null ? document.Vehicle.Plate.Replace(" ", "") : string.Empty;
                voyageNotification.TransportDocument = os.GetObjectByKey<TransportDocument>(document.Oid);
                voyageNotification.StartDate = DateTime.Now;
                voyageNotification.StartTime = new TimeSpan(8, 0, 0);
                voyageNotification.EndDate = DateTime.Now;
                voyageNotification.EndTime = new TimeSpan(18, 0, 0);

                int count = 0;

                #region otherTransaction
                foreach (TransportDocumentOtherTransaction item in document.OtherTransactions)
                {
                    count++;

                    VoyageNotificationTransaction transaction = os.CreateObject<VoyageNotificationTransaction>();
                    transaction.ConsignerVKN = item.TransportDocument.ConsignerTaxNumber;
                    transaction.ConsignerTitle = item.TransportDocument.Consigner != null ? item.TransportDocument.Consigner.Title : string.Empty;
                    transaction.ConsignerCountryCode = item.TransportDocument.Consigner != null && item.TransportDocument.Consigner.Country != null ? item.TransportDocument.Consigner.Country.Code : string.Empty;
                    transaction.ConsignerCityMernisCode = item.TransportDocument.Consigner != null && item.TransportDocument.Consigner.City != null ? item.TransportDocument.Consigner.City.MernisCode : string.Empty;
                    transaction.ConsignerCountyMernisCode = item.TransportDocument.Consigner != null && item.TransportDocument.Consigner.County != null ? item.TransportDocument.Consigner.County.MernisCode : string.Empty;
                    transaction.ConsigneeVKN = item.TransportDocument.ConsigneeTaxNumber;
                    transaction.ConsigneeTitle = item.TransportDocument.Consignee != null ? item.TransportDocument.Consignee.Title : string.Empty;
                    transaction.ConsigneeCountryCode = item.TransportDocument.Consignee != null && item.TransportDocument.Consignee.Country != null ? item.TransportDocument.Consignee.Country.Code : string.Empty;
                    transaction.ConsigneeCityMernisCode = item.TransportDocument.Consignee != null && item.TransportDocument.Consignee.City != null ? item.TransportDocument.Consignee.City.MernisCode : string.Empty;
                    transaction.ConsigneeCountyMernisCode = item.TransportDocument.Consignee != null && item.TransportDocument.Consignee.County != null ? item.TransportDocument.Consignee.County.MernisCode : string.Empty;
                    transaction.LoadQuantity = item.Quantity;
                    transaction.UnId = item.HazardousGoods != null ? item.HazardousGoods.UNID : string.Empty;
                    transaction.OtherTransaction = os.GetObjectByKey<TransportDocumentOtherTransaction>(item.Oid);
                    transaction.LineNumber = count;
                    transaction.LoadQuantity = item.NetWeigth;
                    //transaction.LadingDate = DateTime.Now;
                    //transaction.LadingTime = new TimeSpan(8, 0, 0);
                    //transaction.PouringDate = DateTime.Now;
                    //transaction.PouringTime = new TimeSpan(18, 0, 0);
                    transaction.HazardousUnit = HazardousUnit.KG;


                    voyageNotification.Transactions.Add(transaction);
                }
                #endregion

                #region transaction
                foreach (TransportDocumentTransaction item in document.Transactions)
                {
                    count++;

                    VoyageNotificationTransaction transaction = os.CreateObject<VoyageNotificationTransaction>();
                    transaction.ConsignerVKN = item.TransportDocument.ConsignerTaxNumber;
                    transaction.ConsignerTitle = item.TransportDocument.Consigner != null ? item.TransportDocument.Consigner.Title : string.Empty;
                    transaction.ConsignerCountryCode = item.TransportDocument.Consigner != null && item.TransportDocument.Consigner.Country != null ? item.TransportDocument.Consigner.Country.Code : string.Empty;
                    transaction.ConsignerCityMernisCode = item.TransportDocument.Consigner != null && item.TransportDocument.Consigner.City != null ? item.TransportDocument.Consigner.City.MernisCode : string.Empty;
                    transaction.ConsignerCountyMernisCode = item.TransportDocument.Consigner != null && item.TransportDocument.Consigner.County != null ? item.TransportDocument.Consigner.County.MernisCode : string.Empty;
                    transaction.ConsigneeVKN = item.TransportDocument.ConsigneeTaxNumber;
                    transaction.ConsigneeTitle = item.TransportDocument.Consignee != null ? item.TransportDocument.Consignee.Title : string.Empty;
                    transaction.ConsigneeCountryCode = item.TransportDocument.Consignee != null && item.TransportDocument.Consignee.Country != null ? item.TransportDocument.Consignee.Country.Code : "TR";
                    transaction.ConsigneeCityMernisCode = item.TransportDocument.Consignee != null && item.TransportDocument.Consignee.City != null ? item.TransportDocument.Consignee.City.MernisCode : string.Empty;
                    transaction.ConsigneeCountyMernisCode = item.TransportDocument.Consignee != null && item.TransportDocument.Consignee.County != null ? item.TransportDocument.Consignee.County.MernisCode : string.Empty;
                    transaction.LoadQuantity = item.Quantity;
                    transaction.UnId = item.HazardousGoods != null ? item.HazardousGoods.UNID : string.Empty;
                    transaction.Transaction = os.GetObjectByKey<TransportDocumentTransaction>(item.Oid); 
                    transaction.LineNumber = count;
                    transaction.LoadQuantity = item.NetWeigth;
                    transaction.HazardousUnit = HazardousUnit.KG;

                    voyageNotification.Transactions.Add(transaction);
                }
                #endregion

                DetailView detailView = Application.CreateDetailView(os, voyageNotification);
                detailView.ViewEditMode = ViewEditMode.Edit;
                e.View = detailView;
                e.DialogController.AcceptAction.Execute += createNewVoyage_AcceptAction_Execute;
            }
            else
            {
                throw new UserFriendlyException("Seçili öge bulunamadı..");
            }
        }

        private void createNewVoyage_AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            //TransportDocument document = View.CurrentObject as TransportDocument;
            //if (document != null)
            //{
            //    //document.Status = TransportDocumentStatus.Send;

            //    //View.ObjectSpace.SetModified(document);
            //    //View.ObjectSpace.CommitChanges();
            //    //View.RefreshDataSource();
            //    //View.Refresh();
            //}
            //else
            //{
            //    throw new UserFriendlyException("Seçili öge bulunamadı..");
            //}
        }
    }
}
