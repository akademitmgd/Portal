using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
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
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class HazardousGoodsTransaction : BaseObject
    {
        private HazardousGoodsTransactionType _transactionType;
        private Customer _customer;
        private Consignee _consignee;
        private DateTime _transactionDate;
        private Product _product;
        private HazardousGoods _hazardousGoods;
        private double _quantity;
        private Unitset _unitset;
        private string _description;
        private DateTime _createdOn;
        private Employee _owner;
        public HazardousGoodsTransaction(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                CreatedOn = DateTime.Now;
                Owner = Session.GetObjectByKey<Employee>(SecuritySystem.CurrentUserId);
            }
        }

        public HazardousGoodsTransactionType TransactionType { get => _transactionType; set => SetPropertyValue(nameof(TransactionType), ref _transactionType, value); }


        [ImmediatePostData]
        public Customer Customer { get => _customer; set => SetPropertyValue(nameof(Customer), ref _customer, value); }

        [DataSourceProperty("Customer.Consignees")]
        [RuleRequiredField]
        public Consignee Consignee { get=> _consignee; set=> SetPropertyValue(nameof(Consignee),ref _consignee,value); }

        [RuleRequiredField]
        public DateTime TransactionDate { get => _transactionDate; set => SetPropertyValue(nameof(TransactionDate), ref _transactionDate, value); }

        [Association("Product-Transactions")]
        public Product Product { get => _product; set => SetPropertyValue(nameof(Product), ref _product, value); }

        public double Quantity { get => _quantity; set => SetPropertyValue(nameof(Quantity), ref _quantity, value); }

        [RuleRequiredField]
        public Unitset Unitset { get => _unitset; set => SetPropertyValue(nameof(Unitset), ref _unitset, value); }
        public string Description { get => _description; set => SetPropertyValue(nameof(Description), ref _description, value); }

        [ModelDefault("AllowEdit", "False"), VisibleInDetailView(false), VisibleInListView(false)]
        public DateTime CreatedOn { get => _createdOn; set => SetPropertyValue(nameof(CreatedOn), ref _createdOn, value); }

        [ModelDefault("AllowEdit", "False"), VisibleInDetailView(false), VisibleInListView(false)]
        public Employee Owner { get => _owner; set => SetPropertyValue(nameof(Owner), ref _owner, value); }
    }
}