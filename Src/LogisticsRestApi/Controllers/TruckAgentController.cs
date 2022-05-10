using LogisticsRestApi.Model;
using Logistics_Hackathon_CSharp.Model;
using Microsoft.AspNetCore.Mvc;

namespace LogisticksRestApi.Controllers;

[ApiController]
[Route("decide")]
public class TruckAgentController : ControllerBase
{
    private readonly ILogger<TruckAgentController> _logger;

    public TruckAgentController(ILogger<TruckAgentController> logger) { _logger = logger; }

    [Produces("application/json")]
    [HttpPost(Name = "decide")]
    public DecideResponse Decide(DecideRequest request)
    {
        _logger.LogInformation("Decide request received {@truck} {@offers}", request.Truck, request.Offers);
        var firstOffer = request.Offers.FirstOrDefault();
        
        if (firstOffer != null) { return DecideResponse.Deliver(firstOffer.Uid); }

        return DecideResponse.Sleep(1);
    }
}