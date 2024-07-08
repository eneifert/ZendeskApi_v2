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
    public interface IExternalContentTypes : ICore
    {
#if SYNC
        IndividualExternalContentTypeResponse ShowExternalContentType(string externalSourceId);
        GroupExternalContentTypesResponse ListExternalContentTypes(string after = null, string before = null, int? size = null);
        IndividualExternalContentTypeResponse CreateExternalContentType(ExternalContentTypeRequest externalContentRecord);
        IndividualExternalContentTypeResponse UpdateExternalContentType(string externalSourceId, ExternalContentType externalContentRecord);
        bool? DeleteExternalContentType(string externalSourceId);
#endif
#if ASYNC   
        Task<IndividualExternalContentTypeResponse> ShowExternalContentTypeAsync(string externalSourceId);
        Task<GroupExternalContentTypesResponse> ListExternalContentTypesAsync(string after = null, string before = null, int? size = null);     
        Task<IndividualExternalContentTypeResponse> CreateExternalContentTypeAsync(ExternalContentTypeRequest externalContentRecord);
        Task<IndividualExternalContentTypeResponse> UpdateExternalContentTypeAsync(string externalSourceId, ExternalContentType externalContentRecord);
        Task<bool?> DeleteExternalContentTypeAsync(string externalSourceId);
#endif

    }

    public class ExternalContentTypes: Core, IExternalContentTypes
    {
        private readonly string urlPrefix = "guide/external_content";

        public ExternalContentTypes(string yourZendeskUrl, string user, string password, string apiToken, string locale, string p_OAuthToken, Dictionary<string,string> customHeaders)
            : base(yourZendeskUrl, user, password, apiToken, p_OAuthToken, customHeaders)
        {
            if (!locale.IsNullOrWhiteSpace())
            {
                urlPrefix = $"{urlPrefix}";
            }
        }
#if SYNC
        public IndividualExternalContentTypeResponse ShowExternalContentType(string externalTypeId)
        {
            var resourceUrl = $"{urlPrefix}/types/{externalTypeId}";
            return GenericGet<IndividualExternalContentTypeResponse>(resourceUrl);
        }
        public GroupExternalContentTypesResponse ListExternalContentTypes(string after=null, string before=null, int? size=null)
        {
            var resourceUrl = $"{urlPrefix}/types?" + BuildExternalContentQueryString(after,before,size);
            return GenericGet<GroupExternalContentTypesResponse>(resourceUrl);
        }

        public IndividualExternalContentTypeResponse CreateExternalContentType(ExternalContentTypeRequest externalContentType)
        {
            var resourceUrl = $"{urlPrefix}/types";
            return GenericPost<IndividualExternalContentTypeResponse>(resourceUrl,externalContentType);
        }

        public IndividualExternalContentTypeResponse UpdateExternalContentType(string externalRecordId, ExternalContentType externalContentRecord)
        {
            var resourceUrl = $"{urlPrefix}/types/{externalRecordId}";
            return GenericPut<IndividualExternalContentTypeResponse>(resourceUrl, externalContentRecord);
        }
        public bool? DeleteExternalContentType(string externalTypeId)
        {
            var resourceUrl = $"{urlPrefix}/types/{externalTypeId}";
            return GenericDelete<bool?>(resourceUrl);
        }
#endif

#if ASYNC
        public async Task<IndividualExternalContentTypeResponse> ShowExternalContentTypeAsync(string externalTypeId)
        {
            var resourceUrl = $"{urlPrefix}/types/{externalTypeId}";
            return await GenericGetAsync<IndividualExternalContentTypeResponse>(resourceUrl);
        }

        public async Task<GroupExternalContentTypesResponse> ListExternalContentTypesAsync(string after=null, string before=null, int? size=null)
        {
            var resourceUrl = $"{urlPrefix}/types?" + BuildExternalContentQueryString(after,before,size);
            return await GenericGetAsync<GroupExternalContentTypesResponse>(resourceUrl);
        }

        public async Task<IndividualExternalContentTypeResponse> CreateExternalContentTypeAsync(ExternalContentTypeRequest externalContentType)
        {
            var resourceUrl = $"{urlPrefix}/types";
            return await GenericPostAsync<IndividualExternalContentTypeResponse>(resourceUrl,externalContentType);
        }

        public async Task<IndividualExternalContentTypeResponse> UpdateExternalContentTypeAsync(string externalTypeId, ExternalContentType externalContentType)
        {
            var resourceUrl = $"{urlPrefix}/types/{externalTypeId}";
            return await GenericPutAsync<IndividualExternalContentTypeResponse>(resourceUrl, externalContentType);
        }
        public async Task<bool?> DeleteExternalContentTypeAsync(string externalTypeId)
        {
            var resourceUrl = $"{urlPrefix}/types/{externalTypeId}";
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
