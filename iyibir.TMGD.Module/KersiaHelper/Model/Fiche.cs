using System;
using System.Collections.Generic;

namespace iyibir.TMGD.Module.KersiaHelper.Model;

public class Fiche
{
    public int Logicalref { get; set; }
    public string Ficheno { get; set; } = string.Empty;
    public DateTime FicheDate { get; set; } = default;
    public DateTime DocDate { get; set; } = default;
    public DateTime ShipDate { get; set; } = default;
    public string ClientCode { get; set; } = string.Empty;
    public string POrderFicheNo { get; set; } = string.Empty;
    public int DivisionNo { get; set; } = default;
    public string DivisionName { get; set; } = string.Empty;
    public int WarehouseNo { get; set; } = default;
    public string WarehouseName { get; set; } = string.Empty;
    public int Einvoice { get; set; } = default;
    public int Edespatch { get; set; } = default;
    public string Genexp1 { get; set; } = string.Empty;
    public string RecvCode { get; set; } = string.Empty;
    public string RecvName { get; set; } = string.Empty;
    public string AccountCode { get; set; } = string.Empty;
    public string AccountName { get; set; } = string.Empty;
    public string ShipTypCod { get; set; } = string.Empty;
    public string ShipTypDef { get; set; } = string.Empty;
    public string ShipAgnCod { get; set; } = string.Empty;
    public string ShipAgnDef { get; set; } = string.Empty;
    public string ShipAgnAddress { get; set; } = string.Empty;
    public string DriverName1 { get; set; } = string.Empty;
    public string DriverSurname1 { get; set; } = string.Empty;
    public string DriverTckNo1 { get; set; } = string.Empty;
    public string DriverPlate { get; set; } = string.Empty;
    public string FicheTime { get; set; } = string.Empty;
    public string DocTime { get; set; } = string.Empty;
    public string ShipTime { get; set; } = string.Empty;
    public List<Transaction> Transactions { get; set; } = new();
}

public class Transaction
{
    public int Logicalref { get; set; }
    public string ItemCode { get; set; } = string.Empty;
    public string ItemName { get; set; } = string.Empty;
    public object VariantCode { get; set; } = string.Empty;
    public object VariantName { get; set; } = string.Empty;
    public int WarehouseNo { get; set; } = default;
    public string WarehouseName { get; set; } = string.Empty;
    public object DestWarehouseNo { get; set; } = default;
    public object DestWarehouseName { get; set; } = string.Empty;
    public string UnitCode { get; set; } = string.Empty;
    public double Amount { get; set; } = default;
    public double Uinfo1 { get; set; } = default;
    public double Uinfo2 { get; set; } = default;
    public string Specode { get; set; } = string.Empty;
    public int Iocode { get; set; } = default;
    public string Specode2 { get; set; } = string.Empty;
    public string LineExp { get; set; } = string.Empty;
    public List<LotTransaction> LotTransactions { get; set; } = new();
}

public class LotTransaction
{
    public string LotCode { get; set; } = string.Empty;
    public string LotName { get; set; } = string.Empty;
    public string LocationCode { get; set; } = string.Empty;
    public double Remamount { get; set; } = default;
    public double Remlnunitamnt { get; set; } = default;
    public double Uinfo1 { get; set; } = default;
    public double Uinfo2 { get; set; } = default;
    public int Iocode { get; set; } = default;
    public DateTime ExpDate { get; set; } = default;
}
