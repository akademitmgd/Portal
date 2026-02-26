using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace iyibir.TMGD.Module.BusinessObjects;

[DefaultClassOptions]
[Persistent("Dispatch")]
[ImageName("BO_List")]
[DefaultProperty(nameof(FicheNo))]
[Appearance("Dispatch Delete", AppearanceItemType = "Action", TargetItems = "Delete", Visibility = ViewItemVisibility.Hide)]
[Appearance("Dispatch Edit", AppearanceItemType = "Action", TargetItems = "Edit", Visibility = ViewItemVisibility.Hide)]
[Appearance("Dispatch New", AppearanceItemType = "Action", TargetItems = "New", Visibility = ViewItemVisibility.Hide)]
[Appearance("Dispatch Save", AppearanceItemType = "Action", TargetItems = "Save", Visibility = ViewItemVisibility.Hide)]
[Appearance("Dispatch SaveAndClose", AppearanceItemType = "Action", TargetItems = "SaveAndClose", Visibility = ViewItemVisibility.Hide)]
[Appearance("Dispatch SaveAndNew", AppearanceItemType = "Action", TargetItems = "SaveAndNew", Visibility = ViewItemVisibility.Hide)]
[NavigationItem("DocumentManagement")]
public class Dispatch(Session session) : XPLiteObject(session)
{
    private int _referenceId;
    private string _ficheNo;
    private DateTime _createdOn;
    private string _docode;
    private string _clientCode;
    private string _clientName;
    private string _shipperCode;
    private string _vehiclePlate1;
    private string _vehiclePlate2;
    private string _driverTCKN1;
    private string _driverTCKN2;
    private string _driverPlate;

    [Browsable(false), Key, Persistent]
    public int ReferenceId { get => _referenceId; set => SetPropertyValue(nameof(ReferenceId), ref _referenceId, value); }

    [ModelDefault("AllowEdit", "False"),XafDisplayName("İrsaliye Numarası")]
    public string FicheNo { get => _ficheNo; set => SetPropertyValue(nameof(FicheNo), ref _ficheNo, value); }

    [ModelDefault("AllowEdit", "False"), XafDisplayName("İrsaliye Tarihi")]
    public DateTime CreatedOn { get => _createdOn; set => SetPropertyValue(nameof(CreatedOn), ref _createdOn, value); }

    [ModelDefault("AllowEdit", "False"), XafDisplayName("Belge Numarası")]
    public string Docode { get => _docode; set => SetPropertyValue(nameof(Docode), ref _docode, value); }

    [ModelDefault("AllowEdit", "False"), XafDisplayName("Müşteri Kodu")]
    public string ClientCode { get => _clientCode; set => SetPropertyValue(nameof(ClientCode), ref _clientCode, value); }

    [ModelDefault("AllowEdit", "False"), XafDisplayName("Müşteri Adı")]
    public string ClientName { get => _clientName; set => SetPropertyValue(nameof(ClientName), ref _clientName, value); }

    [ModelDefault("AllowEdit", "False"), XafDisplayName("Taşıyıcı Kodu")]
    public string ShipperCode { get => _shipperCode; set => SetPropertyValue(nameof(ShipperCode), ref _shipperCode, value); }

    [ModelDefault("AllowEdit", "False"), XafDisplayName("Araç Plaka 1")]
    public string VehiclePlate1 { get => _vehiclePlate1; set => SetPropertyValue(nameof(VehiclePlate1), ref _vehiclePlate1, value); }

    [ModelDefault("AllowEdit", "False"), XafDisplayName("Araç Plaka 2")]
    public string VehiclePlate2 { get => _vehiclePlate2; set => SetPropertyValue(nameof(VehiclePlate2), ref _vehiclePlate2, value); }

    [ModelDefault("AllowEdit", "False"), XafDisplayName("Sürücü TCKN 1")]
    public string DriverTCKN1 { get => _driverTCKN1; set => SetPropertyValue(nameof(DriverTCKN1), ref _driverTCKN1, value); }

    [ModelDefault("AllowEdit", "False"), XafDisplayName("Sürücü TCKN 2")]
    public string DriverTCKN2 { get => _driverTCKN2; set => SetPropertyValue(nameof(DriverTCKN2), ref _driverTCKN2, value); }

    [ModelDefault("AllowEdit", "False"), XafDisplayName("Sürücü Plaka")]
    public string DriverPlate { get => _driverPlate; set => SetPropertyValue(nameof(DriverPlate), ref _driverPlate, value); }

    [Association("Dispatch-Lines"), DevExpress.Xpo.Aggregated]
    public XPCollection<DispatchLine> Lines => GetCollection<DispatchLine>(nameof(Lines));
}
