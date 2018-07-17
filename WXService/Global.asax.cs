using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WXService
{
    public class Global : System.Web.HttpApplication
    {
       

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new ServiceRoute("AddWccMemberCommon", new WebServiceHostFactory(), typeof(wccmemberService)));
            RouteTable.Routes.Add(new ServiceRoute("UpdateWccMemberCommon", new WebServiceHostFactory(), typeof(UpdatememberService)));
            RouteTable.Routes.Add(new ServiceRoute("AddTemplateCommon", new WebServiceHostFactory(), typeof(TemplateService)));
            RouteTable.Routes.Add(new ServiceRoute("SelectQRcode", new WebServiceHostFactory(), typeof(QRcodeService)));
            RouteTable.Routes.Add(new ServiceRoute("AddQRcode", new WebServiceHostFactory(), typeof(AQRcodeService)));
            RouteTable.Routes.Add(new ServiceRoute("SelectBarcode", new WebServiceHostFactory(), typeof(BarcodeService)));
            //注册路由
            /**System.Web.Routing.RouteTable.Routes.Add(
                new System.ServiceModel.Activation.ServiceRoute(
                    "AddWccMemberCommon",
                    new SecureWebServiceHostFactory(), typeof(TemplateService)
                ));
            //注册路由
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute(
                "imageService", new System.ServiceModel.Activation.WebServiceHostFactory(), typeof(wccmemberService)));**/
            RegisterLog4Net();
        }
        private void RegisterLog4Net()
        {
            System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath("~\\log4net.config"));
            log4net.Config.XmlConfigurator.Configure(file);
        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}