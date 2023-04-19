using Newtonsoft.Json;

namespace TradingDDD.Web.Api.Helper
{
    public static class UtilHelper
    {
        public static string ToJSON(this object @object) => JsonConvert.SerializeObject(@object, Formatting.None);

    }
}
