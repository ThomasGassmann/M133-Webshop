namespace TaobaoExpress
{
    using System;
    using System.Web;
    using System.Web.Optimization;
    using System.Web.Routing;
    using TaobaoExpress.DataAccess.Context;

    public class Global : HttpApplication
    {
        public void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var context = ObjectFactory.Instance.GetInstance<TaobaoExpressContext>();
            context.Database.CreateIfNotExists();
        }
    }
}