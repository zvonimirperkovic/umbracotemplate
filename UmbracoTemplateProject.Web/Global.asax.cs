using System.Web.Mvc;
using System.Web.Http;
using Umbraco.Web;
using System;
using Umbraco.Core;
using System.Web.Routing;
using System.Web.Optimization;

namespace UmbracoTemplateProject.Web
{
    public class CustomGlobal : UmbracoApplication
    {
        protected override void OnApplicationStarted(object sender, EventArgs e)
        {
            base.OnApplicationStarted(sender, e);
            GlobalConfiguration.Configuration.EnsureInitialized();
            AreaRegistration.RegisterAllAreas();

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override IBootManager GetBootManager()
        {
            return new CustomWebBootManager(this);
        }

        public class CustomWebBootManager : WebBootManager
        {
            public CustomWebBootManager(UmbracoApplicationBase application) : base(application)
            {

            }

            public override IBootManager Complete(Action<ApplicationContext> afterComplete)
            {
                RegisterRoutes();
                return base.Complete(afterComplete);
            }

            private void RegisterRoutes()
            {
            }
        }
    }
}
