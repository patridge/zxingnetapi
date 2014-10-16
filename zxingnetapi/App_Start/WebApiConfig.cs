using System.Web.Http;

namespace zxingnetapi {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            config.MapHttpAttributeRoutes();
        }
    }
}
