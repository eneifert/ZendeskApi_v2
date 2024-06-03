using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if ASYNC

using System.Threading.Tasks;

#endif

using ZendeskApi_v2.Extensions;
using ZendeskApi_v2.Models.FederatedSearch;

namespace ZendeskApi_v2.Requests.FederatedSearch
{
    public interface IExternalContentSources : ICore
    {
#if SYNC
        IndividualExternalContentSourceResponse ShowExternalContentSource(string externalSourceId);
        GroupExternalContentSourcesResponse ListExternalContentSources(string after = null, string before = null, int? size = null);
        IndividualExternalContentSourceResponse CreateExternalContentSource(ExternalContentSourceRequest externalContentSource);

        IndividualExternalContentSourceResponse UpdateExternalContentSource(string externalSourceId, ExternalContentSource externalContentSource);
        bool? DeleteExternalContentSource(string externalSourceId);
#endif
#if ASYNC   
        Task<IndividualExternalContentSourceResponse> ShowExternalContentSourceAsync(string externalSourceId);
        Task<GroupExternalContentSourcesResponse> ListExternalContentSourcesAsync(string after = null, string before = null, int? size = null);     
        Task<IndividualExternalContentSourceResponse> CreateExternalContentSourceAync(ExternalContentSourceRequest externalContentSource);
        Task<IndividualExternalContentSourceResponse> UpdateExternalContentSourceAsync(string externalSourceId, ExternalContentSource externalContentSource);
        Task<bool?> DeleteExternalContentSourceAsync(string externalSourceId);
#endif

    }

    public class ExternalContentSources: Core, IExternalContentSources
    {
        private readonly string urlPrefix = "guide/external_content";

        public ExternalContentSources(string yourZendeskUrl, string user, string password, string apiToken, string locale, string p_OAuthToken, Dictionary<string,string> customHeaders)
            : base(yourZendeskUrl, user, password, apiToken, p_OAuthToken, customHeaders)
        {
            if (!locale.IsNullOrWhiteSpace())
            {
                urlPrefix = $"{urlPrefix}";//locale isn't used in the federated search URL
            }
        }
#if SYNC
        public IndividualExternalContentSourceResponse ShowExternalContentSource(string externalSourceId)
        {
            var resourceUrl = $"{urlPrefix}/sources/{externalSourceId}";

            return GenericGet<IndividualExternalContentSourceResponse>(resourceUrl);
        }
        public GroupExternalContentSourcesResponse ListExternalContentSources(string after=null, string before=null, int? size=null)
        {
            var resourceUrl = $"{urlPrefix}/sources?" + BuildExternalContentQueryString(after,before,size);

            return GenericGet<GroupExternalContentSourcesResponse>(resourceUrl);

        }

        public IndividualExternalContentSourceResponse CreateExternalContentSource(ExternalContentSourceRequest externalContentSource)
        {
            var resourceUrl = $"{urlPrefix}/sources";

            return GenericPost<IndividualExternalContentSourceResponse>(resourceUrl,externalContentSource);
        }

        public IndividualExternalContentSourceResponse UpdateExternalContentSource(string externalSourceId, ExternalContentSource externalContentSource)
        {
            var resourceUrl = $"{urlPrefix}/sources/{externalSourceId}";
            return GenericPut<IndividualExternalContentSourceResponse>(resourceUrl, externalContentSource);
        }
        public bool? DeleteExternalContentSource(string externalSourceId)
        {
            var resourceUrl = $"{urlPrefix}/sources/{externalSourceId}";
            return GenericDelete<bool?>(resourceUrl);
        }
#endif

#if ASYNC
        public async Task<IndividualExternalContentSourceResponse> ShowExternalContentSourceAsync(string externalSourceId)
        {
            var resourceUrl = $"{urlPrefix}/sources/{externalSourceId}";

            return await GenericGetAsync<IndividualExternalContentSourceResponse>(resourceUrl);
        }

        public async Task<GroupExternalContentSourcesResponse> ListExternalContentSourcesAsync(string after=null, string before=null, int? size=null)
        {
            var resourceUrl = $"{urlPrefix}/sources?" + BuildExternalContentQueryString(after,before,size);

            return await GenericGetAsync<GroupExternalContentSourcesResponse>(resourceUrl);

        }

        public async Task<IndividualExternalContentSourceResponse> CreateExternalContentSourceAync(ExternalContentSourceRequest externalContentSource)
        {
            var resourceUrl = $"{urlPrefix}/sources";
            
            return await GenericPostAsync<IndividualExternalContentSourceResponse>(resourceUrl,externalContentSource);
        }

        public async Task<IndividualExternalContentSourceResponse> UpdateExternalContentSourceAsync(string externalSourceId, ExternalContentSource externalContentSource)
        {
            var resourceUrl = $"{urlPrefix}/sources/{externalSourceId}";
            return await GenericPutAsync<IndividualExternalContentSourceResponse>(resourceUrl, externalContentSource);
        }
        public async Task<bool?> DeleteExternalContentSourceAsync(string externalSourceId)
        {
            var resourceUrl = $"{urlPrefix}/sources/{externalSourceId}";
            return await GenericDeleteAsync<bool?>(resourceUrl);
        }
#endif
        private string BuildExternalContentQueryString(string after=null, string before=null, int? size=null)
        {
            var queryParams = new Dictionary<string, string>()
            {
                {"after",after},
                {"before",before},
                {"size",size.ToString()}
            };
            return queryParams.GetQueryString();
        }
    }
}
