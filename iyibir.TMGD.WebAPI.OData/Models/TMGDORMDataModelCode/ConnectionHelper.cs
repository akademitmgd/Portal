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
using DevExpress.Xpo.DB;

namespace iyibir.TMGD.WebAPI.OData.Models.iyibir_TMGD
{
    public static class ConnectionHelper
    {
        static Type[] persistentTypes = new Type[] {
            typeof(Activity),
            typeof(ActivityLine),
            typeof(ActivityReport),
            typeof(ActivityReportTransaction),
            typeof(ActivitySubject),
            typeof(ActivitySubjectDesc),
            typeof(Analysis),
            typeof(Announcement),
            typeof(AnnouncementUser),
            typeof(AnnualWorkPlan),
            typeof(AnnualWorkPlanSubject),
            typeof(AnnualWorkPlanSubjectTransaction),
            typeof(AuditDataItemPersistent),
            typeof(AuditDeterminationForm),
            typeof(AuditDeterminationLegalStatute),
            typeof(AuditDeterminationLegalStatuteTransaction),
            typeof(AuditedObjectWeakReference),
            typeof(CASNumber),
            typeof(City),
            typeof(Company),
            typeof(Consignee),
            typeof(Contract),
            typeof(Country),
            typeof(County),
            typeof(Currency),
            typeof(CustomDocument),
            typeof(Customer),
            typeof(CustomerContact),
            typeof(CustomerDocument),
            typeof(CustomerInventory),
            typeof(CustomerWasteInventory),
            typeof(CustomFile),
            typeof(DangerousGoodInvolved),
            typeof(DashboardData),
            typeof(DefaultAnnualWorkPlan),
            typeof(DefaultDistributionOfTaskSubject),
            typeof(DefaultDistributionOfTaskSubjectDesc),
            typeof(DefaultLabel),
            typeof(DefaultLegalLegislation),
            typeof(DefaultTransportDescription),
            typeof(DefaultVehicleControlDocumentTransaction),
            typeof(DefaultVehicleDocumentControl),
            typeof(Department),
            typeof(DistributionOfTask),
            typeof(DistributionOfTaskSubject),
            typeof(DistributionOfTaskSubjectAuth),
            typeof(DistributionOfTaskSubjectDetail),
            typeof(DrillForm),
            typeof(DrillFormControlList),
            typeof(DrillType),
            typeof(DrillTypeControlList),
            typeof(Education),
            typeof(EMailSetting),
            typeof(Employee),
            typeof(EmployeeDocument),
            typeof(EmployeeEmployees_AnnouncementAnnouncements),
            typeof(EmployeeRole),
            typeof(EmployeeRoleEmployeeRoles_EmployeeEmployees),
            typeof(EstimatedQuantityOfLossOfProduct),
            typeof(FactoryDepartment),
            typeof(FileData),
            typeof(HazardousGoods),
            typeof(HazardousGoodsADRTankCode),
            typeof(HazardousGoodsADRTankSpecialProvision),
            typeof(HazardousGoodsCategory),
            typeof(HazardousGoodsClass),
            typeof(HazardousGoodsClassCode),
            typeof(HazardousGoodsHazardIdentification),
            typeof(HazardousGoodsHazardousGoods_HazardousGoodsADRTankCodeADRTankCodes),
            typeof(HazardousGoodsHazardousGoods_HazardousGoodsADRTankSpecialProvisionADRTankSpecialProvisions),
            typeof(HazardousGoodsHazardousGoods_HazardousGoodsClassClasses),
            typeof(HazardousGoodsHazardousGoods_HazardousGoodsClassCodeClassCodes),
            typeof(HazardousGoodsHazardousGoods_HazardousGoodsHazardIdentificationHazardIdentificationNo),
            typeof(HazardousGoodsLabel),
            typeof(HazardousGoodsLabelController),
            typeof(HazardousGoodsLabelEquipment),
            typeof(HazardousGoodsLabelLabels_HazardousGoodsHazardousGoods),
            typeof(HazardousGoodsLabelMixedLoading),
            typeof(HazardousGoodsLimitedExcept),
            typeof(HazardousGoodsLimitedExceptLimitedExcepted_HazardousGoodsHazardousGoods),
            typeof(HazardousGoodsLimitedQuantity),
            typeof(HazardousGoodsLimitedQuantityLimitedQuantities_HazardousGoodsHazardousGoods),
            typeof(HazardousGoodsMixedPackingProvision),
            typeof(HazardousGoodsMixedPackingProvisionMixedPackingProvisions_HazardousGoodsHazardousGoods),
            typeof(HazardousGoodsPackingInstruction),
            typeof(HazardousGoodsPackingInstructionPackingInstructions_HazardousGoodsHazardousGoods),
            typeof(HazardousGoodsPortableTankContainerInstruction),
            typeof(HazardousGoodsPortableTankContainerInstructionPortableTankAndBulkContainerInstructions_HazardousGoodsHazardousGoods),
            typeof(HazardousGoodsPortableTankContainerSpecialProvision),
            typeof(HazardousGoodsPortableTankContainerSpecialProvisionPortableTankContainerAndBulkSpecialProvisions_HazardousGoodsHazardousGoods),
            typeof(HazardousGoodsProperty),
            typeof(HazardousGoodsPropertyValue),
            typeof(HazardousGoodsSpecialPackingProvision),
            typeof(HazardousGoodsSpecialPackingProvisionSpecialPackingProvisions_HazardousGoodsHazardousGoods),
            typeof(HazardousGoodsSpecialProvision),
            typeof(HazardousGoodsSpecialProvisionForCarriageBulk),
            typeof(HazardousGoodsSpecialProvisionForCarriageBulkSpecialProvisionForCarriageBulk_HazardousGoodsHazardousGoods),
            typeof(HazardousGoodsSpecialProvisionForCarriageLUH),
            typeof(HazardousGoodsSpecialProvisionForCarriageLUHSpecialProvisionForCarriageLoadingUnloadingAndHandling_HazardousGoodsHazardousGoods),
            typeof(HazardousGoodsSpecialProvisionForCarriageOperation),
            typeof(HazardousGoodsSpecialProvisionForCarriageOperationSpecialProvisionForCarriageOperation_HazardousGoodsHazardousGoods),
            typeof(HazardousGoodsSpecialProvisionForCarriagePackage),
            typeof(HazardousGoodsSpecialProvisionForCarriagePackageSpecialProvisionForCarriagePackage_HazardousGoodsHazardousGoods),
            typeof(HazardousGoodsSpecialProvisionSpecialProvisions_HazardousGoodsHazardousGoods),
            typeof(HazardousGoodsTransaction),
            typeof(HazardousGoodsTransportCategory),
            typeof(HazardousGoodsTransportCategoryTransportCategory_HazardousGoodsHazardousGoods),
            typeof(HazardousGoodsTunnelCode),
            typeof(HazardousGoodsTunnelCodeTunnelCodes_HazardousGoodsHazardousGoods),
            typeof(HazardousGoodsVehicleForTankCarriage),
            typeof(HazardousGoodsVehicleForTankCarriageVehicleForTankCarriage_HazardousGoodsHazardousGoods),
            typeof(HCategory),
            typeof(iEvent),
            typeof(iEvent_Employees),
            typeof(LabelTransaction),
            typeof(Lead),
            typeof(LoadType),
            typeof(LOGOParameter),
            typeof(MediaDataObject),
            typeof(Note),
            typeof(PackagingTypes),
            typeof(PackingGroup),
            typeof(PackingGroupPackingGroups_HazardousGoodsHazardousGoods),
            typeof(Participant),
            typeof(PermissionPolicyActionPermissionObject),
            typeof(PermissionPolicyMemberPermissionsObject),
            typeof(PermissionPolicyNavigationPermissionsObject),
            typeof(PermissionPolicyObjectPermissionsObject),
            typeof(PermissionPolicyRole),
            typeof(PermissionPolicyTypePermissionsObject),
            typeof(Position),
            typeof(Product),
            typeof(ProductCASNumber),
            typeof(ProductLabel),
            typeof(ProductSupplier),
            typeof(Quote),
            typeof(ReportDataV2),
            typeof(ReportOnOccurrence),
            typeof(Sector),
            typeof(SharedFile),
            typeof(TransportDocument),
            typeof(TransportDocumentDescription),
            typeof(TransportDocumentOtherTransaction),
            typeof(TransportDocumentTransaction),
            typeof(Unitset),
            typeof(Vehicle),
            typeof(VehicleControlDocument),
            typeof(VehicleControlDocumentEMailList),
            typeof(VehicleControlDocumentHazardousGoods),
            typeof(VehicleControlDocumentLabel),
            typeof(VehicleControlDocumentTransaction),
            typeof(VehicleDocument),
            typeof(VehicleDriver),
            typeof(VehicleDriverCompetenceCertificate),
            typeof(VehicleDriverDocument),
            typeof(VoyageNotification),
            typeof(VoyageNotificationHistory),
            typeof(VoyageNotificationTransaction),
            typeof(WasteList),
            typeof(WastePhysicalState)
        };
        public static Type[] GetPersistentTypes()
        {
            Type[] copy = new Type[persistentTypes.Length];
            Array.Copy(persistentTypes, copy, persistentTypes.Length);
            return copy;
        }
        public static string ConnectionString { get { return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; } }
        public static void Connect(DevExpress.Xpo.DB.AutoCreateOption autoCreateOption, bool threadSafe = false)
        {
            if (threadSafe)
            {
                var provider = XpoDefault.GetConnectionProvider(ConnectionString, autoCreateOption);
                var dictionary = new DevExpress.Xpo.Metadata.ReflectionDictionary();
                dictionary.GetDataStoreSchema(persistentTypes);
                XpoDefault.DataLayer = new ThreadSafeDataLayer(dictionary, provider);
            }
            else
            {
                XpoDefault.DataLayer = XpoDefault.GetDataLayer(ConnectionString, autoCreateOption);
            }

            XpoDefault.Session = null;
        }
        public static DevExpress.Xpo.DB.IDataStore GetConnectionProvider(DevExpress.Xpo.DB.AutoCreateOption autoCreateOption)
        {
            return XpoDefault.GetConnectionProvider(ConnectionString, autoCreateOption);
        }
        public static DevExpress.Xpo.DB.IDataStore GetConnectionProvider(DevExpress.Xpo.DB.AutoCreateOption autoCreateOption, out IDisposable[] objectsToDisposeOnDisconnect)
        {
            return XpoDefault.GetConnectionProvider(ConnectionString, autoCreateOption, out objectsToDisposeOnDisconnect);
        }
        public static IDataLayer GetDataLayer(DevExpress.Xpo.DB.AutoCreateOption autoCreateOption)
        {
            return XpoDefault.GetDataLayer(ConnectionString, autoCreateOption);
        }

        public static IDataLayer CreateDataLayer(AutoCreateOption autoCreationOption, bool threadSafe)
        {
            var dictionary = new ReflectionDictionary();
            dictionary.NullableBehavior = NullableBehavior.ByUnderlyingType;
            dictionary.GetDataStoreSchema(persistentTypes);
            if (threadSafe)
            {
                var provider = XpoDefault.GetConnectionProvider(XpoDefault.GetConnectionPoolString(ConnectionString), autoCreationOption);
                return new ThreadSafeDataLayer(dictionary, provider);
            }
            else
            {
                var provider = XpoDefault.GetConnectionProvider(ConnectionString, autoCreationOption);
                return new SimpleDataLayer(dictionary, provider);
            }
        }

        public static UnitOfWork CreateSession()
        {
            return new UnitOfWork() { IdentityMapBehavior = IdentityMapBehavior.Strong };
        }
    }

}
