using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    [DefaultProperty("Code")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class HazardousGoods : BaseObject
    {
        private string _code;
        private string _name;
        private string _unId;
        private int _convFactor;
        public HazardousGoods(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        public string Code { get => _code; set => SetPropertyValue(nameof(Code), ref _code, value); }

        [Size(250)]
        public string Name { get => _name; set => SetPropertyValue(nameof(Name), ref _name, value); }

        [VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 350, DetailViewImageEditorFixedWidth = 350)]
        public byte[] Image
        {
            get { return GetPropertyValue<byte[]>(nameof(Image)); }
            set { SetPropertyValue<byte[]>(nameof(Image), value); }
        }

        [RuleRequiredField("RuleRequiredField for HazardousGoods.UNID", DefaultContexts.Save)]
        public string UNID { get=>_unId; set=>SetPropertyValue(nameof(UNID),ref _unId,value); }

        public int ConvFactor { get=> _convFactor; set=> SetPropertyValue(nameof(ConvFactor),ref _convFactor,value); }

        [NonPersistent]
        [VisibleInDetailView(false)]
        public string ClassValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in Classes)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-Classes")]
        public XPCollection<HazardousGoodsClass> Classes => GetCollection<HazardousGoodsClass>(nameof(Classes));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string ClassCodeValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in ClassCodes)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-ClassCodes")]
        public XPCollection<HazardousGoodsClassCode> ClassCodes => GetCollection<HazardousGoodsClassCode>(nameof(ClassCodes));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string PackingGroupValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in PackingGroups)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-PackingGroups")]
        public XPCollection<PackingGroup> PackingGroups => GetCollection<PackingGroup>(nameof(PackingGroups));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string LabelValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in Labels.OrderBy(x=> x.LineNumber).ToList())
                    {
                        values += string.Format("{0}, ", item.HazardousGoodsLabel.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-LabelTransactions")]
        public XPCollection<LabelTransaction> Labels => GetCollection<LabelTransaction>(nameof(Labels));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string SpecialProvisionValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in SpecialProvisions)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-SpecialProvisions")]
        public XPCollection<HazardousGoodsSpecialProvision> SpecialProvisions => GetCollection<HazardousGoodsSpecialProvision>(nameof(SpecialProvisions));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string LimitedQuantityValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in LimitedQuantities)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-LimitedQuantities")]
        public XPCollection<HazardousGoodsLimitedQuantity> LimitedQuantities => GetCollection<HazardousGoodsLimitedQuantity>(nameof(LimitedQuantities));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string LimitedExceptedValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in LimitedExcepted)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-LimitedExcepted")]
        public XPCollection<HazardousGoodsLimitedExcept> LimitedExcepted => GetCollection<HazardousGoodsLimitedExcept>(nameof(LimitedExcepted));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string PackingInstructionValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in PackingInstructions)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-PackingInstructions")]
        public XPCollection<HazardousGoodsPackingInstruction> PackingInstructions => GetCollection<HazardousGoodsPackingInstruction>(nameof(PackingInstructions));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string SpecialPackingProvisionValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in SpecialPackingProvisions)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-SpecialPackingProvisions")]
        public XPCollection<HazardousGoodsSpecialPackingProvision> SpecialPackingProvisions => GetCollection<HazardousGoodsSpecialPackingProvision>(nameof(SpecialPackingProvisions));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string MixedPackingProvisionValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in MixedPackingProvisions)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-MixedPackingProvisions")]
        public XPCollection<HazardousGoodsMixedPackingProvision> MixedPackingProvisions => GetCollection<HazardousGoodsMixedPackingProvision>(nameof(MixedPackingProvisions));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string PortableTankAndBulkContainerInstructionValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in PortableTankAndBulkContainerInstructions)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-PortableTankContainerInstructions")]
        public XPCollection<HazardousGoodsPortableTankContainerInstruction> PortableTankAndBulkContainerInstructions => GetCollection<HazardousGoodsPortableTankContainerInstruction>(nameof(PortableTankAndBulkContainerInstructions));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string PortableTankContainerAndBulkSpecialProvisionValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in PortableTankContainerAndBulkSpecialProvisions)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-PortableTankContainerSpecialProvisions")]
        public XPCollection<HazardousGoodsPortableTankContainerSpecialProvision> PortableTankContainerAndBulkSpecialProvisions => GetCollection<HazardousGoodsPortableTankContainerSpecialProvision>(nameof(PortableTankContainerAndBulkSpecialProvisions));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string ADRTankCodeValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in ADRTankCodes)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-ADRTankCodes")]
        public XPCollection<HazardousGoodsADRTankCode> ADRTankCodes => GetCollection<HazardousGoodsADRTankCode>(nameof(ADRTankCodes));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string ADRTankSpecialProvisionValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in ADRTankSpecialProvisions)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-ADRTankSpecialProvisions")]
        public XPCollection<HazardousGoodsADRTankSpecialProvision> ADRTankSpecialProvisions => GetCollection<HazardousGoodsADRTankSpecialProvision>(nameof(ADRTankSpecialProvisions));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string VehicleForTankCarriageValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in VehicleForTankCarriage)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-VehicleForTankCarriage")]
        public XPCollection<HazardousGoodsVehicleForTankCarriage> VehicleForTankCarriage => GetCollection<HazardousGoodsVehicleForTankCarriage>(nameof(VehicleForTankCarriage));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string TransportCategoryValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in TransportCategory)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-TransportCategory")]
        public XPCollection<HazardousGoodsTransportCategory> TransportCategory => GetCollection<HazardousGoodsTransportCategory>(nameof(TransportCategory));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string SpecialProvisionForCarriagePackageValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in SpecialProvisionForCarriagePackage)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-SpecialProvisionForCarriagePackage")]
        public XPCollection<HazardousGoodsSpecialProvisionForCarriagePackage> SpecialProvisionForCarriagePackage => GetCollection<HazardousGoodsSpecialProvisionForCarriagePackage>(nameof(SpecialProvisionForCarriagePackage));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string SpecialProvisionForCarriageBulkValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in SpecialProvisionForCarriageBulk)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-SpecialProvisionForCarriageBulk")]
        public XPCollection<HazardousGoodsSpecialProvisionForCarriageBulk> SpecialProvisionForCarriageBulk => GetCollection<HazardousGoodsSpecialProvisionForCarriageBulk>(nameof(SpecialProvisionForCarriageBulk));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string SpecialProvisionForCarriageLoadingUnloadingAndHandlingValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in SpecialProvisionForCarriageLoadingUnloadingAndHandling)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-SpecialProvisionForCarriageLUH")]
        public XPCollection<HazardousGoodsSpecialProvisionForCarriageLUH> SpecialProvisionForCarriageLoadingUnloadingAndHandling => GetCollection<HazardousGoodsSpecialProvisionForCarriageLUH>(nameof(SpecialProvisionForCarriageLoadingUnloadingAndHandling));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string SpecialProvisionForCarriageOperationValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in SpecialProvisionForCarriageOperation)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-SpecialProvisionForCarriageOperation")]
        public XPCollection<HazardousGoodsSpecialProvisionForCarriageOperation> SpecialProvisionForCarriageOperation => GetCollection<HazardousGoodsSpecialProvisionForCarriageOperation>(nameof(SpecialProvisionForCarriageOperation));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string HazardIdentificationNoValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in HazardIdentificationNo)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-HazardIdentification")]
        public XPCollection<HazardousGoodsHazardIdentification> HazardIdentificationNo => GetCollection<HazardousGoodsHazardIdentification>(nameof(HazardIdentificationNo));


        [NonPersistent]
        [VisibleInDetailView(false)]
        public string TunnelCodeValues
        {
            get
            {
                string values = string.Empty;
                if (!IsLoading && !IsSaving)
                {
                    foreach (var item in TunnelCodes)
                    {
                        values += string.Format("{0}, ", item.Code);
                    }
                }
                else
                    values = string.Empty;

                return values;
            }
        }

        [Association("HazardousGoods-TunnelCodes")]
        public XPCollection<HazardousGoodsTunnelCode> TunnelCodes => GetCollection<HazardousGoodsTunnelCode>(nameof(TunnelCodes));

    }
}