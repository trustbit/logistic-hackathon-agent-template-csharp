using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LogisticsRestApi.Model;
using Logistics_Hackathon_CSharp.Model;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Tests;

public class TruckAgentControllerTests
{
    private DecideRequest _request;

    // client
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        // init request from file: decide.json
        string filePath = "Resources/decide.json";
        string json = File.ReadAllText(filePath);
        // deserialize
        _request = JsonConvert.DeserializeObject<DecideRequest>(json);
        var application = new WebApplicationFactory<Program>()
           .WithWebHostBuilder(
                builder =>
                {
                    // ... Configure test services
                });

        _client = application.CreateClient();
    }

    [Test]
    public async Task Not_Empty_Offers_results_in_deliver_command()
    {
        var response = _client.PostAsJsonAsync("/decide", _request).Result;
        var responseBody = await response.Content.ReadAsStringAsync();
        var responseObject = JsonConvert.DeserializeObject<DecideResponse>(responseBody);

        // ensure deliver command is returned
        Assert.AreEqual(DecisionResponseType.Deliver.ToString(), responseObject.Command.Value.ToString());
    }

    [Test]
    public async Task Empty_offers_results_in_sleep_command()
    {
        // remove offers from request
        var requestWithoutOffers = _request with { Offers = new List<CargoOffer>() };

        var response = _client.PostAsJsonAsync("/decide", requestWithoutOffers).Result;
        var responseBody = await response.Content.ReadAsStringAsync();
        var responseObject = JsonConvert.DeserializeObject<DecideResponse>(responseBody);

        // ensure sleep command is returned
        Assert.AreEqual(DecisionResponseType.Sleep.ToString(), responseObject.Command.Value.ToString());
    }
    // do request to /decide
}