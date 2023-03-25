using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using iyibir.TMGD.WebAPI.OData.Models.iyibir_TMGD;
using System;
using System.Collections.Concurrent;
using System.Web;
using System.Web.Http;
using System.Web.Http.Validation;
namespace iyibir.TMGD.WebAPI.OData
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        [Obsolete]
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(IBodyModelValidator), new CustomBodyModelValidator());
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ConnectionHelper.Connect(AutoCreateOption.DatabaseAndSchema, true);
        }
    }

    public class CustomBodyModelValidator : DefaultBodyModelValidator
    {
        readonly ConcurrentDictionary<Type, bool> persistentTypes = new ConcurrentDictionary<Type, bool>();
        public override bool ShouldValidateType(Type type)
        {
            return persistentTypes.GetOrAdd(type, t => !typeof(IXPSimpleObject).IsAssignableFrom(t));
        }
    }
}
