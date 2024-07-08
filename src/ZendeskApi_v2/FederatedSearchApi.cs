using System.Collections.Generic;
using ZendeskApi_v2.Requests.FederatedSearch;

namespace ZendeskApi_v2.FederatedSearch
{
    public interface IFederatedSearchApi
    {
        IExternalContentRecords ExternalContentRecords { get; }
        IExternalContentSources ExternalContentSources { get; }
        IExternalContentTypes ExternalContentTypes { get; }
        string Locale { get; }
    }

    public class FederatedSearchApi : IFederatedSearchApi
    {
        public FederatedSearchApi(
            string yourZendeskUrl,
            string user,
            string password,
            string apiToken,
            string locale,
            string p_OAuthToken,
            Dictionary<string, string> customHeaders)
        {
            ExternalContentRecords = new ExternalContentRecords(yourZendeskUrl, user, password, apiToken, locale, p_OAuthToken, customHeaders);
            ExternalContentSources = new ExternalContentSources(yourZendeskUrl, user, password, apiToken, locale, p_OAuthToken, customHeaders);
            ExternalContentTypes = new ExternalContentTypes(yourZendeskUrl, user, password, apiToken, locale, p_OAuthToken, customHeaders);
            Locale = locale;
        }

        public IExternalContentRecords ExternalContentRecords { get; }
        public IExternalContentSources ExternalContentSources { get; }
        public IExternalContentTypes ExternalContentTypes { get; }
        public string Locale { get; }
    }
}
