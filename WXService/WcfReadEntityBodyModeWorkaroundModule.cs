using System;
using System.Web;
using System.IO;

namespace WXService
{
    public class WcfReadEntityBodyModeWorkaroundModule : IHttpModule
    {
        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此模块
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参阅以下链接: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //此处放置清除代码。
        }

        public void Init(HttpApplication context)
        {
            // 下面是如何处理 LogRequest 事件并为其 
            // 提供自定义日志记录实现的示例
            context.BeginRequest += context_BeginRequest;
        }

        #endregion

         void context_BeginRequest(Object sender, EventArgs e)
        {
            //可以在此处放置自定义日志记录逻辑
            Stream stream = (sender as HttpApplication).Request.InputStream;
        }
    }
}
