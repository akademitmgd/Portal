using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iyibir.TMGD.Module.BusinessObjects
{
    public enum LoadOfTheType
    {
        [XafDisplayName("Tehlikeli Madde")]
        Hazargoods = 0,
        [XafDisplayName("Normal Yük")]
        Normal = 1
    }
   public enum VehicleType
    {
        [XafDisplayName("Çekici")]
        Cekici = 0,

        [XafDisplayName("Dorse")]
        Dorse = 1,

        [XafDisplayName("Kırkayak")]
        Kirkayak = 2,

        [XafDisplayName("Kamyonet")]
        Kamyonet = 3,
    }
    public enum MixedLoadingType
    {
        [XafDisplayName("Yüklenebilir"), ImageName("Action_Grant")]
        Allow = 0,

        [XafDisplayName("Yüklenemez"), ImageName("Action_Deny")]
        Denied = 1
    }
    public enum CASType
    {
        [XafDisplayName("Yasaklı Değil"), ImageName("Action_Grant")]
        YasakliDegil = 0,

        [XafDisplayName("Yasaklı"), ImageName("Action_Deny")]
        Yasakli = 1
    }
    public enum ProductGroupType
    {
        [XafDisplayName("Tehlikeli Madde")]
        Product = 0,

        [XafDisplayName("Atık Ürün")]
        Waste = 1
    }
    public enum ProductType
    {
        [XafDisplayName("Alış")]
        Alim = 0,

        [XafDisplayName("Satış")]
        Satim = 1,

        [XafDisplayName("Alış+Satış")]
        AlimSatim = 2
    }
    public enum HazardousGoodsTransactionType
    {
        [XafDisplayName("Çıkış Hareketi")]
        Sales = 0,

        [XafDisplayName("Giriş Hareketi")]
        Purchase = 1
    }
    public enum VoyageNotificationTransactionCancelledType
    {
        [XafDisplayName("Seçiniz..")]
        NA = 0,

        [XafDisplayName("Kendi İsteğim ile İptal")]
        KendiIstegimIleIptal = 1,

        [XafDisplayName("Arıza Nedeni ile İptal")]
        ArizaNedeniIleIptal = 2
    }
    public enum VoyageNotificationTransactionStatus
    {
        [XafDisplayName("Bekliyor")]
        Waiting = 0,

        [XafDisplayName("Gönderildi")]
        Sent = 1,

        [XafDisplayName("İptal Edildi")]
        Cancelled = 2,

        [XafDisplayName("Aktif Edildi")]
        Activated = 3,

        [XafDisplayName("Güncellendi")]
        Updated = 4
    }
    public enum HazardousUnit
    {
        [XafDisplayName("Seçiniz..")]
        NA = 0,

        [XafDisplayName("Miligram")]
        MG = 1,

        [XafDisplayName("Litre")]
        L = 2,

        [XafDisplayName("KG")]
        KG = 3
    }

    public enum OtherUnit
    {
        [XafDisplayName("Seçiniz..")]
        NA = 0,

        [XafDisplayName("Adet")]
        AD = 1,

        [XafDisplayName("Paket/Koli")]
        PK = 2,

        [XafDisplayName("KG")]
        KG = 3,

        [XafDisplayName("Ton")]
        TON = 4,

    }
    public enum HazardousExemptionType
    {
        [XafDisplayName("Seçiniz..")]
        NA = 0,

        [XafDisplayName("Muafiyet Yok")]
        No = 1,

        [XafDisplayName("3.3")]
        ThreeDotThree = 33,

        [XafDisplayName("3.4")]
        ThreeDotFour = 34,

        [XafDisplayName("3.5")]
        ThreeDotFive = 35,

        [XafDisplayName("1.1.3.6")]
        OneDotOneDotThreeDotSix = 1136

    }
    public enum HazardousTransportType
    {
        [XafDisplayName("Seçiniz..")]
        NA = 0,

        [XafDisplayName("Paket")]
        Package = 1,

        [XafDisplayName("Tank")]
        Tank = 2,

        [XafDisplayName("Dökme")]
        Bulk = 3
    }
    public enum TransportTypeCode
    {
        [XafDisplayName("Seçiniz..")]
        NA = 0,

        [XafDisplayName("Tehlikeli Madde")]
        Hazardous = 1,

        [XafDisplayName("Normal Yük(Tehlikeli Madde Harici)")]
        Normal = 2
    }
    public enum VoyageNotificationStatus
    {
        [XafDisplayName("Bekliyor")]
        [ImageName("State_Task_NotStarted")]
        Waiting = 0,

        [XafDisplayName("Gönderildi")]
        [ImageName("Action_Grant")]
        Sent = 1,

        [XafDisplayName("İptal Edildi")]
        [ImageName("Action_Deny")]
        Cancelled = 2,

        [XafDisplayName("Aktif Edildi")]
        [ImageName("State_Task_Completed")]
        Activated = 3,

        [XafDisplayName("Güncellendi")]
        [ImageName("State_Task_WaitingForSomeoneElse")]
        Updated = 4
    }
    public enum EmployeeType
    {
        Employee = 0,
        Customer = 1
    }
    public enum WasteInventoryADRStatus
    {
        [XafDisplayName("ADR Kapsamında")]
        ADRKapsaminda = 0,
        [XafDisplayName("ADR Kapsamında Değil")]
        ADRKapsamindaDegil = 1
    }

    public enum TransportDocumentStatus
    {
        [XafDisplayName("Bekliyor")]
        Waiting = 0,

        [XafDisplayName("Gönderildi")]
        Send = 1
    }
    public enum TransportDocumentType
    {
        Product = 0,
        Waste = 1
    }
    public enum ConsigneeType
    {
        [XafDisplayName("Müşteri")]
        Customer = 0,

        [XafDisplayName("Tedarikçi")]
        Supplier = 1,

        [XafDisplayName("Atık Firması")]
        WasteCompany = 2,

        [XafDisplayName("Taşıyıcı")]
        Shipper = 3
    }
    public enum CustomerInventoryMSDSStatus
    {
        Guncel = 0,
        GuncelDegil = 1
    }
    public enum WasteListType
    {
        NA = 0,
        M = 1,
        A = 2
    }

    public enum AnnualWorkPlanSubjectStatus
    {
        [XafDisplayName("Planlandı")]
        Planning = 0,

        [XafDisplayName("Yapıldı")]
        Completed = 1,

        [XafDisplayName("Beklemede")]
        Waiting = 2,

        [XafDisplayName("Çalışıyor")]
        InProgress = 3,

        [XafDisplayName("Ertelendi")]
        Deferred = 4,

        [XafDisplayName("İptal Edildi")]
        Canceled = 5
    }
    public enum QuoteCustomerType
    {
        Lead = 0,
        Customer = 1
    }
    public enum TypeOfFailureMOC
    {
        Loss = 0,
        Fire = 1,
        Explosion = 2,
        StructuralFailure = 3
    }
    public enum MeansOfContainment
    {
        [XafDisplayName("Ambalaj")]
        Packaging = 0,

        [XafDisplayName("IBC")]
        IBC = 1,

        [XafDisplayName("Büyük Ambalaj")]
        LargePackaging = 2,

        [XafDisplayName("Küçük Konteyner")]
        SmallContainer = 3,

        [XafDisplayName("Vagon")]
        Wagon = 4,

        [XafDisplayName("Araç")]
        Vehicle = 5,

        [XafDisplayName("Tank Vagonu")]
        TankWagon = 6,

        [XafDisplayName("Tanker")]
        TankVehicle = 7,

        [XafDisplayName("Akülü Vagon")]
        BatteryWagon = 8,

        [XafDisplayName("Tüplü Gaz Tankeri")]
        BatteryVehicle = 9,

        [XafDisplayName("Sökülebilir Tankları Olan Vagon")]
        WagonWithDemountableTanks = 10,

        [XafDisplayName("Sökülebilir Tank")]
        DemountableTank = 11,

        [XafDisplayName("Büyük Konteyner")]
        LargeContainer = 12,

        [XafDisplayName("Tank Konteyner")]
        TankContainer = 13,

        [XafDisplayName("MEGC")]
        MEGC = 14,

        [XafDisplayName("Portatif Tank")]
        PortableTank = 15

    }
    public enum ReportOnOccurrenceMLocation
    {
        Rail = 0,
        RoadVehicle = 1,
    }
    public enum ReportOnOccurrenceMode
    {
        RailWagonNumber = 0,
        RoadVehicleRegistration = 1,
    }
    public enum AnnualWorkPlanStatus
    {
        Completed = 0,
        Waiting = 1,
        InProgress = 2,
        Canceled = 3,
    }
    public enum Months
    {
        [XafDisplayName("Ocak")]
        January = 0,

        [XafDisplayName("Şubat")]
        February = 1,

        [XafDisplayName("Mart")]
        March = 2,

        [XafDisplayName("Nisan")]
        April = 3,

        [XafDisplayName("Mayıs")]
        May = 4,

        [XafDisplayName("Haziran")]
        June = 5,

        [XafDisplayName("Temmuz")]
        July = 6,

        [XafDisplayName("Ağustos")]
        August = 7,

        [XafDisplayName("Eylül")]
        September = 8,

        [XafDisplayName("Ekim")]
        October = 9,

        [XafDisplayName("Kasım")]
        November = 10,

        [XafDisplayName("Aralık")]
        December = 11
    }
    public enum VehicleControlOption
    {
        [XafDisplayName("Ambalajlı")]
        Packaged = 0,

        [XafDisplayName("Tanker")]
        Tanker = 1,

        [XafDisplayName("Sınırlı Miktar")]
        LimitedQuantity = 2,

        [XafDisplayName("İstisnai Miktar")]
        ExceptionalQuantity = 3
    }
    public enum NotePriority
    {
        [ImageName("State_Validation_Warning")]
        Critic = 0,
        [ImageName("State_Priority_High")]
        High = 1,
        [ImageName("State_Priority_Normal")]
        Medium = 2,
        [ImageName("State_Priority_Low")]
        Low = 3
    }

    public enum ContractStatus
    {
        SignatureState = 0,
        IsValid = 1,
        Abrogated = 2,
        Terminated = 3,
    }

    public enum BillingFrequency
    {
        Yearly = 0,
        Monthly = 1,
        Weekly = 2,
        Daily = 3,
        Other = 4
    }
}
