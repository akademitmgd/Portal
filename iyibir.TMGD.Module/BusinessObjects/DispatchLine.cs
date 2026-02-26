using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace iyibir.TMGD.Module.BusinessObjects;

public class DispatchLine(Session session) : XPLiteObject(session)
{
    private Dispatch _dispatch;
    private int _referenceId;
    private string _itemCode;
    private string _itemName;
    private double _quantity;

    [Browsable(false), Key, Persistent]
    public int ReferenceId { get => _referenceId; set => SetPropertyValue(nameof(ReferenceId), ref _referenceId, value); }

    [ModelDefault("AllowEdit", "False"), XafDisplayName("Ürün Adı")]
    public string ItemName { get => _itemName; set => SetPropertyValue(nameof(ItemName), ref _itemName, value); }

    [ModelDefault("AllowEdit", "False"), XafDisplayName("Ürün Kodu")]
    public string ItemCode { get => _itemCode; set => SetPropertyValue(nameof(ItemCode), ref _itemCode, value); }

    [ModelDefault("AllowEdit", "False"), XafDisplayName("Miktar")]
    public double Quantity { get => _quantity; set => SetPropertyValue(nameof(Quantity), ref _quantity, value); }

    [Association("Dispatch-Lines")]
    public Dispatch Dispatch
    {
        get => _dispatch;
        set => SetPropertyValue(nameof(Dispatch), ref _dispatch, value);
    }

}
