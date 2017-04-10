using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Cors;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Batch;
using Microsoft.OData;
using Microsoft.OData.Edm;
using WebSale.WebAPI.Models;

namespace WebSale.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
            //  new CamelCasePropertyNamesContractResolver();

            config.MapODataServiceRoute("odata", null, GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
            config.EnsureInitialized();
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "WebSale";
            builder.ContainerName = "DefaultContainer";
            builder.EntitySet<Product>("Products")
            .EntityType
            .Select(new string[] { nameof(Product.ProductCode) })
            .Filter(new string[] { nameof(Product.ProductCode), nameof(Product.Price) })
            .Expand(new string[] { nameof(Product.ProductName) })
            .OrderBy(new string[] { nameof(Product.Price) });
            var edmModel = builder.GetEdmModel();
            return edmModel;
        }
    }
}
