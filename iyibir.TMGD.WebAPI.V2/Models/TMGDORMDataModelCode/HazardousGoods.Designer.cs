﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace iyibir.TMGD.WebAPI.V2.Models.iyibir_TMGD
{

    public partial class HazardousGoods : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        string fCode;
        public string Code
        {
            get { return fCode; }
            set { SetPropertyValue<string>(nameof(Code), ref fCode, value); }
        }
        string fName;
        public string Name
        {
            get { return fName; }
            set { SetPropertyValue<string>(nameof(Name), ref fName, value); }
        }
        HazardousGoodsClass fClass;
        [Association(@"HazardousGoodsReferencesHazardousGoodsClass")]
        public HazardousGoodsClass Class
        {
            get { return fClass; }
            set { SetPropertyValue<HazardousGoodsClass>(nameof(Class), ref fClass, value); }
        }
        HazardousGoodsClassCode fClassCode;
        [Association(@"HazardousGoodsReferencesHazardousGoodsClassCode")]
        public HazardousGoodsClassCode ClassCode
        {
            get { return fClassCode; }
            set { SetPropertyValue<HazardousGoodsClassCode>(nameof(ClassCode), ref fClassCode, value); }
        }
        PackingGroup fPackingGroup;
        [Association(@"HazardousGoodsReferencesPackingGroup")]
        public PackingGroup PackingGroup
        {
            get { return fPackingGroup; }
            set { SetPropertyValue<PackingGroup>(nameof(PackingGroup), ref fPackingGroup, value); }
        }
        HazardousGoodsLabel fLabel;
        [Association(@"HazardousGoodsReferencesHazardousGoodsLabel")]
        public HazardousGoodsLabel Label
        {
            get { return fLabel; }
            set { SetPropertyValue<HazardousGoodsLabel>(nameof(Label), ref fLabel, value); }
        }
        HazardousGoodsSpecialProvision fSpecialProvision;
        [Association(@"HazardousGoodsReferencesHazardousGoodsSpecialProvision")]
        public HazardousGoodsSpecialProvision SpecialProvision
        {
            get { return fSpecialProvision; }
            set { SetPropertyValue<HazardousGoodsSpecialProvision>(nameof(SpecialProvision), ref fSpecialProvision, value); }
        }
        byte[] fImage;
        [Size(SizeAttribute.Unlimited)]
        [MemberDesignTimeVisibility(true)]
        public byte[] Image
        {
            get { return fImage; }
            set { SetPropertyValue<byte[]>(nameof(Image), ref fImage, value); }
        }
        [Association(@"CustomerInventoryReferencesHazardousGoods")]
        public XPCollection<CustomerInventory> CustomerInventories { get { return GetCollection<CustomerInventory>(nameof(CustomerInventories)); } }
        [Association(@"CustomerWasteInventoryReferencesHazardousGoods")]
        public XPCollection<CustomerWasteInventory> CustomerWasteInventories { get { return GetCollection<CustomerWasteInventory>(nameof(CustomerWasteInventories)); } }
        [Association(@"DangerousGoodInvolvedReferencesHazardousGoods")]
        public XPCollection<DangerousGoodInvolved> DangerousGoodInvolveds { get { return GetCollection<DangerousGoodInvolved>(nameof(DangerousGoodInvolveds)); } }
        [Association(@"HazardousGoodsADRTankCodeReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsADRTankCode> HazardousGoodsADRTankCodes { get { return GetCollection<HazardousGoodsADRTankCode>(nameof(HazardousGoodsADRTankCodes)); } }
        [Association(@"HazardousGoodsADRTankSpecialProvisionReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsADRTankSpecialProvision> HazardousGoodsADRTankSpecialProvisions { get { return GetCollection<HazardousGoodsADRTankSpecialProvision>(nameof(HazardousGoodsADRTankSpecialProvisions)); } }
        [Association(@"HazardousGoodsClassReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsClass> HazardousGoodsClasses { get { return GetCollection<HazardousGoodsClass>(nameof(HazardousGoodsClasses)); } }
        [Association(@"HazardousGoodsClassCodeReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsClassCode> HazardousGoodsClassCodes { get { return GetCollection<HazardousGoodsClassCode>(nameof(HazardousGoodsClassCodes)); } }
        [Association(@"HazardousGoodsHazardIdentificationReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsHazardIdentification> HazardousGoodsHazardIdentifications { get { return GetCollection<HazardousGoodsHazardIdentification>(nameof(HazardousGoodsHazardIdentifications)); } }
        [Association(@"HazardousGoodsHazardousGoods_HazardousGoodsADRTankCodeADRTankCodesReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsHazardousGoods_HazardousGoodsADRTankCodeADRTankCodes> HazardousGoodsHazardousGoods_HazardousGoodsADRTankCodeADRTankCodess { get { return GetCollection<HazardousGoodsHazardousGoods_HazardousGoodsADRTankCodeADRTankCodes>(nameof(HazardousGoodsHazardousGoods_HazardousGoodsADRTankCodeADRTankCodess)); } }
        [Association(@"HazardousGoodsHazardousGoods_HazardousGoodsADRTankSpecialProvisionADRTankSpecialProvisionsReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsHazardousGoods_HazardousGoodsADRTankSpecialProvisionADRTankSpecialProvisions> HazardousGoodsHazardousGoods_HazardousGoodsADRTankSpecialProvisionADRTankSpecialProvisionss { get { return GetCollection<HazardousGoodsHazardousGoods_HazardousGoodsADRTankSpecialProvisionADRTankSpecialProvisions>(nameof(HazardousGoodsHazardousGoods_HazardousGoodsADRTankSpecialProvisionADRTankSpecialProvisionss)); } }
        [Association(@"HazardousGoodsHazardousGoods_HazardousGoodsClassClassesReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsHazardousGoods_HazardousGoodsClassClasses> HazardousGoodsHazardousGoods_HazardousGoodsClassClassess { get { return GetCollection<HazardousGoodsHazardousGoods_HazardousGoodsClassClasses>(nameof(HazardousGoodsHazardousGoods_HazardousGoodsClassClassess)); } }
        [Association(@"HazardousGoodsHazardousGoods_HazardousGoodsClassCodeClassCodesReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsHazardousGoods_HazardousGoodsClassCodeClassCodes> HazardousGoodsHazardousGoods_HazardousGoodsClassCodeClassCodess { get { return GetCollection<HazardousGoodsHazardousGoods_HazardousGoodsClassCodeClassCodes>(nameof(HazardousGoodsHazardousGoods_HazardousGoodsClassCodeClassCodess)); } }
        [Association(@"HazardousGoodsHazardousGoods_HazardousGoodsHazardIdentificationHazardIdentificationNoReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsHazardousGoods_HazardousGoodsHazardIdentificationHazardIdentificationNo> HazardousGoodsHazardousGoods_HazardousGoodsHazardIdentificationHazardIdentificationNos { get { return GetCollection<HazardousGoodsHazardousGoods_HazardousGoodsHazardIdentificationHazardIdentificationNo>(nameof(HazardousGoodsHazardousGoods_HazardousGoodsHazardIdentificationHazardIdentificationNos)); } }
        [Association(@"HazardousGoodsLabelReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsLabel> HazardousGoodsLabels { get { return GetCollection<HazardousGoodsLabel>(nameof(HazardousGoodsLabels)); } }
        [Association(@"HazardousGoodsLabelLabels_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsLabelLabels_HazardousGoodsHazardousGoods> HazardousGoodsLabelLabels_HazardousGoodsHazardousGoodss { get { return GetCollection<HazardousGoodsLabelLabels_HazardousGoodsHazardousGoods>(nameof(HazardousGoodsLabelLabels_HazardousGoodsHazardousGoodss)); } }
        [Association(@"HazardousGoodsLimitedExceptReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsLimitedExcept> HazardousGoodsLimitedExcepts { get { return GetCollection<HazardousGoodsLimitedExcept>(nameof(HazardousGoodsLimitedExcepts)); } }
        [Association(@"HazardousGoodsLimitedExceptLimitedExcepted_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsLimitedExceptLimitedExcepted_HazardousGoodsHazardousGoods> HazardousGoodsLimitedExceptLimitedExcepted_HazardousGoodsHazardousGoodss { get { return GetCollection<HazardousGoodsLimitedExceptLimitedExcepted_HazardousGoodsHazardousGoods>(nameof(HazardousGoodsLimitedExceptLimitedExcepted_HazardousGoodsHazardousGoodss)); } }
        [Association(@"HazardousGoodsLimitedQuantityReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsLimitedQuantity> HazardousGoodsLimitedQuantities { get { return GetCollection<HazardousGoodsLimitedQuantity>(nameof(HazardousGoodsLimitedQuantities)); } }
        [Association(@"HazardousGoodsLimitedQuantityLimitedQuantities_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsLimitedQuantityLimitedQuantities_HazardousGoodsHazardousGoods> HazardousGoodsLimitedQuantityLimitedQuantities_HazardousGoodsHazardousGoodss { get { return GetCollection<HazardousGoodsLimitedQuantityLimitedQuantities_HazardousGoodsHazardousGoods>(nameof(HazardousGoodsLimitedQuantityLimitedQuantities_HazardousGoodsHazardousGoodss)); } }
        [Association(@"HazardousGoodsMixedPackingProvisionReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsMixedPackingProvision> HazardousGoodsMixedPackingProvisions { get { return GetCollection<HazardousGoodsMixedPackingProvision>(nameof(HazardousGoodsMixedPackingProvisions)); } }
        [Association(@"HazardousGoodsMixedPackingProvisionMixedPackingProvisions_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsMixedPackingProvisionMixedPackingProvisions_HazardousGoodsHazardousGoods> HazardousGoodsMixedPackingProvisionMixedPackingProvisions_HazardousGoodsHazardousGoodss { get { return GetCollection<HazardousGoodsMixedPackingProvisionMixedPackingProvisions_HazardousGoodsHazardousGoods>(nameof(HazardousGoodsMixedPackingProvisionMixedPackingProvisions_HazardousGoodsHazardousGoodss)); } }
        [Association(@"HazardousGoodsPackingInstructionReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsPackingInstruction> HazardousGoodsPackingInstructions { get { return GetCollection<HazardousGoodsPackingInstruction>(nameof(HazardousGoodsPackingInstructions)); } }
        [Association(@"HazardousGoodsPackingInstructionPackingInstructions_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsPackingInstructionPackingInstructions_HazardousGoodsHazardousGoods> HazardousGoodsPackingInstructionPackingInstructions_HazardousGoodsHazardousGoodss { get { return GetCollection<HazardousGoodsPackingInstructionPackingInstructions_HazardousGoodsHazardousGoods>(nameof(HazardousGoodsPackingInstructionPackingInstructions_HazardousGoodsHazardousGoodss)); } }
        [Association(@"HazardousGoodsPortableTankContainerInstructionReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsPortableTankContainerInstruction> HazardousGoodsPortableTankContainerInstructions { get { return GetCollection<HazardousGoodsPortableTankContainerInstruction>(nameof(HazardousGoodsPortableTankContainerInstructions)); } }
        [Association(@"HazardousGoodsPortableTankContainerInstructionPortableTankAndBulkContainerInstructions_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsPortableTankContainerInstructionPortableTankAndBulkContainerInstructions_HazardousGoodsHazardousGoods> HazardousGoodsPortableTankContainerInstructionPortableTankAndBulkContainerInstructions_HazardousGoodsHazardousGoodss { get { return GetCollection<HazardousGoodsPortableTankContainerInstructionPortableTankAndBulkContainerInstructions_HazardousGoodsHazardousGoods>(nameof(HazardousGoodsPortableTankContainerInstructionPortableTankAndBulkContainerInstructions_HazardousGoodsHazardousGoodss)); } }
        [Association(@"HazardousGoodsPortableTankContainerSpecialProvisionReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsPortableTankContainerSpecialProvision> HazardousGoodsPortableTankContainerSpecialProvisions { get { return GetCollection<HazardousGoodsPortableTankContainerSpecialProvision>(nameof(HazardousGoodsPortableTankContainerSpecialProvisions)); } }
        [Association(@"HazardousGoodsPortableTankContainerSpecialProvisionPortableTankContainerAndBulkSpecialProvisions_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsPortableTankContainerSpecialProvisionPortableTankContainerAndBulkSpecialProvisions_HazardousGoodsHazardousGoods> HazardousGoodsPortableTankContainerSpecialProvisionPortableTankContainerAndBulkSpecialProvisions_HazardousGoodsHazardousGoodss { get { return GetCollection<HazardousGoodsPortableTankContainerSpecialProvisionPortableTankContainerAndBulkSpecialProvisions_HazardousGoodsHazardousGoods>(nameof(HazardousGoodsPortableTankContainerSpecialProvisionPortableTankContainerAndBulkSpecialProvisions_HazardousGoodsHazardousGoodss)); } }
        [Association(@"HazardousGoodsSpecialPackingProvisionReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsSpecialPackingProvision> HazardousGoodsSpecialPackingProvisions { get { return GetCollection<HazardousGoodsSpecialPackingProvision>(nameof(HazardousGoodsSpecialPackingProvisions)); } }
        [Association(@"HazardousGoodsSpecialPackingProvisionSpecialPackingProvisions_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsSpecialPackingProvisionSpecialPackingProvisions_HazardousGoodsHazardousGoods> HazardousGoodsSpecialPackingProvisionSpecialPackingProvisions_HazardousGoodsHazardousGoodss { get { return GetCollection<HazardousGoodsSpecialPackingProvisionSpecialPackingProvisions_HazardousGoodsHazardousGoods>(nameof(HazardousGoodsSpecialPackingProvisionSpecialPackingProvisions_HazardousGoodsHazardousGoodss)); } }
        [Association(@"HazardousGoodsSpecialProvisionReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsSpecialProvision> HazardousGoodsSpecialProvisions { get { return GetCollection<HazardousGoodsSpecialProvision>(nameof(HazardousGoodsSpecialProvisions)); } }
        [Association(@"HazardousGoodsSpecialProvisionForCarriageBulkReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsSpecialProvisionForCarriageBulk> HazardousGoodsSpecialProvisionForCarriageBulks { get { return GetCollection<HazardousGoodsSpecialProvisionForCarriageBulk>(nameof(HazardousGoodsSpecialProvisionForCarriageBulks)); } }
        [Association(@"HazardousGoodsSpecialProvisionForCarriageBulkSpecialProvisionForCarriageBulk_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsSpecialProvisionForCarriageBulkSpecialProvisionForCarriageBulk_HazardousGoodsHazardousGoods> HazardousGoodsSpecialProvisionForCarriageBulkSpecialProvisionForCarriageBulk_HazardousGoodsHazardousGoodss { get { return GetCollection<HazardousGoodsSpecialProvisionForCarriageBulkSpecialProvisionForCarriageBulk_HazardousGoodsHazardousGoods>(nameof(HazardousGoodsSpecialProvisionForCarriageBulkSpecialProvisionForCarriageBulk_HazardousGoodsHazardousGoodss)); } }
        [Association(@"HazardousGoodsSpecialProvisionForCarriageLUHReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsSpecialProvisionForCarriageLUH> HazardousGoodsSpecialProvisionForCarriageLUHs { get { return GetCollection<HazardousGoodsSpecialProvisionForCarriageLUH>(nameof(HazardousGoodsSpecialProvisionForCarriageLUHs)); } }
        [Association(@"HazardousGoodsSpecialProvisionForCarriageLUHSpecialProvisionForCarriageLoadingUnloadingAndHandling_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsSpecialProvisionForCarriageLUHSpecialProvisionForCarriageLoadingUnloadingAndHandling_HazardousGoodsHazardousGoods> HazardousGoodsSpecialProvisionForCarriageLUHSpecialProvisionForCarriageLoadingUnloadingAndHandling_HazardousGoodsHazardousGoodss { get { return GetCollection<HazardousGoodsSpecialProvisionForCarriageLUHSpecialProvisionForCarriageLoadingUnloadingAndHandling_HazardousGoodsHazardousGoods>(nameof(HazardousGoodsSpecialProvisionForCarriageLUHSpecialProvisionForCarriageLoadingUnloadingAndHandling_HazardousGoodsHazardousGoodss)); } }
        [Association(@"HazardousGoodsSpecialProvisionForCarriageOperationReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsSpecialProvisionForCarriageOperation> HazardousGoodsSpecialProvisionForCarriageOperations { get { return GetCollection<HazardousGoodsSpecialProvisionForCarriageOperation>(nameof(HazardousGoodsSpecialProvisionForCarriageOperations)); } }
        [Association(@"HazardousGoodsSpecialProvisionForCarriageOperationSpecialProvisionForCarriageOperation_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsSpecialProvisionForCarriageOperationSpecialProvisionForCarriageOperation_HazardousGoodsHazardousGoods> HazardousGoodsSpecialProvisionForCarriageOperationSpecialProvisionForCarriageOperation_HazardousGoodsHazardousGoodss { get { return GetCollection<HazardousGoodsSpecialProvisionForCarriageOperationSpecialProvisionForCarriageOperation_HazardousGoodsHazardousGoods>(nameof(HazardousGoodsSpecialProvisionForCarriageOperationSpecialProvisionForCarriageOperation_HazardousGoodsHazardousGoodss)); } }
        [Association(@"HazardousGoodsSpecialProvisionForCarriagePackageReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsSpecialProvisionForCarriagePackage> HazardousGoodsSpecialProvisionForCarriagePackages { get { return GetCollection<HazardousGoodsSpecialProvisionForCarriagePackage>(nameof(HazardousGoodsSpecialProvisionForCarriagePackages)); } }
        [Association(@"HazardousGoodsSpecialProvisionForCarriagePackageSpecialProvisionForCarriagePackage_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsSpecialProvisionForCarriagePackageSpecialProvisionForCarriagePackage_HazardousGoodsHazardousGoods> HazardousGoodsSpecialProvisionForCarriagePackageSpecialProvisionForCarriagePackage_HazardousGoodsHazardousGoodss { get { return GetCollection<HazardousGoodsSpecialProvisionForCarriagePackageSpecialProvisionForCarriagePackage_HazardousGoodsHazardousGoods>(nameof(HazardousGoodsSpecialProvisionForCarriagePackageSpecialProvisionForCarriagePackage_HazardousGoodsHazardousGoodss)); } }
        [Association(@"HazardousGoodsSpecialProvisionSpecialProvisions_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsSpecialProvisionSpecialProvisions_HazardousGoodsHazardousGoods> HazardousGoodsSpecialProvisionSpecialProvisions_HazardousGoodsHazardousGoodss { get { return GetCollection<HazardousGoodsSpecialProvisionSpecialProvisions_HazardousGoodsHazardousGoods>(nameof(HazardousGoodsSpecialProvisionSpecialProvisions_HazardousGoodsHazardousGoodss)); } }
        [Association(@"HazardousGoodsTransportCategoryReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsTransportCategory> HazardousGoodsTransportCategories { get { return GetCollection<HazardousGoodsTransportCategory>(nameof(HazardousGoodsTransportCategories)); } }
        [Association(@"HazardousGoodsTransportCategoryTransportCategory_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsTransportCategoryTransportCategory_HazardousGoodsHazardousGoods> HazardousGoodsTransportCategoryTransportCategory_HazardousGoodsHazardousGoodss { get { return GetCollection<HazardousGoodsTransportCategoryTransportCategory_HazardousGoodsHazardousGoods>(nameof(HazardousGoodsTransportCategoryTransportCategory_HazardousGoodsHazardousGoodss)); } }
        [Association(@"HazardousGoodsTunnelCodeReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsTunnelCode> HazardousGoodsTunnelCodes { get { return GetCollection<HazardousGoodsTunnelCode>(nameof(HazardousGoodsTunnelCodes)); } }
        [Association(@"HazardousGoodsTunnelCodeTunnelCodes_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsTunnelCodeTunnelCodes_HazardousGoodsHazardousGoods> HazardousGoodsTunnelCodeTunnelCodes_HazardousGoodsHazardousGoodss { get { return GetCollection<HazardousGoodsTunnelCodeTunnelCodes_HazardousGoodsHazardousGoods>(nameof(HazardousGoodsTunnelCodeTunnelCodes_HazardousGoodsHazardousGoodss)); } }
        [Association(@"HazardousGoodsVehicleForTankCarriageReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsVehicleForTankCarriage> HazardousGoodsVehicleForTankCarriages { get { return GetCollection<HazardousGoodsVehicleForTankCarriage>(nameof(HazardousGoodsVehicleForTankCarriages)); } }
        [Association(@"HazardousGoodsVehicleForTankCarriageVehicleForTankCarriage_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public XPCollection<HazardousGoodsVehicleForTankCarriageVehicleForTankCarriage_HazardousGoodsHazardousGoods> HazardousGoodsVehicleForTankCarriageVehicleForTankCarriage_HazardousGoodsHazardousGoodss { get { return GetCollection<HazardousGoodsVehicleForTankCarriageVehicleForTankCarriage_HazardousGoodsHazardousGoods>(nameof(HazardousGoodsVehicleForTankCarriageVehicleForTankCarriage_HazardousGoodsHazardousGoodss)); } }
        [Association(@"PackingGroupReferencesHazardousGoods")]
        public XPCollection<PackingGroup> PackingGroups { get { return GetCollection<PackingGroup>(nameof(PackingGroups)); } }
        [Association(@"PackingGroupPackingGroups_HazardousGoodsHazardousGoodsReferencesHazardousGoods")]
        public XPCollection<PackingGroupPackingGroups_HazardousGoodsHazardousGoods> PackingGroupPackingGroups_HazardousGoodsHazardousGoodss { get { return GetCollection<PackingGroupPackingGroups_HazardousGoodsHazardousGoods>(nameof(PackingGroupPackingGroups_HazardousGoodsHazardousGoodss)); } }
        [Association(@"TransportDocumentOtherTransactionReferencesHazardousGoods")]
        public XPCollection<TransportDocumentOtherTransaction> TransportDocumentOtherTransactions { get { return GetCollection<TransportDocumentOtherTransaction>(nameof(TransportDocumentOtherTransactions)); } }
        [Association(@"TransportDocumentTransactionReferencesHazardousGoods")]
        public XPCollection<TransportDocumentTransaction> TransportDocumentTransactions { get { return GetCollection<TransportDocumentTransaction>(nameof(TransportDocumentTransactions)); } }
    }

}
