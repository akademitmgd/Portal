using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace iyibir.TMGD.WebAPI.V2.EModels
{
    public class CustomerModel
    {
        public Guid Oid { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public CityModel City { get; set; }
        public CountyModel County { get; set; }
        public string Telephone { get; set; }
        public string OtherTelephone { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public bool IsPerson { get; set; }
        public string TCKN { get; set; }
        public string LastName { get; set; }
        public bool Consignor { get; set; }
        public bool Carrier { get; set; }
        public bool Consignee { get; set; }
        public bool Loader { get; set; }
        public bool UnLoader { get; set; }
        public bool Packer { get; set; }
        public bool Filler { get; set; }
        public bool TankContainer { get; set; }
        public string ActivityCertificateCode { get; set; }
        public DateTime ActivityCertificateDate { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public EmployeeModel Consultant { get; set; }
        public SectorModel Sector { get; set; }

    }
}