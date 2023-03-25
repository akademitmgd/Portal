using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using iyibir.TMGD.Module.ApiModel;
using iyibir.TMGD.Module.BusinessObjects;
using iyibir.TMGD.Module.NonPersistentObjects;
using IyibirDLL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace iyibir.TMGD.Module.NPControllers.NP_DispatchListControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
    public partial class NP_DispatchListWindowController : WindowController
    {
        IObjectSpace os;
        public NP_DispatchListWindowController()
        {
            InitializeComponent();
            // Target required Windows (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            os = Application.CreateObjectSpace();
            Application.ListViewCreating += Application_ListViewCreating;
        }

        private void Application_ListViewCreating(Object sender, ListViewCreatingEventArgs e)
        {
            if ((e.CollectionSource.ObjectTypeInfo.Type == typeof(NP_DispatchList)) && (e.CollectionSource.ObjectSpace is NonPersistentObjectSpace))
            {
                ((NonPersistentObjectSpace)e.CollectionSource.ObjectSpace).ObjectsGetting += ObjectSpace_ObjectsGetting;
            }
        }

        private void ObjectSpace_ObjectsGetting(Object sender, ObjectsGettingEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            LOGOParameter parameter = os.FindObject<LOGOParameter>(CriteriaOperator.Parse("IsActive = ? and Employee.Oid = ?", true,SecuritySystem.CurrentUserId));
            if (parameter != null)
            {
               string token = new Helpers.WebApiHelper().GetToken(parameter.Uri,parameter.Username,parameter.Password);
                DBResult result = new Helpers.WebApiHelper().GetDispatchList(token, parameter.FirmNumber, parameter.PeriodNumber,parameter.Uri);
                if (result.Status)
                {
                    var dataResult = (JArray)result.Data;
                    BindingList<LG_STFICHE> dispatchList = dataResult.ToObject<BindingList<LG_STFICHE>>();
                    BindingList<NP_DispatchList> datasource = new BindingList<NP_DispatchList>();
                    foreach (LG_STFICHE item in dispatchList)
                    {
                        NP_DispatchList dispatch = new NP_DispatchList();
                        dispatch.ClientCode = item.CLIENTCODE;
                        dispatch.ClientName = item.CLIENTNAME;
                        dispatch.CreatedOn = (DateTime)item.DATE_;
                        dispatch.Docode = item.DOCODE;
                        dispatch.FicheNo = item.FICHENO;
                        dispatch.ReferenceId = item.LOGICALREF;
                        dispatch.ShipperCode = item.SHPAGNCOD;
                        dispatch.VehiclePlate1 = item.PLATENUM1;
                        dispatch.VehiclePlate2 = item.PLATENUM2;
                        dispatch.DriverTCKN1 = item.DRIVERTCKNO1;
                        dispatch.DriverTCKN2 = item.DRIVERTCKNO2;

                        foreach (LG_STLINE line in item.Lines)
                        {
                            NP_DispatchLine dispatchLine = new NP_DispatchLine();
                            dispatchLine.ReferenceId = line.LOGICALREF;
                            dispatchLine.ItemCode = line.STOCKCODE;
                            dispatchLine.ItemName = line.STOCKNAME;
                            dispatchLine.Quantity = (double)line.AMOUNT;

                            dispatch.Lines.Add(dispatchLine);
                        }

                        datasource.Add(dispatch);
                    }
                    e.Objects = datasource;
                }
                else
                    throw new UserFriendlyException(result.ErrorMessage);
            }
            else
            {
                throw new UserFriendlyException("LOGO Bağlantı Parametreleri Bulunamadı.. Lütfen Kontrol Ediniz..");
            }
        }

        protected override void OnDeactivated()
        {            
            base.OnDeactivated();
            Application.ListViewCreating -= Application_ListViewCreating;
        }
    }
}
