using Microsoft.VisualBasic;
using Newtonsoft.Json;
using NuGet.Frameworks;
using NUnit.Framework;
using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using ZendeskApi_v2.Requests.FederatedSearch;
using ZendeskApi_v2.Tests.Base;

namespace ZendeskApi_v2.Tests.FederatedSearch;

[TestFixture]
[Category("FederatedSearch")]
[Parallelizable(ParallelScope.None)]
public class ExternalContentSourcesTest : TestBase
{

    private string _externalSourceId = String.Empty;
    private string _externalSourceIdAsync = String.Empty;
    //need to create a source and use id as external source

    [Test, Order(1)]
    public void CanCreateExternalContentSource()
    {
        var testPayload = new ZendeskApi_v2.Models.FederatedSearch.ExternalContentSourceRequest { 
            Source = new ZendeskApi_v2.Models.FederatedSearch.ExternalContentSource
            {
                Name = "Test Source"
            }
         };
            
        var res = Api.FederatedSearch.ExternalContentSources.CreateExternalContentSource(testPayload);
        Assert.That(res.Source.Id, Is.Not.Null);
        _externalSourceId = res.Source.Id;
    }
    [Test, Order(2)]
    public async Task CanCreateExternalContentSourceAsync()
    {
        var testPayload = new ZendeskApi_v2.Models.FederatedSearch.ExternalContentSourceRequest
        {
            Source = new ZendeskApi_v2.Models.FederatedSearch.ExternalContentSource
            {
                Name = "Test Async"
            }
        };

        var res = await Api.FederatedSearch.ExternalContentSources.CreateExternalContentSourceAync(testPayload);
        Assert.That(res.Source.Id, Is.Not.Null);
        _externalSourceIdAsync = res.Source.Id;
    }

    [Test, Order(3)]
    public void CanGetSingleExternalContentSource()
    {
        var res = Api.FederatedSearch.ExternalContentSources.ShowExternalContentSource(_externalSourceId);
        Assert.That(res.Source, Is.Not.Null);
    }

    [Test, Order(4)]
    public async Task  CanGetSingleExternalContentSourceAsync()
    {
        var res = await Api.FederatedSearch.ExternalContentSources.ShowExternalContentSourceAsync(_externalSourceId);
        Assert.That(res.Source, Is.Not.Null);
    }

    [Test, Order(5)]
    public void CanGetExternalContentSources()
    {
        var res = Api.FederatedSearch.ExternalContentSources.ListExternalContentSources();
        Assert.That(res.Sources.Count,Is.GreaterThan(0));
    }

    [Test, Order(6)]
    public async Task CanGetExternalContentSourcesAsync()
    {
        var res = await Api.FederatedSearch.ExternalContentSources.ListExternalContentSourcesAsync();
        Assert.That(res.Sources.Count, Is.GreaterThan(0));
    }
    [Test, Order(7)]
    public void CanDeleteExternalContentSources()
    {
        var res = Api.FederatedSearch.ExternalContentSources.DeleteExternalContentSource(_externalSourceId);
        Assert.IsTrue(res == null || res == true);
    }
    [Test, Order(8)]
    public async Task CanDeleteExternalContentSourcesAsync()
    {
        var res = await Api.FederatedSearch.ExternalContentSources.DeleteExternalContentSourceAsync(_externalSourceIdAsync);
        Assert.IsTrue(res == null || res == true);
    }
}