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
    public interface IExternalContentRecords : ICore
    {
#if SYNC
        IndividualExternalContentRecordResponse ShowExternalContentRecord(string externalRecordId);
        GroupExternalContentRecordsResponse ListExternalContentRecords(string after = null, string before = null, int? size = null);
        IndividualExternalContentRecordResponse CreateExternalContentRecord(ExternalContentRecordRequest externalContentRecord);

        IndividualExternalContentRecordResponse UpdateExternalContentRecord(string externalRecordId, ExternalContentRecordRequest externalContentRecord);
        bool? DeleteExternalContentRecord(string externalRecordId);
#endif
#if ASYNC   
        Task<IndividualExternalContentRecordResponse> ShowExternalContentRecordAsync(string externalRecordId);
        Task<GroupExternalContentRecordsResponse> ListExternalContentRecordsAsync(string after = null, string before = null, int? size = null);     
        Task<IndividualExternalContentRecordResponse> CreateExternalContentRecordAsync(ExternalContentRecordRequest externalContentRecord);
        Task<IndividualExternalContentRecordResponse> UpdateExternalContentRecordAsync(string externalRecordId, ExternalContentRecordRequest externalContentRecord);
        Task<bool?> DeleteExternalContentRecordAsync(string externalRecordId);
#endif

    }

    public class ExternalContentRecords: Core, IExternalContentRecords
    {
        private readonly string urlPrefix = "guide/external_content";

        public ExternalContentRecords(string yourZendeskUrl, string user, string password, string apiToken, string locale, string p_OAuthToken, Dictionary<string,string> customHeaders)
            : base(yourZendeskUrl, user, password, apiToken, p_OAuthToken, customHeaders)
        {
            if (!locale.IsNullOrWhiteSpace())
            {
                urlPrefix = $"{urlPrefix}";
            }
        }
#if SYNC
        public IndividualExternalContentRecordResponse ShowExternalContentRecord(string externalRecordId)
        {
            var resourceUrl = $"{urlPrefix}/records/{externalRecordId}";

            return GenericGet<IndividualExternalContentRecordResponse>(resourceUrl);
        }
        public GroupExternalContentRecordsResponse ListExternalContentRecords(string after=null, string before=null, int? size=null)
        {
            var resourceUrl = $"{urlPrefix}/records?" + BuildExternalContentQueryString(after,before,size);

            return GenericGet<GroupExternalContentRecordsResponse>(resourceUrl);

        }

        public IndividualExternalContentRecordResponse CreateExternalContentRecord(ExternalContentRecordRequest externalContentRecord)
        {
            var resourceUrl = $"{urlPrefix}/records";

            return GenericPost<IndividualExternalContentRecordResponse>(resourceUrl,externalContentRecord);
        }

        public IndividualExternalContentRecordResponse UpdateExternalContentRecord(string externalRecordId, ExternalContentRecordRequest externalContentRecord)
        {
            var resourceUrl = $"{urlPrefix}/records/{externalRecordId}";
            return GenericPut<IndividualExternalContentRecordResponse>(resourceUrl, externalContentRecord);
        }
        public bool? DeleteExternalContentRecord(string externalRecordId)
        {
            var resourceUrl = $"{urlPrefix}/records/{externalRecordId}";
            return GenericDelete<bool?>(resourceUrl);
        }
#endif

#if ASYNC
        public async Task<IndividualExternalContentRecordResponse> ShowExternalContentRecordAsync(string externalRecordId)
        {
            var resourceUrl = $"{urlPrefix}/records/{externalRecordId}";

            return await GenericGetAsync<IndividualExternalContentRecordResponse>(resourceUrl);
        }

        public async Task<GroupExternalContentRecordsResponse> ListExternalContentRecordsAsync(string after=null, string before=null, int? size=null)
        {
            var resourceUrl = $"{urlPrefix}/records?" + BuildExternalContentQueryString(after,before,size);

            return await GenericGetAsync<GroupExternalContentRecordsResponse>(resourceUrl);

        }

        public async Task<IndividualExternalContentRecordResponse> CreateExternalContentRecordAsync(ExternalContentRecordRequest externalContentRecord)
        {
            var resourceUrl = $"{urlPrefix}/records";
            
            return await GenericPostAsync<IndividualExternalContentRecordResponse>(resourceUrl,externalContentRecord);
        }

        public async Task<IndividualExternalContentRecordResponse> UpdateExternalContentRecordAsync(string externalRecordId, ExternalContentRecordRequest externalContentRecord)
        {
            var resourceUrl = $"{urlPrefix}/records/{externalRecordId}";
            return await GenericPutAsync<IndividualExternalContentRecordResponse>(resourceUrl, externalContentRecord);
        }
        public async Task<bool?> DeleteExternalContentRecordAsync(string externalRecordId)
        {
            var resourceUrl = $"{urlPrefix}/records/{externalRecordId}";
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
