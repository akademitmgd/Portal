using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using iyibir.TMGD.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace iyibir.TMGD.Module.Helpers
{
    public class Helper
    {
        public MailMessage GetMailWithOpenCase(string fromMailAddress, string toMailAddress, string body)
        {
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.Body = body;

            mail.From = new MailAddress(fromMailAddress);
            mail.To.Add(toMailAddress);
            mail.Subject = "Araç Kontrol Formu Durumu";
            return mail;
        }

        public bool IsAdministrator(Employee employee)
        {
            bool result = false;

            foreach (EmployeeRole role in employee.EmployeeRoles)
            {
                if (role.IsAdministrative)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool IsManager(Employee employee)
        {
            return employee.IsManager;
        }

        public void FilterMyAnnouncement(View view, Employee emp)
        {
            if (view is ListView)
            {
                if (IsAdministrator(emp)) ((ListView)view).CollectionSource.Criteria.Remove("FilterMyAnnouncement");
                else
                {
                    ((ListView)view).CollectionSource.Criteria.Clear();
                    ((ListView)view).CollectionSource.Criteria.Add("FilterMyAnnouncement", CriteriaOperator.Parse("[Employees][[Oid] = ?]", SecuritySystem.CurrentUserId));
                    ((ListView)view).RefreshDataSource();
                    ((ListView)view).Refresh();

                    //XPCollection<Customer> Customers = new XPCollection<Customer>();
                    //Customers.Criteria = CriteriaOperator.Parse("Orders[^.RegistrationDate == Date]");
                }
            }
        }

        public void FilterActivityDocument(View view, Employee employee)
        {
            switch (employee.EmployeeType)
            {
                case EmployeeType.Employee:
                    if (view is ListView)
                    {
                        if (!employee.IsManager)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterActivityByEmployee", CriteriaOperator.Parse("Owner.Oid = ?", employee.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                case EmployeeType.Customer:
                    if (view is ListView)
                    {
                        if (employee.Customer != null)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterActivityByCustomer", CriteriaOperator.Parse("Customer.Oid = ?", employee.Customer.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                default:
                    ((ListView)view).CollectionSource.Criteria.Clear();
                    ((ListView)view).RefreshDataSource();
                    ((ListView)view).Refresh();
                    break;
            }
        }

        public void FilterProductDocument(View view, Employee employee)
        {
            switch (employee.EmployeeType)
            {
                case EmployeeType.Employee:
                    if (view is ListView)
                    {
                        if (!employee.IsManager)
                        {
                            if (view.Id != "Customer_Inventories_ListView")
                            {
                                ((ListView)view).CollectionSource.Criteria.Clear();
                                ((ListView)view).CollectionSource.Criteria.Add("FilterProductByEmployee", CriteriaOperator.Parse("Owner.Oid = ?", employee.Oid));

                                if (view.Id == "Product_ListView")
                                    ((ListView)view).CollectionSource.Criteria.Add("FilterProductByHazardousGoods", CriteriaOperator.Parse("ProductGroupType = ?", 0));
                                else if (view.Id == "Product_ListView_Waste")
                                    ((ListView)view).CollectionSource.Criteria.Add("FilterProductByWaste", CriteriaOperator.Parse("ProductGroupType = ?", 1));

                                ((ListView)view).RefreshDataSource();
                                ((ListView)view).Refresh(); /**/
                            }
                        }
                    }
                    break;
                case EmployeeType.Customer:
                    if (view is ListView)
                    {
                        if (employee.Customer != null)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterProductByCustomer", CriteriaOperator.Parse("Customer.Oid = ?", employee.Customer.Oid));

                            if (view.Id == "Product_ListView")
                                ((ListView)view).CollectionSource.Criteria.Add("FilterProductByHazardousGoods", CriteriaOperator.Parse("ProductGroupType = ?", 0));
                            else if (view.Id == "Product_ListView_Waste")
                                ((ListView)view).CollectionSource.Criteria.Add("FilterProductByWaste", CriteriaOperator.Parse("ProductGroupType = ?", 1));

                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                default:
                    ((ListView)view).CollectionSource.Criteria.Clear();
                    ((ListView)view).RefreshDataSource();
                    ((ListView)view).Refresh();
                    break;
            }
        }

        public void FilterEducationDocument(View view, Employee employee)
        {
            switch (employee.EmployeeType)
            {
                case EmployeeType.Employee:
                    if (view is ListView)
                    {
                        if (!employee.IsManager)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterEducationByEmployee", CriteriaOperator.Parse("Instructur.Oid = ?", employee.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                case EmployeeType.Customer:
                    if (view is ListView)
                    {
                        if (employee.Customer != null)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterEducationByCustomer", CriteriaOperator.Parse("Customer.Oid = ?", employee.Customer.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                default:
                    ((ListView)view).CollectionSource.Criteria.Clear();
                    ((ListView)view).RefreshDataSource();
                    ((ListView)view).Refresh();
                    break;
            }
        }

        public void FilterActivityReportDocument(View view, Employee employee)
        {
            switch (employee.EmployeeType)
            {
                case EmployeeType.Employee:
                    if (view is ListView)
                    {
                        if (!employee.IsManager)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterActivityReportByEmployee", CriteriaOperator.Parse("Colsultant.Oid = ?", employee.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                case EmployeeType.Customer:
                    if (view is ListView)
                    {
                        if (employee.Customer != null)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterActivityReportByCustomer", CriteriaOperator.Parse("Customer.Oid = ?", employee.Customer.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                default:
                    ((ListView)view).CollectionSource.Criteria.Clear();
                    ((ListView)view).RefreshDataSource();
                    ((ListView)view).Refresh();
                    break;
            }
        }

        public void FilterAuditDeterminationDocument(View view, Employee employee)
        {
            switch (employee.EmployeeType)
            {
                case EmployeeType.Employee:
                    if (view is ListView)
                    {
                        if (!employee.IsManager)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterAuditDeterminationByEmployee", CriteriaOperator.Parse("Owner.Oid = ?", employee.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                case EmployeeType.Customer:
                    if (view is ListView)
                    {
                        if (employee.Customer != null)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterAuditDeterminationByCustomer", CriteriaOperator.Parse("Customer.Oid = ?", employee.Customer.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                default:
                    ((ListView)view).CollectionSource.Criteria.Clear();
                    ((ListView)view).RefreshDataSource();
                    ((ListView)view).Refresh();
                    break;
            }
        }

        public void FilterDistributionOfTaskDocument(View view, Employee employee)
        {
            switch (employee.EmployeeType)
            {
                case EmployeeType.Employee:
                    if (view is ListView)
                    {
                        if (!employee.IsManager)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterDistributionOfTaskByEmployee", CriteriaOperator.Parse("Owner.Oid = ?", employee.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                case EmployeeType.Customer:
                    if (view is ListView)
                    {
                        if (employee.Customer != null)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterDistributionOfTaskByCustomer", CriteriaOperator.Parse("Customer.Oid = ?", employee.Customer.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                default:
                    ((ListView)view).CollectionSource.Criteria.Clear();
                    ((ListView)view).RefreshDataSource();
                    ((ListView)view).Refresh();
                    break;
            }
        }

        public void FilterDrillFormDocument(View view, Employee employee)
        {
            switch (employee.EmployeeType)
            {
                case EmployeeType.Employee:
                    if (view is ListView)
                    {
                        if (!employee.IsManager)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterDrillFormByEmployee", CriteriaOperator.Parse("Owner.Oid = ?", employee.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                case EmployeeType.Customer:
                    if (view is ListView)
                    {
                        if (employee.Customer != null)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterDrillFormByCustomer", CriteriaOperator.Parse("Customer.Oid = ?", employee.Customer.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                default:
                    ((ListView)view).CollectionSource.Criteria.Clear();
                    ((ListView)view).RefreshDataSource();
                    ((ListView)view).Refresh();
                    break;
            }
        }

        public void FilterReportOnOccurrenceDocument(View view, Employee employee)
        {
            switch (employee.EmployeeType)
            {
                case EmployeeType.Employee:
                    if (view is ListView)
                    {
                        if (!employee.IsManager)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterReportOnOccurrenceByEmployee", CriteriaOperator.Parse("Owner.Oid = ?", employee.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                case EmployeeType.Customer:
                    if (view is ListView)
                    {
                        if (employee.Customer != null)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterReportOnOccurrenceByCustomer", CriteriaOperator.Parse("Customer.Oid = ?", employee.Customer.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                default:
                    ((ListView)view).CollectionSource.Criteria.Clear();
                    ((ListView)view).RefreshDataSource();
                    ((ListView)view).Refresh();
                    break;
            }
        }

        public void FilterConsigneeDocument(View view, Employee employee)
        {
            switch (employee.EmployeeType)
            {
                case EmployeeType.Employee:
                    if (view is ListView)
                    {
                        if (!employee.IsManager)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterConsigneeByEmployee", CriteriaOperator.Parse("Customer.Consultant.Oid = ?", employee.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                case EmployeeType.Customer:
                    if (view is ListView)
                    {
                        if (employee.Customer != null)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterConsigneeByCustomer", CriteriaOperator.Parse("Customer.Oid = ?", employee.Customer.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                default:
                    ((ListView)view).CollectionSource.Criteria.Clear();
                    ((ListView)view).RefreshDataSource();
                    ((ListView)view).Refresh();
                    break;
            }
        }

        public void FilterVoyageNotificationDocument(View view, Employee employee)
        {
            switch (employee.EmployeeType)
            {
                case EmployeeType.Employee:
                    if (view is ListView)
                    {
                        if (!employee.IsManager)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterVoyageNotificationByEmployee", CriteriaOperator.Parse("Owner.Oid = ?", employee.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                case EmployeeType.Customer:
                    if (view is ListView)
                    {
                        if (employee.Customer != null)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterVoyageNotificationByCustomer", CriteriaOperator.Parse("TransportDocument.Consigner.Oid = ?", employee.Customer.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                default:
                    ((ListView)view).CollectionSource.Criteria.Clear();
                    ((ListView)view).RefreshDataSource();
                    ((ListView)view).Refresh();
                    break;
            }
        }
        public void FilterTransportDocumentDocument(View view, Employee employee)
        {
            switch (employee.EmployeeType)
            {
                case EmployeeType.Employee:
                    if (view is ListView)
                    {
                        if (!employee.IsManager)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterTransportDocumentByEmployee", CriteriaOperator.Parse("Owner.Oid = ?", employee.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                case EmployeeType.Customer:
                    if (view is ListView)
                    {
                        if (employee.Customer != null)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterTransportDocumentByCustomer", CriteriaOperator.Parse("Consigner.Oid = ?", employee.Customer.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                default:
                    ((ListView)view).CollectionSource.Criteria.Clear();
                    ((ListView)view).RefreshDataSource();
                    ((ListView)view).Refresh();
                    break;
            }
        }

        public void FilterAnnualWorkPlanDocument(View view, Employee employee)
        {
            switch (employee.EmployeeType)
            {
                case EmployeeType.Employee:
                    if (view is ListView)
                    {
                        if (!employee.IsManager)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterAnnualWorkPlanByEmployee", CriteriaOperator.Parse("Owner.Oid = ?", employee.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                case EmployeeType.Customer:
                    if (view is ListView)
                    {
                        if (employee.Customer != null)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterAnnualWorkPlanByCustomer", CriteriaOperator.Parse("Customer.Oid = ?", employee.Customer.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                default:
                    ((ListView)view).CollectionSource.Criteria.Clear();
                    ((ListView)view).RefreshDataSource();
                    ((ListView)view).Refresh();
                    break;
            }
        }

        public void FilterVehicleDocumentDocument(View view, Employee employee)
        {
            switch (employee.EmployeeType)
            {
                case EmployeeType.Employee:
                    if (view is ListView)
                    {
                        if (!employee.IsManager)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterVehicleDocumentByEmployee", CriteriaOperator.Parse("Owner.Oid = ?", employee.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                case EmployeeType.Customer:
                    if (view is ListView)
                    {
                        if (employee.Customer != null)
                        {
                            ((ListView)view).CollectionSource.Criteria.Clear();
                            ((ListView)view).CollectionSource.Criteria.Add("FilterVehicleDocumentByCustomer", CriteriaOperator.Parse("Consigner.Oid = ?", employee.Customer.Oid));
                            ((ListView)view).RefreshDataSource();
                            ((ListView)view).Refresh();
                        }
                    }
                    break;
                default:
                    ((ListView)view).CollectionSource.Criteria.Clear();
                    ((ListView)view).RefreshDataSource();
                    ((ListView)view).Refresh();
                    break;
            }
        }
    }
}
