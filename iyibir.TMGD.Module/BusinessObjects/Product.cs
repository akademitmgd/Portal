using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Product")]
    [DefaultProperty("Name")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Product : BaseObject
    {
        private ProductGroupType _productGroupType;
        private ProductType _productType;
        private string _code;
        private string _name;
        private string _otherName;
        private HazardousGoods _hazardousGoods;
        private Unitset _unitset;
        private PackagingTypes _packagingTypes;
        private FactoryDepartment _factoryDepartment;
        private CustomerInventoryMSDSStatus _msdsStatus;
        private string _msdsName;
        private FileData _documentData;
        private Customer _customer;
        private WasteList _wasteCode;
        private string _wasteName;
        private WastePhysicalState _wastePhysicalState;
        private bool _isActive;
        private Employee _owner;
        private DateTime _msdsDateOfValidity;
        public Product(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                IsActive = true;
               Employee owner = SecuritySystem.CurrentUser as Employee;
                if (owner != null)
                {
                    switch (owner.EmployeeType)
                    {
                        case EmployeeType.Employee:
                            break;
                        case EmployeeType.Customer:
                            Customer = owner.Customer != null ? Session.GetObjectByKey<Customer>(owner.Customer.Oid) : null;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (!Session.IsObjectMarkedDeleted(this))
            {
                switch (propertyName)
                {
                    case "HazardousGoods":
                        HazardousGoods hazardousGoods = this.HazardousGoods != null ? Session.GetObjectByKey<HazardousGoods>(this.HazardousGoods.Oid) : null;
                        if (hazardousGoods != null)
                        {
                            foreach (var label in hazardousGoods.Labels)
                            {
                                ProductLabel productLabel = new ProductLabel(Session);
                                productLabel.Product = this;
                                productLabel.LabelImage = label.HazardousGoodsLabel.LabelImage;

                                this.Labels.Add(productLabel);
                            }

                            this.RaisePropertyChangedEvent("Labels");
                        }
                        break;
                    case "WasteCode":
                        if (WasteCode != null)
                        {
                            this.WasteName = WasteCode.Name ?? string.Empty;
                            this.RaisePropertyChangedEvent(nameof(WasteName));
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        [VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 350, DetailViewImageEditorFixedWidth = 350)]
        public byte[] Image
        {
            get { return GetPropertyValue<byte[]>(nameof(Image)); }
            set { SetPropertyValue<byte[]>(nameof(Image), value); }
        }


        [ImmediatePostData]
        public ProductGroupType ProductGroupType { get=> _productGroupType; set=> SetPropertyValue(nameof(ProductGroupType),ref _productGroupType,value); }

        public ProductType ProductType { get=> _productType; set=> SetPropertyValue(nameof(ProductType),ref _productType,value); }

        [RuleRequiredField]
        public string Code { get=> _code; set=> SetPropertyValue(nameof(Code),ref _code,value); }

        [RuleRequiredField]
        public string Name { get=> _name; set=> SetPropertyValue(nameof(Name),ref _name,value); }

        [VisibleInListView(false)]
        public string OtherName { get=> _otherName; set=> SetPropertyValue(nameof(OtherName),ref _otherName,value); }

        [RuleRequiredField]
        [ImmediatePostData]
        public HazardousGoods HazardousGoods { get=> _hazardousGoods; set=> SetPropertyValue(nameof(HazardousGoods),ref _hazardousGoods,value); }

        [RuleRequiredField]
        public Unitset Unitset { get=> _unitset; set=> SetPropertyValue(nameof(Unitset),ref _unitset,value); }


        public PackagingTypes PackagingTypes { get=> _packagingTypes; set=> SetPropertyValue(nameof(PackagingTypes),ref _packagingTypes,value); }

        [Appearance("Product FactoryDepartment Hide", Criteria = "ProductGroupType = 1", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        public FactoryDepartment FactoryDepartment { get=> _factoryDepartment; set=> SetPropertyValue(nameof(FactoryDepartment),ref _factoryDepartment,value); }

        [NonPersistent,VisibleInDetailView(false)]
        public double TotalPurchaseQuantity
        {
            get
            {

                if (!IsLoading && !IsSaving)
                    return Transactions.Where(x=> x.TransactionType == HazardousGoodsTransactionType.Purchase).Sum(x => x.Quantity);
                else
                    return 0;
            }
        }

        [NonPersistent, VisibleInDetailView(false)]
        public double TotalSalesQuantity
        {
            get
            {

                if (!IsLoading && !IsSaving)
                    return Transactions.Where(x => x.TransactionType == HazardousGoodsTransactionType.Sales).Sum(x => x.Quantity);
                else
                    return 0;
            }
        }

        [VisibleInListView(false)]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        [Appearance("Product FileData Hide", Criteria = "ProductGroupType = 1", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        public FileData FileData { get => _documentData; set => SetPropertyValue("FileData", ref _documentData, value); }

        [Appearance("Product MSDSStatus Hide", Criteria = "ProductGroupType = 1", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        public CustomerInventoryMSDSStatus MSDSStatus { get => _msdsStatus; set => SetPropertyValue(nameof(MSDSStatus), ref _msdsStatus, value); }

        [VisibleInListView(false)]
        [Appearance("Product MSDSName Hide", Criteria = "ProductGroupType = 1", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        public string MSDSName { get => _msdsName; set => SetPropertyValue(nameof(MSDSName), ref _msdsName, value); }

        [Association("Customer-Products")]
        [RuleRequiredField]
        public Customer Customer { get=> _customer; set=> SetPropertyValue(nameof(Customer),ref _customer,value); }

        [ImmediatePostData]
        [RuleRequiredField("RuleRequiredField for Product.WasteCode", DefaultContexts.Save, TargetCriteria = "ProductGroupType = 1")]        
        [Appearance("Product WasteCode Hide", Criteria = "ProductGroupType = 0", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        public WasteList WasteCode { get => _wasteCode; set => SetPropertyValue(nameof(WasteCode), ref _wasteCode, value); }

        [ModelDefault("AllowEdit", "False")]
        [Appearance("Product WasteName Hide", Criteria = "ProductGroupType = 0", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        public string WasteName { get => _wasteName; set => SetPropertyValue(nameof(WasteName), ref _wasteName, value); }

        [Appearance("Product WastePhysicalState Hide", Criteria = "ProductGroupType = 0", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        public WastePhysicalState WastePhysicalState { get => _wastePhysicalState; set => SetPropertyValue(nameof(WastePhysicalState), ref _wastePhysicalState, value); }

        [VisibleInDetailView(false),VisibleInListView(false)]
        [ModelDefault("AllowEdit","False")]
        public Employee Owner { get=> _owner; set=> SetPropertyValue(nameof(Owner),ref _owner,value); }

        public bool IsActive { get=> _isActive; set=> SetPropertyValue(nameof(IsActive),ref _isActive,value); }

        //[RuleRequiredField("RuleRequiredField for Product.MSDSDateOfValidity", DefaultContexts.Save, TargetCriteria = "ProductGroupType = 0")]
        [Appearance("Product MSDSDateOfValidity Hide", Criteria = "ProductGroupType = 1", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        public DateTime MSDSDateOfValidity { get=> _msdsDateOfValidity; set=> SetPropertyValue(nameof(MSDSDateOfValidity),ref _msdsDateOfValidity,value); }

        [Association("Product-Transactions"), DevExpress.Xpo.Aggregated]
        public XPCollection<HazardousGoodsTransaction> Transactions => GetCollection<HazardousGoodsTransaction>(nameof(Transactions));

        [Association("Product-Suppliers"),DevExpress.Xpo.Aggregated]
        public XPCollection<ProductSupplier> Suppliers => GetCollection<ProductSupplier>(nameof(Suppliers));

        [Association("Product-Labels"),DevExpress.Xpo.Aggregated]
        public XPCollection<ProductLabel> Labels => GetCollection<ProductLabel>(nameof(Labels));

        [Appearance("Product CASNumbers Hide", Criteria = "ProductGroupType = 1", Context = "DetailView", Visibility = ViewItemVisibility.Hide)]
        [Association("Product-CASNumbers"),DevExpress.Xpo.Aggregated]
        public XPCollection<ProductCASNumber> CASNumbers => GetCollection<ProductCASNumber>(nameof(CASNumbers));
    }
}