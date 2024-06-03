using NuGet.Frameworks;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using ZendeskApi_v2.Requests.FederatedSearch;
using ZendeskApi_v2.Models.FederatedSearch;
using ZendeskApi_v2.Tests.Base;

namespace ZendeskApi_v2.Tests.FederatedSearch;

[TestFixture]
[Category("FederatedSearch")]
[Parallelizable(ParallelScope.None)]
public class ExternalContentRecordsTest : TestBase
{

    private string _externalContentId = String.Empty;
    private string _externalContentIdAsync = String.Empty;
    private ExternalContentType _externalContentType = null;
    private ExternalContentSource _externalContentSource = null;

    [OneTimeSetUp]
    public void ExternalContentSetUp() {

        var _externalContentTypePayload = new ExternalContentTypeRequest
        {
            Type = new ExternalContentType
            {
                Name = "Test External Type"
            }
        };
        var typeRes = Api.FederatedSearch.ExternalContentTypes.CreateExternalContentType(_externalContentTypePayload);
        _externalContentType = typeRes?.Type;

        

        var _externalContentSourcePayload = new ZendeskApi_v2.Models.FederatedSearch.ExternalContentSourceRequest
        {
            Source = new ZendeskApi_v2.Models.FederatedSearch.ExternalContentSource
            {
                Name = "Test Source"
            }
        };

        var sourceRes = Api.FederatedSearch.ExternalContentSources.CreateExternalContentSource(_externalContentSourcePayload);
        _externalContentSource = sourceRes?.Source;

    }

    [OneTimeTearDown]
    public async Task ExternalContentCleanUp() 
    {

        await Api.FederatedSearch.ExternalContentSources.DeleteExternalContentSourceAsync(_externalContentSource.Id);
        await Api.FederatedSearch.ExternalContentTypes.DeleteExternalContentTypeAsync(_externalContentType.Id);

    }


    [Test, Order(1)]
    public void CanCreateAndUpdateExternalContentRecord()
    {

        var createRecordPayload = new ZendeskApi_v2.Models.FederatedSearch.ExternalContentRecordRequest { 
            Record = new ZendeskApi_v2.Models.FederatedSearch.CreateUpdateExternalContentRecord 
            {
                TypeId = _externalContentType.Id,
                SourceId = _externalContentSource.Id,
                Title = "Test External Content Record",
                Body = "Body of a test external content record",
                ExternalId = "ANYID",
                Locale = "en-us",
                Url = "https://example.com/test/external/content",
                UserSegmentId = "-1"
            } 
        };

        var res = Api.FederatedSearch.ExternalContentRecords.CreateExternalContentRecord(createRecordPayload);

        Assert.That(res.Record,Is.Not.Null);
        _externalContentId = res.Record.Id;

        createRecordPayload.Record.Body = "Updated Body";
        var updateRes = Api.FederatedSearch.ExternalContentRecords.UpdateExternalContentRecord(res.Record.Id, createRecordPayload);

        Assert.Multiple(() =>
        {
            Assert.That(updateRes.Record.Body, Is.EqualTo(createRecordPayload.Record.Body));
        });
    }

    [Test, Order(2)]
    public async Task CanCreateAndUpdateExternalContentRecordAsync()
    {

        var createRecordPayload = new ZendeskApi_v2.Models.FederatedSearch.ExternalContentRecordRequest
        {
            Record = new ZendeskApi_v2.Models.FederatedSearch.CreateUpdateExternalContentRecord
            {
                TypeId = _externalContentType.Id,
                SourceId = _externalContentSource.Id,
                Title = "Test External Content Record",
                Body = "Body of a test external content record",
                ExternalId = "ANYIDASYNC",
                Locale = "en-us",
                Url = "https://example.com/test/external/content",
                UserSegmentId = "-1"
            }
        };

        var res =  await Api.FederatedSearch.ExternalContentRecords.CreateExternalContentRecordAsync(createRecordPayload);
        Assert.That(res.Record,Is.Not.Null);
        _externalContentIdAsync = res.Record.Id;

        createRecordPayload.Record.Body = "Updated Body";
        var updateRes = await Api.FederatedSearch.ExternalContentRecords.UpdateExternalContentRecordAsync(res.Record.Id, createRecordPayload);

        Assert.Multiple( () =>
        {
            Assert.That(updateRes.Record.Body, Is.EqualTo(createRecordPayload.Record.Body));
        });

    }
    [Test, Order(3)]
    public void CanGetSingleExternalContentRecord()
    {
        var res = Api.FederatedSearch.ExternalContentRecords.ShowExternalContentRecord(_externalContentId);
        Assert.That(res.Record, Is.Not.Null);
    }

    [Test, Order(4)]
    public async Task CanGetSingleExternalContentRecordAsync()
    {
        var res = await Api.FederatedSearch.ExternalContentRecords.ShowExternalContentRecordAsync(_externalContentId);
        Assert.That(res.Record, Is.Not.Null);
    }

    [Test, Order(5)]
    public void CanGetExternalContentRecords()
    {
        var res = Api.FederatedSearch.ExternalContentRecords.ListExternalContentRecords();
        Assert.That(res.Records.Count, Is.GreaterThan(0));
    }

    [Test, Order(6)]
    public async Task CanGetExternalContentRecordsAsync()
    {
        var res = await Api.FederatedSearch.ExternalContentRecords.ListExternalContentRecordsAsync();
        Assert.That(res.Records.Count, Is.GreaterThan(0));
    }
    [Test, Order(7)]
    public void CanDeleteExternalContentRecord() 
    {
        var res = Api.FederatedSearch.ExternalContentRecords.DeleteExternalContentRecord(_externalContentId);
        Assert.IsTrue(res == null || res == true);
    }

    [Test, Order(8)]
    public async Task CanDeleteExternalContentRecordAsync() 
    {
        var res = await Api.FederatedSearch.ExternalContentRecords.DeleteExternalContentRecordAsync(_externalContentIdAsync);
        Assert.IsTrue(res == null || res == true);
    }
}