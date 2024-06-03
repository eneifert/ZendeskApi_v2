using Newtonsoft.Json;
using NuGet.Frameworks;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using ZendeskApi_v2.Requests.FederatedSearch;
using ZendeskApi_v2.Tests.Base;

namespace ZendeskApi_v2.Tests.FederatedSearch;

[TestFixture]
[Category("FederatedSearch")]
[Parallelizable(ParallelScope.None)]
public class ExternalContentTypesTest : TestBase
{

    private string _externalTypeId = String.Empty;
    private string _externalTypeIdAsync = String.Empty;

    [Test, Order(1)]
    public void CanCreateExternalContentType()
    {
        var testPayload = new ZendeskApi_v2.Models.FederatedSearch.ExternalContentTypeRequest
        {
            Type = new ZendeskApi_v2.Models.FederatedSearch.ExternalContentType
            {
                Name = "Test Type"
            }
        };

        var res = Api.FederatedSearch.ExternalContentTypes.CreateExternalContentType(testPayload);
        Assert.That(res.Type.Id, Is.Not.Null);
        _externalTypeId = res.Type.Id;
    }

    [Test, Order(2)]
    public async Task CanCreateExternalContentTypeAsync()
    {

        var testPayload = new ZendeskApi_v2.Models.FederatedSearch.ExternalContentTypeRequest
        {
            Type = new ZendeskApi_v2.Models.FederatedSearch.ExternalContentType
            {
                Name = "Test Type Async"
            }
        };

        var res = await Api.FederatedSearch.ExternalContentTypes.CreateExternalContentTypeAsync(testPayload);
        Assert.That(res.Type.Id, Is.Not.Null);
        _externalTypeIdAsync = res.Type.Id;
    }

    [Test, Order(3)]
    public void CanGetSingleExternalContentType()
    {
        var res = Api.FederatedSearch.ExternalContentTypes.ShowExternalContentType(_externalTypeId);
        Assert.That(res.Type, Is.Not.Null);
    }

    [Test, Order(4)]
    public async Task CanGetSingleExternalContentTypeAsync()
    {
        var res = await Api.FederatedSearch.ExternalContentTypes.ShowExternalContentTypeAsync(_externalTypeId);
        Assert.That(res.Type, Is.Not.Null);
    }

    [Test, Order(5)]
    public void CanGetExternalContentTypes()
    {
        var res = Api.FederatedSearch.ExternalContentTypes.ListExternalContentTypes();
        Assert.That(res.Types.Count, Is.GreaterThan(0));
    }

    [Test, Order(6)]
    public async Task CanGetExternalContentTypesAsync()
    {
        var res = await Api.FederatedSearch.ExternalContentTypes.ListExternalContentTypesAsync();
        Assert.That(res.Types.Count, Is.GreaterThan(0));
    }

    [Test, Order(7)]
    public void CanDeleteExternalContentType()
    {
        var res = Api.FederatedSearch.ExternalContentTypes.DeleteExternalContentType(_externalTypeId);
        Assert.IsTrue(res == null || res == true);
    }

    [Test, Order(8)]
    public async Task CanDeleteExternalContentTypeAsync()
    {
        var res =await Api.FederatedSearch.ExternalContentTypes.DeleteExternalContentTypeAsync(_externalTypeIdAsync);
        Assert.IsTrue(res == null || res == true);

    }
}